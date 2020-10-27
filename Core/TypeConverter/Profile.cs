using System.Linq.Expressions;
using System;
using Core.TypeConverter.Configuration;
using SharedModels;
namespace Core.TypeConverter
{
    public abstract class Profile
    {
        public MapController controller { get; set; }

        public Profile()
        {
            controller = new MapController();
        }

        public void CreateMap<TIn, TOut, TConvert>()
        where TConvert : IValueTypeConverter<TIn,TOut>
        {
            controller.Add<TIn,TOut, TConvert>();
        }


        public void CreateMap<TIn,TOut>(Expression<Func<TIn,TOut>> convertExpression)
        {
            controller.Add<TIn,TOut>(convertExpression);
        }
    }
}