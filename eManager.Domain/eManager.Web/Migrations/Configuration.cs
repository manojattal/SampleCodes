namespace eManager.Web.Migrations
{
    using eManager.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            // Populate database with some information.
            context.Departments.AddOrUpdate(d => d.Name,
                new Department() { Name = "Engineering" },
                new Department() { Name = "Sales" },
                new Department() { Name = "Shipping" },                
                new Department() { Name = "HR" }
                );

            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }
            if (Membership.GetUser("mattal") == null)
            {
                Membership.CreateUser("mattal", "abc123");
                Roles.AddUserToRole("mattal", "Admin"); 
            }
        }
    }
}
