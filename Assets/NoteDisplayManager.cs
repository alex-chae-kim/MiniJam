using UnityEngine;
using System.Collections;

public class NoteDisplayManager : MonoBehaviour
{
    public float offset;
    public SongManager songManager;
    public Transform scorePoint;
    public Animator owlAnimator;
    public Animator defendantAnimator;
    public string defendantSpeakTrigger;
    public Animator playerAnimator;
    public bool canTrigger;

    //test things
    public GameObject testWord1;
    public GameObject testWord2;

    private int noteTracker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (songManager.currTime >= songManager.activeNote.beat - offset && songManager.currTime != 0) 
        {
            if (canTrigger)
            {
                canTrigger = false;
                if (!songManager.activeNote.interactable && !songManager.activeNote.stop)
                {
                    if (songManager.activeNote.owl)
                    {
                        //do stuff to display owl note
                        StartCoroutine(turnOnOff(testWord1));
                    }
                    else if (!songManager.activeNote.owl)
                    {
                        //do stuff to display defendant note
                        StartCoroutine(turnOnOff(testWord2));
                        defendantAnimator.SetTrigger(defendantSpeakTrigger);
                    }
                }
            }
            
        }
    }

    IEnumerator turnOnOff(GameObject accuracyIndicator)
    {
        accuracyIndicator.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        accuracyIndicator.SetActive(false);
    }

    public void enableTrigger()
    {
        canTrigger = true;
    }
}
