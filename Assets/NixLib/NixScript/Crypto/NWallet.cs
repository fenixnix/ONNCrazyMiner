using System.Text;
using UnityEngine;

namespace NixLib
{
    public class NWallet
    {
        public NWalletDat dat = new NWalletDat();

        static public void SelfTest()
        {
            var wallet = new NWallet();
            var keyString = "qweasd";
            wallet.GenerateKey(keyString);
            var secKeyString = wallet.ExportSecKey(keyString);
            Debug.Log("Gen SecKey:" + secKeyString);
            wallet.ImportKey(keyString, secKeyString);
            var exportSecKeyString = wallet.ExportSecKey(keyString);
            Debug.Log("Import Export:" + exportSecKeyString);
            var wrongKeyExportSecKeyString = wallet.ExportSecKey("WrongKey");
            Debug.Log("WrongKey Export:" + wrongKeyExportSecKeyString);
        }

        static public bool HasWallet()
        {
            return PlayerPrefs.HasKey("SecKeyCrypto");
        }

        public string GetAddress()
        {
            return dat.address;
        }

        public bool CheckUserPwd(string pwd)
        {
            var keyMd5 = Utils.GetMD5(Encoding.ASCII.GetBytes(pwd));
            return PasswordEquals(keyMd5, dat.userKeyMD5);
        }

        public void GenerateKey(string userKey)
        {
            NECDsa dsa = new NECDsa();
            dsa.Generate();
            ImportKey(userKey, dsa.secKeyStr);
            dat.Save();
        }

        public bool ImportKey(string userKey, string secKeyHexString)
        {
            dat.userKeyMD5 = Utils.GetMD5(Encoding.ASCII.GetBytes(userKey));
            if (secKeyHexString.Length != 64)
            {
                return false;
            }
            var secKey = Utils.HexStr2Byte(secKeyHexString);
            var mainKey = NDEA.GenerateKey();
            var dea = new NDEA();
            dea.SetStringKey(userKey);
            dat.mainKeyCrypto = dea.EnCrypto(mainKey);
            dea.SetKey(mainKey);
            dat.secKeyCrypto = dea.EnCrypto(secKey);
            dat.address = NECDsa.getEthAddress(secKeyHexString);
            dat.Save();
            return true;
        }

        private bool PasswordEquals(byte[] b1, byte[] b2) {
            if (b1.Length != b2.Length) return false; if (b1 == null || b2 == null) return false; for (int i = 0; i < b1.Length; i++) if (b1[i] != b2[i]) return false; return true;
        }

        public string ExportSecKey(string userKey)
        {
            var md5 = Utils.GetMD5(Encoding.ASCII.GetBytes(userKey));
            if (!PasswordEquals(md5, dat.userKeyMD5))
                return string.Empty;

            var dea = new NDEA();
            dea.SetStringKey(userKey);
            var mainKey = dea.DeCrypto(dat.mainKeyCrypto);
            dea.SetKey(mainKey);
            return Utils.Byte2HexStr(dea.DeCrypto(dat.secKeyCrypto));
        }

        public string ExportMnemonicWord(string userKey)
        {
            return NMnemonicWord.GenerateString(ExportSecKey(userKey));
        }

        public void ImportMnemonicWord(string userKey, string mnemonicWord)
        {
            ImportKey(userKey, NMnemonicWord.Parse(mnemonicWord));
        }
    }

    public class NWalletDat
    {
        public byte[] userKeyMD5;
        public byte[] mainKeyCrypto;
        public byte[] secKeyCrypto;
        public string address;

        public void Save()
        {
            PlayerPrefs.SetString("SecKeyCrypto", Utils.Byte2HexStr(secKeyCrypto));
            PlayerPrefs.SetString("MainKeyCrypto", Utils.Byte2HexStr(mainKeyCrypto));
            PlayerPrefs.SetString("UserKeyMD5", Utils.Byte2HexStr(userKeyMD5));
            PlayerPrefs.SetString("Address", address);
        }

        public void Load()
        {
            secKeyCrypto = Utils.HexStr2Byte(PlayerPrefs.GetString("SecKeyCrypto"));
            mainKeyCrypto = Utils.HexStr2Byte(PlayerPrefs.GetString("MainKeyCrypto"));
            userKeyMD5 = Utils.HexStr2Byte(PlayerPrefs.GetString("UserKeyMD5"));
            address = PlayerPrefs.GetString("Address");
            //Debug.Log(JsonUtility.ToJson(this));
        }
    }
}
