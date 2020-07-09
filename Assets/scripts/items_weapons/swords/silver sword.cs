using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silversword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.A;
        might =12;
        hit = 80;
        crit = 0;
        weight = 10;
        min_range = 1;
        max_range = 1;
        weapon_exp = 5;

        max_uses = 30;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Silver Sword";
        type = Item_type.sword;
    }

    public static silversword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<silversword>();
        data.Init(num);
        return data;
    }


}