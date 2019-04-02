using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;

namespace ServerlessTodo.Api
{
    public class FunctionAppStartup : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                })
                .Functions(functions =>
                {
                });
        }
    }
}