using UnityEngine;
using UnityEngine.UI;

public class NFade : MonoBehaviour {
    public float fade = 1.0f;
    Image[] imgs;
    Text[] txts;
	// Use this for initialization
	void Start () {
        imgs = GetComponentsInChildren<Image>();
        txts = GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i< imgs.Length; i++)
        {
            imgs[i].color = new Color(imgs[i].color.r, imgs[i].color.g, imgs[i].color.b, fade);
        }
        for (int i = 0; i < txts.Length; i++)
        {
            txts[i].color = new Color(txts[i].color.r, txts[i].color.g, txts[i].color.b, fade);
        }
    }
}
