using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Console.CursorVisible = false;

//----VARIABLES----//
//main
int window_height = Console.WindowHeight;
int window_wide = Console.WindowWidth;

//line for border
string up_line = "│";
string line = "─";

string left_up_corner = "┌";
string left_down_corner = "└";
string right_up_corner = "┐";
string right_down_corner = "┘";

//text for settings
string config_1 = "1. General";
string config_2 = "2. Appearance";
string config_3 = "3. Advanced";




//----CODE----//

//generating lying lines
for (int i = 1; i < window_wide-1; i++)
{
    Console.SetCursorPosition(i, 0);
    Console.Write(line);
    Console.SetCursorPosition(i, window_height-1);
    Console.Write(line);
}

//generating up lines
for (int i = 1; i < window_height - 1; i++)
{
    Console.SetCursorPosition(0, i);
    Console.Write(up_line);
    Console.SetCursorPosition(window_wide-1, i);
    Console.Write(up_line);
}

//generating corners
Console.SetCursorPosition(0, 0);
Console.Write(left_up_corner);
Console.SetCursorPosition(0, window_height-1);
Console.Write(left_down_corner);
Console.SetCursorPosition(window_wide-1, 0);
Console.Write(right_up_corner);
Console.SetCursorPosition(window_wide - 1, window_height - 1);
Console.Write(right_down_corner);