﻿
using System.Reflection.Metadata.Ecma335;

namespace Console_Project.Models;

public abstract class BaseEntity
{
    private static int _id;
    public int Id { get; protected set; }
    public BaseEntity()
    {
        Id = ++_id;
    }

}
