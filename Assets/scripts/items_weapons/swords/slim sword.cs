using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimsword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.E;
        might = 2;
        hit =100;
        crit = 5;
        weight = 3;
        min_range = 1;
        max_range = 1;
        weapon_exp = 1;

        max_uses = 35;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Slim Sword";
        type = Item_type.sword;
    }

    public static slimsword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<slimsword>();
        data.Init(num);
        return data;
    }


}