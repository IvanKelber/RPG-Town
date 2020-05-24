using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Character/DerivedStats", order = 1)]
public class DerivedStats : ScriptableObject
{

    const int HealthMultiplier = 10;
    const int ManaMultiplier = 10;

    public PrimaryStats primaryStats;
    public Equipment equipment;


    public int MaxHealth {
        get {
            return (primaryStats.Constitution + equipment.statsMap["Constitution"]) * HealthMultiplier;
        }
    }

    public int MaxMana {
        get {
            return (primaryStats.Wisdom + equipment.statsMap["Wisdom"]) * ManaMultiplier;
        }
    }

    public int Strength {
        get {
            return primaryStats.Strength + equipment.statsMap["Strength"];
        }
    }
    public int Agility {
        get {
            return primaryStats.Agility + equipment.statsMap["Agility"];
        }
    }
    public int Wisdom {
        get {
            return primaryStats.Wisdom + equipment.statsMap["Wisdom"];
        }
    }
    public int Constitution {
        get {
            return primaryStats.Constitution + equipment.statsMap["Constitution"];
        }
    }
    public int Defense {
        get {
            return primaryStats.Defense + equipment.statsMap["Defense"];
        }
    }
    public int Luck {
        get {
            return primaryStats.Luck + equipment.statsMap["Luck"];
        }
    }
}
