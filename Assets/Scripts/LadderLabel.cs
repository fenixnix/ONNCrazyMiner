using UnityEngine;
using UnityEngine.UI;

public class LadderLabel : MonoBehaviour {
    public Text Round;
    public Text Addr;
    public Text Bonus;

    public void SetLabel(LadderUnit dat)
    {
        Round.text = "第" + dat.Round + "期";
        Addr.text = dat.Addr;
        Bonus.text = dat.Bonus.ToString() + "ETH";
    }
}
