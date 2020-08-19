using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The hud controller for all the buttons that show up
/// uses a few hard coded buttons that appear when you first select a unit always
/// and a few custom buttons that change what they do baised on situations
/// </summary>
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
    public map Map;
    public GameObject prev;
    public combatprevew prevScript;
    public camera cam;
    public unitInfo infoScript;
    public GameObject info;
    public GameObject over;
    private void Start()
    {
        basic = GameObject.FindGameObjectsWithTag("basicButton");
        custom = GameObject.FindGameObjectsWithTag("customButton");
        cancel = GameObject.FindGameObjectWithTag("cancelButton");
        prev = GameObject.FindGameObjectWithTag("preview");
        over = GameObject.FindGameObjectWithTag("mouseover");
        prevScript = prev.GetComponent(typeof(combatprevew)) as combatprevew;
        disapear();
        state = hudState.nothing;
        combat = GameObject.FindGameObjectWithTag("CombatMed").GetComponent(typeof(combatmed)) as combatmed;
        Map = GameObject.FindGameObjectWithTag("map").GetComponent(typeof(map)) as map;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof(camera)) as camera;
        info = gameObject.transform.GetChild(14).gameObject;
        infoScript = info.GetComponent(typeof(unitInfo)) as unitInfo;



}
    /// when a unit is clicked on and given to the hud to handle
    public void getunit(unit temp)
    {
        state = hudState.normal;
     
        if (selected != null)
            if (selected.state != unitState.done)
                 selected.fullCancel();

        selected = temp;
        update();

    }
    /// <summary>
    /// what happens then the wait button is clicked
    /// </summary>
    public void waitButton()
    {
        selected.wait();
        Map.cleanTiles();
        clear();
    }
    /// <summary>
    /// the button that is always there
    /// brings everything back a state
    /// and how to go back on anything
    /// </summary>
    public void cancelButton()
    {
        switch (state)
        {
            case hudState.normal: //for when nothing happened
                selected.cancelMove();
                if (selected.state == unitState.nothing)
                    state = hudState.nothing;
                update();
                break;
            case hudState.item: // for options on a item
                itemButton();
                break;
           
            case hudState.attack: // when selecting an opponent
                attackButton();
                Map.clearTiles();
               
                 Map.revisTiles();
                break;
            case hudState.attackItem: // selecting an item to attack with after selecting attack
            case hudState.itemList: // selecting an item to do things with
            case hudState.skillSelect:
            case hudState.blueCommand: // commanding blue and yellow units AI
            case hudState.yellowCommand:
                state = hudState.normal;
                break;
        }
        update();
    }

    /// <summary>
    /// honestly here just cause a base action
    /// does not do much yet
    /// </summary>
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

    /// <summary>
    /// most of the work done here and in update
    /// num is the button clicked
    /// also uses the text in the buttons to find out what exactly was asked of it
    /// </summary>
    /// <param name="num">button number clicked 0-7</param>
    public void varibleButton(int num)
    {
        TMPro.TextMeshProUGUI temp;
        int counter = 0;
        switch (state)
        {
            case hudState.normal: //for when nothing happened

                for (int i = 0; i < selected.skills.Count; i++)
                {
                    if (selected.skills[i].targets(selected) == true)
                    {
                        if (counter == num)
                        {
                            selected.skills[i].mark(selected);
                        }
                        counter++;
                    }
                }
                state = hudState.skillSelect;
                break;
                
            case hudState.item: // for options on a item
                ///these are the only options for items at the moment
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
                ///a filler state as we want them to click on the map and not on the HUD
            case hudState.attack: // when selecting an opponent
                break;
                
            case hudState.attackItem: // selecting an item to attack with after selecting attack
                ///gets the items that was selected and equips it
               
                for (int i = 0; i < selected.invintory.Count; i++)
                {
                    if (selected.invintory[i].equipable(selected) == true)
                    {
                        if (counter == num) 
                            selected.equip(i);

                        counter++;
                    }
                }
                ///clears the map of the movement tiles and repaints it red for the space and weapon we have equiped
                Map.clearTiles();
                Vector3 location = selected.transform.position;
                Map.makeRed((int)location[0], (int)location[2]);
                Map.tiles[(int)location[0]][(int)location[2]].clear();
                state = hudState.attack;
                break;
            case hudState.itemList: // selecting an item to do things with
        
                state = hudState.item;

                break;
            case hudState.blueCommand: 
            case hudState.yellowCommand:
                break;
            case hudState.dropping:
                selected.drop(num);
                selected.equiping();
                waitButton();
                break;
            case hudState.skillSelect:
               
                break;

        }
        //remembers last selected button and reupdates the hud cutom buttons
        lastSelection = num;
        update();
    }

    /// <summary>
    /// makes all buttons disappear
    /// </summary>
    public void disapear()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {

            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        
    }
    /// <summary>
    /// removes all info in HUD
    /// </summary>
    public void clear()
    {
        disapear();
        state = hudState.nothing;
        selected = null;
    }
    /// <summary>
    /// what buttons are visable
    /// and making them active
    /// </summary>
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
                List<string> names = selected.skillCommands();
                for (int i =0; i < names.Count; i++)
                {
                    custom[i].SetActive(true);
                    temp = custom[i].transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
                    temp.text = names[i];
                }
                break;
            case hudState.item: // for options on a item
                ///goes into the selected unit and grabs ever item, and the commands the item has in it
                ///swaps the equiped item to an unequip command
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
            case hudState.skillSelect:
                break;

            case hudState.attackItem: // selecting an item to attack with after selecting attack
                ///grabs all the items from the unit 
                ///gives them each a button
                ///adds an e to the equiped one
                ///removes all items that can not be equiped
                int counter = 0;
                buttons = selected.invintory.Count;
                for (int i = 0; i < buttons; i++)
                {
                    if (selected.invintory[i].equipable(selected) == true)
                    {
                        custom[counter].SetActive(true);
                        temp = custom[counter].transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
                        temp.text = selected.invintory[i].named;
                        counter++;
                    }
                }
                buttons = counter;
                if (selected.has_weapon == true)
                {
                    temp = custom[0].transform.GetChild(0).GetComponent(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
                    temp.text = selected.invintory[0].named + " E";
                }
                break;

            case hudState.itemList: // selecting an item to do things with
                                    ///grabs all the items from the unit 
                                    ///gives them each a button
                                    ///adds an e to the equiped one
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
            case hudState.dropping:
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
                cancel.SetActive(false);
                
                break;


        }
        
       
    }
    /// <summary>
    /// helper start of fight command
    /// </summary>
    /// <param name="spot">the spot that was clicked</param>
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
        else if (state == hudState.skillSelect)
        {
            unit person = null;
            if (selected.foeHere(spot.transform.position))
            {
                person = selected.mum.getFoe(location);
            }
            else if (selected.allyHere(spot.transform.position))
            {
                person = selected.mum.getAlly(location);
            }
            skills(person);
        }
        return;
    }
    /// <summary>
    /// helper start of fight command
    /// </summary>
    /// <param name="person">the unit selected</param>
    public void fightUnit(unit person)
    {
        if (person == selected)
            return;
        if (state == hudState.attack)
        {
            if (selected.allyHere(person.transform.position) == true)
                return;
            Vector3 location = person.transform.position;
            tile spot = Map.tiles[(int)location[0]][(int)location[2]];
            if ( spot.fight == true)
            {
                fightComplete(person, spot);
            }
            
        }
        else if (state == hudState.skillSelect && selected.skills.Count >0)
        {
            skills(person);
        }
    }

    public void skills (unit person)
    {
        int counter = 0;
        for (int i = 0; i < selected.skills.Count; i++)
        {
            if (selected.skills[i].targets(selected) == true)
            {
                if (counter == lastSelection)
                {
                    selected.skills[i].commanded(selected, person);
                    waitButton();
                    return;
                }

                counter++;
            }
        }
    }
    /// <summary>
    /// the true fight start function
    /// as a person could click on a unit or a tile so we needed to catch both and get the same information
    /// grabs the opponents and the ground they are on as we have 1 ground so we might as well grab the other
    /// </summary>
    /// <param name="person">attacker</param>
    /// <param name="spot">the ground the attacker is on</param>
    public void fightComplete(unit person, tile spot)
    {
        Vector3 location = selected.transform.position;
        combat.cambatTaker(selected, Map.tiles[(int)location[0]][(int)location[2]], person, spot);
        if (state != hudState.dropping)
            waitButton();
    }
    public void dropItem(unit person)
    {
        selected = person;
        state = hudState.dropping;
        update();

    }
    public void mouse(unit person)
    {
        if (person == selected)
            return;
        if (state == hudState.attack)
        {
            if (selected.allyHere(person.transform.position) == true)
                return;


            Vector3 location = selected.transform.position;
            Vector3 location2 = person.transform.position;
            tile spot = Map.tiles[(int)location2[0]][(int)location2[2]];
            if (spot.fight == true)
            {
                prev.SetActive(true);
                prevScript.take(selected, person, Map.tiles[(int)location[0]][(int)location[2]], Map.tiles[(int)location2[0]][(int)location2[2]]);
            }
        }

        }
       
    public void status(unit person)
    {
        cam.move = !cam.move;
        cancelButton();
        cancelButton();
        cancelButton();
        cancelButton();
        over.SetActive(false);
        info.SetActive(true);
        infoScript.take(person);

    }
    public void done()
    {
        over.SetActive(true);
        cam.move = !cam.move;
        info.SetActive(false);
    }
    public void dropmouse()
    {
        update();
    }
}
