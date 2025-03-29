using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColdWeapon : Ability, IItem
{
    public ColdWeapon(List<(float damage, Force damageForce)> damages,
        string name, AbilityType type, float reloadTime, GameSession session, List<IEffect> effects) : base(name, type, reloadTime, session, effects)
    {
        Damages = damages;
    }

    public IPersonage CurrentPersonage { get; set; }

    public bool OnTheFloor => CurrentPersonage == null;

    public Vector2 Position { get; set; }
    string IEntity.Name => this.Name;


    /// <summary>
    /// Список уронов оружия
    /// </summary>
    public List<(float damage, Force damageForce)> Damages {get; protected set; } = new();

    public override void Activate(IEntity activator, List<IEntity> targets)
    {
        if(IsReady is false)
            throw new InvalidOperationException($"Невозможно выполнить абилку {Name} от активатора {activator.Name}: абилка не готова ");

        foreach(var effect in Effects) {
            effect.ActivateEffect(activator.Position, targets);
        }
        foreach(var target in targets.Where(t => t is IDestroyable).Cast<IDestroyable>()) {
            foreach(var damage in Damages) {
                target.Hit(damage.damage, damage.damageForce);
            }
        }

        IsReady = false;

        OnActivation.Invoke();
    }
}
