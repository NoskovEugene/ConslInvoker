using Core.TypeConverter.Configuration;
using Models;
namespace Core.TypeConverter
{
    public class TypeMapperFactory
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