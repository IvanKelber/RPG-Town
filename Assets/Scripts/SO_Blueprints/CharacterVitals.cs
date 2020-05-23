using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Character/Vitals", order = 1)]
public class CharacterVitals : ScriptableObject
{
    [SerializeField]
    private DerivedStats derivedStats;

    [SerializeField]
    private int _health;
    private int _mana;
    
    public void TakeDamage(int damage) {
        if(_health > 0) {
            _health -= damage;
            _health = Mathf.Clamp(_health, 0, derivedStats.MaxHealth);
        }
        if(_health <= 0) {
            if(_health < 0 ) {
                Debug.LogWarning("Health is below zero... how did we get into this state?");
            }
            Debug.Log("Ded");
        }
    }

    public bool SpendMana(int manaCost) {
        if(_mana > manaCost) {
            _mana -= manaCost;
            return true;
        }
        //Not enough mana
        return false;
    }

    public void GainHealth(int healing) {
        _health += healing;
        _health = Mathf.Clamp(_health, 0, derivedStats.MaxHealth);
    }

    public void GainMana(int mana) {
        _mana += mana;
        _mana = Mathf.Clamp(_mana, 0, derivedStats.MaxMana);
    }

    public int CurrentHealth() {
        return _health;
    }

    public int CurrentMana() {
        return _mana;
    }

    public void FullHealth() {
        _health = derivedStats.MaxHealth;
    }

    public void FullMana() {
        _mana = derivedStats.MaxMana;
    }
}
