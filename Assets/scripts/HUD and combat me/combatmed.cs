using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
combat medator is a thing that handels all the fight calculations and everything regarding dmg and healing
very basic at the moment/unworking
*/





public class combatmed : MonoBehaviour
{
    unit attack, defend;
    tile spotAttack, spotDefend;
    public List<combatOrder> order = new List<combatOrder>();
    int counter;
    public GameObject fancy;
    private Quaternion rotation = new Quaternion();
    public GameObject cam;
    public int amount = 0;
    // this is the function that starts all the combat, and every other function is just a helper to this one
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rotation = cam.transform.rotation;
    }
        void Update()
    {
        if (order.Count > 0)
        {
            if (counter % 240 == 0)
            {
                if (order[0] == combatOrder.attack)
                {
                    order.RemoveAt(0);
                    attacks(attack, defend, spotDefend);
                }
                else
                {
                    order.RemoveAt(0);
                    attacks(defend, attack, spotAttack);
                }

            }
        }
        counter++;
    }
    public void cambatTaker(unit attacker, tile attackSpot, unit defender, tile defendSpot)
    {
        attack = attacker;
        spotAttack = attackSpot;
        defend = defender;
        spotDefend = defendSpot;
        counter = (int)Time.time;
        order.Add(combatOrder.attack);
        

        int dis = distance(attackSpot, defendSpot);
        if (defender.min_range <= dis && defender.max_range >= dis)
        {
            order.Add(combatOrder.defend);
            if (doubleAttack(defender, attacker) == true)
                    order.Add(combatOrder.defend);
        }
        if (doubleAttack(attacker,defender) == true)
        {
            order.Add(combatOrder.attack);
        }
        counter = 0;
    }
    public bool doubleAttack (unit attacker, unit defender)
    {
        if (attacker.AS > defender.AS + 4)
            return true;
        return false;
    }

    public int distance(tile att, tile def)
    {
        int num = 0, num2 = 0;
        Vector3 posAtt = att.transform.position;
        Vector3 posDef = def.transform.position;
        num = (int)posAtt[0] - (int)posDef[0];
        num2 = (int)posAtt[2] - (int)posDef[2];
        return Mathf.Abs(num) + Mathf.Abs(num2);
    }
    // faster random number generation
    public int random()
    {
        return Random.Range(0, 99);
    }


    // a single round of combat
    public void attacks(unit attacker, unit defender, tile spot)
    {
        attacker.combatSkills(this);
        defender.defensiveSkills(this);
        if (accuracy(attacker, defender, spot) > random())
        {
            if (crit(attacker, defender) > random())
            {
                activate("Critical");
                if (defender.takeDamage(damage(attacker, defender, spot) * 3))
                {
                    order.Clear();
                    attacker.getItem(defender.drop());
                }
            }
            else
            {
                if (defender.takeDamage(damage(attacker, defender, spot)))
                {
                    order.Clear();
                    attacker.getItem(defender.drop());
                }
            }
        }
        else
            defender.miss();
        amount = 0;
    }


    // a helper function to calculate accuracy
    public int accuracy(unit attacker, unit defender, tile spot)
    {
        int boost = evasionTriangle(attacker, defender);
        int num = 0;


        num = (attacker.hit - (defender.avoid + spot.avo) + boost);
        if (num > 100)
            return 100;
        else
            return num;



    }


    //helper function to calculate how much damage was done or can be done
    public int damage(unit attacker, unit defender, tile spot)
    {
        int boost = attackTriangle(attacker, defender);
        int temp;
        if (attacker.invintory[0].damage == damageType.physical)
        {
            temp = (attacker.attack - (defender.getDefence() + spot.def)) + boost;
            if (temp < 0)
                return 0;
            else
                return temp;
        }
        else if (attacker.invintory[0].damage == damageType.magical)
        {
            temp = (attacker.attack - (defender.getRes() + spot.res)) + boost;
            if (temp < 0)
                return 0;
            else
                return temp;
        }

        return 0;
    }


    // helper function to determine how high the crit chance is
    public int crit(unit attacker, unit defender)
    {
        int temp = attacker.crit - defender.dodge;
        if (temp < 0)
            return 0;
        else
            return temp;

    }


    // a function to give to AI to determine what to attck
    public int combatscore(unit attacker, unit defender, tile spot)
    {
        return (accuracy(attacker, defender, spot) * damage(attacker, defender, spot));
    }


    // if triangle attack is for or against you
    public triangle advantage(unit attacker, unit defender)
    {
        if (defender.has_weapon)
        {
            Item_type temp = defender.invintory[0].type;
            switch (attacker.invintory[0].type)
            {
                case Item_type.sword:
                    if (temp == Item_type.axe)
                        return triangle.yes;
                    else if (temp == Item_type.lance)
                        return triangle.no;
                    else
                        return triangle.even;
                case Item_type.lance:
                    if (temp == Item_type.sword)
                        return triangle.yes;
                    else if (temp == Item_type.axe)
                        return triangle.no;
                    else
                        return triangle.even;
                case Item_type.axe:
                    if (temp == Item_type.lance)
                        return triangle.yes;
                    else if (temp == Item_type.sword)
                        return triangle.no;
                    else
                        return triangle.even;

                case Item_type.fire:
                    if (temp == Item_type.wind || temp == Item_type.light)
                        return triangle.yes;
                    else if (temp == Item_type.thunder || temp == Item_type.dark)
                        return triangle.no;
                    else
                        return triangle.even;
                case Item_type.wind:
                    if (temp == Item_type.thunder || temp == Item_type.light)
                        return triangle.yes;
                    else if (temp == Item_type.fire || temp == Item_type.dark)
                        return triangle.no;
                    else
                        return triangle.even;
                case Item_type.thunder:
                    if (temp == Item_type.fire || temp == Item_type.light)
                        return triangle.yes;
                    else if (temp == Item_type.wind || temp == Item_type.dark)
                        return triangle.no;
                    else
                        return triangle.even;


                case Item_type.light:
                    if (temp == Item_type.dark)
                        return triangle.yes;
                    else if (temp == Item_type.wind || temp == Item_type.thunder || temp == Item_type.fire)
                        return triangle.no;
                    else
                        return triangle.even;

                case Item_type.dark:
                    if (temp == Item_type.wind || temp == Item_type.thunder || temp == Item_type.fire)
                        return triangle.yes;
                    else if (temp == Item_type.light)
                        return triangle.yes;
                    else
                        return triangle.even;

                default:
                    return triangle.even;
            }
        }
        else
            return triangle.even;
    }

    // the accuracy boost/punishment for having the triangle
    public int evasionTriangle(unit attacker, unit defender)
    {
        triangle temp = advantage(attacker, defender);
        switch (temp)
        {
            case triangle.yes:
                return 10;
            case triangle.no:
                return -10;
            case triangle.even:
                return 0;
        }
        return 0;

    }

    // the damage boost/punishment for having the triangle
    public int attackTriangle(unit attacker, unit defender)
    {
        triangle temp = advantage(attacker, defender);
        switch (temp)
        {
            case triangle.yes:
                return 1;
            case triangle.no:
                return -1;
            case triangle.even:
                return 0;
        }
        return 0;
    }
    public void activate(string name)
    {
        Vector3 pos = cam.transform.position;
        pos -= new Vector3 (2.78f, 1.5f, -3.53f);
        pos -= new Vector3(0f, 0.213f, 0.254f) * amount;
        amount++;
        GameObject temp = Instantiate(fancy, pos, rotation);
        TMPro.TextMeshPro texty;
        texty = temp.GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;
        texty.text = name;
        Destroy(temp, 1f);
    }
}
