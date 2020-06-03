using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleParticipant 
{
    public string name;
    public DerivedStats stats;
    public CharacterVitals vitals;

    public BattleParticipant(string name, DerivedStats stats, CharacterVitals vitals) {
        this.name = name;
        this.stats = stats;
        this.vitals = vitals;
    }

    public void Attack(BattleParticipant target) {
        int attack = CalculateAttack()
        target.TakeDamage(attack);
    } 

    public void TakeDamage(int attack) {
        int mitigation = CalculateMitigation()
        this.vitals.TakeDamage(CalculateDamage(attack, mitigation));
    }

    private int CalculateAttack() {
        return this.stats.attack;
    }

    private int CalculateMitigation() {
        return this.stats.defense;
    }

    private int CalculateDamage(int attack, int mitigation) {
        return Mathf.Clamp(attack-mitigation, 1, attack);
    }
}
