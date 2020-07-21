using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;


namespace Lab_4.Bonus_Igpay_Atinlay__Pig_Latin_
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = true;
            string again;
           
            string word;

            Console.WriteLine("Welcome to the Pig Latin Translator");

            do
            {
                Console.WriteLine("Enter a word to be translated: ");

                word = Console.ReadLine().ToLower();

                Console.Write("\n");

                Vowels(ref word);
                Consonants(ref word);

                Console.Write("\n");

                Console.WriteLine("Translate another line? (y/n): ");

                again = Console.ReadLine();

                if  (again == "y")
                {
                    done = true;
                }
                else if (again == "n")
                {
                    Console.WriteLine("GoodBye");
                    done = false;
                } 
            } while (done);
        }

        static void Consonants(ref string word)
        {
            string newWord;
            bool digraph = false;

            // determine if it starts with a digraph if statement
            if (word.StartsWith("ch") || word.StartsWith("gh") || word.StartsWith("ph") || word.StartsWith("sh") || word.StartsWith("th") || word.StartsWith("wh") || word.StartsWith("kn") || word.StartsWith("qu"))
            {
                digraph = true;
            }

            if (digraph)
            {
                // handle double consonants
                newWord = word.Substring(2) + word.Substring(0, 2) + "ay";

                Console.WriteLine(newWord);
            }
            else
            {
                // handle single consonants
                Regex entry = new Regex(@"^([bcdfghjklmnpqrstvwxyz][^0-9|@|!|#|$|%|^|&|*|(|)|-|=|+|_|[|\]|\|\||,|<|.|>|/|\|?|][^\w{5,30}@\w{5,10}\.\w{2,3}])"); // Regex entry = new Regex(@"^([bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ])");              

                bool matched = entry.IsMatch(word);

                if (matched)
                {                 
                    newWord = word.Substring(1) + word.Substring(0, 1) + "ay";

                    Console.WriteLine(newWord);
                }
                //else if (!matched)
                //{
                //    Console.WriteLine($"{word} is invalid");
                //}

            }            
        }

        static void Vowels(ref string word)
        {
            string vowel = "way";

            Regex entry = new Regex(@"^([aeiou][^0-9|@|!|#|$|%|^|&|*|(|)|-|=|+|_|[|\]|\|\||,|<|.|>|/|\|?|][^\w{5,30}@\w{5,10}\.\w{2,3}])"); // Regex entry = new Regex(@"^([aeiouAEIOU])");

            bool matched = entry.IsMatch(word);

            if (matched)
            {
                string newWord = string.Concat(word, vowel);
                Console.WriteLine(newWord);
            }
            //else if (!matched)
            //{
            //    Console.WriteLine($"{word} is invalid");
            //}
        }
    }
}
