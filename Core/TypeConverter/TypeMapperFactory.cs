using Core.TypeConverter.Configuration;
using SharedModels;
namespace Core.TypeConverter
{
    public class TypeMapperFactory : ITypeMapperFactory
    {
        private MapController MapController { get; set; }

        public TypeMapperFactory()
        {
            
        }

        public void Configure(Profile profile)
        {
            MapController = profile.controller;
        }

        public ITypeMapper GetTypeMapper()
        {
            return  new TypeMapper(MapController);
        }

    }
}