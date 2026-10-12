//menu logic
Console.CursorVisible = false;

int windows_height = Console.WindowHeight;
int windows_width = Console.WindowWidth;

//---button variables---//
string button_off = "X";
string button_on = "#";
(int X_start, int Y_start, int X_end, int Y_end)[] button1 = new (int, int, int, int)[1];
button1[0] = ((int)(windows_width * 0.1), (int)(windows_height * 0.2), (int)(windows_width * 0.9), (int)(windows_height * 0.35));




//code
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