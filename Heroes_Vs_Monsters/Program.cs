using Heroes_Vs_Monsters.Models;

Console.CursorVisible = false;

Humain humain = new();
Orque orque = new();
bool InBattle = false;
bool IsAlive = true;
string[,] BoardGame = new string[15, 15];

//remplir le tableau
for (int i = 0; i < BoardGame.GetLength(0); i++)
{
    for (int j = 0; j < BoardGame.GetLength(1); j++)
    {
        BoardGame[i, j] = "[ ]";
    }
}

//positioner le personnage
BoardGame[humain.Y, humain.X] = "[H]";
BoardGame[orque.Y, orque.X] = "[X]";

//afficher le tableau
for (int i = 0; i < BoardGame.GetLength(0); i++)
{
    for (int j = 0; j < BoardGame.GetLength(1); j++)
    {
        Console.Write(BoardGame[i, j]);
    }
    Console.WriteLine();
}

Console.SetCursorPosition(15, 15);


//déplacer le personnage
//Console.WriteLine($"HP du personnage : {humain.HP}");
while (true)
{
    var input = Console.ReadKey();
    switch (input.Key)
    {
        case ConsoleKey.UpArrow:
            if (humain.Y > 0 && (orque?.Y != humain.Y - 1 || orque?.X != humain.X))
            {
                BoardGame[humain.Y, humain.X] = "[ ]";
                humain.Y -= 1;
            }
            break;
        case ConsoleKey.DownArrow:
            if (humain.Y < 14 && (orque?.Y != humain.Y + 1 || orque?.X != humain.X))
            {
                BoardGame[humain.Y, humain.X] = "[ ]";
                humain.Y += 1;
            }
            break;
        case ConsoleKey.LeftArrow:
            if (humain.X > 0 && (orque?.X != humain.X - 1 || orque?.Y != humain.Y))
            {
                BoardGame[humain.Y, humain.X] = "[ ]";
                humain.X -= 1;
            }
            break;
        case ConsoleKey.RightArrow:
            if (humain.X < 14 && (orque?.X != humain.X + 1 || orque?.Y != humain.Y))
            {
                BoardGame[humain.Y, humain.X] = "[ ]";
                humain.X += 1;
            }
            break;
        default:
            break;
    }

    Console.Clear();
    BoardGame[humain.Y, humain.X] = "[H]";
    for (int i = 0; i < BoardGame.GetLength(0); i++)
    {
        for (int j = 0; j < BoardGame.GetLength(1); j++)
        {
            Console.Write(BoardGame[i, j]);
        }
        Console.WriteLine();
    }
    //Console.WriteLine($"HP du personnage : {humain.HP}");

    if (humain.X == orque?.X && (humain.Y == orque?.Y + 1 || humain.Y == orque?.Y - 1) || humain.Y == orque?.Y && (humain.X == orque?.X + 1 || humain.X == orque?.X - 1)
        || humain.X + 1 == orque?.X && (humain.Y == orque?.Y + 1 || humain.Y == orque?.Y - 1) || humain.Y + 1 == orque?.Y && (humain.X == orque?.X + 1 || humain.X == orque?.X - 1) || (humain.Y == orque?.Y + 1 && humain.X == orque?.X + 1))
    {
        InBattle = true;
        while (InBattle)
        {
            Console.WriteLine($"HP {orque.GetType().Name} :   {orque.HP} |  HP {humain.GetType().Name} : {humain.HP}");
            humain.Frappe(orque);
            if (orque.HP <= 0)
            {
                InBattle = false;
                Console.WriteLine($"{orque.GetType().Name} est mort. HP {humain.GetType().Name} restants : {humain.HP}");
                BoardGame[orque.Y, orque.X] = "[ ]";
                orque = null;
                humain.SeReposer();
                break;

            }
            orque.Frappe(humain);
            if (humain.HP <= 0)
            {
                InBattle = false;
                Console.WriteLine($"{humain.GetType().Name} est mort.");
                IsAlive = false;
                break;
            }
        }
    }

    if (!IsAlive) break;


}

Console.WriteLine("Perdu");