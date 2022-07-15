using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityAndAccess.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        private readonly string DemoAdminUserId = "bf3f3f96-eb42-11ec-8fea-0242ac120002";
        private readonly string DemoCommonUserId = "c4521861-05a3-4489-9eb1-dac03a60f1bb";
        private readonly string DemoManagerId = "f5e4f537-9d10-4338-a063-a9ebe8a8b446";

        private readonly string AdminRoleId = "c72244d8-eb42-11ec-8fea-0242ac120002";
        private readonly string UserRoleId = "96217ec2-f2da-4fc9-9df5-42c2d4a7796f";
        private readonly string ManagerRoleId = "fa1a7297-8b66-4e97-9a8d-073329a96f8a";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedUserRoles(modelBuilder);
            this.SeedClaims(modelBuilder);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var admin = new IdentityUser()
            {
                Id = DemoAdminUserId,
                UserName = "admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                SecurityStamp = "a48e7992-eb46-11ec-8ea0-0242ac120002",
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = true
            };

            admin.PasswordHash = hasher.HashPassword(admin, "Test@123");

            modelBuilder.Entity<IdentityUser>().HasData(admin);


            var user = new IdentityUser()
            {
                Id = DemoCommonUserId,
                UserName = "user@test.com",
                NormalizedUserName = "USER@TEST.COM",
                Email = "user@test.com",
                NormalizedEmail = "USER@TEST.COM",
                SecurityStamp = "270409d9-bb0c-4bdf-8f47-a302dc395a0c",
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = true
            };

            user.PasswordHash = hasher.HashPassword(user, "Test@123");

            modelBuilder.Entity<IdentityUser>().HasData(user);

            var manager = new IdentityUser()
            {
                Id = DemoManagerId,
                UserName = "manager@test.com",
                NormalizedUserName = "MANAGER@TEST.COM",
                Email = "manager@test.com",
                NormalizedEmail = "MANAGER@TEST.COM",
                SecurityStamp = "22545daa-46e8-4033-8ae9-379871bd59e8",
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                LockoutEnabled = true
            };

            manager.PasswordHash = hasher.HashPassword(manager, "Test@123");

            modelBuilder.Entity<IdentityUser>().HasData(manager);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Id = AdminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = UserRoleId, Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = ManagerRoleId, Name = "Manager", NormalizedName = "MANAGER" }
             };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = AdminRoleId,
                   UserId = DemoAdminUserId
               }
           );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = UserRoleId,
                    UserId = DemoCommonUserId
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ManagerRoleId,
                    UserId = DemoManagerId
                }
            );
        }

        private void SeedClaims(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
             new IdentityUserClaim<string>
             {
                 Id = 1,
                 ClaimType = "Permission",
                 ClaimValue = "CanRead, CanCreate, CanUpdate, CanDelete",
                 UserId = DemoAdminUserId
             }
            );

            // example of another approach;
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
             new IdentityUserClaim<string>
             {
                 Id = 4,
                 ClaimType = "CanDelete",
                 ClaimValue = "CanDelete",
                 UserId = DemoAdminUserId
             }
            );

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
              new IdentityUserClaim<string>
              {
                  Id = 2,
                  ClaimType = "Permission",
                  ClaimValue = "CanRead, CanCreate, CanUpdate",
                  UserId = DemoManagerId
              }
            );

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 3,
                    ClaimType = "Permission",
                    ClaimValue = "CanRead",
                    UserId = DemoCommonUserId
                }
            );
        }
    }
}