using AutoMapper;

using BeamlineX.Domain;
using BeamlineX.Repositories.Abstraction;

using Microsoft.AspNetCore.Mvc;

namespace BeamlineX.Api.Controllers
{
    public class MeasureSetsController : BaseController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MeasureSetsController> _logger;

        public MeasureSetsController(IRepository repository, IMapper mapper, ILogger<MeasureSetsController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation($"Getting all measurement values.");
            ICollection<MeasureSet> result = await _repository.GetAllAsync<MeasureSet>();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> ClearAll()
        {
            _logger.LogInformation($"Getting all measurement values.");
            await _repository.ClearAll<MeasureSet>();
            await _repository.SaveChangesAsync();
            return Ok();
        }
    }
}
