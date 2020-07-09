using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windedge : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.D;
        might = 6;
        hit = 60;
        crit = 0;
        weight = 10;
        min_range = 1;
        max_range = 2;
        weapon_exp = 2;

        max_uses = 20;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Wind Edge";
        type = Item_type.sword;
    }

    public static windedge CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<windedge>();
        data.Init(num);
        return data;
    }


}
