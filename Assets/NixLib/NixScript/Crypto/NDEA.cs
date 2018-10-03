using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class NDEA
{
    static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    AesManaged aes = new AesManaged();
    ICryptoTransform encryptor;
    ICryptoTransform decryptor;

    static public void SelfTest()
    {
        NDEA dea = new NDEA();
        dea.SetStringKey("hello!");

        var code = dea.EnCrypto("hello world!");
        Debug.Log(dea.DeCryptoString(code));
        dea.SetStringKey("World");
        Debug.Log(dea.DeCryptoString(code));
    }

    static public byte[] GenerateKey()
    {
        AesManaged aes = new AesManaged();
        aes.GenerateKey();
        return aes.Key;
    }

    public void SetStringKey(string keyString)
    {
        SetKey((new SHA256Managed()).ComputeHash(Encoding.ASCII.GetBytes(keyString)));
    }

    public void SetKey(byte[] key)
    {
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.Zeros;
        aes.IV = IV;
        aes.Key = (key);
        encryptor = aes.CreateEncryptor();
        decryptor = aes.CreateDecryptor();
    }

    public byte[] EnCrypto(string src)
    {
        var dat = Encoding.ASCII.GetBytes(src);
        return encryptor.TransformFinalBlock(dat, 0, dat.Length);
    }

    public byte[] EnCrypto(byte[] src)
    {
        return encryptor.TransformFinalBlock(src, 0, src.Length);
    }

    public string DeCryptoString(byte[] src)
    {
        return Utils.Byte2Str(DeCrypto(src));
    }

    public byte[] DeCrypto(byte[] src)
    {
        return decryptor.TransformFinalBlock(src, 0, src.Length);
    }

}
