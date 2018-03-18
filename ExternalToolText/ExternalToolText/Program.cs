using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Kyle Fasanella
//Section 1
//External Tool - text files
namespace ExternalToolText
{
    class Program
    {
        static void Main(string[] args)
        {
            //value for checking if need to leave outer loop/finish program
            bool done = false;
            //attributes
            string filename;
            string input = "";
            string type;
            int result = 0;
            StreamWriter strm;
            bool makeFile;
            Menu menu = new Menu();
            Write writ = new Write();
            Designate des = new Designate();

            //welcome user, ask which they woulkd like to do - create files or designate ones for use
            Console.WriteLine("Welcome!\n");

            First:
            Console.Write("Would you like to create/append a file, or designate a file for use in a certain level? \n(type 'create' or 'use', or 'no' to exit): ");
            input = Console.ReadLine();
            //decide what to do
            switch (input)
            {
                case "create": //continue past switch statement
                    break;

                case "use": //allow the user to designate a file or files for use in the game by changing their name to level1,level2, etc
                    des.Copy();
                    goto First;

                case "no":
                    Console.WriteLine("\nClosing.\n");
                    done = true;
                    break;

                default:
                    Console.WriteLine("\nTry again.\n");
                    goto First;
                    
            }
            if(input != "no")
            {
                Console.WriteLine("You can append an existing file or create a new file.\nYou do not overwrite existing attributes - only add more to the file.");
            }            

            //outer loop
            while (done == false)
            {
                makeFile = true;

                //explain values/input
                Console.WriteLine("\n***************************************************************************************");
                Console.WriteLine("\nLevel: what level the player/ enemy will be in (type 'lvl' only for now)\nX / Y: coordinates for rectangle\nWidth / Height: also for rectangle");
                Console.WriteLine("Projectile Speed: speed that pojectile will go at\nDamage: damage done; for item: damage added to player damage when picked up\nHealth: health to add to player\nValue: value to apply to item\n");
                Console.WriteLine("To add multiple types to one file:\nAppend an existing file by typing its name when asked to type a name.\nOr answer yes when asked if you want to add another object to the file\n");
                Console.WriteLine("***************************************************************************************\n");
                
                //get filename to create
                Console.Write("Type name of file (do not include '.txt'): ");
                filename = Console.ReadLine() + ".txt";

                //if file doesnt exist, make new one
                if (File.Exists(filename) != true)
                {
                    strm = new StreamWriter(new FileStream(filename, FileMode.Create));
                }
                else //append one that exists
                {
                    strm = new StreamWriter(new FileStream(filename, FileMode.Append));
                    strm.WriteLine("");
                }

                type = menu.Decide();
                
                writ.Writing(type, strm, makeFile, input, result);

                //see if the user wants to copy a file for use in the game
                CopyDecision:
                Console.Write("Would you like to copy a files contents, such as the one you just made, for use in the game? ('yes' or 'no'): ");
                input = Console.ReadLine();
                //decide what to do
                switch (input)
                {
                    case "yes":
                        des.Copy();
                        goto CopyDecision;

                    case "no":                       
                        break;

                    default:
                        Console.WriteLine("\nTry again.\n");
                        goto CopyDecision;
                }

                //exiting program/going back and doing another file
            Exit:
                //ask if that is all
                Console.Write("\nWould you like to make another file ('yes' or 'no'; 'no' exits the program): ");
                input = Console.ReadLine();
                //decide what to do
                switch (input)
                {
                    case "yes": //loop
                        break;

                    case "no": //set done to true, leave loop
                        Console.WriteLine("\nClosing stream.\n");
                        done = true;
                        break;

                    default:
                        Console.WriteLine("\nTry again.\n");
                        goto Exit;
                }

                //close stream
                strm.Close();

            } // end outer loop
        } // end main
    } // end class
}
