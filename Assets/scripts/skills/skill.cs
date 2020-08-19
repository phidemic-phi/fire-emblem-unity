using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class skill : ScriptableObject
{
    
   
    public string named;

    public  string skillName()
    {
        return named;
    }

    /// <summary>
    /// can the skill be used
    /// </summary>
    /// <param name="user">the unit that has the skill</param>
    /// <returns></returns>
    public abstract bool targets(unit user);
    public abstract void mark(unit user);
    public abstract void commanded(unit user, unit effected);
    public abstract bool useable(unit user, Vector3 direction, map Map);
    public abstract void statBooster(unit user);
    public abstract bool isTrigger(unit user, combatmed med, combatOrder place);
   
}