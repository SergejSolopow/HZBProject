using AutoMapper;
using BeamlineX.Domain;
using BeamlineX.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamlineX.DtoMapper
{
    internal class CreateMeasureSetMapper : DFMapper<CreateMeasureSetDto, MeasureSet>
    {
        protected override void Map(IMappingExpression<CreateMeasureSetDto, MeasureSet> exp)
        {
            exp.ForMember(c => c.Temperature, m => m.MapFrom(c => c.Temperature));
            exp.ForMember(c => c.MeasureTime, m => m.MapFrom(c => c.MeasureTime));
            exp.ForMember(c => c.MonochromatorPos, m => m.MapFrom(c => c.MonochromatorPos));
            exp.ForMember(c => c.LocationId, m => m.MapFrom(c => c.LocationId));
            exp.ForMember(c => c.AnglePosition, m => m.MapFrom(c => c.AnglePosition));
            exp.ForMember(c => c.Intensity, m => m.MapFrom(c => c.Intensity));
        }
    }
}
