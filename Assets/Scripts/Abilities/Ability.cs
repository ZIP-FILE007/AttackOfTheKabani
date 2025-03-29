using System;
using System.Collections.Generic;

public class Ability : IAbility
{
    public string Name { get; protected set; }

    public AbilityType Type { get; protected set; }

    public float BetweenCastTime { get; protected set; }

    public float CurrentCooldown { get; protected set; }

    public Action OnActivation { get; protected set; } = null;

    public Action OnReady { get; protected set; } = null;

    public bool IsReady { get; protected set; }

    public List<IEffect> Effects { get; protected set; }

    public void Activate(IEntity activator)
    {
        if(IsReady is false)
            throw new InvalidOperationException($"Невозможно выполнить абилку {Name} от активатора {activator.Name}: абилка не готова ");

        throw new NotImplementedException();
    }

    public bool ChangeCooldown(float deltaTime)
    {
        CurrentCooldown = CurrentCooldown - deltaTime;
        if(CurrentCooldown <= 0) {
            CurrentCooldown = BetweenCastTime;
            IsReady = true;
        }

        return IsReady;
    }
}
