using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Character/DerivedStats", order = 1)]
public class DerivedStats : ScriptableObject
{

    const int HealthMultiplier = 10;
    const int ManaMultiplier = 10;

    public PrimaryStats primaryStats;

    public int MaxHealth {
        get {
            return primaryStats.Constitution * HealthMultiplier;
        }
    }

    public int MaxMana {
        get {
            return primaryStats.Wisdom * ManaMultiplier;
        }
    }
}
