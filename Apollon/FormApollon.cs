using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apollon
{
    public partial class FormApollon : Form
    {
        Game game;

        public FormApollon()
        {
            InitializeComponent();

            game = new Game(picture.Width, picture.Height);

        }
        
        void timer_Tick(object sender, EventArgs e)
        {
            switch (game.Status)
            {
                case GameStatus.Wait:
                    break;
                case GameStatus.EngineOn:
                    game.EngineOn((float)timer.Interval);
                    labelEngine.Text = game.GetFuelOfShip;
                    break;
                case GameStatus.EngineOff:
                    game.EngineOff((float)timer.Interval);
                    break;
                case GameStatus.Landing:
                    ShowLending();
                    break;
                case GameStatus.Crash:
                    ShowCrash();
                    break;
                case GameStatus.Flyout:
                    ShowFlyout();
                    break;
            }

            picture.Image = game.Refresh();
        }

        private void ShowFlyout()
        {
            labelMessage.Visible = true;
            labelMessage.Text = "Корабль улетел!";
            game.Stop();
        }

        private void ShowCrash()
        {
            labelMessage.Visible = true;
            labelMessage.Text = "Корабль разбился!";
            game.Stop();
        }

        private void ShowLending()
        {
            labelMessage.Visible = true;
            labelMessage.Text = "Прилунение выполнено успешно!";
            game.Stop();
        }

        private void labelEngine_MouseDown(object sender, MouseEventArgs e)
        {
            if (game.Status == GameStatus.Wait) return;

            labelEngine.BackColor = Color.DarkRed;
            game.Status = GameStatus.EngineOn;
        }

        private void labelEngine_MouseUp(object sender, MouseEventArgs e)
        {
            if (game.Status == GameStatus.Wait) return;

            labelEngine.BackColor = Color.Red;
            game.Status = GameStatus.EngineOff;
        }

        private void labelMessage_Click(object sender, EventArgs e)
        {
            switch(game.Status)
            {
                case GameStatus.Wait:
                    labelMessage.Visible = false;
                    game.Start();
                    labelEngine.Text = game.GetFuelOfShip;
                    timer.Start();
                    break;
                case GameStatus.Crash:
                    timer.Stop();
                    break;
                case GameStatus.Flyout:
                    timer.Stop();
                    break;
            }
            
        }
    }
}
