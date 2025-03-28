using System;

public interface IDestroyable : IEntity
{
    float HP { get; set; }
    /// <summary>
    /// Стихия объекта
    /// </summary>
    Force Force { get; set; }
    /// <summary>
    /// Размер объекта
    /// </summary>
    /// <remarks>
    /// Используется для расчёта попадания
    /// </remarks>
    float RectangleSize { get; set; }

    /// <summary>
    /// Шанс "попадания" проджектайла. При "непопадании" проджектайллетит дальше
    /// </summary>
    float Coverage { get; set; }

    Action<float, Force> GotHit { get; set; }
    Action Destroyed { get; set; }
}
