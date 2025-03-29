using System;
using System.Collections.Generic;
using UnityEngine;

public class Superhero : IAlly
{
    public IPlayer CurrentPlayer { get; set ; }

    public bool IsPlayerControlled => throw new NotImplementedException();

    public List<IItem> Inventory => throw new NotImplementedException();

    public IItem SelectedWeapon => throw new NotImplementedException();

    public float HP => throw new NotImplementedException();

    public Force Force => throw new NotImplementedException();

    public float RectangleSize => throw new NotImplementedException();

    public Action<float, Force> GotHit { get; set ; }
    public Action Destroyed { get; set ; }
    public float Speed { get; set ; }
    public Vector2 Position { get; set ; }

    public string Name => throw new NotImplementedException();

    public GameSession Session => throw new NotImplementedException();

    public List<IAbility> Abilities => throw new NotImplementedException();

    public Action OnMove { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Hit(float damage, Force force)
    {
        throw new NotImplementedException();
    }

    public void LogDeath()
    {
        throw new NotImplementedException();
    }

    public void LogHit(float damage, Force force)
    {
        throw new NotImplementedException();
    }

    public bool MoveTo(Vector2 position)
    {
        throw new NotImplementedException();
    }

    public Vector2 MoveToward(Vector2 offset)
    {
        throw new NotImplementedException();
    }

    public void SelectAttack(IDestroyable target)
    {
        throw new NotImplementedException();
    }

    public void SelectWeapon(IItem weapon)
    {
        throw new NotImplementedException();
    }
}
