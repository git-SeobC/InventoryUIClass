using Gpm.Ui;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlotData : InfiniteScrollData
{
    public Sprite GradeBackgroundSprite { get; }
    public Sprite ItemIconSprite { get; }
}

public class InventoryItemSlot : InfiniteScrollItem
{
    [SerializeField] private Image _gradeBackgroud;
    [SerializeField] private Image _itemIcon;

    public override void UpdateData(InfiniteScrollData scrollData)
    {
        base.UpdateData(scrollData);

        InventoryItemSlotData data = scrollData as InventoryItemSlotData;

        _gradeBackgroud.sprite = data.GradeBackgroundSprite;
        _itemIcon.sprite = data.ItemIconSprite;
    }
}