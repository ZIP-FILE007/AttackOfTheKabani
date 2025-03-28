using System.Collections.Generic;
using Assets.Scripts.Entities;
#nullable enable
internal class MagicScroll : Entity, IItem
{
    public IPersonage? CurrentPersonage { get; set; }
    public bool OnTheFloor => CurrentPersonage == null;
    List<IAbility> Abilities { get; set; } = new();
}
