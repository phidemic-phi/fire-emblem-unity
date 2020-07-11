using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public unit selected;
    public hudState state;
    public GameObject[] basic; 
    public GameObject[] custom;
    public GameObject cancel;
    public int buttons;
    public int lastSelection;
    public combatmed combat;
    private void Start()
    {
        basic = GameObject.FindGameObjectsWithTag("basicButton");
        custom = GameObject.FindGameObjectsWithTag("customButton");
        cancel = GameObject.FindGameObjectWithTag("cancelButton");
        disapear();
        state = hudState.nothing;
        combat = GameObject.FindGameObjectWithTag("CombatMed").GetComponent(typeof(combatmed)) as combatmed;

    }
    // when a unit is clicked on and given to the hud to handle
    public void getunit(unit temp)
    {
        state = hudState.normal;
        update();
        if (selected != null)
            if (selected.state != unitState.done)
                 selected.cancelMove();

        selected = temp;
        
    }

    public void waitButton()
    {
        selected.wait();

        clear();
    }
    public void cancelButton()
    {
        switch (state)
        {
            case hudState.normal: //for when nothing happened
                selected.cancelMove();
                clear();
                break;
            case hudState.item: // for options on a item
                itemButton();
                break;
           
            case hudState.attack: // when selecting an opponent
                attackButton();
                break;
            case hudState.attackItem: // selecting an item to attack with after selecting attack
            case hudState.itemList: // selecting an item to do things with
           
            case hudState.blueCommand: // commanding blue and yellow units AI
            case hudState.yellowCommand:
                state = hudState.normal;
                break;
        }
        update();
    }


    public void attackButton()
    {
        state = hudState.attackItem;
        update();
    }



    public void itemButton()
    {
        state = hudState.itemList;
      
        update();
    }

    public void varibleButton(int num)
    {
        TMPro.TextMeshProUGUI temp;
        switch (state)
        {
            case hudState.normal: //for when nothing happened
                break;
            case hudState.item: // for options on a item
                
                temp = custom[num].transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
               
                if (temp.text == "Equip")
                {
                    selected.equip(lastSelection);
                    cancelButton();
                }
                else if (temp.text == "Drop")
                {
                    selected.drop(lastSelection);
                    cancelButton();
                }
                else if (temp.text == "Use")
                {
                    selected.use(lastSelection);
                    waitButton();
                }
                else if (temp.text == "Unequip")
                {
                    selected.unequip();
                    cancelButton();
                }

                break;

            case hudState.attack: // when selecting an opponent
                break;
            case hudState.attackItem: // selecting an item to attack with after selecting attack
                selected.equip(num);
                state = hudState.attack;
                break;
            case hudState.itemList: // selecting an item to do things with
        
                state = hudState.item;

                break;
            case hudState.blueCommand: 
            case hudState.yellowCommand:
                break;
        }
        lastSelection = num;
        update();
    }


    public void disapear()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {

            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        
    }

    public void clear()
    {
        disapear();
        state = hudState.nothing;
        selected = null;
    }

    public void update()
    {
        TMPro.TextMeshProUGUI temp;
        disapear();
        cancel.SetActive(true);
        switch (state) {
            case hudState.nothing:
                clear();
                break;
            case hudState.normal: //for when nothing happened

                for (int i = 0; i < basic.Length; i++)
                {

                    basic[i].SetActive(true);
                }
                
                break;
            case hudState.item: // for options on a item
                List<string> commands;
                commands = selected.invintory[lastSelection].commandList();
                buttons = commands.Count;

                for (int i = 0; i < buttons; i++)
                {

                    custom[i].SetActive(true);
                    temp = custom[i].transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
                    temp.text = commands[i];
                }
                if (selected.has_weapon == true && lastSelection == 0)
                {
                    temp = custom[0].transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
                    temp.text = "Unequip";
                }
                    break;

            case hudState.attack: // when selecting an opponent
                break;

            case hudState.attackItem: // selecting an item to attack with after selecting attack
            
            case hudState.itemList: // selecting an item to do things with
                
                buttons = selected.invintory.Count;
                for (int i = 0; i < buttons; i++)
                {

                    custom[i].SetActive(true);
                    temp = custom[i].transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
                    temp.text = selected.invintory[i].named;
                }
                if (selected.has_weapon == true)
                {
                    temp = custom[0].transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
                    temp.text = selected.invintory[0].named + " E";
                }
                break;
            case hudState.blueCommand:
            case hudState.yellowCommand:
                break;


        }
        
       
    }
    public void fightTile(tile spot) {
        Vector3 location = spot.transform.position;
        if(state == hudState.attack)
        {
            if (selected.foeHere(spot.transform.position))
            {
                if (selected.foeHere(location))
                    fightComplete(selected.mum.getFoe(location), spot);
            }
        }
        return;
    }
    public void fightUnit(unit person)
    {
        if (state == hudState.attack)
        {
            Vector3 location = person.transform.position;
            tile spot = person.mum.Map.tiles[(int)location[0]][(int)location[2]];
            if ( spot.fight == true)
            {
                fightComplete(person, spot);
            }
            
        }
    }
    public void fightComplete(unit person, tile spot)
    {
        Vector3 location = selected.transform.position;
        combat.cambatTaker(selected, selected.mum.Map.tiles[(int)location[0]][(int)location[2]], person, spot);
        waitButton();
    }
}
