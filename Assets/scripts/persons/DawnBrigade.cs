using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miccy : person
{
    public void Init( )
    {
        skills = new List<skillsName>();
        named = "Micaiah";
      hp=0;
      str=0;
      mag=0;
      skill=0;
      luck=0;
      speed=0;
      def=0;
      res=0;

      tex = "miccy";
        bioType = "2";
        skills.Add(skillsName.sacrifice);
     
}

    public static person CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<miccy>();
        data.Init( );
        return data;
    }
}
public class edward : person
{
    public void Init( )
    {
        skills = new List<skillsName>();
        named = "Edward";
        hp = 0;
        str = 0;
        mag = 0;
        skill = 0;
        luck = 0;
        speed = 0;
        def = 0;
        res = 0;

        tex = "ed";
        bioType = "6";
        skills.Add(skillsName.wrath);
    }

    public static person CreateInstance( )
    {
        var data = ScriptableObject.CreateInstance<edward>();
        data.Init( );
        return data;
    }
}
public class leonardo : person
{
    public void Init()
    {
        skills = new List<skillsName>();
        named = "Leonardo";
        hp = 0;
        str = 0;
        mag = 0;
        skill = 0;
        luck = 0;
        speed = 0;
        def = 0;
        res = 0;

        tex = "leo";
        bioType = "3";
        skills.Add(skillsName.cancel);
    }

    public static person CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<leonardo>();
        data.Init();
        return data;
    }
}
//https://fireemblemwiki.org/wiki/File:Portrait_leonardo_fe10.png
