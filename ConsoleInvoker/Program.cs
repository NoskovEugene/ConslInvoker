using System.Reflection;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System;
using System.Text;

using Core;

using Models;

using Infrastructure.Commands;
using Core.TypeConverter;
using Core.CoreSettings;

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

            var methodInfo = typeof(Converter).GetMethod("Convert");
            var exp = Expression.Call(Expression.Constant(new Converter()),methodInfo);
            var lambda = Expression.Lambda(exp).Compile();
            var result = lambda.DynamicInvoke("123");
            Console.WriteLine(result);


            Console.ReadKey();
        }



    }

    public class Converter : IValueTypeConverter<string, int>
    {
        public int Convert(string instance)=>int.Parse(instance);
    }

    class TypeMapperExpression
    {
        public Type SourceType { get; set; }

        public Type DestinationType { get; set; }

        public Type ConverterType { get; set; }

        public object ConvertInstance { get; set; }


    }


}