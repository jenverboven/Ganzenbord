// See https://aka.ms/new-console-template for more information

using Ganzenbord;
using Ganzenbord.Business;

ILogger logger = new ConsoleLogger();
int amountPlayers = Int32.Parse(Console.ReadLine());
Game game = new(logger, amountPlayers);