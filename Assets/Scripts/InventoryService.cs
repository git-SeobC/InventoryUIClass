using System;
using System.Collections.Generic;
using System.Linq;

public class UserInventoryDataViewModel
{
    public string GradeSpritePath { get; }
    public string ItemIconPath { get; }
    public int Quantity { get; }

    public UserInventoryDataViewModel(string gradeSpritePath, string itemIconPath, int quantity)
    {
        GradeSpritePath = gradeSpritePath;
        ItemIconPath = itemIconPath;
        Quantity = quantity;
    }
}

public class EquipSlotViewModel
{
    public string GradeSpritePath { get; }
    public string ItemIconPath { get; }

    public EquipSlotViewModel(string gradeSpritePath, string itemIconPath)
    {
        GradeSpritePath = gradeSpritePath;
        ItemIconPath = itemIconPath;
    }
}

public interface IInventoryService
{
    IReadOnlyCollection<UserInventoryDataViewModel> UnequippedItems { get; }

    void AcquipreRandomItem();
}


/// <summary>
/// 인벤토리의 기능
/// </summary>
public class InventoryService : IInventoryService
{
    private IUserInventoryDataRepository _inventoryDataRepository;
    private IItemRepository _itemRepository;
    private UserInventory _userInventory;

    public InventoryService(IUserInventoryDataRepository inventoryDataRepository, IItemRepository itemRepository)
    {
        _inventoryDataRepository = inventoryDataRepository;
        _itemRepository = itemRepository;

        // TODO: _inventory 초기화 필요
        //_inventory = _inventoryDataRepository.Load();
        _userInventory = UserInventory.CreateEmpty();
    }

    public IReadOnlyCollection<UserInventoryDataViewModel> UnequippedItems => _userInventory.UnequippedItems
        .Select(userItem =>
        {
            var item = _itemRepository.FindBy(userItem.ItemId);
            // userInventoryData -> UserInventoryDataViewModel
            var viewModel = new UserInventoryDataViewModel(
                item.GradePath, item.IconPath, userItem.Quantity);

            return viewModel;
        }).ToList();

    public void AcquipreRandomItem()
    {
        // 랜덤하게 아이템을 획득하여 인벤토리에 추가한다.

        // 3 -> 랜덤한 아이템 식별자를 만든다.
        //int rendomItemId = Item.GetRandomId();

        // 2 -> 유저 인벤토리 데이터 객체를 만든다.
        //UserInventoryData.Acquire(itemId);

        // 1 -> 인벤토리에 아이템을 추가한다. -> UserInventory가 시켜야 한다.
        //_userInventory.AcquipItem(item);
    }

    public void RandomItem()
    {
        // 랜덤한 아이템 식별자를 만든다.
    }
}