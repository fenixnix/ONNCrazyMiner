using UnityEngine;
using UnityEngine.UI;

public class NColorPicker : MonoBehaviour {
    public Slider R;
    public Slider G;
    public Slider B;
    public Image image;
    public Color color;

    public void SetColor(Color c)
    {
        color = c;
        R.value = c.r;
        G.value = c.g;
        B.value = c.b;
        image.color = color;
    }

    public void UpdateColor()
    {
        color.r = R.value;
        color.g = G.value;
        color.b = B.value;
        image.color = color;
    }

	// Use this for initialization
	void Start () {
        SetColor(new Color(1, 1, 1, 1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
