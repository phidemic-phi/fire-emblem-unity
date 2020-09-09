using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseoverUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI classnames;
    TMPro.TextMeshProUGUI levels;
    TMPro.TextMeshProUGUI exp;
    TMPro.TextMeshProUGUI hp;
    TMPro.TextMeshProUGUI names;
    TMPro.TextMeshProUGUI max;

    Image ren;


    // Start is called before the first frame update
    void Start()
    {
        classnames = transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        levels = transform.GetChild(1).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        exp = transform.GetChild(2).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        hp = transform.GetChild(3).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        max = transform.GetChild(4).GetComponent< TMPro.TextMeshProUGUI > (); 
        ren = transform.GetChild(7).GetComponent<Image>();
        names = transform.GetChild(8).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;

    }
  

    public void unmove(unit person)
    {



        classnames.text = person.className;

        names.text = person.name;

        levels.text = Convert.ToString(person.level);

        exp.text = Convert.ToString(person.exp);

        hp.text = Convert.ToString(person.hp);

        max.text = Convert.ToString(person.max_hp);

        ren.sprite = Resources.Load<Sprite>(person.personallity.tex);
    }
}
