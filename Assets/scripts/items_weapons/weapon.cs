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
  

    public override void use(unit person) { }
    public override List<string> commandList() {
        List<string> commands = new List<string>(); ;
        commands.Add("Equip");
        commands.Add("Drop");

        return commands;

    }
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
