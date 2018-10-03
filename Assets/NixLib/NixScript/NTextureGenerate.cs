using UnityEngine;

class NTextureGenerate
{
    public Texture2D texture;

    public void Generate()
    {
        texture = new Texture2D(100, 100);
        texture.filterMode = FilterMode.Point;
        Color[] colors = new Color[10000];
        for(int i = 0; i < 10000; i++)
        {
            colors[i] = Color.green;
        }
        texture.SetPixels(colors);

        Debug.Log(texture.GetPixel(1, 1));
    }
}

