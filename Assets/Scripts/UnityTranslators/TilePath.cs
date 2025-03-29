using System;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Класс отвечает за реализацию поиска пути по заранее проложенным Tilemap'ам
/// </summary>
[Serializable]
public class TilePath
{
    /// <summary>
    /// Объект, из местоположения которого мобы будут спавнится
    /// </summary>
    public GameObject SpawnPoint;
    /// <summary>
    /// Путь от спавнпоинта вперед
    /// </summary>
    public Tilemap Route;
}

