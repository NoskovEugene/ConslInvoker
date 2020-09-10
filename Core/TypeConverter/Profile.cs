using Core.TypeConverter.Configuration;
using Models;
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
    }
}