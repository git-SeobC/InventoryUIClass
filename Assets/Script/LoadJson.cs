//using System.Collections.Generic;
//using System;
//using UnityEngine;

//[Serializable]
//public class Item
//{
//    public int item_id;
//    public string item_name;
//    public int attack_power;
//    public int defense;
//}

//[Serializable]
//public class ItemData
//{
//    public List<Item> data;
//}

//public class LoadJson : MonoBehaviour
//{
//    void Start()
//    {
//        // Load the JSON file
//        TextAsset jsonFile = Resources.Load<TextAsset>("Json/items");
//        if (jsonFile != null)
//        {
//            // Deserialize the JSON data into an object
//            ItemData itemData = JsonUtility.FromJson<ItemData>(jsonFile.text);

//            // Log each item
//            foreach (var item in itemData.data)
//            {
//                Debug.Log($"ID: {item.item_id}, Name: {item.item_name}, Attack: {item.attack_power}, Defense: {item.defense}");
//            }
//        }
//        else
//        {
//            Debug.LogError("Failed to load JSON file.");
//        }
//    }
//}