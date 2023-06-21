using Assignments.Models;

namespace Assignments.Iservices
{
    public interface IUserServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<User> GetAllUser();
        public User GetUserById(Guid id);

        public List<User> GetUserByName(string name);

        // Phương thức thêm
        public bool CreateUser(User us);
        // Phương thức sửa
        public bool UpdateUser(User us);
        // Phương thức xóa
        public bool DeleteUser(Guid id);
    }
}
