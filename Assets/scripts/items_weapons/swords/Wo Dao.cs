using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wodao : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might = 7;
        hit = 90;
        crit =20;
        weight = 7;
        min_range = 1;
        max_range = 1;
        weapon_exp = 3;

        max_uses = 30;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Wo Dao";
        type = Item_type.sword;
    }

    public static wodao CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<wodao>();
        data.Init(num);
        return data;
    }


}