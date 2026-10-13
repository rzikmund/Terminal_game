using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Console.CursorVisible = false;

//----Variables----//
int windows_height = Console.WindowHeight;
int windows_width = Console.WindowWidth;

//text
string head_text = " CUSTOMIZATION ";
string hero_text = " HERO ";
ConsoleColor text_color = ConsoleColor.White;

//line for border
string up_line = "│";
string line = "─";

string left_up_corner = "┌";
string left_down_corner = "└";
string right_up_corner = "┐";
string right_down_corner = "┘";
string arrow = "->" ;

//hero custom//
string hero_name = " ";
string race = " ";
string profession = " ";
string outfit = " ";

int power = 0;
int intelligence = 0;
int dexterity = 0;

int first_time = 0; //0-no, 1-yes

//hero outfit
string hero_symbol = "X";
int hero_hight = 2;

ConsoleColor head_color = ConsoleColor.Gray;
ConsoleColor body_color = ConsoleColor.Red;


//---CODE---//

//generating lying lines
for (int i = 1; i < windows_width - 1; i++)
{
    Console.SetCursorPosition(i, 0);
    Console.Write(line);
    Console.SetCursorPosition(i, windows_height - 1);
    Console.Write(line);

    //dividing line
    Console.SetCursorPosition(i, (int)(windows_height * 0.60));
    Console.Write(line);
}

//generating up lines
for (int i = 1; i < windows_height - 1; i++)
{
    Console.SetCursorPosition(0, i);
    Console.Write(up_line);
    Console.SetCursorPosition(windows_width - 1, i);
    Console.Write(up_line);
}

//generating dividing up line
for (int i = (int)(windows_height * 0.60)+1; i < windows_height-1; i++)
{
    Console.SetCursorPosition((int)(windows_width * 0.25), i);
    Console.Write(up_line);
}

//generating corners
Console.SetCursorPosition(0, 0);
Console.Write(left_up_corner);
Console.SetCursorPosition(0, windows_height - 1);
Console.Write(left_down_corner);
Console.SetCursorPosition(windows_width - 1, 0);
Console.Write(right_up_corner);
Console.SetCursorPosition(windows_width - 1, windows_height - 1);
Console.Write(right_down_corner);

//placing text
Console.SetCursorPosition((int)(windows_width / 2) - (head_text.Length)+2, 0);
Console.Write(head_text);
Console.SetCursorPosition((int)((windows_width * 0.125)/2) + (hero_text.Length), (int)(windows_height * 0.60)+1);
Console.Write(hero_text);

//placing hero
Action placing_hero = () =>
{
    Console.ForegroundColor = body_color;
    Console.SetCursorPosition((int)((windows_width * 0.125)), (int)(windows_height * 0.80));
    Console.Write(hero_symbol);
    Console.ForegroundColor = head_color;
    Console.SetCursorPosition((int)((windows_width * 0.125)), (int)(windows_height * 0.80) - 1);
    Console.Write(hero_symbol);
    Console.ForegroundColor = text_color;
};


placing_hero();






Console.ReadLine();