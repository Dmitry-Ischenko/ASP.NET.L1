using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Webstore.DAL.Context;
using WebStore.Service;

namespace WebStore.Data
{
    public class WebStoreDbInitializer
    {
        private readonly WebStoreDB _db;
        private readonly ILogger<WebStoreDbInitializer> _Logger;

        public WebStoreDbInitializer(WebStoreDB db, ILogger<WebStoreDbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
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
            } else
                _Logger.LogInformation("Структура БД в актуальном состояние");

            try
            {
                InitializePdroducts();
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
            using(_db.Database.BeginTransaction())
            {
                _db.Categories.AddRange(TestDB.Сategories);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                _db.Database.CommitTransaction();
            }
            _Logger.LogInformation("Добавление брендов ...");
            using(_db.Database.BeginTransaction())
            {
                _db.Brands.AddRange(TestDB.Brands);
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Добавление товаров ...");
            using (_db.Database.BeginTransaction())
            {
                _db.Products.AddRange(TestDB.Products);
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                _db.Database.CommitTransaction();
            }
            _Logger.LogInformation("Добавление исходных данных выполнено успешно за {0} мс", timer.ElapsedMilliseconds);
        }
    }
}
