using System;
using UnityEngine;
using UnityEngine.TextCore.Text;
[CreateAssetMenu]
public class characterDatabase : ScriptableObject
{
    public CharatcterScript[] character;
    public CharatcterScript GetCharacterByName(string name)
    {
        foreach (CharatcterScript script in character)
            Debug.Log(script.characterSprite.name);
        Debug.Log(name);
        Debug.Log(Array.Find(character, c => c.characterSprite.name == name));
        return Array.Find(character,c => c.characterSprite.name == name);
    }
    public int characterCount
    {
        get
        {
            return character.Length;
        }
    }
    public CharatcterScript GetCharatcter( int index )
    {
        return character [index];
    }
}

