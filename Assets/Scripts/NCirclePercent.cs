using UnityEngine;
using UnityEngine.UI;

public class NCirclePercent : MonoBehaviour {

    public Text textVal;
    public Image imgPie;

    public void SetValue(float val)
    {
        int v = Mathf.RoundToInt(val * 100f);
        textVal.text = v.ToString() + "%";
        imgPie.fillAmount = val;
    }

	// Use this for initialization
	void Start () {
        textVal = GetComponentInChildren<Text>();
	}
}
