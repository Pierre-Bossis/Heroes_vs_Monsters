using Heroes_Vs_Monsters.Models;

Console.CursorVisible = false;

Humain humain = new(); Orque orque = new(); Loup loup = new(); Dragonnet dragonnet = new();
Queue<Monstre> Ennemis = new();

bool InBattle = false; bool IsAlive = true;

string[,] BoardGame = new string[15, 15];

//remplir le tableau
for (int i = 0; i < BoardGame.GetLength(0); i++)
{
    for (int j = 0; j < BoardGame.GetLength(1); j++)
    {
        BoardGame[i, j] = "[ ]";
    }
}

//ajouter monstres a la liste de monstre
Ennemis.Enqueue(orque);
Ennemis.Enqueue(loup);
Ennemis.Enqueue(dragonnet);

//positioner le personnage et l'ennemi ( pas sur la meme case que le héro )
BoardGame[humain.Y, humain.X] = "[H]";
BoardGame[Ennemis.FirstOrDefault().Y, Ennemis.FirstOrDefault().X] = "[X]";
while (humain.Y == Ennemis.FirstOrDefault().Y && humain.X == Ennemis.FirstOrDefault().X)
{
    Ennemis.FirstOrDefault().X = De.DeStart();
    Ennemis.FirstOrDefault().Y = De.DeStart();
}







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
while (Ennemis.Count > 0)
{
    BoardGame[Ennemis.FirstOrDefault().Y, Ennemis.FirstOrDefault().X] = "[X]";
    while (humain.Y == Ennemis.FirstOrDefault().Y && humain.X == Ennemis.FirstOrDefault().X)
    {
        Ennemis.FirstOrDefault().X = De.DeStart();
        Ennemis.FirstOrDefault().Y = De.DeStart();
    }

    var input = Console.ReadKey();
    switch (input.Key)
    {
        case ConsoleKey.UpArrow:
            if (humain.Y > 0 && (Ennemis.FirstOrDefault().Y != humain.Y - 1 || Ennemis.FirstOrDefault().X != humain.X))
            {
                BoardGame[humain.Y, humain.X] = "[ ]";
                humain.Y -= 1;
            }
            break;
        case ConsoleKey.DownArrow:
            if (humain.Y < 14 && (Ennemis.FirstOrDefault().Y != humain.Y + 1 || Ennemis.FirstOrDefault().X != humain.X))
            {
                BoardGame[humain.Y, humain.X] = "[ ]";
                humain.Y += 1;
            }
            break;
        case ConsoleKey.LeftArrow:
            if (humain.X > 0 && (Ennemis.FirstOrDefault().X != humain.X - 1 || Ennemis.FirstOrDefault().Y != humain.Y))
            {
                BoardGame[humain.Y, humain.X] = "[ ]";
                humain.X -= 1;
            }
            break;
        case ConsoleKey.RightArrow:
            if (humain.X < 14 && (Ennemis.FirstOrDefault().X != humain.X + 1 || Ennemis.FirstOrDefault().Y != humain.Y))
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

    if (humain.X == Ennemis.FirstOrDefault().X && (humain.Y == Ennemis.FirstOrDefault().Y + 1 || humain.Y == Ennemis.FirstOrDefault().Y - 1) || humain.Y == Ennemis.FirstOrDefault().Y && (humain.X == Ennemis.FirstOrDefault().X + 1 || humain.X == Ennemis.FirstOrDefault().X - 1)
        || humain.X + 1 == Ennemis.FirstOrDefault().X && (humain.Y == Ennemis.FirstOrDefault().Y + 1 || humain.Y == Ennemis.FirstOrDefault().Y - 1) || humain.Y + 1 == Ennemis.FirstOrDefault().Y && (humain.X == Ennemis.FirstOrDefault().X + 1 || humain.X == Ennemis.FirstOrDefault().X - 1) || (humain.Y == Ennemis.FirstOrDefault().Y + 1 && humain.X == Ennemis.FirstOrDefault().X + 1))
    {
        InBattle = true;
        while (InBattle)
        {
            Console.WriteLine($"HP {Ennemis.FirstOrDefault().GetType().Name} :   {Ennemis.FirstOrDefault().HP} |  HP {humain.GetType().Name} : {humain.HP}");
            humain.Frappe(Ennemis.FirstOrDefault());
            if (Ennemis.FirstOrDefault().HP <= 0)
            {
                InBattle = false;
                Console.WriteLine($"{Ennemis.FirstOrDefault().GetType().Name} est mort. HP {humain.GetType().Name} restants : {humain.HP}");
                BoardGame[Ennemis.FirstOrDefault().Y, Ennemis.FirstOrDefault().X] = "[ ]";
                Ennemis.Dequeue();
                humain.SeReposer();
                break;

            }
            Ennemis.FirstOrDefault().Frappe(humain);
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
if (!IsAlive)
{
    Console.WriteLine("Perdu");
}
else
{
    Console.WriteLine("Bravo !!");
}
