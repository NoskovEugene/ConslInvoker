using System.Linq.Expressions;
using System;
using System.Reflection;

namespace Core.TypeConverter.Configuration
{
    public class ConvertConfiguration
    {
        public Type Source { get; set; }

        public Type Destination { get; set; }

        public Type ConverterType { get; set; }

        public LambdaExpression ConvertExpression { get; set; }

        public object ConverterInstance { get; set; }
    }
}