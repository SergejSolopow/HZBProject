using AutoMapper;

using BeamlineX.Domain;
using BeamlineX.Dtos;

namespace BeamlineX.DtoMapper
{
    internal class CustomerViewMapper : DFMapper<Customer, CustomerViewDto>
    {
        protected override void Map(IMappingExpression<Customer, CustomerViewDto> exp)
        {
            exp.ForMember(c => c.Id, m => m.MapFrom(c => c.Id));
            exp.ForMember(c => c.Name, m => m.MapFrom(c => c.Name));
        }
    }
}
