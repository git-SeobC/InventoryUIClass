using Gpm.Ui;
using System.IO;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InfiniteScroll _infiniteScroll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        IUserInventoryDataRepository repo = new UserInventoryDataRepository(path);

        InventoryService inventoryService = new InventoryService(repo, itemRepo);

        foreach (var dataViewModel in inventoryService.FindAll())
        {
            Sprite gradeBackgroundSprite = Resources.Load<Sprite>(dataViewModel.GradeSpritePath);

            Sprite itemIconSprite = Resources.Load<Sprite>(dataViewModel.ItemIconPath);

        }
    }
}
