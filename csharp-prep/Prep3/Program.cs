using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        int guess = 2;
        int numberOfGuesses = 0;

        // use a do-while loop here...
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            numberOfGuesses++;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Congratulations, You guessed it! Number of gusses is " + numberOfGuesses );
                 
            } 
        
            
        }   
    }
}