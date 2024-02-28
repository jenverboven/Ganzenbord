// See https://aka.ms/new-console-template for more information
using Ganzenbord.Business;

foreach (var square in Game.Instance.board.squares)
{
    Console.WriteLine(square.GetType());
}