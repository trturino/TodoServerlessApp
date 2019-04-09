using System.Net.Http;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using ServerlessTodo.Domain.Commands.Todo;
using ServerlessTodo.Domain.Handlers.CommandHandlers;
using ServerlessTodo.Domain.Handlers.QueryHandlers;
using ServerlessTodo.Domain.Queries.Todo;

namespace ServerlessTodo.Api
{
    public class FunctionAppStartup : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    commandRegistry.Register<AddNewTodoCommandHandler>();
                    commandRegistry.Register<DoneTodoCommandHandler>();
                    commandRegistry.Register<RemoveTodoCommandHandler>();
                    commandRegistry.Register<GetAllTodosQueryHandler>();
                    commandRegistry.Register<GetCompletedTodosQueryHandler>();
                    commandRegistry.Register<GetPendingTodosQueryHandler>();

                })
                .OpenApiEndpoint(openApi => openApi
                    .Title("Todo API")
                    .Version("1.0.0")
                    .UserInterface()
                )
                .Functions(functions => functions
                    .HttpRoute("v1/todo", route => route
                        .HttpFunction<AddNewTodoCommand>(AuthorizationTypeEnum.Anonymous, HttpMethod.Post)
                    )
                    .HttpRoute("v1/todo/done", route => route
                        .HttpFunction<DoneTodoCommand>(AuthorizationTypeEnum.Anonymous, HttpMethod.Put)
                    )
                    .HttpRoute("v1/todo", route => route
                        .HttpFunction<RemoveTodoCommand>(AuthorizationTypeEnum.Anonymous, HttpMethod.Delete)
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