using Spectre.Console;

namespace classes
{
    internal class ConsoleMenu
    {
        public static void Run()
        {
            var rule = new Rule("[red]Inventory[/]");
            AnsiConsole.Write(rule);

            Inventory inventory = new Inventory();

            do
            {

                var options = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select [green]option[/]")
                        .PageSize(10)
                        .AddChoices(new[]
                        {
                            "1: Add Product",
                            "2: Show inventory",
                            "3: Delete product",
                            "4: Clean inventory",
                            "0: Exit"
                        }));

                switch (options.First())
                {
                    case '1':
                    {

                        inventory.AddProduct(
                            AnsiConsole.Ask<string>("Input [green]label[/]:"),
                            AnsiConsole.Ask<double>("Input [green]price[/]:"),
                            AnsiConsole.Ask<int>("Input [green]quantity[/]:"));
                        break;
                    }
                    case '2':
                    {
                        var table = new Table();
                        table.Border(TableBorder.MinimalHeavyHead);
                        table.AddColumn("Id");
                        table.AddColumn("Label");
                        table.AddColumn("Quantity");
                        table.AddColumn("Price");
                        table.AddColumn("Total");

                        double sum = 0;
                        foreach (var item in inventory.GetProducts())
                        {
                            table.AddRow($"{item.Id}", $"{item.Label}", $"{item.Quantity}", $"{item.Price}$", $"{item.Price * item.Quantity}$");
                            sum += item.Price * item.Quantity;
                        }

                        table.AddEmptyRow();
                        table.AddRow("Total sum", "", "", "", $"[red]{sum}[/]$");

                        AnsiConsole.Write(table);
                        break;
                    }
                    case '3':
                    {
                        var mes = inventory.DeleteProduct(AnsiConsole.Ask<int>("Input [green]id of product[/]:"));
                        if (mes) { AnsiConsole.MarkupLine("[green]Sucсess[/] "); }
                        else { AnsiConsole.MarkupLine("[red]Error![/] "); }
                        break;
                    }
                    case '4':
                    {
                        if (AnsiConsole.Confirm("You rly want to clear your inventory?"))
                        {
                            inventory.CleanInventory();
                        }
                        break;
                    }
                    case '0':
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            } while (true);

        }
    }
}
