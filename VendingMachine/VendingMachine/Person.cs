using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class Person
    {
        
     //  public int PersonBalance { get; private set; }
       public int PersonBalance = 1000;
       private readonly List<string> inventory;

       public Person()
       {
           inventory = new List<string>();
       }
      // public void AddPersonBalance(int amount)
      // {
         //  PersonBalance += amount;
      // }
       public void WithdrawPersonBalance(int amount)
       {
           PersonBalance -= amount;
       }
       public void AddItemToInventory(string item)
       {
           if (item == null)
           {
               return;
           }
            
           inventory.Add(item);
       }
       public void ListInventoryItems()
       {
           if (inventory.Count == 0)
           {
               Console.WriteLine("The inventory is empty");
               return;
           }

           var itemNumber = 0;
           Console.WriteLine("The items in the inventory:");
           foreach (var item in inventory)
           {
               itemNumber++;
               Console.WriteLine($"{itemNumber}. {item}");
           }
       }
    }
}