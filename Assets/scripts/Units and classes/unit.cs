using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * base class of all units.
 as such it holds a lot of the information that is used as a base for everything that you interact with in the game
 used in joint with the unadded character information to make a full unit
 * 
 */
public abstract class unit : MonoBehaviour
{
   
    public ID me;
    public bool drop_item;

    public List<itemName> starting_invintory;
    public List<int> item_uses;

    public int level;

    public int max_hp;
    public int strength;
    public int magic;
    public int speed;
    public int skill;
    public int luck;
    public int defence;
    public int resistance;


    //affinity for supports and stuff
    public Affinity affinity;


    //basic information that is very visable
    public int exp;
   
    public int hp;
    public unitState state;
    public MoveType movetype;
    public bool has_weapon;
    //where items go
  
    private int max_invintory = 8;
    

    
   

    public List<skill> skills;
    public List<item> invintory;

    //containers for every stat
  

    public int tempStrength =0;
    public int tempMagic =0;
    public int tempSpeed =0;
    public int tempSkill = 0;
    public int tempLuck = 0;
    public int tempDefence = 0;
    public int tempResistance = 0;

    // the class caps as every class has unique ones
    public int cap_max_hp;
    public int cap_str;
    public int cap_mag;
    public int cap_speed;
    public int cap_skill;
    public int cap_luck;
    public int cap_def;
    public int cap_res;

    //class growth rates that are combined with personal/personality growthes to make the full value
    public int growth_max_hp;
    public int growth_str;
    public int growth_mag;
    public int growth_speed;
    public int growth_skill;
    public int growth_luck;
    public int growth_def;
    public int growth_res;

    // the quick calculated states for combat to use
    public int move;
    public int attack;
     public int AS;
    public int hit;
    public int crit;
    public int avoid;
    public int dodge;
    public int max_range;
    public int min_range;

    // for skills (last thing to add)
    public int skill_cap;
    public int skill_use;

    // exp for weapon ranks to know when better ones can be used
    public int sword_exp;
    public int lance_exp;
    public int axe_exp;
    public int bow_exp;
    public int knives_exp;
    public int strike_exp;
    public int fire_exp;
    public int thunder_exp;
    public int wind_exp;
    public int light_exp;
    public int dark_exp;
    public int staves_exp;

    // what rank you are with all the weapons
    public Weapon_rank sword_rank;
    public Weapon_rank lance_rank;
    public Weapon_rank axe_rank;
    public Weapon_rank bow_rank;
    public Weapon_rank knives_rank;
    public Weapon_rank strike_rank;
    public Weapon_rank fire_rank;
    public Weapon_rank thunder_rank;
    public Weapon_rank wind_rank;
    public Weapon_rank light_rank;
    public Weapon_rank dark_rank;
    public Weapon_rank staves_rank;

  
    
    //are you the lord for seizing and stuff
    //can't put in personlization thing as RD has more then one
    public bool lord;

    // list holding how you moved
    public List<Directions> going = new List<Directions>();


    //movement holder varibles
    private float tempX;

    private float tempZ;
    private Vector3 oldLocation;
    

    // the player that i belong to
    public player mum;

    //who i really am
    public person personallity;

    public string className;

    private void Start()
    {
       

      
        // gets parent, will also make the weapons from a file in the future
        // and updates the stats withen me 
        mum = GetComponentInParent(typeof(player)) as player;
        createInvintory();
        setValue();
        equiping();
        updateStats();
        tempX = transform.position[0];
        tempZ = transform.position[2];
        if (me != ID.none)
        {
            setPerson();
        }
    }
  
    // Update is called once per frame

        // movement function
        //removes things you of the going list and moves in that way
    void Update()
    {

        if (going.Count != 0)
        {
            
            Vector3 temp = new Vector3(0f, 0f, 0f);
            if (going[going.Count - 1] == Directions.down && transform.position[2] > tempZ - 1)
            {
                temp[2] = -0.05f;
                transform.position = transform.position + temp;
            }
            else if (going[going.Count - 1] == Directions.up && transform.position[2] < tempZ + 1)
            {
                temp[2] = 0.05f;
                transform.position = transform.position + temp;
            }
            else if (going[going.Count - 1] == Directions.left && transform.position[0] > tempX - 1)
            {
                temp[0] = -0.05f;
                transform.position = transform.position + temp;
            }
            else if (going[going.Count - 1] == Directions.right && transform.position[0] < tempX + 1)
            {
                temp[0] = 0.05f;
                transform.position = transform.position + temp;
            }
            else
            {
                going.RemoveAt(going.Count - 1);
                tempX = Mathf.Round(transform.position[0]);
                tempZ = Mathf.Round(transform.position[2]);
                temp[0] = tempX;
                temp[1] = transform.position[1];
                temp[2] = tempZ;
                transform.position = temp;
            }

            // did I stop moving check
            if (going.Count == 0 && state == unitState.moving)
            {
                mum.hud.update();
                state = unitState.menus;
            }
        }
    }

    // auto equips the next item that I can hold
    public void equiping()
    {
        if (has_weapon == false)
        {
            for (int i =0; i< invintory.Count; i++)
            {
                if (invintory[i].equipable(this) == true)
                {
                    item temp;
                    for(int k = i; k > 0; k--)
                    {
                        temp = invintory[k - 1];
                        invintory[k - 1] = invintory[k];
                        invintory[k] = temp;
                    }
                    has_weapon = true;
                    updateStats();
                    return;
                }
                    
            }
        }
    }


    //equip this specific weapon if I can else nothing
    public bool equip(int num)
    {
        if (invintory[num].equipable(this))
        {
            item temp;
            for( int i = num; i > 0; i--)
            {
                temp = invintory[i - 1];
                invintory[i - 1] = invintory[i];
                invintory[i] = temp;
            }
            has_weapon = true;
            updateStats();
            return true;
        }
        return false;
    }

    // drops the item, if weapon that you are holding will equip another
    public void drop(int num)
    {
        invintory.RemoveAt(num);
        if (num == 0)
        {
            has_weapon = false;
            equiping();
        }
    }

    // for the use command on an item
    public void use(int num)
    {
        if (invintory[num].use(this) == true)
            drop(num);
    }

    //uneqip the current weapon
    public void unequip()
    {
       has_weapon = false;
        updateStats();
    }

    // updates combat stats with weapon stats
    public void updateStats()
    {
        clearTemps();
        constSkills();
        int mt =0 , Whit = 0, Wcrit = 0, weight = 0, min = 0, max = 0;
        damageType dmg = damageType.physical;
        if (has_weapon == true)
        { 
            invintory[0].getStats(ref mt, ref Whit, ref Wcrit,ref weight,ref min,ref max,ref dmg);       
            if (dmg == damageType.magical)
                attack = mt + getMagic();
            else if (dmg == damageType.physical)
                attack = mt + getStrength();
        }
        else
            attack = 0;
        AS = getSpeed() - weight + getStrength();
        if (AS > getSpeed())
            AS = getSpeed();
        if (AS < 0)
            AS = 0;
        hit += Whit + (getSkill() *2);
        crit += Wcrit + (getSkill()/4);
        avoid += AS * 2 + getLuck();
        dodge += getLuck();
        max_range += max;
        min_range += min;


        
    }
    public void clearTemps()
    {
        hit = 0;
        crit = 0;
        avoid = 0;
        dodge = 0;
        max_range = 0;
        min_range = 0;
        tempStrength = 0;
        tempMagic = 0;
        tempSpeed = 0;
        tempSkill = 0;
        tempLuck = 0;
        tempDefence = 0;
        tempResistance = 0;

    }
    public int getMagic()
    {
        return magic + tempMagic;
    }
    public int getStrength()
    {
        return strength+ tempStrength;
    }
    public int getSpeed()
    {
        return speed + tempSpeed;
    }
    public int getSkill()
    {
        return skill + tempSkill;
    }
    public int getLuck()
    {
        return luck+ tempLuck;
    }
    public int getDefence()
    {
        return defence+ tempDefence;
    }
    public int getRes()
    {
        return resistance + tempResistance;
    }


    public bool combatSkills(combatmed med)
    {
        bool holder = false;
        for (int i = 0; i < skills.Count; i++)
        {
            if(skills[i].isTrigger(this, med, combatOrder.attack) == true)
            {
                holder = true;
            }
        }
        return holder;
    }
    public void defensiveSkills(combatmed med)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].isTrigger(this, med, combatOrder.defend);
        }
    }
    public void constSkills()
    {
        for(int i =0; i< skills.Count; i++)
        {
            skills[i].statBooster(this);
        }
    }


    //you clicked me, if I have yet to do anything, then go to player to see if its our turn
    //update old location so if move was canceled
   
     void OnMouseDown()
     {
         if (state == unitState.nothing)
         {


             if (mum.unitClicked(this) == true)
             {
                 state = unitState.selected;
                 oldLocation = transform.position;
             }
             else
             {
                 mum.unitFight(this);
             }

         }
         else
         {
             mum.unitFight(this);
         }
         
     }
   

        void OnMouseEnter()
    {
        mum.mouse(this);
    }
    void OnMouseExit()
    {
        mum.dropmouse();
    }




    public void getItem(item dropped)
    {
        if (dropped != null)
        {
            invintory.Add(dropped);
            if (invintory.Count > max_invintory)
            {
                mum.dropMenu(this);
            }
        }
    }

    public item drop()
    {
        if (drop_item == true)
        {
            item temp = invintory[invintory.Count - 1];
            invintory.RemoveAt(invintory.Count - 1);
            return temp;
        }
        return null;
    }

    // this is what takes a list of directions for movement
    public void location(List<Directions> dir)
    {
        tempX = transform.position[0];
        tempZ = transform.position[2];
        going = dir;
        state = unitState.moving;
    }

    //do we have an ally at loaction
    public bool allyHere(Vector3 location)
    {
        return mum.allyHere(location);
    }

    //do we have a foe?
    public bool foeHere(Vector3 location)
    {
        
        return mum.foeHere(location);
    }


    // player calls this on all of its units at start of turn
    public void turnStart()
    {
        state = unitState.nothing;
    }

    // how I take damage, need to update for death
    public bool takeDamage(int damage)
    {
        Vector3 pos = transform.position;
        pos[2]-= 0.5f;
        GameObject temp =Instantiate(mum.god.text, pos, Quaternion.identity, transform);
        TMPro.TextMeshPro texty;
        texty =temp.GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;
       
        texty.text = Convert.ToString(damage);
        Destroy(temp, 2f);
        hp -= damage;
        if (hp < 0)
        {
            mum.death(this);
            return true;
        }
        return false;
    }
    public void miss()
    {
        Vector3 pos = transform.position;
        pos[2] -= 0.5f;
        GameObject temp = Instantiate(mum.god.text, pos, Quaternion.identity, transform);
        TMPro.TextMeshPro texty;
        texty = temp.GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;

        texty.text = "MISS";
        Destroy(temp, 2f);
       
    }
    public void heal(int amount)
    {
        Vector3 pos = transform.position;
        pos[2] -= 0.5f;
        GameObject temp = Instantiate(mum.god.text, pos, Quaternion.identity, transform);
        TMPro.TextMeshPro texty;
        texty = temp.GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;
        texty.color = Color.green;
        print(Convert.ToString(amount));
        texty.text = Convert.ToString(amount);
        Destroy(temp, 2f);
        hp += amount;
        if (hp > max_hp)
            hp = max_hp;
        return;
    }

    //wait command for HUD
    public void wait()
    {
        
        state = unitState.done;
        mum.moveDone();
    }
   
    //cancel mevement from HUD
    public void cancelMove()
    {
        
        if (state == unitState.menus)
        {
            state = unitState.selected;
            transform.position = oldLocation;
            mum.Map.revisTiles();
            
        }
        else if (state == unitState.selected)
        {
            state = unitState.nothing;
            mum.clear();
            
        }
    }
    public void fullCancel()
    {
        transform.position = oldLocation;
        state = unitState.nothing;
        mum.clear();
    }


    public void createInvintory()
    {
        int num = starting_invintory.Count;
        if (num > max_invintory)
        {
            num = max_invintory;
        }
        if (item_uses.Count < num)
        {
            item_uses.Add(0);
            item_uses.Add(0);
            item_uses.Add(0);
            item_uses.Add(0);
            item_uses.Add(0);
            item_uses.Add(0);
            item_uses.Add(0);
            item_uses.Add(0);
        }
        for (int i = 0; i < num; i++)
        {
            switch (starting_invintory[i])
            {
                case itemName.light:

                    invintory.Add(lightning.CreateInstance(item_uses[i]));
                    break;
                case itemName.ironSword:

                    invintory.Add(ironsword.CreateInstance(item_uses[i]));

                    break;
                case itemName.steelSword:
                    invintory.Add(steelsword.CreateInstance(item_uses[i]));
                    break;
                case itemName.herb:
                    invintory.Add(herb.CreateInstance(item_uses[i]));
                    break;
                case itemName.vulnerary:
                    invintory.Add(vulnerary.CreateInstance(item_uses[i]));
                    break;
                case itemName.dracosheild:
                    invintory.Add(dracosheild.CreateInstance(item_uses[i]));
                    break;
                case itemName.ironAxe:
                    invintory.Add(ironaxe.CreateInstance(item_uses[i]));
                    break;
                case itemName.bronzeAxe:
                    invintory.Add(bronzeaxe.CreateInstance(item_uses[i]));
                    break;
            }
        }
    }
    public void setPerson()
    {
        switch (me) {
            case ID.miccy:
                personallity = miccy.CreateInstance();
                break;
            case ID.edward:
                personallity = edward.CreateInstance();
                break;
            case ID.pugo:
                personallity = pugo.CreateInstance();
                break;
            case ID.bandit:
                personallity = bandit.CreateInstance();
                break;
            case ID.leo:
                personallity = leonardo.CreateInstance();
                break;
        }
        name = personallity.named;
    }

     public void skillMarkAll()
    {
        mum.skillMarkAll(this);
    }
    public void skillMarkAlly()
    {
        mum.skillMarkAlly(this);
    }
    public void skillMarkfoe()
    {
        mum.skillMarkFoe(this);
    }
    public bool anyNextTo(skill ability)
    {
        return mum.anyNextTo(this, ability);
    }
    public bool allyNextTo(skill ability)
    {
        return mum.allyNextTo(this, ability);
    }
   public List<string> skillCommands()
    {

        List<string> temp = new List<string>();
        for(int i =0; i< skills.Count; i++)
        {
            if (skills[i].targets(this) == true)
            {
                temp.Add(skills[i].skillName());
            }
        }

        return temp;
    }
    public void removeNegStatus()
    {

    }
  

    //gets the values from  classes
    public abstract void setValue();
    
}


