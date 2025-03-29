using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Класс задаёт характеристики волны, её время суток, врагов, и т.д.
/// </summary>
public class Siege
{
    public int Hour { get; set; }
    public List<IEnemy> ForestAttackers { get; set; }
    public List<IEnemy> TeleportAttackers { get; set; }
}
