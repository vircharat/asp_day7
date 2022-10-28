using BookTheShowDAL.Repost;
using BookTheShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTheShowBLL.services
{
    public class AdminService
    {
        IAdmin _iadmin;
        public AdminService(IAdmin iadmin)
        {
            _iadmin = iadmin;
        }

        public void Register(Admin admin)
        {
            _iadmin.Register(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            _iadmin.UpdateAdmin(admin);
        }

        public void DeleteAdmin(int adminId)
        {
            _iadmin.DeleteAdmin(adminId);
        }

        public Admin GetAdminbyId(int adminId)
        {
            return _iadmin.GetAdminById(adminId);
        }

        public IEnumerable<Admin> GetAdmins()
        {
            return _iadmin.GetAdmins();
        }

        public Admin Login(Admin admin)
        {
            return _iadmin.Login(admin);
        }
    }
}
