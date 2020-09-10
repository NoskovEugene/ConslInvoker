using System;
using Models;
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
            var converter = Controller.RequestConverter<TIn, TOut>();
            try
            {
                var result = converter.Convert(instance);
                return new TypeMapperResult<TOut>(result, true, null);
            }
            catch (Exception ex)
            {
                return new TypeMapperResult<TOut>(default, false, ex);
            }
        }
    }
}