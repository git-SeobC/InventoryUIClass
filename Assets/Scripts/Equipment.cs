using System;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private EquipSlot[] _equipSlots;

    public Equipment()
    {
        _equipSlots = new EquipSlot[6];
        _equipSlots[GetIndexFrom(EquipSlotType.Weapon)] = new EquipSlot(EquipSlotType.Weapon);
        _equipSlots[GetIndexFrom(EquipSlotType.Sheild)] = new EquipSlot(EquipSlotType.Sheild);
        _equipSlots[GetIndexFrom(EquipSlotType.ChestArmor)] = new EquipSlot(EquipSlotType.ChestArmor);
        _equipSlots[GetIndexFrom(EquipSlotType.Gloves)] = new EquipSlot(EquipSlotType.Gloves);
        _equipSlots[GetIndexFrom(EquipSlotType.Boots)] = new EquipSlot(EquipSlotType.Boots);
        _equipSlots[GetIndexFrom(EquipSlotType.Accessory)] = new EquipSlot(EquipSlotType.Accessory);
    }

    public void Equip(EquipSlotType type, UserInventoryData item)
    {
        _equipSlots[GetIndexFrom(type)].Equip(item);
    }

    public void Unequip(EquipSlotType type)
    {

    }
}
