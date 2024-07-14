using MvvmLib.Models;

namespace MvvmLib.Messages;

public class UserAddedMessage(User user) : IMessage
{
    public User User { get; } = user;
}