using System.Collections.Generic;
using UnityEngine;
#nullable enable
public class GameMap
{
    public Vector2 CrystalPosition;
    public List<Vector2> HeroSpawnPoints = new();
    public List<GameTileInfo> WalkableTiles = new();
    public List<GameTileInfo> WallTiles = new();
    public List<EnemyPath> EnemyPaths = new();
}
