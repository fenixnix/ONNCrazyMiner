using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Crypto.Digests;
using UnityEngine;

public static class Utils
{
    public static string SelfTest()
    {
        string output = string.Empty;
        output += "hello!\n";
        var bytes = Str2Byte("hello!");
        var hexStr = Byte2HexStr(bytes);
        output += hexStr + "\n";
        var bytes2 = HexStr2Byte(hexStr);
        output += Byte2HexStr(bytes2) + "\n";
        var outStr = Byte2Str(bytes2);
        output += outStr + "\n";

        var hashStr = Hash256("hello!");
        output += "Hello! hashString: " + hashStr + "\n";

        output += "Byte2BinaryStr:\n";
        output += Byte2BinStr(bytes2) + "\n";

        output += "StringSplit:\n";
        var splitO = StringSplit("hello!", 2);
        foreach(var o in splitO)
        {
            output += o +"\n";
        }
        return output;
    }

    public static string Byte2BinStr(byte[] srcDat)
    {
        var hex = new StringBuilder(srcDat.Length * 8);
        foreach (var b in srcDat)
        {
            hex.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }
        return hex.ToString();
    }

    public static byte[] BinStr2Byte(string[] srcDat)
    {
        List<byte> br = new List<byte>();
        foreach (var b in srcDat)
        {
            br.Add(Convert.ToByte(b, 2));
        }
        return br.ToArray();
    }

    public static string Byte2HexStr(this byte[] bytes)
    {
        var hex = new StringBuilder(bytes.Length * 2);
        foreach (var b in bytes)
        {
            hex.AppendFormat("{0:x2}", b);
        }
        return hex.ToString();
    }

    public static byte[] Str2Byte(string src)
    {
        return Encoding.Default.GetBytes(src);
    }

    public static string Str2HexStr(string src)
    {
        return Byte2HexStr(Str2Byte(src));
    }

    public static string Byte2Str(byte[] src)
    {
        return Encoding.Default.GetString(src);
    }

    public static byte[] HexStr2Byte(string src)
    {
        var output = new byte[src.Length / 2];
        for(var i = 0; i< output.Length; i++)
        {
            output[i] = Convert.ToByte(src.Substring(i * 2, 2), 16);
        }
        return output;
    }

    public static byte[] Hash256(byte[] src)
    {
        Sha256Digest sha = new Sha256Digest();
        sha.BlockUpdate(src, 0, src.Length);
        byte[] output = new byte[sha.GetDigestSize()];
        sha.DoFinal(output, 0);
        return output;
    }

    public static byte[] GetMD5(byte[] src)
    {
        return MD5.Create().ComputeHash(src);
    }

    public static string Hash256(string src)
    {
        var byteArray = Str2Byte(src);
        return Byte2HexStr(Hash256(byteArray));
    }

    public static byte[] HashKeccak256(byte[] src)
    {
        KeccakDigest sha = new KeccakDigest(256);
        sha.BlockUpdate(src, 0, src.Length);
        byte[] output = new byte[sha.GetDigestSize()];
        sha.DoFinal(output, 0);
        return output; 
    }

    public static string HashKeccak256(string src)
    {
        var byteArray = Str2Byte(src);
        return Byte2HexStr(HashKeccak256(byteArray));
    }

    public static byte[] GetEthAddr(byte[] pubKey)
    {
        var dst = HashKeccak256(pubKey);
        byte[] res = new byte[20];
        System.Array.Copy(dst, 12, res, 0, 20);
        return res;
    }

    public static string GetEthAddr(string src)
    {
        var byteArray = HexStr2Byte(src);
        return Byte2HexStr(GetEthAddr(byteArray));
    }

    //public static string GetOnnAddr(string src)
    //{
    //    var byteArray = Str2Byte(src);
    //    var hash = HashKeccak256(byteArray);
    //    byte[] res = new byte[20];
    //    Array.Copy(hash, 0, res, 0, 20);
    //    return Byte2HexStr(res);
    //}

    public static string[] StringSplit(string src, int unitSize)
    {
        List<string> array = new List<string>();
        for(int i = 0; i<src.Length/unitSize; i++)
        {
            array.Add(src.Substring(i*unitSize, unitSize));
        }
        if(src.Length%unitSize != 0)
        {
            array.Add(src.Substring(src.Length - src.Length%unitSize));
        }
        return array.ToArray();
    }

    static public bool CheckEthAddr(string addr)
    {
        Regex reg = new Regex("0x[0-9,a-f,A-F]{40}");
        Debug.Log(addr);
        return reg.IsMatch(addr);
    }

    static public bool CheckHexString(string src)
    {
        if (src.Length % 2 != 0) return false;
        Regex reg = new Regex("[0-9,a-f,A-F]*");
        return reg.IsMatch(src);
    }
}

