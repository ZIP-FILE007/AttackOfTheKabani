using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Область эффекта (конус, сфера, квадрат, и т.д)
/// </summary>
/// <remarks>
/// Реализует паттерн Стратегия
/// </remarks>
public interface IEffectArea
{
    /// <summary>
    /// Возращает список сущностей, которые попали в область эффекта
    /// </summary>
    /// <param name="possibleEnitites">Все сущности, которые нужно проверить на попадание</param>
    /// <param name="direction">Направление, в котором кастуется эффект; у кругов можно не задавать</param>
    /// <returns></returns>
    List<IEntity> GetAffectedEntities(Vector2 sourcePosition, List<IEntity> possibleEnitites, Vector2? direction = null);
    /// <summary>
    /// Дальность эффекта
    /// </summary>
    /// <remarks>
    /// Радиус для круга, линия для лазера и т.д.
    /// </remarks>
    int Distance { get; }

    /// <summary>
    /// Название типа эффекта
    /// </summary>
    string Name { get; }
}
