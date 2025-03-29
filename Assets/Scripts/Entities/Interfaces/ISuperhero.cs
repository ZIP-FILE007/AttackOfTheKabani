using UnityEngine;
public interface ISuperhero : IPersonage
{
    /// <summary>
    /// Игрок, которому принадлежит супергерой
    /// </summary>
    IPlayer Player { get; }
}