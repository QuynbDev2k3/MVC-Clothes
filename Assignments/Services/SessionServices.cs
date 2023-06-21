using Assignments.Models;
using Newtonsoft.Json;

namespace Assignments.Services
{
    public class SessionServices
    {
        // Đưa dữ liệu vào Sesson dưới dạng Json
        public static void SetObjToJson(ISession session, string key, object value)
        {
            // Obj value là dữ liệu bạn muốn thêm vào Sesson
            // Chuyển đổi dữ liệu đó sang dạng JsonString
            var jsonstring = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonstring);
        }
        // Lấy và đưa dữ liệu từ Sesson về dạng List<obj>
        public static List<GioHangChiTiet> GetObjFromSession(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Sesson ở dạng chuỗi
            if (data != null)
            {
                var listobj = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(data);
                return listobj;
            }
            else
            {
                return new List<GioHangChiTiet>();
            }
        }
        public static bool CheckProductInCart(Guid id, List<GioHangChiTiet> cartproducts)
        {
            return cartproducts.Any(p => p.SanPhamID == id); // Kiểm tra xem có tồn tại sản phẩm đó trong giỏi hàng chưa
        }
    }
}
