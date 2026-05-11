using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp
{
    /// <summary>
    /// Клас, що представляє ресторан та керує його даними.
    /// </summary>
    public class Restaurant
    {
        // Властивості об'єкта (дані ресторану)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Rating { get; private set; } // Рейтинг можна змінювати лише всередині класу
        public List<string> Dishes { get; private set; } // Список страв

        /// <summary>
        /// Конструктор для створення нового об'єкта ресторану.
        /// </summary>
        public Restaurant(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
            Rating = 0; // Початковий рейтинг
            Dishes = new List<string>(); // Ініціалізація списку страв
        }

        /// <summary>
        /// Додає нову страву до списку.
        /// Перевіряє назву на порожнечу (техніка тестування EP).
        /// </summary>
        /// <param name="dish">Назва страви</param>
        public void AddDish(string dish)
        {
            // Валідація: якщо назва порожня або null — викидаємо помилку
            if (string.IsNullOrWhiteSpace(dish))
            {
                throw new ArgumentException("Назва страви не може бути порожньою.", nameof(dish));
            }
            
            Dishes.Add(dish);
            Console.WriteLine($"Страва '{dish}' додана.");
        }

        /// <summary>
        /// Оновлює рейтинг ресторану.
        /// Обмежує значення від 0 до 5 (техніка тестування BVA).
        /// </summary>
        /// <param name="newRating">Нове значення рейтингу</param>
        public void UpdateRating(float newRating)
        {
            // Перевірка межових значень: рейтинг має бути в діапазоні [0; 5]
            if (newRating < 0 || newRating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(newRating), "Рейтинг має бути від 0 до 5.");
            }

            Rating = newRating;
            Console.WriteLine($"Рейтинг оновлено до: {Rating}");
        }

        /// <summary>
        /// Повертає список перших N страв.
        /// </summary>
        /// <param name="count">Кількість страв для отримання</param>
        /// <returns>Список назв страв</returns>
        public List<string> GetTopDishes(int count)
        {
            // Якщо передано від'ємне число, прирівнюємо до 0
            if (count < 0) count = 0;

            // Використання LINQ для отримання певної кількості елементів
            return Dishes.Take(count).ToList();
        }
    }
}