using System;

public abstract class Shape
{
    // Properties for width and height
    public double Width { get; set; }
    public double Height { get; set; }

    private abstract double perimeter();

    public abstract void sendResponse();
}

public class Rectangle: Shape
{
    private override double Perimeter()
    {
        return 2 * (Width + Height);
    }

    private double Area()
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
            Console.WriteLine("Rectangle perimeter:" + Perimeter());

        }

    }
}
public class Triangle: Shape
{
    private string[] triangleOptions = { "Option 1 - Perimeter", "Option 2 - print triangle" };
    private override double Perimeter()
    {
        double side = Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Width/2, 2));
        return 2 * side + Width;
    }

    private void triangleMagic()
    {
        int layerNum = Math.Floor(Width/Height);
        int numOfLayers =  Math.Floor(Width/layerNum);
        int firstLayer = (numOfLayers - 1) * layers;
    }

    private void sendResponse()
    {
        string opt = chooseAnOption(triangleOptions);
        if(opt == "1")
        {
            Console.WriteLine("Rectangle perimeter:" + Perimeter());
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
class Program
{
    static void Main()
    {
        // Define an array of options
        string[] optionsMain = { "Option 1 - rectangle", "Option 2 - triangle", "Option 3 - exit" };
        string[] optionsTriangle = { "Option 1 - Perimeter", "Option 2 - print triangle" };
        Shape shape;

        while (true)
        {
            // Print the options
            string opt = chooseAnOption(options);
            if(opt == "3")
                return;

            int width = GetNumberFromUser("Enter an integer number for width:");
            int height = GetNumberFromUser("Enter an integer number for height:");

            if(input == "1")
                shape = new Rectangle(width, height);
            else
                shape = new Triangle(width, height);
            }
            shape.print();
            // Add a separator
            Console.WriteLine(new string('-', 30));
        }
    }

    static string chooseAnOption(string[] options)
    {
        string input;
         while (true)
        {
            // Print the options
            Console.WriteLine("Choose an option:");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            Console.WriteLine($"Enter your choice 1 to : {options.Length}");

            // Read user input
            input = Console.ReadLine();

            // Validate the input
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= options.Length)
            {
                Console.WriteLine($"You chose: {options[choice - 1]}");
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
            }
        }
    }

    static int GetNumberFromUser(string prompt)
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
            if (double.TryParse(userInput, out number))
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

