# User Stories - Hệ thống Quản lý EduHub

## 1. Sinh viên: Cập nhật thông tin cá nhân
- **Vai trò:** Sinh viên
- **Mô tả:** As a Student, I want to update my personal information so that my profile is accurate.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Thông tin chưa đầy đủ → cập nhật → lưu thông tin sinh viên thành công.
  - ② Thông tin không hợp lệ → cập nhật → báo lỗi.

## 2. Sinh viên: Xem danh sách thành viên CLB
- **Vai trò:** Sinh viên
- **Mô tả:** As a Student, I want to view the list of club members so that I can connect with others.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Là thành viên CLB → xem danh sách → hiển thị danh sách các thành viên.
  - ② CLB không có thành viên → xem → thông báo “Chưa có thành viên”.

## 3. Ban CLB: Xóa sự kiện
- **Vai trò:** Ban CLB
- **Mô tả:** As a Club Board, I want to delete an event so that outdated events are removed.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Sự kiện chưa diễn ra → xóa → loại bỏ sự kiện khỏi danh sách.
  - ② Sự kiện đã diễn ra → xóa → báo lỗi “Không thể xóa sự kiện”.

## 4. Ban CLB: Tìm kiếm thành viên
- **Vai trò:** Ban CLB
- **Mô tả:** As a Club Board, I want to search for members so that I can manage them easily.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Nhập tên hoặc mã sinh viên → tìm kiếm → hiển thị thành viên phù hợp.
  - ② Không tìm thấy → tìm kiếm → thông báo “Không có kết quả”.

## 5. Admin: Xem danh sách CLB
- **Vai trò:** Admin
- **Mô tả:** As an Admin, I want to view all clubs in the system so that I can monitor system activity.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Có các CLB trong hệ thống → xem → hiển thị danh sách CLB.
  - ② Hệ thống chưa có CLB → xem → thông báo “Chưa có CLB”.
