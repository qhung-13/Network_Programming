namespace ChatShared.Models;

public class Room
{
    public string RoomName { get; set; } = "";
    public string Description { get; set; } = "";
    public int Maxmembers { get; set; } = 0;
    public int CurrentMembers { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Room()
    {

    }

}