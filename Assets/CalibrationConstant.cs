using UnityEngine;

public class CalibrationConstant : MonoBehaviour
{
    private GameObject scrollBarManager;
    public float calibrationConst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        scrollBarManager = GameObject.Find("ScrollBarManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollBarManager != null) 
        {
            calibrationConst = scrollBarManager.GetComponent<ScrollBarManager>().getScrollValue();
        }
    }

    public float getCalibrationConst()
    {
        return calibrationConst;
    }
}
