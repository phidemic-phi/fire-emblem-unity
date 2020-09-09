using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nameFlag : MonoBehaviour
{
    public Sprite[] flags;
    Image current;
    int counter = 0;
    int holder;
    // Start is called before the first frame update
    void Start()
    {
        current = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter % 14 == 0)
        {
            current.sprite = flags[holder++];
        }
        counter++;
        if (holder == 16)
            holder = 0;
    }
}
