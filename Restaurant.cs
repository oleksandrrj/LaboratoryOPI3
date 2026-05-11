using System;
using System.Collections.Generic;

namespace RestaurantApp
{
    // Це твій програмний модуль
    public class Restaurant
    {
        // Поля з діаграми класів
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string Location { get; set; }
        
        // Список для зберігання страв
        private List<string> dishes = new List<string>();

        public Restaurant(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
            Rating = 0.0f;
        }

        // МЕТОД 1: Додавання страви (Умовні конструкції + Винятки)
        public void AddDish(string dishName)
        {
            if (string.IsNullOrWhiteSpace(dishName))
            {
                // Обробка виняткової ситуації
                throw new ArgumentException("Назва страви не може бути порожньою.");
            }

            if (dishes.Contains(dishName))
            {
                Console.WriteLine($"Страва '{dishName}' вже є в меню.");
            }
            else
            {
                dishes.Add(dishName);
                Console.WriteLine($"Страву '{dishName}' успішно додано.");
            }
        }

        // МЕТОД 2: Пошук ТОП-страв (Цикл)
        // Реалізація методу getTopDishes() з твоєї схеми
        public List<string> GetTopDishes(int count)
        {
            List<string> topList = new List<string>();
            
            // Використання циклу для перебору елементів
            for (int i = 0; i < dishes.Count; i++)
            {
                if (topList.Count < count)
                {
                    topList.Add(dishes[i]);
                }
                else 
                {
                    break; // Зупинка циклу при досягненні ліміту
                }
            }
            return topList;
        }

        // МЕТОД 3: Оновлення рейтингу (Аналіз граничних значень)
        public void UpdateRating(float newRating)
        {
            // Логіка перевірки діапазону (від 0 до 5)
            if (newRating < 0 || newRating > 5)
            {
                Console.WriteLine("Помилка: Рейтинг має бути в межах від 0 до 5.");
            }
            else
            {
                Rating = newRating;
                Console.WriteLine($"Новий рейтинг для {Name}: {Rating}");
            }
        }
    }
}