using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{

    class Program
    {

        static void Main(string[] args)
        {
            int sesi_login = -1, check_menu = -1, choice_menu = -1;
            string in_username, in_password;

            Users lg = new Users();

            user s_login = new user();

            lg.cetUser();

            while (check_menu == -1)
            {
                if (sesi_login == -1)
                {
                    if (choice_menu == -1)
                    {
                        lg.ShowMenuNotLogin();
                        while (choice_menu == -1)
                        {
                            try
                            {
                                choice_menu = int.Parse(Console.ReadLine());
                                if (choice_menu > 1 || choice_menu < 0)
                                    throw new Exception();

                            }
                            catch (Exception)
                            {
                                choice_menu = -1;
                                Console.WriteLine("Input salah, silahkan coba lagi!");
                            }
                        }
                    }
                    else if(choice_menu == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Halaman Login\n\n");
                        Console.Write("Username : ");
                        in_username = Console.ReadLine();
                        Console.Write("Password : ");
                        in_password = Console.ReadLine();

                        s_login = lg.Login(in_username, in_password);

                        if (s_login.username == in_username)
                        {
                            Console.WriteLine("Login Berhasil");
                            Console.WriteLine("Tekan apapun untuk melanjutkan");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Username atau Password Salah");
                            Console.WriteLine("Ingin Mencoba lagi? (Y/N)");
                            try
                            {
                                string check_reload_login = Console.ReadLine();
                                if (check_reload_login == "Y" || check_reload_login == "y")
                                    throw new Exception();
                                else if (check_reload_login == "N" || check_reload_login == "n")
                                    break;
                            }
                            catch (Exception)
                            {

                            }
                        }

                        Console.WriteLine("{0}", s_login.username);
                    }
                }

            }

            Console.ReadKey();
        }

    }
}
