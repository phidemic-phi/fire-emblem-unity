using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class combatprevew : MonoBehaviour
{
    TMPro.TextMeshProUGUI pName;
    TMPro.TextMeshProUGUI pWeapon;
    TMPro.TextMeshProUGUI pHP;
    TMPro.TextMeshProUGUI pMt;
    TMPro.TextMeshProUGUI pCrit;
    TMPro.TextMeshProUGUI oName;
    TMPro.TextMeshProUGUI oWeapon;
    TMPro.TextMeshProUGUI oHP;
    TMPro.TextMeshProUGUI oMt;
    TMPro.TextMeshProUGUI oCrit;
    TMPro.TextMeshProUGUI pHit;
    TMPro.TextMeshProUGUI oHit;
    combatmed med;
   
        // Start is called before the first frame update
        void Start()
        {
            pName = transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            pWeapon = transform.GetChild(1).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            pHP = transform.GetChild(2).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            pMt = transform.GetChild(3).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            pHit = transform.GetChild(4).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            pCrit = transform.GetChild(5).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            oName = transform.GetChild(6).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            oWeapon = transform.GetChild(7).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            oHP = transform.GetChild(8).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            oMt = transform.GetChild(9).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            oHit = transform.GetChild(10).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            oCrit = transform.GetChild(11).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            med = GameObject.FindGameObjectWithTag("CombatMed").GetComponent(typeof(combatmed)) as combatmed;
    }
    public void take(unit player, unit foe, tile spot, tile defender)
    {
        pName.text = player.name;

        pWeapon.text = Convert.ToString(player.invintory[0].named);

        pMt.text = Convert.ToString(med.damage(player, foe, spot));

        pHP.text = Convert.ToString(player.hp);

        pHit.text = Convert.ToString(med.accuracy(player, foe, spot));

        pCrit.text = Convert.ToString(med.crit(player, foe));

        oHP.text = Convert.ToString(foe.hp);
        oName.text = foe.name;
        int dis = med.distance(spot.transform.position, defender.transform.position);
        if (foe.has_weapon == true)
        {
            oWeapon.text = Convert.ToString(foe.invintory[0].named);
        }
        else
            oWeapon.text = "-";
        if (foe.min_range >= dis && foe.max_range <= dis)
        {
           

            oMt.text = Convert.ToString(med.damage(foe, player, defender));

          

            oHit.text = Convert.ToString(med.accuracy(foe, player, defender));

            oCrit.text = Convert.ToString(med.crit(foe, player));
        }
        else
        {
           

            oMt.text = "-";

        

            oHit.text = "-";

            oCrit.text = "-";
        }
        if (med.doubleAttack(player, foe))
        {
            transform.GetChild(13).gameObject.SetActive(true);
            transform.GetChild(12).gameObject.SetActive(false);
        }
        else if (med.doubleAttack(foe, player))
        {
            transform.GetChild(13).gameObject.SetActive(false);
            transform.GetChild(12).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(13).gameObject.SetActive(false);
            transform.GetChild(12).gameObject.SetActive(false);
        }
    }
}
