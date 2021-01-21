using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Webstore.DAL.Context;
using WebStore.Domain.Entities.Identity;
using Webstore.Services.Products;

namespace Webstore.Services.Data
{
    public class WebStoreDbInitializer
    {
        private readonly WebStoreDB _db;
        private readonly ILogger<WebStoreDbInitializer> _Logger;
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<Role> _RoleManager;

        public WebStoreDbInitializer(WebStoreDB db, ILogger<WebStoreDbInitializer> Logger, UserManager<User> UserManager,
            RoleManager<Role> RoleManager)
        {
            _db = db;
            _Logger = Logger;
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }


        public void Initialize()
        {
            _Logger.LogInformation("Инициализация БД...");
            var db = _db.Database;

            if (db.GetPendingMigrations().Any())
            {
                _Logger.LogInformation("Есть не примененные миграции...");
                db.Migrate();
                _Logger.LogInformation("Миграции выполнены успешно");
            }
            else
                _Logger.LogInformation("Структура БД в актуальном состояние");

            try
            {
                InitializePdroducts();
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "Ошибка при инициализации БД данными каталога товаров");

                throw;
            }
            try
            {
                InitializeIdentityAsync().Wait();
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "Ошибка при инициализации БД системы Identity");
                throw;
            }
        }

        private void InitializePdroducts()
        {
            var timer = Stopwatch.StartNew();
            if (_db.Products.Any())
            {
                _Logger.LogInformation("Добавление исходных данные в бд не требуется");
                return;
            }

            _Logger.LogInformation("Добавление категорий... {0} мс", timer.ElapsedMilliseconds);
            using (_db.Database.BeginTransaction())
            {
                _db.Categories.AddRange(TestDB.Сategories);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Categories] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Categories] OFF");

                _db.Database.CommitTransaction();
            }
            _Logger.LogInformation("Добавление брендов ...");
            using (_db.Database.BeginTransaction())
            {
                _db.Brands.AddRange(TestDB.Brands);
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF");

                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Добавление товаров ...");
            using (_db.Database.BeginTransaction())
            {
                _db.Products.AddRange(TestDB.Products);
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");

                _db.Database.CommitTransaction();
            }
            _Logger.LogInformation("Добавление исходных данных выполнено успешно за {0} мс", timer.ElapsedMilliseconds);
        }

        private async Task InitializeIdentityAsync()
        {
            async Task CheckRole(string RoleName)
            {
                if (!await _RoleManager.RoleExistsAsync(RoleName))
                    await _RoleManager.CreateAsync(new Role { Name = RoleName });
            }

            await CheckRole(Role.Administrator);
            await CheckRole(Role.User);

            if (await _UserManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User
                {
                    UserName = User.Administrator
                };
                var creation_result = await _UserManager.CreateAsync(admin, User.DefaultAdminPassword);
                if (creation_result.Succeeded)
                    await _UserManager.AddToRoleAsync(admin, Role.Administrator);
                else
                {
                    var errors = creation_result.Errors.Select(e => e.Description);
                    throw new InvalidOperationException($"Ошибка при создании учётно записи администратора {string.Join(",", errors)}");
                }
            }
        }
    }
}
