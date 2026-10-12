using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho Câu lạc bộ.
/// </summary>
public class Club
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<Member> _members = new();
    public IReadOnlyCollection<Member> Members => _members.AsReadOnly();

    private Club(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên CLB không được để trống.");
        return new Club(Guid.NewGuid(), name.Trim(), description?.Trim() ?? string.Empty);
    }

    public void AddMember(Member member)
    {
        if (member == null) throw new ArgumentNullException(nameof(member));
        if (_members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException("Sinh viên đã là thành viên của CLB này.");
        _members.Add(member);
    }

    public int MemberCount() => _members.Count;

    /// <summary>
    /// Hành vi (Behavior): Xem danh sách thành viên (Phục vụ User Story 2).
    /// </summary>
    public List<Member> GetMembers()
    {
        if (_members.Count == 0)
            throw new InvalidOperationException("Chưa có thành viên");
        return _members.ToList();
    }

    /// <summary>
    /// Hành vi bổ trợ: Tìm kiếm thành viên theo tên hoặc mã sinh viên (Phục vụ User Story tìm kiếm).
    /// </summary>
    public Member? SearchMember(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return null;
        return _members.FirstOrDefault(m =>
            m.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.StudentCode.Equals(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
    }
}