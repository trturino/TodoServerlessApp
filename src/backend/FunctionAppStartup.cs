using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;

namespace ServerlessTodo
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
                );
        }
    }
}