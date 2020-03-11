using DotNetCoreWebApi.DbContexts;
using DotNetCoreWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.Repository
{
    public class MeasurementRepository : IMeasurementRepository<Measurement>
    {
        private readonly MeasurementContext _measurementContext;

        public MeasurementRepository(MeasurementContext _measurementContext)
        {
            this._measurementContext = _measurementContext;
        }
        public async Task<IEnumerable<Measurement>> GetAll()
        {
            return await _measurementContext.Measurments.ToListAsync();
        }
        public async Task<Measurement> Get(long id)
        {
            return await _measurementContext.Measurments.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task Add(Measurement entity)
        {
            await _measurementContext.Measurments.AddAsync(entity);
            await _measurementContext.SaveChangesAsync();
        }
        public async Task Update(Measurement measurement, Measurement entity)
        {
            measurement.Name = entity.Name;
            measurement.Value = entity.Value;
            measurement.CreatedAt = entity.CreatedAt;
            measurement.CreatedBy = entity.CreatedBy;
            await _measurementContext.SaveChangesAsync();
        }
        public async Task Delete(Measurement measurement)
        {
            _measurementContext.Measurments.Remove(measurement);
        }
    }
}
