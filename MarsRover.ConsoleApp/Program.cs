using MarsRover.Business.Services.Concrete;
using MarsRover.Core.Utilities.Results;
using MarsRover.Entities.Abstract;

TransactionResult<IPlateauDto> p;

do
{
    Console.WriteLine("Please enter Plateau width and heigth cordinations like 3 3");
    string cordinates = Console.ReadLine();
    p = PlateauService.Current.Create(cordinates);
    Console.WriteLine(p.Message);

} while (!p.IsSuccess);


do
{
    ConsoleKey responseKey;
    do
    {
        Console.Write("Do you create new Rover on plateu? [y/n]");
        responseKey = Console.ReadKey(false).Key;
        if (responseKey != ConsoleKey.Enter)
            Console.WriteLine();
    } while (responseKey != ConsoleKey.Y && responseKey != ConsoleKey.N);

    if (responseKey == ConsoleKey.N)
        break;

    bool isCreateRover;
    do
    {
        Console.WriteLine("Please enter your Rover landing coordinates and direction like 1 2 W...");
        string roverPositionText = Console.ReadLine();

        var roverResult = RoverService.Current.Create(p.ResponseObject, roverPositionText);

        isCreateRover = roverResult.IsSuccess;

        if (!roverResult.IsSuccess)
        {
            continue;
        }

        var displayResult = PlateauService.Current.DisplayText(p.ResponseObject);
        if (displayResult.IsSuccess)
        {
            Console.Clear();
            Console.WriteLine(displayResult.ResponseObject);
        }


        bool isExploreComplete;
        do
        {
            Console.WriteLine("Please create rover explore command like LLMMRLRLM");
            string commandText = Console.ReadLine();

            var exploreResult = RoverService.Current.Explore(roverResult.ResponseObject, commandText);

            isExploreComplete = exploreResult.IsSuccess;

            if (!isExploreComplete)
            {
                continue;
            }

            displayResult = PlateauService.Current.DisplayText(p.ResponseObject);
            if (displayResult.IsSuccess)
            {
                Console.Clear();
                Console.WriteLine(displayResult.ResponseObject);
            }

        } while (!isExploreComplete);

    } while (!isCreateRover);

} while (true);
