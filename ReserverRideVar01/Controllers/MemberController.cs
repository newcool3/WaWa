using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.Controllers
{
    //[Route("/[controller]/[action]")]
    public class MemberController : Controller
    {
        MSITDbContext _db;
        public MemberController(MSITDbContext db)
        {
            _db = db;
        }
        //[Route("/Member/register")]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(MemberViewModel Mem)
        {
            Member member = new Member();
            member.MemberName = Mem.MemberName;
            member.MemberNumberID = Mem.MemberNumberID;
            member.MemberPassword = Mem.MemberPassword;
            member.MemberPhone = Mem.MemberPhone;
            member.MemberBirthday = Mem.MemberBirthday;
            member.MemberModifyDate = DateTime.Now;
            member.MemberCreateDate = DateTime.Now;
            member.MemberEmail = Mem.MemberEmail;
            _db.Members.Add(member);
            _db.SaveChanges();
            return RedirectToAction("about.html");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            Member mem = _db.Members.FirstOrDefault(m => m.MemberID == id);
            if (mem == null)
            {
                return RedirectToAction("List");
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
                mem.MemberPassword = Member.MemberPassword;
                mem.MemberPhone = Member.MemberPhone;
                mem.MemberAddress = Member.MemberAddress;
                mem.MemberBirthday = Member.MemberBirthday;
                //mem.MemberPhoto = Member.MemberPhoto;
                mem.MemberNumberID = Member.MemberNumberID;
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}
