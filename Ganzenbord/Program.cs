// See https://aka.ms/new-console-template for more information

using Ganzenbord;
using Ganzenbord.Business;
using Ganzenbord.Business.Dice;

ILogger logger = new ConsoleLogger();
IDice dice = new Dice(2);

Console.WriteLine("Enter the amount of players: ");
int amountPlayers = Int32.Parse(Console.ReadLine());
Console.WriteLine();

Game game = new(logger, dice, amountPlayers);
game.Start();