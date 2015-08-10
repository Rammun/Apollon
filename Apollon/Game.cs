using DataSprite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon
{
    /// <summary>
    /// Реализует свойства и методы (правила) игры
    /// </summary>
    public enum GameStatus
    {
        Wait, EngineOn, EngineOff, Landing, Crash, Flyout
    }

    public class Game
    {
        Ship ship;        // Наш корабль
        Sprites sprites;  // Наши спрайты

        public GameStatus Status { get; set; } // Статус игры (ожидание, игра, приземлился, разбился, улетел)
        public Ship Ship { get { return ship; } }

        public Game(int width, int height)
        {
            sprites = new Sprites(width, height);
        }

        public string  GetFuelOfShip { get { return ((int)ship.Fuel).ToString(); } }

        public void Start()
        {
            ship = new Ship();
            Status = GameStatus.EngineOff;
            ShowAllSprites();
        }

        private void ShowAllSprites()
        {
            sprites.Show("moon", 0, 450, 1.0f);
            sprites.Show("earth", 350, 200, 0.3f);

            sprites.Show("star", 50, 50, 0.25f);
            sprites.Show("star", 300, 70, 0.2f);
            sprites.Show("star", 20, 200, 0.35f);
            sprites.Show("star", 350, 320, 0.15f);
        }

        public void Stop()
        {
            Status = GameStatus.Wait;
        }
        
        public void EngineOn(float timer)
        {
            ship.PowerOn();
            ship.MoveShip((timer / 1000));

            sprites.Clear();
            ShowAllSprites();
            sprites.Show("ship", Setting.shipX, Setting.shipY + (int)(Setting.Height - ship.Height), Setting.shipZoom);
            sprites.Show("fire", Setting.fireX, Setting.fireY + (int)(Setting.Height - ship.Height), Setting.fireZoom);

            EndOrPlay();
        }

        public void EngineOff(float timer)
        {
            ship.PowerOff();
            ship.MoveShip((timer / 1000));

            sprites.Clear();
            ShowAllSprites();
            sprites.Show("ship", Setting.shipX, Setting.shipY + (int)(Setting.Height - ship.Height), Setting.shipZoom);

            EndOrPlay();
        }

        private void EndOrPlay()
        {
            if (ship.Height > Setting.Height_creat)
                Status = GameStatus.Flyout;

            if (ship.Height <= 0)
                Status = ship.Speed > Setting.Speed_creat ? GameStatus.Landing : GameStatus.Crash;
        }

        public Image Refresh()
        {
            //ShowAllSprites();
            return sprites.GetBitmap;
        }
    }
}
