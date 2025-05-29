using Gpm.Ui;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryServiceLocatorSO _serviceLocator;

    [SerializeField] private InfiniteScroll _infiniteScroll;

    private IInventoryService _inventoryService;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (var viewModel in _serviceLocator.Service.UnequippedItems)
        {
            Sprite gradeBackgroundSprite = Resources.Load<Sprite>($"Textures/{viewModel.GradeSpritePath}");
            Sprite itemIconSprite = Resources.Load<Sprite>($"Textures/{viewModel.ItemIconPath}");

            var slotData = new InventoryItemSlotData(gradeBackgroundSprite, itemIconSprite, viewModel.Quantity);

            _infiniteScroll.InsertData(slotData);
        }
    }

}
