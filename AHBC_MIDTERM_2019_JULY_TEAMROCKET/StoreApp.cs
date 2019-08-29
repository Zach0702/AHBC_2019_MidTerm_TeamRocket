using System;
using System.Collections.Generic;
using System.IO;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    class StoreApp
    {
        //var menu = new Menu() { };
        bool isNotMenuChoice;
        IntegerValidator intergerValidator = new IntegerValidator { };
        bool isValid;
        bool isShoppingAgain;
        int startMenuChoice = 0;
        int shoppingMenuChoice = 0;
        string initalUserInput = "";
        string nextChoiceAfterTransaction = "";
        public ShoppingCart usersCart = new ShoppingCart();
        StoreInventory inventoryPull = new StoreInventory();




        public void RunStore()
        {

           

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to '@void', your number one stop for the latest in digiatl fashion! \nSelecet below from the following options:\n");
                Console.WriteLine("[1] Shop \n[2] About \n[3] Exit");

                initalUserInput = Console.ReadLine();
                do
                {
                    if (IntegerValidator.Validate(initalUserInput))
                    {
                        startMenuChoice = int.Parse(initalUserInput);
                        isValid = true;
                    }
                    else
                    {
                        Console.Clear();
                        menuOptions();
                        initalUserInput = Console.ReadLine();

                        isValid = false;
                    }


                } while (!isValid);


                switch (startMenuChoice)
                {
                    case 1:

                        do
                        {
                            Console.Clear();
                            ShoppingMenu.RunShoppingMenu(inventoryPull, usersCart);
                           
                            double userSubTotal = usersCart.calculateSubtotal(usersCart.ItemstoPurchase);
                            Payment userPayment = new Payment(userSubTotal, usersCart);
                            userPayment.CalculatedSalesTaxTotal();
                            double grandTotal = userPayment.CalculatedGrandTotal();
                            userPayment.MethodOfPayment();
                            //Receipt userReceipt = new Receipt(grandTotal, userSubTotal, usersCart.ItemstoPurchase);
                            //userReceipt.PrintReceipt();

                            inventoryPull.GenerateStoreInventory(usersCart);
                            StoreInventory.UpdateInventoryDatabase(inventoryPull);
                            usersCart = new ShoppingCart();
                            Console.WriteLine("\nWould Like make another transacton or head to the main menu?\n");
                            Console.WriteLine("[1] New Transaction \n[2] Main Menu\n");

                            nextChoiceAfterTransaction = Console.ReadLine();
                            do
                            {
                                if (IntegerValidator.Validate(nextChoiceAfterTransaction))
                                {
                                    shoppingMenuChoice = int.Parse(nextChoiceAfterTransaction);
                                    isValid = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    menuOptions();
                                    nextChoiceAfterTransaction = Console.ReadLine();

                                    isValid = false;
                                }
                            } while (!isValid);

                            if (shoppingMenuChoice == 1)
                            {
                                isShoppingAgain = true;
                            }
                            else
                            {
                                isShoppingAgain = false;
                            }


                        } while (isShoppingAgain);
                        isNotMenuChoice = true;
                        break;

                    case 2:
                        /// WRITE OUR STORE BIO!!!!
                        Console.Clear();
                        Console.WriteLine("\n");

                        menuOptions();
                        initalUserInput = Console.ReadLine();
                        isNotMenuChoice = true;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Thank you and B#!");
                        isNotMenuChoice = false;
                        break;

                    default:
                        Console.Clear();
                        Console.Write("Not a valid option. ");
                        menuOptions();
                        initalUserInput = Console.ReadLine();
                        isNotMenuChoice = true;
                        break;
                }

            } while (isNotMenuChoice);


           StoreInventory.ResetInventoryDatabase(inventoryPull); 
            //    ^^^^^^^^^^^^^^^^^^
            //I added this in case we need to reset the inventory when we close the program. 
            //Idk if we want this, but it's here just in case.

        }

        public static void menuOptions()
        {

            Console.WriteLine("Please, selecet below from the following options:\n");
            Console.WriteLine("[1] Shop \n[2] About \n[3] Exit");

        }




    }
}