using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steelblade : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might =13;
        hit = 65;
        crit = 0;
        weight = 17;
        min_range = 1;
        max_range = 1;
        weapon_exp = 4;

        max_uses = 35;
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