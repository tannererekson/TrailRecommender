///
///
///
///
///
///
///
///

using System;
using System.IO;
using System.Collections.Generic;

namespace TrailRecommendations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trail> BlackTrails = new List<Trail>();
            List<Trail> GreenTrails = new List<Trail>();
            List<Trail> BlueTrails = new List<Trail>();
            List<Trail> FlowyTrails = new List<Trail>();
            List<Trail> JumpyTrails = new List<Trail>();
            List<Trail> TechTrails = new List<Trail>();
            List<Trail> ShortTrails = new List<Trail>();
            List<Trail> LongTrails = new List<Trail>();
            var rnd = new Random();

            //Asks for input for the directory of the csv file
            Console.Write("Please enter the path name for your csv file:");
            string filePath = Console.ReadLine();
            filePath = @"/Users/tannererekson/Desktop/TrailRecommendations/MountainBikeTrails.csv";
            StreamReader reader = null;

            //checks to see if file exists
            if (File.Exists(filePath))
            {
                //Will open up the given file
                int count = 0;
                reader = new StreamReader(File.OpenRead(filePath));
                List<string> listA = new List<string>();

                //This will set up variables
                string trail;
                string difficulty;
                string type;
                string distance;
                string address;
                List<Trail> trailList = new List<Trail>();

                //This will loop until it reaches the end of the file
                while (!reader.EndOfStream)
                {
                    //This will read a line in the file
                    var line = reader.ReadLine();
                    if (count <= 1)
                    {
                        count++;
                        continue;
                    }

                    //This will create a Trail object with each new line
                    listA = Seperator(line);
                    Trail myTrail = new Trail(listA[0], listA[1], listA[2], listA[3], listA[4]);

                    trail = listA[0];
                    difficulty = listA[1];
                    type = listA[2];
                    distance = listA[3];
                    address = listA[4];

                    //sort by difficulty
                    switch (myTrail.GetDifficulty())
                    {
                        case "Black":
                            BlackTrails.Add(myTrail);
                            break;
                        case "Green":
                            GreenTrails.Add(myTrail);
                            break;
                        case "Blue":
                            BlueTrails.Add(myTrail);
                            break;
                    }

                    //sort by difficulty
                    switch (myTrail.GetTType())
                    {
                        case "Flowy":
                            FlowyTrails.Add(myTrail);
                            break;
                        case "Jumpy":
                            JumpyTrails.Add(myTrail);
                            break;
                        case "Technical":
                            TechTrails.Add(myTrail);
                            break;
                    }

                    string testTrail = myTrail.GetDistance();
                    //sort by distance
                    var myDistance = double.Parse(myTrail.GetDistance());

                    if (myDistance >= 3)
                    {
                        LongTrails.Add(myTrail);
                    }
                    else if (myDistance < 3)
                    {
                        ShortTrails.Add(myTrail);
                    }
                }
            }

            else
            {
                Console.WriteLine("File doesn't exist");
            }

            //Menu option will looped through until input is entered to exit
            string choice = "0";
            int index = 0;
            Trail givenTrail = null;

            while (choice != "4")
            {
                //Menu Option is created
                Console.WriteLine("How would you like to sort the trails today?");
                Console.WriteLine("1 --> Trail Type");
                Console.WriteLine("2 --> Trail Difficulty");
                Console.WriteLine("3 --> Trail Distance");
                Console.WriteLine("4 --> Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        string choice2 = "0";
                        //Menu Option2 is created
                        Console.WriteLine("Which Type of Trails would you like to ride today?");
                        Console.WriteLine("1 --> Flowy Trail");
                        Console.WriteLine("2 --> Jumpy Trail");
                        Console.WriteLine("3 --> Technical Trail");
                        Console.WriteLine("4 --> Exit");
                        choice2 = Console.ReadLine();

                        //checks what type of trail would like to be ridden
                        switch (choice2)
                        {
                            case "1":
                                index = rnd.Next(FlowyTrails.Count);
                                PrintTrail(FlowyTrails[index]);
                                choice = "4";
                                break;
                            case "2":
                                index = rnd.Next(JumpyTrails.Count);
                                PrintTrail(JumpyTrails[index]);
                                choice = "4";
                                break;
                            case "3":
                                index = rnd.Next(TechTrails.Count);
                                PrintTrail(TechTrails[index]);
                                choice = "4";
                                break;
                            case "4":
                                break;
                        }
                        break;

                    case "2":
                        string choice3 = "0";
                        //Menu Option2 is created
                        Console.WriteLine("Which Type of Trails would you like to ride today?");
                        Console.WriteLine("1 --> Green Trail");
                        Console.WriteLine("2 --> Blue Trail");
                        Console.WriteLine("3 --> Black Trail");
                        Console.WriteLine("4 --> Exit");
                        choice3 = Console.ReadLine();

                        //checks what type of trail would like to be ridden
                        switch (choice3)
                        {
                            case "1":
                                index = rnd.Next(GreenTrails.Count);
                                PrintTrail(GreenTrails[index]);
                                choice = "4";
                                break;
                            case "2":
                                index = rnd.Next(BlueTrails.Count);
                                PrintTrail(BlueTrails[index]);
                                choice = "4";
                                break;
                            case "3":
                                index = rnd.Next(BlackTrails.Count);
                                PrintTrail(BlackTrails[index]);
                                choice = "4";
                                break;
                            case "4":
                                break;
                        }
                        break;
                    case "3":
                        string choice4 = "0";
                        //Menu Option2 is created
                        Console.WriteLine("Which Type of Trails would you like to ride today?");
                        Console.WriteLine("1 --> Short Trail");
                        Console.WriteLine("2 --> Long Trail");
                        Console.WriteLine("3 --> Exit");
                        choice4 = Console.ReadLine();

                        //checks what type of trail would like to be ridden
                        switch (choice4)
                        {
                            case "1":
                                index = rnd.Next(ShortTrails.Count);
                                PrintTrail(ShortTrails[index]);
                                choice = "4";
                                break;
                            case "2":
                                index = rnd.Next(LongTrails.Count);
                                PrintTrail(LongTrails[index]); choice = "4";
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
            Console.WriteLine($"Trail Name: {myTrail.GetName()}");
            Console.WriteLine($"Trail Difficulty: {myTrail.GetDifficulty()}");
            Console.WriteLine($"Trail Type: {myTrail.GetTType()}");
            Console.WriteLine($"Trail Distance: {myTrail.GetDistance()} miles");
            Console.WriteLine($"Trail Address is: {myTrail.GetAddress()}");
        }
    }
}
