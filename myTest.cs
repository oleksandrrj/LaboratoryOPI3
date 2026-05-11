using Xunit;
using RestaurantApp;
using System;

namespace RestaurantApp.Tests
{
    public class MyTests
    {
        // 1. Позитивний тест, техніка EP (Еквівалентне розділення)
        // Перевіряємо, що звичайна назва страви додається без проблем
        [Fact]
        public void AddDish_ValidName_ShouldAddSuccessfully()
        {
            // Arrange (Налаштування - Патерн AAA)
            var restaurant = new Restaurant(1, "Mon Plaisir", "Харків");
            string dishName = "Паста Карбонара";

            // Act (Дія - Патерн AAA)
            restaurant.AddDish(dishName);
            var result = restaurant.GetTopDishes(1);

            // Assert (Перевірка - Патерн AAA)
            Assert.Contains(dishName, result);
        }

        // 2. Тест на граничні значення, техніка BVA (Аналіз граничних значень)
        // Перевіряємо максимально допустимий рейтинг (5.0)
        [Fact]
        public void UpdateRating_BoundaryValueFive_ShouldSetCorrectly()
        {
            // Arrange
            var restaurant = new Restaurant(1, "Mon Plaisir", "Харків");
            float maxRating = 5.0f;

            // Act
            restaurant.UpdateRating(maxRating);

            // Assert
            Assert.Equal(maxRating, restaurant.Rating);
        }

        // 3. Негативний тест, техніка EP (Еквівалентне розділення)
        // Перевіряємо реакцію системи на некоректні дані (порожній рядок)
        [Fact]
        public void AddDish_EmptyName_ShouldThrowException()
        {
            // Arrange
            var restaurant = new Restaurant(1, "Mon Plaisir", "Харків");
            string emptyDish = "";

            // Act & Assert
            // Перевіряємо, що метод викидає виключення (ArgumentException)
            Assert.Throws<ArgumentException>(() => restaurant.AddDish(emptyDish));
        }
    }
}