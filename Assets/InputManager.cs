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
    private bool notePressed;
    private bool key1Up;
    private bool key2Up;
    private bool key3Up;
    private bool key4Up;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        noteTracker = 0;
        notePressed = false;
        key1Up = true;
        key2Up = true;
        key3Up = true;
        key4Up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (songManager.currTime >= songManager.activeNote.beat - offset)
        {
           if (songManager.activeNote.interactable)
            {
                float accuracy = 0;
                if (songManager.activeNote.type.Length == 1)
                {
                    if (Input.GetKeyDown(songManager.activeNote.type))
                    {
                        notePressed = true;
                        accuracy = Mathf.Abs(songManager.currTime - songManager.activeNote.beat);
                        if (accuracy <= perfectInterval) 
                        {
                            Debug.Log("Perfect note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(perfectIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy <= closeInterval)
                        {
                            Debug.Log("Close note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(closeIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy < badInterval)
                        {
                            Debug.Log("Bad note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(badIndicator));
                            songManager.nextNote();
                        }
                        else
                        {
                            Debug.Log("Missed note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(missIndicator));
                            songManager.nextNote();
                        }
                    }
                }
                else if (songManager.activeNote.type.Length == 2)
                {
                    if (Input.GetKeyDown((songManager.activeNote.type[0]).ToString()))
                    {
                        key1Up = false;
                    }
                    if (Input.GetKeyDown((songManager.activeNote.type[1]).ToString()))
                    {
                        key2Up = false;
                    }
                    if (!key1Up && !key2Up)
                    {
                        key1Up = true;
                        key2Up = true;
                        notePressed = true;
                        accuracy = Mathf.Abs(songManager.currTime - songManager.activeNote.beat);
                        if (accuracy <= perfectInterval)
                        {
                            Debug.Log("Perfect note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(perfectIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy <= closeInterval)
                        {
                            Debug.Log("Close note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(closeIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy < badInterval)
                        {
                            Debug.Log("Bad note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(badIndicator));
                            songManager.nextNote();
                        }
                        else
                        {
                            Debug.Log("Missed note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(missIndicator));
                            songManager.nextNote();
                        }
                    }
                }
                else if (songManager.activeNote.type.Length == 3)
                {
                    if (Input.GetKeyDown((songManager.activeNote.type[0]).ToString()))
                    {
                        key1Up = false;
                    }
                    if (Input.GetKeyDown((songManager.activeNote.type[1]).ToString()))
                    {
                        key2Up = false;
                    }
                    if (Input.GetKeyDown((songManager.activeNote.type[2]).ToString()))
                    {
                        key3Up = false;
                    }
                    if (!key1Up && !key2Up && !key3Up)
                    {
                        key1Up = true;
                        key2Up = true;
                        key3Up = true;
                        notePressed = true;
                        accuracy = Mathf.Abs(songManager.currTime - songManager.activeNote.beat);
                        if (accuracy <= perfectInterval)
                        {
                            Debug.Log("Perfect note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(perfectIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy <= closeInterval)
                        {
                            Debug.Log("Close note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(closeIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy < badInterval)
                        {
                            Debug.Log("Bad note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(badIndicator));
                            songManager.nextNote();
                        }
                        else
                        {
                            Debug.Log("Missed note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(missIndicator));
                            songManager.nextNote();
                        }
                    }
                }
                else if (songManager.activeNote.type.Length == 4)
                {
                    if (Input.GetKeyDown((songManager.activeNote.type[0]).ToString()))
                    {
                        key1Up = false;
                    }
                    if (Input.GetKeyDown((songManager.activeNote.type[1]).ToString()))
                    {
                        key2Up = false;
                    }
                    if (Input.GetKeyDown((songManager.activeNote.type[2]).ToString()))
                    {
                        key3Up = false;
                    }
                    if (Input.GetKeyDown((songManager.activeNote.type[3]).ToString()))
                    {
                        key4Up = false;
                    }
                    if (!key1Up && !key2Up && !key3Up && !key4Up)
                    {
                        key1Up = true;
                        key2Up = true;
                        key3Up = true;
                        key4Up = true;
                        notePressed = true;
                        accuracy = Mathf.Abs(songManager.currTime - songManager.activeNote.beat);
                        if (accuracy <= perfectInterval)
                        {
                            Debug.Log("Perfect note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(perfectIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy <= closeInterval)
                        {
                            Debug.Log("Close note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(closeIndicator));
                            songManager.nextNote();
                        }
                        else if (accuracy < badInterval)
                        {
                            Debug.Log("Bad note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(badIndicator));
                            songManager.nextNote();
                        }
                        else
                        {
                            Debug.Log("Missed note @ " + songManager.currTime + "!!");
                            StartCoroutine(turnOnOff(missIndicator));
                            songManager.nextNote();
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
    public void noNotePressedCheck()
    {
        if (!notePressed && songManager.activeNote.interactable)
        {
            StartCoroutine(turnOnOff(missIndicator));
        }
        notePressed = false;
    }
}
