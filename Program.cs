using System;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення об'єкта модуля
            Restaurant myRest = new Restaurant(1, "Mon Plaisir", "вул. Сумська, 10");

            Console.WriteLine($"--- Робота з модулем ресторану: {myRest.Name} ---");

            // Виклик методу 1
            myRest.AddDish("Паста Карбонара");
            myRest.AddDish("Піца Маргарита");

            // Виклик методу 3 (оновлення рейтингу)
            myRest.UpdateRating(4.8f);

            // Виклик методу 2 (цикл)
            var top = myRest.GetTopDishes(1);
            Console.WriteLine("Перша страва з ТОП-списку: " + top[0]);

            Console.WriteLine("\nПрограма завершена. Натисніть клавішу...");
            Console.ReadKey();
        }
    }
}