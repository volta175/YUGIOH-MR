using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetingOptions
{
    Notarget,
    AllCard,
    EnemyCard,
    YourCard,
    AllMonster,
    EnemyMonster,
    YourMonster,
    AllSpell,
    EnemySpell,
    YourSpell,
    AllCharacter,
    EnemyCharacter,
    YourCharacter,
    Enemy, // Enemy = enemy monster / enemy character
}

public class CardAsset : ScriptableObject
{
    [Header("General info")]
    public CharacterAsset characterAsset;
    [TextArea(2, 3)]
    public string Description;
    public Sprite CardImage;
    public GameObject Animation;

    public string cardType1;
    public int cardType1Num;
    /*
        1 = Monster;      2 = Ritual;
        3 = Fusion;       4 = Spell;
        5 = Trap;
    */

    public string cardType2;
    public int cardType2Num;
    /*
        1 = Normal;      2 = Effect;
    */

    [Header("Monster Info")]
    public int level;

    public string monsterAttribute;
    public Sprite monsterAttributePic;
    public int monsterAttributeNum;
    /*
        1 = Light;      2 = Dark;
        3 = Fire;       4 = Water;
        5 = Wind;       6 = Earth;
        7 = Divine;
    */

    public string monsterType;
    public int monsterTypeNum;
    /*
        1  = Fairy;         2  = Spellcaster;      3  = Fiend;             4  = Physic;            5  = Pyro;
        6  = Cyberse;       7  = Machine;          8  = Aqua;              9  = Fish;              10 = Sea Serpent;
        11 = Dragon;        12 = Wyrm;             13 = Thunder;           14 = Winged Beast;      15 = Beast;
        16 = Insect;        17 = Plant;            18 = Beast Warrior;     19 = Warrior;           20 = Zombie;
        21 = Reptile;       22 = Dinosaur;         23 = Rock;              24 = Divine Beast;
    */

    public int ATK;
    public int DEF;
    public int AtkFor1Turn = 1;
    public string MonsterSriptName;
    public int specialCreatureAmount;

    [Header("Spell Info")]
    public string spellType;
    public int spellTypeNum;
    /*
        1 = None;           2 = Equip;
        3 = Continuous;     4 = Counter;
        5 = Quick Play;     6 = Ritual;
        7 = Field;
    */

    public string SpellScriptName;
    public int specialSpellAmount;
    public TargetingOptions Targets;
}