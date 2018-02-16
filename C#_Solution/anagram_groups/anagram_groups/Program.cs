using System;
using System.Collections.Generic;

namespace anagram_groups
{
    class Anagrams
    {
        public static void Main()
        {
            int counter = 0;
            string line;
            Dictionary<string, List<string>> hash = new Dictionary<string, List<string>>();

            // read in the file
            System.IO.StreamReader file = new System.IO.StreamReader(@"./../../words.txt");
            while ((line = file.ReadLine()) != null)
            {
                // sort the word and add to dictionary
                string sorted_word = SortWord(line);

                if (hash.ContainsKey(sorted_word))
                {
                    hash[sorted_word].Add(line);
                }
                else
                {
                    hash.Add(sorted_word, new List<string>() { line });
                }

                counter++;
            }

            file.Close(); // close the file

            // print out the anagrams only if there are more than 1
            foreach (var pair in hash)
            {
                if (pair.Value.Count > 1)
                    Console.WriteLine("{0}", String.Join(", ", pair.Value));
            }
        }
        public static string SortWord(string input)
        {
            // sorts a string alphabetically
            char[] characters = input.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}