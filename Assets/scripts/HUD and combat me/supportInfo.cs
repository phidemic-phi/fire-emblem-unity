using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class supportInfo : MonoBehaviour
{


    public List<TMPro.TextMeshProUGUI> elements;
 
    HUD hud;
    public GameObject skillholder;
    Image circle;
     List<GameObject> skills;
    List<skillHUD> skillScript;
  
    // Start is called before the first frame update
    void Start()
    {
   
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent(typeof(HUD)) as HUD;
        elements = new List<TMPro.TextMeshProUGUI>();
        skills = new List<GameObject>();
        skillScript = new List<skillHUD>();
        for (int i = 1; i < transform.childCount -1; i++)
        {
            elements.Add(transform.GetChild(i).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI);
        }
        circle = transform.GetChild(transform.childCount-1).GetComponent(typeof(Image)) as Image;
    }

    public void updating(unit person)
    {
        elements[0].text = "";
        if (person.supports())
        {
            elements[1].text = Convert.ToString(person.suppAttack);
            elements[2].text = Convert.ToString(person.suppDef);
            elements[3].text = Convert.ToString(person.suppHit);
            elements[4].text = Convert.ToString(person.suppAvoid);
            
        }
        else
        {
            elements[1].text = "0";
            elements[2].text = "0";
            elements[3].text = "0";
            elements[4].text = "0";

        }
        if (person.support != null)
        {
            elements[0].text = person.support.name;
        }
        elements[6].text = Convert.ToString(person.skill_use);
        elements[7].text = Convert.ToString(person.skill_cap);
        circle.fillAmount = (float)person.skill_use / (float)person.skill_cap;



        if (skills.Count < person.skills.Count)
        {
            for (int i = skills.Count; i < person.skills.Count; i++)
            {
                skills.Add(Instantiate(skillholder, transform, false));
                skillScript.Add(skills[i].GetComponent<skillHUD>());
                Vector3 temp = new Vector3(40f, 7f - (i * 5), 0);
                skillScript[i].loc(temp);
            }
        }
        else
        {
            for (int i =0; i< skills.Count; i++)
            {
                skills[i].SetActive(false);
            }
        }

        for(int i=0;i< person.skills.Count; i++)
        {
            skills[i].SetActive(true);
            skillScript[i].take(person.skills[i], hud);
        }
    }
}