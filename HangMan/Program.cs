using System.Collections.Generic;
using static System.Random;
using System.Text;
using System;


internal class program
{
    private static void PrintHangman(int wrong)
    {
        if (wrong == 0)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 1)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("O   |");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 2)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("O   |");
            Console.WriteLine("|   |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 3)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|  |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 4)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|\\ |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 5)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|\\ |");
            Console.WriteLine("/   |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 6)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O   |");
            Console.WriteLine("/|\\  |");
            Console.WriteLine("/ \\  |");
            Console.WriteLine("    ===");
        }
    }

    private static int printWord(List<char>guessedLetters, String randomWords)
    {
        int counter=0;
        int rightLetter=0;
        Console.Write("\r\n");
        foreach (char c in randomWords)
        {
            if (guessedLetters.Contains(c))
            {
                Console.Write(c + " ");
                rightLetter += 1;
            }
            else
            {
                Console.Write("  ");
            }
            //Console.Write("\r\n");
            counter += 1;
        }
        return rightLetter;
    }

    private static void printLine(string randomWords)
    {
        Console.Write("\r");
        foreach (char c in randomWords)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("\u0305 ");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Hangman");
        Console.WriteLine("----------------------------------------------");

        Random random=new Random();
        List<string> wordDictionary = new List<string> {"cat", "calendar", "matrix", "sow", "native", "lazy", "maid", "sniff", "computer", "victory", };
        int index = random.Next(wordDictionary.Count);
        String randomWord = wordDictionary[index];

        foreach (char x in randomWord)
        {
            Console.Write("_ ");
        }

        int lenghtOfWordToGuesse= randomWord.Length;
        int amountOfTimeWrong = 0;
        List<char>currentLetterGussed=new List<char>();
        int currentLetterRight=0;

        while (amountOfTimeWrong != 6 && currentLetterRight != lenghtOfWordToGuesse)
        {
            Console.Write("\n Letters Guessed So Far: ");
            foreach (char  letter in currentLetterGussed)
            {
                Console.Write(letter + " ");
            }

            Console.Write("\nGuesse a Letter: ");
            char letterGuessed = Console.ReadLine()[0];

            if (currentLetterGussed.Contains(letterGuessed))
            {
                Console.Write("\r\n You Have Already Guessed The Letter");
                PrintHangman(amountOfTimeWrong);
                currentLetterRight = printWord(currentLetterGussed, randomWord);
                printLine(randomWord);
            }
            else
            {
                bool right = false;
                for (int i = 0; i < randomWord.Length; i++) if (letterGuessed == randomWord[i]) { right = true; }

                if (right)
                {
                    PrintHangman(amountOfTimeWrong);
                    currentLetterGussed.Add(letterGuessed);
                    currentLetterRight = printWord(currentLetterGussed, randomWord);
                    Console.Write("\r\n");
                    printLine(randomWord);

                }
                else
                {
                    amountOfTimeWrong += 1;
                    currentLetterGussed.Add(letterGuessed);
                    PrintHangman(amountOfTimeWrong);
                    currentLetterRight = printWord(currentLetterGussed, randomWord);
                    Console.Write("\r\n");
                    printLine(randomWord);
                }
            }
        }

        Console.WriteLine("\r\n Game is Over ! Thank you For Playing");
    }
}
