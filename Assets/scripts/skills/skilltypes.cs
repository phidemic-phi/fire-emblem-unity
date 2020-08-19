using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class commandSkill : skill
{

    /// <summary>
    /// can the skill be used
    /// </summary>
    /// <param name="user">the unit that has the skill</param>
    /// <returns></returns>
   
    public override void statBooster(unit user)
	{
	}
    public override bool isTrigger(unit user, combatmed med, combatOrder place)
    {
        return false;
    }
   
}
public abstract class boosterSkill : skill
{
    public override bool targets(unit user)
    {
    return false;	
    }
    public override void mark(unit user)
    {
    }
    public override void commanded(unit user, unit effected)
    {
    }
   
    public override bool useable(unit user, Vector3 direction, map Map)
    {
    	return false;
    }
    public override bool isTrigger(unit user, combatmed med, combatOrder place)
    {
        return false;
    }
   

}
public abstract class combatSkill : skill
{
    public override bool targets(unit user)
    {
    return false;	
    }
    public override void mark(unit user)
    {
    }
    public override void commanded(unit user, unit effected)
    {
    }
    public override void statBooster(unit user)
    {
    }
    public override bool useable(unit user, Vector3 direction, map Map)
    {
    	return false;
    }	
	
	
	
}