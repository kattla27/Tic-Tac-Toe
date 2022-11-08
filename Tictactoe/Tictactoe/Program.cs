using System;
public static class Tictactoe
{
   
            public static bool Spelarensrunda = true;
            public static Board board;
            public static int antaletrundor = 0;
            static void Main()
            {
                while (true)
                {
                    ResetBoard();
                    PlayGame();
                } 
                void ResetBoard()
                {
                    board = new Board();
                    antaletrundor=0;
                    board.Showboard();
                }
                void PlayGame()
                {
                    while (true)
                    {
                        board.VäljSpace();
                        board.Showboard();
                        if (Letareftervinnare())
                            break;
                        Spelarensrunda = !Spelarensrunda;
                        antaletrundor++;
                        if(antaletrundor >= 9)
                        {
                            Console.WriteLine("GG, ni suger");
                            break; 
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("F in the chat, I mean Press F to Play again");
                    Console.ReadKey(true);
                    }
                }
                    
            static bool Letareftervinnare()
            {
                if (Horisontell() || Vertical() || Diagonal())
                    return true;
                else return false;
                bool Horisontell()
                {
                    for (int i = 0; i < board.Rader.Length; ++i)
                    {
                        bool HarVunnit = false;
                        bool X = true;
                        int[] spaces = board.Rader[i].spaces;
                        int KollaHorisontell = spaces[0];
                        switch (KollaHorisontell)
                        {
                            case 0:
                                continue;
                            case 1:
                                X = true;
                                break;
                            case 2:
                                X = false;
                                break;

                        }
                        for (int j = 0; j < spaces.Length; ++j)
                        {
                            if (spaces[j] != KollaHorisontell)
                            {
                                HarVunnit= false;
                                break;
                            }
                            if (HarVunnit)
                            {
                                Belöning(X);
                                return true;
                            }
                        }
                       
                    }
                    return false;
                }
                bool Vertical()
                {
                    bool harVunnit = true;
                    bool X = false;
                    int[] spaces = board.Rader[0].spaces;
                    for (int i = 0; i < 3; ++i) 
                    {
                        harVunnit = true;
                        int kollaVertical = spaces[i];
                        switch (kollaVertical)
                        {
                            case 0:
                                continue;
                            case 1:
                                X = true;
                                break;
                            case 2:
                                X = false;
                                break;

                        }
                        for(int j = 0; j < 3; ++j)
                        {
                            if (board.Rader[j].spaces[i] != kollaVertical)
                            {
                                harVunnit = false;
                                break;
                            }
                        }
                        if (harVunnit)
                        {
                            Belöning(X);
                            return true;
                        }
                    }
                    return false;
                }
                bool Diagonal()
                {
                bool HarVunnit = true;
                bool X = false;
                int firstplace = board.Rader[0].spaces[0];
                    switch (firstplace)
                    {
                        case 0:
                            HarVunnit = false;
                            break;
                        case 1:
                            X=true;
                            break;
                        case 2:
                            X=false;
                            break;

                    }
                    for(int i = 0; i < 3; ++i)
                    {
                        if(board.Rader[i].spaces[i] != firstplace)
                        {
                            HarVunnit = false;
                            break;
                        }
                    }
                    if (HarVunnit)
                    {
                        Belöning(X);
                        return true;
                    }
                HarVunnit = true;
                int SistaSpace = board.Rader[0].spaces[2];
                    switch (SistaSpace)
                    {
                        case 0:
                            HarVunnit = false;
                            break;
                        case 1:
                            X=true;
                            break;
                        case 2:
                            X = false;
                            break;
                    }
                    for(int i = 0; i < 3; i++)
                    {
                        if(board.Rader[i].spaces[2-i] != SistaSpace)
                        {
                            HarVunnit=false;
                            break;
                        }
                    }
                    if (HarVunnit)
                    {
                        Belöning(X);
                        return true;
                    }
                    return false;
                }
                    void Belöning(bool X)
                    {
                    string vinnaren = "";
                    if (X)
                        vinnaren = "you cunt how could you lose to a stick";
                    else
                        vinnaren = "You cunt how could you lose to a fat O";
                    Console.WriteLine(vinnaren);
                     }
            }
}
                
     
public class Board
        {
             public Rad[] Rader;
            public Board()
            {
                Rader = new Rad[3];
                for (int i = 0; i < 3; ++i)
                Rader[i] = new Rad();
            }   
            public void Showboard()
            {   

                for (int i = 0; i < Rader.Length; ++i)
                Rader[i].Linjer();
            }
        public void VäljSpace()
        {
            string input = "";
            int RadNumber = 0;
            Console.WriteLine("Välj rad mellan från toppen till botten( 1,2 eller 3)");
            input = Console.ReadLine();
            if (int.TryParse(input, out RadNumber))
            {
                if (RadNumber > 3 || RadNumber < 1)
                {
                    Console.WriteLine("KAN DU LÄSA? Försök igen");
                    VäljSpace();
                    return;
                }
                Rader[RadNumber - 1].väljplats(Tictactoe.Spelarensrunda);
            }
            else
            {
                Console.WriteLine("KAN DU LÄSA? Försök igen");
                VäljSpace();
                return;
            }
        }
}
public class Rad
{
     public int[] spaces; 
     public void väljplats(bool X)
    {
        string input;
        int spaceNumber;
        Console.WriteLine("Välj en ruta ifrån höger till vänster (1,2,3)");
        input = Console.ReadLine();
        if(int.TryParse(input, out spaceNumber))
        {
            if (spaceNumber > 3 || spaceNumber < 1)
            {
                Console.WriteLine("KAN DU LÄSA? Försök igen");
                väljplats(X);
                return;
            }
            if(spaces[spaceNumber - 1] != 0)
            {
                Console.WriteLine("Oj någon har redan occoperat den rutan som isfake occoperar de palestinska folket :))))");
                Tictactoe.board.VäljSpace();
                return;
            }
            if (X)
                spaces[spaceNumber - 1] = 1;
            else
                spaces[spaceNumber - 1] = 2;
        }
        else
        {
            Console.WriteLine("KAN DU LÄSA? Försök igen");
            väljplats(X);
        }
    }   
    
    public void Linjer()
    {
        string rutor = "";
        for(int i = 0; i < spaces.Length; i++)
        {

        
        if (spaces[i] == 0)
            rutor += "|   |";
        else if (spaces[i] == 1)
            rutor += "| X |";
        else if (spaces[i] == 2)
            rutor += "| O |";
        }
        Console.WriteLine(rutor);
    }
    public Rad()
    {
        spaces = new int[3];
    }
    
}
        
        
    

