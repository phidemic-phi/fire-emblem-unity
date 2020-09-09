using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillHUD : MonoBehaviour
{
    public TMPro.TextMeshProUGUI cap;
    public TMPro.TextMeshProUGUI names;
   public Image icon;
   
   
    
        public void take(skill here, HUD hud)
    {
        names.text = Convert.ToString(here.skillName());
        if (here.cap != 0)
        {

            cap.text = Convert.ToString(here.cap);
        }
        else
            cap.text = "";
        icon.sprite =  hud.skillIcons[here.tex];
        if (here.locked == false)
            {
            transform.GetChild(3).gameObject.SetActive(false);

            }
     
      
    }
    public void loc(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    }
