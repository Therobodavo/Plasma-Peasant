using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalToolText
{
    class Write
    {
        public void Writing(string type, StreamWriter strm, bool makeFile, string input, int result)
        {
            Menu menu = new Menu();
            while(makeFile == true)
            {
                
                //get user input, write to file
                strm.Write(type + ",");

                /*unique name for object
                Console.Write("\nA name to identify this object/character: ");
                input = Console.ReadLine();
                strm.Write(input + ",");*/

                //write level
                /*Console.Write("\nName of level to put it in: ");
                input = Console.ReadLine();
                strm.Write(input + ",");*/

                //if type is a character
                if (type == "Enemy1" || type == "Enemy2" || type == "Enemy3")
                {
                    XAndY(input, result, strm);
                    strm.Write(",");
                    Width(input, result, strm);
                    strm.Write(",");
                    Height(input, result, strm);
                    strm.Write(",");
                    Health(input, result, strm);
                    strm.Write(",");
                    Speed(input, result, strm);
                    goto MakeMore;
                }

                //weapons
                //ranged
                /*else if(type == "ranged")
                {
                    XAndY(input, result, strm);
                    strm.Write(",");
                    Damage(input, result, strm);
                    strm.Write(",");
                    ProjectileSpeed(input, result, strm);
                    goto MakeMore;                 
                }

                //melee
                else if (type == "melee")
                {
                    XAndY(input, result, strm);
                    strm.Write(",");
                    Damage(input, result, strm);
                    goto MakeMore;
                }*/
                //structure
                else if (type == "structure")
                {
                    XAndY(input, result, strm);
                    strm.Write(",");
                    Width(input, result, strm);
                    strm.Write(",");
                    Height(input, result, strm);
                    goto MakeMore;
                }

                //door
                else if (type == "door")
                {
                    XAndY(input, result, strm);
                    strm.Write(",");
                    Width(input, result, strm);
                    strm.Write(",");
                    Height(input, result, strm);
                    strm.Write(",");
                    NextRoom(input, result, strm);
                    strm.Write(",");
                    Console.WriteLine("\nX and Y value of where to spawn into next room:");
                    XAndY(input, result, strm);
                    goto MakeMore;
                }

                //player wants to make item - potion, boost, or buff
                else if (type == "Potion" || type == "SpeedBoost" || type == "DamageBuff")
                {
                    Value(input, result, strm);
                    strm.Write(",");
                    XAndY(input, result, strm);                                      
                    goto MakeMore;
                }

                //items - weapons
                else if(type == "Weapon")
                {
                    Damage(input, result, strm);
                    strm.Write(",");
                    Rate(input, result, strm);
                    strm.Write(",");
                    ProjSpeed(input, result, strm);
                    goto MakeMore;
                }

            /*check to see if they want to keep adding the same type of object to the file, line by line
            MakeMore:
                Console.Write("\nWould you like to add another " + type + " ('yes' or 'no'): ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "yes": //loop
                        strm.WriteLine();
                        goto Start;

                    case "no":
                        goto MakeType;

                    default:
                        Console.WriteLine("\nTry again.");
                        goto MakeMore;
                }*/

            //check to see if they want to add a different type to the file
            MakeMore:
                Console.Write("\nWould you like to add another object to the file? ('yes' or 'no'): ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "yes": //loop
                        type = menu.Decide();
                        strm.WriteLine();
                        break;

                    case "no": //set done to true, leave loop
                        Door:
                        //ask if they want to add a door, if they didn't - just a reminder really
                        Console.WriteLine("\nIf you didn't add a door, would you like to so that you can go to another level once the enemies are dead? \n('yes' or 'no'): ");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "yes": //add door object
                                strm.WriteLine();
                                strm.Write("door,");
                                XAndY(input, result, strm);
                                strm.Write(",");
                                Width(input, result, strm);
                                strm.Write(",");
                                Height(input, result, strm);
                                strm.Write(",");
                                NextRoom(input, result, strm);
                                strm.Write(",");
                                Console.WriteLine("\nX and Y value of where to spawn into next room:");
                                XAndY(input, result, strm);
                                break;
                            case "no":
                                break;

                            default:
                                Console.WriteLine("\nTry again.\n");
                                goto Door;
                        }
                        Console.WriteLine();
                        makeFile = false;
                        return;

                    default:
                        Console.WriteLine("\nTry again.\n");
                        goto MakeMore;
                }
            } //end inner loop
            Console.WriteLine("Something was wrong");          
        }


        //Methods
        //methods for getting values from input - names are self explanatory -----------------------------
        private void XAndY(string input, int result, StreamWriter strm)
        {   
            //get x and y values
            X:
            Console.Write("\nX Location (0 - 1024): ");
            input = Console.ReadLine();
            if (int.TryParse(input, out result)) //check it is a number
            {
                //check value
                if (result >= 0 && result <= 1024)
                {
                    strm.Write(input + ",");
                }
                else
                {
                    Console.WriteLine("\n0 to 1024 please");
                    goto X;
                }
                
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto X;
            }

            Y:
            Console.Write("\nY Location (0 - 600): ");
            input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                //check value
                if (result >= 0 && result <= 600)
                {
                    strm.Write(input);
                }
                else
                {
                    Console.WriteLine("\n0 to 600 please");
                    goto Y;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Y;
            }
        }

        /*private void Level(string input, StreamWriter strm)
        {
            Console.Write("\nName of level to put it in: ");
            input = Console.ReadLine();
            strm.Write(input);
        }*/
        //speed of character
        private void Speed(string input, int result, StreamWriter strm)
        {
            Speed:
            Console.Write("\nSpeed (0 - 4): ");
            input = Console.ReadLine();

            //make sure its an integer
            if (int.TryParse(input, out result))
            {
                if (result >= 0 && result <= 4)
                {
                    strm.Write(input);
                }
                else
                {
                    Console.WriteLine("\n0 to 4 please");
                    goto Speed;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Speed;
            }
        }

        //projectile speed
        private void ProjSpeed(string input, int result, StreamWriter strm)
        {
        ProjSpeed:
            Console.Write("\nProjectile speed (1 - 50): ");
            input = Console.ReadLine();

            //make sure its an integer
            if (int.TryParse(input, out result))
            {
                if (result >= 1 && result <= 50)
                {
                    strm.Write(input);
                }
                else
                {
                    Console.WriteLine("\n1 to 50 please");
                    goto ProjSpeed;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto ProjSpeed;
            }
        }

        //damage of weapon
        private void Damage(string input, int result, StreamWriter strm)
        {
            Damage:
            Console.Write("\nDamage (0 - 100): ");
            input = Console.ReadLine();

            //make sure its an integer
            if (int.TryParse(input, out result))
            {
                if (result >= 0 && result <= 100)
                {
                    strm.Write(input);
                }
                else
                {
                    Console.WriteLine("\n0 to 100 please");
                    goto Damage;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Damage;
            }
        }

        //width of texture
        private void Width(string input, int result, StreamWriter strm)
        {
            Width:
            Console.Write("\nWidth: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                strm.Write(input);
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Width;
            }
        }

        //height
        private void Height(string input, int result, StreamWriter strm)
        {
            Height:
            Console.Write("\nHeight: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                strm.Write(input);
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Height;
            }
        }

        //health for enemies
        private void Health(string input, int result, StreamWriter strm)
        {
            Health:
            Console.Write("\nHealth (0 - 50): ");
            input = Console.ReadLine();

            //make sure its an integer
            if (int.TryParse(input, out result))
            {
                //check value
                if (result >= 0 && result <= 50)
                {
                    strm.Write(input);
                }
                else
                {
                    Console.WriteLine("\n0 to 50 please");
                    goto Health;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Health;
            }
        }

        //rate of fire
        private void Rate(string input, int result, StreamWriter strm)
        {
        Rate:
            Console.Write("\nRate of fire (0 - 100): ");
            input = Console.ReadLine();

            //make sure its an integer
            if (int.TryParse(input, out result))
            {
                if (result >= 4 && result <= 50)
                {
                    strm.Write(input);
                }
                else
                {
                    Console.WriteLine("\n4 to 50 please");
                    goto Rate;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Rate;
            }
        }

        //can indicate what value with console.write before calling method. Can be used in general for other values.
        private void Value(string input, int result, StreamWriter strm)
        {
            Value:
            Console.Write("\nValue (0 - 100): ");
            input = Console.ReadLine();

            //make sure its an integer
            if (int.TryParse(input, out result))
            {
                if (result >= 0 && result <= 100)
                {
                    strm.Write(input);
                }
                else
                {
                    Console.WriteLine("\n0 to 100 please");
                    goto Value;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Value;
            }
        }

        //for getting next room for doors
        private void NextRoom(string input, int result, StreamWriter strm)
        {
        Value:
            Console.Write("\nNext room number, Where the door will take you (1 - 12): ");
            input = Console.ReadLine();

            //make sure its an integer
            if (int.TryParse(input, out result))
            {
                if (result >= 1 && result <= 12)
                {
                    strm.Write(input);
                }
                else
                {
                    Console.WriteLine("\n1 to 12 please");
                    goto Value;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a number.");
                goto Value;
            }
        }
    }
}
