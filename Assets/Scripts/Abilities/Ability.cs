using System;
using System.Collections.Generic;
using UnityEngine;

public class Ability : IAbility
{
    public Ability(string name, AbilityType type, float reloadTime, GameSession session, List<IEffect> effects)
    {
        Name = name;
        Type = type;
        ReloadTime = reloadTime;
        Session = session;
        Effects = effects;

        Cooldown = reloadTime;
        OnActivation = LogActivation;
        OnReady = LogReady;
    }

    public string Name { get; protected set; }

    public AbilityType Type { get; protected set; }

    public float ReloadTime { get; protected set; }

    public float Cooldown { get; protected set; }

    public Action OnActivation { get; protected set; }

    public Action OnReady { get; protected set; }

    public bool IsReady { get; protected set; } = true;

    public GameSession Session {get; protected set; }

    public List<IEffect> Effects { get; protected set; }

    public virtual void Activate(IEntity activator, List<IEntity> targets)
    {
        if(IsReady is false)
            throw new InvalidOperationException($"Невозможно выполнить абилку {Name} от активатора {activator.Name}: абилка не готова ");

        foreach(var effect in Effects) {
            effect.ActivateEffect(activator.Position, targets);
        }

        IsReady = false;

        OnActivation.Invoke();
    }

    public virtual bool ChangeCooldown(float deltaTime)
    {
        Cooldown = Cooldown - deltaTime;
        if(Cooldown <= 0) {
            Cooldown = ReloadTime;
            IsReady = true;
            OnReady.Invoke();
        }

        return IsReady;
    }

    public void LogActivation()
    {
        Debug.Log($"Способность {Name} активирована");
    }

    public void LogReady()
    {
        Debug.Log($"Способность {Name} готова");
    }
}
