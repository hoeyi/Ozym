﻿using Microsoft.Extensions.DependencyInjection;
using Ozym.BusinessLogic.Functions;
using Ozym.BusinessLogic.MarketFeed;
//using Ozym.EntityModel.Context;
using Ozym.Web.Services;
using Ozym.Web.Data;
using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Ichosys.DataModel.Expressions;
using Ichosys.DataModel;
using Ozym.Messaging;
using Ozym.UserInterface;
using Ichosys.Blazor.Ionicons;
using System.Xml.Serialization;
using System.Reflection;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using Ozym.DataTransfer.Common;

namespace Ozym.Web
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
        private const string identity_db_name = "OzymIdentity";

        /// <summary>
        /// Registers all services required for classes in the <b>Ozym.DAL</b>
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
            services.AddRazorHelperServices();

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
            services
                .AddTransient(typeof(IHttpService<>), typeof(HttpService<>))
                .AddTransient(typeof(IHttpCollectionService<>), typeof(HttpService<>))
                .AddTransient(
                    serviceType: typeof(IHttpCollectionService<AccountWalletDto, int>),
                    implementationType: typeof(HttpService<AccountWalletDto, int>))
                .AddTransient(
                    serviceType: typeof(IHttpCollectionService<BankTransactionDto, int>),
                    implementationType: typeof(HttpService<BankTransactionDto, int>))
                .AddTransient(
                    serviceType: typeof(IHttpCollectionService<BrokerTransactionDto, int>),
                    implementationType: typeof(HttpService<BrokerTransactionDto, int>));

            return services;
        }

        /// <summary>
        /// Registers helpers services required for pages in the <b>Ozym.Web</b>
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
