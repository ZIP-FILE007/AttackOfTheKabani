using System;
using UnityEngine;
/// <summary>
/// Способности персонажей
/// </summary>
/// Должны создавать эффекты
public interface IAbility
{
    /// <summary>
    /// Название способности
    /// </summary>
    string Name { get; protected set; }
    /// <summary>
    /// Тип способности
    /// </summary>
    AbilityType Type { get; protected set; }
    /// <summary>
    /// Время перезарядки способности
    /// </summary>
    float BetweenCastTime { get; protected set; }
    /// <summary>
    /// Текущий кулдаун способности
    /// </summary>
    float CurrentCooldown { get; protected set; }
    Action OnActivation { get; protected set; }
    Action OnReady { get; protected set; }
    bool IsReady { get; protected set; }
}
