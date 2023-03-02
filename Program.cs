using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            Robe NewRobe = new();
            NewRobe.Colors = new List<string>
            {
                "Peach Sherbert",
                "Rainbow Unicorn",
                "Mud Brown"
            };
            NewRobe.Length = 36;

            Hat NewHat = new();
            NewHat.ShininessLevel = 10;

            Prize NewPrize = new("WoW");


            Console.WriteLine("What is your name, adventurer?");
            string newName = Console.ReadLine();
            Console.WriteLine();
            Adventurer theAdventurer = new Adventurer(newName, NewRobe, NewHat);
            Console.WriteLine(theAdventurer.GetDescription());
            Console.WriteLine();


            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 420, 25);
            Challenge whatSecond = new Challenge(
                "How old am I?", 4, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge areYouADingDong = new Challenge("On a scale of 1-10, how much of a ding-dong are you?", 10, 30);
            Challenge lameMathProblem = new Challenge("How much $$$ are you willing to bribe me?", 420, 420);
            Challenge dogVsCat = new Challenge(
                @"Dogs or Cats?
    1) Dogs
    2) Cats
    ",
                1, 1000
            );


            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class


            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                areYouADingDong,
                lameMathProblem,
                dogVsCat
            };



            // Loop through all the challenges and subject the Adventurer to them
            bool x = true;

            while(x == true)
            {
                List<int> randomChallenges = new();

                while (randomChallenges.Count != 5)
                {
                    Random r = new();
                    int index = r.Next(0, challenges.Count);
                    if (!randomChallenges.Contains(index))
                    {
                        randomChallenges.Add(index);
                    }
                }
                foreach (int id in randomChallenges)
                {
                    challenges[id].RunChallenge(theAdventurer);
                }

                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                NewPrize.ShowPrize(theAdventurer);

                Console.WriteLine();
                Console.WriteLine("Do you want to try again? (y/n)");
                string repeat = Console.ReadLine().ToLower();

                if (repeat == "n")
                {
                    x = false;
                }
                else if (repeat == "y")
                {
                    theAdventurer.Awesomeness += (theAdventurer.NumberRight * 10);
                    theAdventurer.NumberRight = 0;
                    Console.WriteLine($"Awesomeness Score: {theAdventurer.Awesomeness}");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("NEXT ROUND DING-DING");
                    Console.WriteLine();
                }
            }
        }
    }
}
