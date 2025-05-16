using UnityEngine;
using UnityEngine.UI;

public class ScrollBarManager : MonoBehaviour
{
    public Scrollbar scrollBar;
    public float scrollValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrollValue = ((scrollBar.value - 0.5f) * 2) * 2f;
    }

    public float getScrollValue()
    {
        return scrollValue;
    }
}
