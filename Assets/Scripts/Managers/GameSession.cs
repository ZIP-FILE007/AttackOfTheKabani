using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameSession
{
    public List<IEntity> Entities { get; }
    public List<IPlayer> Players { get; }
    public Tilemap Tilemap  { get; set; }
    /// <summary>
    /// Номер текущей осады
    /// </summary>
    public int SiegeIndex { get; protected set; } = 0;

    public List<Siege> Sieges {get; protected set; } = new(); 
}
