using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApi.Model;
using DotNetCoreWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApi.Controllers
{
    [Route("api/measurement")]
    [ApiController]
    public class MeasurementController : Controller
    {
        public IMeasurementRepository<Measurement> _measurementRepository { get; }

        public MeasurementController(IMeasurementRepository<Measurement> measurementRepository)
        {
            this._measurementRepository = measurementRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var measurements = await _measurementRepository.GetAll();
            return Ok(measurements);
        }
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var measurements = await _measurementRepository.Get(id);
            return Ok(measurements);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Measurement measurement)
        {
            await _measurementRepository.Add(measurement);
            return CreatedAtAction(nameof(Get), new { id = measurement.Id }, measurement);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Measurement measurement)
        {
            var measurementsToUpdate = await _measurementRepository.Get(id);
            await _measurementRepository.Update(measurementsToUpdate, measurement);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var measurementToDelete = await _measurementRepository.Get(id);
            await _measurementRepository.Delete(measurementToDelete);
            return NoContent();
        }
    }
}
