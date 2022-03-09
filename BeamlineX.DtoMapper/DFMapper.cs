using AutoMapper;

namespace BeamlineX.DtoMapper
{
    internal abstract class DFMapper<T1, T2> : IDFMapper
    {
        public void InitMap(DFProfile profile)
        {;
            IMappingExpression<T1, T2> exp = profile.CreateMap<T1, T2>();
            Map(exp);
        }

        protected abstract void Map(IMappingExpression<T1, T2> exp);
    }
}
