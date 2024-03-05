// See https://aka.ms/new-console-template for more information

using Ganzenbord;
using Ganzenbord.Business.Board;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Game;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Squares;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddTransient<ILogger, ConsoleLogger>()
    .AddTransient<ISquareFactory, SquareFactory>()
    .AddTransient<IDice, Dice>()
    .AddSingleton<IBoard, Board>()
    .AddSingleton<IGame, Game>()
    .BuildServiceProvider();

IGame game = serviceProvider.GetRequiredService<IGame>();
game.Start();