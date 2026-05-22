namespace ChatShared.Protocol;

public enum MessageType
{
    Chat,
    Join,
    Leave,
    Error,
    CreateRoom,
    GetRooms
}