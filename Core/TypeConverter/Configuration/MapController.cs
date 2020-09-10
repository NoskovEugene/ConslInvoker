using System;
using System.Collections.Generic;
using System.Linq;

using Models;

namespace Core.TypeConverter.Configuration
{
    public class MapController
    {
        private HashSet<ConvertConfiguration> Map { get; set; }

        public MapController()
        {
            Map = new HashSet<ConvertConfiguration>();
        }

        public void Add<TIn, TOut, TConverter>()
        where TConverter : IValueTypeConverter<TIn, TOut>
        {
            var config = new ConvertConfiguration()
            {
                Source = typeof(TIn),
                Destination = typeof(TOut),
                ConverterType = typeof(TConverter),
                CastMethod = typeof(TConverter).GetMethod("Cast")
            };
            Map.Add(config);
        }

        public IValueTypeConverter<TIn, TOut> RequestConverter<TIn, TOut>()
        {
            return (IValueTypeConverter<TIn, TOut>)RequestConfig<TIn, TOut>().ConverterInstance;
        }

        public ConvertConfiguration RequestConfig<TIn, TOut>()
        {
            var item = Map.Where(x => x.Source == typeof(TIn) & x.Destination == typeof(TOut)).FirstOrDefault();
            if (item.ConverterInstance == null)
            {
                item.ConverterInstance = Activator.CreateInstance(item.ConverterType);
            }
            return item;
        }
    }
}
