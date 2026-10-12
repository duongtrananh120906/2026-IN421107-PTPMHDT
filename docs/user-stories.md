# User Stories - Quản lý Câu lạc bộ & Sự kiện (EduHub)

## 1. Sinh viên: Cập nhật thông tin cá nhân
- **Vai trò:** Sinh viên
- **Mô tả:** As a Student, I want to update my personal information so that my profile is accurate.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Thông tin hợp lệ và đầy đủ → cập nhật → lưu thông tin sinh viên thành công.
  - ② Thông tin không hợp lệ (ví dụ: trống tên, email sai định dạng) → cập nhật → báo lỗi.

## 2. Sinh viên: Xem danh sách thành viên CLB
- **Vai trò:** Sinh viên
- **Mô tả:** As a Student, I want to view the list of club members so that I can know my peers.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Là thành viên CLB → xem danh sách → hiển thị đầy đủ các thành viên trong CLB.
  - ② CLB chưa có thành viên nào → xem danh sách → thông báo “Chưa có thành viên”.

## 3. Ban CLB: Xóa sự kiện
- **Vai trò:** Ban CLB
- **Mô tả:** As a Club Board, I want to delete an upcoming event so that it is cancelled.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Sự kiện chưa diễn ra (`Event.Date > DateTime.Now`) → xóa → loại bỏ sự kiện khỏi danh sách tổ chức.
  - ② Sự kiện đã diễn ra → xóa → báo lỗi “Không thể xóa sự kiện”.

## 4. Ban CLB: Tìm kiếm thành viên
- **Vai trò:** Ban CLB
- **Mô tả:** As a Club Board, I want to search for members by name or student ID so that I can find them quickly.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Nhập đúng tên hoặc mã sinh viên tồn tại → tìm kiếm → hiển thị danh sách thành viên phù hợp.
  - ② Không tìm thấy kết quả phù hợp → tìm kiếm → thông báo “Không có kết quả”.

## 5. Admin: Xem danh sách CLB
- **Vai trò:** Admin
- **Mô tả:** As an Admin, I want to view the list of all clubs so that I can monitor system activity.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Hệ thống đã có các CLB → xem → hiển thị danh sách toàn bộ các CLB.
  - ② Hệ thống chưa có CLB nào → xem → thông báo “Chưa có CLB”.