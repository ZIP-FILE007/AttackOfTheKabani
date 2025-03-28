using UnityEngine;

/// <summary>
/// Коэффициент урона элемента по элементу
/// </summary>
public class DamageCoefficient
{
    public DamageCoefficient(Force sourceForce, Force targetForce, float modifier)
    {
        SourceForce = sourceForce;
        TargetForce = targetForce;
        Modifier = modifier;
    }

    public Force SourceForce {  get; protected set; }
    public Force TargetForce { get; protected set; }

    /// <summary>
    /// Модификатор урона
    /// </summary>
    public float Modifier { get; protected set; }
}
