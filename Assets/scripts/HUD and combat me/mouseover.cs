using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class mouseover : MonoBehaviour
{
    TMPro.TextMeshPro names;
    TMPro.TextMeshPro levels;
    TMPro.TextMeshPro exp;
    TMPro.TextMeshPro hp;
    TMPro.TextMeshPro max;
   
    SpriteRenderer ren;
    Vector3 bye;
    unit holder;
    HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        names = transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;
        levels = transform.GetChild(1).GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;
        exp = transform.GetChild(2).GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;
        hp = transform.GetChild(3).GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;
        max = transform.GetChild(4).GetComponent(typeof(TMPro.TextMeshPro)) as TMPro.TextMeshPro;
        ren = transform.GetChild(5).GetComponent<SpriteRenderer>();

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent(typeof(HUD)) as HUD;
        bye = transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)&& transform.position != bye)
        {
            hud.status(holder);
        }
    }
    public void take (unit person)
    {
        holder = person;
        transform.position = person.transform.position + new Vector3(0f, 0.8f, 0.8f);
        
        names.text = person.name;
       
        levels.text = Convert.ToString(person.level);
        
        exp.text = Convert.ToString(person.exp);
        
        hp.text = Convert.ToString(person.hp);
        
        max.text = Convert.ToString(person.max_hp);

        ren.sprite = Resources.Load<Sprite>(person.personallity.tex);
    }
    public void loose()
    {
        transform.position = bye;
    }
    public void fightHappened(unit person)
    {
        names.text = person.name;

        levels.text = Convert.ToString(person.level);

        exp.text = Convert.ToString(person.exp);

        hp.text = Convert.ToString(person.hp);

        max.text = Convert.ToString(person.max_hp);

        ren.sprite = Resources.Load<Sprite>(person.personallity.tex );
    }
    public void unmove(unit person)
    {
        holder = person;
      

        names.text = person.name;

        levels.text = Convert.ToString(person.level);

        exp.text = Convert.ToString(person.exp);

        hp.text = Convert.ToString(person.hp);

        max.text = Convert.ToString(person.max_hp);

        ren.sprite = Resources.Load<Sprite>(person.personallity.tex);
    }
}
