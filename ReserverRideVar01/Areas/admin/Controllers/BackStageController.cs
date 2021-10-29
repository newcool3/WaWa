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
    [Area("admin")]
    public class BackStageController : Controller
    {
        MSITDbContext _db;
        public BackStageController(MSITDbContext db)
        {
            _db = db;
        }
        //[Route("/Member/register")]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(Member Mem)
        {
            //_db.Members.Add(Mem);
            //_db.SaveChanges();
            //return RedirectToAction("List");

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
            member.MemberAddress = Mem.MemberAddress;

            _db.Members.Add(member);
            _db.SaveChanges();
            return RedirectToAction("List");
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
                mem.MemberEmail = Member.MemberEmail;
                mem.MemberPassword = Member.MemberPassword;
                mem.MemberPhone = Member.MemberPhone;
                mem.MemberAddress = Member.MemberAddress;
                mem.MemberBirthday = Member.MemberBirthday;
                //mem.MemberPhoto = Member.MemberPhoto;
                mem.MemberNumberID = Member.MemberNumberID;
                mem.MemberEnable = Member.MemberEnable;
                mem.MemberType = Member.MemberType;
                mem.MemberModifyDate =DateTime.Now;

                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public IActionResult List(CQueryViewModel model)
        {
            IEnumerable<Member> members = null;
            if (string.IsNullOrEmpty(model.txtQuery))
            {
                members = from m in _db.Members
                          select m;
            }
            else
            {
                members = from m in _db.Members
                          where m.MemberName.Contains(model.txtQuery)
                          select m;
            }
            return View(members);
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Member m = _db.Members.FirstOrDefault(m => m.MemberID == id);
                if (m != null)
                {
                    _db.Members.Remove(m);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
    }
}
