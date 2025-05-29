using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private InventoryServiceLocatorSO _serviceLocator;

    [SerializeField] private InventoryUI _inventoryUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //string path = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        //IUserInventoryDataRepository repo = new UserInventoryDataRepository(path);
        
        //InventoryService inventoryService = new InventoryService(repo);

        //foreach (var item in inventoryService.Items)
        //{
        //    Debug.Log($"{item}");
        //}

        //repo.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _serviceLocator.Service.AcquipreRandomItem();

            _inventoryUI.Refresh();
        }
    }

    
}
