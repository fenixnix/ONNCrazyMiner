using System;
using System.Numerics;

[Serializable]
public class CMLadderInfo
{
    public LadderUnit[] members;
}

[Serializable]
public class LadderUnit
{
    BigInteger bigInt = 0;
    public int Round = 0;
    public string Addr = "none";
    public int Bonus = 0;
}

