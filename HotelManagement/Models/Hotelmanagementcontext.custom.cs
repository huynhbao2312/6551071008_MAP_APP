using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Models;

// File riêng (partial) để khi scaffold lại DB, EF Core Power Tools ghi đè HotelManagementContext.cs
// thì cấu hình kết nối này không bị mất.
public partial class HotelManagementContext
{
    private const string ConnectionString =
        "Server=BAO\\SQLEXPRESS01;Database=HotelManagement;Trusted_Connection=True;TrustServerCertificate=True;";

    // Constructor không tham số để dùng: new HotelManagementContext()
   
    
}