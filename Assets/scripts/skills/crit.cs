using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crit5 : boosterSkill
{
    
     
	public override void statBooster(unit user)
	{
		user.crit+=5;
	
	}


    public void Init()
    {

        named = "crit + 5";
        
    }

    public static skill CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<crit5>();
        data.Init();
        return data;
    }

}




public class crit10 : boosterSkill
{
    
	public override void statBooster(unit user)
	{
		user.crit+=10;
	
	}


    public void Init()
    {

        named = "crit + 10";
        
    }

    public static skill CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<crit10>();
        data.Init();
        return data;
    }

}


public class crit15 : boosterSkill
{
    
	public override void statBooster(unit user)
	{
		user.crit+=15;
	
	}


    public void Init()
    {

        named = "crit + 15";
        
    }

    public static skill CreateInstance()
    {
        var data = ScriptableObject.CreateInstance<crit15>();
        data.Init();
        return data;
    }

}
