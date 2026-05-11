using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Rating { get; private set; }
        public List<string> Dishes { get; private set; }

        public Restaurant(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
            Rating = 0;
            Dishes = new List<string>();
        }

        public void AddDish(string dish)
        {
            if (string.IsNullOrWhiteSpace(dish))
            {
                throw new ArgumentException("Назва страви не може бути порожньою.", nameof(dish));
            }
            Dishes.Add(dish);
            Console.WriteLine($"Страва '{dish}' додана.");
        }

        public void UpdateRating(float newRating)
        {
            if (newRating < 0 || newRating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(newRating), "Рейтинг має бути від 0 до 5.");
            }
            Rating = newRating;
            Console.WriteLine($"Рейтинг оновлено до: {Rating}");
        }

        public List<string> GetTopDishes(int count)
        {
            if (count < 0) count = 0;
            return Dishes.Take(count).ToList();
        }
    }
}