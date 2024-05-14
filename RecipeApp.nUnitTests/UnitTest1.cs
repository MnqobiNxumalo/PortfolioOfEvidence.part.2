using NUnit.Framework;

namespace RecipeApp.nUnitTests
{

    [TestFixture]
    public class RecipeManagerTests
    {
        [Test]
        public void TestCalculateTotalCalories()
        {
            // Arrange
            RecipeManager recipeManager = new RecipeManager();
            Recipe pancakes = new Recipe("Pancakes");
            pancakes.Ingredients.Add(new Ingredient { Name = "Flour", Quantity = 1, Unit = "cup", Calories = 455, FoodGroup = "Grains" });
            pancakes.Ingredients.Add(new Ingredient { Name = "Milk", Quantity = 1, Unit = "cup", Calories = 103, FoodGroup = "Protein" });
            pancakes.Ingredients.Add(new Ingredient { Name = "Butter", Quantity = 1, Unit = "teaspoon", Calories = 70, FoodGroup = "Dairy" });

            // Add other ingredients...
            recipeManager.AddRecipe(pancakes);

            // Act
            int totalCalories = pancakes.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(455, totalCalories);
        }
    }
}