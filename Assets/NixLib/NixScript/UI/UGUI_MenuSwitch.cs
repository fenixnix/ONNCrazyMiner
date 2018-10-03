using UnityEngine;

public class UGUI_MenuSwitch : MonoBehaviour {
    public RectTransform menuRect;
    Vector2 oriPosition;
    bool isShow = false;
    
    public void Show()
    {
        //gameObject.SetActive(true);
        transform.SetAsLastSibling();
        menuRect.anchoredPosition = new Vector2(0, 0);
        menuRect.rect.Set(0, 0, 0, 0);
        isShow = true;
    }

    public void Hide()
    {
        menuRect.anchoredPosition = oriPosition;
        isShow = false;
        //gameObject.SetActive(false);
    }

    public void Toggle()
    {
        if (isShow)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    void Start()
    {
        oriPosition = menuRect.anchoredPosition;
    }
}
