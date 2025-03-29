using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Менеджер, который отвечает за всю игровую сессию, её обновление и трансляцию в Unity
/// </summary>
public class GameHandlerBehaviour : MonoBehaviour
{
    private GameSession _session;
    private IPlayer _player;

    public List<TilePath> Paths;
    public Tilemap WallTileMap;
    public Tilemap WalkableTileMap;
    void Start()
    {

    }

    void Update()
    {
        
    }
}
