using SharedModels;

namespace Core.TypeConverter
{
    public interface ITypeMapperFactory
    {
        void Configure(Profile profile);

        ITypeMapper GetTypeMapper();
    }
}