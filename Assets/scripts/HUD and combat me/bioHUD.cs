using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bioHUD : MonoBehaviour
{


    public List<TMPro.TextMeshProUGUI> elements;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            elements.Add(transform.GetChild(i).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI);
        }
    }
    public void updating(unit person)
    {
        elements[0].text = person.mum.teamName;
        elements[1].text = person.mum.lordName();
    }
}