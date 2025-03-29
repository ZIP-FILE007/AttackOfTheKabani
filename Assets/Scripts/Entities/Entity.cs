using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Entity : IEntity
    {
        public Entity(GameSession session)
        {
            Session = session;
        }

        public Vector2 Position { get; set; }
        public string Name { get; set; } = "Неизвестная сущность";

        public GameSession Session {get; protected set;}
    }
}
