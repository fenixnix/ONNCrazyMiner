using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class ONNConnector : MonoBehaviour
{
    string httpAddr = "http://47.75.190.195:3000";
    string contract = "CM10";

    public CrazyMiner cm;
    public CrazyMinerUI cmUI;

    NECDsa dsa = new NECDsa();
    OnnRequest onnReq = new OnnRequest();
    public KeyPair keyPair = new KeyPair();
    string m_info = "null";

    void Start()
    {
        NixLib.NWallet.SelfTest();
        Debug.Log(NixLib.NMnemonicWord.SelfTest());
        NDEA.SelfTest();
        Debug.Log(Utils.SelfTest());
        Debug.Log(NECDsa.SelfTest());

        cmUI = GetComponent<CrazyMinerUI>();
        cm = GetComponent<CrazyMiner>();

        if (PlayerPrefs.HasKey("SecKey"))
        {
            keyPair.pri = PlayerPrefs.GetString("SecKey");
            keyPair.pub = PlayerPrefs.GetString("PubKey");
            keyPair.addr = PlayerPrefs.GetString("Addr");
        }
        else
        {
            dsa.Generate();
            keyPair.pri = dsa.secKeyStr;
            keyPair.pub = dsa.pubKeyStr.ToUpper();
            keyPair.addr = dsa.ethAddrStr;

            PlayerPrefs.SetString("SecKey", keyPair.pri);
            PlayerPrefs.SetString("PubKey", keyPair.pub);
            PlayerPrefs.SetString("Addr", keyPair.addr);
        }

        onnReq.Init(keyPair.pri);
        onnReq.SetUrlContract(httpAddr, contract);

        Debug.Log(JsonUtility.ToJson(keyPair));

        InvokeRepeating("Tick", 0.3f, 1f);
    }

    public void GetInfo(string dat)
    {
        m_info = dat;
    }

    public void GetLadder(string dat)
    {
        Debug.Log("getLadder");
        Debug.Log(dat);
        if (dat == "")
        {
            return;
        }
        var jsonString = "{\"members\":" + dat + "}";
        Debug.Log(jsonString);
        cm.data.ladderInfo = JsonUtility.FromJson<CMLadderInfo>(jsonString);
        cmUI.UpdateLadder();
    }

    public void GetOnnInfo()
    {
        byte[] hex = Encoding.Default.GetBytes(keyPair.addr);
        var hexString = Utils.Byte2HexStr(hex);
        StartCoroutine(NHttp.Get(onnReq.Get("getInfo", hexString), GetInfo));
    }

    public void GetOnnLadder()
    {
        StartCoroutine(NHttp.Get(onnReq.Get("getLadderInfo"), GetLadder));
    }

    public void BuyOnnCalcPower()
    {
        var arg = Utils.Str2HexStr("null");
        var para = onnReq.Post("BuyHash", arg);
        Debug.Log(para);
        StartCoroutine(NHttp.Post(httpAddr, para));
    }

    public void WithDrawal(string addr, float amount)
    {
        var arg = Utils.Str2HexStr(addr + "?" + amount);
        Debug.Log(arg);
        var para = onnReq.Post("withDrawal", arg);
        Debug.Log(para);
        StartCoroutine(NHttp.Post(httpAddr, para));
    }

    public void Tick()
    {
        GetOnnInfo();
        Debug.Log(m_info);
        if (m_info != "null")
        {
            var ret = JsonUtility.FromJson<CrazyMinerData>(m_info);
            if (ret != null)
            {
                cm.data = ret;
            }
        }
    }
}

[Serializable]
public class KeyPair
{
    public string pri = string.Empty;
    public string pub = string.Empty;
    public string addr = string.Empty;
}
