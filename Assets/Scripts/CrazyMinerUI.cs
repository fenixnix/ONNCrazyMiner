using System;
using UnityEngine;
using UnityEngine.UI;

public class CrazyMinerUI : MonoBehaviour {
    CrazyMiner cm;
    ONNConnector onn;

    public Text round;
    public Text totalPlayer;
    public Text totalCalcPower;
    public Text calcPowerPrice;
    public NTickNumber minePool;
    public NTickNumber bonusPool;
    public Text lastIncoming;

    public InputField localAddr;
    public NTickNumber balance;
    public Text balanceTransfer;
    public Text calcPower;

    public CreateQR localAddrQRCode;
    public NCirclePercent calcPowerRate;
    public Text timeOut;
    public UpdateLadder ladder;

    public MinerEffect minerEffect;

    public void UpdateLadder()
    {
        Debug.Log("UpdateLadder");
        ladder.UpdateList(cm.data.ladderInfo);
    }

    // Use this for initialization
    void Start () {
        cm = GetComponent<CrazyMiner>();
        onn = GetComponent<ONNConnector>();
	}

    float displayRate = 1;
	void Update () {
        //round.text = "疯狂矿机 第 " + cm.data.Round.ToString() + " 期";
        round.text = cm.data.Round.ToString();
        totalPlayer.text = cm.data.TotalPlayer.ToString();
        totalCalcPower.text = cm.data.TotalCalcPower.ToString();
        calcPowerPrice.text = (cm.data.CalcPowerPrice/ displayRate).ToString();
        minePool.SetValue(cm.data.MinePool/ displayRate);
        bonusPool.SetValue(cm.data.BonusPool/ displayRate);

        if (cm.data.LastIncoming == onn.keyPair.addr)
        {
            lastIncoming.text = "就是你！！！";
        }
        else
        {
            lastIncoming.text = cm.data.LastIncoming;
        }

        localAddr.text = onn.keyPair.addr;
        localAddrQRCode.CreatQr("0xdac7a3de021a8d3bc64db090062f352c855299ea");
        balance.SetValue(cm.data.Balance/ displayRate);
        balanceTransfer.text = (cm.data.Balance*displayRate).ToString();
        calcPower.text = cm.data.CalcPower.ToString();
        //calcPowerRate.SetValue((float)cm.data.CalcPower / (float)cm.data.TotalCalcPower);
        minerEffect.SetHashRate(cm.data.CalcPower);

        if (cm.data.TotalCalcPower > 0)
        {
            int timeOutSec = Mathf.RoundToInt(cm.data.MinePool / cm.data.TotalCalcPower);
            if (timeOutSec > 0)
            {
                var to = new TimeSpan(0, 0, timeOutSec);
                //timeOut.text = "预计在" + to.ToString("hh\\时mm\\分ss\\秒") + "后开出大奖";
                timeOut.text = to.ToString("hh\\:mm\\:ss");
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
	}
}
