using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Kyle Fasanella
//Section 1
//External Tool - deciding what file to make
namespace ExternalToolText
{
    class Menu
    {
        public string Decide()
        {
            //attributes
            string input;

            //Have user decide what to make
            Start:
            Console.WriteLine("\nWhat kind of object would you like to create? (type word)");
            Console.WriteLine("character\nstructure\ndoor\nitem\n");
            input = Console.ReadLine();
            switch (input)
            {
                //if character, ask if enemy or player
                case "character":
                One:
                    Console.WriteLine("\nType the word:\nEnemy1\nEnemy2\nEnemy3\n");
                    input = Console.ReadLine();
                    if (input == "Enemy1" || input == "Enemy2" || input == "Enemy3")
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("\nTry again");
                        goto One;
                    }
                //if structure
                case "structure":
                    return input;
                case "door":
                    return input;
                //if item
                case "item":
                Two:
                    Console.WriteLine("\nType the word:\nPotion\nSpeedBoost\nDamageBuff\nWeapon\n");
                    input = Console.ReadLine();
                    if (input == "Potion" || input == "SpeedBoost" || input == "DamageBuff" || input == "Weapon")
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("\nTry again");
                        goto Two;
                    }    
                //default: go back to start
                default: Console.WriteLine("\nTry again");
                    goto Start;
            }
        }       
    }
}
