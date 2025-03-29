using System;
using System.Collections.Generic;
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
    string Name { get; }
    /// <summary>
    /// Тип способности
    /// </summary>
    /// <remarks>
    /// Семейство способностей лол
    /// </remarks>
    AbilityType Type { get; }
    /// <summary>
    /// Время перезарядки способности
    /// </summary>
    float ReloadTime { get; }
    /// <summary>
    /// Текущий кулдаун способности
    /// </summary>
    float Cooldown { get; }
    Action OnActivation { get; }
    Action OnReady { get; }
    bool IsReady { get;}
    /// <summary>
    /// Эффекты которые создаёт абилка
    /// </summary>
    List<IEffect> Effects { get; }

    /// <summary>
    /// Уменьшить кулдаун на изменение времени
    /// </summary>
    /// <returns>True если кулдаун закончился; Иначе False</returns>
    bool ChangeCooldown(float deltaTime);

    void Activate(IEntity activator, List<IEntity> targets);

    void LogActivation();
    void LogReady();
}
