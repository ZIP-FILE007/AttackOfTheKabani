using UnityEngine;
#nullable enable
public class Player : IPlayer
{
    public Player(int playerId, string name)
    {
        PlayerId = playerId;
        Name = name;
    }

    public int PlayerId {get; protected set;}
    public string Name {get; protected set;}

    public IPersonage? ControlledPersonage {get; protected set;}

    public void Move(Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public bool TakeControlOverEntity(IPersonage entity)
    {
        throw new System.NotImplementedException();
    }
}
