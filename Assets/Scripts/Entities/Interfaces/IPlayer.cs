using UnityEngine;
public interface IPlayer
{
    /// <summary>
    /// ID текущего игрока
    /// </summary>
    /// Равен 1 в сингплеере; и выбирается на основе порядка игроков в мультиплеере
    int? PlayerId { get; set; }
    string Name { get; set;}
    void Move(Vector2 direction);
    bool TakeControlOverEntity(IPersonage entity);
}