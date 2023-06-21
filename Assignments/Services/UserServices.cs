using Assignments.Iservices;
using Assignments.Models;

namespace Assignments.Services
{
    public class UserServices : IUserServices
    {
        ShoppingDBConText ConText;
        public UserServices()
        {
            ConText = new ShoppingDBConText();
        }
        public bool CreateUser(User us)
        {
            try
            {
                ConText.users.Add(us);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var user = ConText.users.Find(id);
                ConText.users.Remove(user);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<User> GetAllUser()
        {
            return ConText.users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return ConText.users.FirstOrDefault(p => p.UserID == id);
        }

        public List<User> GetUserByName(string name)
        {
            return ConText.users.Where(p => p.Ten.Contains(name)).ToList();
        }

        public bool UpdateUser(User us)
        {
            try
            {
                var user = ConText.users.Find(us.UserID);
                user.Ten = us.Ten;
                user.MatKhau = us.MatKhau;
                user.TrangThai = us.TrangThai;
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
