using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Сила стихий, стихия
/// </summary>
/// <remarks>
/// Их список должен определяться в одном месте, ссылочная целостность важна для определения и сравнения стихий
/// </remarks>
public class Force
{
    public Force(string name, Color color, List<DamageCoefficient> coefficients)
    {
        Name = name;
        Color = color;
        Coefficients = coefficients;
    }

    [SerializeField]
    public string Name { get; protected set; }
    [SerializeField]
    public Color Color { get; protected set; }
    /// <summary>
    /// Если коэффициентов для нужной стихии нет, принимать нужно единицу
    /// </summary>
    [SerializeField]
    public List<DamageCoefficient> Coefficients { get; protected set; }
}