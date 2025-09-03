using System;
using SplashKitSDK;

namespace OuroborosAdventure
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Ouroboros Adventure", 1536, 920);
            DrawGameState drawGameState = new DrawGameState();
            //GameManager gameManager = new GameManager();
            //gameManager.SetUp();
            while (!window.CloseRequested) // Fix: Access CloseRequested as a property, not a method  
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                drawGameState.Draw();
                drawGameState.UpdateGameState();
                //gameManager.Update();
                //gameManager.Draw();
                SplashKit.RefreshScreen(60);
                SplashKit.Delay(1000 / 60); // Ensure 60 FPS  
            }
        }
    }
}
