using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bioHUD : MonoBehaviour
{


    public List<TMPro.TextMeshProUGUI> elements;

    public List<Image> curve;
    float baseLoc;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            elements.Add(transform.GetChild(i).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI);
        }
        for (int i = 4; i < transform.childCount; i++)
        {
            curve.Add(transform.GetChild(i).GetComponent(typeof(Image)) as Image);
        }
        baseLoc = -20;
    }
    public void updating(unit person)
    {
        elements[0].text = person.mum.teamName;
        elements[1].text = person.mum.lordName();
        elements[2].text = Convert.ToString(person.getBio());
        Vector3 temp = new Vector3();
        for (int i = 0; i < curve.Count; i++)
        {
            temp = curve[i].transform.localPosition;
            temp[1] = baseLoc;
            curve[i].transform.localPosition = temp;
           
            }
            int offset = -6;
        Vector3 diff = new Vector3(0, 15, 0);
        for (int i = 0; i < curve.Count; i++)
        {
            switch (person.getBio(offset))
            {
                case bioState.Worst:
                    curve[i].color = Color.red;
                    curve[i].transform.position+=(diff*-4);
                    break;
                case bioState.Bad:
                    curve[i].color = Color.red;
                    curve[i].transform.position += (diff * -2);
                    break;
                case bioState.Even:
                    curve[i].color = Color.white;
                    break;
               
                case bioState.Good:
                    curve[i].color = Color.green;
                    curve[i].transform.position += (diff * 2);
                    break;
                case bioState.Best:
                    curve[i].color = Color.green;
                    curve[i].transform.position += (diff * 4);

                    break;
            }
            offset ++;
        }
    }
}