using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����� ����� �������������� �����, � ����� �����, ������, � �.�.
/// </summary>
public class Siege
{
    public int Day { get; set; }
    public int Hour { get; set; }
    public List<IEnemy> ForestAttackers { get; set; } = new List<IEnemy>();
    public List<IEnemy> TeleportAttackers { get; set; } = new List<IEnemy>();
}
