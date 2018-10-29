using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemoWebDotNet.Models
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options)
            : base(options)
        {
        }

        public DbSet<StudentViewModel> Students { get; set; }
    }
}
