using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon
{
    /// <summary>
    /// Настройки игры
    /// </summary>
    static public class Setting
    {
        public const float Height = 400;   // Высота посадки
        public const float Speed_f = 100f; // Скорость расхода топлива
        public const float Fuel = 200;     // Начальное кол-во топлива       
        public const float Speed = -5;     // Начальная скорость корабля
        public const float Moon_g = -200f;  // Ускорение свободного падения на Луне
        public const float Ship_g = 300f;   // Ускорение корабля
        public const float Speed_creat = - 70.0f; // Критическая скорость корабля для посадки
        public const float Height_creat = 500;  // Критическая высота корабля для улета

        // Начальные положения и пропорции для спрайтов
        #region

        // Луна
        public const int moonX = 0;
        public const int moonY = 450;
        public const float moonZoom = 1.0f;

        // Земля
        public const int earthX = 350;
        public const int earthY = 200;
        public const float earthZoom = 0.3f;

        // Корабль
        public const int shipX = 120;
        public const int shipY = -100;
        public const float shipZoom = 1.0f;

        // Огонь
        public const int fireX = 110;
        public const int fireY = 80;
        public const float fireZoom = 1.0f;

        #endregion






    }
}
