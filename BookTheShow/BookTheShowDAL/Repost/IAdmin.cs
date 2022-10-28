using BookTheShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTheShowDAL.Repost
{
    public interface IAdmin
    {
        void Register(Admin admin);

        void UpdateAdmin(Admin admin);

        void DeleteAdmin(int adminId);

        Admin GetAdminById(int adminId);

        IEnumerable<Admin> GetAdmins();

        Admin Login(Admin admin);
    }
}
