using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain;

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                string text = @"
██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗
██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║
███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║
██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║
██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║
╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝
****************************************************************";
                Console.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- Welcome to HANGMAN! Please select Game Mode -");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("****************************************************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Easy (4 - 5 letters)");
                Console.WriteLine("2. Medium (6 - 7 letters)");
                Console.WriteLine("3. Hard (8 - 9 letters)");
                Console.Write("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        GameMode.EasyMode();
                        break;

                    case 2:
                        GameMode.MediumMode();
                        break;

                    case 3:
                        GameMode.HardMode();
                        break;

                    default:
                        Console.WriteLine("...");
                        break;
                }

                Console.Write("\n- Play again? (y/n) -: ");
                playAgain = Console.ReadLine().ToLower() == "y";

            } while (playAgain);
        }
    }

    class GameMode
    {
        public static void EasyMode()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n- EASY MODE -");
            Console.WriteLine("****************************************************************\n");
            Console.ForegroundColor = ConsoleColor.White;

            var easyWords = new[]{"moon", "fire", "dusk", "veil", "grave", "light", "chill", "haunt"};
            var chosenEasyWord = easyWords[new Random().Next(easyWords.Length)];
            var validCharacters = new Regex("^[a-z]$");
            var tries = 6;
            var letters = new List<string>();

            while (tries != 0)
            {
                var charactersLeft = 0;//counter to track how many letters are still unknown

                foreach (var character in chosenEasyWord)
                {
                    var letter = character.ToString();

                    if (letters.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("_");
                        charactersLeft++;
                    }
                }
                Console.WriteLine("");

                //game end!!!
                if (charactersLeft == 0)
                {
                    break;
                }

                Console.Write("\n- Type in a letter: ");
                var key = Console.ReadKey().KeyChar.ToString().ToLower();
                Console.WriteLine("");

                //CHECK TIME TO SEE IF KEY MATCHES 
                if (!validCharacters.IsMatch(key))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"- The letter {key} is invalid. Try again. ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }//validates input, if not a single a–z letter,shows error and skips to next loop

                if (letters.Contains(key))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("- You already entered this letter! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }//checks if u already tried the letter
                
                letters.Add(key);//used a guess.

                if (!chosenEasyWord.Contains(key))
                {
                    tries--;
                    if (tries > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"The letter {key} is not in the word. You have {tries} tries left.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }

            if (tries > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n****************************************************************");
                Console.WriteLine($"- You won with {tries} tries left! -");
                Console.WriteLine("****************************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n****************************************************************");
                Console.WriteLine($"- You lost! The word was: {chosenEasyWord} -");
                Console.WriteLine("****************************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        public static void MediumMode()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n- MEDIUM MODE -");
            Console.WriteLine("****************************************************************\n");
            Console.ForegroundColor = ConsoleColor.White;

            var mediumWords = new[] { "circle", "shadow", "murmur", "silent", "lantern", "eclipse", "shudder", "creeping" };
            var chosenMediumWord = mediumWords[new Random().Next(mediumWords.Length)];
            var validCharacters = new Regex("^[a-z]$");
            var tries = 6;
            var letters = new List<string>();

            while (tries != 0)
            {
                var charactersLeft = 0;

                foreach (var character in chosenMediumWord)
                {
                    var letter = character.ToString();
                    if (letters.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("_");
                        charactersLeft++;
                    }
                }

                Console.WriteLine("");

                if (charactersLeft == 0)
                {
                    break;
                }

                Console.Write("Type in a letter: ");
                var key = Console.ReadKey().KeyChar.ToString().ToLower();

                Console.WriteLine("");

                if (!validCharacters.IsMatch(key))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"The letter {key} is invalid. Try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (letters.Contains(key))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You already entered this letter!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                letters.Add(key);

                if (!chosenMediumWord.Contains(key))
                {
                    tries--;
                    if (tries > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"The letter {key} is not in the word. You have {tries} tries left.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }

            if (tries > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n****************************************************************");
                Console.WriteLine($"- You won with {tries} tries left! -");
                Console.WriteLine("****************************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n****************************************************************");
                Console.WriteLine($"- You lost! The word was: {chosenMediumWord} -");
                Console.WriteLine("****************************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void HardMode()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n- HARD MODE -");
            Console.WriteLine("****************************************************************\n");
            Console.ForegroundColor = ConsoleColor.White;

            var hardWords = new[] { "nightmare", "creature", "skeleton", "obsidian", "afterlife", "forgotten", "backlight", "underworld" };
            var chosenHardWord = hardWords[new Random().Next(hardWords.Length)];
            var validCharacters = new Regex("^[a-z]$");
            var tries = 6;
            var letters = new List<string>();

            while (tries != 0)
            {
                var charactersLeft = 0;

                foreach (var character in chosenHardWord)
                {
                    var letter = character.ToString();
                    if (letters.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("_");
                        charactersLeft++;
                    }
                }

                Console.WriteLine("");

                if (charactersLeft == 0)
                {
                    break;
                }

                Console.Write("Type in a letter: ");
                var key = Console.ReadKey().KeyChar.ToString().ToLower();

                Console.WriteLine("");

                if (!validCharacters.IsMatch(key))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"The letter {key} is invalid. Try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (letters.Contains(key))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You already entered this letter!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                letters.Add(key);

                if (!chosenHardWord.Contains(key))
                {
                    tries--;
                    if (tries > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"The letter {key} is not in the word. You have {tries} tries left.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }

            if (tries > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n****************************************************************");
                Console.WriteLine($"- You won with {tries} tries left! -");
                Console.WriteLine("****************************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n****************************************************************");
                Console.WriteLine($"- You lost! The word was: {chosenHardWord} -");
                Console.WriteLine("****************************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
