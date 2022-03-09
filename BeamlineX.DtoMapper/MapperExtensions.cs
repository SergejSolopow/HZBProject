using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

namespace BeamlineX.DtoMapper
{
    public static class MapperExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(c =>
                {
                    c.AllowNullCollections = false;
                    //c.ConstructServicesUsing()
                },
                typeof(DFProfile));
        }

        public static IMapper GetMapper()
        {
            MapperConfiguration mockMapper = new(cfg =>
            {
                cfg.AddProfile(new DFProfile());
            });

            return mockMapper.CreateMapper();
        }

        public static ICollection<T2> Map<T1, T2>(this IMapper mapper, ICollection<T1> collection)
        {
            return collection.Select(e => mapper.Map<T1, T2>(e)).ToList();
        }
    }
}
