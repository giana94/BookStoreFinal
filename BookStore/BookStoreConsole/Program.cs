using BookStore;
using BookStore.Models;
using BookStoreConsole;



var _args = Environment.GetCommandLineArgs();
var choice = _args[0].ToString();
var books = BookStoreBasicFunctions.GetAllBooks();
var oh = new OutputHelper();

    //oh.WriteToConsole(b);
    //oh.WriteToCSV(b);


    Console.WriteLine("Please select the output format:");
    Console.WriteLine("1. CSV");
    Console.WriteLine("2. Console");

    Console.Write("Enter your choice (1 or 2): ");
    string outputChoiceStr = Console.ReadLine();

    if (int.TryParse(outputChoiceStr, out int outputChoice))
    {
        // Execute the appropriate action based on the user's choice
        if (outputChoice == 1)
        {
            Console.WriteLine("You chose CSV output.");
            FunctionOptions("CSV");
        }
        else if (outputChoice == 2)
        {
            Console.WriteLine("You chose Console output.");
            FunctionOptions("Console");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }


    static void FunctionOptions(string outputType)
    {
        Console.WriteLine("Please select a function:");
        Console.WriteLine("1. GetAllMovies");
        Console.WriteLine("2. GetAllBooksByAuthorLastName");
        Console.WriteLine("3. GetMovieByTitle");


        Console.Write("Enter your choice (1-3): ");
        string userChoiceStr = Console.ReadLine();


        if (int.TryParse(userChoiceStr, out int method))
        {
            switch (method)
            {
                case 1:
                    ExecuteFunction("GetAllBooks", outputType);
                    break;
                case 2:
                    Console.Write("Enter Author's last name: ");
                    string authorLastName = Console.ReadLine();
                    ExecuteFunction("GetAllBooksByAuthorLastName", outputType, authorLastName);
                    break;
                case 3:
                Console.Write("Enter book title: ");
                    string bookTitle = Console.ReadLine();
                    ExecuteFunction("GetBookByTitle", outputType, bookTitle);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }




        static void ExecuteFunction(string functionName, string outputType, params string[] userInput)
        {
            var oh = new OutputHelper();
            var movies = BookStoreBasicFunctions.ExecuteQuery(functionName, userInput);
            oh.Output(movies, outputType);

        }
    }
