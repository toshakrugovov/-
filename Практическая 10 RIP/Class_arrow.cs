using System;
using System.Data;

namespace Пятёрочка
{
    internal class Class_arrow
    {
        static public int y = 3;
        static public int min = 3;
        static public int arrov_max;
        static public string arrow = "->";
        static public int deep;
        static public int page = 0;

        static public void Draw_Arrow()
        {
            Admin adm = new();
            Sklader skl = new();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (y <= arrov_max)
                        {
                            Console.SetCursorPosition(0, y);
                            Console.WriteLine(arrow.Replace("->", "  "));
                            Console.SetCursorPosition(0, ++y);
                            Console.WriteLine(arrow);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (y >= min)
                        {
                            Console.SetCursorPosition(0, y);
                            Console.WriteLine(arrow.Replace("->", "  "));
                            Console.SetCursorPosition(0, --y);
                            Console.WriteLine(arrow);
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (page == 0)
                        {
                            switch (deep)
                            {
                                case 0:
                                    Class_Log_in.Log_in(y);
                                    break;
                                case 1:
                                    min = 3;
                                    Admin.Hello(y);
                                    page = 1;
                                    Console.Clear();
                                    min = 2;
                                    arrov_max = 5;
                                    adm.Update(y);
                                    break;
                                case 2:
                                    min = 2;
                                    adm.Create(y);
                                    break;
                                case 3:
                                    min = 3;
                                    Admin.Search(y);
                                    break;
                            }
                        }
                        else if (page == 1)
                        {
                            switch (deep)
                            {
                                case 4:
                                    min = 2;
                                    arrov_max = 5;
                                    adm.Edit(y);
                                    break;
                                case 1:
                                    Console.Clear();
                                    min = 2;
                                    arrov_max = 5;
                                    adm.Update(y);
                                    break;
                            }
                        }
                        else if (page == 2)
                        {
                            switch (deep)
                            {
                                case 0:
                                    Class_Log_in.Log_in(y);
                                    break;
                                case 1:
                                    min = 3;
                                    Sklader.Hello(y);
                                    page = 3;
                                    Console.Clear();
                                    min = 2;
                                    arrov_max = 5;
                                    skl.Update(y);
                                    break;
                                case 2:
                                    min = 2;
                                    skl.Create(y);
                                    break;
                                case 3:
                                    min = 3;
                                    Sklader.Search(y);
                                    break;
                            }
                        }
                        else if (page == 3)
                        {
                            switch (deep)
                            {
                                case 4:
                                    min = 2;
                                    arrov_max = 5;
                                    skl.Edit(y);
                                    break;
                                case 1:
                                    Console.Clear();
                                    min = 2;
                                    arrov_max = 5;
                                    skl.Update(y);
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.F3:
                        if (page == 1)
                        {
                            Console.Clear();
                            deep = 1; 
                            Admin.Hello(y); 
                        }
                        else if (page == 3)
                        {
                            Console.Clear();
                            deep = 1; 
                            Sklader.Hello(y); 
                        }
                        
                        break;
                    case ConsoleKey.F1:
                        if (page == 0)
                        {
                            page = 0;
                            deep = 2;
                            min = 2;
                            arrov_max = 6;
                            Console.Clear();
                            adm.Create(y);
                        }
                        else if (page == 2)
                        {
                            page = 2;
                            deep = 2;
                            min = 2;
                            arrov_max = 6;
                            Console.Clear();
                            skl.Create(y);
                        }
                        break;
                    case ConsoleKey.F2:
                        if (page == 0)
                        {
                            page = 0;
                            deep = 3;
                            min = 3;
                            arrov_max = 6;
                            Admin.Search_Draw(y);
                        }
                        else if (page == 2)
                        {
                            page = 2;
                            deep = 3;
                            min = 3;
                            arrov_max = 6;
                            Sklader.Search_Draw(y);
                        }
                        break;
                    case ConsoleKey.F10:
                        if (page == 1)
                        {
                            deep = 4;
                            min = 2;
                            arrov_max = 5;
                            adm.Edit(y);
                        }
                        else if (page == 3)
                        {
                            deep = 4;
                            min = 2;
                            arrov_max = 5;
                            skl.Edit(y);
                        }
                        break;
                    case ConsoleKey.Delete:
                        if (page == 1)
                        {
                            adm.Delete();
                        }
                        else if (page == 3)
                        {
                            skl.Delete();
                        }
                        break;
                    case ConsoleKey.S:
                        if (page == 1)
                        {
                            Admin.Update_save();
                            Class_arrow.page = 0;
                            Class_arrow.deep = 1;
                            min = 3;
                            Console.Clear();
                            Admin.Hello(y);
                        }
                        else if (page == 3)
                        {
                            Sklader.Update_save();
                            Class_arrow.page = 2;
                            Class_arrow.deep = 1;
                            min = 3;
                            Console.Clear();
                            Sklader.Hello(y);
                        }
                        break;
                    case ConsoleKey.F4:
                        Console.Clear();
                        min = 2;
                        arrov_max = 5;
                        page = 0;
                        deep = 0;
                        Program.Start();
                        break;
                    default:

                        break;
                }
            }
        }
    }
}
