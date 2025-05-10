using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public SongManager songManager;
    public float offset;

    public float perfectInterval;
    public float closeInterval;
    public float badInterval;

    public GameObject perfectIndicator;
    public GameObject closeIndicator;
    public GameObject badIndicator;
    public GameObject missIndicator;


    private int noteTracker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        noteTracker = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool canTrigger = noteTracker == songManager.noteIndex;
        if (songManager.currTime >= songManager.activeNote.beat - offset)
        {
           if (songManager.activeNote.interactable)
            {
                float accuracy = 0;
                if (songManager.activeNote.type.Length == 1)
                {
                    if (Input.GetKeyDown(songManager.activeNote.type))
                    {
                        accuracy = Mathf.Abs(songManager.currTime - songManager.activeNote.beat);
                        if (accuracy <= perfectInterval) 
                        {
                            StartCoroutine(turnOnOff(perfectIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy <= closeInterval)
                        {
                            StartCoroutine(turnOnOff(closeIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy < badInterval)
                        {
                            StartCoroutine(turnOnOff(badIndicator));
                            songManager.nextNote();
                        }
                        else
                        {
                            StartCoroutine(turnOnOff(missIndicator));
                            songManager.nextNote();
                        }
                    }
                    if (songManager.currTime >= songManager.activeNote.beat + 0.2)
                    {
                        StartCoroutine(turnOnOff(missIndicator));
                    }
                }
                else if (songManager.activeNote.type.Length == 2)
                {

                }
                else if (songManager.activeNote.type.Length == 3)
                {

                }
                else if (songManager.activeNote.type.Length == 4)
                {

                }
            }
        }
    }

    IEnumerator turnOnOff(GameObject accuracyIndicator)
    {
        accuracyIndicator.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        accuracyIndicator.SetActive(false);
    }
}
