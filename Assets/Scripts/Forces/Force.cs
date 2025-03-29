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
    public Force(string name, Color color)
    {
        Name = name;
        Color = color;
    }

    [SerializeField]
    public string Name { get; protected set; }
    [SerializeField]
    public Color Color { get; protected set; }
}