using UnityEngine;

/// <summary>
/// Перемещаемый объект
/// </summary>
public interface IMovable : IEntity
{
    /// <summary>
    /// Скорость в тайлах в секунду
    /// </summary>
    float Speed { get; set; }

    /// <summary>
    /// Перемещает объект с выбранным смещением
    /// </summary>
    /// <returns>Новые координаты объекта после смещения</returns>
    Vector2 MoveToward(Vector2 offset);

    /// <summary>
    /// Перемещает объект на выбранные координаты
    /// </summary>
    /// <returns>True - если перемещение успешно, False - если переместить не удалось</returns>
    bool MoveTo(Vector2 position);
}
