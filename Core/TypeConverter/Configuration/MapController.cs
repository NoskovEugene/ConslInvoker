using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

using Shared.Models;

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
            };
            Map.Add(config);
        }

        public void Add<TIn, TOut>(Expression<Func<TIn, TOut>> convertExpression)
        {
            var config = new ConvertConfiguration()
            {
                Source = typeof(TIn),
                Destination = typeof(TOut),
                ConvertExpression = convertExpression
            };
            Map.Add(config);
        }

        public IEnumerable<ConvertConfiguration> GetMap()
        {
            return (IEnumerable<ConvertConfiguration>)Map;
        }



        public ConvertConfiguration RequestConfig<TIn, TOut>()
        {
            var item = Map.Where(x => x.Source == typeof(TIn) & x.Destination == typeof(TOut)).FirstOrDefault();

            if (item == null)
            {
                throw new Exception($"Map for {typeof(TIn)} to {typeof(TOut)} not found");
            }

            if (item.ConvertExpression != null)
            {
                return item;
            }
            else
            {
                if (item.ConverterInstance == null)
                    item.ConverterInstance = Activator.CreateInstance(item.ConverterType);
                return item;
            }
        }
    }
}
