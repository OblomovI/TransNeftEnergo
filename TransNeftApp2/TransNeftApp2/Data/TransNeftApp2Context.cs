using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransNeftEnergo.DTO;

namespace TransNeftApp2.Data
{
    public class TransNeftApp2Context : DbContext
    {
        public TransNeftApp2Context (DbContextOptions<TransNeftApp2Context> options)
            : base(options)
        {
        }

        public DbSet<TransNeftEnergo.DTO.IdNumber> IdNumber { get; set; }
    }
}
