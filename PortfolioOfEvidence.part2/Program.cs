using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

// Class to represent an ingredient
public class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public int Calories { get; set; } //Property for part 2(new)
    public string FoodGroup { get; set; } //(Property for part 2(new)
}

// Class to represent a step in a recipe
public class RecipeStep
{
    public string Description { get; set; }
}

// Class to represent a recipe
public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<RecipeStep> Steps { get; set; }

    public Recipe(string name)
    {
        Name = name;
        Ingredients = new List<Ingredient>();
        Steps = new List<RecipeStep>();
    }

    // Method to calculate total calories of the recipe
    public int CalculateTotalCalories()
    {
        int totalCalories = 0;
        foreach (var ingredient in Ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }
}

// Class to manage recipes
public class RecipeManager
{
    public List<Recipe> Recipes { get; set; }
    public delegate void NotifyUserDelegate(string message);

    public RecipeManager()
    {
        Recipes = new List<Recipe>();
    }

    // Method to add a new recipe
    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
    }
    public Recipe SearchRecipe(string name)
    {
        var recipe = Recipes.Find(r => r.Name == name);
        return recipe;

        
    }
   

// Method to display all recipes
public void DisplayAllRecipes()
    {
        Recipes.Sort((x, y) => string.Compare(x.Name, y.Name));
        foreach (var recipe in Recipes)
        {
            Console.WriteLine(recipe.Name);
        }
    }

    // Method to display a specific recipe
    public void DisplayRecipe(string name)
    {
        var recipe = Recipes.Find(r => r.Name == name);
        if (recipe != null)
        {
            Console.WriteLine($"Recipe: {recipe.Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i].Description}");
            }
            Console.WriteLine($"Total Calories: {recipe.CalculateTotalCalories()}");
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }
    // Method to notify user if total calories exceed 300
    public void NotifyIfExceeds(Recipe recipe, NotifyUserDelegate notifyUser)
    {
        if (recipe.CalculateTotalCalories() > 300)
        {
            notifyUser($"Warning: {recipe.Name} exceeds 300 calories.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RecipeManager recipeManager = new RecipeManager();

        // Add recipes and ingredients
        Recipe pancakes = new Recipe("Pancakes");
        pancakes.Ingredients.Add(new Ingredient { Name = "Flour", Quantity = 1, Unit = "cup", Calories = 455, FoodGroup = "Grains" });
        pancakes.Ingredients.Add(new Ingredient { Name = "Milk", Quantity = 1, Unit = "cup", Calories = 103, FoodGroup = "Protein" });
        pancakes.Ingredients.Add(new Ingredient { Name = "Butter", Quantity = 1, Unit = "teaspoon", Calories = 70, FoodGroup = "Dairy" });

        pancakes.Steps.Add(new RecipeStep { Description = "Mix flour, milk, and egg in a bowl" });
        pancakes.Steps.Add(new RecipeStep { Description = "Heat a lightly oiled griddle or frying pan over medium-high heat. Pour or scoop batteronto the griddle, using approximately 1/4 cup for each pancake;" });
       // Add other ingredients and steps...
       recipeManager.AddRecipe(pancakes);

        // Display all recipes
        recipeManager.DisplayAllRecipes();

        // Display a specific recipe 
        recipeManager.DisplayRecipe("Pancakes");

       
        Recipe cake = new Recipe("Cake");
        cake.Ingredients.Add(new Ingredient{Name = "Sugar", Quantity = 1.5, Unit = "cups", Calories = 774, FoodGroup = "Sweets"});
        cake.Ingredients.Add(new Ingredient { Name = "Milk", Quantity = 2, Unit = "cups", Calories = 206, FoodGroup = "Protein" });

        cake.Steps.Add(new RecipeStep { Description = "Preheat the oven to 350 degrees F (175 degrees C), grease and flour a 9 inch square cake pan" });
        cake.Steps.Add(new RecipeStep { Description = "Cream sugar and butter together in a mixing bowl. Add eggs, one at a time, beating briefly after each. Mix in vanilla" });
        cake.Steps.Add(new RecipeStep { Description = "Combine Flour and baking powder in a separate bowl. Add to the wet ingredients ad mix well. Add milk and stir until smooth" });
        cake.Steps.Add(new RecipeStep { Description = "Pour batter into the prepared cake pan, bake in the preheated oven until the top springs back when lightly touched, 30 to 40 minutes" });
        
        
        recipeManager.AddRecipe(cake);

        //Searching for a recipe
        Recipe foundRecipe = recipeManager.SearchRecipe("Cake");
        if (foundRecipe != null)
        {
            recipeManager.DisplayRecipe(foundRecipe.Name);
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }

    } 
}