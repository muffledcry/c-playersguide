using System;


ColoredItem<Sword> myBlueSword = new ColoredItem<Sword>(new(), ConsoleColor.Blue);
ColoredItem<Bow> myGreenBow = new ColoredItem<Bow>(new(), ConsoleColor.Green);
ColoredItem<Axe> myCyanAxe = new ColoredItem<Axe>(new(), ConsoleColor.Cyan);
myBlueSword.Display();
myGreenBow.Display();
myCyanAxe.Display();



public class ColoredItem<T>
{
    public T? Item {get;}
    public ConsoleColor Color {get;}

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item);
    }
}

public class Sword {}
public class Bow {}
public class Axe {}



using System;

Sword myFirstSword = new(Material.Iron, Gemstone.None, 24.0f, 10.0f);
Sword mySecondSword = myFirstSword with {material=Material.Wood, gemstone=Gemstone.Amber};
Sword myThirdSword = mySecondSword with {length=23.0f, crossguard=14.0f};

Console.WriteLine(myFirstSword);
Console.WriteLine(mySecondSword);
Console.WriteLine(myThirdSword);

public record Sword(Material material, Gemstone gemstone, float length, float crossguard);
public enum Material
{
    Wood,
    Bronze,
    Iron,
    
    Steel,
    Binarium,
}

public enum Gemstone
{
    None,
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone,
}

using System;

Coordinate myFirstCoordinate = new(5, 5);
Coordinate myAdjacentCoordinate = new(5,4);
Coordinate myNonAdjacentCoordinate = new(7, 7);

bool adjacent = myFirstCoordinate.isAdjacent(myAdjacentCoordinate);
bool nonAdjacent = myFirstCoordinate.isAdjacent(myNonAdjacentCoordinate);

Console.WriteLine(adjacent);
Console.WriteLine(nonAdjacent);

public struct Coordinate
{
    private readonly int Row;
    private readonly int Column;

    public Coordinate(int row, int column)
    {
        Row=row;
        Column=column;
    }

    public bool isAdjacent(Coordinate other)
    {
        if (Row == other.Row && (Column == other.Column+1 || Column == other.Column-1)) return true;
        else if (Column == other.Column && (Row == other.Row+1 || Row == other.Row-1)) return true;
        else return false;
    }
}

using System;

Robot myRobot = new();

for (int index = 0; index < 3; index++ )
{
    Console.WriteLine("Please enter a command.");
    Console.WriteLine("- Enter 0 to Turn the Robot Off.");
    Console.WriteLine("- Enter 1 to Turn the Robot On.");
    Console.WriteLine("- Enter N to Move the Robot North.");
    Console.WriteLine("- Enter S to Move the Robot South");
    Console.WriteLine("- Enter W to Move the Robot West");
    Console.WriteLine("- Enter E to Move the Robot East");
    String myCommand = Console.ReadLine();
    Console.Clear();

    switch (myCommand)
    {
        case "0":
            myRobot.Commands[index] = new OffCommand();
            break;
        
        case "1":
            myRobot.Commands[index] = new OnCommand();
            break;
        
        case "N":
            myRobot.Commands[index] = new NorthCommand();
            break;
        
        case "S":
            myRobot.Commands[index] = new SouthCommand();
            break;
        
        case "W":
            myRobot.Commands[index] = new WestCommand();
            break;

        case "E":
            myRobot.Commands[index] = new EastCommand();
            break;
        
        default :
            Console.WriteLine("That's not a valide command, you fucking idiot!");
            index--;
            break;
    }
}

myRobot.Run();

public class Robot
{
    public int X {get; set;}
    public int Y {get; set;}
    public bool IsPowered {get; set;}
    public IRobotCommand[] Commands {get;} = new IRobotCommand[3];
    public void Run()
    {
        foreach (IRobotCommand command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
} 

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
    
}
public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

using System;

Robot myRobot = new();

for (int index = 0; index < 3; index++ )
{
    Console.WriteLine("Please enter a command.");
    Console.WriteLine("- Enter 0 to Turn the Robot Off.");
    Console.WriteLine("- Enter 1 to Turn the Robot On.");
    Console.WriteLine("- Enter N to Move the Robot North.");
    Console.WriteLine("- Enter S to Move the Robot South");
    Console.WriteLine("- Enter W to Move the Robot West");
    Console.WriteLine("- Enter E to Move the Robot East");
    String myCommand = Console.ReadLine();
    Console.Clear();

    switch (myCommand)
    {
        case "0":
            myRobot.Commands[index] = new OffCommand();
            break;
        
        case "1":
            myRobot.Commands[index] = new OnCommand();
            break;
        
        case "N":
            myRobot.Commands[index] = new NorthCommand();
            break;
        
        case "S":
            myRobot.Commands[index] = new SouthCommand();
            break;
        
        case "W":
            myRobot.Commands[index] = new WestCommand();
            break;

        case "E":
            myRobot.Commands[index] = new EastCommand();
            break;
        
        default :
            Console.WriteLine("That's not a valide command, you fucking idiot!");
            index--;
            break;
    }
}

myRobot.Run();

public class Robot
{
    public int X {get; set;}
    public int Y {get; set;}
    public bool IsPowered {get; set;}
    public RobotCommand[] Commands {get;} = new RobotCommand[3];
    public void Run()
    {
        foreach (RobotCommand command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
} 

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
    
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

Pack myPack = new(5, 5.0f, 1.0f);

while (true)
{
    Console.WriteLine("What item do you want to pack?");
    Console.WriteLine("- Enter 1 for an Arrow.");    
    Console.WriteLine("- Enter 2 for an Bow.");
    Console.WriteLine("- Enter 3 for an Rope.");
    Console.WriteLine("- Enter 4 for an Water.");
    Console.WriteLine("- Enter 5 for an Food.");
    Console.WriteLine("- Enter 6 for an Sword.");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Arrow myArrow = new();
            myPack.Add(myArrow);
            break;
        case "2":
            Bow myBow = new();
            myPack.Add(myBow);
            break;
        case "3":
            Rope myRope = new();
            myPack.Add(myRope);
            break;
        case "4":
            Water myWater = new();
            myPack.Add(myWater);
            break;
        case "5":
            Food myFood = new();
            myPack.Add(myFood);
            break;
        case "6":
            Sword mySword = new();
            myPack.Add(mySword);
            break;
    }
}

public class Pack
{
    InventoryItem[] Items {get; set;}
    int ItemLimit {get;}
    int ItemCount {get; set;}
    float WeightLimit {get;}
    float CurrentWeight {get; set;}
    float VolumeLimit {get; }
    float CurrentVolume {get; set;}

    public Pack(int itemLimit, float weightLimit, float volumeLimit)
    {
        Items = new InventoryItem[itemLimit];
        ItemLimit=itemLimit; ItemCount=0; 
        WeightLimit=weightLimit; CurrentWeight=0.00f;
        VolumeLimit=volumeLimit; CurrentVolume=0.00f;
    }

    public void Total()
    {
        if (ItemCount == 0) {Console.WriteLine("Item count was zero. No total.");}
        else{
            ItemCount = 0;
            CurrentWeight = 0.00f;
            CurrentVolume = 0.00f;

            foreach(InventoryItem item in Items)
                {
                    if (item!= null)
                    {
                        ItemCount +=1;
                        CurrentWeight += item.Weight;
                        CurrentVolume += item.Volume;
                    }
                }
            Console.WriteLine($"Item count is: {ItemCount}");
            Console.WriteLine($"Current Weight is: {CurrentWeight}");
            Console.WriteLine($"Current Volume is: {CurrentVolume}");
        }
    }

    public void Add(InventoryItem item)
    {
        Total();
        if (ItemCount < ItemLimit && CurrentWeight < WeightLimit && CurrentVolume < VolumeLimit)
        {
            Items[ItemCount] = item;
            ItemCount+=1;
        }
        else Console.WriteLine("Additional item exceeds pack limitations. Not added.");
    }
}

public class InventoryItem
{
    public float Weight {get; set;}
    public float Volume {get; set;}
}

public class Arrow : InventoryItem
{
    public Arrow()
    {
        Weight = 0.1f;
        Volume = 0.05f;
    }
}
public class Bow : InventoryItem
{
    public Bow()
    {
        Weight = 1.0f;
        Volume = 4.0f;
    }
}
public class Rope : InventoryItem
{
    public Rope()
    {
        Weight = 1.0f;
        Volume = 1.5f;
    }
    
}
public class Water : InventoryItem
{
    public Water()
    {
        Weight = 2.0f;
        Volume = 3.0f;
    }
}
public class Food : InventoryItem
{
    public Food()
    {
        Weight = 1.0f;
        Volume = 0.5f;
    }

}
public class Sword : InventoryItem
{
    public Sword()
    {
        Weight = 5.0f;
        Volume = 3.0f;
    }
}


using System;
using System.Linq;

TicTacToe game = new TicTacToe(2, 0, 0);
game.Play();

class TicTacToe
{
    public int Rounds {get; set;}
    public Player[]? Players {get; }
    public Board? GameBoard {get;}
    public bool PlayGame {get;}

    public TicTacToe(int rounds, int playerOneScore, int playerTwoScore)
    {
        Rounds = rounds;
        Players = new Player[2];
        GameBoard = new Board();
        PlayGame = true;

        Players[0]  = new Player('X', playerOneScore);
        Players[1] = new Player('O', playerTwoScore);

        System.Random generator = new System.Random();
        int goesFirst = generator.Next(0,1);
        Players[goesFirst].HasTurn = true;
    }

    public bool CheckWin(char mark)
    {
        if (
            // check horizontals for X
            (GameBoard?.RowOne?[0] == mark && GameBoard.RowOne[1] == mark && GameBoard.RowOne[2] == mark) |
            (GameBoard?.RowTwo?[0] == mark && GameBoard.RowTwo[1] == mark && GameBoard.RowTwo[2] == mark) | 
            (GameBoard?.RowThree?[0] == mark && GameBoard.RowThree[1] == mark && GameBoard.RowThree[2] == mark) |
            // check verticals for X 
            (GameBoard?.RowOne?[0] == mark && GameBoard?.RowTwo?[0] == mark && GameBoard?.RowThree?[0] == mark) | 
            (GameBoard?.RowOne?[1] == mark && GameBoard?.RowTwo?[1] == mark && GameBoard?.RowThree?[1] == mark) | 
            (GameBoard?.RowOne?[2] == mark && GameBoard?.RowTwo?[2] == mark && GameBoard?.RowThree?[2] == mark) |
            // check diagonals for X
            (GameBoard?.RowOne?[0] == mark && GameBoard?.RowTwo?[1] == mark && GameBoard?.RowThree?[2] == mark) |
            (GameBoard?.RowOne?[2] == mark && GameBoard?.RowTwo?[1] == mark && GameBoard?.RowThree?[0] == mark)
            ) 
            return true;
        else 
            return false;
    }

    public char GetChoice(Player  player)
    {
        Console.WriteLine($"It's {player.Mark}'s turn.");
        Console.WriteLine("Where will you place your mark?");
        char choice = Convert.ToChar(Console.ReadLine());
        return choice;
    }

    public bool Available()
    {
        Console.WriteLine($"{GameBoard?.Redraws} redraws.");
        if (GameBoard?.Redraws < 9) return true;
        else return false;
    }

    public void Play()
    {
        bool play = true;
        while (play)
        {
            foreach (Player player in Players)
            {    
                bool win = CheckWin(player.Mark);
                if (win) 
                {
                    player.Score +=1;
                    Console.WriteLine("Tic Tac Toe: Three in a row!");
                    Console.WriteLine($"{player.Mark} has won!");
                    Console.WriteLine("\nPress enter to continue.");
                    Console.Clear();

                    Console.WriteLine("--------------");
                    Console.WriteLine("SCOREBOARD:");
                    Console.WriteLine("--------------");
                    Console.WriteLine($"{Players[0].Mark} has {Players[0].Score} points.");
                    Console.WriteLine($"{Players[1].Mark} has {Players[1].Score} points.");
                    Console.WriteLine("\n Press enter to start a new game.");
                    play = false;
                }
            }
            Console.Clear();
            bool canPlay = Available();
            if (canPlay)
            {
                GameBoard?.drawBoard();


                foreach (Player player in Players)
                {
                    if (player.HasTurn == true)
                    {
                        char choice = GetChoice(player);
                        GameBoard?.update(choice, player.Mark);
                        player.HasTurn = false;
                    }
                    else player.HasTurn = true;
                }
            }
            else 
            {
                Console.WriteLine("Draw.");
                play = false;
            }
        }
        Console.WriteLine("Would you like to play another round?");
        Console.WriteLine("Enter 1 for yes.");
        Console.WriteLine("Enter 2 for no.");
        string answer = Console.ReadLine();
        if (answer == "1")
        {
            Rounds +=1;
            TicTacToe game = new TicTacToe(Rounds, Players[0].Score, Players[1].Score);
            game.Play();
        }
    }
}

class Player
{
    public int Score {get; set;}
    public char Mark {get;}
    public bool HasTurn {get; set;}

    public Player(char mark, int score)
    {
        Score = score;
        Mark = mark;
        HasTurn = false;
    }
}

class Board
{
    public char[]? RowOne {get;}
    public char[]? RowTwo {get;}
    public char[]? RowThree {get;}

    public int Redraws {get; set;}

    public Board()
    {
        RowOne = new char[3];
        RowTwo = new char[3];
        RowThree = new char[3];
        Redraws = 0;

        RowOne[0] = '7';
        RowOne[1] = '8';
        RowOne[2] = '9';

        RowTwo[0] = '4';
        RowTwo[1] = '5';
        RowTwo[2] = '6';

        RowThree[0] = '1';
        RowThree[1] = '2';
        RowThree[2] = '3';
    }

    public void drawBoard()
    {
        Console.WriteLine($"{RowOne?[0]} | {RowOne?[1]} | {RowOne?[2]}");
        Console.WriteLine("---------");
        Console.WriteLine($"{RowTwo?[0]} | {RowTwo?[1]} | {RowTwo?[2]}");
        Console.WriteLine("---------");
        Console.WriteLine($"{RowThree?[0]} | {RowThree?[1]} | {RowThree?[2]}");
        Redraws += 1;
    }

    public void update(char choice, char mark)
    {
        if (choice == '7') {RowOne[0] = mark;}
        if (choice == '8') {RowOne[1] = mark;}
        if (choice == '9') {RowOne[2] = mark;}
        if (choice == '4') {RowTwo[0] = mark;}
        if (choice == '5') {RowTwo[1] = mark;}
        if (choice == '6') {RowTwo[2] = mark;}
        if (choice == '1') {RowThree[0] = mark;}
        if (choice == '2') {RowThree[1] = mark;}
        if (choice == '3') {RowThree[2] = mark;}
    }
}



using System;

Door myDoor = new(1234);
while (true)
{
    Console.Clear();
    Console.WriteLine($"The door is {myDoor.DoorState}.");
    Console.WriteLine($"What would you like to do?");
    Console.WriteLine($"Enter 1 to close the door.");
    Console.WriteLine($"Enter 2 to lock the door.");
    Console.WriteLine($"Enter 3 to unlock the door.");
    Console.WriteLine($"Enter 4 to open the door.");
    Console.WriteLine($"Enter 5 to change the door's passcode.");

    Int32 choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            myDoor.close();
            break;
        case 2:
            myDoor.lockDoor();
            break;
        case 3:
            myDoor.unlock();
            break;
        case 4:
            myDoor.open();
            break;
        case 5:
            Console.WriteLine("Please enter the door's current passcode: ");
            Int32 currentPassCode = Convert.ToInt32(Console.ReadLine());
            myDoor.changePassCode(currentPassCode);
            break;
        default:
            Console.WriteLine("That was not a valid choice.");
            break;
    }

}

class Door 
{
    public DoorState DoorState {get; set; }

    public Int32 PassCode {get; set; }

    public Door(Int32 passCode)
    {
        DoorState = DoorState.Open;
        PassCode = passCode;
    }

    public void unlock()
    {
        if (DoorState == DoorState.Locked)
        {
            Console.Clear();
            Console.WriteLine("Please enter the passcode to unlock the door: ");
            Int32 currentPassCode = Convert.ToInt32(Console.ReadLine());

            if (PassCode == currentPassCode) DoorState = DoorState.Closed;
            else 
            {
                Console.WriteLine("Incorrect passcode.");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }
    }

    public void lockDoor()
    {
        if (DoorState == DoorState.Closed) DoorState = DoorState.Locked;
    }

     public void open()
    {
        if (DoorState == DoorState.Closed) DoorState = DoorState.Open;
    }

    public void close()
    {
        if (DoorState == DoorState.Open) DoorState = DoorState.Closed;
    }

    public void changePassCode(Int32 passcode)
    {
       if (PassCode == passcode)
       {
           Console.Clear();
           Console.WriteLine("Your passcode is correct.");
           Console.WriteLine("Please enter your new passcode: ");
           Int32 newPassCode = Convert.ToInt32(Console.ReadLine());
           PassCode = newPassCode;
       }
    }
    

}

public enum DoorState 
{
    Open,
    Closed,
    Locked,
}



// Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
// Rank[] ranks= new Rank[] { Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.Dollar, Rank.Percent, Rank.Caret, Rank.Ampersand };

// foreach (Color color in colors)
// {
//     foreach (Rank rank in ranks)
//     {
//         Card card = new Card(color, rank);
//         Console.WriteLine($"The {card.Rank} of {card.Color}");
//     }
// }

// Card myCard = new Card(Color.Red, Rank.Ampersand);
// bool face = myCard.IsSymbol;
// Console.WriteLine(face);
// class Card
// {
//     public Color Color {get; }
//     public Rank Rank {get;}

//     public Card(Color color, Rank rank)
//     {
//         Color = color;
//         Rank = rank;
//     }

//     public bool IsSymbol => Rank == Rank.Ampersand || Rank == Rank.Caret || Rank == Rank.Dollar || Rank == Rank.Percent;
//     public bool IsNumber => !IsSymbol;
// }

// public enum Color
// {
//     Red,
//     Green,
//     Blue,
//     Yellow
// }

// public enum Rank
// {
//     One,
//     Two,
//     Three,
//     Four,
//     Five,
//     Six,
//     Seven,
//     Eight,
//     Nine,
//     Ten,
//     Dollar,
//     Percent,
//     Caret,
//     Ampersand

// }


// Color myFirstColor = new(125, 125, 125);
// Color mySecondColor = Color.Green;

// Console.WriteLine(myFirstColor.Printable());
// Console.WriteLine(mySecondColor.Printable());

// class Color 
// {
//     public Int32 R {get; }
//     public Int32 G {get; }
//     public Int32 B {get; }

//     public Color(Int32 r, Int32 g, Int32 b)
//     {
//         R = r;
//         G = g;
//         B = b;
//     }

//     public static Color White  => new Color(255, 255, 255);
//     public static Color Black  => new Color(0, 0, 0);    
//     public static Color Red => new Color(255, 0 ,0);
//     public static Color Orange => new Color(255, 165, 0);
//     public static Color Yellow => new Color(255, 255, 0);
//     public static Color Green => new Color(0, 255, 0);
//     public static Color Blue => new Color(0, 0, 255);
//     public static Color Purple => new Color(128, 0, 128);

//     public string Printable()
//     {
//         return $"({Red}, {Green }, {Blue})";
//     }
// }



// Point myFirstPoint = new(2, 3);
// Point mySecondPoint = new(-4, 0);

// Console.WriteLine($"({myFirstPoint.X}, {myFirstPoint.Y})");

// string printableFirst = myFirstPoint.Printable();
// string printableSecond = mySecondPoint.Printable();

// Console.WriteLine($"First point is at: {printableFirst}");
// Console.WriteLine($"Second point is at: {printableSecond}");

// public class Point
// {
//     public float X {get; }
//     public float Y {get; }

//     public Point()
//     {
//         X = 0;
//         Y = 0;
//     }

//     public Point(float x, float y)
//     {
//         X = x;
//         Y = y;
//     }

//     public string Printable()
//     {
//         return $"({X}, {Y})";
//     }

// }



// Console.WriteLine("Welcome to Vin's Arrow shop.");
// Console.WriteLine("What type of arrow would you like to create?");
// Console.WriteLine("Enter 1 for Elite Arrow");
// Console.WriteLine("Enter 2 for Beginner Arrow");
// Console.WriteLine("Enter 3 for Marksman Arrow");
// Console.WriteLine("Enter 4 for Custom Arrow\n");

// int arrowChoice = Convert.ToInt32(Console.ReadLine());
// Console.Clear();

// Arrow arrow = arrowChoice switch
// {
//     1 => Arrow.CreateEliteArrow(),
//     2 => Arrow.CreateBeginnerArrow(),
//     3 => Arrow.CreateMarksmanArrow(),
//     _ => CreateCustomArrow(),
// };

// Arrow CreateCustomArrow()
// {
//     Console.WriteLine("Let's build your arrow.");
//     ArrowHeadMaterial arrowhead = GetArrowHead();
//     FletchingType fletching = GetFletchingType();
//     Int32 length = GetLength();

//     return new Arrow(arrowhead, fletching, length);
// }


// ArrowHeadMaterial GetArrowHead()
// {
//     Console.WriteLine("What arrowhead material do you want to use?");
//     Console.WriteLine("Enter 1 for Steel");
//     Console.WriteLine("Enter 2 for Wood");
//     Console.WriteLine("Enter 3 for Obsidian\n");
//     int arrowheadChoice = Convert.ToInt32(Console.ReadLine());

//     return arrowheadChoice switch
//     {
//         1 => ArrowHeadMaterial.Steel,
//         2 => ArrowHeadMaterial.Wood,
//         3 => ArrowHeadMaterial.Obsidian,
//     };
// }

// FletchingType GetFletchingType()
// {
//     Console.WriteLine("What fletching material do you want to use?");
//     Console.WriteLine("Enter 1 for Plastic");
//     Console.WriteLine("Enter 2 for Goose Feathers");
//     Console.WriteLine("Enter 3 for Turkey Feathers\n");
//     int fletchingChoice = Convert.ToInt32(Console.ReadLine());

//     return fletchingChoice switch
//     {
//         1 => FletchingType.Plastic,
//         2 => FletchingType.GooseFeathers,
//         3 => FletchingType.TurkeyFeathers,
//     };
// }
 
// Int32 GetLength()
// {
//     int length = 0;
//     while (length <60 || length > 100)
//     {
//         Console.WriteLine("How long do you want your arrow?");
//         Console.WriteLine("Enter a value between 60 and 100:\n");
//         length = Convert.ToInt32(Console.ReadLine());
//     }
//     return length; 
// }

// public class Arrow
// {
//     public ArrowHeadMaterial ArrowHead {get;}
//     public FletchingType Fletching {get;}
//     public Int32 Length {get;}

//     public double Cost
//     {
//         get
//         {
//             double arrowheadCost = ArrowHead switch
//             {
//                 ArrowHeadMaterial.Steel => 10.0,
//                 ArrowHeadMaterial.Wood => 3.0,
//                 ArrowHeadMaterial.Obsidian => 5
//             };
            
//             double fletchingCost = Fletching switch
//             {
//                 FletchingType.Plastic => 10.0,
//                 FletchingType.GooseFeathers => 3.0,
//                 FletchingType.TurkeyFeathers => 5
//             };

//             double lengthCost = 0.05 * Length;

//             return arrowheadCost + fletchingCost + lengthCost;            
//         }
//     }

//     public Arrow(ArrowHeadMaterial arrowHead, FletchingType fletching, Int32 length)
//     {
//         ArrowHead = arrowHead;
//         Fletching = fletching;
//         Length = length;
//     }
//         public static Arrow CreateEliteArrow() => new Arrow(ArrowHeadMaterial.Steel, FletchingType.Plastic, 95);
//         public static Arrow CreateBeginnerArrow() => new Arrow(ArrowHeadMaterial.Wood, FletchingType.GooseFeathers, 75);
//         public static Arrow CreateMarksmanArrow() => new Arrow(ArrowHeadMaterial.Steel, FletchingType.GooseFeathers, 65);
// }
// public enum ArrowHeadMaterial
// {
//     Steel,
//     Wood,
//     Obsidian
// }

// public enum FletchingType
// {
//     Plastic,
//     TurkeyFeathers,
//     GooseFeathers
// }
// Arrow my_arrow = new();
// double my_arrow_cost = my_arrow.GetCost();
// Console.WriteLine($"Your arrow costs: {my_arrow_cost} gold.");

// class Arrow
// {
//     private ArrowHeadMaterial arrowhead;
//     private FletchingType fletching;
//     private Int32 arrowLength;

//     private double cost;

//     public Arrow()
//     {
//         Console.WriteLine("Let's make an arrow!");
//         Console.WriteLine("What material do you want for your arrowhead?");
//         Console.WriteLine("Enter 1 for Steel\nEnter 2 for Wood\nEnter 3 for Obsidian");
//         string? head_choice = Console.ReadLine();
//         if (head_choice == "1") this.arrowhead = ArrowHeadMaterial.Steel;
//         else if (head_choice == "2") this.arrowhead = ArrowHeadMaterial.Wood;
//         else this.arrowhead = ArrowHeadMaterial.Obsidian;

//         Console.WriteLine("What material do you want for your fletching?");
//         Console.WriteLine("Enter 1 for Plastic\nEnter 2 for Turkey Feathers\nEnter 3 for Goose Feathers");
//         string? fletching_choice = Console.ReadLine();
//         if (fletching_choice == "1") this.fletching = FletchingType.Plastic;
//         else if (fletching_choice == "2") this.fletching = FletchingType.TurkeyFeathers;
//         else this.fletching = FletchingType.GooseFeathers;

//         Console.WriteLine("How long do you want your arrow?\nEnter a length between 60 and 100:\n");
//         this.arrowLength = Convert.ToInt32(Console.ReadLine());

//         this.cost = 0.00;
//     }



//     public double GetCost()
//     {

//         if (this.arrowhead == ArrowHeadMaterial.Steel) this.cost += 10.0;
//         else if (this.arrowhead == ArrowHeadMaterial.Wood) this.cost += 3.0;
//         else this.cost += 5.0;

//         if (this.fletching == FletchingType.Plastic) cost += 10.0;
//         else if (this.fletching == FletchingType.TurkeyFeathers) cost += 5.0;
//         else this.cost += 3;

//         cost += 0.05 * this.arrowLength;

//         return this.cost;
//     }
    
// }




// (Seasoning, Ingredient, SoupType)[] soup = new (Seasoning, Ingredient, SoupType)[3];

// for (int counter = 0; counter < 3; counter++) soup[counter] = GetSoup();
// foreach ((Seasoning, Ingredient, SoupType) current_soup in soup) Console.WriteLine($"{current_soup.Item1} {current_soup.Item2} {current_soup.Item3}");

// (Seasoning, Ingredient, SoupType) GetSoup()
// {
//     Seasoning current_seasoning;
//     Ingredient current_ingredient;
//     SoupType current_soup_type;

//     Console.WriteLine("Do you want your soup:\n-1 for spicy,\n-2 for salty,\n-3 for sweet?");
//     string? seasoning = Console.ReadLine();
//     if (seasoning == "1") current_seasoning = Seasoning.Spicy;
//     else if (seasoning == "2") current_seasoning = Seasoning.Salty;
//     else current_seasoning = Seasoning.Sweet;
//     Console.Clear();

//     Console.WriteLine("What ingredient do you want for your soup:\n-1 for mushrooms,\n-2 for chicken,\n-3 for carrots,\n-4 for potatoes?");
//     string? ingredient = Console.ReadLine();
//     if (ingredient == "1") current_ingredient = Ingredient.Mushrooms;
//     else if (ingredient == "2") current_ingredient = Ingredient.Chicken;
//     else if (ingredient == "3") current_ingredient = Ingredient.Carrots;
//     else current_ingredient = Ingredient.Potatoes;
//     Console.Clear();

//     Console.WriteLine("What type of soup do you want:\n-1 for broth,\n-2 for stew,\n-3 for gumbo?");
//     string? soup_type = Console.ReadLine();
//     if (soup_type == "1") current_soup_type = SoupType.Broth;
//     else if (soup_type == "2") current_soup_type = SoupType.Stew;
//     else current_soup_type = SoupType.Gumbo;
//     Console.Clear();

//     return (current_seasoning, current_ingredient, current_soup_type);
// }


// enum SoupType
// {
//     Broth,
//     Stew,
//     Gumbo
// }

// enum Ingredient
// {
//     Mushrooms,
//     Chicken,
//     Carrots,
//     Potatoes
// }

// enum Seasoning
// {
//     Spicy,
//     Salty,
//     Sweet
// }

// ChestState current = ChestState.Locked;

// while (true)
// {
// 	ChestAction action = GetAction();
// 	current = Enact(action, current);
// }

// ChestAction GetAction()
// {
// 	Console.WriteLine($"The chest is {current}. What would you like to do?");
// 	string action = Console.ReadLine();

// 	if (action == "open") return ChestAction.Open;
// 	else if (action == "close") return ChestAction.Close;
// 	else if (action == "unlock") return ChestAction.Unlock;
// 	else if (action == "lock") return ChestAction.Lock;
// 	else
// 	{
// 		Console.WriteLine("Not a valid action.");
// 		return GetAction();
// 	}
// }

// ChestState Enact(ChestAction action, ChestState current)
// {
// 	if (action == ChestAction.Open && current == ChestState.Closed) return ChestState.Open;
// 	else if (action == ChestAction.Close && current == ChestState.Open) return ChestState.Closed;
// 	else if (action == ChestAction.Unlock && current == ChestState.Locked) return ChestState.Closed;
// 	else if (action == ChestAction.Lock && current == ChestState.Closed) return ChestState.Locked;
// 	else return current;
// }

// enum ChestState {
// 	Open,
// 	Closed,
// 	Locked
// }

// enum ChestAction {
// 	Close,
// 	Lock,
// 	Unlock,
// 	Open
// }







// int GetDistance()
// {
// 	Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore?");
// 	int distance = Convert.ToInt32(Console.ReadLine());
// 	Console.Clear();
// 	return distance;
// }

// void Player2Turn()
// {
// 	Console.WriteLine("Player 2, it is your turn.");
// }

// int cityHealth = 15;
// int manticoreHealth = 10;
// int round = 1;
// int distance = GetDistance();
// int damage = 0;

// Player2Turn();

// while (cityHealth > 0 && manticoreHealth > 0)
// {
// 	Console.ForegroundColor = ConsoleColor.White;
// 	Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
// 	if (round % 15 == 0) damage = 10;
// 	else if (round % 5 == 0 || round % 3 == 0 ) damage = 3;
// 	else damage = 1;
// 	Console.WriteLine($"The cannon is expected to do {damage} damage this round.");
// 	Console.WriteLine("Enter desired cannon range.");
// 	int range = Convert.ToInt32(Console.ReadLine());

// 	if (range == distance)
// 	{
// 		manticoreHealth -= damage;
// 		Console.ForegroundColor = ConsoleColor.Red;
// 		Console.WriteLine("That round was a DIRECT HIT!");
// 	}
// 	else if (range > distance)
// 	{
// 		cityHealth -=1;
// 		Console.ForegroundColor = ConsoleColor.Yellow;
// 		Console.WriteLine("That round OVERSHOT the target.");
// 	}
// 	else
// 	{
// 		cityHealth -=1;
// 		Console.ForegroundColor = ConsoleColor.DarkMagenta;
// 		Console.WriteLine("That round FELL SHORT of the target.");
// 	}
// 	round +=1;
// 	Console.WriteLine("Press enter to advance the round.");
// 	Console.ReadLine();
// 	Console.Clear();
// }

// if (manticoreHealth <= 0) Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
// else 
// 	Console.WriteLine("The city of Consolas has been Destroyed!");

// void RecursiveSubtractor(int value)
// {
//     Console.WriteLine(value);
//     value = value - 1;
//     if (value > 1) RecursiveSubtractor(value);
//     else Console.WriteLine(1);
// }

// RecursiveSubtractor(10);


// int result_1 = AskForNumber("How big is your penis?");
// int result_2 = AskForNumberInRange("Is your penis between Stephen and Brian's?", 2, 14);
// 
// Console.WriteLine(result_1);
// Console.WriteLine(result_2);
// 
// int AskForNumber(string text) 
// {
// Console.WriteLine($"{text}");
// int answer = Convert.ToInt32(Console.ReadLine());
// return answer;
// }
// 
// int AskForNumberInRange(string text, int min, int max)
// {
// while (true)
// {
// Console.WriteLine($"{text}");
// int answer = Convert.ToInt32(Console.ReadLine());
// if (answer > min && answer < max)
// {
// return answer;
// }
// else
// continue;
// }
// }





// int[] array = new int[] {4, 51, -7, 13, -99, 15, -8, 45, 90};
// int currentMinimum = int.MaxValue;
// int total = 0;


// foreach (int numb in array)
// 	if (numb < currentMinimum)
// 		currentMinimum = numb;

// foreach (int number in array)
// 	total += number;

// float average = (float)total / array.Length;

// Console.WriteLine($"The minimum value is: {currentMinimum}");
// Console.WriteLine($"The average value is: {average}");



// Console.Clear();
// int[] lotto = new int[5];

// for (int index = 0; index < lotto.Length; index++)
// {
// 	Console.WriteLine($"Enter number {index + 1}:");
// 	lotto[index] = Convert.ToInt32(Console.ReadLine());
// 	Console.Clear();
// }

// int[] lottery = new int[5];


// for (int index = 0; index < lottery.Length; index++)
// {
// 	lottery[index] = lotto[index];
// }

// Console.WriteLine($"Lotto equals: {String.Join(", ", lotto)}");
// Console.WriteLine($"Lottery equals: {String.Join(", ", lottery)}");


//for (int crank_number = 1; crank_number <= 100; crank_number++)
//{
//    if (crank_number % 3 == 0 && crank_number % 5 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine($"{crank_number}: Fire and Electric");
//    }
//    else if (crank_number % 3 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine($"{crank_number}: Fire");
//    }
//    else if (crank_number % 5 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine($"{crank_number}: Electric");
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.White;
//        Console.WriteLine($"{crank_number}:Normal");
//    }
//}
