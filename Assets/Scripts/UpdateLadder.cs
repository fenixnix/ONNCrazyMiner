using UnityEngine;

public class UpdateLadder : MonoBehaviour {
    public GameObject labelParent;
    public GameObject labelPrefab;

    public void UpdateList(CMLadderInfo cm)
    {
        UCS.ClearChild(labelParent.transform);
        for(int i = 0; i < cm.members.Length; i++)
        {
            var obj = Instantiate(labelPrefab, labelParent.transform);
            var lab = obj.GetComponent<LadderLabel>();
            lab.SetLabel(cm.members[cm.members.Length-i-1]);
        }
    }
}
