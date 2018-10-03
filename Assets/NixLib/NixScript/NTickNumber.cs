using UnityEngine;
using UnityEngine.UI;

public class NTickNumber : MonoBehaviour {
    public Text text;
    float prevValue = 0;
    float value = 0;
   
    public void SetValue(float val)
    {
        prevValue = value;
        value = val;
    }

	void Start () {
		text = GetComponent<Text>();
	}

    float v = 0;
	void Update () {
        //v += 0.01f;
        //text.text = Mathf.SmoothDamp(prevValue, value, ref v,Time.deltaTime).ToString("f6");
        text.text = value.ToString("f2");
    }
}
