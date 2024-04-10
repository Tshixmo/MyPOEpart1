using System;

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
