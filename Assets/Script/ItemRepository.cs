using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Weapon,
    Sheild,
    ChestArmor,
    Gloves,
    Boots,
    Accessary
}

public enum ItemGrade
{
    None,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

// 우리 게임에서 사용할 아이템 객체 => 도메인 객체 / 엔티티(Entity)
public sealed class Item
{
    private int _id;
    private string _name;
    private ItemType _type;
    private ItemGrade _grade;
    private int _atk;
    private int _def;

    public Item(int id, string name, int atk, int def)
    {
        _id = id;
        _name = name;
        _atk = atk;
        _def = def;

        _type = GetType(id);
        _grade = GetGrade(id);
    }

    public override string ToString()
    {
        return $"Item(id: {_id}, name: {_name}, type: {_type}, grade: {_grade}, atk: {_atk}, def: {_def})";
    }

    private ItemType GetType(int id)
    {
        char type = id.ToString()[0];
        if (type == '1') return ItemType.Weapon;
        else if (type == '2') return ItemType.Sheild;
        else if (type == '3') return ItemType.ChestArmor;
        else if (type == '4') return ItemType.Gloves;
        else if (type == '5') return ItemType.Boots;
        else if (type == '6') return ItemType.Accessary;
        else return ItemType.None;
    }

    private ItemGrade GetGrade(int id)
    {
        int value = id % 10000 / 1000;
        switch (value)
        {
            case 1:
                return ItemGrade.Common;
            case 2:
                return ItemGrade.Uncommon;
            case 3:
                return ItemGrade.Rare;
            case 4:
                return ItemGrade.Epic;
            case 5:
                return ItemGrade.Legendary;
            default:
                return ItemGrade.None;
        }
        //char grade = id.ToString()[1];
        //if (grade == '1') return ItemGrade.Common;
        //else if (grade == '2') return ItemGrade.Uncommon;
        //else if (grade == '3') return ItemGrade.Rare;
        //else if (grade == '4') return ItemGrade.Epic;
        //else if (grade == '5') return ItemGrade.Legendary;
        //else return ItemGrade.None;
    }
}

// 목적 : LoadJson을 파싱을 했을 때 모든 아이템 목록을 확인
// Item 관련 Persistency를 담당한다.
public class ItemRepository
{
    private List<Item> _items;

    public ItemRepository()
    {
        LoadJson();
    }

    // 외부에서 변경이 이루어 지면 안됨 -> readonly를 통해 변경 막기
    public IReadOnlyList<Item> FindAll() => _items.AsReadOnly();

    // DTO ; Data Transfer Object
    // 외부와 소통하기 위한 객체, 직렬화만을 위한 객체, 데이터 전송만을 위한 객체
    // 보통 이름에 Model을 붙여줌
    [Serializable]
    class ItemModel
    {
        public int item_id;
        public string item_name;
        public int attack_power;
        public int defense;
    }

    [Serializable]
    class ItemModelList
    {
        public ItemModel[] data;
    }

    void LoadJson()
    {
        // Json 파일을 읽어와야 합니다.
        // ㄴ Json 파일은 어디에? -> Unity 외부에있음
        // ㄴ     1) 파일 입출력 , 2) Resources , 3) Assetbundle , 4) Addresable

        TextAsset jsonFile = Resources.Load<TextAsset>("Json/items");
        string json = jsonFile.text;
        ItemModelList itemModelList = JsonUtility.FromJson<ItemModelList>(json);

        // _items 초기화
        _items = new List<Item>();
        foreach (var itemModel in itemModelList.data)
        {
            _items.Add(new Item(itemModel.item_id, itemModel.item_name, itemModel.attack_power, itemModel.defense));
        }
    }
}