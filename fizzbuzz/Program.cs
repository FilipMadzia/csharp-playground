namespace fizzbuzz;

class Program
{
    static string FizzBuzz(int number)
    {
        if (number % 3 == 0 && number % 5 == 0)
        {
            return "FizzBuzz";
        }
        else if (number % 3 == 0)
        {
            return "Fizz";
        }
        else if (number % 5 == 0)
        {
            return "Buzz";
        }
        
        return "Something went wrong";
    }
    
    static void Main()
    {
        Console.WriteLine(FizzBuzz(5));
    }
}