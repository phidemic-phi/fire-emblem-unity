using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shove : commandSkill
{
    
    public override bool targets(unit user)
    {
        if (user.anyNextTo(this) == true)
        {
            
                return true;
        }
        return false;
    }
    
    public override void mark(unit user)
    {
        user.skillMarkAll();
    }
    public override void commanded(unit user, unit effected)
    {
        Vector3 location = user.transform.position;
        Vector3 position = effected.transform.position;

        if (location + Vector3.forward == position)
        {
            effected.going.Add(Directions.up);
        }
        else if (location + Vector3.back == position)
        {
            effected.going.Add(Directions.down);
        }
        else if (location + Vector3.left == position)
        {
            effected.going.Add(Directions.left);
        }
        else if (location + Vector3.right == position)
        {
            effected.going.Add(Directions.right);
        }
    }
    public override bool useable(unit user, Vector3 direction, map Map)
    {
        
        Vector3 location = user.transform.position;
        location += direction + direction;
        return Map.waitAble(location);
    }



    public void Init()
    {

        named = "Shove";
        tex = 9;
        cap = 5;
        locked = true;
    }

    public static skill CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<shove>();
        data.Init();
        return data;
    }

}
