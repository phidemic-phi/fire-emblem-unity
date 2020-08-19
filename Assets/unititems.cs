using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unititems : MonoBehaviour
{
    TMPro.TextMeshProUGUI slot0;
    TMPro.TextMeshProUGUI slot1;
    TMPro.TextMeshProUGUI slot2;
    TMPro.TextMeshProUGUI slot3;
    TMPro.TextMeshProUGUI slot4;
    TMPro.TextMeshProUGUI slot5;
    TMPro.TextMeshProUGUI slot6;
    TMPro.TextMeshProUGUI slot7;
    TMPro.TextMeshProUGUI slot0left;
    TMPro.TextMeshProUGUI slot1left;
    TMPro.TextMeshProUGUI slot2left;
    TMPro.TextMeshProUGUI slot3left;
    TMPro.TextMeshProUGUI slot4left;
    TMPro.TextMeshProUGUI slot5left;
    TMPro.TextMeshProUGUI slot6left;
    TMPro.TextMeshProUGUI slot7left;
    TMPro.TextMeshProUGUI slot0max;
    TMPro.TextMeshProUGUI slot1max;
    TMPro.TextMeshProUGUI slot2max;
    TMPro.TextMeshProUGUI slot3max;
    TMPro.TextMeshProUGUI slot4max;
    TMPro.TextMeshProUGUI slot5max;
    TMPro.TextMeshProUGUI slot6max;
    TMPro.TextMeshProUGUI slot7max;
    TMPro.TextMeshProUGUI slot0slash;
    TMPro.TextMeshProUGUI slot1slash;
    TMPro.TextMeshProUGUI slot2slash;
    TMPro.TextMeshProUGUI slot3slash;
    TMPro.TextMeshProUGUI slot4slash;
    TMPro.TextMeshProUGUI slot5slash;
    TMPro.TextMeshProUGUI slot6slash;
    TMPro.TextMeshProUGUI slot7slash;


    // Start is called before the first frame update
    void Start()
    {
        
        slot0 = transform.GetChild(1).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot1 = transform.GetChild(2).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot2 = transform.GetChild(3).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot3 = transform.GetChild(4).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot4 = transform.GetChild(5).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot5 = transform.GetChild(6).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot6 = transform.GetChild(7).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot7 = transform.GetChild(8).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot0left= transform.GetChild(9).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot1left= transform.GetChild(10).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot2left= transform.GetChild(11).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot3left= transform.GetChild(12).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot4left= transform.GetChild(13).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot5left= transform.GetChild(14).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot6left= transform.GetChild(15).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot7left= transform.GetChild(16).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot0max= transform.GetChild(17).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot1max= transform.GetChild(18).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot2max= transform.GetChild(19).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot3max= transform.GetChild(20).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot4max= transform.GetChild(21).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot5max= transform.GetChild(22).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot6max= transform.GetChild(23).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot7max= transform.GetChild(24).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot0slash= transform.GetChild(25).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot1slash= transform.GetChild(26).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot2slash= transform.GetChild(27).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot3slash= transform.GetChild(28).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot4slash= transform.GetChild(29).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot5slash= transform.GetChild(30).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot6slash= transform.GetChild(31).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
        slot7slash= transform.GetChild(32).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
    }

    public void updating(unit person)
    {
        slot0.text = "";
        slot1.text = "";
        slot2.text = "";
        slot3.text = "";
        slot4.text = "";
        slot5.text = "";
        slot6.text = "";
        slot7.text = "";
        slot0left.text = "";
        slot1left.text = "";
        slot2left.text = "";
        slot3left.text = "";
        slot4left.text = "";
        slot5left.text = "";
        slot6left.text = "";
        slot7left.text = "";
        slot0max.text = "";
        slot1max.text = "";
        slot2max.text = "";
        slot3max.text = "";
        slot4max.text = "";
        slot5max.text = "";
        slot6max.text = "";
        slot7max.text = "";
        slot0slash.text = "";
        slot1slash.text = "";
        slot2slash.text = "";
        slot3slash.text = "";
        slot4slash.text = "";
        slot5slash.text = "";
        slot6slash.text = "";
        slot7slash.text = "";
        switch (person.invintory.Count)
        {
         
            case 8:
                slot7.text = person.invintory[7].named;
                slot7left.text = Convert.ToString(person.invintory[7].uses);
                slot7slash.text = "/";
                slot7max.text = Convert.ToString(person.invintory[7].max_uses);
                goto case 7;
            case 7:
                slot6.text = person.invintory[6].named;
                slot6left.text = Convert.ToString(person.invintory[6].uses);
                slot6slash.text = "/";
                slot6max.text = Convert.ToString(person.invintory[6].max_uses);
                goto case 6;
            case 6:
                slot5.text = person.invintory[5].named;
                slot5left.text = Convert.ToString(person.invintory[5].uses);
                slot5max.text = Convert.ToString(person.invintory[5].max_uses);
                slot5slash.text = "/";
                goto case 5;
            case 5:
                slot4.text = person.invintory[4].named;
                slot4left.text = Convert.ToString(person.invintory[4].uses);
                slot4max.text = Convert.ToString(person.invintory[4].max_uses);
                slot4slash.text = "/";
                goto case 4;
            case 4:
                slot3.text = person.invintory[3].named;
                slot3left.text = Convert.ToString(person.invintory[3].uses);
                slot3max.text = Convert.ToString(person.invintory[3].max_uses);
                slot3slash.text = "/";
                goto case 3;
            case 3:
                slot2.text = person.invintory[2].named;
                slot2left.text = Convert.ToString(person.invintory[2].uses);
                slot2max.text = Convert.ToString(person.invintory[2].max_uses);
                slot2slash.text = "/";
                goto case 2;
            case 2:
                slot1.text = person.invintory[1].named;
                slot1left.text = Convert.ToString(person.invintory[1].uses);
                slot1max.text = Convert.ToString(person.invintory[1].max_uses);
                slot1slash.text = "/";
                goto case 1;
            case 1:
                slot0.text = person.invintory[0].named;
                slot0left.text = Convert.ToString(person.invintory[0].uses);
                slot0max.text = Convert.ToString(person.invintory[0].max_uses);
                slot0slash.text = "/";
                break;
            case 0:
                return;
             }


        }
}
