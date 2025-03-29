using Assets.Scripts.PatsanskiyMatematics;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#nullable enable
public class Enemy : IEnemy, ICaster
{
    public Enemy(float hP, Force force, float rectangleSize, float speed, Vector2 position, string name, List<IAbility> abilities,
        GameSession session, List<IItem> inventory)
    {
        HP = hP;
        Force = force;
        RectangleSize = rectangleSize;
        Speed = speed;
        Position = position;
        Name = name;

        GotHit = LogHit;
        Destroyed = LogDeath;
        Abilities = abilities;

        Session = session;
        Inventory = inventory;
    }

    public IPlayer? CurrentPlayer {get; set;} = null;

    public bool IsPlayerControlled => CurrentPlayer != null;

    public List<IItem> Inventory { get; protected set; }
    public float HP { get; protected set; }
    public Force Force {get; protected set;}
    public float RectangleSize {get; set;}
    public Action<float, Force> GotHit {get; set;}
    public Action Destroyed {get; set;}
    public float Speed {get; set;}
    public Vector2 Position {get; set;}
    public string Name {get; set;}
    public List<IAbility> Abilities {get; protected set;}
    public GameSession Session { get; protected set; }

    public IItem? SelectedWeapon {get; protected set;}

    public void Hit(float damage, Force force)
    {
        DamageCoefficient? currentCoef = Session.Coefficients
            .Where(coef => coef.TargetForce == Force)
            .FirstOrDefault();

        float actualDamage = damage;
        if(currentCoef != null) {
            actualDamage = damage * currentCoef.Modifier;
        }
        HP -= actualDamage;
        GotHit.Invoke(actualDamage, force);
        if(HP <= 0) {
            HP = 0f;
            Destroyed.Invoke();
        }
    }

    public void LogDeath()
    {
        Debug.Log($"{Name} стихии {Force.Name} в позиции ({Position.x};{Position.y}) сдох");
    }

    public void LogHit(float damage, Force force)
    {
        Debug.Log($"{Name} стихии {Force.Name} в позиции ({Position.x};{Position.y}) получил {force.Name} урон {damage}");
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
        if(SelectedWeapon != null && SelectedWeapon is ColdWeapon cold) {
            if(PatsanskiyMatematics.GetDistanceToRectangle(target.Position, target.RectangleSize, Position) <= 1f) {
                if(cold.IsReady) {
                    cold.Activate(this, new List<IEntity>() {
                        target
                    });
                }
            }
        }
    }

    public void SelectWeapon(IItem weapon)
    {
        if(Inventory.Contains(weapon)) {
            SelectedWeapon = weapon;
        }
        else {
            throw new InvalidOperationException($"Попытка экипировать оружие {weapon.Name} персонажу {Name}, которого нет в инвентаре");
        }
    }
}
