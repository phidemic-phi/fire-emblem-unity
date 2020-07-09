using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironsword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.D;
        might = 6;
        hit = 90;
        crit = 0;
        weight = 7;
        min_range = 1;
        max_range = 1;
        weapon_exp = 2;

        max_uses = 50;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Iron Sword";
        type = Item_type.sword;
    }

    public static ironsword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<ironsword>();
        data.Init(num);
        return data;
    }


}