using System.ComponentModel;

namespace Пятёрочка
{
    internal class Class_Log_in
    {
        static public string login = "";
        static public string role = "";
        static private string password_check = "";
        static public void Log_in(int y)
        {
            List<string> logs = new List<string>();
            List<string> pass = new List<string>();
            int can_log = 0;

            if (y == 2)
            {
                Console.SetCursorPosition(8, y);
                try
                {
                    login = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (y == 3)
            {
                HideCharacter(y);
            }
            else
            {
                List<User> users = Class_save.Deserialize<List<User>>("users.json");
                foreach (User user in users)
                {
                    logs.Add(user.login_table);
                    pass.Add(user.password_table);
                }
                foreach (string log in logs)
                {
                    if (login.Equals(log))
                    {
                        can_log++;
                    }
                }
                foreach (string pas in pass)
                {
                    if (password_check.Equals(pas))
                    {
                        can_log++;
                    }
                }

                if (can_log == 2)
                {
                    foreach (User user in users)
                    {
                        if (user.login_table.Equals(login) & user.password_table.Equals(password_check))
                        {
                            role = user.role_table;
                        }
                    }
                    switch (role)
                    {
                        case "Admin":
                            Class_arrow.min = 3;
                            Admin.Hello(y);
                            Class_arrow.deep = 1;
                            break;
                        case "Sklad":
                            Class_arrow.page = 2;
                            Class_arrow.min = 3;
                            Class_arrow.deep = 1;
                            Sklader.Hello(y);
                            break;
                        case "HR":
                            break;
                        case "Kassir":
                            break;
                        case "Buhgalter":
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("неверный логин или пароль");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Program.Start();
                }
            }
        }

        public static void HideCharacter(int y)
        {
            int x = 11;
            string password = "";
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                Console.SetCursorPosition(x, y);
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (password.Length != 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b");
                        x--;
                    }
                }
                else
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                    x++;
                }
            }
            password_check = password;
        }
    }
}