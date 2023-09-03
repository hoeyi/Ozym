using Microsoft.Extensions.DependencyInjection;
using NjordinSight.BusinessLogic.Functions;
using NjordinSight.BusinessLogic.MarketFeed;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Context;
using NjordinSight.Web.Controllers;
using NjordinSight.Web.Controllers.Abstractions;
using NjordinSight.Web.Services;
using NjordinSight.Web.Data;
using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Ichosys.DataModel.Expressions;
using Ichosys.DataModel;
using NjordinSight.Messaging;
using NjordinSight.UserInterface;
using Ichosys.Blazor.Ionicons;
using System.Xml.Serialization;
using System.Reflection;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;

namespace NjordinSight.Web
{
    /// <summary>
    /// Container for <see cref="IServiceCollection"/> extension methods that handle 
    /// registering web layer services for use with dependency injection.
    /// </summary>
    public static class IServiceCollectionExtWeb
    {
        /// <summary>
        /// Database or database store for the web identity management entity model.
        /// </summary>
        private const string identity_db_name = "NjordIdentity";

        /// <summary>
        /// Registers all services required for classes in the <b>NjordinSight.DAL</b>
        /// assembly.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>A reference to this instance after the operation is completed.</returns>
        /// <remarks>
        /// Calls <see cref="AddModelControllers(IServiceCollection)"/> and 
        /// <see cref="AddRazorHelperServices(IServiceCollection)"/>.
        /// </remarks>
        public static IServiceCollection AddBlazorPageServices(this IServiceCollection services)
        {
            services
                .AddModelControllers()
                .AddRazorHelperServices();

            return services;
        }

        /// <summary>
        /// Adds the controllers to the collection.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddModelControllers(this IServiceCollection services)
        {
            services
                // Add single-entity controllers.
                .AddScoped<IController<Account>, ModelController<Account>>()
                .AddScoped<IController<AccountComposite>, ModelController<AccountComposite>>()
                .AddScoped<IController<AccountCustodian>, ModelController<AccountCustodian>>()
                .AddScoped<IController<BankTransactionCode>, ModelController<BankTransactionCode>>()
                .AddScoped<IController<BrokerTransactionCode>, ModelController<BrokerTransactionCode>>()
                .AddScoped<IController<Country>, ModelController<Country>>()
                .AddScoped<IController<InvestmentStrategy>, ModelController<InvestmentStrategy>>()
                .AddScoped<IController<MarketHoliday>, ModelController<MarketHoliday>>()
                .AddScoped<IController<MarketIndex>, ModelController<MarketIndex>>()
                .AddScoped<IController<ModelAttribute>, ModelController<ModelAttribute>>()
                .AddScoped<IController<ReportConfiguration>, ModelController<ReportConfiguration>>()
                .AddScoped<IController<ReportStyleSheet>, ModelController<ReportStyleSheet>>()
                .AddScoped<IController<ResourceImage>, ModelController<ResourceImage>>()
                .AddScoped<IController<SecurityExchange>, ModelController<SecurityExchange>>()
                .AddScoped<IController<Security>, ModelController<Security>>()
                .AddScoped<IController<SecurityTypeGroup>, ModelController<SecurityTypeGroup>>()
                .AddScoped<IController<SecurityType>, ModelController<SecurityType>>()
                .AddScoped<IController<SecurityPrice>, ModelController<SecurityPrice>>()

                // Add entity-collection controllers.
                .AddScoped<ICollectionController<
                    AccountCustodian>, ModelCollectionController<AccountCustodian>>()
                .AddScoped<
                    ICollectionController<AccountWallet, int>, 
                    ModelCollectionController<AccountWallet, int>>()
                .AddScoped<
                    ICollectionController<BankTransaction, int>, 
                    ModelCollectionController<BankTransaction, int>>()
                .AddScoped<
                    IBrokerTransactionController, BrokerTransactionController>()
                .AddScoped<
                    ICollectionController<
                        InvestmentPerformanceAttributeMemberEntry, (AccountObject, ModelAttributeMember)>,
                    ModelCollectionController<
                        InvestmentPerformanceAttributeMemberEntry, (AccountObject, ModelAttributeMember)>>()
                .AddScoped<
                    ICollectionController<InvestmentPerformanceEntry, int>, 
                    ModelCollectionController<InvestmentPerformanceEntry, int>>()
                .AddScoped<
                    ICollectionController<MarketHolidayObservance>, 
                    ModelCollectionController<MarketHolidayObservance>>()
                .AddScoped<
                    ICollectionController<MarketIndexPrice>, 
                    ModelCollectionController<MarketIndexPrice>>()
                .AddScoped<
                    ICollectionController<SecurityExchange>, 
                    ModelCollectionController<SecurityExchange>>()
                .AddScoped<
                    ICollectionController<SecurityPrice>, 
                    ModelCollectionController<SecurityPrice>>();

            return services;
        }

        /// <summary>
        /// Registers <see cref="IHttpClientFactory"/> and <see cref="IHttpService{T}"/> services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>A reference to this instance after the operation is completed.</returns>
        /// <remarks>
        public static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient(typeof(IHttpService<>), typeof(HttpService<>));
            services.AddTransient(typeof(IReferenceDataService), typeof(ReferenceDataService));

            return services;
        }

        /// <summary>
        /// Registers helpers services required for pages in the <b>NjordinSight.Web</b>
        /// assembly.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>A reference to this instance after the operation is completed.</returns>
        /// <remarks>Adds to the DI container:
        /// <list type="bullet">
        /// <item><see cref="ITypedMetadataService{T}"/></item>
        /// <item><see cref="IExpressionBuilder"/></item>
        /// <item><see cref="ISearchService{T}"/></item>
        /// </list>
        /// <see cref="IModelMetadataService"/> is not included because it is registered by 
        /// <see cref="IServiceCollectionExtDAL.AddDataAccessServices(IServiceCollection)"/>
        /// </remarks>
        public static IServiceCollection AddRazorHelperServices(this IServiceCollection services)
        {
            services
                .AddSingleton(typeof(ITypedMetadataService<>), typeof(TypedMetadataService<>))
                .AddSingleton<IExpressionBuilder, ExpressionBuilder>()
                .AddTransient(typeof(ISearchService<>), typeof(SearchService<>))
                .AddSingleton(ISvgHelper.Create());

            return services;
        }

        /// <summary>
        /// Configures the <see cref="FinanceDbContext"/> and <see cref="IdentityDbContext"/> 
        /// factory services.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="databaseProvider">The string name identifying the database provide.</param>
        /// <exception cref="NotSupportedException"></exception>
        public static void AddIdentityContextFactoryService(
            this WebApplicationBuilder builder, string databaseProvider)
        {
            builder.Services.AddDbContext<IdentityDbContext>(options =>
            {
                if (string.IsNullOrEmpty(databaseProvider) && builder.Environment.IsDevelopment())
                    options.UseInMemoryDatabase(identity_db_name);

                else if (databaseProvider == "SQL_SERVER")
                    options.UseSqlServer(
                        connectionString: $"Name=ConnectionStrings:{identity_db_name}");
                else
                    throw new NotSupportedException();
            });
        }

        /// <summary>
        /// Trys to extract the display string member accessor associated with the given key.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="displayMember"></param>
        /// <returns></returns>
        public static string TryGetDisplayString<TKey, TValue>(
            this IDictionary<TKey, TValue> dict, TKey key, Func<TValue, string> displayMember)
        {
            if(dict.TryGetValue(key, out TValue value))
            {
                return displayMember(value);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
