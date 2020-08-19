using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.E;
        might = 3;
        hit = 100;
        crit = 0;
        weight = 1;
        min_range = 1;
        max_range = 2;
        weapon_exp = 1;

        max_uses = 40;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Light";
        type = Item_type.light;
        damage = damageType.magical;
    }

    public static item CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<lightning>();
        data.Init(num);
        return data;
    }


}