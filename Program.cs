using CashDB.Application;
using CashDB.Cli;


Console.Title = "Cash DB";

Console.WriteLine("======================================");
Console.WriteLine("              Cash DB                 ");
Console.WriteLine("======================================");
Console.WriteLine();
Console.WriteLine("Press any key to continue...");
Console.ReadKey(true);

var space = new UserSpace();

Menu.ShowMenu(space);

