using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TermninalApp
{
    public class Ground
    {
        public void Play()
        {


            //----variables----//
            Console.CursorVisible = false;

            int windows_height = Console.WindowHeight;
            int windows_width = Console.WindowWidth;

            string earth_symbol = "█";

            uint tile_ranodm = 1;

            int world_offset = 0;

            //earth
            (int X_start, int Y_start, int X_end, int Y_end)[] earth = new (int, int, int, int)[1];
            earth[0] = (0, (int)(windows_height * 0.9), windows_width - 1, windows_height - 1);

            //plants
            int grass_end_x = windows_width - 1;
            int grass_start_x = 0;
            int grass_chance = 1;
            string grass = "|";

            //stars
            int star_chance = 1;
            string star_symbol = "*";
            (int X_start, int Y_start, int X_end, int Y_end)[] star = new (int, int, int, int)[1];
            star[0] = (0, 0, windows_width - 1, (int)(windows_height * 0.2));

            //hero

            int momentum = 0;
            string hero_symbol = "X";

            (int X, int Y)[] hero_location = new (int, int)[1];
            hero_location[0] = (1, earth[0].Y_start - (int)(windows_height * 0.07));

            (int X_start, int Y_start, int X_end, int Y_end)[] body = new (int, int, int, int)[1];



            //----ACTIONS----//
            Action<int, int> random = (x, y) =>
            {   //random gererator with Bit mixer and XOR

                tile_ranodm = ((uint)x * 732444753U);
                tile_ranodm = ((uint)x * 732444753U);
                tile_ranodm ^= ((uint)y * 227651033U);
                tile_ranodm ^= ((uint)Global.seed * 105655039U);

                tile_ranodm = (tile_ranodm ^ (tile_ranodm >> 16)) * 2246822507U;
                tile_ranodm = (tile_ranodm ^ (tile_ranodm >> 13)) * 3266489909U;
                tile_ranodm = (tile_ranodm ^ (tile_ranodm >> 16));


            };

            Action ground = () =>
            {
                for (int i = earth[0].X_start; i <= earth[0].X_end; i++)
                {
                    for (int y = earth[0].Y_start; y <= earth[0].Y_end; y++)
                    {
                        random(i + world_offset, y);
                        tile_ranodm = tile_ranodm % 4;

                        switch (tile_ranodm)
                        {
                            case 0: earth_symbol = "█"; break;
                            case 1: earth_symbol = "▓"; break;
                            case 2: earth_symbol = "▒"; break;
                            case 3: earth_symbol = "░"; break;
                        }

                        Console.SetCursorPosition(i, y);
                        Console.Write(earth_symbol);

                    }
                }

                //---generatig grass---//
                for (int i = grass_start_x; i <= grass_end_x; i++)
                {
                    random(i + world_offset, earth[0].Y_start - 1);
                    tile_ranodm = tile_ranodm % 101;
                    Console.SetCursorPosition(i, earth[0].Y_start - 1);
                    if (tile_ranodm == 1)
                    {
                        Console.Write(grass);
                    }
                }

                //---generating stars---//
                for (int i = star[0].X_start; i <= star[0].X_end; i++)
                {
                    for (int y = star[0].Y_start; y <= star[0].Y_end; y++)
                    {
                        random(i + world_offset, y);
                        tile_ranodm = tile_ranodm % 101;
                        Console.SetCursorPosition(i, y);
                        if (tile_ranodm == 1)
                        {
                            Console.Write(star_symbol);
                        }
                    }
                }
            };

            Action hero_movement = () =>
            {
                for (int i = body[0].X_start; i <= body[0].X_end; i++)
                {
                    for (int y = body[0].Y_start; y <= body[0].Y_end; y++)
                    {
                        Console.SetCursorPosition(i, y);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(hero_symbol);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            };

            Action hero_delete = () =>
            {
                for (int i = body[0].X_start; i <= body[0].X_end; i++)
                {
                    for (int y = body[0].Y_start; y <= body[0].Y_end; y++)
                    {
                        Console.SetCursorPosition(i, y);
                        Console.Write(" ");

                    }
                }
            };

            Action body_update = () =>
            {
                body[0] = (hero_location[0].X + (int)(windows_height * 0.01), hero_location[0].Y + (int)(windows_height * 0.01), hero_location[0].X + (int)(windows_height * 0.01), hero_location[0].Y + (int)(windows_height * 0.04));
            };


            //----MAIN LOOP----//

            ground();
            body_update();
            hero_movement();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true);
                    }

                    if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) && hero_location[0].X <= windows_width - 1)
                    {
                        hero_delete();
                        hero_location[0].X++;
                        body_update();
                        hero_movement();
                        momentum = 1;

                        if (hero_location[0].X >= windows_width * 0.75)
                        {
                            hero_delete();
                            hero_location[0].X--;
                            body_update();


                            earth[0] = (windows_width - 1, (int)(windows_height * 0.9), windows_width - 1, windows_height - 1);
                            star[0] = (windows_width - 1, 0, windows_width - 1, (int)(windows_height * 0.2));
                            grass_start_x = windows_width - 1;
                            grass_end_x = windows_width - 1;
                            

                            earth[0] = (windows_width-1, (int)(windows_height * 0.9), windows_width - 1, windows_height - 1);
                            ground();
                            Console.MoveBufferArea
                                (
                                    sourceLeft: 1,
                                    sourceTop: 0,
                                    sourceWidth: windows_width - 1,
                                    sourceHeight: windows_height,
                                    targetLeft: 0,
                                    targetTop: 0
                                );


                            world_offset++;
                            ground();
                            hero_movement();
                        }
                    }

                    if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) && hero_location[0].X >= 1)
                    {
                        hero_delete();
                        hero_location[0].X--;
                        body_update();
                        hero_movement();
                        momentum = -1;
                    }



                    if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                    {
                        switch (momentum)
                        {
                            case 0:
                                hero_delete();
                                hero_location[0].Y -= 2;
                                body_update();
                                hero_movement();

                                Thread.Sleep(100);

                                hero_delete();
                                hero_location[0].Y += 2;
                                body_update();
                                hero_movement();
                                break;

                            case 1:
                                if (hero_location[0].X <= windows_width - 5)
                                {
                                    hero_delete();
                                    hero_location[0].Y -= 2;
                                    hero_location[0].X += 2;
                                    body_update();
                                    hero_movement();

                                    Thread.Sleep(100);

                                    hero_delete();
                                    hero_location[0].Y += 2;
                                    hero_location[0].X += 1;
                                    body_update();
                                    hero_movement();
                                    momentum = 0;

                                }
                                else
                                {
                                    hero_delete();
                                    hero_location[0].Y -= 2;
                                    body_update();
                                    hero_movement();

                                    Thread.Sleep(100);

                                    hero_delete();
                                    hero_location[0].Y += 2;
                                    body_update();
                                    hero_movement();
                                    momentum = 0;
                                }
                                break;


                            case -1:
                                if (hero_location[0].X >= 5)
                                {
                                    hero_delete();
                                    hero_location[0].Y -= 2;
                                    hero_location[0].X -= 2;
                                    body_update();
                                    hero_movement();

                                    Thread.Sleep(100);

                                    hero_delete();
                                    hero_location[0].Y += 2;
                                    hero_location[0].X -= 1;
                                    body_update();
                                    hero_movement();
                                    momentum = 0;
                                }
                                else
                                {
                                    hero_delete();
                                    hero_location[0].Y -= 2;
                                    body_update();
                                    hero_movement();

                                    Thread.Sleep(100);

                                    hero_delete();
                                    hero_location[0].Y += 2;
                                    body_update();
                                    hero_movement();
                                    momentum = 0;
                                }
                                break;

                        }
                    }
                }
            }
        }
    }
}
         
        
    
