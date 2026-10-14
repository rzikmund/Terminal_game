using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

int seed = 1156445;


int windows_height = Console.WindowHeight;
int windows_width = Console.WindowWidth;

Random random = new Random();
string earth_symbol = "█";

//earth
(int X_start, int Y_start, int X_end, int Y_end)[] earth = new (int, int, int, int)[1];
earth[0] = (0, (int)(windows_height * 0.9), windows_width - 1, windows_height - 1);

Action ground = () =>
{
    for (int i = earth[0].X_start; i <= earth[0].X_end; i++)
    {
        for (int y = earth[0].Y_start; y <= earth[0].Y_end; y++)
        {
            int random_symbol = Console.GetCursorPosition().Left + Console.GetCursorPosition().Top;
            
            if (Math.Abs(((random_symbol + seed) % 4) +1) == 1)
            {
                random_symbol = 1;
            }

            if (Math.Abs(((random_symbol + seed) % 4) + 1) == 2)
            {
                random_symbol = 2;
            }

            if (Math.Abs(((random_symbol + seed) % 4) + 1) == 3)
            {
                random_symbol = 3;
            }

            if (Math.Abs(((random_symbol + seed) % 4) + 1) == 4)
            {
                random_symbol = 4;
            }

            switch (random_symbol)
            {
                case 1: earth_symbol = "█"; break;
                case 2: earth_symbol = "▓"; break;
                case 3: earth_symbol = "▒"; break;
                case 4: earth_symbol = "░"; break;
            }

            Console.SetCursorPosition(i, y);
            Console.Write(earth_symbol);            
        }
    }
};
ground();

 
