using System;
using System.Text;

using Core;

using Models;

using Infrastructure.Commands;
using Core.TypeConverter;

namespace ConsoleInvoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new InvokerCore();
            core.CommandManager.RegistryCommandUseAttribute<QuitCommand>();
            core.CommandManager.RegistryCommandUseAttribute<MessengerTestCommand>();
            core.CommandManager.RegistryCommandUseAttribute<RequesterTestCommand>();
            Console.ReadKey();
            var typeMapperFactory = new TypeMapperFactory();
            typeMapperFactory.Configure(new TestProfile());
            var TMapper = typeMapperFactory.GetTypeMapper();
            var result = TMapper.Map<string,int>("hello world");
            if(result.Converter)
            {
                Console.WriteLine(result.Item);
            }
            else{
                Console.WriteLine(result.Exception.Message);
            }
            Console.ReadKey();

        }

        class TestProfile : Profile
        {
            public TestProfile()
            {
                CreateMap<string,int,StringToIntConverter>();
            }
        }

        class StringToIntConverter : IValueTypeConverter<string, int>
        {
            public int Convert(string instance)
            {
                return int.Parse(instance);
            }
        }
    }
}