// Project Prolog
// Name: Tanner Erekson
// Project: Mountain Bike Trail Recommendation System
// Date: 7/13/2021 
// Purpose: The purpose of this project is to create a system that
// will recommend a mountain biking trail based on user input.
// Files needed: MountainBikeTrails.csv

using System;
using System.IO;
using System.Collections.Generic;

namespace TrailRecommendations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates Lists and variables that will be used throughout
            List<Trail> blackTrails = new List<Trail>();
            List<Trail> greenTrails = new List<Trail>();
            List<Trail> blueTrails = new List<Trail>();
            List<Trail> flowyTrails = new List<Trail>();
            List<Trail> jumpyTrails = new List<Trail>();
            List<Trail> techTrails = new List<Trail>();
            List<Trail> shortTrails = new List<Trail>();
            List<Trail> longTrails = new List<Trail>();
            var rnd = new Random();

            // Asks for input for the directory of the csv file
            Console.Write("Please enter the path name for your csv file:");
            string filePath = Console.ReadLine();
            StreamReader reader = null;

            // checks to see if file exists
            if (File.Exists(filePath))
            {
                // Will open up the given file
                reader = new StreamReader(File.OpenRead(filePath));

                // This will set up variables used in the following while loop
                int count = 0;
                List<string> listA = new List<string>();
                string trail;
                string difficulty;
                string type;
                string distance;
                string address;
                List<Trail> trailList = new List<Trail>();

                // This read each line one at a time until it reaches the end of the file
                while (!reader.EndOfStream)
                {
                    // This will read 1 line in the file
                    var line = reader.ReadLine();
                    if (count <= 1)
                    {
                        count++;
                        continue;
                    }

                    // Create a Trail object with each new line
                    listA = Seperator(line);
                    Trail myTrail = new Trail(listA[0], listA[1], listA[2], listA[3], listA[4]);

                    trail = listA[0];
                    difficulty = listA[1];
                    type = listA[2];
                    distance = listA[3];
                    address = listA[4];

                    // Sort by difficulty
                    switch (myTrail.GetDifficulty())
                    {
                        case "Black":
                            blackTrails.Add(myTrail);
                            break;
                        case "Green":
                            greenTrails.Add(myTrail);
                            break;
                        case "Blue":
                            blueTrails.Add(myTrail);
                            break;
                    }

                    // Sort by difficulty
                    switch (myTrail.GetTType())
                    {
                        case "Flowy":
                            flowyTrails.Add(myTrail);
                            break;
                        case "Jumpy":
                            jumpyTrails.Add(myTrail);
                            break;
                        case "Technical":
                            techTrails.Add(myTrail);
                            break;
                    }

                    // sort by distance
                    string testTrail = myTrail.GetDistance();
                    var myDistance = double.Parse(myTrail.GetDistance());

                    if (myDistance >= 3)
                    {
                        longTrails.Add(myTrail);
                    }
                    else if (myDistance < 3)
                    {
                        shortTrails.Add(myTrail);
                    }
                }
            }

            else
            {
                Console.WriteLine("File doesn't exist");
            }

            // Menu option will looped through until input is entered to exit
            string choice = "0";
            int index = 0;

            while (choice != "4")
            {
                // Menu Option is created
                Console.WriteLine("\nHow would you like to sort the trails today?");
                Console.WriteLine("1 --> Trail Type");
                Console.WriteLine("2 --> Trail Difficulty");
                Console.WriteLine("3 --> Trail Distance");
                Console.WriteLine("4 --> Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        string choice2 = "0";
                        // Menu Option2 is created
                        Console.WriteLine("\nWhich Type of Trails would you like to ride today?");
                        Console.WriteLine("1 --> Flowy Trail");
                        Console.WriteLine("2 --> Jumpy Trail");
                        Console.WriteLine("3 --> Technical Trail");
                        Console.WriteLine("4 --> Exit");
                        choice2 = Console.ReadLine();

                        // checks what type of trail would like to be ridden
                        switch (choice2)
                        {
                            case "1":
                                index = rnd.Next(flowyTrails.Count);
                                PrintTrail(flowyTrails[index]);
                                choice = "4";
                                break;
                            case "2":
                                index = rnd.Next(jumpyTrails.Count);
                                PrintTrail(jumpyTrails[index]);
                                choice = "4";
                                break;
                            case "3":
                                index = rnd.Next(techTrails.Count);
                                PrintTrail(techTrails[index]);
                                choice = "4";
                                break;
                            case "4":
                                break;
                        }
                        break;

                    case "2":
                        string choice3 = "0";
                        // Menu Option2 is created
                        Console.WriteLine("\nWhich Type of Trails would you like to ride today?");
                        Console.WriteLine("1 --> Green Trail (Easy)");
                        Console.WriteLine("2 --> Blue Trail (Intermediate)");
                        Console.WriteLine("3 --> Black Trail(Expert)");
                        Console.WriteLine("4 --> Exit");
                        choice3 = Console.ReadLine();

                        // checks what type of trail would like to be ridden
                        switch (choice3)
                        {
                            case "1":
                                index = rnd.Next(greenTrails.Count);
                                PrintTrail(greenTrails[index]);
                                choice = "4";
                                break;
                            case "2":
                                index = rnd.Next(blueTrails.Count);
                                PrintTrail(blueTrails[index]);
                                choice = "4";
                                break;
                            case "3":
                                index = rnd.Next(blackTrails.Count);
                                PrintTrail(blackTrails[index]);
                                choice = "4";
                                break;
                            case "4":
                                break;
                        }
                        break;
                    case "3":
                        string choice4 = "0";
                        // Menu Option2 is created
                        Console.WriteLine("\nWhich Type of Trails would you like to ride today?");
                        Console.WriteLine("1 --> Short Trail");
                        Console.WriteLine("2 --> Long Trail");
                        Console.WriteLine("3 --> Exit");
                        choice4 = Console.ReadLine();

                        // checks what type of trail would like to be ridden
                        switch (choice4)
                        {
                            case "1":
                                index = rnd.Next(shortTrails.Count);
                                PrintTrail(shortTrails[index]);
                                choice = "4";
                                break;
                            case "2":
                                index = rnd.Next(longTrails.Count);
                                PrintTrail(longTrails[index]); choice = "4";
                                break;
                            case "3":
                                break;
                        }
                        break;
                    case "4":
                        break;
                }
            }
        }

        /// <summary>
        /// Purpose: This method will take a given line from a file and split it by comma.
        /// Each item will be added to a list and then the whole list will be returned
        /// </summary>
        /// <param name="line"></param>
        /// <returns>A list</returns>
        static List<string> Seperator(string line)
        {
            List<string> listA = new List<string>();
            var currentLine = line.Split(',');
            foreach (var item in currentLine)
            {
                listA.Add(item);
            }

            return listA;
        }

        static void PrintTrail(Trail myTrail)
        {
            Console.WriteLine("\nToday you get to ride:");
            Console.WriteLine($"Trail Name: {myTrail.GetName()}");
            Console.WriteLine($"Trail Difficulty: {myTrail.GetDifficulty()}");
            Console.WriteLine($"Trail Type: {myTrail.GetTType()}");
            Console.WriteLine($"Trail Distance: {myTrail.GetDistance()} miles");
            Console.WriteLine($"Trail Address: {myTrail.GetAddress()}");
        }
    }
}
