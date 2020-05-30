using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Character/PrimaryStats", order = 1)]
public class PrimaryStats : ScriptableObject
{
    private const int DEFAULT_STAT_VALUE = 10;
    public int Strength; //Affects physical attack damage
    public int Agility; //Affects turn order
    public int Defense; //Affects damage taken
    public int Wisdom; //Affects mana && non-physical damage
    public int Constitution; //Affects hit points
    public int Luck; //Affects rarity modifier

    public void LevelUp() {
        //maybe add this to randomly upgrade stats
    }

    public void Default() {
        Strength        = DEFAULT_STAT_VALUE; //Affects physical attack damage
        Agility         = DEFAULT_STAT_VALUE; //Affects turn order
        Defense         = DEFAULT_STAT_VALUE; //Affects damage taken
        Wisdom          = DEFAULT_STAT_VALUE; //Affects mana && non-physical damage
        Constitution    = DEFAULT_STAT_VALUE; //Affects hit points
        Luck            = DEFAULT_STAT_VALUE; //Affects rarity modifier
    }
}
