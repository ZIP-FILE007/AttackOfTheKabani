using System.Collections.Generic;

#nullable enable
public interface IPersonage : IDestroyable, IMovable 
{
    IPlayer? CurrentPlayer { get; set; }
    bool IsPlayerControlled { get; }
    List<IItem> Inventory { get; set; }
}
