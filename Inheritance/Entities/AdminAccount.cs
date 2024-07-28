namespace Inheritance.Entities;

public class AdminAccount : ModeratorAccount
{
	public bool IsOwner { get; set; }
}