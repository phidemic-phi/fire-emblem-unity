using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biorythim : MonoBehaviour
{
   public List <bioState> state;

   public bioState slot(int num)
    {
        while (num > 24)
            num -= 25;
        return state[num];
    }
   
 }
