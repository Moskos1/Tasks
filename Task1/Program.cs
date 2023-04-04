using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string input = "gdfgdf25678990dggf*9786754343234677763oP";
            string pattern = @"([\d]+)|([+\-*])|([\d]+)"; // регулярное выражение для поиска чисел и знака операции
            MatchCollection matchesExpression = Regex.Matches(input, pattern);
            string[] expression = new string[3];
            
            int i = 0;
            for (i = 0; matchesExpression[i].ToString() != "/" && matchesExpression[i].ToString() != "+" 
                && matchesExpression[i].ToString() != "*" && matchesExpression[i].ToString() != "-"; i++)
            {
                expression[0] += matchesExpression[i].ToString();
            }
            expression[1] = matchesExpression[i].ToString();
            for (i++; i < matchesExpression.Count; i++)
            {
                expression[2] += matchesExpression[i].ToString();
            }
            char operation = Convert.ToChar(expression[1]); // знак операции

            // выполняем операцию
            int result=0;
            switch (operation)
            {
                case '+':
                    result = int.Parse(expression[0]) + int.Parse(expression[2]);
                    break;
                case '-':
                    result = int.Parse(expression[0]) - int.Parse(expression[2]);
                    break;
                case '*':
                    result = int.Parse(expression[0]) * int.Parse(expression[2]);
                    break;
                case '/':
                    result = int.Parse(expression[0]) / int.Parse(expression[2]);
                    break;

            }

            Console.WriteLine(result);
        }
        catch(OverflowException exp) 
        { 
            Console.WriteLine(exp.Message); 
        }
        
        catch
        {
            Console.WriteLine("Invalid input string format!");
        }
       
        Console.ReadKey();
    }
}