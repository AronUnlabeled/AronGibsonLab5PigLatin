using System;

namespace AronGibsonLab5PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            //used for our outer loop.
            String again = "y";

            //outer loop is for going until the user wants to stop.
            do 
            {
                Console.WriteLine("Enter a word or sentance. Letters only or ' (apostrophe) for contractions.");
                string s = Console.ReadLine().Trim();

                //calls method to validate the sentance or word.
                while(!validatePigLatin(s)){
                    Console.WriteLine("Please enter a valid word or sentance. Letters only or ' (apostrophe) for contractions.");
                    Console.ReadLine().Trim();
                }

                string newString = "";
                String word;
                //splits words
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i]==' ') {
                        word = s.Substring(0,i);
                        s = s.Substring(i+1);
                        i = 0;
                        //Console.WriteLine(PigLatin(word));
                        newString += $" {PigLatin(word)}";
                    }
                }
                newString += $" {PigLatin(s)}";
                newString = newString.Substring(1);
                Console.WriteLine(newString);
 
                bool inputValid=false;
                //inner loop is for asking yes or no until they give a valid answer.
                do
                {
                    Console.WriteLine("again? y or n");
                    again = Console.ReadLine().Trim();
                    if (again == "y")
                        inputValid = true;
                    else if (again == "n")
                        inputValid = true;
                } 
                while (inputValid == false);
            } 
            while (again=="y");
        }

        static string PigLatin(String s)
        {
            int firstVowelIndex = -1;
            int length = s.Length;
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            
            //loop finds first vowel index.
            for (int i = 0; i < length; i++)
            {
                char letter = (s[i]) ;
                foreach (char vowel in vowels)
                {

                    if (char.ToLower(letter) == vowel)
                    {
                        firstVowelIndex = i;
                        break;
                    }
                }
                if (firstVowelIndex != -1)
                    break;
            }

            if (firstVowelIndex == -1)
                return $"{s}ay";
            else if (firstVowelIndex == 0)
                return $"{s}way";
            else
                return $"{s.Substring(firstVowelIndex)}{s.Substring(0, firstVowelIndex)}ay";
        }

        public static bool validatePigLatin(string s)
        {

            if (s == "") 
            {
            Console.WriteLine("You Entered nothing!");
                return false;
            }
            foreach (char letter in s)
            {
                if (letter == '\'') {
                    continue;
                }
                else if(letter ==' '){
                    continue;
                }

                //I used ASCII method for efficiency  
                else if ((int)letter < 91) {
                    if ((int)letter < 65)
                    {
                        Console.WriteLine("invalid character(s)!");
                        return false;
                    }
                    else
                        continue;
                }

                else if ((int)letter > 64)
                    if ((int)letter > 122)
                    {
                        Console.WriteLine("invalid character(s)!");
                        return false;
                    }
                    else
                        continue;
                }

            return true;
            } 

        }
    }
