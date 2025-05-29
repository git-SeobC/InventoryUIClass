using System.Collections.Generic;
using System;
using System.Linq;

public class UserInventory
{
    private Inventory _inventory;
    private Equipment _equipment;

    public static UserInventory CreateEmpty()
    {
        return new UserInventory
            (Inventory.CreateEmpty(),
            Equipment.CreateEmpty());
    }

    public UserInventory(Inventory inventory, Equipment equipment)
    {
        _inventory = inventory;
        _equipment = equipment;
    }

    public void AcquipItem(UserInventoryData item)
    {
        _inventory.AddItem(item);
    }

    public IReadOnlyCollection<UserInventoryData> Items => _inventory.Items;

    public IReadOnlyDictionary<EquipSlotType, UserInventoryData> EquippedItems => _equipment.EquippedItems;

    public IReadOnlyCollection<UserInventoryData> UnequippedItems // 인벤토리의 모든 아이템 중 장착된 아이템을 제외하고 반환
    {
        get
        {
            // 빠르게 찾기위해서 HashSet을 사용한다.
            var equipped = _equipment.EquippedItems.Values.ToHashSet();
            // Inventory : 소유한 모든 아이템을 관리
            // Equipment : 장착된 아이템을 관리

            return Items
                .Where(item => equipped.Contains(item) == false)
                .ToList();
        }
    }
}