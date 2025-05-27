using System.Collections.Generic;
using System.Linq;

public class UserInventoryDataViewModel
{
    public string GradeSpritePath { get; }
    public string ItemIconPath { get; }

    public UserInventoryDataViewModel(string gradeSpritePath, string itemIconPath)
    {

    }
}

public interface IInventoryService
{
    IReadOnlyList<UserInventoryDataViewModel> FindAll();
}

/// <summary>
/// 인벤토리 기능 구현
/// </summary>
public class InventoryService : IInventoryService
{
    private IUserInventoryDataRepository _inventoryDataRepository;
    /// <summary>
    /// 유저가 획득한 아이템
    /// </summary>
    // 레포지토리를 확용해서 기능 구현
    public IReadOnlyList<UserInventoryData> Items => _inventoryDataRepository.FindAll();

    public void Save() => _inventoryDataRepository.Save();

    public IReadOnlyList<UserInventoryDataViewModel> FindAll()
    {
        var allItem = _inventoryDataRepository.FindAll();

        // itemId를 이용해 아이템 객체를 복원해야 함
        Item item = _itemRepository.FindBy(allItem[0].ItemId);
        // UserInventoryDataViewModel 객체를 만들어서 반환

        // item으로부터 gradPath, iconPath를 알 수 있을까?
        Item item = _itemRepository.FindBy(allItem[0].ItemId);

        var viewModel = new UserInventoryDataViewModel(
            item.GradePath,
            item.IconPath);

        return _inventoryDataRepository.FindAll().Select(userInventoryData =>
        {
            Item item = _inventoryDataRepository.FindBy(userInventoryData.ItemId);
            return new UserInventoryDataViewModel(item.GradePath, item.IconPath);
        }).ToList();
    }

    public InventoryService(IUserInventoryDataRepository inventoryDataRepository)
    {
        _inventoryDataRepository = inventoryDataRepository;
    }
}
