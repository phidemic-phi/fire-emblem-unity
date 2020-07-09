using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bronzesword :weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.E;
        might = 3;
        hit = 95;
        crit = -100;
        weight = 5;
        min_range = 1;
        max_range = 1;
        weapon_exp = 1;

        max_uses = 50;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Bronze Sword";
        type = Item_type.sword;
    }

    public static bronzesword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<bronzesword>();
        data.Init(num);
        return data;
    }


}