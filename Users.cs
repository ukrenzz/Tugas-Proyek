using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    struct user
    {
        public string fullname;
        public string username;
        public string password;
        public int level;
    }
    enum level_user
    {
        Admin = 1,
        Owner = 2,
        Staff = 3,
        User = 4
    }
    class Users
    {
        List<user> usr = new List<user>();
        level_user lvl = new level_user();
        user pfl = new user();

        public Users()
        {
        }

        public void Register(string nama, string username, string password, int level) //Fungsi Register
        {
            user add_user = new user();
            add_user.fullname = nama;
            add_user.username = username;
            add_user.password = password;
            add_user.level = level;

            if (usr.Exists(x => x.username == username) == true)
            {
                Console.WriteLine("Username sudah digunakan!!");
            }
            else
            {
                this.usr.Add(add_user);
                Console.WriteLine("Register Berhasil!!");
                Console.ReadKey();
            }
        }

        public user Login(string username, string password) //Fungsi Login
        {
            user find_user = new user();
            int idx_user;

            if (usr.Exists(x => x.username == username) == true &&
                usr.Exists(x => x.password == password) == true)
            {
                idx_user = usr.FindIndex(x => x.username == username);
                find_user.fullname = usr[idx_user].fullname;
                find_user.username = usr[idx_user].username;
                find_user.password = usr[idx_user].password;
                find_user.level = usr[idx_user].level;

            }

            return find_user;
            
        }

        public void PrintAllUser()//Fungsi Cetak List User
        {
            foreach (user x in this.usr)
                Console.WriteLine(" Fullname : {0} \n username : {1} \n Level : {2}",
                    x.fullname,
                    x.username,
                    (level_user)x.level);
        }

        public void ShowMenuNotLogin()
        {
            Console.Clear();
            Console.WriteLine("Aplikasi ini hanya dapat di gunakan oleh user yang bersangkutan dan dibuat admin\n\n");
            Console.WriteLine("Menu :");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("0. Exit");
            Console.Write("Pilihan = ");
        }
    }
}
