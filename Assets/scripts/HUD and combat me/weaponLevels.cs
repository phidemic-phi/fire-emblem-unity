using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponLevels : MonoBehaviour
{


    public List<TMPro.TextMeshProUGUI> elements;
    Color holder;
    Image affinity;
    HUD hud;
    // Start is called before the first frame update
    void Start()
    {

        elements = new List<TMPro.TextMeshProUGUI>();

        for (int i = 1; i < transform.childCount-1; i++)
        {
            elements.Add(transform.GetChild(i).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI);
        }
        holder = elements[19].color;
        affinity = transform.GetChild(transform.childCount - 1).GetComponent(typeof(Image)) as Image;
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent(typeof(HUD)) as HUD;
    }

    public void updating(unit person)
    {

        for (int i = 0; i <elements.Count; i++)
        {
            elements[i].text = "";
        }
        elements[0].text = con(person.sword_rank);
        elements[1].text = con(person.lance_rank);
        elements[2].text = con(person.axe_rank);
        elements[3].text = con(person.bow_rank);
        elements[4].text = con(person.knives_rank);
        elements[5].text = con(person.strike_rank);
        elements[6].text = con(person.fire_rank);
        elements[7].text = con(person.thunder_rank);
        elements[8].text = con(person.wind_rank);
        elements[9].text = con(person.light_rank);
        elements[10].text = con(person.dark_rank);
        elements[11].text = con(person.staves_rank);


        elements[12].text = Convert.ToString(person.constatution);
        elements[13].text = Convert.ToString(person.weight);

        elements[14].text = Convert.ToString(person.move);
        elements[15].text = Convert.ToString(person.affinity);
        elements[16].text = Convert.ToString(person.race);
        if (person.tempMove > 0)
        {
            elements[19].color = holder;
             elements[19].text = "+ " + Convert.ToString(person.tempMove);
        }
        else if (person.tempMove < 0)
        {
            elements[19].color = Color.red;
            elements[19].text = "- " + Convert.ToString(person.tempMove *-1);
        }
        switch (person.affinity)
        {
            case Affinity.dark:
                affinity.sprite = hud.items[4];
                break;
            case Affinity.earth:
                affinity.sprite = hud.items[1];
                break;
            case Affinity.water:
                affinity.sprite = hud.items[2];
                break;
            case Affinity.wind:
                affinity.sprite = hud.items[6];
                break;
            case Affinity.light:
                affinity.sprite = hud.items[3];
                break;
            case Affinity.heaven:
                affinity.sprite = hud.items[0];
                break;
            case Affinity.thunder:
                affinity.sprite = hud.items[7];
                break;
            case Affinity.fire:
                affinity.sprite = hud.items[5];
                break;
        }
    }

    public string con(Weapon_rank rank)
    {
        switch (rank)
        {
            
            
            case Weapon_rank.E:
                return "E";
                
            case Weapon_rank.D:
                return "D";
                
            case Weapon_rank.C:
                return "C";
                
            case Weapon_rank.B:
                return "B";
                
            case Weapon_rank.A:
                return "A";
            case Weapon_rank.S:
                return "S";
            case Weapon_rank.SS:
                return "SS";

            case Weapon_rank.none:
            
                return "--";
                
        }
        return "--";
    }
}
