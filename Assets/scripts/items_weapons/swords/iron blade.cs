using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironblade : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.C;
        might =10;
        hit = 70;
        crit = 0;
        weight = 13;
        min_range = 1;
        max_range = 1;
        weapon_exp = 3;

        max_uses = 40;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Steel Blade";
        type = Item_type.sword;
    }

    public static steelblade CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<steelblade>();
        data.Init(num);
        return data;
    }


}