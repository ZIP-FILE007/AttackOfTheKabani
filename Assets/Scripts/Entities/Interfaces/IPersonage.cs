using System;
using System.Collections.Generic;

#nullable enable
public interface IPersonage : IDestroyable, IMovable 
{
    IPlayer? CurrentPlayer { get; set; }
    bool IsPlayerControlled { get; }
    List<IItem> Inventory { get; }
    IItem? SelectedWeapon { get; }
    void SelectWeapon(IItem weapon);
    Action OnMove {get; set;}
}
