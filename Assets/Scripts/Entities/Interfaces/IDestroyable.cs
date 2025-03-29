using System;

public interface IDestroyable : IEntity
{
    float HP { get; }
    /// <summary>
    /// Стихия объекта
    /// </summary>
    Force Force { get; }
    /// <summary>
    /// Размер объекта
    /// </summary>
    /// <remarks>
    /// Используется для расчёта попадания
    /// </remarks>
    float RectangleSize { get; }

    ///// <summary>
    ///// Шанс "попадания" проджектайла. При "непопадании" проджектайллетит дальше
    ///// </summary>
    //float Coverage { get; set; }

    Action<float, Force> GotHit { get; set; }
    Action Destroyed { get; set; }

    void Hit(float damage, Force force);

    void LogHit(float damage, Force force);
    void LogDeath();
}
