using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Threading.Channels;

namespace VendingMachine
{
    public class VendingMachine
    {
        private readonly List<Item> vendingMachineItems = new List<Item>
        {
            new Item("M&M", 20),
            new Item("Nuts", 25),
            new Item("Soda", 15),
            new Item("Gum", 10),
        };

        public void ListItems()
        {
            if (vendingMachineItems.Count == 0)
            {
                Console.WriteLine("No items left");
                return;
            }
            var itemNumber = 0;
            foreach (var item in vendingMachineItems)
            {
                itemNumber++;
                Console.WriteLine($"{itemNumber}. {item.Name} - {item.Price}Kr");
            }
        }

        public Item BuyItem(string input, int money)
        {
            int.TryParse(input, out int ui);
            ui -= 1; // To avoid the conflict with the items number.
           
            var item = vendingMachineItems[ui];

            for (var i = 0; i < vendingMachineItems.Count; i++)
            {
                if (item.Name != vendingMachineItems[i].Name || money < item.Price) continue;

                Console.WriteLine($"You purchased {item.Name} for {item.Price}kr");
                return item;
            }
            

            Console.WriteLine("An error occured. Please check your balance or make sure that the item exists.");
            return null;
        }
    }
}