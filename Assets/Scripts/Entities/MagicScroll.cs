using System.Collections.Generic;
using UnityEngine;
#nullable enable
public class MagicScroll : Ability, IItem
{
    public MagicScroll(IPersonage personage,
        string name, AbilityType type, float reloadTime, GameSession session, List<IEffect> effects) : base(name, type, reloadTime, session, effects)
    {
        CurrentPersonage = personage;
    }

    public IPersonage? CurrentPersonage { get; set; }

    public bool OnTheFloor => CurrentPersonage == null;

    public Vector2 Position { get; set; }
    string IEntity.Name => this.Name;

    // Свиток типо одноразовый
    public override bool ChangeCooldown(float deltaTime)
    {
        return false;
    }
}
