using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        //Constructor (Need to set up connection string in the appsettings.json file)
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
