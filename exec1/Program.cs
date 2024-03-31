using System;

public static class Utility
{
    public static int chooseAnOption(string[] options)
    {
        //string input;
         while (true)
        {
            // Print the options
            Console.WriteLine("Choose an option:");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            Console.WriteLine($"Enter your choice 1 to {options.Length}:");

            // Read user input
            string input = Console.ReadLine();

            // Validate the input
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= options.Length)
            {
                Console.WriteLine($"You chose: {options[choice - 1]}");
                return choice;
            }
            else
            {
                Console.WriteLine($"Invalid choice. Please enter a number from 1 to : {options.Length}.");
            }
        }
    }

    public static int GetNumberFromUser(string prompt)
    {
        int number;
        string userInput;

        while (true)
        {
            // Prompt the user for input
            Console.WriteLine(prompt);

            // Read the user input as a string
            userInput = Console.ReadLine();

            // Attempt to parse the input string into an integer
            if (int.TryParse(userInput, out number))
            {
                // Parsing was successful, return the parsed integer
                return number;
            }
            else
            {
                // Parsing failed, display an error message and prompt the user to try again
                Console.WriteLine("Invalid input. Please enter a valid integer number.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Define an array of options
        string[] optionsMain = { "Option 1 - rectangle", "Option 2 - triangle", "Option 3 - exit" };
        Shape shape;

        while (true)
        {
            // Print the options
            int opt = Utility.chooseAnOption(optionsMain);
            if(opt == 3)
                return;

            int width = Utility.GetNumberFromUser("Enter an integer number for width:");
            int height = Utility.GetNumberFromUser("Enter an integer number for height:");

            if(opt == 1)
                shape = new Rectangle(width, height);
            else
                shape = new Triangle(width, height);
            
            shape.sendResponse();
            // Add a separator
            Console.WriteLine(new string('-', 30));
        }
    }
}

public abstract class Shape
{
    // Properties for width and height
    public int Width { get; set; }
    public int Height { get; set; }

    public abstract double perimeter();

    public abstract void sendResponse();
}

public class Rectangle: Shape
{
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
    public override double perimeter()
    {
        return 2 * (Width + Height);
    }

    private int Area()
    {
        return Width * Height;
    }

    public override void sendResponse()
    {
        if(Math.Abs(Width-Height) > 5)
        {
            Console.WriteLine("Rectangle area:" + Area());
        }
        else
        {
            Console.WriteLine("Rectangle perimeter:" + perimeter());

        }

    }
}
public class Triangle: Shape
{
    public Triangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
    private string[] triangleOptions = { "Option 1 - Perimeter", "Option 2 - print triangle" };
    public override double perimeter()
    {
        double side = Math.Sqrt(Math.Pow((double)Height, 2) + Math.Pow((double)Width/2, 2));
        return 2 * side + Width;
    }

    private void triangleMagic()
    {
        //if we reached this function, then width is an odd number
        int halfWidth = (Width - 1) / 2; //when moving from different types of layer, this moves by one '*' instead of two (for the whole triangle).
        //number of different layers is moving from one '*' to width in the full triangle, or if we mark width = 2k+1, moving from 0 to k in one half (excluding the common middle *).
        //so k+1 different layers type.
        //devide hight to number of different layers - fron 0 (only central *) to half width full of *s.
        int layerRepeats = Height/(halfWidth + 1); //no need to use Math.Floor, since both are int now.
        //now, if our hight does not divide equaly with no remeider to this k+1 layers, we add the remainder to the first layer (the one * layer).
        //halfWidth is k, number of different layers (excluding the first one);
        int firstLayerRepeat = Height - layerRepeats * halfWidth;
        //now we print all the height lines:
        //the first type separately:
        //k empty, the central *, and another k empty
        //string line = " " * halfWidth + "*" + " " * halfWidth;
        string line = new string(' ', halfWidth) + "*" + new string(' ', halfWidth);
        for(int i = 0; i < firstLayerRepeat; i++)
        {
            Console.WriteLine(line);
        }
        //the rest of the layers:
        //starting from k-1 empty with one *, central *, one * and another k-1 empty
        //to
        //k * and no empty, central *, and another k * with no empty spaces.
        for(int i = 1; i <= halfWidth; i++)
        {
            //line = " " * (k-i) + "*" * i + "*" (central) + "*" * i + " " * (k-i);
            line =  new string(' ', halfWidth-i) + new string('*',  2*i+1) + new string(' ', halfWidth-i);
            //for each layer we print all repeat instances:
            for(int j = 0; j < layerRepeats; j++)
            {
                Console.WriteLine(line);
            }
        }
    
    }

    public override void sendResponse()
    {
        int opt = Utility.chooseAnOption(triangleOptions);
        if(opt == 1)
        {
            Console.WriteLine("Rectangle perimeter:" + perimeter());
        }
        else
        {
            if(Width%2 == 0 || Width > 2*Height)
            {
                Console.WriteLine("unable to print");
            }
            else
            {
                triangleMagic();
            }
        }
    }
}

