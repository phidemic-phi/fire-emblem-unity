using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class person : ScriptableObject
{
    public string named;
    public int hp;
    public int str;
    public int mag;
    public int skill;
    public int luck;
    public int speed;
    public int def;
    public int res;
    public string tex;
    public string bioType= "";
    public List<skillsName> skills;


   public void setup(unit person)
    {
        person.name = named;
        person.strength += str;
        person.magic += mag;
        person.skill += skill;
        person.luck += luck;
        person.speed += speed;
        person.defence += def;
        person.resistance += res;
        person.hp += hp;
        person.max_hp += hp;
        if (bioType == "")
        {
            bioType = Convert.ToString(UnityEngine.Random.Range(1,8));
        }
       person.bio = GameObject.FindGameObjectWithTag(bioType).GetComponent(typeof(biorythim)) as biorythim;
        person.bioSpot =UnityEngine.Random.Range(25,51);
        for (int i=0; i< skills.Count; i++)
        {
            switch (skills[i])
            {
                case skillsName.sacrifice:
                    person.skills.Add(sacrifice.CreateInstance());
                    break;
                    case skillsName.smite:
                case skillsName.wrath:
                case skillsName.cancel:
                case skillsName.nihil:
                case skillsName.guard:
                case skillsName.shade:
                case skillsName.fortune:
                case skillsName.howl:
                case skillsName.quickclaw:
                case skillsName.wildheart:
                case skillsName.shriek:
                case skillsName.adept:
                case skillsName.resolve:
                case skillsName.imbue:
                case skillsName.savior:
                case skillsName.celerity:
                case skillsName.discipline:
                case skillsName.pass:
                case skillsName.gamble:
                case skillsName.beastfoe:
                case skillsName.birdfoe:
                case skillsName.dragonfoe:
                case skillsName.paragon:
                case skillsName.vantage:
                case skillsName.parity:
                case skillsName.renewal:
                case skillsName.flourish:
                case skillsName.blossom:
                case skillsName.counter:
                case skillsName.disarm:
                case skillsName.corrosion:
                case skillsName.provoke:
                case skillsName.miracle:
                case skillsName.mercy:
                case skillsName.nulify:
                case skillsName.dount:
                case skillsName.formshift:
                case skillsName.blessing:
                case skillsName.boon:
                case skillsName.galdrar:
                case skillsName.glare:
                case skillsName.pavise:
                case skillsName.insight:
                case skillsName.vigilance:
                case skillsName.maelstrom:
                case skillsName.bloodtide:
                case skillsName.nighttide:
                case skillsName.stillness:
                case skillsName.mantle:
                case skillsName.aurora:
                    break;
            }
        }
        
    }

}
