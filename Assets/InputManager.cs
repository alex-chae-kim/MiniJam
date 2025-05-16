using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public AudioManager AudioManager;
    public Animator birdHandAnimator;
    public SongManager songManager;
    public float offset;

    public float perfectInterval;
    public float closeInterval;
    public float badInterval;

    public Transform scoreSpawnPoint;

    public GameObject perfectIndicator;
    public GameObject closeIndicator;
    public GameObject badIndicator;
    public GameObject missIndicator;

    public int score;


    private int noteTracker;
    private bool notePressed;
    private bool key1Up;
    private bool key2Up;
    private bool key3Up;
    private bool key4Up;
    private bool left;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        left = true;
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
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        playPressKeyAnimation();
                        notePressed = true;
                        accuracy = Mathf.Abs(songManager.currTime - songManager.activeNote.beat);
                        if (accuracy <= perfectInterval) 
                        {
                            Debug.Log("Perfect note @ " + songManager.currTime + "!!");
                            score += 1000;
                            Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
                            Instantiate(perfectIndicator, scoreSpawnPoint.position, rotation);
                            songManager.nextNote();
                        }
                        else if (accuracy <= closeInterval)
                        {
                            Debug.Log("Close note @ " + songManager.currTime + "!!");
                            score += 750;
                            Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
                            Instantiate(closeIndicator, scoreSpawnPoint.position, rotation);
                            songManager.nextNote();
                        }
                        else if (accuracy < badInterval)
                        {
                            Debug.Log("Bad note @ " + songManager.currTime + "!!");
                            score += 500;
                            Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
                            Instantiate(badIndicator, scoreSpawnPoint.position, rotation);
                            songManager.nextNote();
                        }
                        else
                        {
                            Debug.Log("Missed note @ " + songManager.currTime + "!!");
                            Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
                            Instantiate(missIndicator, scoreSpawnPoint.position, rotation);
                            songManager.nextNote();
                        }
                    }
                /*
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
                    playPressKeyAnimation();
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
                    playPressKeyAnimation();
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
                    playPressKeyAnimation();
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
            } */
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
            Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
            Instantiate(missIndicator, scoreSpawnPoint.position, rotation);
        }
        notePressed = false;
    }

    public void playPressKeyAnimation()
    {
        if (left)
        {
            birdHandAnimator.SetTrigger("TypeLeft");
            AudioManager.Play("type", Time.time);
            left = false;
        }
        else
        {
            birdHandAnimator.SetTrigger("TypeRight");
            AudioManager.Play("type", Time.time);
            left = true;
        }
    }
}
