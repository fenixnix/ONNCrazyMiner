using System;
using System.Collections.Generic;
using UnityEngine;
namespace NixLib
{
    //bip-0039
    //bip-0032
    //bip-0044
    public class NMnemonicWord
    {
        static BIP39.Wordlists.Wordlist dict = new BIP39.Wordlists.ChineseSimplified();

        static public string SelfTest()
        {
            string txt = string.Empty;
            txt += "Genrate:" + "\n";
            var res = Generate("14A0633A9D963234D2DE219D900937B2E7F04F8EDC0B3173D317489ACB2B9942");
            var resString = string.Join(",", res);
            txt += resString + "\n";
            txt += Parse(resString) + "\n";
            return txt;
        }

        static public string GenerateString(string src,string sep = ",")
        {
            var indexArray = GenerateIndexArray(src);
            List<string> words = new List<string>();
            foreach (var d in indexArray)
            {
                words.Add(dict.GetWordAtIndex(d));
            }
            return string.Join("sep",words.ToArray());
        }

        static public string[] Generate(string src)
        {
            var indexArray = GenerateIndexArray(src);
            List<string> words = new List<string>();
            foreach (var d in indexArray)
            {
                words.Add(dict.GetWordAtIndex(d));
            }
            return words.ToArray();
        }

        static public int[] GenerateIndexArray(string src)
        {
            //check data valid;
            var srcDat = Utils.HexStr2Byte(src);
            var hashHexDat = Utils.Hash256(srcDat);
            var head = Utils.Byte2BinStr(hashHexDat).Substring(0, 8);
            var binaryString = Utils.Byte2BinStr(srcDat) + head;
            var dataArray = Utils.StringSplit(binaryString, 11);
            List<int> indexs = new List<int>();
            foreach (var d in dataArray)
            {
                var val = Convert.ToInt32(d, 2);
                indexs.Add(val);
            }
            return indexs.ToArray();
        }

        static public string Parse(string dat,char sep = ',')
        {
            var stringArray = dat.Split(sep);
            List<int> indexList = new List<int>();
            foreach(var str in stringArray)
            {
                int index = 0;
                dict.WordExists(str, out index);
                indexList.Add(index);
            }
            //indexArray to binaryString
            string binaryString = string.Empty;
            foreach(var i in indexList)
            {
                var bs = Convert.ToString(i, 2).PadLeft(11, '0');
                binaryString += bs;
            }
            var binStrArray = Utils.StringSplit(binaryString.Substring(0, 256), 8);
            return Utils.Byte2HexStr(Utils.BinStr2Byte(binStrArray));
        }
    }
}
