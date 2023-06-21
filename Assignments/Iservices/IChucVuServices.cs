using Assignments.Models;

namespace Assignments.Iservices
{
    public interface IChucVuServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<ChucVu> GetAllChucVu();
        public ChucVu GetChucVuById(Guid id);

        public List<ChucVu> GetChucVuByName(string name);

        // Phương thức thêm
        public bool CreateChucVu(ChucVu cv);
        // Phương thức sửa
        public bool UpdateChucVu(ChucVu cv);
        // Phương thức xóa
        public bool DeleteChucVu(Guid id);
    }
}
