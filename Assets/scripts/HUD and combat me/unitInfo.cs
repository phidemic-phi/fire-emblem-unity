using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitInfo : MonoBehaviour
{
    player owner;
    camera cam;
    unit holder;
    HUD mum;
    mouseoverUI basic;
    shortstats shortStats;
    rotation rot;
    float amount = 90;

    private void Start()
    {
        mum = GameObject.FindGameObjectWithTag("HUD").GetComponent(typeof(HUD)) as HUD;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof(camera)) as camera;
        basic =transform.GetChild(2).gameObject.GetComponent(typeof(mouseoverUI)) as mouseoverUI;
        shortStats = transform.GetChild(1).gameObject.GetComponent(typeof(shortstats)) as shortstats;
        rot = transform.GetChild(3).gameObject.GetComponent(typeof(rotation)) as rotation;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mum.done();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            updateUnit(1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            updateUnit(-1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rot.Rotate(amount * -1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rot.Rotate(amount);
        }

    }

    public void take (unit person)
    {
        holder = person;
        owner = person.mum;
        basic.unmove(person);
        shortStats.unmove(person);
        rot.take(person);
        
    }
    public void updateUnit(int num)
    {
        for (int i= 0; i < owner.units.Count; i++)
        {
            if (owner.units[i] == holder)
            {
                if (i == 0 && num == -1)
                    i = owner.units.Count;
                else if (i == owner.units.Count - 1 && num ==1)
                    i = -1;
                    
                take(owner.units[i + num]);
                return;
            }
        }
    }
}
