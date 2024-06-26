﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZenAchitecture.Application.Account.Cities.Dtos;
using ZenAchitecture.Application.Account.Cities.Queries;
using ZenAchitecture.Application.Account.Cities.Commands;
using Zen.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;


namespace ZenAchitecture.WebUI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CityController : ZenController
    {
        public CityController(ILogger<CityController> logger)
        {
            logger.LogInformation("Test LogInformation");
            logger.LogWarning("Test LogWarning");
            logger.LogError("Test LogError");
            logger.LogCritical("Test LogCritical");
            logger.LogTrace("Test LogTrace");
        }

        [HttpGet]
        [Route(nameof(ReadCity))]
        public async Task<CityDto> ReadCity(int id) => await Mediator.Send(new GetCityQuery { Id = id });

        [HttpGet, Authorize]
        [Route(nameof(GetCities))]
        public async Task<IEnumerable<CityDto>> GetCities() => await Mediator.Send(new GetCitiesQuery());

        [HttpPost]
        [Route(nameof(CreateCity))]
        public async Task<int> CreateCity(CreateCityCommand command) => await Mediator.Send(command);

        [HttpPost]
        [Route((nameof(UpdateCity)))]
        public async Task<int> UpdateCity(UpdateCityCommand command) => await Mediator.Send(command);

        [HttpDelete]
        [Route((nameof(DeleteCity)))]
        public async Task<int> DeleteCity([FromQuery] DeleteCityCommand command) => await Mediator.Send(command);

    }
}
