using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NjordinSight.Api.Controllers;
using Ichosys.DataModel.Expressions;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModelService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NjordinSight.Api.Test.Unit
{
    public partial class ApiControllerTest<T, TEntity>
        where TEntity : class, new()
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IApiController{T}"/> using the given 
        /// <see cref="Mocks"/> record.
        /// </summary>
        /// <param name="mocks">Record containing the <see cref="Mock"/> objects.</param>
        /// <returns></returns>
        protected virtual ApiController<T, TEntity> InitTestController(Mocks mocks)
        {
            var controller = new ApiController<T, TEntity>(
                expressionBuilder: mocks.Expression.Object,
                mapper: mocks.Mapper.Object,
                modelService: mocks.ModelService.Object,
                logger: mocks.Logger.Object);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            return controller;
        }

        protected record Mocks
        {
            public Mock<IMapper> Mapper { get; init; } = new();

            public Mock<IExpressionBuilder> Expression { get; init; } = new();

            public Mock<ILogger> Logger { get; init; } = new();

            public Mock<IModelService<TEntity>> ModelService { get; init; } = new();
        }

        protected record NullableMocks
        {
            public Mock<IMapper> Mapper { get; init; } = default!;

            public Mock<IExpressionBuilder> Expression { get; init; } = default!;

            public Mock<ILogger> Logger { get; init; } = default!;

            public Mock<IModelService<TEntity>> ModelService { get; init; } = default!;
        }
    }
}
