using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace VendingMachine
{
    public class Program
    {
         static void Main(string[] args)
         {
             var person = new Person();
             var bankAccount = new BankAccount();
             var vendingMachine = new VendingMachine();

             while (true)
             {
                 Console.WriteLine("Choose an option from the following options :");
                 Console.WriteLine("1. Check your bank account balance");
                 Console.WriteLine("2. Withdraw money from your bank account");
                 Console.WriteLine("3. The items in your inventory");
                 Console.WriteLine("4. Buy something");
                 
                 var option = Console.ReadLine();

                 if (option == "1")
                 {
                     Console.WriteLine($"Your current balance is {person.PersonBalance}kr"); 
                 }

                 if (option == "2")
                 {
                     Console.WriteLine("How much money would you like to withdraw?");
                     var chosenAmount = Console.ReadLine();
                     int.TryParse(chosenAmount, out int amount);
                     person.WithdrawPersonBalance(amount);
                 }
                 
                 if (option == "3")
                 {
                     try
                     {
                         person.ListInventoryItems();
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex.Message);
                     }
                 }
                 
                 if (option == "4")
                 {
                     Console.WriteLine("What would you like to buy?");
                     vendingMachine.ListItems();
                     var choise = Console.ReadLine();
                    
                     var item = vendingMachine.BuyItem(choise, person.PersonBalance);
                        
                     if (item == null) continue;
                     person.AddItemToInventory(item.Name);
                     person.WithdrawPersonBalance(item.Price);
                 }
             }
         }
     
    }
}