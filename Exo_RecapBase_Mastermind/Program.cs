
using Exo_RecapBase_Mastermind.Models;
using System.Text.RegularExpressions;

Mastermind game = new Mastermind();
game.Initialize();
Console.WriteLine($"DEBUG {string.Join(" > ", game.MysteryValue!)}");

Console.WriteLine("Jeu du Mastermind...");
Console.WriteLine("********************");
Console.WriteLine();

while (game.State == MastermindState.Running)
{
    Console.WriteLine($"Veuillez encoder une proposition " +
        $"(Format : {game.NbElement} nombre séparé d'un espace) : ");
    string input;
    do
    {
        Console.Write("> ");
        input = Console.ReadLine()! ;
    }
    while (!Regex.IsMatch(input, "^[0-9] [0-9] [0-9] [0-9]$"));
    
    List<int> userTry = new List<int>();
    foreach (string val in input.Split(" "))
    {
        userTry.Add(int.Parse(val));
    }

    MastermindResult result = game.Play(userTry);
    Console.WriteLine($"Valeur bien placé : {result.WellPlaced}");
    Console.WriteLine($"Valeur mal placé : {result.WrongPlaced}");
}

if(game.State == MastermindState.Win)
{
    Console.WriteLine("Bravo !");
    Console.WriteLine($"Tu as gagné en {game.CurrentTry} essais !");
}
else
{
    Console.WriteLine("Perdu !");
    Console.WriteLine($"La combinaison etait {string.Join(" > ", game.MysteryValue!)}");
}