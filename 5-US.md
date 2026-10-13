# 5 US

## US-01 · Sinh viên: Hủy đăng ký sự kiện
1.Phiếu đăng ký đang ở trạng thái Pending hoặc Confirmed ➜ hủy ➜ trạng thái phiếu chuyển thành Cancelled.
2.Phiếu đăng ký đã được Check-in ➜ hủy ➜ bị từ chối và báo lỗi.
## US-02 · Sinh viên: Rời khỏi câu lạc bộ
1.Đang là thành viên của CLB (có trong danh sách) ➜ rời khỏi ➜ mất quyền thành viên và bị xóa tên khỏi danh sách Club.Members.
2.Không phải là thành viên của CLB ➜ rời khỏi ➜ hệ thống báo lỗi không hợp lệ.
## US-03 · Ban CLB: Duyệt phiếu đăng ký sự kiện
1.Phiếu đăng ký đang ở trạng thái Pending và sự kiện vẫn còn chỗ (Capacity > số lượng đã duyệt) ➜ duyệt ➜ trạng thái phiếu chuyển thành Confirmed.
2.Sự kiện đã hết chỗ (đạt Capacity) ➜ duyệt ➜ hệ thống từ chối và báo lỗi vượt quá số lượng.
## US-04 · Ban CLB: Cập nhật thông tin sự kiện
1.Sự kiện chưa diễn ra và thông tin chỉnh sửa hợp lệ (sức chứa > 0, tên không trống) ➜ cập nhật ➜ lưu thành công thông tin mới.
2.Thay đổi sức chứa (Capacity) mới nhỏ hơn số lượng phiếu đã được Confirmed ➜ cập nhật ➜ hệ thống báo lỗi không cho phép.
## US-05 · Admin: Tạo câu lạc bộ mới
1.Tên CLB mới không bị trùng lặp và có đầy đủ mô tả ➜ tạo ➜ thêm thành công Club mới vào hệ thống.
2.Tên CLB bị trùng với một câu lạc bộ đã tồn tại ➜ tạo ➜ hệ thống báo lỗi trùng lặp tên.