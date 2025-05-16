using UnityEngine;

public class blackScreen : MonoBehaviour
{
    public Animator screenAnimator;
    public GameObject blackbox;
    public bool blackScreenExitOnStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackbox.SetActive(true);
        if (blackScreenExitOnStart)
        {
            screenAnimator.SetTrigger("screen exit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void screenEnter() 
    {
        screenAnimator.SetTrigger("screen enter");
    }
    public void gavelScreenEnter()
    {
        screenAnimator.SetTrigger("gavel screen enter");
    }

    public void gavelScreenExit()
    {
        screenAnimator.SetTrigger("gavel screen exit");
    }
}
