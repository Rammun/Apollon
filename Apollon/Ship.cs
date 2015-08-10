using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon
{    
    /// <summary>
    /// Оисывает корабль
    /// </summary>
    public class Ship
    {
        float height = Setting.Height;
        float fuel = Setting.Fuel;
        float speed = Setting.Speed;
        bool power = false;

        public Ship()
        {
        }

        public float Height { get { return height; } }  // Текущая высота корабля
        public float Fuel { get { return fuel; } }      // Текущее кол-во топлива
        public float Speed { get { return speed; } }    // Текущая скорость корабля        
        public bool Power { get { return power; } }     // Текущее состояние двигателя

        // Включить двигатель
        public void PowerOn()
        {
            if (fuel > 0) power = true;            
        }

        // Выключить двигатель
        public void PowerOff()
        {
            power = false;
        }

        /// <summary>
        /// Вычисляет высоту корабля
        /// </summary>
        /// <param name="s">секунды</param>
        /// <returns>высота</returns>
        public void MoveShip(float s)
        {
            if(power)  // Если двигатель включен
            {
                speed += s * Setting.Ship_g;
                fuel -= Setting.Speed_f * s;

                if(fuel < 0)
                {
                    fuel = 0;
                    power = false;
                }
            }                
            else      // Если двигатель выключен
            {
                speed += s * Setting.Moon_g;
            }                

            height += s * speed;   // Считаем высоту
        }
    }  
}
