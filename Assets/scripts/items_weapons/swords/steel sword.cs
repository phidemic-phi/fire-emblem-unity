using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steelsword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.C;
        might = 9;
        hit = 85;
        crit = 0;
        weight = 11;
        min_range = 1;
        max_range = 1;
        weapon_exp = 3;

        max_uses = 40;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Steel Sword";
        type = Item_type.sword;
    }

    public static steelsword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<steelsword>();
        data.Init(num);
        return data;
    }


}