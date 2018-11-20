using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BikeForeverApi.Models
{
    public class BikeForeverContext : DbContext
    {
        public BikeForeverContext (DbContextOptions<BikeForeverContext> options)
            : base(options)
        {
        }

        public DbSet<BikeForeverApi.Models.PostItem> PostItem { get; set; }
    }
}
