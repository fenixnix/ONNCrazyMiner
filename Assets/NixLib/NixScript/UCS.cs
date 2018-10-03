using UnityEngine;

public class UCS : MonoBehaviour
{
    static public void ClearChild(Transform root)
    {
        for (int i = 0; i < root.childCount; i++)
        {
            Destroy(root.GetChild(i).gameObject);
        }
    }
}