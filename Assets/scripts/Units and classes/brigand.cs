using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brigand : unit
{

    public override void setValue()
    {
        //base stats of the class being set into the unit need to be combined with the personal data
        max_hp += 16;
        hp = max_hp;
        strength += 0;
        magic += 4;
        speed += 5;
        skill += 5;
        luck += 0;
        defence += 1;
        resistance += 7;
        move += 5;
        axe_rank = Weapon_rank.D;
        movetype = MoveType.foot;

        className = "Brigand";

        skills.Add(shove.CreateInstance());

    }
}
