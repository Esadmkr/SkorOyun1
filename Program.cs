class Player
{
    public string oyuncusembol = "@";
    public int x = 10, y = 10; 
    public int oyuncuskoru = 0;
    public int zaman = 120;

    
    public void LogYaz(string islem, string detay)
    {
        string logSatiri = $"{islem} → {detay}";
        File.AppendAllText("game_log.txt", logSatiri + Environment.NewLine);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player p1 = new Player();
        int itemX = new Random().Next(0, 30), itemY = 0;
        
        
        while (p1.zaman > 0 && p1.oyuncuskoru < 10)
        {
            itemY++; 
p1.LogYaz("UPDATE", $"itemMoved x={itemX} y={itemY}");
            Console.Clear(); 
Console.SetCursorPosition(p1.x, p1.y); 
Console.Write(p1.oyuncusembol); 
            
            if (Console.KeyAvailable) 
            {
                var tus = Console.ReadKey(true).Key;
                p1.LogYaz("INPUT", $"key={tus} x={p1.x} y={p1.y}");
                if (tus == ConsoleKey.LeftArrow) p1.x--;
if (tus == ConsoleKey.RightArrow) p1.x++;
if (tus == ConsoleKey.UpArrow) p1.y--;
if (tus == ConsoleKey.DownArrow) p1.y++;
                
            }
                    if (p1.x == itemX && p1.y == itemY)
{
    p1.oyuncuskoru++;
    p1.LogYaz("COLLISION", $"score={p1.oyuncuskoru}");
    itemY = 0; 
    itemX = new Random().Next(0, Console.WindowWidth - 1);
}
Console.SetCursorPosition(itemX, itemY);
Console.Write("*");
if (itemY >= Console.WindowHeight - 1) 
{ 
    itemY = 0; 
    itemX = new Random().Next(0, 30); 
}

        p1.zaman--;
            
            
            Thread.Sleep(100); 
            
        }
        p1.LogYaz("GAME_OVER", $"score={p1.oyuncuskoru}");

    }
}
