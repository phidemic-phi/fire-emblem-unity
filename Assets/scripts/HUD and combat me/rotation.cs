using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float holder;
    public float counter;
    GameObject items;
    unititems itemsScript;
    GameObject weaponLevel;
    weaponLevels weapons;
    GameObject supports;
    supportInfo suppScript;
    GameObject bio;
    bioHUD bioScript;
   
    private void Start()
    {
        items = transform.GetChild(0).gameObject;
        itemsScript = items.GetComponent(typeof(unititems)) as unititems;
        weaponLevel = transform.GetChild(1).gameObject;
        weapons = weaponLevel.GetComponent(typeof(weaponLevels)) as weaponLevels;
        supports = transform.GetChild(2).gameObject;
        suppScript = supports.GetComponent(typeof(supportInfo)) as supportInfo;
        bio = transform.GetChild(3).gameObject;
        bioScript = bio.GetComponent(typeof(bioHUD)) as bioHUD;
        holder = 0f;
        counter = 0f;
    }
    public void Rotate(float num)
    {
        holder += num;
    }
    // Update is called once per frame
    public void take(unit guy)
    {
    
        bio.SetActive(true);
        weaponLevel.SetActive(true);
        items.SetActive(true);
        supports.SetActive(true);
        itemsScript.updating(guy);
        weapons.updating(guy);
        suppScript.updating(guy);
        bioScript.updating(guy);
        updating();
    }
    void Update()
    {
      
       
        if(holder > counter)
        {
            transform.Rotate(0, 1, 0, Space.Self);
            counter++;
            updating();
        }
        else if (holder < counter)
        {
            transform.Rotate(0, -1, 0, Space.Self);
            counter--;
            updating();
        }





        if (holder > 360)
        {
            holder -= 360;
            counter -= 360;
        }
        else if (holder < 0)
        {
            holder += 360;
            counter += 360;
        }
 
    }
    public void updating()
    {

        if (counter > 315 || counter < 45)
        {
            bio.SetActive(true);
            weaponLevel.SetActive(true);           
            supports.SetActive(false);
        }
        else if (counter > 45 && counter < 135)
        {
            bio.SetActive(false);
            supports.SetActive(true);           
            items.SetActive(true);
           
        }
        else if (counter > 225 && counter < 315)
        {
            weaponLevel.SetActive(false);
            items.SetActive(true);
            supports.SetActive(true);
        }

        else if (counter > 135 && counter < 225)
        {
            bio.SetActive(true);
            weaponLevel.SetActive(true);           
            items.SetActive(false);
        }

    }
}
