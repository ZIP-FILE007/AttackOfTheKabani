using System.Collections.Generic;
using Assets.Scripts.Entities;

public class ColdWeapon : Entity, IItem
{
    public IPersonage CurrentPersonage { get; set; }

    public bool OnTheFloor => CurrentPersonage == null;

    /// <summary>
    /// Список уронов оружия
    /// </summary>
    public List<(float damage, Force damageForce)> Damages = new();
}
