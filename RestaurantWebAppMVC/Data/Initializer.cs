using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantWebAppMVC.Models;

namespace RestaurantWebAppMVC.Data
{
    public static class Initializer
    {
        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static readonly string[] dishName =
        {
            "pizza", "ham", "meat", "banana", "tomato", "peach", "melon", "sandwich", "pepper", "cucumber", "milk",
            " orange", "juice", "cocktail", "melon", "raspberry", "blueberry", "strawberry", "apple", "pineapple"
        };


        private static string[] names =
        {
            "Екатерина", "Виолетта", "Наталья", "Анна", "Алина", "Евгения", "Александра", "Любовь", "Татьяна",
            "Вероника", "Ольга", "Светлана", "Елена", "Надежда", "Юлия"
        };

        private static string[] surnames =
        {
            "Кириленко", "Панфилова", "Дубровская", "Долгова", "Яркина", "Черкасова", "Рябцева", "Жилина", "Фокина",
            "Мосина", "Агапова", "Якубовская", "Николина", "Котова", "Прохорова"
        };
        private static string[] positions =
        {
            "Заведующий", "Заместитель директора", "администратор вип зала",
            "Заведующий по административной части", "Сторож", "администратор", "администратор станд зала",
            "Инструктор по физической культуре", "Заведующий по хозяйственной части", "Педагог-психолог", "Повар",
            "Помощник администратора", "Кухонный работник", "Обслуживающий персонал", "Дворник", "официант"
        };

        private static string[] addresses =
        {
            "бульвар Юбилейный", "проспект Машерова", "улица Ленина", "улица Королева", "бульвар Днепровский",
            "улица Рокоссовского", "улица Горовца", "улица Ванеева", "улица Долгобродская", "улица Козлова",
            "улица Голодеда", "проспект Мира", "проспект Независимисти", "улица Народного Ополчения", "улица Миронова",
            "улица Веры Хоружей", "улица Нёманская", "улица Мояковского", "Партизанский проспект", "улица Ангарская"
        };
        private static string[] phoneCodes = { "33", "29", "44", "17", "25" };
        private static Random random;
        private static string GetRandomElement(string[] arr)
        {
            return arr[random.Next(0, arr.Length)];
        }
        private static DateTime NextDateTime()
        {
            DateTime start = new DateTime(2015, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }

        private static string GetString(int minStringLength, int maxStringLength)
        {
            string result = "";

            int stringLimit = minStringLength + random.Next(maxStringLength - minStringLength);

            int stringPosition;
            for (int i = 0; i < stringLimit; i++)
            {
                stringPosition = random.Next(letters.Length);

                result += letters[stringPosition];
            }

            return result;
        }
        public static void Initialize(RestaurantContext db)
        {
            db.Database.EnsureCreated();

            int rowIndex;
            int manyRows = 2000;
            int singleRows = 500;

            if (!db.Dishes.Any())
            {
                rowIndex = 0;
                while (rowIndex < 100)
                {
                    Dish dish = new Dish
                    {
                        Name = GetString(8, 13),
                        CookingTime = random.Next(15, 25),
                        Price = random.Next(150, 777)
                    };
                    db.Dishes.Add(dish);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Employees.Any())
            {
                rowIndex = 0;
                while (rowIndex < 100)
                {
                    Employee emp = new Employee
                    {
                        Name = GetRandomElement(names),
                        Lastname = GetRandomElement(surnames),
                        Position = GetRandomElement(positions),
                        Address = GetRandomElement(addresses)
                    };

                    db.Employees.Add(emp);

                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Orders.Any())
            {
                rowIndex = 0;
                while (rowIndex < 1000)
                {
                    int minEmpId = db.Employees.Min(x => x.Id);
                    int maxEmpId = db.Employees.Max(x => x.Id);


                    Order order = new Order
                    {
                        EmployeeId = random.Next(minEmpId, maxEmpId+1),
                        ClientName = GetRandomElement(names),
                        ClientLastname = GetRandomElement(surnames),
                        ClientPhone = GetRandomElement(phoneCodes) + Convert.ToString(random.Next(1000000, 9999999)),
                        IsCompleted = random.Next(0, 2) == 1 ? true : false,
                        PaymentMethod = GetString(12, 16)
                    };

                    db.Orders.Add(order);

                    rowIndex++;
                }

                db.SaveChanges();
            }

        }
    }
}
