using hw10.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw10.Controllers
{
    public class UserController : Controller
    {
        List<UserModel> User = new List<UserModel>
        {
            new UserModel {F_Name = "d", L_Name = "m", N_code = "123", Phone = "123"}
        };
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string name, string l_name, string phone, string n_code)
        {
            return View("Login");
        }

        public IActionResult Login(string n_code, string phone)
        {
            foreach (var user in User)
            {
                if(user.N_code == n_code && user.Phone == phone)
                {
                    return View("Menu");
                }
            }

            return View("Error");
        }

        public IActionResult Turnover() 
        {
            List<AccountModel> accounts = new List<AccountModel>
            {
                new AccountModel{name = "danial", credit = 100, debit = 1000, date = DateTime.Now, note = "Im need money"}
            };

            return View("Turnover", accounts);
        }

        public IActionResult AccountMenu() 
        {
            List<AccountModel> accounts = new List<AccountModel>
            {
                new AccountModel{name = "danial", credit = 100, debit = 1000, date = new DateTime(), note = "Im need money"}
            };

            return View("Menu2", accounts);
        }

        public IActionResult Debit(int number)
        {
            List<AccountModel2> newAccounts1 = new List<AccountModel2>
            {
                new AccountModel2{name = "danial", credit = 100, debit = 1000 + number, date = new DateTime(), note = "Im need money"}
            };

            return View("Debit", newAccounts1);
        }

        public IActionResult Credit(int number)
        {
            List<AccountModel3> newAccounts2 = new List<AccountModel3>
            {
                new AccountModel3{name = "danial", credit = 100 + number, debit = 1000, date =DateTime.Now, note = "Im need money"}
            };

            return View(newAccounts2);
        }


        public IActionResult TurnoverList()
        {
            List<AccountModel> accounts = new List<AccountModel>
            {
                new AccountModel
                {
                    name = "danial", credit = 0, debit = 1000 - 100, date = DateTime.Now, note = "You have less money now"
                }
            };

            return View("TurnoverList", accounts);
        }

        public IActionResult BackToMenu()
        {
            return View("Menu");
        }
    }
}
