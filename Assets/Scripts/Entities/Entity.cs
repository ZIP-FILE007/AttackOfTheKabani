using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Entity : IEntity
    {
        public Vector2 Position { get; set; }
        public string Name { get; set; } = "Неизвестный объект";
    }
}
