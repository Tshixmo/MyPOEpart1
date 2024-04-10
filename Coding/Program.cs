using System;
using System.Buffers.Text;

namespace MyRecipe
{
    class Program
    {
        static void Main()
        {

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

    }

    public void Scaling()
    {

    }

    public void Reset()
    {

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
