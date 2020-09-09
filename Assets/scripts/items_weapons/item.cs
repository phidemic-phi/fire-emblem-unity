using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// base class for all items
/// split into two main types consumables and weapons
/// </summary>
public abstract class item : ScriptableObject
{
    public int uses;
    public int max_uses;
    public string named;
    public int icon;
    public Item_type type;
    public damageType damage = damageType.physical;


    public abstract bool use(unit person);
    public abstract void getStats(ref int might, ref int hit, ref int crit, ref int weight, ref int min_range, ref int max_range, ref damageType dmg);
    public abstract bool equipable(unit person);
    public abstract List<string> commandList();

}
