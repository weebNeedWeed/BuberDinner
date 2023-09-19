﻿using Domain.Common.Models;

namespace Domain.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}