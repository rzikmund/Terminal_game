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

//text on down leadge
string down_text1 = "[Arrows] Movement";
string down_text2 = "[Space/Enter] Change";
string down_text3 = "[Tab] Switch panel";

//location of down text
(int X, int Y)[] down_text_location = new (int, int)[1];
down_text_location[0] = ((int)(window_width * 0.095), (int)(window_height * 0.95));

//pointer
string pointer_symbol = "#";
int pointer_index = 0;

(int X, int Y)[] pointer = new (int, int)[2];
pointer[0] = ((int)(window_width * 0.025), (int)(window_height * 0.15));

int[] menu_y = new int[5];
menu_y[0] = (int)(config_menu_location[0].Y);
menu_y[1] = (int)(config_menu_location[0].Y * 1.5);
menu_y[2] = (int)(config_menu_location[0].Y * 2);
menu_y[3] = (int)(config_menu_location[0].Y * 2.5);
menu_y[4] = (int)(config_menu_location[0].Y * 3);

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

//placing down text
Console.SetCursorPosition(down_text_location[0].X, down_text_location[0].Y);
Console.Write(down_text1);
Console.SetCursorPosition((int)(down_text_location[0].X*4), down_text_location[0].Y);
Console.Write(down_text2);
Console.SetCursorPosition((int)(down_text_location[0].X * 8), down_text_location[0].Y);
Console.Write(down_text3);

//static pointer
Console.SetCursorPosition(pointer[0].X, pointer[0].Y);
Console.Write(pointer_symbol);

//user-controlled pointer
while (true)
{
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        while (Console.KeyAvailable)
        {
            key = Console.ReadKey(true);
        }

        int old_index = pointer_index;

        if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
        {
            pointer_index = (pointer_index + 1) % 5;
        }

        if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
        {
            pointer_index = (pointer_index + 4) % 5;
        }

        if (old_index != pointer_index)
        {
            Console.SetCursorPosition(pointer[0].X, menu_y[old_index]);
            Console.Write(" ");
            pointer[0].Y = menu_y[pointer_index];
            Console.SetCursorPosition(pointer[0].X, pointer[0].Y);
            Console.Write(pointer_symbol);

        }
    }
}