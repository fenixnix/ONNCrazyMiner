using System.Collections.Generic;

public class OnnRequest
{
    string url = string.Empty;
    string contract = string.Empty;

    string urlContract = string.Empty;
    string onnAddr = string.Empty;

    NECDsa dsa = new NECDsa();

    public void Init(string secKey)
    {
        dsa.Import(secKey);
        onnAddr = dsa.ethAddrStr;
    }

    public void SetUrlContract(string url, string contract)
    {
        this.url = url;
        this.contract = contract;
        urlContract = url + "/" + contract;
    }

    public string Get(string method, string arg = "null")
    {
        List<string> list = new List<string>();
        list.Add(urlContract);
        list.Add(method);
        list.Add(arg);
        list.Add(onnAddr);
        return string.Join("$", list);
    }

    public string Post(string method, string arg = "null")
    {
        List<string> list = new List<string>();
        list.Add("method");
        list.Add(dsa.pubKeyStr.ToUpper());
        list.Add(contract);
        list.Add(method);
        list.Add(arg);
        var block = string.Join("$", list);
        var sign = dsa.SignStr(block);
        return sign.ToUpper() + "&" + block;
    }
}

