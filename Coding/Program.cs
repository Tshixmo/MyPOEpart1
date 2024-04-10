using System;
using System.Buffers.Text;

namespace MyRecipe
{
    class Program
    {
        static void Main()
        {
            Recipe myrep = new Recipe();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Enter Recipe Details:" +
                    "2. Display Recipe" +
                    "3. Scale Recipe" +
                    "4. Reset quantities" +
                    "5. Clear all data" +
                    "6. Exit");

                Console.WriteLine("Select an option: ");
                string input = Console.ReadLine();
                Console.ReadKey();

                switch (input)
                {
                    case "1":
                        myrep.TheRecipeDetails();
                        break;
                    case "2":
                        myrep.DisplayingTheRecipe();
                        break;
                    case "3":
                        myrep.Scaling();
                        break;
                    case "4":
                        myrep.Reset();
                        break;
                    case "5":
                        myrep.ClearData();
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Bye Bye");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
        }
    }
}

class Recipe
{
    private string[] ingredients;
    private double[] quantity;
    private string[] units;
    private string[] steps;

    public void TheRecipeDetails()
    {
        //Ask the number of ingredients the user wants to enter
        Console.WriteLine("Enter the number of ingredients your recipe will have? ");
        int numIngred = Convert.ToInt32(Console.ReadLine());

        //Creating arrays for the ingredient, quantity and units to be stored in. With the number of ingredients
        //as the 
        ingredients = new string[numIngred];
        quantity = new double[numIngred];
        units = new string[numIngred];

        // This will iterate based on the number of ingredient they are. 
        for (int i = 0; i < numIngred; i++)
        {
            Console.WriteLine("Enter the name of the ingredient: ");
            ingredients[i] = Console.ReadLine();

            Console.WriteLine("Enter the quantity for the " + ingredients[i] + " :");
            quantity[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the unit of measurement for the " + ingredients[i] + " :");
            units[i] = Console.ReadLine();
        }

        Console.WriteLine("Enter the number of steps the recipe has");
        int stepNum = Convert.ToInt32(Console.ReadLine());

        steps = new string[stepNum];

        for (int i = 0; i < stepNum; i++)
        {
            Console.WriteLine("Enter step" + (i + 1) + ":");
            steps[i] = Console.ReadLine();
        }

    }

    public void DisplayingTheRecipe()
    {
        //Displaying the recipe and the ingredient in it. 
        Console.WriteLine("Ingredient: ");
        Console.WriteLine("Recipe: ");

        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine((i + 1) + "." + quantity[i] + units[i] + "of" + ingredients[i]);
        }

        //Displaying the steps in the recipe.
        Console.WriteLine("Steps: ");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine((i + 1) + "." + steps[i]);
        }
    }

    public void Scaling()
    {
        Console.WriteLine("Enter the scaling factor for your recipe: 0.5, 2 or 3");
        double factor = Convert.ToDouble(Console.ReadLine());

        for (int i = 0; i < quantity.Length; i++)
        {
            quantity[i] *= factor;
        }

        Console.WriteLine("Your Recipe has been successfully scaled by " + factor);
    }

    public void Reset()
    {
        Console.WriteLine("Quantity reset to orignal values");
    }

    public void ClearData()
    {
        ingredients = null;
        quantity = null;
        units = null;
        steps = null;
        Console.WriteLine("Data Cleared");
    }

}
