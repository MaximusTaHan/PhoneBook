using ConsoleTableExt;
using Microsoft.EntityFrameworkCore;
using PhoneBook;

internal class ContactVisualizer
{
    internal static void ShowContacts<T>(List<T> tableData) where T : class
    {
        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .ExportAndWriteLine();
        Console.WriteLine("\n\n");
    }
}
