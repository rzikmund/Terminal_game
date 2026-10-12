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
string ground_symbol = "█";

//ground
(int X_start, int Y_start, int X_end, int Y_end)[] ground = new (int, int, int, int)[1];
ground[0] = (0, (int)(windows_height * 0.9), windows_width-1, windows_height-1);



//----code----//
for (int i = ground[0].X_start; i <= ground[0].X_end; i++)
{
    for (int y = ground[0].Y_start; y <= ground[0].Y_end; y++)
    {   
        int random_symbol = random.Next(1,5);
        switch (random_symbol)
        {
            case 1:
                ground_symbol = "█";
                break; 
            case 2:
                ground_symbol = "▓";
                break; 
            case 3:
                ground_symbol = "▒";
                break;
            case 4:
                ground_symbol = "░";
                break;
        }

        Console.SetCursorPosition(i, y);
        Console.Write(ground_symbol);
        Console.SetCursorPosition(i, y);
        Console.Write(ground_symbol);
    }   

}

