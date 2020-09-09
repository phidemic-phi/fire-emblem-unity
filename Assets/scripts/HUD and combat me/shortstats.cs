using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shortstats : MonoBehaviour
{

    TMPro.TextMeshProUGUI attack;
    TMPro.TextMeshProUGUI hit;
    TMPro.TextMeshProUGUI avoid;
    TMPro.TextMeshProUGUI dodge;
    TMPro.TextMeshProUGUI minRange;
    TMPro.TextMeshProUGUI maxRange;
    TMPro.TextMeshProUGUI dash;
    TMPro.TextMeshProUGUI crit;
    TMPro.TextMeshProUGUI AS;
    public combatmed med;
    // Start is called before the first frame update
    void Start()
    {
        med = GameObject.FindGameObjectWithTag("CombatMed").GetComponent(typeof(combatmed)) as combatmed;
        attack = transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        hit = transform.GetChild(1).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        avoid = transform.GetChild(2).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        crit = transform.GetChild(3).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        dodge = transform.GetChild(4).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        minRange = transform.GetChild(5).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        maxRange = transform.GetChild(6).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        dash = transform.GetChild(7).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        AS = transform.GetChild(8).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;

    }

    public void unmove(unit person)
    {


        if (med.supports(person) == true)
        {
            attack.text = Convert.ToString(person.attack + person.suppAttack);

            hit.text = Convert.ToString(person.hit + person.suppHit);

            avoid.text = Convert.ToString(person.avoid + person.suppAvoid);
        }
        else
        {
            attack.text = Convert.ToString(person.attack);

            hit.text = Convert.ToString(person.hit);

            avoid.text = Convert.ToString(person.avoid);
        }
        dodge.text = Convert.ToString(person.dodge);
        if(person.crit< 0)
            crit.text = "0";
        else
            crit.text = Convert.ToString(person.crit);

        AS.text = Convert.ToString(person.AS);

        minRange.text = Convert.ToString(person.min_range);
        if (person.max_range == person.min_range)
        {
            maxRange.text = "";
            dash.text = "";
        }
        else
        {
            maxRange.text = Convert.ToString(person.max_range);
            dash.text = "-";
        }
    }
}
