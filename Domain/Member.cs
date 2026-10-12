using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho một Thành viên (Sinh viên) trong hệ thống EduHub.
/// </summary>
public class Member
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string StudentCode { get; private set; }
    public DateTime JoinedAt { get; private set; }

    private Member(Guid id, string name, string email, string studentCode)
    {
        Id = id;
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = DateTime.Now;
    }

    /// <summary>
    /// Factory method tạo mới thành viên với validation dữ liệu đầu vào.
    /// </summary>
    public static Member Create(string name, string email, string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên sinh viên không được để trống.");
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new ArgumentException("Email sinh viên không hợp lệ.");
        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException("Mã sinh viên không được để trống.");

        return new Member(Guid.NewGuid(), name.Trim(), email.Trim(), studentCode.Trim());
    }

    /// <summary>
    /// Hành vi (Behavior): Cập nhật thông tin cá nhân (Phục vụ User Story 1).
    /// </summary>
    public void UpdateProfile(string newName, string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Thông tin không hợp lệ: Tên mới không được để trống.");
        if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains("@"))
            throw new ArgumentException("Thông tin không hợp lệ: Email mới không đúng định dạng.");

        Name = newName.Trim();
        Email = newEmail.Trim();
    }

    public bool IsActive() => true;
}