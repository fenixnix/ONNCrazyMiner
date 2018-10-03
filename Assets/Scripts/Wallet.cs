using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using NixLib;

public class Wallet : MonoBehaviour
{

    public NNewPassword newPwd;
    public NPassword pwd;
    public NTextInput input;

    public NQRLabel qrCode;

    public NMessageBox msgBox;
    public Text addrLabel;
    public NWallet wallet = new NWallet();

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if (NWallet.HasWallet())
        {
            wallet.dat.Load();
            addrLabel.text = wallet.GetAddress();
        }
    }

    public void ShowAddrQrCode()
    {
        qrCode.Set(wallet.GetAddress());
    }

    public void RunNewWallet()
    {
        StartCoroutine("NewWallet");
    }

    public void RunImportKey()
    {
        StartCoroutine("ImportKey");
    }

    public void RunExportKey()
    {
        StartCoroutine("ExportKey");
    }

    public void RunUserKeyModify()
    {
        StartCoroutine("UserKeyModify");
    }

    IEnumerator NewWallet()
    {
        if (NWallet.HasWallet())
        {
            msgBox.ShowMsgBox("", "已经存在钱包");
        }
        else
        {
            yield return StartCoroutine("WaitForNewPWD");
            wallet.GenerateKey(newPwd.rawPWD);
            msgBox.ShowMsgBox("成功创建新钱包", "地址：" + wallet.GetAddress());
            addrLabel.text = wallet.GetAddress();
        }
    }

    IEnumerator ImportKey()
    {
        if (NWallet.HasWallet())
        {
            msgBox.ShowMsgBox("警告", "已经存在钱包,建议导入前先导出并备份本地钱包");
            yield return StartCoroutine("WaitForPWD");
        }
        yield return StartCoroutine("WaitForTextInput");
        var key = input.rawDat;
        yield return StartCoroutine("WaitForNewPWD");
        var pwd = newPwd.rawPWD;
        wallet.ImportKey(pwd, key);
        msgBox.ShowMsgBox("成功导入钱包", "地址：" + wallet.GetAddress());
        addrLabel.text = wallet.GetAddress();
    }

    IEnumerator ExportKey()
    {
        if (NWallet.HasWallet())
        {
            yield return StartCoroutine("WaitForPWD");
            if (wallet.CheckUserPwd(pwd.rawPWD))
            {
                qrCode.Set(wallet.ExportSecKey(pwd.rawPWD));
            }
            else
            {
                msgBox.ShowMsgBox("警告", "密码错误");
                yield return null;
            }
        }
        else
        {
            msgBox.ShowMsgBox("", "尚未创建钱包");
            yield return null;
        }
    }

    public void ImportMKey()
    {

    }

    public void ExportMKey()
    {

    }

    IEnumerator UserKeyModify()
    {
        if (NWallet.HasWallet())
        {
            yield return StartCoroutine("WaitForPWD");
            if (wallet.CheckUserPwd(pwd.rawPWD))
            {
                yield return StartCoroutine("WaitForNewPWD");
                var key = wallet.ExportSecKey(pwd.rawPWD);
                wallet.ImportKey(newPwd.rawPWD, key);
                msgBox.ShowMsgBox("", "密码修改成功");
            }
            else
            {
                msgBox.ShowMsgBox("警告", "密码错误");
                yield return StartCoroutine("UserKeyModify");
            }
        }
        else
        {
            msgBox.ShowMsgBox("", "尚未创建钱包");
        }
    }

    IEnumerator WaitForPWD()
    {
        pwd.Init();
        while (pwd.WaitForInput())
        {
            yield return 0;
        }
        yield return 1;
    }

    IEnumerator WaitForNewPWD()
    {
        newPwd.Init();
        while (newPwd.WaitForInput())
        {
            yield return 0;
        }
        yield return 1;
    }

    IEnumerator WaitForTextInput()
    {
        input.Init();
        Debug.Log("Wait for Input");
        while (input.WaitForInput())
        {
            yield return 0;
        }
        Debug.Log("finish Input:" + input.rawDat);
        yield return 1;
    }
}
