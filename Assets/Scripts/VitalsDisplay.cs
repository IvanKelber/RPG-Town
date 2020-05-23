using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsDisplay : MonoBehaviour
{
    [SerializeField]
    CharacterVitals vitals;

    public Image healthFill;
    public Image manaFill;

    private int maxHealth;
    private int maxMana;

    public float manaTickTime = 2;
    public int manaTickAmount = 5;

    private float manaTickTimer;

    private void Awake() {
        vitals.FullHealth();
        vitals.FullMana();
        maxHealth = vitals.CurrentHealth();
        maxMana = vitals.CurrentMana();
    }
    private void Start() {
        manaTickTimer = manaTickTime;
    }

    private void Update() {
        healthFill.fillAmount = (float) vitals.CurrentHealth() / maxHealth;
        manaFill.fillAmount = (float) vitals.CurrentMana() / maxMana;
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T)) {
            if(vitals.SpendMana(10)) {
                vitals.GainHealth(15);
            }
        } else if(Input.GetKeyDown(KeyCode.T)) {
            vitals.TakeDamage(10);
        }
        manaTickTimer -= Time.deltaTime;
        if(manaTickTimer <= 0) {
            vitals.GainMana(manaTickAmount);
            manaTickTimer = manaTickTime;
        }

    }
}
