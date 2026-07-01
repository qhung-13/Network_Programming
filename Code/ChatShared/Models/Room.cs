namespace ChatShared.Models;

public class Room
{
    public string RoomName { get; set; } = "";
    public string Description { get; set; } = "";

    // 0 = không giới hạn
    public int MaxMembers { get; set; } = 0;

    // Chỉ dùng để hiển thị, không dùng làm nguồn kiểm tra chính
    public int CurrentMembers { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool HasMemberLimit => MaxMembers > 0;
}