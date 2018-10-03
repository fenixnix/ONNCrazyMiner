using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class CreateQR : MonoBehaviour
{
    //在屏幕上显示二维码  
    //public RawImage rawImage;
    public Image image;
    //存放二维码  
    Texture2D encoded;
    Sprite sprite;
    // Use this for initialization  
    void Start()
    {
        encoded = new Texture2D(256, 256);
    }

    /// <summary>
    /// 定义方法生成二维码 
    /// </summary>
    /// <param name="textForEncoding">需要生产二维码的字符串</param>
    /// <param name="width">宽</param>
    /// <param name="height">高</param>
    /// <returns></returns>       
    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }


    /// <summary>  
    /// 生成二维码  
    /// </summary>  
    public void CreatQr(string text)
    {
        if (encoded == null) return;
        if (text.Length > 1)
        {
            //二维码写入图片    
            var color32 = Encode(text, encoded.width, encoded.height);
            encoded.SetPixels32(color32);
            encoded.Apply();
            //生成的二维码图片附给RawImage    
            //rawImage.texture = encoded;
            sprite = Sprite.Create(encoded, new Rect(0, 0, encoded.width, encoded.height), new Vector2(0.5f, 0.5f));
            image.sprite = sprite;
            image.preserveAspect = true;
        }
        else
        {
            GameObject.Find("Text_1").GetComponent<Text>().text = "没有生成信息";
        }
    }
}