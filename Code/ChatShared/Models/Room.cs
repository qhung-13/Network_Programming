namespace ChatShared.Models;

public class Room
{
    public string RoomName { get; set; } = "";

    public List<User> Users { get; set; }

    public Room()
    {
        Users = new List<User>();
    }
}