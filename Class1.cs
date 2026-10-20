using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TermninalApp
{
    public class Menud
    {
        public void Play()
        {/*
int seed = 1156445;dsds dfsdfsd sdfdsfs dsfsdfds consoels asdas


int windows_height = Console.WindowHeight;
int windows_width = Console.WindowWidth;

uint tile_ranodm = 1;
string earth_symbol = "█";

//earth
(int X_start, int Y_start, int X_end, int Y_end)[] earth = new (int, int, int, int)[1];
earth[0] = (0, (int)(windows_height * 0.9), windows_width - 1, windows_height - 1);


Action <int, int> random = (x,y) => 
{   //random gererator with Bit mixer and XOR

    tile_ranodm = ((uint)x * 732444753U);
    tile_ranodm = ((uint)x * 732444753U);
    tile_ranodm ^= ((uint)y * 227651033U);
    tile_ranodm ^= ((uint)seed * 105655039U);

    tile_ranodm = (tile_ranodm ^ (tile_ranodm >> 16)) * 2246822507U;
    tile_ranodm = (tile_ranodm ^ (tile_ranodm >> 13)) * 3266489909U;
    tile_ranodm = (tile_ranodm ^ (tile_ranodm >> 16));

    
};

Action ground = () =>
{
    for (int i = earth[0].X_start; i <= earth[0].X_end; i++)
    {
        for (int y = earth[0].Y_start; y <= earth[0].Y_end; y++)
        {         
            random(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top);
            tile_ranodm = tile_ranodm % 4;
            
            switch (tile_ranodm)
            {
                case 0: earth_symbol = "█"; break;
                case 1: earth_symbol = "▓"; break;
                case 2: earth_symbol = "▒"; break;
                case 3: earth_symbol = "░"; break;
            }

            Console.SetCursorPosition(i, y);
            Console.Write(earth_symbol);
            
        }
    }
};
ground();


Console.ReadLine();*/
        }
    }
}