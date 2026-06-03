﻿using System;
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

        // Покращена інкапсуляція: приватне поле і ReadOnly список
        private readonly List<string> _dishes = new List<string>();
        public IReadOnlyList<string> Dishes => _dishes;

        public Restaurant(int id, string name, string address)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Rating = 0;
        }

        public void AddDish(string dish)
        {
            if (string.IsNullOrWhiteSpace(dish))
                throw new ArgumentException("Назва страви не може бути порожньою.", nameof(dish));
            
            _dishes.Add(dish);
        }

        public void UpdateRating(float newRating)
        {
            if (newRating < 0 || newRating > 5)
                throw new ArgumentOutOfRangeException(nameof(newRating), "Рейтинг має бути від 0 до 5.");

            Rating = newRating;
        }

        public List<string> GetTopDishes(int count)
        {
            // Виправлено маскування помилки: тепер викидаємо виняток
            if (count < 0) 
                throw new ArgumentOutOfRangeException(nameof(count), "Кількість не може бути від'ємною.");

            return _dishes.Take(count).ToList();
        }
    }
}