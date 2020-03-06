using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check_Brackets
{
    class check_Brackets_Main
    {
       
            //this application will check if all the brackets in a file are correctly closed
            //lie ( { [ ] } ) is correctly closed and ({)}[] is not
             public static bool IsCorrect (string input)
            {
                var correctChecker = false;

                if (string.IsNullOrEmpty(input)) { return correctChecker; }
                else
                {

                //Dictionary with all possible brackets to pull from
                var openersAndCLosers = new Dictionary<char, char>
                    {
                        {'(', ')' },
                        {'{', '}' },
                        {'[', ']'}
                    };
                //two different sets of char's - with open braces and close braces
                var openers = new HashSet<char>(openersAndCLosers.Keys);
                var closer = new HashSet<char>(openersAndCLosers.Values);

                //now we should go through input string and use Stack when we encounter an opener
                //when we encounter a different pair of opener - closer - we know that something is wrong
                var stackChecker = new Stack<char>();

                //loop through every symbol in the inpout string to get all the openers and then closers
                foreach (char c in input)
                {
                    if (openers.Contains(c))
                    {
                        Console.WriteLine($"Encountered opener: {c}");
                        stackChecker.Push(c);
                    }
                    if (closer.Contains(c))
                    {
                        if(stackChecker.Count == 0)
                        {
                            return false;
                        }

                        Console.WriteLine($"Encountered closer: {c}");

                        char lastUnclosedOpener = stackChecker.Pop();

                        if (openersAndCLosers [lastUnclosedOpener] != c)
                        {
                            Console.WriteLine("Looks like here is the issue with this bracket closer");
                            return false;
                        }

                    }
                    correctChecker = true;
                }

                Console.WriteLine("Looks like your code is good. Nice job closing the brackets:)");
                return correctChecker;
                }
            }

        static void Main(string[] args)
        {
            IsCorrect("Some COde Here ( Then this brackets) () () all over { and again [and again } is that even right? )");
        }

    }
}
