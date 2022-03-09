using AutoMapper;

using BeamlineX.Common.Extensions;

using MoreLinq;

namespace BeamlineX.DtoMapper
{
    internal class DFProfile : Profile
    {
        public DFProfile()
        {
            GetType()
                .Assembly
                .GetAssemblyObjects<IDFMapper>()
                .ForEach(c => c.InitMap(this));
        }
    }
}
