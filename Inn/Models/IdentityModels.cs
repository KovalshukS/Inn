using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Inn.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class Service
    {
        public int Id { get; set; }

        [Display(Name = "Назва послуги")]
        public string Name { get; set; }
        [Display(Name = "Опис послуги")]
        public string Description { get; set; }

        [Display(Name = "Ціна послуги")]
        public int Price { get; set; }
    }

    public class Stage
    {
        public int Id { get; set; }

        [Display(Name = "Стадія")]
        public string Name { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }

        [Display(Name = "Статус")]
        public string Name { get; set; }
    }

    public class Structure
    {
        public int Id { get; set; }

        [Display(Name = "Об'єкт")]
        public string Name { get; set; }

        [Display(Name = "Рік проектування")]
        public int Year { get; set; }

        [Display(Name = "Опис об'єкту")]
        public string Description { get; set; }

        public int? TeamId { get; set; }
        public Status Team { get; set; }
        public int? StageId { get; set; }
        public Stage Stage { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Structure> Structures { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}