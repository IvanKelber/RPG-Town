using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "Equippable", menuName = "Equipment/Equipment", order = 1)]
public class Equipment : ScriptableObject
{

    public GameEvent equipmentChanged;

    public ItemCollection inventory;

    private Dictionary<EquipSlot, EquippableItem> _map;

    public Dictionary<EquipSlot, EquippableItem> EquipmentMap {get {return _map;} private set {_map = value;}}
    public Dictionary<string, int> statsMap;

    private List<SerializedEquipment> serializedEquipment;

    private void OnEnable() {

        if(_map == null) {
            _map = new Dictionary<EquipSlot, EquippableItem>();
        }
        if(serializedEquipment == null) {
            serializedEquipment = new List<SerializedEquipment>();
        }
        if(statsMap == null) {
            statsMap = new Dictionary<string, int>();
            statsMap.Add("Strength", 0);
            statsMap.Add("Agility", 0);
            statsMap.Add("Constitution", 0);
            statsMap.Add("Wisdom", 0);
            statsMap.Add("Defense", 0);
            statsMap.Add("Luck", 0);

        }
        DeserializeEquipment();
    }

    private void OnDestroy() {
        SerializeEquipment();
    }

    private void SerializeEquipment() {
        foreach(var pair in _map) {
            serializedEquipment.Add(new SerializedEquipment(pair));
        }
    }

    private void DeserializeEquipment() {
        foreach(SerializedEquipment equipment in serializedEquipment) {
            _map.Add(equipment.slot, equipment.item);
        }
    }

    public void Equip(EquipSlot slot, EquippableItem item) {
        inventory.Remove(item);
        if(_unequip(slot)) {
            _map.Add(slot, item);
            AddStatsFromItem(item);
            equipmentChanged.Raise();
        } else {
            inventory.Add(item);
        }
    }

    // Returns whether or not the item was successfully unequiped
    public bool _unequip(EquipSlot slot) {
        EquippableItem preEquipped;
        if(_map.TryGetValue(slot, out preEquipped)) {
            bool removed = inventory.Add(preEquipped) && _map.Remove(slot); // won't unequip unless there's room in the inventory
            if(removed) {
                RemoveStatsFromItem(preEquipped);
            }
            return removed;
        }
        //There was nothing to unequip
        return true;
    }

    public bool Unequip(EquipSlot slot) {
        bool unequipped = _unequip(slot);
        if(unequipped) {
            equipmentChanged.Raise();
        }
        return unequipped;
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

    [Serializable]
    struct SerializedEquipment {
        public EquipSlot slot;
        public EquippableItem item;

        public SerializedEquipment (KeyValuePair<EquipSlot, EquippableItem> pair) {
            this.slot = pair.Key;
            this.item = pair.Value;
        }
    }

}
