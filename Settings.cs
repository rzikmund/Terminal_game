using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Console.CursorVisible = false;

//----VARIABLES----//
//main
int window_height = Console.WindowHeight;
int window_width = Console.WindowWidth;

//line for border
string up_line = "│";
string line = "─";

string left_up_corner = "┌";
string left_down_corner = "└";
string right_up_corner = "┐";
string right_down_corner = "┘";

//text for settings
string head_text = " SETTINGS ";

string config_1 = "1. General";
string config_2 = "2. Appearance";
string config_3 = "3. Advanced";
string config_4 = "4. About the application";
string config_5 = "5. Back";

//location of config
(int X, int Y)[] config_menu_location = new (int, int)[1];
config_menu_location[0] = ((int)(window_width * 0.05), (int)(window_height * 0.15));



//----CODE----//

//generating lying lines
for (int i = 1; i < window_width-1; i++)
{
    Console.SetCursorPosition(i, 0);
    Console.Write(line);
    Console.SetCursorPosition(i, window_height-1);
    Console.Write(line);

    //dividing line
    Console.SetCursorPosition(i, (int)(window_height*0.90));
    Console.Write(line);
}

//generating up lines
for (int i = 1; i < window_height - 1; i++)
{
    Console.SetCursorPosition(0, i);
    Console.Write(up_line);
    Console.SetCursorPosition(window_width-1, i);
    Console.Write(up_line);
}

//generating corners
Console.SetCursorPosition(0, 0);
Console.Write(left_up_corner);
Console.SetCursorPosition(0, window_height-1);
Console.Write(left_down_corner);
Console.SetCursorPosition(window_width-1, 0);
Console.Write(right_up_corner);
Console.SetCursorPosition(window_width - 1, window_height - 1);
Console.Write(right_down_corner);

//placing head text
Console.SetCursorPosition((int)(window_width / 2) - (head_text.Length), 0);
Console.Write(head_text);

//placing config text
Console.SetCursorPosition (config_menu_location[0].X, config_menu_location[0].Y);
Console.Write(config_1);
Console.SetCursorPosition(config_menu_location[0].X, (int)(config_menu_location[0].Y*1.5));
Console.Write(config_2);
Console.SetCursorPosition(config_menu_location[0].X, (int)(config_menu_location[0].Y * 2));
Console.Write(config_3);
Console.SetCursorPosition(config_menu_location[0].X, (int)(config_menu_location[0].Y * 2.5));
Console.Write(config_4);
Console.SetCursorPosition(config_menu_location[0].X, (int)(config_menu_location[0].Y * 3));
Console.Write(config_5);
Console.ReadLine();
