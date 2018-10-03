using System;

[Serializable]
public class CrazyMinerData
{
    public int Round = 1;
    public bool IsPlaying = false;
    public int TotalPlayer = 0;
    public int TotalCalcPower = 0;
    public int CalcPowerPrice = 1000;
    public int MinePool = 0;
    public int BonusPool = 0;
    public string LastIncoming = "none";
    public string Banker = "none";

    public int Balance = 0;
    public int CalcPower = 0;

    public CMLadderInfo ladderInfo = new CMLadderInfo();
}

