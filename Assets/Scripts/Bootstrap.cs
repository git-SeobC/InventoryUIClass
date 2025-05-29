using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private InventoryServiceLocatorSO _inventoryServiceLocator;

    private void Awake()
    {
        _inventoryServiceLocator.Bootstrap();
    }
}
