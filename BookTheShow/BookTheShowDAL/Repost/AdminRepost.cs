using BookTheShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookTheShowDAL.Repost
{
    public class AdminRepost:IAdmin
    {
        MovieDBcontextv _movieDBcontextv;

        public AdminRepost(MovieDBcontextv movieDBcontextv)
        {
            _movieDBcontextv = movieDBcontextv;
        }

        public void Register(Admin adminv)
        {

            _movieDBcontextv.admins.Add(adminv);
            _movieDBcontextv.SaveChanges();
        }



        public void DeleteAdmin(int adminId)
        {
            var Adminv = _movieDBcontextv.admins.Find(adminId);
            _movieDBcontextv.admins.Remove(Adminv);
            _movieDBcontextv.SaveChanges();
        }

        public Admin GetAdminById(int adminId)
        {
            return _movieDBcontextv.admins.Find(adminId);
        }

        public IEnumerable<Admin> GetAdmins() // ucan give lis
        {
            return _movieDBcontextv.admins.ToList();
        }



        public void UpdateAdmin(Admin adminv)
        {
            _movieDBcontextv.Entry(adminv).State = EntityState.Modified;
            _movieDBcontextv.SaveChanges();
        }

        public Admin Login(Admin adminv)
        {
            Admin Admin = null;
            var result = _movieDBcontextv.admins.Where(obj => obj.AdminEmail == adminv.AdminEmail && obj.AdminPassword == adminv.AdminPassword).ToList();
            if (result.Count > 0)
            {
                Admin = result[0];
            }
            return Admin;
        }
    }
}
