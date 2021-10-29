using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.Service;
using ReserverRideVar01.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace ReserverRideVar01.Controllers
{
    //[Route("/[controller]/[action]")]
    public class MemberController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        MSITDbContext _db;
        public MemberController(MSITDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }
        //[Route("/Member/register")]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(MemberViewModel Mem)
        {
            if (Mem.MemberPassword!=Mem.MemberPassword2)
            {
                ViewBag.errorpwd = "兩次密碼輸入不同，請重新輸入";
                return View();
            }
            else
            {
                
                Member member = new Member();
                member.MemberName = Mem.MemberName;
                member.MemberNumberID = Mem.MemberNumberID;
                member.MemberPassword = Mem.MemberPassword;
                member.MemberPhone = Mem.MemberPhone;
                member.MemberBirthday = Mem.MemberBirthday;
                member.MemberModifyDate = DateTime.Now;
                member.MemberCreateDate = DateTime.Now;
                member.MemberType = Mem.MemberType;
                member.MemberEmail = Mem.MemberEmail;

                _db.Members.Add(member);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
          
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("login", "Member"); ;
            }
            Member mem = _db.Members.FirstOrDefault(m => m.MemberID == id);
            if (mem == null)
            {
                return RedirectToAction("login", "Member"); ;
            }
            return View(mem);
        }
        [HttpPost]
        public IActionResult Edit(Member Member)
        {
            Member mem = _db.Members.FirstOrDefault(m => m.MemberID == Member.MemberID);
            if (mem != null)
            {
                mem.MemberName = Member.MemberName;
                mem.MemberEmail = Member.MemberEmail;
                mem.MemberPassword = Member.MemberPassword;
                mem.MemberPhone = Member.MemberPhone;
                mem.MemberAddress = Member.MemberAddress;
                mem.MemberBirthday = Member.MemberBirthday;
                //mem.MemberPhoto = Member.MemberPhoto;
                mem.MemberNumberID = Member.MemberNumberID;
                mem.MemberModifyDate = DateTime.Now;
                _db.SaveChanges();
            }
            return RedirectToAction("login","Member");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Forget()
        {
            return View();
        }
        [HttpPost]
        public string Forget(Member formData)
        {
            MailService mailService = new MailService();
            var mem = _db.Members.Where(x => x.MemberEmail == formData.MemberEmail).FirstOrDefault();
            if (mem == null)
            {
                return "無此帳號";
            }
            else
            {
                //取得信箱驗證碼
                //======================================
                string RegisterCheckCode = mailService.GetValidateCode();
                //取得寫好的驗證範本內容
                string TempMail = System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + @"\Views\Shared\ForgetEmail.html");
                //宣告驗證Email驗證用的Url-------------------------------------------------------------改9-21
                UriBuilder ValidateUrl = new UriBuilder("https", "localhost", 44324)
                {
                    Path = Url.Action("PasswordValidate", "Member",
                    new { UserName = formData.MemberEmail, RegisterCheckCode = RegisterCheckCode })
                };
                //藉由Service將使用者資料填入驗證信範本中
                string MailBody = mailService.GetRegisterMailBody(TempMail,
                    formData.MemberEmail, ValidateUrl.ToString().Replace("%3F", "?"));
                //呼叫Service寄出驗證信
                mailService.SendRegisterMail(MailBody, formData.MemberEmail);
            }

            return "成功";
        }
        //宣告Member資料表內的Service9-20
        //private MemberService memberService = new MemberService();
        //宣告寄信用的Service物件
        private MailService mailService = new MailService();

        
        //接收驗證信連接密碼修改頁面
        //==================================================
        public IActionResult PasswordValidate(string UserName, string RegisterCheckCode)
        {
            Member member = _db.Members.Where(m => m.MemberEmail == UserName).FirstOrDefault();
            //Member s = new Member() { entity = member };
            ViewBag.email = UserName;
            return View();
        }
        [HttpPost, ActionName("PasswordValidate")]
        public IActionResult PasswordValidatePost(string MemberPassword, string email)
        {

            Member member = _db.Members.Where(m => m.MemberEmail == email).FirstOrDefault();
            member.MemberPassword = MemberPassword;
            _db.SaveChanges();

            return RedirectToAction("Login", "Member");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel model)
        {

            Member mem = _db.Members.FirstOrDefault(
               c => c.MemberEmail.Equals(model.txtAccount) && c.MemberPassword.Equals(model.txtPassword));

            if (mem != null && mem.MemberPassword.Equals(model.txtPassword))
            {
                string json = JsonSerializer.Serialize(mem);
                HttpContext.Session.SetString(Dictionary.SK_LOGIN_USER, json);
                return RedirectToAction("Index","Member");
            }
            return View();
        }
        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains(Dictionary.SK_LOGIN_USER))
                return RedirectToAction("Login", "Member");
            string json = HttpContext.Session.GetString(Dictionary.SK_LOGIN_USER);
            Member user = JsonSerializer.Deserialize<Member>(json);
            ViewBag.USERNAME = user.MemberName;
            return View();
        }

    }
}
