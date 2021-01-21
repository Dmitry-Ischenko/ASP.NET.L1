using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Entities;
using WebStore.Domain.Models;

namespace WebStore.Service
{
    public static class TestDB
    {
        private static readonly Random _rand = new Random();

        #region Фамилии и Имена
        private static readonly string[] __firstName =
                {
                    "Алан","Георгий","Константин","Роман",
                    "Александр","Герман","Лев","Ростислав",
                    "Алексей","Глеб","Леонид","Руслан",
                    "Альберт","Гордей","Макар","Рустам",
                    "Анатолий","Григорий","Максим","Савва",
                    "Андрей","Давид","Марат","Савелий",
                    "Антон","Дамир","Марк","Святослав",
                    "Арсен","Даниил","Марсель","Семен",
                    "Арсений","Демид","Матвей","Сергей",
                    "Артем","Демьян","Мирон","Станислав",
                    "Артемий","Денис","Мирослав","Степан",
                    "Артур","Дмитрий","Михаил","Тамерлан",
                    "Богдан","Евгений","Назар","Тимофей",
                    "Борис","Егор","Никита","Тимур",
                    "Вадим","Елисей","Николай","Тихон",
                    "Валентин","Захар","Олег","Федор",
                    "Валерий","Иван","Павел","Филипп",
                    "Василий","Игнат","Петр","Шамиль",
                    "Виктор","Игорь","Платон","Эдуард",
                    "Виталий","Илья","Прохор","Эльдар",
                    "Владимир","Ильяс","Рамиль","Эмиль",
                    "Владислав","Камиль","Ратмир","Эрик",
                    "Всеволод","Карим","Ринат","Юрий",
                    "Вячеслав","Кирилл","Роберт","Ян",
                    "Геннадий","Клим","Родион","Ярослав"
                };
        private static readonly string[] __lastName = {
                "Смирнов","Орехов","Денисов","Белоусов","Авдеев","Лазарев","Горшков","Кузьмин",
                "Иванов","Ефремов","Громов","Федотов","Зыков","Медведев","Чернов","Кудрявцев",
                "Кузнецов","Исаев","Фомин","Дорофеев","Бирюков","Ершов","Овчинников","Баранов",
                "Соколов","Евдокимов","Давыдов","Егоров","Шарапов","Никитин","Селезнёв","Куликов",
                "Попов","Калашников","Мельников","Матвеев","Никонов","Соболев","Панфилов","Алексеев",
                "Лебедев","Кабанов","Щербаков","Бобров","Щукин","Рябов","Копылов","Степанов",
                "Козлов","Носков","Блинов","Дмитриев","Дьячков","Поляков","Михеев","Яковлев",
                "Новиков","Юдин","Колесников","Калинин","Одинцов","Цветков","Галкин","Сорокин",
                "Морозов","Кулагин","Карпов","Анисимов","Сазонов","Данилов","Назаров","Сергеев",
                "Петров","Лапин","Афанасьев","Петухов","Якушев","Жуков","Лобанов","Романов",
                "Волков","Прохоров","Власов","Антонов","Красильников","Фролов","Лукин","Захаров",
                "Соловьёв","Нестеров","Маслов","Тимофеев","Гордеев","Журавлёв","Беляков","Борисов",
                "Васильев","Харитонов","Исаков","Никифоров","Самойлов","Николаев","Потапов","Королёв",
                "Зайцев","Агафонов","Тихонов","Веселов","Князев","Крылов","Некрасов","Герасимов",
                "Павлов","Муравьёв","Аксёнов","Филиппов","Беспалов","Максимов","Хохлов","Пономарёв",
                "Семёнов","Ларионов","Гаврилов","Марков","Уваров","Сидоров","Жданов","Григорьев",
                "Голубев","Федосеев","Родионов","Большаков","Шашков","Осипов","Ситников",
                "Виноградов","Зимин","Котов","Суханов","Наумов","Сысоев","Симонов",
                "Богданов","Пахомов","Горбунов","Миронов","Шилов","Фомичёв","Мишин",
                "Воробьёв","Шубин","Кудряшов","Ширяев","Воронцов","Русаков","Фадеев",
                "Фёдоров","Игнатов","Быков","Александров","Ермаков","Стрелков","Комиссаров",
                "Михайлов","Филатов","Зуев","Коновалов","Дроздов","Гущин","Мамонтов",
                "Беляев","Крюков","Третьяков","Шестаков","Игнатьев","Тетерин","Носов",
                "Тарасов","Рогов","Савельев","Казаков","Савин","Колобов","Гуляев",
                "Белов","Кулаков","Панов","Ефимов","Логинов","Субботин","Шаров",
                "Комаров","Терентьев","Рыбаков","Бобылёв","Сафонов","Фокин","Устинов",
                "Орлов","Молчанов","Суворов","Доронин","Капустин","Блохин","Вишняков",
                "Киселёв","Владимиров","Абрамов","Белозёров","Кириллов","Селиверстов","Евсеев",
                "Макаров","Артемьев","Воронов","Рожков","Моисеев","Пестов","Лаврентьев",
                "Андреев","Гурьев","Мухин","Самсонов","Елисеев","Кондратьев","Брагин",
                "Ковалёв","Зиновьев","Архипов","Мясников","Кошелев","Силин","Константинов",
                "Ильин","Гришин","Трофимов","Лихачёв","Костин","Меркушев","Корнилов",
                "Гусев","Кононов","Мартынов","Буров","Горбачёв","Лыткин",
                "Титов","Дементьев","Емельянов","Туров"
                };
        #endregion

        public static IEnumerable<Employee> Employees { get; } = Enumerable.Range(1, 10)
            .Select(i => new Employee
            {
                Id = i,
                FirstName = __firstName[_rand.Next(0, __firstName.Length)],
                LastName = __lastName[_rand.Next(0, __lastName.Length)],
                Age = _rand.Next(20, 50)
            }).ToArray();

        public static IEnumerable<BlogPost> Blogs { get; } = new []
        {
            new BlogPost
            {
                DateCreate = DateTime.Now,
                Rating = 10,
                Id = 1,
                ImageBackground = "/images/blog_single_background.jpg",
                PreviewImage = "/images/blog_1.jpg",
                Header = "Вася пупкин ограбил магазин Ситилинка",
                BodyHtml = @"<p>Mauris viverra cursus ante laoreet eleifend. Donec vel fringilla ante. Aenean finibus velit id urna vehicula, nec maximus est sollicitudin. Praesent at tempus lectus, eleifend blandit felis. Fusce augue arcu, consequat a nisl aliquet, consectetur elementum turpis. Donec iaculis lobortis nisl, et viverra risus imperdiet eu. Etiam mollis posuere elit non sagittis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc quis arcu a magna sodales venenatis. Integer non diam sit amet magna luctus mollis ac eu nisi. In accumsan tellus ut dapibus blandit.</p>
<div class=""single_post_quote text - center"">
<div class=""quote_image""><img src=""images / quote.png"" alt=""""></div>
<div class=""quote_text"">Quisque sagittis non ex eget vestibulum. Sed nec ultrices dui. Cras et sagittis erat. Maecenas pulvinar, turpis in dictum tincidunt, dolor nibh lacinia lacus.</div>
<div class=""quote_name"">Liam Neeson</div>
</div>
<p>Praesent ac magna sed massa euismod congue vitae vitae risus. Nulla lorem augue, mollis non est et, eleifend elementum ante. Nunc id pharetra magna.  Praesent vel orci ornare, blandit mi sed, aliquet nisi. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. </p>
"
            },
            new BlogPost
            {
                DateCreate = DateTime.Now,
                Id = 2,
                ImageBackground = "/Blog/images/blog2_background.jpg",
                PreviewImage = "/Blog/images/blog2.jpg",
                Header = "Как выбрать корпус",
                BodyHtml = @"<p>Первоначально все корпуса компьютеров, совместимых с IBM PC, имели один и тот же типоразмер (Desktop) и были похожи друг на друга практически всем, даже цветом.
Хотя совместимые компьютеры производило множество различных компаний, не связанных никакими лицензиями, нарушить заданный IBM негласный стандарт не решался никто. И светло-серые «чемоданы» с монитором сверху надолго прописались на столах офисов и кабинетов.
Первый, отличный от оригинала, типоразмер Tower (позже названный Full Tower) появился в 1996, через 15 лет после выхода на рынок IBM PC. Первоначально такие корпуса предназначались серверам и другим сборкам повышенной мощности: высокая «башня» обеспечивала куда лучшие условия вентиляции, чем плоский настольный корпус.
Новый корпус понравился многим, но высокая цена и излишний для домашних компьютеров внутренний объем помешали его широкому распространению. Однако интерес к новому типоразмеру был замечен производителями. Это привело к появлению стандарта Mid-Tower, быстро вытеснившего Desktop и ставшего основным массовым корпусом еще на несколько лет. И вплоть до середины «нулевых» весь выбор сводился к различным вариациям этих трех типоразмеров.</p>",
            },
            new BlogPost
            {
                DateCreate = DateTime.Now,
                Id = 3,
                ImageBackground = "/Blog/images/blog3.jpg",
                PreviewImage = "/Blog/images/blog3.jpg",
                Header = "Что такое техпроцесс в микрочипах и как он влияет на производство полупроводников",
                BodyHtml = @"<p><strong>Одна из главных характеристик процессоров и других микрочипов — техпроцесс. Что означает этот термин и насколько он влияет на производительность — разберемся в этом блоге.</strong></p>
<h2>Что такое техпроцесс</h2>
<p>Ключевым элементом практически каждой вычислительной схемы является транзистор. Это полупроводниковый элемент, который служит для управления токами. Из транзисторов собираются основные логические элементы, а на их основе создаются различные комбинационные схемы и уже непосредственно процессоры.</p>"
            },
        };

        public static IEnumerable<Category> Сategories { get; } = new []
        {
            new Category
            {
                Id = 1,Name="Смартфоны и гаджеты",Order =0
            },
            new Category
            {
                Id = 2,Name="Смартфоны",Order = 1,ParentId = 1
            },
            new Category
            {
                Id = 3,Name="Планшеты",Order = 2,ParentId = 1
            },
            new Category
            {
                Id = 4,Name="Гаджеты",Order = 3,ParentId = 1
            },
            new Category
            {
                Id = 5,Name="Наушники",Order = 4,ParentId = 1
            },
            new Category
            {
                Id = 6,Name="Ноутбуки и компьютеры",Order = 5
            },
            new Category
            {
                Id = 7,Name="Ноутбуки",Order = 6,ParentId = 6
            },
            new Category
            {
                Id = 8,Name="Моноблоки",Order = 7,ParentId = 6
            },
            new Category
            {
                Id = 9,Name="Комплектующие для ПК",Order = 8,ParentId = 6
            },
            new Category
            {
                Id = 10,Name="Процессоры",Order = 9,ParentId = 9
            },
            new Category
            {
                Id = 11,Name="Материнские платы",Order = 10,ParentId = 9
            },
            new Category
            {
                Id = 12,Name="Видеокарты",Order = 11,ParentId = 9
            },
            new Category
            {
                Id = 13,Name="Блоки питания",Order = 12,ParentId = 9
            },
            new Category
            {
                Id = 14,Name="Телевизоры, аудио-видео",Order = 13
            },
            new Category
            {
                Id = 15,Name="Телевизоры",Order = 14,ParentId = 14
            },
            new Category
            {
                Id = 16,Name="Видеотехника",Order = 15,ParentId = 14
            },
            new Category
            {
                Id = 17,Name="Аудиотехника",Order = 16,ParentId = 14
            },
            new Category
            {
                Id = 18,Name="Фитнес-браслеты",Order = 17,ParentId = 4
            },
        };

        public static IEnumerable<Brand> Brands { get; } = new []
        {
            new Brand
            {
                Id = 1,
                Name = "APPLE"
            },
            new Brand
            {
                Id = 2, Name="SAMSUNG"
            },
            new Brand
            {
                Id = 3, Name="XIAOMI"
            },
            new Brand
            {
                Id = 4, Name="ZTE"
            },
            new Brand
            {
                Id = 5, Name="HONOR"
            },
            new Brand
            {
                Id = 6, Name="AMD"
            },
            new Brand
            {
                Id = 7, Name="INTEL"
            },
            new Brand
            {
                Id = 8, Name="GIGABYTE"
            },
            new Brand
            {
                Id = 9, Name="ASUS"
            },
            new Brand
            {
                Id = 10, Name="CREATIVE"
            },
        };

        public static IEnumerable<Product> Products { get; } = new []
        {
            new Product
            {
                Id=1,
                CategoryId=2,
                BrandId=1,
                Price=54490,
                Name=@"Смартфон APPLE iPhone 11 64Gb, MWLT2RU/A, черный", 
                ImageUrl="product_id1_1.jpg", 
                Description=@"ОС iPhone iOS 13, экран: 6.1"", IPS, 1792×828, процессор: Apple A13 Bionic, , GPS, ГЛОНАСС, с защитой от пыли и влаги, встроенная память: 64ГБ",
            },
            new Product
            {
                Id=2,
                CategoryId=2,
                BrandId=2,
                Price=20490,
                Name=@"Смартфон SAMSUNG Galaxy A51 64Gb, SM-A515F, черный", 
                ImageUrl="product_id2_1.jpg", 
                Description=@"ОС Android 10, экран: 6.5"", Super AMOLED, 2400×1080, процессор: Exynos 9611, 2300МГц, 8-ми ядерный, GPS, ГЛОНАСС, оперативная память: 4ГБ, встроенная память: 64ГБ",
            },
            new Product
            {
                Id=3,
                CategoryId=2,
                BrandId=3,
                Price=22990,
                Name=@"Смартфон XIAOMI Redmi Note 9 Pro 6/128Gb, зеленый", 
                ImageUrl="product_id3_1.jpg", 
                Description=@"ОС Android 10.0, экран: 6.67"", IPS, 2400×1080, процессор: Qualcomm Snapdragon 720G, 2300МГц, 8-ми ядерный, FM-радио, GPS, ГЛОНАСС, время работы в режиме разговора, до: 33ч, оперативная память: 6ГБ, встроенная память: 128ГБ",
            },
            new Product
            {
                Id=4,
                CategoryId=2,
                BrandId=4,
                Price=12490,
                Name=@"Смартфон ZTE Blade 20 Smart 128Gb, темный изумруд", 
                ImageUrl="product_id4_1.jpg", 
                Description=@"ОС Android 9.0, экран: 6.49"", IPS, 1560×720, процессор: MediaTek Helio P60, 2000МГц, 8-ми ядерный, FM-радио, GPS, ГЛОНАСС, время работы в режиме разговора, до: 50ч, в режиме ожидания, до: 833ч, оперативная память: 4ГБ, встроенная память: 128ГБ",
            },
            new Product
            {
                Id=5,
                CategoryId=2,
                BrandId=5,
                Price=10390,
                Name=@"Смартфон HONOR 9A 64Gb, черный", 
                ImageUrl="product_id5_1.jpg", 
                Description=@"ОС Android 10 HMS, экран: 6.3"", IPS, 1600×720, процессор: MediaTek МТ6762R, 2000МГц, 8-ми ядерный, GPS, оперативная память: 3ГБ, встроенная память: 64ГБ",
            },
            new Product
            {
                Id=6,
                CategoryId=3,
                BrandId=1,
                Price=29900,
                Name=@"Планшет APPLE iPad 2020 32Gb Wi-Fi MYL92RU/A, 32GB, iOS темно-серый", 
                ImageUrl="product_id6_1.jpg", 
                Description=@"сенсорный экран 10.2"" (25.9 см), разрешение: 2160 x 1620, Multitouch, Wi-Fi, Bluetooth, основная камера: 8Мп, фронтальная камера: 1.2Мп, fingerprint, встроенная память: 32ГБ, операционная система: iOS",
            },
            new Product
            {
                Id=7,
                CategoryId=3,
                BrandId=2,
                Price=25990,
                Name=@"Планшет SAMSUNG Galaxy Tab S6 Lite SM-P610N, 4GB, 64GB, Android 10.0 серый [sm-p610nzaaser]", 
                ImageUrl="product_id7_1.jpg", 
                Description=@"сенсорный экран 10.4"" (26.4 см), разрешение: 2000 x 1200, Multitouch, Wi-Fi, Bluetooth, основная камера: 8Мп, фронтальная камера: 5Мп, встроенная память: 64ГБ, операционная система: Android 10.0",
            },
            new Product
            {
                Id=8,
                CategoryId=3,
                BrandId=5,
                Price=28990,
                Name=@"Планшет HONOR Pad V6, 6ГБ, 128GB, Android 10.0 черный [53011eta]", 
                ImageUrl="product_id8_1.jpg", 
                Description=@"сенсорный экран 10.4"" (26.4 см), разрешение: 2000 x 1200, Multitouch, Wi-Fi, Bluetooth, GPS, ГЛОНАСС, основная камера: 13Мп, фронтальная камера: 8Мп, встроенная память: 128ГБ, операционная система: Android 10.0",
            },
            new Product
            {
                Id=9,
                CategoryId=18,
                BrandId=3,
                Price=2120,
                Name=@"Фитнес-трекер XIAOMI Band 4 XMSH07HM, 0.95"", черный / черный [mgw4057ru]", 
                ImageUrl="product_id9_1.jpg", 
                Description=@"Mi Band 4 — очень удачный фитнес-браслет, который оказался улучшен практически во всех аспектах в сравнении с предшественниками. Устройство не только получило великолепный AMOLED-дисплей, но и оказалось оборудовано продвинутыми датчиками.",
            },
            new Product
            {
                Id=10,
                CategoryId=5,
                BrandId=1,
                Price=12990,
                Name=@"Гарнитура APPLE AirPods, with Charging Case, Bluetooth, вкладыши, белый [mv7n2ru/a]", 
                ImageUrl="product_id10_1.jpg", 
                Description=@"тип соединения: беспроводные bluetooth; акустический тип: закрытые; тип амбушюр: вкладыши",
            },
            new Product
            {
                Id=11,
                CategoryId=7,
                BrandId=1,
                Price=70990,
                Name=@"Ноутбук APPLE MacBook Air 13.3"", Intel Core i5 5350U 1.8ГГц, 8ГБ, 128ГБ SSD, Intel HD Graphics 6000, Mac OS X El Capitan, MQD32RU/A, серебристый", 
                ImageUrl="product_id11_1.jpg", 
                Description=@"экран: 13.3""; разрешение экрана: 1440×900; процессор: Intel Core i5 5350U; частота: 1.8 ГГц (2.9 ГГц, в режиме Turbo); память: 8192 Мб, LPDDR3, 1600 МГц; SSD: 128 Гб; Intel HD Graphics 6000; WiFi; Bluetooth; WEB-камера; Mac OS X El Capitan",
            },
            new Product
            {
                Id=12,
                CategoryId=7,
                BrandId=5,
                Price=5990,
                Name=@"Ультрабук HONOR MagicBook Pro HLY-W19R, 16.1"", IPS, AMD Ryzen 5 3550H 2.1ГГц, 8ГБ, 512ГБ SSD, AMD Radeon Vega 8, Windows 10, 53010TSA, серый", 
                ImageUrl="product_id12_1.jpg", 
                Description=@"экран: 16.1""; разрешение экрана: 1920×1080; тип матрицы: IPS; процессор: AMD Ryzen 5 3550H; частота: 2.1 ГГц (3.7 ГГц, в режиме Turbo); память: 8192 Мб, DDR4, 2400 МГц; SSD: 512 Гб; AMD Radeon Vega 8; WiFi; Bluetooth; HDMI; WEB-камера; Windows 10",
            },
            new Product
            {
                Id=13,
                CategoryId=8,
                BrandId=1,
                Price=118890,
                Name=@"Моноблок APPLE iMac MRT42RU/A, 21.5"", Intel Core i5 8500, 8ГБ, 1000ГБ, AMD Radeon Pro 560X - 4096 Мб, Mac OS, серебристый и черный", 
                ImageUrl="product_id13_1.jpg", 
                Description=@"экран 21.5"", 4096 х 2304; процессор: Intel Core i5 8500, 3.0 ГГц (4.1 ГГц, в режиме Turbo); оперативная память: DDR4 8192 Мб 2666 МГц; видеокарта: AMD Radeon Pro 560X — 4096 Мб; HDD: 1000 Гб; Web-камера; Wi-Fi; Bluetooth",
            },
            new Product
            {
                Id=14,
                CategoryId=10,
                BrandId=6,
                Price=10790,
                Name=@"Процессор AMD Ryzen 5 2600, SocketAM4, OEM [yd2600bbm6iaf]", 
                ImageUrl="product_id14_1.jpg", 
                Description=@"сокет SocketAM4, ядро Pinnacle Ridge, ядер — 6, потоков — 12, частота 3.4 ГГц и 3.9 ГГц в режиме Turbo, L3 кэш 16МБ, техпроцесс 12нм, поддержка памяти DDR4 каналов памяти — 2, множитель не заблокирован, контроллер PCI Express 3.0, поставка OEM",
            },
            new Product
            {
                Id=15,
                CategoryId=10,
                BrandId=7,
                Price=12390,
                Name=@"Процессор INTEL Core i5 9400F, LGA 1151v2, OEM [cm8068403358819s rf6m]", 
                ImageUrl="product_id15_1.jpg", 
                Description=@"сокет LGA 1151v2, ядро Coffee Lake, ядер — 6, потоков — 6, частота 2.9 ГГц и 4.1 ГГц в режиме Turbo, L3 кэш 9МБ, техпроцесс 14нм, поддержка памяти DDR4 до 128 ГБ, каналов памяти — 2, контроллер PCI Express 3.0, поставка OEM",
            },
            new Product
            {
                Id=16,
                CategoryId=11,
                BrandId=8,
                Price=5290,
                Name=@"Материнская плата GIGABYTE B450M S2H, SocketAM4, AMD B450, mATX, Ret", 
                ImageUrl="product_id16_1.jpg", 
                Description=@"гнездо процессора: SocketAM4; чипсет AMD B450; память DDR4 — 2слота; частотой до 2933МГц; SATA RAID, тип поставки: Ret; mATX",
            },
            new Product
            {
                Id=17,
                CategoryId=11,
                BrandId=9,
                Price=4690,
                Name=@"Материнская плата ASUS PRIME H310M-R R2.0, LGA 1151v2, Intel H310, mATX, Ret (White Box)", 
                ImageUrl="product_id17_1.jpg", 
                Description=@"гнездо процессора: LGA 1151v2; чипсет Intel H310; память DDR4 — 2слота; частотой до 2666МГц; тип поставки: Ret (White Box); mATX",
            },
            new Product
            {
                Id=18,
                CategoryId=12,
                BrandId=8,
                Price=21400,
                Name=@"Видеокарта GIGABYTE nVidia GeForce GTX 1660 , GV-N1660OC-6GD, 6ГБ, GDDR5, OC, Ret", 
                ImageUrl="product_id18_1.jpg", 
                Description=@"nVidia GeForce GTX 1660 ; частота процессора: 1785 МГц (1830 МГц, в режиме Boost); частота памяти: 8002МГц; объём видеопамяти: 6ГБ; тип видеопамяти: GDDR5; OverClock Edition; DirectX 12/OpenGL 4.5; доп. питание: 8 pin; блок питания не менее: 450Вт; тип поставки: Ret",
            },
            new Product
            {
                Id=19,
                CategoryId=13,
                BrandId=8,
                Price=7740,
                Name=@"Блок питания GIGABYTE GP-P750GM, 750Вт, 120мм, черный, retail [28200-p750g-1eur]", 
                ImageUrl="product_id19_1.jpg", 
                Description=@"размер вентилятора 120мм; ATX; мощность: 750Вт; активный PFC; стандарт 80 PLUS GOLD; питание MB и CPU: 24+2x(4+4) pin; питание видеокарты: 4х(6+2) pin; разъемы Molex: 3шт; разъемы SATA: 8шт; отсоединяющиеся кабели; цвет: черный; тип поставки Ret",
            },
            new Product
            {
                Id=20,
                CategoryId=15,
                BrandId=3,
                Price=23990,
                Name=@"Телевизор XIAOMI Mi TV 4S 43, 43"", Ultra HD 4K", 
                ImageUrl="product_id20_1.jpg", 
                Description=@"диагональ: 43""; разрешение: 3840 x 2160; Ultra HD 4K; SMART TV; яркость: 220кд/м2; DVB-T2; DVB-С; разъем Ethernet 1; VESA 300×300; USB: 2: HDMI: 3 : цвет: черный",
            },
            new Product
            {
                Id=21,
                CategoryId=16,
                BrandId=3,
                Price=5700,
                Name=@"Медиаплеер XIAOMI Mi TV Box S", 
                ImageUrl="product_id21_1.jpg", 
                Description=@"поддержка HDTV 4096p; Wi-Fi 802.11ac; USB 2.0: 1",
            },
            new Product
            {
                Id=22,
                CategoryId=17,
                BrandId=10,
                Price=4540,
                Name=@"Колонки CREATIVE T3250W, 2.1, черный [51mf0450aa000]", 
                ImageUrl="product_id22_1.jpg", 
                Description=@"акустический тип: 2.1; выходная мощность (RMS) 9Вт; регуляторы на пульте; питание от сети; тип акустики: стационарная; цвет: черный",
            },
        };
    }
}
