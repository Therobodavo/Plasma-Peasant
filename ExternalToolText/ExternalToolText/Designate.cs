using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Kyle Fasanella
//Section 1
//Class for designating files for use in the game - the game will load the files when creating levels
namespace ExternalToolText
{
    class Designate
    {
        //we are going to have the user select which level they want to use the file for and copy the file contents into an appropriately named file, to be loaded in the game without further user input.
        public void Copy()
        {
        Start:
            //attributes
            string input = "";
            StreamReader strmR;
            List<string> contents = new List<string>();

            Console.Write("\nWhat file that you have created would you like to copy the contents of to be used in the game? \nIf you got here by accident, type 'Go back'\n(Do not include '.txt'): ");
            input = Console.ReadLine();
            if(input == "Go back")
            {
                Console.WriteLine();
                return;
            }
            input = input + ".txt";
            //if file exists, copy contents. If not, ask again.
            if (File.Exists(input) == true)
            {
                strmR = new StreamReader(input);
            }
            else //goto start, try again to get file that actually exists
            {
                Console.WriteLine("\nTry again.");
                goto Start;
            }

            Copy:
            input = strmR.ReadLine();
            //read out lines to list
            if(input != null)
            {
                contents.Add(input);
                goto Copy;
            }

            //ask what level
            Level:
            Console.WriteLine("\nWhat level ('level1', 'level2', 'level3', 'level4', 'level5', 'level6') \n('level7', 'level8', 'level9', 'level10', 'level11', 'level12') \nwould you like to use the file in: ");
            input = Console.ReadLine();
            input = input + ".txt";
            if(input == "level1.txt" || input == "level2.txt" || input == "level3.txt" || input == "level4.txt" || input == "level5.txt" || input == "level6.txt" || input == "level7.txt" || input == "level8.txt" || input == "level9.txt" || input == "level10.txt" || input == "level11.txt" || input == "level12.txt")
            {
                File.WriteAllLines(input, contents);
                //strmW = new StreamWriter(new FileStream(input + ".txt", FileMode.Create)); //create new file with level name, always overwrites if file already exists since it uses Create.
            }
            else
            {
                Console.WriteLine("\nTry again.");
                goto Level;
            }

            /*for(int i = 0; i < contents.Count; i++) //write out into level file each line from the list
            {
                strmW.Write(contents[i]);
            }*/

            Console.WriteLine("\nCopying done\n"); //indicate it is done

        }//end copy method
    } //end class
}
