using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wodao : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might = 7;
        hit = 90;
        crit =20;
        weight = 7;
        min_range = 1;
        max_range = 1;
        weapon_exp = 3;

        max_uses = 30;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 128;
        named = "Wo Dao";
        type = Item_type.sword;
    }

    public static wodao CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<wodao>();
        data.Init(num);
        return data;
    }


}
public class windedge : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.D;
        might = 6;
        hit = 60;
        crit = 0;
        weight = 10;
        min_range = 1;
        max_range = 2;
        weapon_exp = 2;

        max_uses = 20;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 129;
        named = "Wind Edge";
        type = Item_type.sword;
    }

    public static windedge CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<windedge>();
        data.Init(num);
        return data;
    }


}
public class tempestblade : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.S;
        might = 18;
        hit = 55;
        crit = 5;
        weight = 15;
        min_range = 1;
        max_range = 2;
        weapon_exp = 5;

        max_uses = 20;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 131;
        named = "Tempest Blade";
        type = Item_type.sword;
    }

    public static tempestblade CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<tempestblade>();
        data.Init(num);
        return data;
    }


}
public class stormsword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might = 12;
        hit = 85;
        crit = 0;
        weight = 11;
        min_range = 1;
        max_range = 2;
        weapon_exp = 3;

        max_uses = 20;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 130;
        named = "Strom Sword";
        type = Item_type.sword;
    }

    public static steelsword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<steelsword>();
        data.Init(num);
        return data;
    }


}

public class steelsword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.C;
        might = 9;
        hit = 85;
        crit = 0;
        weight = 11;
        min_range = 1;
        max_range = 1;
        weapon_exp = 3;

        max_uses = 40;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 119;
        named = "Steel Sword";
        type = Item_type.sword;
    }

    public static steelsword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<steelsword>();
        data.Init(num);
        return data;
    }


}
public class steelblade : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might = 13;
        hit = 65;
        crit = 0;
        weight = 17;
        min_range = 1;
        max_range = 1;
        weapon_exp = 4;

        max_uses = 35;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 122;
        named = "Steel Blade";
        type = Item_type.sword;
    }

    public static steelblade CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<steelblade>();
        data.Init(num);
        return data;
    }


}
public class slimsword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.E;
        might = 2;
        hit = 100;
        crit = 5;
        weight = 3;
        min_range = 1;
        max_range = 1;
        weapon_exp = 1;

        max_uses = 35;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 117;
        named = "Slim Sword";
        type = Item_type.sword;
    }

    public static slimsword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<slimsword>();
        data.Init(num);
        return data;
    }


}

public class silversword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.A;
        might = 12;
        hit = 80;
        crit = 0;
        weight = 10;
        min_range = 1;
        max_range = 1;
        weapon_exp = 5;

        max_uses = 30;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 120;
        named = "Silver Sword";
        type = Item_type.sword;
    }

    public static silversword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<silversword>();
        data.Init(num);
        return data;
    }


}
public class silverblade : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.A;
        might = 16;
        hit = 60;
        crit = 0;
        weight = 16;
        min_range = 1;
        max_range = 1;
        weapon_exp = 5;

        max_uses = 30;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 123;
        named = "Silver Sword";
        type = Item_type.sword;
    }

    public static silverblade CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<silverblade>();
        data.Init(num);
        return data;
    }


}
public class killingedge : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.B;
        might = 8;
        hit = 85;
        crit = 30;
        weight = 08;
        min_range = 1;
        max_range = 1;
        weapon_exp = 2;

        max_uses = 3;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 126;
        named = "Killing edge";
        type = Item_type.sword;
    }

    public static killingedge CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<killingedge>();
        data.Init(num);
        return data;
    }


}
public class ironsword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.D;
        might = 6;
        hit = 90;
        crit = 0;
        weight = 7;
        min_range = 1;
        max_range = 1;
        weapon_exp = 2;

        max_uses = 50;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 118;
        named = "Iron Sword";
        type = Item_type.sword;
    }

    public static ironsword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<ironsword>();
        data.Init(num);
        return data;
    }


}
public class ironblade : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.C;
        might = 10;
        hit = 70;
        crit = 0;
        weight = 13;
        min_range = 1;
        max_range = 1;
        weapon_exp = 3;

        max_uses = 40;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 122;
        named = "Steel Blade";
        type = Item_type.sword;
    }

    public static steelblade CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<steelblade>();
        data.Init(num);
        return data;
    }


}

public class bronzesword : weapon
{

    public void Init(int num)
    {

        needed = Weapon_rank.E;
        might = 3;
        hit = 95;
        crit = -100;
        weight = 5;
        min_range = 1;
        max_range = 1;
        weapon_exp = 1;

        max_uses = 50;
        if (num == 0)
            uses = max_uses;
        else
            uses = num;
        icon = 138;
        named = "Bronze Sword";
        type = Item_type.sword;
    }

    public static bronzesword CreateInstance(int num)
    {
        var data = ScriptableObject.CreateInstance<bronzesword>();
        data.Init(num);
        return data;
    }


}