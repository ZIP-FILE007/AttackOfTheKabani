using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Менеджер, который отвечает за всю игровую сессию, её обновление и трансляцию в Unity
/// </summary>
public class GameHandlerBehaviour : MonoBehaviour
{
    private GameSession _session;
    private IPlayer _player;

    private List<UnityEnemyHandler> _enemyHandlers;

    // Эти поля вводятся визуальным программированием
    public List<TilePath> Paths;
    public Tilemap WallTileMap;
    public Tilemap WalkableTileMap;
    public GameObject CrystalPosition; // GameObject, который стоит на тайле кристалла
    public List<GameObject> HeroSpawnPositions;
    // Префабы кабанов
    public GameObject SmallKabanPrefab;
    public GameObject MediumKabanPrefab;
    public GameObject LargeKabanPrefab;
    void Start()
    {
        GameMap map = CreateGameMap();

        List<IPlayer> playersInGameSession = new();
        if (GameState.IsSinglePlayer) {
            Player localPlayer = new(1, "Одиночник");
            playersInGameSession.Add(localPlayer);
            _player = localPlayer;
        }
        
        _session = new GameSession(playersInGameSession, new(),  new(), new(), map);

        _session.StartGame();
        
        foreach(var enemy in _session.CurrentEnemies) {
            UnityEnemyHandler enemyHandler = new();
            if(enemy.Item1.Name == "Малый кабан") {
                enemyHandler.@object = Instantiate(SmallKabanPrefab);
            }else if (enemy.Item1.Name == "Средний кабан") {
                enemyHandler.@object = Instantiate(MediumKabanPrefab);
            }else {
                enemyHandler.@object = Instantiate(LargeKabanPrefab);
            }
            enemyHandler.Replace(enemy.Item1.Position);
        }
    }

    void Update()
    {
        
    }

    public GameMap CreateGameMap()
    {
        GameMap map = new();
        
        foreach(var path in Paths) {
            List<Vector2> tiles = path.Route.TilesToAbsolutePositions();
            EnemyPath enemyPath = new() {
                SpawnPoint = path.SpawnPoint.GetPositionInTilemap(),
                Tiles = tiles
            };
            map.EnemyPaths.Add(enemyPath);
        }
        map.WalkableTiles = WallTileMap.TilesToAbsolutePositions().Select(w => new GameTileInfo() {
            Position = w,
            IsWalkable = true,
        }).ToList();
        map.WallTiles = WallTileMap.TilesToAbsolutePositions().Select(w => new GameTileInfo() {
            Position = w,
            IsWall = true,
        }).ToList();
        map.CrystalPosition = CrystalPosition.GetPositionInTilemap();
        map.HeroSpawnPoints = HeroSpawnPositions.Select(hsp => hsp.GetPositionInTilemap()).ToList();
        return map;
    }
}
