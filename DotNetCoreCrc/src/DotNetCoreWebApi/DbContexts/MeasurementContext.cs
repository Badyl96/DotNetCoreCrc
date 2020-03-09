using DotNetCoreWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.DbContexts
{
    public class MeasurementContext : DbContext
    {
        public MeasurementContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Measurement> Measurments { get; set; }
    }
}
