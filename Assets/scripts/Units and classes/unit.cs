using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class unit : MonoBehaviour
{

    public int exp;
    public int level;
    public int hp;
    public unitState state;
    public MoveType movetype;
    public bool has_weapon;

    public List<item> invintory;
    private int max_invintory = 8;




    public int max_hp;
    public int strength;
    public int magic;
    public int speed;
    public int skill;
    public int luck;
    public int defence;
    public int resistance;

    public int cap_max_hp;
    public int cap_str;
    public int cap_mag;
    public int cap_speed;
    public int cap_skill;
    public int cap_luck;
    public int cap_def;
    public int cap_res;

    public int growth_max_hp;
    public int growth_str;
    public int growth_mag;
    public int growth_speed;
    public int growth_skill;
    public int growth_luck;
    public int growth_def;
    public int growth_res;


    public int move;
    public int attack;
    public int physicalDef;
    public int magicalDef;
    public int AS;
    public int hit;
    public int crit;
    public int avoid;
    public int dodge;
    public int max_range;
    public int min_range;

    public int skill_cap;
    public int skill_use;

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


    public Affinity affinity;
    public bool lord;
    public List<Directions> going = new List<Directions>();

    private float tempX;
    private float tempZ;
    private Vector3 oldLocation;
    
    public player mum;

  

    private void Start()
    {
        mum = GetComponentInParent(typeof(player)) as player;
        lightning temp = lightning.CreateInstance(0);
        invintory.Add(temp);
        ironsword temp2 = ironsword.CreateInstance(0);
        invintory.Add(temp2);
        steelsword temp3 = steelsword.CreateInstance(0);
        invintory.Add(temp3);
        setValue();
        equiping();
        updateStats();
    }
  
    // Update is called once per frame
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

            moving();
         }
    }

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

    public void drop(int num)
    {
        invintory.RemoveAt(num);
        if (num == 0)
            equiping();
    }

    public void use(int num)
    {
        invintory[num].use(this);
    }
    public void unequip()
    {
       has_weapon = false;
        updateStats();
    }

    public void updateStats()
    {
        int mt =0 , hit = 0, crit = 0, weight = 0, min = 0, max = 0;
        damageType dmg = damageType.physical;
        if (has_weapon == true)
        { 
            invintory[0].getStats(ref mt, ref hit, ref crit,ref weight,ref min,ref max,ref dmg);       
            if (dmg == damageType.magical)
                attack = mt + magic;
            else if (dmg == damageType.physical)
                attack = mt + strength;
        }
        else
            attack = 0;
        AS = speed - weight + strength;
        if (AS > speed)
            AS = speed;
        if (AS < 0)
            AS = 0;
        this.hit = hit + (skill *2);
        this.crit = crit + (skill/4);
        avoid = AS * 2 + luck;
        dodge = luck;
        max_range = max;
        min_range = min;
    }




    public void moving()
    {
        if (going.Count == 0)
        {
           
            state = unitState.menus;
        }
    }

    void OnMouseDown()
    {
        if (state == unitState.nothing)
        {
            state = unitState.selected;
            oldLocation = transform.position;
            mum.unitClicked(this);
            
        }
       
    }

    public void location(List<Directions> dir)
    {
        tempX = transform.position[0];
        tempZ = transform.position[2];
        going = dir;
        state = unitState.moving;
    }

    public bool allyHere(Vector3 location)
    {
        return mum.allyHere(location);
    }
    public bool foeHere(Vector3 location)
    {
        
        return mum.foeHere(location);
    }

    public void turnStart()
    {
        state = unitState.nothing;
    }
    public void takeDamage(int damage)
    {
        hp -= damage;
    }
    public void wait()
    {
        
        state = unitState.done;
        mum.moveDone();
    }
   
    public void cancelMove()
    {
        
        if (state == unitState.menus)
        {
            state = unitState.nothing;
            transform.position = oldLocation;
            
        }
        else if (state == unitState.selected)
        {
            state = unitState.nothing;
            mum.clear();
            
        }
    }
    public abstract void setValue();
    
}


