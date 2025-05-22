using UnityEngine;
using System;




public class GameManager : MonoBehaviour
{
    void Start()
    {
        ItemRepository repo = new();
        foreach (var item in repo.FindAll())
        {
            Debug.Log($"{item}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
