//menu logic
namespace TermninalApp
{
    public class Menu
    {
        public void Play()
        {
            Console.CursorVisible = false;

            int windows_height = Console.WindowHeight;
            int windows_width = Console.WindowWidth;

            //---button variables---//
            string button_on = "#";
            string button_off = "X";
            string button_symbol = button_off;

            string button1_text = "START";
            string button2_text = "SETTINGS";
            string button3_text = "EXIT";

            int cursor_location = 1;

            //button-1
            (int X_start, int Y_start, int X_end, int Y_end)[] button1 = new (int, int, int, int)[1];
            button1[0] = ((int)(windows_width * 0.1), (int)(windows_height * 0.3), (int)(windows_width * 0.9), (int)(windows_height * 0.45));

            //button-2
            (int X_start, int Y_start, int X_end, int Y_end)[] button2 = new (int, int, int, int)[1];
            button2[0] = ((int)(windows_width * 0.1), (int)(windows_height * 0.5), (int)(windows_width * 0.9), (int)(windows_height * 0.65));

            //button-3
            (int X_start, int Y_start, int X_end, int Y_end)[] button3 = new (int, int, int, int)[1];
            button3[0] = ((int)(windows_width * 0.1), (int)(windows_height * 0.7), (int)(windows_width * 0.9), (int)(windows_height * 0.85));


            //---code---//

            Action button_start = () =>
            {
                for (int i = button1[0].X_start; i <= button1[0].X_end; i++)
                {
                    Console.SetCursorPosition(i, button1[0].Y_start);
                    Console.Write(button_symbol);
                    Console.SetCursorPosition(i, button1[0].Y_end);
                    Console.Write(button_symbol);
                }
                for (int i = button1[0].Y_start; i <= button1[0].Y_end; i++)
                {
                    Console.SetCursorPosition(button1[0].X_start, i);
                    Console.Write(button_symbol);
                    Console.SetCursorPosition(button1[0].X_end, i);
                    Console.Write(button_symbol);
                }
                Console.SetCursorPosition((button1[0].X_start + (button1[0].X_end - button1[0].X_start) / 2) - ((int)button1_text.Length) / 2, (button1[0].Y_start + (button1[0].Y_end - button1[0].Y_start) / 2));
                Console.Write(button1_text);
            };

            Action button_settings = () =>
            {
                for (int i = button2[0].X_start; i <= button2[0].X_end; i++)
                {
                    Console.SetCursorPosition(i, button2[0].Y_start);
                    Console.Write(button_symbol);
                    Console.SetCursorPosition(i, button2[0].Y_end);
                    Console.Write(button_symbol);
                }
                for (int i = button2[0].Y_start; i <= button2[0].Y_end; i++)
                {
                    Console.SetCursorPosition(button2[0].X_start, i);
                    Console.Write(button_symbol);
                    Console.SetCursorPosition(button2[0].X_end, i);
                    Console.Write(button_symbol);
                }
                Console.SetCursorPosition((button2[0].X_start + (button2[0].X_end - button2[0].X_start) / 2) - ((int)button2_text.Length) / 2, (button2[0].Y_start + (button2[0].Y_end - button2[0].Y_start) / 2));
                Console.Write(button2_text);
            };

            Action button_exit = () =>
            {
                for (int i = button3[0].X_start; i <= button3[0].X_end; i++)
                {
                    Console.SetCursorPosition(i, button3[0].Y_start);
                    Console.Write(button_symbol);
                    Console.SetCursorPosition(i, button3[0].Y_end);
                    Console.Write(button_symbol);
                }
                for (int i = button3[0].Y_start; i <= button3[0].Y_end; i++)
                {
                    Console.SetCursorPosition(button3[0].X_start, i);
                    Console.Write(button_symbol);
                    Console.SetCursorPosition(button3[0].X_end, i);
                    Console.Write(button_symbol);
                }
                Console.SetCursorPosition((button3[0].X_start + (button3[0].X_end - button3[0].X_start) / 2) - ((int)button3_text.Length) / 2, (button3[0].Y_start + (button3[0].Y_end - button3[0].Y_start) / 2));
                Console.Write(button3_text);
            };
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true);
                    }

                    if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                    {
                        if (cursor_location == 3)
                        {
                            cursor_location = 1;
                        }
                        else
                        {
                            cursor_location++;
                        }
                        switch (cursor_location)
                        {
                            case 1:
                                button_symbol = button_on;
                                button_start();
                                button_symbol = button_off;
                                button_settings();
                                button_exit();
                                cursor_location = 1;
                                break;

                            case 2:
                                button_symbol = button_on;
                                button_settings();
                                button_symbol = button_off;
                                button_start();
                                button_exit();
                                cursor_location = 2;
                                break;

                            case 3:
                                button_symbol = button_on;
                                button_exit();
                                button_symbol = button_off;
                                button_start();
                                button_settings();
                                cursor_location = 3;
                                break;
                        }
                    }

                    if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                    {
                        if (cursor_location == 1)
                        {
                            cursor_location = 3;
                        }
                        else
                        {
                            cursor_location--;
                        }
                        switch (cursor_location)
                        {
                            case 1:
                                button_symbol = button_on;
                                button_start();
                                button_symbol = button_off;
                                button_settings();
                                button_exit();
                                break;

                            case 2:
                                button_symbol = button_on;
                                button_settings();
                                button_symbol = button_off;
                                button_start();
                                button_exit();
                                break;

                            case 3:
                                button_symbol = button_on;
                                button_exit();
                                button_symbol = button_off;
                                button_start();
                                button_settings();
                                break;
                        }
                    }
                }
            }
        }
    }
}