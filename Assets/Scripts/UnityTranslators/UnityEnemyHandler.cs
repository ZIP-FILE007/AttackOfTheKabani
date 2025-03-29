using System;
using UnityEngine;

public class UnityEnemyHandler
{
    public Guid ID; // ID в GameSession
    public GameObject @object;

    public void Replace(Vector2 newPos)
    {
        @object.transform.position = newPos;
    }
}
