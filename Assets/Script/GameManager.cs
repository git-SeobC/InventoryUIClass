using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        List<UserInventoryData> items = new()
        {
            UserInventoryData.Acquire(11001),
            UserInventoryData.Acquire(12001),
            UserInventoryData.Acquire(13001),
            UserInventoryData.Acquire(14001),
            UserInventoryData.Acquire(15001)
        };

        // 경로 -> 외부에서 받아오도록 하는 것이 좋음
        string path = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        IUserInventoryDataRepository repo = new TestUserInventoryDataRepository(path, items);

        InventoryService inventoryService = new InventoryService(repo);

        foreach (var item in repo.FindAll())
        {
            Debug.Log($"{item}");
        }

        inventoryService.Save();
    }
}
