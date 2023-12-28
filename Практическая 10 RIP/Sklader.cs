using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пятёрочка
{
    internal class Sklader : ICrud
    {
        static private List<Staff> goods = Class_save.Deserialize<List<Staff>>("Sklad.json");
        static private List<string> goods_str = new();
        static public Staff new_g;
        static private int index;

        static private int id;
        static private string name_new = "";
        static private double price_new;
        static private int amount_new;

        static public int id_ed;
        static public string name_ed = "";
        static public double price_ed;
        static public int amount_ed;

        static public void Hello(int y)
        {
            List<Staff> goods = Class_save.Deserialize<List<Staff>>("Sklad.json");
            Sklader skl = new();
            Console.Clear();
            skl.Read(y);
            Draw();
        }
        static public void Draw()
        {
            string user_name = $"Добро пожаловать в магазин 'Пятёрочка Выручает', {Class_Log_in.login}!, \tРоль: {Class_Log_in.role}";
            Console.SetCursorPosition(Console.BufferWidth / 2 - user_name.Length / 2, 0);
            Console.WriteLine(user_name);
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 2; i < 10; i++)
            {
                Console.SetCursorPosition(90, i);
                Console.WriteLine("|");
            }
        }

        public void Create(int y)
        {
            Staff staff_info = new();
            Draw();

            

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID:");
            Console.WriteLine("  Название:");
            Console.WriteLine("  Цена шт:");
            Console.WriteLine("  Кол-во (склад):");
            Console.WriteLine("  Сохранить");

            switch (y)
            {
                case 2:
                    Console.SetCursorPosition(5, y);
                    try
                    {
                        id = Convert.ToInt32(Console.ReadLine());
                        foreach (string elem in goods_str)
                        {
                            if (id.ToString() == elem)
                            {
                                Console.SetCursorPosition(0, 8);
                                Console.WriteLine("ID занят");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Create(y);
                            }
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine(ex.Message + "Походу не цифра :(");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Create(y);
                    }
                    break;
                case 3:
                    Console.SetCursorPosition(11, y);
                    try
                    {
                        name_new = Console.ReadLine();
                        foreach (string elem in goods_str)
                        {
                            if (name_new == elem)
                            {
                                Console.SetCursorPosition(0, 8);
                                Console.WriteLine("Такой товар уже есть!");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Create(y);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(1000);
                        Console.Clear();
                        Create(y);
                    }
                    break;
                case 4:
                    Console.SetCursorPosition(10, y);
                    try
                    {
                        price_new = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "Не похоже на цифру");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Create(y);
                    }
                    break;
                case 5:
                    Console.SetCursorPosition(17, y);
                    try
                    {
                        amount_new = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "Не похоже на цифру");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Create(y);
                    }
                    break;
                case 6:
                    staff_info.id_table = id;
                    staff_info.name_table = name_new;
                    staff_info.price_table = price_new;
                    staff_info.amount_table = amount_new;
                    goods.Add(staff_info);
                    Class_save.Serialize(goods, "Sklad.json");
                    Class_arrow.page = 2;
                    Class_arrow.deep = 1;
                    Hello(y);
                    break;
            }
        }

        public void Delete()
        {
            goods.RemoveAt(index);
            Class_save.Serialize(goods, "Sklad.json");
            Console.Clear();
            Class_arrow.page = 2;
            Hello(3);
        }

        public void Read(int y)
        {
            goods_str.Clear();
            goods.Clear();
            goods = Class_save.Deserialize<List<Staff>>("Sklad.json");

            int next = 0;
            int count = 0;
            foreach (Staff staff in goods)
            {
                goods_str.Add(staff.id_table.ToString());
                goods_str.Add(staff.name_table);
                goods_str.Add(staff.price_table.ToString());
                goods_str.Add(staff.amount_table.ToString());
            }

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("\t\tID\t\tНазвание\tЦена шт.\tКол-во (склад)");
            foreach (string elem in goods_str)
            {
                Console.Write("\t\t" + elem);
                next++;
                if (next % 4 == 0)
                {
                    Console.WriteLine(" ");
                    count++;
                }
            }
            Class_arrow.arrov_max = Class_arrow.min + count - 1;

            Console.SetCursorPosition(92, 3);
            Console.WriteLine("F1 - добавить");
            Console.SetCursorPosition(92, 4);
            Console.WriteLine("F2 - поиск");
            Console.SetCursorPosition(92, 5);
            Console.WriteLine("F4 - выйти");
        }

        public void Update(int y)
        {
            index = y - Class_arrow.min - 1;
            if (y == 2)
            {
                index++;
            }
            new_g = goods.ElementAt(index);
            Draw();
            
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"  ID:{new_g.id_table}");
            Console.WriteLine($"  Название:{new_g.name_table}");
            Console.WriteLine($"  Цена:{new_g.price_table}");
            Console.WriteLine($"  Кол-во:{new_g.amount_table}");

          

            Console.SetCursorPosition(92, 5);
            Console.WriteLine("F10 - изменить");
            Console.SetCursorPosition(92, 6);
            Console.WriteLine("Del - удалить");
            Console.SetCursorPosition(92, 7);
            Console.WriteLine("s - сохранить");
            Console.SetCursorPosition(92, 8);
            Console.WriteLine("F3 - выйти в меню");
            

        }
        public void Edit(int y)
        {
            switch (y)
            {
                case 2:
                    Console.SetCursorPosition(5, y);
                    try
                    {
                        id_ed = Convert.ToInt32(Console.ReadLine());
                        foreach (string elem in goods_str)
                        {
                            if (id_ed.ToString() == elem)
                            {
                                Console.SetCursorPosition(0, 8);
                                Console.WriteLine("ID занят");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Update(y);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine(ex.Message + "Походу не цифра :(");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Update(y);
                    }
                    break;
                case 3:
                    Console.SetCursorPosition(11, y);
                    try
                    {
                        name_ed = Console.ReadLine();
                        foreach (string elem in goods_str)
                        {
                            if (name_ed == elem)
                            {
                                Console.SetCursorPosition(0, 8);
                                Console.WriteLine("Товар уже есть");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Update(y);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 4:
                    Console.SetCursorPosition(7, y);
                    try
                    {
                        price_ed = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine(ex.Message + "Походу не цифра :(");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Update(y);
                    }
                    break;
                case 5:
                    Console.SetCursorPosition(9, y);
                    try
                    {
                        amount_ed = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine(ex.Message + "Походу не цифра :(");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Update(y);
                    }
                    break;
            }
        }

        static public void Update_save()
        {
            if (amount_ed == 0)
            {
                amount_ed = new_g.amount_table;
            }

            for (int i = 0; i < 3; i++)
            {
                if (name_ed.Length <= 0)
                {
                    name_ed = new_g.name_table;
                }
                else if (price_ed == 0)
                {
                    price_ed = new_g.price_table;
                }
                else if (id_ed == 0)
                {
                    id_ed = new_g.id_table;
                }
            }

            new_g.id_table = id_ed;
            new_g.name_table = name_ed;
            new_g.price_table = price_ed;
            new_g.amount_table = amount_ed;
            goods.Add(new_g);
            goods.RemoveAt(index);
            Class_save.Serialize(goods, "Sklad.json");
        }

        static public void Search_Draw(int y)
        {
            Console.Clear();
            Draw();
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Выберите, по какому пункту делать поиск: ");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("  ID:");
            Console.WriteLine("  Название:");
            Console.WriteLine("  Цена:");
            Console.WriteLine("  Кол-во:");
        }
        static public void Search(int y)
        {
            Search_Draw(y);
            switch (y)
            {
                case 3:
                    Console.SetCursorPosition(0, 7);
                    try
                    {
                        Console.WriteLine("Введите id:");
                        int search_id = Convert.ToInt32(Console.ReadLine());
                        Search_elem("id_table", search_id);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message + "Введите число!!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Search_Draw(y);
                    }
                    break;
                case 4:
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Введите название:");
                    string search = Console.ReadLine();
                    Search_elem("name_table", search);
                    break;
                case 5:
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Введите цену:");
                    search = Console.ReadLine();
                    Search_elem("price_table", search);
                    break;
                case 6:
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Введите кол-во:");
                    search = Console.ReadLine();
                    Search_elem("amount_table", search);
                    break;
                default:
                    Console.WriteLine("Error number");
                    break;
            }
        }

        static private void Search_elem<T>(string search_item, T search_el)
        {
            Console.Clear();
            Draw();
            goods_str.Clear();
            goods.Clear();
            goods = Class_save.Deserialize<List<Staff>>("Sklad.json");
            int next = 0;
            int count = 0;
            foreach (Staff staff in goods)
            {
                var a = staff.GetType().GetFields().FirstOrDefault(x => x.Name == search_item);
                if (String.Equals(a?.GetValue(staff), Convert.ChangeType(search_el, search_el.GetType())))
                {
                    goods_str.Add(staff.id_table.ToString());
                    goods_str.Add(staff.name_table);
                    goods_str.Add(staff.price_table.ToString());
                    goods_str.Add(staff.amount_table.ToString());
                }
            }

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("\t\tID\t\tНазвание\tЦена шт.\tКол-во (склад)");
            foreach (string elem in goods_str)
            {
                Console.Write("\t\t" + elem);
                next++;
                if (next % 4 == 0)
                {
                    Console.WriteLine(" ");
                    count++;
                }
            }
            Class_arrow.arrov_max = Class_arrow.min + count - 1;

            Console.SetCursorPosition(92, 3);
            Console.WriteLine("F1 - добавить");
            Console.SetCursorPosition(92, 4);
            Console.WriteLine("F2 - поиск");
            Console.SetCursorPosition(92, 5);
            Console.WriteLine("F4 - выйти");

        }

        
    }
}