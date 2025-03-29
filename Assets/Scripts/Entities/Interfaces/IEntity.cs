using UnityEngine;

/// <summary>
/// Обозначает любой игровой объект на карте (стены, люди, кони, вещи)
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Позиция по X и Y
    /// </summary>
    /// <remarks>
    /// Позиция в виде float (у нас real time в конце концов)
    /// </remarks>
    /// <remarks>
    /// Координаты зависят от тайлмапа. 1 - целый тайл
    /// </remarks>
    Vector2 Position { get; set; }
    /// <summary>
    /// Имя сущности
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Игровая сессия, в которой участвует объект
    /// </summary>
    GameSession Session { get;}
}
