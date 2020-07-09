using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killingedge : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might = 8;
        hit = 85;
        crit =30;
        weight = 08;
        min_range = 1;
        max_range = 1;
        weapon_exp = 2;

        max_uses = 3;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Killing edge";
        type = Item_type.sword;
    }

    public static killingedge CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<killingedge>();
        data.Init(num);
        return data;
    }


}