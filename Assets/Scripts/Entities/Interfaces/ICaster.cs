using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс для сущностей, способных кастовать способности
/// </summary>
public interface ICaster
{
    List<IAbility> Abilities { get; }
    void SelectAttack(IDestroyable target);
}
