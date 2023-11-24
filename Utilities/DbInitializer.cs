using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using HospitalRepos;
using Microsoft.EntityFrameworkCore;
using HospitalModels;

namespace Utilities
{
    public class DbInitializer:IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> _userManager, 
            RoleManager<IdentityRole> _roleManager, ApplicationDbContext _context)
        {
            this._userManager = _userManager;
            this._roleManager = _roleManager;   
            this._context = _context;

        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            
            if (!_roleManager.RoleExistsAsync(Roles.Admin).GetAwaiter().GetResult())
            { 
                _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Doctor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Patient)).GetAwaiter().GetResult();
                _userManager.CreateAsync(new AppUser()
                {
                    UserName = "Arthur Vicky",
                    Email = "daveelvis.369@gmail.com"
                }, "dave@369").GetAwaiter().GetResult();

                var admin = _context.Users.FirstOrDefault(p => p.Email == "daveelvis.369@gmail.com");
                if (admin != null)
                {
                    _userManager.AddToRoleAsync(admin, Roles.Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}
