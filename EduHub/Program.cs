using System;
using System.Collections.Generic;
using EduHub.docs; // Chỉ giữ lại namespace đúng của 5 class

namespace EduHubConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập để Console hiển thị tốt tiếng Việt có dấu
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BẮT ĐẦU CHẠY THỬ NGHIỆM QUY TRÌNH EDUHUB ===\n");

            // 1. Khởi tạo dữ liệu Sinh viên
            Member student = new Member
            {
                Id = Guid.NewGuid(),
                Name = "Phạm Nguyễn Tuấn Anh",
                StudentId = "0024416676"
            };
            Console.WriteLine($"[1] Sinh viên mới: {student.Name} (MSSV: {student.StudentId})");

            // 2. Chạy quy trình US-05: Tạo Câu lạc bộ
            List<string> dbClubs = new List<string> { "IT Club", "English Club" }; // Giả lập dữ liệu cũ
            Club newClub = Club.Create("EduHub Club", "CLB Học thuật và Sáng tạo", dbClubs);
            Console.WriteLine($"[2] Ban quản trị tạo thành công CLB: {newClub.Name}");

            // 3. Chạy quy trình US-04: Tạo và Cập nhật Sự kiện
            Event newEvent = Event.Create(newClub.Id, "Workshop C# cơ bản", 30);
            newEvent.UpdateInfo("Workshop C# nâng cao", 50); // Đổi tên và tăng sức chứa lên 50
            Console.WriteLine($"[3] Sự kiện được cập nhật: {newEvent.Title} (Sức chứa: {newEvent.Capacity})");

            // 4. Sinh viên tiến hành đăng ký sự kiện
            Registration reg = Registration.Create(student.Id, newEvent.Id);
            Console.WriteLine($"[4] Sinh viên đăng ký tham gia sự kiện. Trạng thái phiếu: {reg.Status}");

            // 5. Chạy quy trình US-03: Ban CLB duyệt phiếu đăng ký
            reg.Approve(newEvent);
            Console.WriteLine($"[5] Ban CLB đã duyệt phiếu. Trạng thái hiện tại: {reg.Status}");

            // 6. Chạy quy trình US-01: Sinh viên hủy đăng ký
            reg.Cancel();
            Console.WriteLine($"[6] Sinh viên đổi ý và hủy phiếu. Trạng thái cuối cùng: {reg.Status}");

            // 7. Chạy quy trình US-02: Sinh viên rời CLB (Giả lập)
            // Lưu ý: Cần có hàm AddMember vào danh sách Members trước khi test RemoveMember.
            // newClub.RemoveMember(student);

            Console.WriteLine("\n=== QUY TRÌNH KẾT THÚC. BẤM PHÍM BẤT KỲ ĐỂ THOÁT ===");
            Console.ReadKey();
        }
    }
}