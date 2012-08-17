using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveCanada_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemCollection testItems = GenerateTestItems();

            foreach (Item item in testItems.SortByDependencies())
            {
                PrintItem(item);
            }

            Console.WriteLine("\nPress Enter key to exit...");
            Console.ReadLine();
        }

        public static ItemCollection GenerateTestItems()
        {
            ItemCollection itemCollection = new ItemCollection();

            //unnamed item with no dependencies
            Item item3 = new Item();
            itemCollection.AddItem(item3);

            //unnamed item with dependencies
            Item item4 = new Item();
            item4.AddDependencies(new List<string>() { "item1", "item2" });
            itemCollection.AddItem(item4);

            //named item with no dependencies
            Item item1 = new Item("item1");
            itemCollection.AddItem(item1);

            //named item with dependencies
            Item item2 = new Item("item2");
            item2.AddDependencies(new List<string>() { "item2_1", "item2_2" });
            itemCollection.AddItem(item2);            

            return itemCollection;
        }

        public static void PrintItem(Item item)
        {
            Console.Write((item.Name == string.Empty ? "unNamed" : item.Name));            
            Console.Write(item.Dependencies.Count() > 0? " with dependencies on " + string.Join(", ", item.Dependencies) : " with no dependencies");
            Console.WriteLine();
        }
    }
}
