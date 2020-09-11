using System.Threading;
using Core.TypeConverter;
using Core.CoreSettings.Converters;
namespace Core.CoreSettings
{
    public class TypeConverterDefaultProfile : Profile
    {
        public TypeConverterDefaultProfile()
        {
            CreateMap<string,int,StringToInt>();
            CreateMap<string,double,StringToDouble>();
        }
    }
}