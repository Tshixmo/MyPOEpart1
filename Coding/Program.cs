﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;

namespace MyRecipe
{
    class Program
    {
        static void Main()
        {
            RecipeManager manager = new RecipeManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Enter Recipe Details:" +
                                  "\n2. Display Recipe" +
                                  "\n3. Display all Recipes" +
                                  "\n4. Scale Recipe" +
                                  "\n5. Reset quantities" +
                                  "\n6. Clear all data" +
                                  "\n7. Exit");

                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        manager.EnterRecipe();
                        break;
                    case "2":
                        manager.DisplayRecipe();
                        break;
                    case "3":
                        manager.DisplayAllRecipes();
                        break;
                    case "4":
                        manager.ScaleRecipe();
                        break;
                    case "5":
                        manager.ResetRecipe();
                        break;
                    case "6":
                        manager.ClearAllData();
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("Bye Bye");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }

    class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();

        public void EnterRecipe()
        {
            Recipe recipe = new Recipe();
            recipe.TotalCaloriesExceeded += TotalCaloriesExceededHandler;
            recipe.EnterRecipeDetails();
            recipes.Add(recipe);
        }

        private void TotalCaloriesExceededHandler(object sender, CaloriesExceededEvent e)
        {
            Console.WriteLine("WARNING: Your recipe has more than 300 calories!!");
        }

        public void DisplayRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to display.");
                return;
            }

            Console.WriteLine("Enter the recipe number to display:");
            int recipeNumber = int.Parse(Console.ReadLine());
            if (recipeNumber <= 0 || recipeNumber > recipes.Count)
            {
                Console.WriteLine("Invalid recipe number.");
                return;
            }

            recipes[recipeNumber - 1].DisplayRecipe();
        }

        public void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to display.");
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

            Console.WriteLine("All the recipes in alphabetical order: ");
            for(int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"Recipe {i + 1}:");
                sortedRecipes[i].DisplayRecipe();
                Console.WriteLine();
            }
        }

        public void ScaleRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to scale.");
                return;
            }

            Console.WriteLine("Enter the recipe number to scale:");
            int recipeNumber = int.Parse(Console.ReadLine());
            if (recipeNumber <= 0 || recipeNumber > recipes.Count)
            {
                Console.WriteLine("Invalid recipe number.");
                return;
            }

            recipes[recipeNumber - 1].Scale();
        }

        public void ResetRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to reset.");
                return;
            }

            Console.WriteLine("Enter the recipe number to reset:");
            int recipeNumber = int.Parse(Console.ReadLine());
            if (recipeNumber <= 0 || recipeNumber > recipes.Count)
            {
                Console.WriteLine("Invalid recipe number.");
                return;
            }

            recipes[recipeNumber - 1].Reset();
        }

        public void ClearAllData()
        {
            recipes.Clear();
            Console.WriteLine("All recipe data cleared.");
        }
    }

    public class CaloriesExceededEvent : EventArgs
    {
        public double TotalCalories { get; }

        public CaloriesExceededEvent(double totalCalories)
        {
            TotalCalories = totalCalories;
        }
    }

    class Recipe
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public List<double> Quantities { get; set; }
        public List<string> Units { get; set; }
        public List<string> Steps { get; set; }
        public List<double> Calories { get; set; }
        public List<string> FoodGroups { get; set; }
        public List<double> OriginalQuantities { get; set; }
        private List<double> OriginalCalories { get; set; }

        public Recipe()
        {
            Ingredients = new List<string>();
            Quantities = new List<double>();
            Units = new List<string>();
            Steps = new List<string>();
            Calories = new List<double>();
            FoodGroups = new List<string>();
            OriginalQuantities = new List<double>();
            OriginalCalories = new List<double>();
        }

        public delegate void TotalCaloriesExceededHandler(object sender, CaloriesExceededEvent e);
        public event TotalCaloriesExceededHandler TotalCaloriesExceeded;

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the name of the recipe:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the number of ingredients your recipe will have:");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                Ingredients.Add(Console.ReadLine());

                Console.WriteLine($"Enter the quantity for {Ingredients[i]}:");
                Quantities.Add(double.Parse(Console.ReadLine()));

                Console.WriteLine($"Enter the unit of measurement for {Ingredients[i]}:");
                Units.Add(Console.ReadLine());

                Console.WriteLine($"Enter the calories for {Ingredients[i]}:");
                Calories.Add(double.Parse(Console.ReadLine()));

                Console.WriteLine("Select the food group for the ingredient:" +
                                  "\n1. Starch" +
                                  "\n2. Fruit and Vegetable" +
                                  "\n3. Beans" +
                                  "\n4. Protein" +
                                  "\n5. Dairy" +
                                  "\n6. Fats and Oils" +
                                  "\n7. Water" +
                                  "\n8. Other");
                int foodGroupChoice = int.Parse(Console.ReadLine());
                string foodGroup = "";
                switch (foodGroupChoice)
                {
                    case 1:
                        foodGroup = "Starch";
                        break;
                    case 2:
                        foodGroup = "Fruit and Vegetable";
                        break;
                    case 3:
                        foodGroup = "Beans";
                        break;
                    case 4:
                        foodGroup = "Protein";
                        break;
                    case 5:
                        foodGroup = "Dairy";
                        break;
                    case 6:
                        foodGroup = "Fats and Oils";
                        break;
                    case 7:
                        foodGroup = "Water";
                        break;
                    case 8:
                        foodGroup = "Other";
                        break;
                    default:
                        Console.WriteLine("You havent choosen a food group");
                        break;
                }
                FoodGroups.Add(foodGroup);
            }

            Console.WriteLine("Enter the number of steps the recipe has:");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                Steps.Add(Console.ReadLine());
            }

            OriginalQuantities = new List<double>(Quantities);
            OriginalCalories = new List<double>(Calories);

            double totalCalories = CalculateTotalCalories();
            if (totalCalories > 300)
            {
                if (TotalCaloriesExceeded != null)
                {
                    TotalCaloriesExceeded(this, new CaloriesExceededEvent(totalCalories));
                }
                
            }
        }

        public void DisplayRecipe()
        {
            if (Ingredients.Count == 0)
            {
                Console.WriteLine("No recipe details available.");
                return;
            }

            Console.WriteLine("Ingredients:");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Quantities[i]} {Units[i]} of {Ingredients[i]} (Calories: {Calories[i]}, Food Group: {FoodGroups[i]})");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        public void Scale()
        {
            if (Quantities.Count == 0)
            {
                Console.WriteLine("No quantities available to scale.");
                return;
            }

            Console.WriteLine("Enter the scaling factor (e.g., 0.5, 2, 3):");
            double factor = double.Parse(Console.ReadLine());

            for (int i = 0; i < Quantities.Count; i++)
            {
                Quantities[i] = OriginalQuantities[i] * factor;
                Calories[i] =  OriginalCalories[i] * factor;
            }

            Console.WriteLine($"Recipe quantities scaled by a factor of {factor}.");
        }

        public void Reset()
        {
            if (OriginalQuantities.Count == 0)
            {
                Console.WriteLine("No quantities available to scale.");
                return;
            }

            for (int i = 0; i < OriginalQuantities.Count; i++)
            {
                Quantities[i] = OriginalQuantities[i];
                Calories[i] = OriginalCalories[i];
            }
        }

        public void ClearData()
        {
            Ingredients.Clear();
            Quantities.Clear();
            Units.Clear();
            Steps.Clear();
            Calories.Clear();
            FoodGroups.Clear();
            OriginalQuantities.Clear();
            OriginalCalories.Clear();
            Console.WriteLine("Recipe data cleared.");
        }

        private double CalculateTotalCalories()
        {
            double totalCalories = 0;
            for (int i = 0; i < Calories.Count; i++)
            {
                totalCalories += Calories[i];
            }
            return totalCalories;
        }
    }
}
