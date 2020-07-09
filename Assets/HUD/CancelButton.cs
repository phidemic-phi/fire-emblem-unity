using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
    public HUD mum;

    private void Start()
    {
        mum = GetComponentInParent(typeof(HUD)) as HUD;
    }
    void TaskOnClick()
    {
        mum.cancelButton();
    }
}
