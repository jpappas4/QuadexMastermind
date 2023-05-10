using System;

public class MastermindGame
{
    //MastermindGame guess a 4 diget number using numbers 1 to 6 within 10 guesses display - for correct number but wrong place and + for correct number in correct place.  Display nothing for incorrect.
    private const int CodeLength = 4;
    private const int MaxAttempts = 10;

    private static readonly Random random = new Random();

    private readonly int[] secretCode = new int[CodeLength];
    private int attemptsLeft;

    public void Play()
    {
        GenerateSecretCode();
        attemptsLeft = MaxAttempts;

        Console.WriteLine("Welcome to the Mastermind game!");
        Console.WriteLine("Try to guess the secret code using numbers from 1 to 6.");
        Console.WriteLine("You have " + MaxAttempts + " attempts.");

        bool isCodeGuessed = false;
        while (!isCodeGuessed && attemptsLeft > 0)
        {
            int[] guess = GetPlayerGuess();
            int correctPositionCount = 0;
            int correctNumberCount = 0;

            for (int i = 0; i < CodeLength; i++)
            {
                if (guess[i] == secretCode[i])
                {
                    correctPositionCount++;
                }
                else if (Array.IndexOf(secretCode, guess[i]) != -1)
                {
                    correctNumberCount++;
                }
            }

            if (correctPositionCount == CodeLength)
            {
                isCodeGuessed = true;
                Console.WriteLine("Congratulations! You guessed the secret code!");
            }
            else
            {
                //Loop through each number in guess and print - if it is correct but in the wrong spot.
                for (int h = 0; h < correctNumberCount; h++)
                {
                    Console.WriteLine("-");
                }

                //Loop through each number in guess and print + if it is correct and in correct spot.
                for (int j = 0; j < correctPositionCount; j++)
                {
                    Console.WriteLine("+");
                }
                attemptsLeft--;
                Console.WriteLine("Attempts left: " + attemptsLeft);
                Console.WriteLine();
            }
        }

        if (!isCodeGuessed)
        {
            Console.WriteLine("Game over! You ran out of attempts.");
            Console.WriteLine("The secret code was: " + string.Join("", secretCode));
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    private void GenerateSecretCode()
    {
        for (int i = 0; i < CodeLength; i++)
        {
            // Generate a random number between 1 and 6
            secretCode[i] = random.Next(1, 7);
        }
    }

    private int[] GetPlayerGuess()
    {
        int[] guess = new int[CodeLength];

        Console.Write("Enter your guess: ");
        string input = Console.ReadLine();

        while (input.Length != CodeLength || !int.TryParse(input, out int _))
        {
            Console.WriteLine("Invalid guess. Please enter a " + CodeLength + "-digit number.");
            Console.Write("Enter your guess: ");
            input = Console.ReadLine();
        }

        for (int i = 0; i < CodeLength; i++)
        {
            guess[i] = int.Parse(input[i].ToString());
        }

        return guess;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MastermindGame game = new MastermindGame();
        game.Play();
    }
}