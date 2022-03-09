using AutoMapper;
using BeamlineX.Domain;
using BeamlineX.Dtos;
using BeamlineX.Repositories.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace BeamlineX.Api.Controllers
{
    public class MeasureSetController : BaseController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MeasureSetController> _logger;

        public MeasureSetController(IRepository repository, IMapper mapper, ILogger<MeasureSetController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateMeasureSetDto createMeasureSetDto)
        {
            MeasureSet measureSet = _mapper.Map<MeasureSet>(createMeasureSetDto);
            await _repository.InsertAsync(measureSet);
            await _repository.SaveChangesAsync();

            return Ok(measureSet);
        }
    }
}
