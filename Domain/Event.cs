using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho Sự kiện do CLB tổ chức.
/// </summary>
public class Event
{
    public Guid Id { get; private set; }
    public Guid ClubId { get; private set; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public int Capacity { get; private set; }
    public bool IsOnline { get; private set; }

    private Event(Guid id, Guid clubId, string title, DateTime date, int capacity, bool isOnline)
    {
        Id = id;
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
        IsOnline = isOnline;
    }

    public static Event Create(Guid clubId, string title, DateTime date, int capacity, bool isOnline)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tiêu đề sự kiện không được để trống.");
        if (capacity <= 0)
            throw new ArgumentException("Sức chứa sự kiện phải lớn hơn 0.");

        return new Event(Guid.NewGuid(), clubId, title.Trim(), date, capacity, isOnline);
    }

    /// <summary>
    /// Hành vi (Behavior): Kiểm tra xem sự kiện có thể xóa được không (Chưa diễn ra) - Phục vụ User Story 3.
    /// </summary>
    public bool CanBeDeleted()
    {
        return Date > DateTime.Now;
    }

    public void UpdateDetails(string newTitle, DateTime newDate)
    {
        if (!CanBeDeleted())
            throw new InvalidOperationException("Không thể chỉnh sửa hoặc xóa sự kiện đã diễn ra.");
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Tiêu đề mới không hợp lệ.");

        Title = newTitle.Trim();
        Date = newDate;
    }
}