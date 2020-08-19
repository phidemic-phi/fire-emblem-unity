using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pugo : person
{
    public void Init()
    {
        named = "Pugo";
        hp = 0;
        str = 0;
        mag = 0;
        skill = 0;
        luck = 0;
        speed = 0;
        def = 0;
        res = 0;

        tex = "pugo";

    }

    public static person CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<pugo>();
        data.Init();
        return data;
    }
}
public class bandit : person
{
    public void Init()
    {
        named = "Bandit";
        hp = 0;
        str = 0;
        mag = 0;
        skill = 0;
        luck = 0;
        speed = 0;
        def = 0;
        res = 0;

        tex = "bandit";

    }

    public static person CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<bandit>();
        data.Init();
        return data;
    }
}
