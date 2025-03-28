using UnityEngine;
#nullable enable
/// <summary>
/// Предмет; может существовать на земле, или в инвентаре
/// </summary>
public interface IItem : IEntity
{
    IPersonage? CurrentPersonage { get; set; }
    bool OnTheFloor { get; }
}
