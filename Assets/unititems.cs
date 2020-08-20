using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unititems : MonoBehaviour
{
  
   
    List<TMPro.TextMeshProUGUI> elements;
    Color holder;

    // Start is called before the first frame update
    void Start()
    {
        elements = new List<TMPro.TextMeshProUGUI>();

        for(int i = 1; i< transform.childCount; i++)
        {
            elements.Add(transform.GetChild(i).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI);
        }
        holder = elements[45].color;
       
    }

    public void updating(unit person)
    {
        for (int i = 0; i < 46; i++)
        {
            elements[i].text = "";
        }
        if (person.invintory.Count > 0)
        {
            for (int i=0; i< person.invintory.Count; i++)
            {
                elements[i].text = person.invintory[i].named;

                elements[i+8].text = Convert.ToString(person.invintory[i].uses);
                elements[i+16].text = Convert.ToString(person.invintory[i].max_uses);
                elements[i+24].text = "/";
            }
        }

        elements[32].text = Convert.ToString(person.strength);
        elements[33].text = Convert.ToString(person.magic);
        elements[34].text = Convert.ToString(person.skill);
        elements[35].text = Convert.ToString(person.speed);
        elements[36].text = Convert.ToString(person.luck);
        elements[37].text = Convert.ToString(person.defence);
        elements[38].text = Convert.ToString(person.resistance);

        if(person.tempStrength > 0)
        {
            elements[39].color = holder;
            elements[39].text = "+ " + Convert.ToString(person.tempStrength);
        }
        if (person.tempMagic > 0)
        {
            elements[40].color = holder;
            elements[40].text = "+ " + Convert.ToString(person.tempMagic);
        }
        if (person.tempSkill > 0)
        {
            elements[41].color = holder;
            elements[41].text = "+ " + Convert.ToString(person.tempSkill);
        }
        if (person.tempSpeed > 0)
        {
            elements[42].color = holder;
            elements[42].text = "+ " + Convert.ToString(person.tempSpeed);
        }
        if (person.tempLuck > 0)
        {
            elements[43].color = holder;
            elements[43].text = "+ " + Convert.ToString(person.tempLuck);
        }
        if (person.tempDefence> 0)
        {
            elements[44].color = holder;
            elements[44].text = "+ " + Convert.ToString(person.tempDefence);
        }
        if (person.tempResistance > 0)
        {
            elements[45].color = holder;
            elements[45].text = "+ " + Convert.ToString(person.tempResistance);
        }


        if (person.tempStrength < 0)
        {
            elements[39].color = Color.red;
            elements[39].text = "- " + Convert.ToString(person.tempStrength * -1);
        }
        if (person.tempMagic < 0)
        {
            elements[40].color = Color.red;
            elements[40].text = "- " + Convert.ToString(person.tempMagic *-1);
        }
        if (person.tempSkill < 0)
        {
            elements[41].color = Color.red;
            elements[41].text = "- " + Convert.ToString(person.tempSkill * -1);
        }
        if (person.tempSpeed < 0)
        {
            elements[42].color = Color.red;
            elements[42].text = "- " + Convert.ToString(person.tempSpeed * -1);
        }
        if (person.tempLuck < 0)
        {
            elements[43].color = Color.red;
            elements[43].text = "- " + Convert.ToString(person.tempLuck * -1);
        }
        if (person.tempDefence < 0)
        {
            elements[44].color = Color.red;
            elements[44].text = "- " + Convert.ToString(person.tempDefence * -1);
        }
        if (person.tempResistance < 0)
        {
            elements[45].color = Color.red;
            elements[45].text = "- " + Convert.ToString(person.tempResistance * -1);
        }
    }
}
