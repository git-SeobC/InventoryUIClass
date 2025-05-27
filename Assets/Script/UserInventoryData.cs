using System;

public class UserInventoryData
{
    // 식별자 규칙 : 획득연월일 난수4자리 ex) 202309011234
    public static readonly Random random = new();

    public long SerialNumber { get; }
    public int ItemId { get; }

    public static UserInventoryData Acquire(int itemId)
    {
        int rndNum = random.Next(10000);
        long serialNumber = long.Parse(DateTime.Now.ToString("yyyyMMdd") + rndNum.ToString("D4"));
        return new UserInventoryData(serialNumber, itemId);
    }

    public UserInventoryData(long serialNumber, int itemID)
    {
        SerialNumber = serialNumber;
        ItemId = itemID;
    }

    public override string ToString()
    {
        return $"Inven Data : {SerialNumber}, {ItemId}";
    }
}