using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Менеджер, который отвечает за всю игровую сессию, её обновление и трансляцию в Unity
/// </summary>
public class GameHandlerBehaviour : MonoBehaviour
{
    private GameSession _session;

    public List<TilePath> Paths { get ; set; }
    public Tilemap WallTileMap { get; set; }
    public Tilemap WalkableTileMap { get; set; }
    void Start()
    {

    }

    void Update()
    {
        
    }
}
