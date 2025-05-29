using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryServiceLocatorSO", menuName = "Scriptable Objects/InventoryServiceLocatorSO")]
public class InventoryServiceLocatorSO : ScriptableObject
{
    [SerializeField] private string _userInventoryPath;
    public IInventoryService Service { get; private set; }

    public void Bootstrap()
    {
        string path = Path.Combine(Application.persistentDataPath, _userInventoryPath);

        IUserInventoryDataRepository repo = new UserInventoryDataRepository(path);
        IItemRepository itemRepo = new JsonItemRepository();

        Service = new InventoryService(repo, itemRepo);
    }
}
