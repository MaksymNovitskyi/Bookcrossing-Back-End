﻿using Application.Dto;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services = Application.Services;

namespace BookCrossingBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly Services.Interfaces.ILocation _locationService;

        public LocationController(ILocation locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> GetLocation([FromRoute]int id)
        {
            var location = await _locationService.GetById(id);
            if (location == null)
                return NotFound();
            return Ok(location);
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<List<LocationDto>>> GetAllLocations()
        {
            return Ok(await _locationService.GetAll());
        }

        // PUT: api/Locations
        [HttpPut]
        public async Task<IActionResult> PutLocation([FromBody] LocationDto locationDto)
        {
            await _locationService.Update(locationDto);
            return NoContent();
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<ActionResult<LocationDto>> PostLocation([FromBody] LocationDto locationDto)
        {
            var insertedId = await _locationService.Add(locationDto);
            locationDto.Id = insertedId;
            return CreatedAtAction("GetLocation", new { id = locationDto.Id }, locationDto);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationDto>> DeleteLocation([FromRoute] int id)
        {
            var location = await _locationService.Remove(id);
            if (location == null)
                return NotFound();
            return Ok(location);
        }
    }
}