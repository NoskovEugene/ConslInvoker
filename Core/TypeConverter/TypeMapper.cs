using System;
using Shared.Models;
using Core.TypeConverter.Configuration;
namespace Core.TypeConverter
{
    public class TypeMapper : ITypeMapper
    {
        private MapController Controller { get; set; }

        public TypeMapper(MapController controller)
        {
            this.Controller = controller;
        }

        public TypeMapperResult<TOut> Map<TIn, TOut>(TIn instance)
        {
            var config = Controller.RequestConfig<TIn, TOut>();
            try
            {
                if (config.ConvertExpression != null)
                {
                    var result = (TOut)config.ConvertExpression.Compile().DynamicInvoke(instance);
                    return new TypeMapperResult<TOut>(result, true, null);
                }
                else
                {
                    var converter = (IValueTypeConverter<TIn, TOut>)config.ConverterInstance;
                    var result = converter.Convert(instance);
                    return new TypeMapperResult<TOut>(result, true, null);
                }

            }
            catch (Exception ex)
            {
                return new TypeMapperResult<TOut>(default, false, ex);
            }
        }

        
    }
}