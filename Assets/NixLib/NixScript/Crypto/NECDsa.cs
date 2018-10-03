using System.Numerics;
using Ecc;

public class NECDsa
{
    ECCurve curve = ECCurve.Secp256k1;
    ECPrivateKey secKey;
    ECPublicKey pubKey;
    public string pubKeyStr = string.Empty;
    public string secKeyStr = string.Empty;
    public string ethAddrStr = string.Empty;
    //public string onnAddrStr = string.Empty;
    
    public void Import(string key)
    {
        BigInteger num = BigIntegerExt.ParseHexUnsigned(key);
        secKey = new ECPrivateKey(num,curve);
        Init();
    }

    public void Generate()
    {
        secKey = curve.CreateKeyPair();
        Init();
    }

    void Init()
    {
        secKeyStr = secKey.D.ToHexUnsigned(32);
        pubKey = secKey.PublicKey;
        pubKeyStr = pubKey.Point.X.ToHexUnsigned(32) + pubKey.Point.Y.ToHexUnsigned(32);
        ethAddrStr = Utils.GetEthAddr(pubKeyStr);
        //onnAddrStr = Utils.GetOnnAddr(pubKeyStr);
    }

    public byte[] Sign(string msg)
    {
        var br = Utils.Str2Byte(msg);
        var sign = secKey.Sign(Utils.Hash256(br));
        //Debug.Log(Utils.Byte2HexStr(sign.R.ToByteArray()));
        //Debug.Log(Utils.Byte2HexStr(sign.S.ToByteArray()));
        return sign.ToByteArray();
    }

    public string SignStr(string msg)
    {
        return Utils.Byte2HexStr(Sign(msg));
    }

    //static public bool Verify(string pubKey, string msg, string signature)
    //{
    //    ECPublicKey pubKey = new ECPublicKey(new ECPoint());
    //    ECSignature sig = new ECSignature();

    //    return pubKey.VerifySignature(msg, signature);
    //}

    static public string getEthAddress(string secKey)
    {
        NECDsa dsa = new NECDsa();
        dsa.Import(secKey);
        return dsa.ethAddrStr;
    }

    static public string SelfTest()
    {
        string output = string.Empty;
        NECDsa dsa = new NECDsa();
        dsa.Generate();
        dsa.Sign("hello!");
        dsa.Sign("hello!");
        return output;
    }
}

