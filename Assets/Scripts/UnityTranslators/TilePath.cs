using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Класс отвечает за реализацию поиска пути по заранее проложенным Tilemap'ам
/// </summary>
public class TilePath
{
    /// <summary>
    /// Объект, из местоположения которого мобы будут спавнится
    /// </summary>
    [SerializeField]
    public GameObject SpawnPoint { get; set; }
    /// <summary>
    /// Путь от спавнпоинта вперед
    /// </summary>
    [SerializeField]
    public Tilemap Route { get; set;}
}

