
var myGame = new Game();
myGame.Run();


public class Game
{
    private bool isRunning;
    private int playerX;
    private int playerY;

    public RenderGame render;

    public Game()
    {
        isRunning = true;
        playerX = 0;
        playerY = 0;
        render = new RenderGame(); // or using dependency injection
    }

    public void Run()
    {
        while (isRunning)
        {
            // Game logic
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            HandleInput(keyInfo);
            Update();
            render.Render(playerX, playerY);
        }
    }

    private void HandleInput(ConsoleKeyInfo keyInfo)
    {
        // Handle user input to move the player
        if (keyInfo.Key == ConsoleKey.LeftArrow)
            playerX--;
        else if (keyInfo.Key == ConsoleKey.RightArrow)
            playerX++;
        else if (keyInfo.Key == ConsoleKey.UpArrow)
            playerY--;
        else if (keyInfo.Key == ConsoleKey.DownArrow)
            playerY++;
        else if (keyInfo.Key == ConsoleKey.Escape)
            isRunning = false;
    }

    private void Update()
    {
        // Update game state
    }
}

public class RenderGame 
{
    public void Render(int playerX, int playerY)
    {
        // Render the game, including the player's position
        Console.Clear();
        Console.SetCursorPosition(playerX, playerY);
        Console.Write("*");
    }
}