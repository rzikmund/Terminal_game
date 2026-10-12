//menu logic
Console.CursorVisible = false;

int windows_height = Console.WindowHeight;
int windows_width = Console.WindowWidth;

//---button variables---//
string button_off = "X";
string button_on = "#";

string button1_text = "START";
string button2_text = "SETTINGS";

//button-1
(int X_start, int Y_start, int X_end, int Y_end)[] button1 = new (int, int, int, int)[1];
button1[0] = ((int)(windows_width * 0.1), (int)(windows_height * 0.2), (int)(windows_width * 0.9), (int)(windows_height * 0.35));

//button-2
(int X_start, int Y_start, int X_end, int Y_end)[] button2 = new (int, int, int, int)[1];
button2[0] = ((int)(windows_width * 0.1), (int)(windows_height * 0.4), (int)(windows_width * 0.9), (int)(windows_height * 0.55));



//---code---//

//---button1---//
for (int i = button1[0].X_start; i <= button1[0].X_end; i++)
{
    Console.SetCursorPosition(i, button1[0].Y_start);
    Console.Write(button_off);
    Console.SetCursorPosition(i, button1[0].Y_end);
    Console.Write(button_off);
}
for (int i = button1[0].Y_start; i <= button1[0].Y_end; i++)
{
    Console.SetCursorPosition(button1[0].X_start, i);
    Console.Write(button_off);
    Console.SetCursorPosition(button1[0].X_end, i);
    Console.Write(button_off);
}
Console.SetCursorPosition((button1[0].X_start+(button1[0].X_end-button1[0].X_start)/2)- ((int)button1_text.Length) / 2, (button1[0].Y_start + (button1[0].Y_end - button1[0].Y_start) / 2));
Console.Write(button1_text);

//---button2---//
for (int i = button2[0].X_start; i <= button2[0].X_end; i++)
{
    Console.SetCursorPosition(i, button2[0].Y_start);
    Console.Write(button_off);
    Console.SetCursorPosition(i, button2[0].Y_end);
    Console.Write(button_off);
}
for (int i = button2[0].Y_start; i <= button2[0].Y_end; i++)
{
    Console.SetCursorPosition(button2[0].X_start, i);
    Console.Write(button_off);
    Console.SetCursorPosition(button2[0].X_end, i);
    Console.Write(button_off);
}
Console.SetCursorPosition((button2[0].X_start + (button2[0].X_end - button2[0].X_start) / 2) - ((int)button2_text.Length) / 2, (button2[0].Y_start + (button2[0].Y_end - button2[0].Y_start) / 2));
Console.Write(button2_text);

//---button3---//
Console.ReadLine();