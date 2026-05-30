namespace ChatShared.Models;

public class User
{
    public string Username { get; set; } = "";
    public string CurrentRoom { get; set; } = "";
    public bool IsOnline { get; set; } = false;
    public DateTime JoinedAt { get; set; } = DateTime.Now;
    public User()
    {

    }
}