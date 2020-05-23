using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Character/PrimaryStats", order = 1)]
public class PrimaryStats : ScriptableObject
{
    public int Strength; //Affects physical attack damage
    public int Agility; //Affects turn order
    public int Defense; //Affects damage taken
    public int Wisdom; //Affects mana && non-physical damage
    public int Constitution; //Affects hit points
    public int Luck; //Affects rarity modifier

    public void LevelUp() {
        //maybe add this to randomly upgrade stats
    }
}
