using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TermninalApp
{
    public class Frist_time_menu
    {
        public void Play()
        {
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

            string power_text = "POWER: ";
            string intelligence_text = "INTELLIGENCE: ";
            string dexterity_text = "DEXTERITY: ";

            string race_1 = "Human";
            string race_2 = "Elf";
            string race_3 = "Dwarf";
            string race_4 = "Orc";

            string profession_1 = "Warrior";
            string profession_2 = "Mage";
            string profession_3 = "Thief";

            string hero_symbol_text = "Hero symbol:";
            string head_color_text = "Head color: ";
            string body_color_text = "Body color: ";

            string hero_symbol_answer_text = "[ Enter hero character... ]";

            string head_color_1 = "Red";
            string head_color_2 = "Blue";
            string head_color_3 = "White";
            string head_color_4 = "Gray";

            string body_color_1 = "Red";
            string body_color_2 = "Blue";
            string body_color_3 = "White";
            string body_color_4 = "Gray";

            string play_button = "Continue >";

            string asking_for_name_text = "[ Enter name... ]";
            ConsoleColor text_color = ConsoleColor.White;

            //statistic text
            string chart = "[░░░░░░░░░░]";

            int power_unit_used = 2;
            int intelligence_unit_used = 2;
            int dexterity_unit_used = 2;
            int points = 5;

            string points_text = "FREE POINTS: [ " + points + " ]";

            //line for border//
            string up_line = "│";
            string line = "─";

            string left_up_corner = "┌";
            string left_down_corner = "└";
            string right_up_corner = "┐";
            string right_down_corner = "┘";
            string arrow = "->";

            //hero custom//
            string hero_name_answer = " ";
            string race_answer = " ";
            string profession_answer = " ";
            string outfit_answer = " ";

            int power_answer = 0;
            int intelligence_answer = 0;
            int dexterity_answer = 0;

            int first_time = 0; //0-yes, 1-no

            //hero outfit
            string hero_symbol = "X";
            int hero_hight = 2;

            ConsoleColor head_color = ConsoleColor.Red;
            ConsoleColor body_color = ConsoleColor.Red;

            //text location//
            (int X, int Y)[] text_location = new (int, int)[13];
            text_location[1] = ((int)(windows_width / 2) - (head_text.Length) + 2, 0);  //head text
            text_location[2] = ((int)(windows_width * 0.05), (int)(windows_height * 0.1));   //hero name text
            text_location[3] = ((int)(windows_width * 0.05), (int)(windows_height * 0.2));  //race text
            text_location[4] = ((int)(windows_width * 0.05), (int)(windows_height * 0.3)); //profession text
            text_location[5] = ((int)(windows_width * 0.05), (int)(windows_height * 0.45));  //power text
            text_location[6] = ((int)(windows_width * 0.05), (int)(windows_height * 0.5)); //intelligence text 
            text_location[7] = ((int)(windows_width * 0.05), (int)(windows_height * 0.57));  //dexterity text

            text_location[8] = ((int)(windows_width * 0.35), (int)(windows_height * 0.7));  //hero symbol text
            text_location[9] = ((int)(windows_width * 0.35), (int)(windows_height * 0.8));  //head color text
            text_location[10] = ((int)(windows_width * 0.35), (int)(windows_height * 0.9));  //body color text

            text_location[11] = ((int)(windows_width - play_button.Length - 3), (int)(windows_height - 2));  //play button text

            text_location[12] = ((int)((windows_width * 0.125) / 2) + (hero_text.Length), (int)(windows_height * 0.60) + 1);   //hero text

            //statistics location//
            (int X, int Y)[] statistics_location = new (int, int)[5];
            statistics_location[1] = (text_location[5].X + intelligence_text.Length + 2, text_location[5].Y);  //power grafic
            statistics_location[2] = (text_location[6].X + intelligence_text.Length + 2, text_location[6].Y);  //intelligence grafic
            statistics_location[3] = (text_location[7].X + intelligence_text.Length + 2, text_location[7].Y);  //dexterity grafic

            //cursor//
            int curent_selection = 2;
            int max_selection = 11;
            int min_selection = 2;

            int curent_selection_body = 1;
            int max_selection_body = 4;
            int min_selection_body = 1;

            int curent_selection_head = 1;
            int max_selection_head = 4;
            int min_selection_head = 1;

            int curent_selection_hero_symbol = 1;
            int max_selection_hero_symbol = 1;
            int min_selection_hero_symbol = 1;

            int curent_selection_hero_name = 1;
            int max_selection_hero_name = 1;
            int min_selection_hero_name = 1;

            int curent_selection_profession = 1;
            int max_selection_profession = 3;
            int min_selection_profession = 1;


            int curent_selection_race = 1;
            int max_selection_race = 4;
            int min_selection_race = 1;

            string cursor_logo = "#";
            (int X, int Y)[] cursor = new (int, int)[1];
            cursor[0] = (1, 1);  //1 - first row,1 - first collum

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
                Console.SetCursorPosition(i, (int)(windows_height * 0.40));
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
            for (int i = (int)(windows_height * 0.60) + 1; i < windows_height - 1; i++)
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

            //placing text//
            Console.SetCursorPosition(text_location[1].X, text_location[1].Y);
            Console.Write(head_text);
            Console.SetCursorPosition(text_location[2].X, text_location[2].Y);
            Console.Write(name_text + "  " + arrow);
            Console.SetCursorPosition(text_location[3].X, text_location[3].Y);
            Console.Write(race_text + "  " + arrow);
            Console.SetCursorPosition(text_location[4].X, text_location[4].Y);
            Console.Write(profession_text + "  " + arrow);
            Console.SetCursorPosition(text_location[5].X, text_location[5].Y);
            Console.Write(power_text);
            Console.SetCursorPosition(text_location[6].X, text_location[6].Y);
            Console.Write(intelligence_text);
            Console.SetCursorPosition(text_location[7].X, text_location[7].Y);
            Console.Write(dexterity_text);
            Console.SetCursorPosition(text_location[8].X, text_location[8].Y);
            Console.Write(hero_symbol_text);
            Console.SetCursorPosition(text_location[9].X, text_location[9].Y);
            Console.Write(head_color_text);
            Console.SetCursorPosition(text_location[10].X, text_location[10].Y);
            Console.Write(body_color_text);
            Console.SetCursorPosition(text_location[11].X, text_location[11].Y);
            Console.Write(play_button);
            Console.SetCursorPosition(text_location[12].X, text_location[12].Y);
            Console.Write(hero_text);

            Console.SetCursorPosition(text_location[2].X + (name_text + "  " + arrow).Length + 2, text_location[2].Y);
            Console.Write(asking_for_name_text);
            Console.SetCursorPosition(text_location[3].X + (race_text + "  " + arrow).Length + 2, text_location[3].Y);
            Console.Write("< " + race_1 + " >" + " / " + race_2 + " / " + race_3 + " / " + race_4);
            Console.SetCursorPosition(text_location[4].X + (profession_text + "  " + arrow).Length + 2, text_location[4].Y);
            Console.Write("< " + profession_1 + " >" + " / " + profession_2 + " / " + profession_3);

            Console.SetCursorPosition(text_location[8].X + (hero_symbol_text + " ").Length + 2, text_location[8].Y);
            Console.Write(hero_symbol_answer_text);
            Console.SetCursorPosition(text_location[9].X + (head_color_text + " ").Length + 2, text_location[9].Y);
            Console.Write("< " + head_color_1 + " >" + " / " + head_color_2 + " / " + head_color_3 + " / " + head_color_4);
            Console.SetCursorPosition(text_location[10].X + (body_color_text + " ").Length + 2, text_location[10].Y);
            Console.Write("< " + body_color_1 + " >" + " / " + body_color_2 + " / " + body_color_3 + " / " + body_color_4);

            //placing statistic
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(statistics_location[1].X, statistics_location[1 + i].Y);
                Console.Write(chart);
            }
            Action units = () =>
            {
                Console.SetCursorPosition(statistics_location[1].X + chart.Length + 2, statistics_location[1].Y);
                Console.Write(power_unit_used);
                Console.SetCursorPosition(statistics_location[2].X + chart.Length + 2, statistics_location[2].Y);
                Console.Write(intelligence_unit_used);
                Console.SetCursorPosition(statistics_location[3].X + chart.Length + 2, statistics_location[3].Y);
                Console.Write(dexterity_unit_used);
                Console.SetCursorPosition(statistics_location[1].X + chart.Length + (int)(windows_width * 0.15), statistics_location[1].Y);
                Console.Write(points_text);

                Console.SetCursorPosition(statistics_location[1].X, statistics_location[1].Y);
                Console.Write(chart);
                for (int i = 0; i < power_unit_used; i++)
                {

                    Console.SetCursorPosition(statistics_location[1].X + 1 + i, statistics_location[1].Y);
                    Console.Write("▓");
                }


                Console.SetCursorPosition(statistics_location[1].X, statistics_location[2].Y);
                Console.Write(chart);
                for (int i = 0; i < intelligence_unit_used; i++)
                {

                    Console.SetCursorPosition(statistics_location[1].X + 1 + i, statistics_location[2].Y);
                    Console.Write("▓");
                }


                Console.SetCursorPosition(statistics_location[1].X, statistics_location[3].Y);
                Console.Write(chart);
                for (int i = 0; i < dexterity_unit_used; i++)
                {

                    Console.SetCursorPosition(statistics_location[1].X + 1 + i, statistics_location[3].Y);
                    Console.Write("▓");
                }
            };
            units();
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

            //render/delete cursor
            Action<int, string> draw_cursor = (index, logo) =>
            {
                Console.SetCursorPosition(text_location[index].X - 2, text_location[index].Y);
                Console.Write(logo);
            };

            //render/delete body
            Action draw_body_text = () =>
            {
                switch (curent_selection_body)
                {
                    case 1:
                        Console.SetCursorPosition(text_location[10].X + (body_color_text + " ").Length + 2, text_location[10].Y);
                        Console.Write("< " + body_color_1 + " >" + " / " + body_color_2 + " / " + body_color_3 + " / " + body_color_4 + "   ");
                        body_color = ConsoleColor.Red;
                        placing_hero();
                        break;
                    case 2:
                        Console.SetCursorPosition(text_location[10].X + (body_color_text + " ").Length + 2, text_location[10].Y);
                        Console.Write(body_color_1 + " / " + " < " + body_color_2 + " >" + " / " + body_color_3 + " / " + body_color_4 + "   ");
                        body_color = ConsoleColor.Blue;
                        placing_hero();
                        break;
                    case 3:
                        Console.SetCursorPosition(text_location[10].X + (body_color_text + " ").Length + 2, text_location[10].Y);
                        Console.Write(body_color_1 + " / " + body_color_2 + " / " + "< " + body_color_3 + " >" + " / " + body_color_4 + "   ");
                        body_color = ConsoleColor.White;
                        placing_hero();
                        break;

                    case 4:
                        Console.SetCursorPosition(text_location[10].X + (body_color_text + " ").Length + 2, text_location[10].Y);
                        Console.Write(body_color_1 + " / " + body_color_2 + " / " + body_color_3 + " / " + "< " + body_color_4 + " >" + "   ");
                        body_color = ConsoleColor.Gray;
                        placing_hero();
                        break;
                }

            };

            Action draw_head_text = () =>
            {
                switch (curent_selection_head)
                {
                    case 1:
                        Console.SetCursorPosition(text_location[9].X + (head_color_text + " ").Length + 2, text_location[9].Y);
                        Console.Write("< " + head_color_1 + " >" + " / " + head_color_2 + " / " + head_color_3 + " / " + head_color_4 + "   ");
                        head_color = ConsoleColor.Red;
                        placing_hero();
                        break;
                    case 2:
                        Console.SetCursorPosition(text_location[9].X + (head_color_text + " ").Length + 2, text_location[9].Y);
                        Console.Write(head_color_1 + " / " + " < " + head_color_2 + " >" + " / " + head_color_3 + " / " + head_color_4 + "   ");
                        head_color = ConsoleColor.Blue;
                        placing_hero();
                        break;
                    case 3:
                        Console.SetCursorPosition(text_location[9].X + (head_color_text + " ").Length + 2, text_location[9].Y);
                        Console.Write(head_color_1 + " / " + head_color_2 + " / " + "< " + head_color_3 + " >" + " / " + head_color_4 + "   ");
                        head_color = ConsoleColor.White;
                        placing_hero();
                        break;

                    case 4:
                        Console.SetCursorPosition(text_location[9].X + (head_color_text + " ").Length + 2, text_location[9].Y);
                        Console.Write(head_color_1 + " / " + head_color_2 + " / " + head_color_3 + " / " + "< " + head_color_4 + " >" + "   ");
                        head_color = ConsoleColor.Gray;
                        placing_hero();
                        break;
                }
            };

            Action hero_symbol_changing = () =>
            {
                Console.SetCursorPosition(text_location[8].X + (hero_symbol_text + " ").Length + 2, text_location[8].Y);
                Console.Write("[   ]                           ");
                Console.SetCursorPosition(text_location[8].X + (hero_symbol_text + " ").Length + 4, text_location[8].Y);
                hero_symbol = Console.ReadLine();
                if (hero_symbol.Length > 1)
                {
                    hero_symbol = "X";
                    Console.SetCursorPosition(text_location[8].X + (hero_symbol_text + " ").Length + 2, text_location[8].Y);
                    Console.Write("[1 symbol...]               ");
                }
                placing_hero();
            };

            Action hero_name = () =>
            {
                Console.SetCursorPosition(text_location[2].X + (name_text + "  " + arrow).Length + 2, text_location[2].Y);
                Console.Write("[          ]                       ");
                Console.SetCursorPosition(text_location[2].X + (name_text + "  " + arrow).Length + 3, text_location[2].Y);
                hero_name_answer = Console.ReadLine();
                if (hero_name_answer.Length > 10)
                {
                    hero_name_answer = "Leo";
                    Console.SetCursorPosition(text_location[2].X + (name_text + "  " + arrow).Length + 2, text_location[2].Y);
                    Console.Write("[10 symbols...]               ");
                }


            };



            Action race = () =>
            {
                switch (curent_selection_race)
                {
                    case 1:
                        Console.SetCursorPosition(text_location[3].X + (race_text + " ").Length + 2, text_location[3].Y);
                        Console.Write(">" + "  < " + race_1 + " >" + " / " + race_2 + " / " + race_3 + " / " + race_4 + "   ");
                        race_answer = race_1;

                        power_unit_used = 2;
                        intelligence_unit_used = 2;
                        dexterity_unit_used = 2;
                        units();
                        break;

                    case 2:
                        Console.SetCursorPosition(text_location[3].X + (race_text + " ").Length + 2, text_location[3].Y);
                        Console.Write(">  " + race_1 + " / " + " < " + race_2 + " >" + " / " + race_3 + " / " + race_4 + "   ");
                        race_answer = race_2;

                        power_unit_used = 0;
                        intelligence_unit_used = 5;
                        dexterity_unit_used = 1;
                        units();
                        break;

                    case 3:
                        Console.SetCursorPosition(text_location[3].X + (race_text + " ").Length + 2, text_location[3].Y);
                        Console.Write(">  " + race_1 + " / " + race_2 + " / " + "< " + race_3 + " >" + " / " + race_4 + "   ");
                        race_answer = race_3;

                        power_unit_used = 4;
                        intelligence_unit_used = 1;
                        dexterity_unit_used = 1;
                        units();
                        break;

                    case 4:
                        Console.SetCursorPosition(text_location[3].X + (race_text + " ").Length + 2, text_location[3].Y);
                        Console.Write(">  " + race_1 + " / " + race_2 + " / " + race_3 + " / " + "< " + race_4 + " >" + "   ");
                        race_answer = race_4;

                        power_unit_used = 2;
                        intelligence_unit_used = 0;
                        dexterity_unit_used = 4;
                        units();
                        break;
                }

            };

            Action profession = () =>
            {
                switch (curent_selection_profession)
                {
                    case 1:
                        Console.SetCursorPosition(text_location[4].X + (profession_text + "  " + arrow).Length + 3, text_location[4].Y);
                        Console.Write("< " + profession_1 + " >" + " / " + profession_2 + " / " + profession_3);
                        profession_answer = profession_1;
                        points = 5;
                        points_text = "FREE POINTS: [ " + points + " ]";
                        Console.SetCursorPosition(statistics_location[1].X + chart.Length + (int)(windows_width * 0.15), statistics_location[1].Y);
                        Console.Write(points_text);
                        units();
                        race();
                        break;
                    case 2:
                        Console.SetCursorPosition(text_location[4].X + (profession_text + " ").Length + 3, text_location[4].Y);
                        Console.Write("   " + profession_1 + " / " + " < " + profession_2 + " >" + " / " + profession_3 + "   ");
                        profession_answer = profession_2;
                        points = 6;
                        points_text = "FREE POINTS: [ " + points + " ]";
                        Console.SetCursorPosition(statistics_location[1].X + chart.Length + (int)(windows_width * 0.15), statistics_location[1].Y);
                        Console.Write(points_text);
                        units();
                        race();
                        break;
                    case 3:
                        Console.SetCursorPosition(text_location[4].X + (profession_text + " ").Length + 3, text_location[4].Y);
                        Console.Write("   " + profession_1 + " / " + profession_2 + " / " + "< " + profession_3 + " >" + "   ");
                        profession_answer = profession_3;
                        points = 7;
                        points_text = "FREE POINTS: [ " + points + " ]";
                        Console.SetCursorPosition(statistics_location[1].X + chart.Length + (int)(windows_width * 0.15), statistics_location[1].Y);
                        Console.Write(points_text);
                        units();
                        race();
                        break;


                }
            };
            placing_hero();

            draw_cursor(curent_selection, cursor_logo);


            //-----DYNAMIC CODE ------//


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true);
                    }

                    draw_cursor(curent_selection, " ");


                    if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                    {
                        curent_selection--;
                        if (curent_selection < min_selection)
                        {
                            curent_selection = max_selection;
                        }

                    }

                    if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                    {
                        curent_selection++;
                        if (curent_selection > max_selection)
                        {
                            curent_selection = min_selection;
                        }

                    }

                    draw_cursor(curent_selection, cursor_logo);

                    if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                    {
                        if (curent_selection == 2)
                        {
                            curent_selection_hero_name++;
                            if (curent_selection_hero_name > max_selection_hero_name)
                            {
                                curent_selection_hero_name = min_selection_hero_name;
                            }
                            hero_name();
                        }


                        if (curent_selection == 3)
                        {
                            curent_selection_race++;
                            if (curent_selection_race > max_selection_race)
                            {
                                curent_selection_race = min_selection_race;
                            }
                            race();
                        }

                        if (curent_selection == 4)
                        {
                            curent_selection_profession++;
                            if (curent_selection_profession > max_selection_profession)
                            {
                                curent_selection_profession = min_selection_profession;
                            }
                            profession();
                        }
                        //
                        if (curent_selection == 5)
                        {
                            points--;
                            if (points >= 0)
                            {
                                power_unit_used++;
                                if (power_unit_used == 11)
                                {
                                    power_unit_used = 10;
                                    points++;
                                }
                                points_text = "FREE POINTS: [ " + points + " ]";
                                Console.SetCursorPosition(statistics_location[1].X + chart.Length + (int)(windows_width * 0.15), statistics_location[1].Y);
                                Console.Write(points_text);
                                units();
                            }
                        }

                        if (curent_selection == 6)
                        {
                            points--;
                            if (points >= 0)
                            {
                                intelligence_unit_used++;
                                if (intelligence_unit_used == 11)
                                {
                                    intelligence_unit_used = 10;
                                    points++;
                                }
                                points_text = "FREE POINTS: [ " + points + " ]";
                                Console.SetCursorPosition(statistics_location[1].X + chart.Length + (int)(windows_width * 0.15), statistics_location[1].Y);
                                Console.Write(points_text);
                                units();
                            }
                        }

                        if (curent_selection == 7)
                        {
                            points--;
                            if (points >= 0)
                            {
                                dexterity_unit_used++;
                                if (dexterity_unit_used == 11)
                                {
                                    dexterity_unit_used = 10;
                                    points++;
                                }
                                points_text = "FREE POINTS: [ " + points + " ]";
                                Console.SetCursorPosition(statistics_location[1].X + chart.Length + (int)(windows_width * 0.15), statistics_location[1].Y);
                                Console.Write(points_text);
                                units();
                            }
                        }
                        //

                        if (curent_selection == 8)
                        {
                            curent_selection_hero_symbol++;
                            if (curent_selection_hero_symbol > max_selection_hero_symbol)
                            {
                                curent_selection_hero_symbol = min_selection_hero_symbol;
                            }
                            hero_symbol_changing();
                        }

                        if (curent_selection == 9)
                        {
                            curent_selection_head++;
                            if (curent_selection_head > max_selection_head)
                            {
                                curent_selection_head = min_selection_head;
                            }
                            draw_head_text();
                        }

                        if (curent_selection == 10)
                        {
                            curent_selection_body++;
                            if (curent_selection_body > max_selection_body)
                            {
                                curent_selection_body = min_selection_body;
                            }
                            draw_body_text();
                        }
                    }

                    if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                    {
                        if (curent_selection == 2)
                        {
                            curent_selection_hero_name--;
                            if (curent_selection_hero_name < min_selection_hero_name)
                            {
                                curent_selection_hero_name = max_selection_hero_name;
                            }
                            hero_name();
                        }

                        if (curent_selection == 3)
                        {
                            curent_selection_race--;
                            if (curent_selection_race < min_selection_race)
                            {
                                curent_selection_race = max_selection_race;
                            }
                            race();
                        }

                        if (curent_selection == 4)
                        {
                            curent_selection_profession--;
                            if (curent_selection_profession < min_selection_profession)
                            {
                                curent_selection_profession = max_selection_profession;
                            }
                            profession();
                        }
                        //
                        if (curent_selection == 5)
                        {
                            profession();
                        }

                        if (curent_selection == 6)
                        {
                            profession();
                        }
                        if (curent_selection == 7)
                        {
                            profession();
                        }
                        //
                        if (curent_selection == 8)
                        {
                            curent_selection_hero_symbol--;
                            if (curent_selection_hero_symbol < min_selection_hero_symbol)
                            {
                                curent_selection_hero_symbol = max_selection_hero_symbol;
                            }
                            hero_symbol_changing();
                        }

                        if (curent_selection == 9)
                        {
                            curent_selection_head--;
                            if (curent_selection_head < min_selection_head)
                            {
                                curent_selection_head = max_selection_head;
                            }
                            draw_head_text();
                        }

                        if (curent_selection == 10)
                        {
                            curent_selection_body--;
                            if (curent_selection_body < min_selection_body)
                            {
                                curent_selection_body = max_selection_body;
                            }
                            draw_body_text();
                        }
                    }

                    if (key.Key == ConsoleKey.Enter && curent_selection == 11)
                    {
                        first_time = 1;
                    }
                }
            }
        }
    }
}