using System.Collections;
using UnityEngine;

public class NHttp
{
    public delegate void DataProcessFunction(string str);
    static string m_err = "null";
    public static IEnumerator Post(string url, string data)
    {
        using (WWW www = new WWW(url, Utils.Str2Byte(data)))
        {
            yield return www;
            if (www.error != null)
            {
                yield return null;
            }
        }
    }
    public static IEnumerator Get(string url, DataProcessFunction pFun)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            if (www.error != null)
            {
                m_err = www.error;
                yield return null;
            }
            pFun(www.text);
        }
    }
}

