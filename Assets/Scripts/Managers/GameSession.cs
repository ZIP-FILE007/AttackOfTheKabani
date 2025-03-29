using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameSession
{
    public GameSession(List<IPlayer> players, List<Siege> sieges, List<Force> forces, List<DamageCoefficient> coefficients,
        GameMap gameMap)
    {
        Players = players;
        Sieges = sieges;
        Forces = forces;

        GameMap = gameMap;

        if (Forces.Count == 0)
            Forces = GetDefaultForces();
        if (Coefficients.Count == 0)
            Coefficients = GetDefaultCoefficients();
        if (Sieges.Count == 0)
            Sieges = GetDefaultSieges();
    }

    public GameMap GameMap { get; protected set; }
    public List<(IEnemy, EnemyPath)> CurrentEnemies { get; protected set; } = new();
    public List<IPlayer> Players { get; protected set; }
    /// <summary>
    /// Номер текущей осады
    /// </summary>
    public int SiegeIndex { get; protected set; } = 1;

    public List<Siege> Sieges {get; protected set; } = new(); 

    public List<Force> Forces {get; protected set; } = new();

    /// <summary>
    /// Если коэффициентов для нужной стихии нет, принимать нужно единицу
    /// </summary>
    public List<DamageCoefficient> Coefficients { get; protected set; } = new();

    public void StartGame()
    {
        Siege startSiege = Sieges.First();
        int spawnPoints = GameMap.EnemyPaths.Count;
        foreach(var enemy in startSiege.ForestAttackers) {
            int path = Random.Range(0, spawnPoints);
            CurrentEnemies.Add((enemy, GameMap.EnemyPaths[path]));

            enemy.Position = GameMap.EnemyPaths[path].SpawnPoint;
        }
    }

    public void UpdateGame(float deltaTime, Vector2? moveDirection = null, int? hotbarClicked = null)
    {

    }

    public void HandlePlayerMovement(IPlayer player, Vector2Int direction)
    {
        player.Move(direction);
    }

    private static List<Force> GetDefaultForces()
    {
        List<Force> result = new();

        Force physic = new("Физика", new Color(224, 224, 224));
        Force magic = new("Магия", new Color(178, 102, 255));

        result.Add(physic);
        result.Add(magic);

        return result;
    }

    private List<Siege> GetDefaultSieges()
    {
        List<Siege> result = new();

        Force physic = Forces.Where(f => f.Name == "Физика").First();
        Force magic = Forces.Where(f => f.Name == "Магия").First();

        Siege one = new() {
            Day = 1,
            Hour = 8,
            ForestAttackers = new List<IEnemy>() {
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban()
            }
        };

        Siege two = new() {
            Day = 1, 
            Hour = 20,
            ForestAttackers = new List<IEnemy>() {
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateMediumKaban(),
                GenerateMediumKaban(),
                GenerateMediumKaban(),
            }
        };

        Siege three = new() {
            Day = 2, 
            Hour = 2,
            ForestAttackers = new List<IEnemy>() {
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateSmallKaban(),
                GenerateMediumKaban(),
                GenerateMediumKaban(),
                GenerateMediumKaban(),
                GenerateBigKaban(),
                GenerateBigKaban(),
                GenerateBigKaban(),
            }
        };

        result.Add(one);
        result.Add(two);
        result.Add(three);

        return result;
    }

    private List<DamageCoefficient> GetDefaultCoefficients()
    {
        List<DamageCoefficient> result = new();

        Force physic = Forces.Where(f => f.Name == "Физика").First();
        Force magic = Forces.Where(f => f.Name == "Магия").First();

        result.Add(new(physic, magic, 1.2f));
        result.Add(new(magic, physic, 1.3f));

        return result;
    }

    private Enemy GenerateSmallKaban()
    {
        Force physic = Forces.Where(f => f.Name == "Физика").First();

        var smallFangsDamage = new List<(float damage, Force damageForce)>() {
            new (2f, physic)
        };
        ColdWeapon smallFangs = new(smallFangsDamage, "Маленькие клыки", AbilityType.CloseCombat, 1f, this, new List<IEffect>());

        Enemy smallKaban = new(10, physic, 1, 4f, new(-99,-99), "Малый кабан", new List<IAbility>(), this,
            new List<IItem>() {smallFangs});
        smallKaban.SelectWeapon(smallFangs);

        return smallKaban;
    }

    private Enemy GenerateMediumKaban()
    {
        Force physic = Forces.Where(f => f.Name == "Физика").First();

        var mediumDamage = new List<(float damage, Force damageForce)>() {
            new (3f, physic)
        };
        ColdWeapon mediumFangs = new(mediumDamage, "Средние клыки", AbilityType.CloseCombat, 1f, this, new List<IEffect>());

        Enemy mediumKaban = new(20, physic, 1, 3f, new(-99,-99), "Средний кабан", new List<IAbility>(), this,
            new List<IItem>() {mediumFangs});
        mediumKaban.SelectWeapon(mediumFangs);

        return mediumKaban;
    }

    private Enemy GenerateBigKaban()
    {
        Force physic = Forces.Where(f => f.Name == "Физика").First();
        Force magic = Forces.Where(f => f.Name == "Магия").First();

        var bigDamage = new List<(float damage, Force damageForce)>() {
            new (5f, physic),
            new (4f, magic)
        };
        ColdWeapon bigFangs = new(bigDamage, "Большие клыки", AbilityType.CloseCombat, 1f, this, new List<IEffect>());

        Enemy bigKaban = new(30, physic, 1, 4f, new(-99,-99), "Большой кабан", new List<IAbility>(), this,
            new List<IItem>() {bigFangs});
        bigKaban.SelectWeapon(bigFangs);

        return bigKaban;
    }
}
