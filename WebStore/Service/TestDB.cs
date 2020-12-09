using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Models;
using WebStore.Domain.Entityes;

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

        public static List<Employee> Employees { get; } = Enumerable.Range(1, 100)
            .Select(i => new Employee
            {
                Id = i,
                FirstName = __firstName[_rand.Next(0, __lastName.Length)],
                LastName = __lastName[_rand.Next(0, __lastName.Length)],
                Age = _rand.Next(20, 50)
            }).ToList();

        public static List<BlogPost> Blogs { get; } = new List<BlogPost>()
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

        public static List<Сategory> Сategories { get; } = new List<Сategory>()
        {
            new Сategory
            {
                Id = 1,Name="Смартфоны и гаджеты",Order =0
            },
            new Сategory
            {
                Id = 2,Name="Смартфоны",Order = 1,ParentId = 1
            },
            new Сategory
            {
                Id = 3,Name="Планшеты",Order = 2,ParentId = 1
            },
            new Сategory
            {
                Id = 4,Name="Гаджеты",Order = 3,ParentId = 1
            },
            new Сategory
            {
                Id = 5,Name="Наушники",Order = 4,ParentId = 1
            },
            new Сategory
            {
                Id = 6,Name="Ноутбуки и компьютеры",Order = 5
            },
            new Сategory
            {
                Id = 7,Name="Ноутбуки",Order = 6,ParentId = 6
            },
            new Сategory
            {
                Id = 8,Name="Моноблоки",Order = 7,ParentId = 6
            },
            new Сategory
            {
                Id = 9,Name="Комплектующие для ПК",Order = 8,ParentId = 6
            },
            new Сategory
            {
                Id = 10,Name="Процессоры",Order = 9,ParentId = 9
            },
            new Сategory
            {
                Id = 11,Name="Материнские платы",Order = 10,ParentId = 9
            },
            new Сategory
            {
                Id = 12,Name="Видеокарты",Order = 11,ParentId = 9
            },
            new Сategory
            {
                Id = 13,Name="Блоки питания",Order = 12,ParentId = 9
            },
            new Сategory
            {
                Id = 14,Name="Телевизоры, аудио-видео",Order = 13
            },
            new Сategory
            {
                Id = 15,Name="Телевизоры",Order = 14,ParentId = 14
            },
            new Сategory
            {
                Id = 16,Name="Видеотехника",Order = 15,ParentId = 14
            },
            new Сategory
            {
                Id = 17,Name="Аудиотехника",Order = 16,ParentId = 14
            },
            new Сategory
            {
                Id = 18,Name="Фитнес-браслеты",Order = 17,ParentId = 4
            },
        };

        public static List<Brand> Brands { get; } = new List<Brand>()
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


    }
}
