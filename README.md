# TrailRecommender
This program will recommend a mountain biking trail based on user input on what they prefer. 

The file MountainBikeTrails.csv holds all of the information on different mountain bike trails within the Salt Lake City area.

To start off, the program will ask for this .csv file so it can be loaded and read. The program reads the file and makes Trail Objects that hold a Trail's name, difficulty, type, distance, and address. Once the object is created, it will sort the trail based on three aspects. The first is difficulty, second is type, and third is distance. Within these aspects, the program looks at the Trail object's value and puts it into a certain list.
This is then repeated until the end of file is reached.

Once sorted, a menu pop up will appear. You can choose how to sort the trails by entering a number 
  1 --> Type 
  2 --> Difficulty
  3 --> Distance
  4 --> Exit

Then based on user input, another menu will appear.

if Type is chosen first then this will appear
  1 --> Flowy 
  2 --> Jumpy
  3 --> Technical
  4 --> Exit

if Difficulty is chosen first then this will appear
  1 --> Green (Easy)
  2 --> Blue (Intermediate) 
  3 --> Black (Expert)
  4 --> Exit
  
  if Distance is chosen first then this will appear
  1 --> Short 
  2 --> Long
  3 --> Exit
  
  Once an option is chosen, a Trail will be printed to the console.
  

