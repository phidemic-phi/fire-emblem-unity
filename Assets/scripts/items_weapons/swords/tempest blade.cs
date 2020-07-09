using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempestblade : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.S;
        might = 18;
        hit = 55;
        crit = 5;
        weight = 15;
        min_range = 1;
        max_range = 2;
        weapon_exp = 5;

        max_uses = 20;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Tempest Blade";
        type = Item_type.sword;
    }

    public static tempestblade CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<tempestblade>();
        data.Init(num);
        return data;
    }


}