using BookTheShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTheShowDAL.Repost
{
    public interface IuserRepositry
    {
        void Register(Userv userv);

        void UpdateUser(Userv userv);

        void DeleteUser(int uservId);

        Userv GetUserById(int uservId);

        IEnumerable<Userv> GetUsers();

        Userv Login(Userv user);

        
    }
}
