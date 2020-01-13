using UnityEngine;
using System.Collections;

public enum CharClass { Spellcaster, Warrior}

public class CharacterAsset : ScriptableObject
{
    public CharClass Class;
    public string ClassName;
 
    public int MaxHealth;
    public Sprite AvatarBGImage;
    public Sprite AvatarImage;

}
