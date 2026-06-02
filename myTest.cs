using Xunit;
using RestaurantApp;
using System;

namespace RestaurantApp.Tests
{
    public class MyTests
    {
        // --- ГРУПА 1: Додавання страв (AddDish) ---    

        [Fact]
        public void Test1_AddDish_Positive_EP() // Позитивний сценарій
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            res.AddDish("Борщ");
            Assert.Contains("Борщ", res.GetTopDishes(10));
        }

        [Fact]
        public void Test2_AddDish_EmptyName_Negative_EP() // Негативний: порожній рядок
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            Assert.Throws<ArgumentException>(() => res.AddDish(""));
        }

        [Fact]
        public void Test3_AddDish_Null_Negative_EP() // Негативний: null
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            Assert.Throws<ArgumentException>(() => res.AddDish(null!));
        }

        // --- ГРУПА 2: Рейтинг (UpdateRating) ---

        [Fact]
        public void Test4_UpdateRating_Boundary_Max_BVA() // Межа: 5.0
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            res.UpdateRating(5.0f);
            Assert.Equal(5.0f, res.Rating);
        }

        [Fact]
        public void Test5_UpdateRating_Boundary_Min_BVA() // Межа: 0.0
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            res.UpdateRating(0.0f);
            Assert.Equal(0.0f, res.Rating);
        }

        [Fact]
        public void Test6_UpdateRating_BelowMin_Negative_EP() // Негативний: менше 0
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            Assert.Throws<ArgumentOutOfRangeException>(() => res.UpdateRating(-1.0f));
        }

        [Fact]
        public void Test7_UpdateRating_AboveMax_Negative_EP() // Негативний: більше 5
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            Assert.Throws<ArgumentOutOfRangeException>(() => res.UpdateRating(5.1f));
        }

        // --- ГРУПА 3: Отримання списку (GetTopDishes) ---

        [Fact]
        public void Test8_GetTopDishes_Positive_EP() // Позитивний: повертає правильну кількість
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            res.AddDish("Dish 1");
            res.AddDish("Dish 2");
            var result = res.GetTopDishes(2);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Test9_GetTopDishes_RequestMoreThanExist_BVA() // Граничне: просимо більше, ніж є
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            res.AddDish("Dish 1");
            var result = res.GetTopDishes(10); // Просимо 10, а є 1
            Assert.Single(result);
        }

        [Fact]
        public void Test10_GetTopDishes_ZeroCount_BVA() // Граничне: просимо 0 страв
        {
            var res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
            res.AddDish("Dish 1");
            var result = res.GetTopDishes(0);
            Assert.Empty(result);
        }
    }
}
