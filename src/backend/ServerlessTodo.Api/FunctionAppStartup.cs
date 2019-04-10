using System;
using System.Net.Http;
using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.Extensions.DependencyInjection;
using ServerlessTodo.Api.ResponseHandler;
using ServerlessTodo.Domain.Commands.Todo;
using ServerlessTodo.Domain.Handlers.CommandHandlers;
using ServerlessTodo.Domain.Handlers.QueryHandlers;
using ServerlessTodo.Domain.Models;
using ServerlessTodo.Domain.Queries.Todo;
using ServerlessTodo.Domain.Repositories;
using ServerlessTodo.Infra.Repositories;

namespace ServerlessTodo.Api
{
    public class FunctionAppStartup : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    var cosmosDbUri = Environment.GetEnvironmentVariable("CosmosDbUri");
                    var cosmosDbKey = Environment.GetEnvironmentVariable("CosmosDbKey");
                    var cosmosSettings = new CosmosStoreSettings("TodoDb", new Uri(cosmosDbUri), cosmosDbKey);

                    commandRegistry.Register<AddNewTodoCommandHandler>();
                    commandRegistry.Register<DoneTodoCommandHandler>();
                    commandRegistry.Register<RemoveTodoCommandHandler>();
                    commandRegistry.Register<GetAllTodosQueryHandler>();
                    commandRegistry.Register<GetCompletedTodosQueryHandler>();
                    commandRegistry.Register<GetPendingTodosQueryHandler>();

                    serviceCollection.AddCosmosStore<Todo>(cosmosSettings);
                    serviceCollection.AddScoped<ITodoWriteRepository, TodoRepository>();
                    serviceCollection.AddScoped<ITodoReadOnlyRepository, TodoRepository>();
                })
                .OpenApiEndpoint(openApi => openApi
                    .Title("Todo API")
                    .Version("1.0.0")
                )
                .Functions(functions => functions
                    .HttpRoute("v1/todo", route => route
                        .HttpFunction<AddNewTodoCommand>(AuthorizationTypeEnum.Anonymous, HttpMethod.Post)
                    )
                    .HttpRoute("v1/todo/done", route => route
                        .HttpFunction<DoneTodoCommand>(AuthorizationTypeEnum.Anonymous, HttpMethod.Put)
                        .Options(options => options.ResponseHandler<AcceptedResponseHandler>())
                    )
                    .HttpRoute("v1/todo", route => route
                        .HttpFunction<RemoveTodoCommand>(AuthorizationTypeEnum.Anonymous, HttpMethod.Delete)
                        .Options(options => options.ResponseHandler<AcceptedResponseHandler>())
                    )
                    .HttpRoute("v1/todo", route => route
                        .HttpFunction<GetAllTodosQuery>(AuthorizationTypeEnum.Anonymous, HttpMethod.Get)
                    )
                    .HttpRoute("v1/todo/completed", route => route
                        .HttpFunction<GetCompletedTodosQuery>(AuthorizationTypeEnum.Anonymous, HttpMethod.Get)
                    )
                    .HttpRoute("v1/todo/pending", route => route
                        .HttpFunction<GetPendingTodosQuery>(AuthorizationTypeEnum.Anonymous, HttpMethod.Get)
                    )
                );
        }
    }
}