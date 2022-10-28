using BookTheShowDAL.Repost;
using BookTheShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTheShowBLL.services
{
    public class UserService
    {
        IuserRepositry _iuserRepositry;
        public UserService(IuserRepositry iuserRepositry)
        {
            _iuserRepositry = iuserRepositry;
        }

        public void Register(Userv userv)
        {
            _iuserRepositry.Register(userv);
        }

        public void UpdateUser(Userv userv)
        {
            _iuserRepositry.UpdateUser(userv);
        }

        public void DeleteUser(int userId)
        {
            _iuserRepositry.DeleteUser(userId);
        }

        public Userv GetUserbyId(int userId)
        {
            return _iuserRepositry.GetUserById(userId);
        }

        public IEnumerable<Userv> GetUsers()
        {
            return _iuserRepositry.GetUsers();
        }

        public Userv Login(Userv userv)
        {
            return _iuserRepositry.Login(userv);
        }

    }
}
