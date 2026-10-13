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

string name_text = "1. Character name";
string race_text = "2. Race";
string profession_text = "3. Profession";

string asking_for_name_text = "[ Enter name... ]";
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
string hero_name_answer = " ";
string race_answer = " ";
string profession_answer = " ";
string outfit_answer = " ";

int power_answer = 0;
int intelligence_answer = 0;
int dexterity_answer = 0;

int first_time = 0; //0-no, 1-yes

//hero outfit
string hero_symbol = "X";
int hero_hight = 2;

ConsoleColor head_color = ConsoleColor.Gray;
ConsoleColor body_color = ConsoleColor.Red;

//text location//
(int X, int Y)[] text_location = new (int, int)[7];
text_location[1] = ((int)(windows_width / 2) - (head_text.Length) + 2, 0);  //head text
text_location[2] = ((int)(windows_width * 0.05), (int)(windows_height * 0.1));   //hero name text
text_location[3] = ((int)(windows_width * 0.05), (int)(windows_height * 0.2));  //race text
text_location[4] = ((int)(windows_width * 0.05), (int)(windows_height * 0.3)); //profession text
text_location[5] = ((int)(windows_width * 0.05), (int)(windows_height * 0.3));
text_location[6] = ((int)((windows_width * 0.125) / 2) + (hero_text.Length), (int)(windows_height * 0.60) + 1);   //hero text


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
Console.SetCursorPosition(text_location[1].X, text_location[1].Y);
Console.Write(head_text);
Console.SetCursorPosition(text_location[2].X, text_location[2].Y);
Console.Write(name_text + "  " + arrow);
Console.SetCursorPosition(text_location[3].X, text_location[3].Y);
Console.Write(race_text + "  " + arrow);
Console.SetCursorPosition(text_location[4].X, text_location[4].Y);
Console.Write(profession_text + "  " + arrow);
Console.SetCursorPosition(text_location[6].X, text_location[6].Y);
Console.Write(hero_text);

Console.SetCursorPosition(text_location[2].X + (name_text + "  " + arrow).Length + 2, text_location[2].Y);
Console.Write(asking_for_name_text);


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