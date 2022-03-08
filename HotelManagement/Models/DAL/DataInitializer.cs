using HotelManagement.DATA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models.DAL
{
    public class DataInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<HotelDbContext>();
                db.Database.EnsureCreated();

                var role = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                db.Database.Migrate();
                if (!db.Roles.Any())
                {
                    db.Roles.Add(new IdentityRole { Name = RoleConstants.Moderator, NormalizedName = RoleConstants.Moderator.ToUpper() });
                    db.Roles.Add(new IdentityRole { Name = RoleConstants.SuperAdmin, NormalizedName = RoleConstants.SuperAdmin.ToUpper() });
                    db.Roles.Add(new IdentityRole { Name = RoleConstants.User, NormalizedName = RoleConstants.User.ToUpper() });
                    db.Roles.Add(new IdentityRole { Name = RoleConstants.Hotel, NormalizedName = RoleConstants.Hotel.ToUpper() });

                    

                }

                db.SaveChanges();
            }
        }


    }
}
