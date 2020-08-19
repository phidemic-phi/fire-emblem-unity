using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weapon : item
{
    public Weapon_rank needed;
    public int might;
    public int hit;
    public int crit;
    public int weight;
    public int min_range;
    public int max_range;
    public int weapon_exp;
  

    public override bool use(unit person)
    {
        uses--;
        if (uses <= 0)
            return true;
        return false;
    }
    /// <summary>
    /// gets the commands that can be used on this
    /// </summary>
    /// <returns>a list of strings that each are command that can be used on this item</returns>
    public override List<string> commandList() {
        List<string> commands = new List<string>();
        commands.Add("Equip");
        commands.Add("Drop");

        return commands;

    }
    /// <summary>
    /// gets the stats from the weapon, all passed by referance
    /// </summary>
    /// <param name="might">strength of the weapon</param>
    /// <param name="hit">hit of the weapon</param>
    /// <param name="crit">crit of the weapon</param>
    /// <param name="weight">weight of the weapon</param>
    /// <param name="min_range">min range of the weapon</param>
    /// <param name="max_range">max range of the weapon</param>
    /// <param name="dmg">type of damage the weapon does</param>
    public override void getStats(ref int might, ref int hit, ref int crit, ref int weight, ref int min_range, ref int max_range, ref damageType dmg)
    {
        might = this.might;
        hit = this.hit;
        weight = this.weight;
        min_range = this.min_range;
        max_range = this.max_range;
        crit = this.crit;
        dmg = damage;
    }
    /// <summary>
    /// checks to see if you can use this weapon
    /// </summary>
    /// <param name="person">the person trying to use the weapon</param>
    /// <returns></returns>
    public override bool equipable(unit person)
    {
        switch (type)
        {
            case Item_type.consumable:
                return false;
            case Item_type.axe:
                if (person.axe_rank >= needed)
                    return true;
                return false;
            case Item_type.sword:
                if (person.sword_rank >= needed)
                    return true;
                return false;
            case Item_type.lance:
                if (person.lance_rank >= needed)
                    return true;
                return false;
            case Item_type.knife:
                if (person.knives_rank >= needed)
                    return true;
                return false;
            case Item_type.bow:
                if (person.bow_rank >= needed)
                    return true;
                return false;
            case Item_type.strike:
                if (person.strike_rank >= needed)
                    return true;
                return false;
            case Item_type.staff:
                if (person.staves_rank >= needed)
                    return true;
                return false;
            case Item_type.fire:
                if (person.fire_rank >= needed)
                    return true;
                return false;
            case Item_type.wind:
                if (person.wind_rank >= needed)
                    return true;
                return false;
            case Item_type.light:
                if (person.light_rank >= needed)
                    return true;
                return false;
            case Item_type.thunder:
                if (person.thunder_rank >= needed)
                    return true;
                return false;
            case Item_type.dark:
                if (person.dark_rank >= needed)
                    return true;
                return false;
            default:
                return false;


        }
        
    }
}
