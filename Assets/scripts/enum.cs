/* just some enumations to help with states or some other few things, not too fancy
names of the enums should say what they are for
*/




public enum Affinity { fire, water, wind, thunder, heaven, earth, light, dark }
public enum Weapon_rank { none,E,D,C,B,A,S,SS}
public enum Directions { up, down, left, right}

public enum MoveType {foot, armour, mage, knight, flyer, theif, footbeast, beast, footdragon, dragon, rafel }

public enum Item_type { consumable,sword, lance,axe,knife, bow,light,dark,wind,fire,thunder,staff,strike}
public enum triangle {  yes, no , even}
public enum damageType { physical, magical}
public enum unitState { nothing, selected, moving, menus, done}
public enum hudState { nothing, normal, attackItem, attack, itemList, item, blueCommand, yellowCommand, dropping, skillSelect }
public enum tileState { clear, green, blue, red}
public enum combatOrder { attack, defend}
public enum ID { none,miccy, edward, bandit, leo, pugo}
public enum itemName { none,light, ironSword,steelSword,herb,bronzeAxe, ironAxe, dracosheild, vulnerary }
public enum eventType { item, units, stats, mapChange, status, AIChange}
public enum suppRank { C =1, B, A, S}
public enum bioState { Best, Good, Even, Bad, Worst}
public enum skillsName { smite, sacrifice, wrath, cancel, nihil, guard, shade, fortune, howl, quickclaw, wildheart, shriek, adept, resolve, imbue,
savior, celerity, discipline, pass, gamble, beastfoe, birdfoe, dragonfoe, paragon, vantage, parity, renewal, flourish, blossom, counter, disarm, corrosion, 
provoke, miracle, mercy, nulify, dount, formshift, blessing, boon, galdrar, glare, pavise, insight, vigilance, maelstrom,  bloodtide, nighttide, stillness, 
mantle, aurora}