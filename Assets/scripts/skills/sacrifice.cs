using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sacrifice : commandSkill
{
    public override bool targets(unit user)
    {
        if (user.allyNextTo(this) == true)
        {

            return true;
        }
        return false;
    }
    /// <summary>
    /// marks the squares and units that the skill can be used on
    /// </summary>
    /// <param name="user"></param>
    public override void mark(unit user)
    {
        user.skillMarkAlly();
    }
    public override void commanded(unit user, unit effected)
    {
        int amount = effected.max_hp - effected.hp;
        if (amount < user.hp)
        {
            user.takeDamage(amount);
            effected.heal(amount);
            effected.removeNegStatus();
           
        }
        else
        {
            amount = user.max_hp - user.hp;
            user.takeDamage(amount);
            effected.heal(amount);
            effected.removeNegStatus();
            
        }
    }
    public override bool useable(unit user, Vector3 direction, map Map)
    {
        Vector3 location = user.transform.position + direction;
        unit target = user.mum.getAlly(location);
        if (target == null || target.hp == target.max_hp)
        {
            return false;
        }
        else
            return true;
    }



    public void Init()
    {

        named = "Sacrifice";
        tex = 8;
        cap = 0;
        locked = true;
    }

    public static skill CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<sacrifice>();
        data.Init();
        return data;
    }

}
