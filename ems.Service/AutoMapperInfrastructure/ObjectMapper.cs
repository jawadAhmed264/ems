using AutoMapper;
using System;

namespace ems.Service.AutoMapperInfrastructure
{
    public class ObjectMapper
    {
        public static IMapper Mapper
        {
            get { return mapper.Value; }
        }

        public static IConfigurationProvider Configuration
        {
            get { return config.Value; }
        }

        public static Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
        {
            var mapper = new Mapper(Configuration);
            return mapper;
        });

        public static Lazy<IConfigurationProvider> config = new Lazy<IConfigurationProvider>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ems.Service.AutoMapperProfiles.AutomapperWebProfile>();
                //cfg.AddProfile<AppCore.Config.MapperProfile>();  // any other profiles you need to use
            });

            return config;
        });
    }
}
