using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����� ����� �������������� �����, � ����� �����, ������, � �.�.
/// </summary>
public class Siege
{
    public int Hour { get; set; }
    public List<IEnemy> ForestAttackers { get; set; }
    public List<IEnemy> TeleportAttackers { get; set; }
}
