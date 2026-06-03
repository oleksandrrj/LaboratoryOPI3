using Xunit;
using RestaurantApp;
using System;

namespace RestaurantApp.Tests
{
    public class MyTests
    {
        private readonly Restaurant _res;

        // Конструктор виконується перед кожним тестом, усуваючи дублювання
        public MyTests()
        {
            _res = new Restaurant(1, "Mon Plaisir", "Kharkiv");
        }

        [Fact]
        public void Test1_AddDish_Positive()
        {
            _res.AddDish("Борщ");
            Assert.Contains("Борщ", _res.GetTopDishes(10));
        }

        [Fact]
        public void Test2_AddDish_EmptyName_Negative()
        {
            Assert.Throws<ArgumentException>(() => _res.AddDish(""));
        }

        [Fact]
        public void Test3_AddDish_Null_Negative()
        {
            Assert.Throws<ArgumentException>(() => _res.AddDish(null!));
        }

        [Fact]
        public void Test4_UpdateRating_Boundary_Max()
        {
            _res.UpdateRating(5.0f);
            Assert.Equal(5.0f, _res.Rating);
        }

        [Fact]
        public void Test5_UpdateRating_Boundary_Min()
        {
            _res.UpdateRating(0.0f);
            Assert.Equal(0.0f, _res.Rating);
        }

        [Fact]
        public void Test6_UpdateRating_BelowMin_Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _res.UpdateRating(-1.0f));
        }

        [Fact]
        public void Test7_UpdateRating_AboveMax_Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _res.UpdateRating(5.1f));
        }

        [Fact]
        public void Test8_GetTopDishes_Positive()
        {
            _res.AddDish("Dish 1");
            _res.AddDish("Dish 2");
            var result = _res.GetTopDishes(2);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Test9_GetTopDishes_RequestMoreThanExist()
        {
            _res.AddDish("Dish 1");
            var result = _res.GetTopDishes(10);
            Assert.Single(result);
        }

        [Fact]
        public void Test10_GetTopDishes_ZeroCount()
        {
            _res.AddDish("Dish 1");
            var result = _res.GetTopDishes(0);
            Assert.Empty(result);
        }
    }
}