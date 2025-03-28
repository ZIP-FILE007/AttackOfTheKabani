using UnityEngine;
public interface ISuperhero : IPersonage
{
    /// <summary>
    /// ID текущего игрока
    /// </summary>
    /// Равен 99 в сингплеере; и выбирается на основе порядка игроков в мультиплеере
    int? PlayerId { get; set; }
    bool IsPlayerControlled { get; }

}