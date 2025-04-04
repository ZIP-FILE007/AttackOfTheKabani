﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Какой-либо эффект (например, урон, лечение, бафф, дебафф и т.д.)
/// </summary>
public interface IEffect
{
    IEffectArea EffectArea { get; set; }
    List<IEntity> ActivateEffect(Vector2 sourcePosition, List<IEntity> possibleEntities);

    string Name { get; set; }
    string Description { get; set; }
}
