using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "Equippable", menuName = "Equipment/Equipment", order = 1)]
public class Equipment : ScriptableObject
{

    public GameEvent itemEquipEvent;

    public ItemCollection inventory;

    private Dictionary<EquipSlot, EquippableItem> _map = new Dictionary<EquipSlot, EquippableItem>();

    public Dictionary<string, int> statsMap = new Dictionary<string, int>();

    private void OnEnable() {
        statsMap.Add("Strength", 0);
        statsMap.Add("Agility", 0);
        statsMap.Add("Constitution", 0);
        statsMap.Add("Wisdom", 0);
        statsMap.Add("Defense", 0);
        statsMap.Add("Luck", 0);     
    }

    public void Equip(EquipSlot slot, EquippableItem item) {
        if(_unequip(slot)) {
            _map.Add(slot, item);
            AddStatsFromItem(item);
        }
    }

    // Returns whether or not the item was successfully unequiped
    private bool _unequip(EquipSlot slot) {
        EquippableItem preEquipped;
        if(_map.TryGetValue(slot, out preEquipped)) {
            bool removed = inventory.Add(preEquipped) && _map.Remove(slot); // won't unequip unless there's room in the inventory
            if(removed) {
                RemoveStatsFromItem(preEquipped);
            }
        }
        //The equipment slot wasn't filled
        return true;
    }

    public Dictionary<string, int> CalculateStatsFromEquipment() {       
        foreach(EquippableItem item in _map.Values) {
            AddStatsFromItem(item);
        }
        return statsMap;
    }

    public void AddStatsFromItem(EquippableItem item) {
        statsMap["Strength"] += item.stats.Strength;
        statsMap["Agility"] += item.stats.Agility;
        statsMap["Constitution"] += item.stats.Constitution;
        statsMap["Wisdom"] += item.stats.Wisdom;
        statsMap["Defense"] += item.stats.Defense;
        statsMap["Luck"] += item.stats.Luck;
    }

    public void RemoveStatsFromItem(EquippableItem item) {
        statsMap["Strength"] -= item.stats.Strength;
        statsMap["Agility"] -= item.stats.Agility;
        statsMap["Constitution"] -= item.stats.Constitution;
        statsMap["Wisdom"] -= item.stats.Wisdom;
        statsMap["Defense"] -= item.stats.Defense;
        statsMap["Luck"] -= item.stats.Luck;   
    }


}
