using UnityEngine;
#nullable enable
public interface IPlayer
{
    /// <summary>
    /// ID текущего игрока
    /// </summary>
    /// Равен 1 в сингплеере; и выбирается на основе порядка игроков в мультиплеере
    int PlayerId { get; }
    string Name { get;}
    void Move(Vector2 direction);
    bool TakeControlOverEntity(IPersonage entity);
    IPersonage? ControlledPersonage { get; }
}