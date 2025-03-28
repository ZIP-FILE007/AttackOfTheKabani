using System.Collections.Generic;

public interface IPersonage : IDestroyable, IMovable 
{
    List<IItem> Inventory { get; set; }

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
