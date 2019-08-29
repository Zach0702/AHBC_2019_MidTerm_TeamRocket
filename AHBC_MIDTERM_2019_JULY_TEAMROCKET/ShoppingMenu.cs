﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AHBC_MIDTERM_2019_JULY_TEAMROCKET
{
    class ShoppingMenu
    {
        private static string initialUserInput = "";
        private static bool isValid, isNotMenuChoice;
        private static int startMenuChoice;
        public static List<string> categories = new List<string> { };
        public static void RunShoppingMenu(StoreInventory currentInventory, ShoppingCart userCart)
        {

            char loopBreaker;
            do
            {
               
                categories.Clear();

                foreach (var item in currentInventory)
                {
                    if (!categories.Contains(item.ItemCategory))
                    {
                        categories.Add(item.ItemCategory);
                    }

                }
                menuOptions();
                initialUserInput = Console.ReadLine();
                if (initialUserInput == "x")
                {
                    StoreApp returnToMenu = new StoreApp();
                    returnToMenu.RunStore();
                }
                Console.WriteLine();

                do
                {
                    do
                    {
                        if (IntegerValidator.Validate(initialUserInput))
                        {
                            startMenuChoice = int.Parse(initialUserInput);
                            isValid = true;
                        }
                        else
                        {
                            Console.Clear();
                            menuOptions();
                            initialUserInput = Console.ReadLine();
                            isValid = false;
                        }

                    } while (!isValid);


                    if (startMenuChoice > 0 && startMenuChoice <= categories.Count)
                    {

                        CategorySelectionApp selections = new CategorySelectionApp(startMenuChoice, categories);
                        selections.categorySelector(currentInventory, userCart);
                        isNotMenuChoice = false;


                    }
                    //else if (startMenuChoice == 5)
                    //{
                    //    StoreApp returnToMainMenu = new StoreApp();
                    //    returnToMainMenu.RunStore();
                    //}
                    else
                    {

                        Console.Clear();
                        Console.Write("Not a valid option. ");
                        menuOptions();
                        initialUserInput = Console.ReadLine();
                        isNotMenuChoice = true;

                    }

                } while (isNotMenuChoice);



                Console.WriteLine("Do you wish to continue adding items to your cart (enter y/n): "); //ask user to if they want to continue
                loopBreaker = IsValidLoopBreaker(Console.ReadLine()); //storing answer and if it's valid input 


            } while (loopBreaker == 'y');

        }


        private static void menuOptions()
        {
            Console.WriteLine("Please select from the following categories:\n");
            int i = 1;
            foreach (var item in categories)
            {
                Console.WriteLine($"[{i}] {item}\r");
                i++;
            }
            Console.WriteLine("Enter x to return to main menu");
            //Console.WriteLine("[1] Clothiging\n[2] Accessories\n[3] Shoes\n[4] Outerwear\n");

        }
        private static char IsValidLoopBreaker(string testChar)
        {
            bool isInvalidChar = true;

            Regex pattern = new Regex(@"^[y|n]$");

            char validChar = ' ';

            while (isInvalidChar)
            {
                if (pattern.IsMatch(testChar))
                {
                    isInvalidChar = false;
                    validChar = char.Parse(testChar);
                }
                else
                {
                    Console.WriteLine($"ERROR invalid input of {testChar}  entered please try again");
                    Console.WriteLine("Do you wish to continue(enter y/n): ");
                    testChar = Console.ReadLine();
                }
            }
            return validChar;
        }

    }
}
