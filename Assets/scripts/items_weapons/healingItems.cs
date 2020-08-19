using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herb : consumableItems
{

    public void Init(int num)
    {

       
        max_uses = 10;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Herb";
        type = Item_type.consumable;
     
    }

    public static item CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<herb>();
        data.Init(num);
        return data;
    }
    public override bool use(unit person)
    {
        if (person.hp < person.max_hp)
        {
            person.heal(10);
        }
        uses--;
        if (uses <= 0)
            return true;
        return false;
    }

}

public class vulnerary : consumableItems
{

    public void Init(int num)
    {


        max_uses = 8;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Vulnerary";
        type = Item_type.consumable;

    }

    public static item CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<vulnerary>();
        data.Init(num);
        return data;
    }
    public override bool use(unit person)
    {
        if (person.hp < person.max_hp)
        {
            person.heal(20);
        }
        uses--;
        if (uses <= 0)
            return true;
        return false;
    }

}

public class concoction : consumableItems
{

    public void Init(int num)
    {


        max_uses = 6;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Concoction";
        type = Item_type.consumable;

    }

    public static item CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<concoction>();
        data.Init(num);
        return data;
    }
    public override bool use(unit person)
    {
        if (person.hp < person.max_hp)
        {
            person.heal(40);
        }
        uses--;
        if (uses <= 0)
            return true;
        return false;
    }

}

public class elixer : consumableItems
{

    public void Init(int num)
    {


        max_uses = 3;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Elixer";
        type = Item_type.consumable;

    }

    public static item CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<elixer>();
        data.Init(num);
        return data;
    }
    public override bool use(unit person)
    {
        if (person.hp < person.max_hp)
        {
            person.heal(999);
        }
        uses--;
        if (uses <= 0)
            return true;
        return false;
    }

}



public class dracosheild : consumableItems
{

    public void Init(int num)
    {


        max_uses = 1;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;

        named = "Dracosheild";
        type = Item_type.consumable;

    }

    public static item CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<dracosheild>();
        data.Init(num);
        return data;
    }
    public override bool use(unit person)
    {
        if (person.defence < person.cap_def)
        {
            person.defence += 2;
            if (person.defence > person.cap_def)
                person.defence = person.cap_def;
        }


        uses--;
        if (uses <= 0)
            return true;
        return false;
    }

}