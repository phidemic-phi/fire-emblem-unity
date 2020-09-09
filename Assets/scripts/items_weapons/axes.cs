﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this is all the axes and their data
/// </summary>





public class bronzeaxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.E;
        might = 5;
        hit = 85;
        crit = -100;
        weight = 7;
        min_range = 1;
        max_range = 1;
        weapon_exp = 2;

        max_uses = 50;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 165;
        named = "Bronze Axe";
        type = Item_type.axe;
    }

    public static bronzeaxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<bronzeaxe>();
        data.Init(num);
        return data;
    }


}

public class ironaxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.D;
        might = 8;
        hit = 80;
        crit = 0;
        weight =11;
        min_range = 1;
        max_range = 1;
        weapon_exp = 2;

        max_uses = 50;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 166;
        named = "Iron Axe";
        type = Item_type.axe;
    }

    public static ironaxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<ironaxe>();
        data.Init(num);
        return data;
    }


}

public class handaxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.D;
        might = 9;
        hit = 70;
        crit = 0;
        weight = 12;
        min_range = 1;
        max_range = 2;
        weapon_exp = 2;

        max_uses = 25;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 177;
        named = "Hand Axe";
        type = Item_type.axe;
    }

    public static handaxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<handaxe>();
        data.Init(num);
        return data;
    }


}

public class shortaxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might =12;
        hit = 60;
        crit = 0;
        weight = 13;
        min_range = 1;
        max_range = 2;
        weapon_exp = 3;

        max_uses = 15;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 178;
        named = "Short Axe";
        type = Item_type.axe;
    }

    public static shortaxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<shortaxe>();
        data.Init(num);
        return data;
    }


}

public class tomahawk : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.S;
        might =15;
        hit = 65;
        crit = 5;
        weight = 17;
        min_range = 1;
        max_range = 2;
        weapon_exp = 5;

        max_uses = 15;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 179;
        named = "Tomahawk";
        type = Item_type.axe;
    }

    public static tomahawk CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<tomahawk>();
        data.Init(num);
        return data;
    }


}

public class steelaxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.C;
        might =11;
        hit = 75;
        crit = 0;
        weight = 15;
        min_range = 1;
        max_range = 1;
        weapon_exp = 3;

        max_uses = 40;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 167;
        named = "Steel Axe";
        type = Item_type.axe;
    }

    public static steelaxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<steelaxe>();
        data.Init(num);
        return data;
    }


}

public class killeraxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might = 10;
        hit = 75;
        crit =30;
        weight = 12;
        min_range = 1;
        max_range = 1;
        weapon_exp = 2;

        max_uses = 30;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 174;
        named = "Killer Axe";
        type = Item_type.axe;
    }

    public static killeraxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<killeraxe>();
        data.Init(num);
        return data;
    }


}

public class silveraxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.A;
        might = 14;
        hit = 70;
        crit = 00;
        weight = 14;
        min_range = 1;
        max_range = 1;
        weapon_exp = 5;

        max_uses = 30;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 168;
        named = "Silver Axe";
        type = Item_type.axe;
    }

    public static silveraxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<silveraxe>();
        data.Init(num);
        return data;
    }


}

public class silverpoleaxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.A;
        might = 18;
        hit = 60;
        crit = 00;
        weight = 19;
        min_range = 1;
        max_range = 1;
        weapon_exp = 5;

        max_uses = 30;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 171;
        named = "Silver Poleaxe";
        type = Item_type.axe;
    }

    public static silverpoleaxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<silverpoleaxe>();
        data.Init(num);
        return data;
    }


}

public class steelpoleaxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might = 15;
        hit = 60;
        crit = 00;
        weight = 20;
        min_range = 1;
        max_range = 1;
        weapon_exp = 4;

        max_uses = 35;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 170;
        named = "Steel Poleaxe";
        type = Item_type.axe;
    }
   

    public static steelpoleaxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<steelpoleaxe>();
        data.Init(num);
        return data;
    }


}

public class ironpoleaxe : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.C;
        might = 12;
        hit = 65;
        crit = 00;
        weight = 16;
        min_range = 1;
        max_range = 1;
        weapon_exp = 3;

        max_uses = 40;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 169;
        named = "Iron Poleaxe";
        type = Item_type.axe;
    }

    public static ironpoleaxe CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<ironpoleaxe>();
        data.Init(num);
        return data;
    }


}