using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermninalApp;

partial class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;


        Menu menu = new Menu();
        Frist_time_menu frist_time = new Frist_time_menu();
        Settings settings = new Settings();
        Ground ground = new Ground();

        menu.Play();    
        
    }
}