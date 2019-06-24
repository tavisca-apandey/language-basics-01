using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            //Spliting the Equation.
            String[] terms=equation.Split(new char[]{'*','='});

            //Checking for the term with missing digit.
            int pos=-1;
            if(terms[0].Contains("?"))
                pos=0;
            else if(terms[1].Contains("?"))
                pos=1;
            else
                pos=2;
                
            int firstTerm=0,secondTerm=0,thirdTerm=0;

            //Finding the exact missing digit.
            if(pos==0)
            {
                bool ifSuccess1=int.TryParse(terms[1], out secondTerm);
                bool ifSuccess2=int.TryParse(terms[2], out thirdTerm);
                double tempMissingTerm=(double)thirdTerm/secondTerm;
                String missingTerm=tempMissingTerm.ToString();
                //(cc%1==0) to check if the term is decimal; Used mainly for Test 5 type of cases
                if(missingTerm.Length==terms[0].Length&&(tempMissingTerm%1==0))
                {
                    return int.Parse(missingTerm[terms[0].IndexOf('?')].ToString());
                }
            }
            else if(pos==1)
            {
                bool ifSuccess1=int.TryParse(terms[0], out firstTerm);
                bool ifSuccess2=int.TryParse(terms[2], out thirdTerm);
                double tempMissingTerm=(double)thirdTerm/firstTerm;
                String missingTerm=tempMissingTerm.ToString();
                //(cc%1==0) to check if the term is decimal; Used mainly for Test 5 type of cases
                if(missingTerm.Length==terms[1].Length&&(tempMissingTerm%1==0))
                {
                    return int.Parse(missingTerm[terms[1].IndexOf('?')].ToString());
                }
            }
            else if(pos==2)
            {
                bool ifSuccess1=int.TryParse(terms[0], out firstTerm);
                bool ifSuccess2=int.TryParse(terms[1], out secondTerm);
                thirdTerm=firstTerm*secondTerm;
                String missingTerm=thirdTerm.ToString();
                if(missingTerm.Length==terms[2].Length)
                {
                    return int.Parse(missingTerm[terms[2].IndexOf('?')].ToString());
                }
            }

            //If none of the above.
            return -1;
        }
    }
}
/*
Last login: Fri Jun 21 00:53:39 on ttys000
Anikets-MacBook-Pro:~ aniket$ cd /Users/aniket/language-basics-01/Tavisca.Bootcamp.LanguageBasics.Exercise1
Anikets-MacBook-Pro:Tavisca.Bootcamp.LanguageBasics.Exercise1 aniket$ dotnet run
42*47=1?74 : PASS
4?*47=1974 : PASS
42*?7=1974 : PASS
42*?47=1974 : PASS
2*12?=247 : PASS

[1]+  Stopped                 dotnet run
Anikets-MacBook-Pro:Tavisca.Bootcamp.LanguageBasics.Exercise1 aniket$ 
 */