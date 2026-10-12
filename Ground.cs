using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//----variables----//
Console.CursorVisible = false;

int windows_height = Console.WindowHeight;
int windows_width = Console.WindowWidth;

Random random = new Random();
string earth_symbol = "█";

//earth
(int X_start, int Y_start, int X_end, int Y_end)[] earth = new (int, int, int, int)[1];
earth[0] = (0, (int)(windows_height * 0.9), windows_width-1, windows_height-1);

//plants
int grass_chance = 25;
string grass = "|";

//stars
int star_chance = 3;
string star_symbol = "*";
(int X_start, int Y_start, int X_end, int Y_end)[] star = new (int, int, int, int)[1];
star[0] = (0, 0, windows_width - 1, (int)(windows_height * 0.2));

//----code----//
Action ground = () =>
{
    for (int i = earth[0].X_start; i <= earth[0].X_end; i++)
    {
        for (int y = earth[0].Y_start; y <= earth[0].Y_end; y++)
        {
            int random_symbol = random.Next(1, 5);
            switch (random_symbol)
            {
                case 1:
                    earth_symbol = "█";
                    break;
                case 2:
                    earth_symbol = "▓";
                    break;
                case 3:
                    earth_symbol = "▒";
                    break;
                case 4:
                    earth_symbol = "░";
                    break;
            }

            Console.SetCursorPosition(i, y);
            Console.Write(earth_symbol);
            Console.SetCursorPosition(i, y);
            Console.Write(earth_symbol);
        }

    }

    for (int i = 0; i <= windows_width - 1; i++)
    {
        int random_grass = random.Next(1, 101);
        Console.SetCursorPosition(i, earth[0].Y_start - 1);
        if (random_grass <= grass_chance)
        {
            Console.Write(grass);
        }
    }

};

ground();

for (int i = star[0].X_start; i <= star[0].X_end; i++)
{
    for (int y = star[0].Y_start; y <= star[0].Y_end; y++)
    {
        int random_star = random.Next(1, 101);
        Console.SetCursorPosition(i, y);
        if (random_star <= star_chance)
        {
            Console.Write(star_symbol);
        }
    }
}

Console.ReadLine();
