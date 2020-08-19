using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancel : combatSkill
{
    public override bool isTrigger(unit user, combatmed med, combatOrder place)
    {
        if (place == combatOrder.attack)
        {
            if (user.speed > Random.Range(0, 99))
            {
                med.activate(named);
                if (med.order[0] == combatOrder.attack)
                {
                    med.order.Remove(combatOrder.defend);
                    return false;
                }
                else if (med.order[0] == combatOrder.defend)
                {
                    med.order.Remove(combatOrder.attack);
                    return false;
                }
            }
        }
        return false;
    }
    public void Init()
    {

        named = "Cancel";

    }

    public static skill CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<cancel>();
        data.Init();
        return data;
    }

}
