using UnityEngine;
using System.Collections;


public class CalibrationDisplayManager : MonoBehaviour
{
    public VisualNotePair[] BirdSounds;
    public float offset;
    public CalibrationManager calibrationManager;
    public Transform speakPoint;
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
        if (calibrationManager.currTime >= calibrationManager.activeNote.beat - offset && calibrationManager.currTime != 0)
        {
            if (canTrigger)
            {
                Debug.Log("second check passed");
                canTrigger = false;
                if (!calibrationManager.activeNote.interactable && !calibrationManager.activeNote.stop)
                {
                    Debug.Log("third check passed");
                    if (calibrationManager.activeNote.owl)
                    {
                        //do stuff to display owl note
                        StartCoroutine(turnOnOff(testWord1));
                    }
                    else if (!calibrationManager.activeNote.owl)
                    {
                        //do stuff to display defendant note                     
                        foreach (var sound in BirdSounds)
                        {
                            if (sound.name == calibrationManager.activeNote.type)
                            {
                                Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
                                Instantiate(sound.noteObject, speakPoint.position, rotation);
                            }
                        }
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
