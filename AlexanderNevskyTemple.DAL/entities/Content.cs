﻿using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.entities;

[PrimaryKey(nameof(Id))]
public class Content
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public string URL { get; set; } = string.Empty;
    public virtual Article Article { get; set; }
}