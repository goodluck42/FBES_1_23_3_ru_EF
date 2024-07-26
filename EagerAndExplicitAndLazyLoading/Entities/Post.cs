﻿namespace EagerAndExplicitAndLazyLoading.Entities;

public class Post
{
	public int Id { get; set; }
	public string Text { get; set; } = string.Empty;

	public int Likes { get; set; }
	public int Reposts { get; set; }

	// many-to-many (#3)
	public virtual ICollection<PostProfile> PostProfiles { get; set; } = [];
}