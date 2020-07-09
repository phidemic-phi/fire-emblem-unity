using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitButton : MonoBehaviour
{
    public HUD mum;

    private void Start()
    {
        mum = GetComponentInParent(typeof(HUD)) as HUD;
    }
    void TaskOnClick()
    {
        mum.waitButton();
    }
}
