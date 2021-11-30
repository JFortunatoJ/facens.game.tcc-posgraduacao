using System;

[Serializable]
public struct CoinsStruct
{
    public int amount;

    public CoinsStruct(int amount)
    {
        this.amount = amount;
    }
}
