using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using NamLa.Models;


namespace NamLa.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        Encrytion encry = new Encrytion();
        LTQLDbContext db = new LTQLDbContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                acc.Password = encry.PassWordEncrytion(acc.Password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Accounts");
            }
            return View(acc);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                string encrytionpass = encry.PassWordEncrytion(acc.Password);
                var model = db.Accounts.Where(m => m.Username == acc.Username && m.Password == encrytionpass).ToList().Count();
                //Thông tin đăng nhập chính xác
                if (model == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.Username, true);

                    return RedirectToAction("Index", "NhaCungCaps");
                    return RedirectToAction("Index", "SanPhams");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập không chính xác ");
                }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }

    }

}