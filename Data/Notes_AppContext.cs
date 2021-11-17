using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes_App.Strucs;

namespace Notes_App.Data
{
    public class Notes_AppContext : DbContext
    {
        public Notes_AppContext (DbContextOptions<Notes_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Notes_App.Strucs.Note> Note { get; set; }
    }
}
