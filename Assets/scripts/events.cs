using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class events : MonoBehaviour
{
    public List<eventType> type;
    public List<int> turnNumber;
    public List<int> turnTrigger;

    public List<int> unitGroups;
    public List<player> owner;
    public List<GameObject> classes;
    public List<ID> who;
    public List<Vector3> location;
    public void turn (int num)
    {
        for (int i = 0; i < turnNumber.Count; i++)
        {
            if (turnNumber[i] == num)
            {
                trigger(turnTrigger[i]);
            }
        }
    }

    public void trigger(int num)
    {
        switch (type[num])
        {
            case eventType.units:
                for(int i=0;i < unitGroups.Count; i++)
                {
                   unit temp = Instantiate(classes[i], owner[i].transform).GetComponent(typeof(unit)) as unit;
                    temp.me = who[i];
                    temp.setPerson();
                    temp.transform.position = location[i];
                    temp.state = unitState.done;
                    owner[i].units.Add(temp);

                }
                break;
        }
    }
}
