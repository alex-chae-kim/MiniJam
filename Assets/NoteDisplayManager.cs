using UnityEngine;
using System.Collections;


public class NoteDisplayManager : MonoBehaviour
{
    public VisualNotePair[] BirdSounds;
    public float offset;
    public SongManager songManager;
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
                        defendantAnimator.SetTrigger(defendantSpeakTrigger);
                        foreach (var sound in BirdSounds)
                        {
                            if (sound.name == songManager.activeNote.type)
                            {
                                float randomZ = Random.Range(-10f, 10f); //
                                Quaternion rotation = Quaternion.Euler(0f, 0f, randomZ);
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
