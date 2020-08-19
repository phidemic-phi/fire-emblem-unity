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
    GameObject supports;
    GameObject bio;
    public unit person;
    private void Start()
    {
        items = transform.GetChild(0).gameObject;
        itemsScript = items.GetComponent(typeof(unititems)) as unititems;
        weaponLevel = transform.GetChild(1).gameObject;
        supports = transform.GetChild(2).gameObject;
        bio = transform.GetChild(3).gameObject;
        supports.SetActive(false);
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
        person = guy;
        itemsScript.updating(person);
    }
    void Update()
    {
      
       
        if(holder > counter)
        {
            transform.Rotate(0, 1, 0, Space.Self);
            counter++;
        }
        else if (holder < counter)
        {
            transform.Rotate(0, -1, 0, Space.Self);
            counter--;
        }



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
            itemsScript.updating(person);
        }
        else if (counter > 225 && counter < 315)
        {
            weaponLevel.SetActive(false);
            items.SetActive(true);
            supports.SetActive(true);
            itemsScript.updating(person);
        }

        else if (counter > 135 && counter < 225)
        {
            bio.SetActive(true);
            weaponLevel.SetActive(true);
            items.SetActive(false);
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
}
