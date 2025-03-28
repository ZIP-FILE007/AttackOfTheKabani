using System.Collections.Generic;

/// <summary>
/// Область эффекта (конус, сфера, квадрат, и т.д)
/// </summary>
public interface IEffectArea
{
    /// <summary>
    /// Возращает список сущностей, которые попали в область эффекта
    /// </summary>
    /// <param name="possibleEnitites">Все сущности, которые нужно проверить на попадание</param>
    /// <returns></returns>
    List<IEntity> GetAffectedEntities(List<IEntity> possibleEnitites);
    public int TileSize { get; set; }
}
