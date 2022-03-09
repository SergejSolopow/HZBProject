using AutoMapper;

using BeamlineX.Domain;
using BeamlineX.Dtos;

namespace BeamlineX.DtoMapper
{
    internal class CreateCustomerMapper : DFMapper<CreateCustomerDto, Customer>
    {
        protected override void Map(IMappingExpression<CreateCustomerDto, Customer> exp)
        {
            exp.ForMember(c => c.CreatedDate, m => m.MapFrom(c => DateTime.Now));
            exp.ForMember(c => c.Id, m => m.MapFrom(c => Guid.NewGuid()));
            exp.ForMember(c => c.Name, m => m.MapFrom(c => c.Name));
            exp.ForMember(c => c.UpdatedDate, m => m.MapFrom(c => DateTime.Now));
        }
    }
}
