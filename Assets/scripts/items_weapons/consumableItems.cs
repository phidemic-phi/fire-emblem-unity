using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class consumableItems : item
{


    
    public override void getStats(ref int might, ref int hit, ref int crit, ref int weight, ref int min_range, ref int max_range, ref damageType dmg) { }
    public override bool equipable(unit person)
    {
        return false;
    }
    public override List<string> commandList()
    {
        List<string> commands = new List<string>();
        commands.Add("Use");
        commands.Add("Drop");

        return commands;
    }
}
