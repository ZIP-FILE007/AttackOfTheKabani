using UnityEngine;
public interface IPlayer
{
    /// <summary>
    /// ID текущего игрока
    /// </summary>
    /// Равен 1 в сингплеере; и выбирается на основе порядка игроков в мультиплеере
    int? PlayerId { get; set; }

    /// <summary>
    /// Имя игрока
    /// </summary>
    /// <remarks>В синглплеере устанавливается как Герой</remarks>
    public string Name { get; }
    /// <summary>
    /// Обрабатывает перемещение персонажа, вводимое с клавиатуры
    /// </summary>
    /// <param name="w">Вверх</param>
    /// <param name="s">Назад</param>
    /// <param name="a">Вправо</param>
    /// <param name="d">Влево</param>
    /// <returns></returns>
    bool DirectionalMove(bool w, bool s, bool a, bool d);

}