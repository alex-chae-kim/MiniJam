using System.Collections;
using TMPro;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public CalibrationConstant calibrationConstant;
    public NoteDisplayManager NoteDisplayManager;
    public AudioManager audioManager;
    public InputManager inputManager;
    public Song song;
    public string songToPlay;
    public Note activeNote;
    public float currTime;
    public int noteIndex;
    public Animator EndScreenAnimator;
    public blackScreen blackScreen;
    public GameObject nextLevelButton;
    public GameObject restartButton;
    public GameObject winMessage;
    public GameObject loseMessage;
    public TMP_Text scoreText;
    public int scoreCutoff;
    public float bpm;
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;

    private Sound activeSound;
    private bool soundAssigned;
    private bool stopSong;
    private double dspStartTime;
    private float startTime;
    private float calibrationConst;

    private bool first1;
    private bool first2;
    private bool first3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        calibrationConstant = GameObject.Find("CalibrationConstant").GetComponent<CalibrationConstant>();
        calibrationConst = calibrationConstant.getCalibrationConst();
        first1 = true;
        first2 = true;
        first3 = true;
        startTime = Time.time;
        if (bpm >= 100 ) 
        {
            bpm = bpm / 2;
        }
        soundAssigned = false;
        noteIndex = 0;
        activeNote = song.notes[noteIndex];
        stopSong = false;
    }

    // Update is called once per frame
    void Update()
    {
        manageSongTime();
        if (Time.time > startTime + 1 && first1)
        {
            first1 = false;
            audioManager.Play("gavel", Time.time);
            line1.SetActive(true);
        }
        if (Time.time > startTime + 1+60/bpm && first2)
        {
            first2 = false;
            audioManager.Play("gavel", Time.time);
            line1.SetActive(false);
            line2.SetActive(true);
        }
        if (Time.time > startTime + 1+2*(60/bpm) && first3)
        {
            first3 = false;
            audioManager.Play("gavel", Time.time);
            line3.SetActive(true);
            line2.SetActive(false);
            StartCoroutine(startSong());
        }
    }

    void manageSongTime()
    {
        if (soundAssigned && !stopSong)
        {
            if (activeNote.stop) 
            {
                stopSong = true;
                StartCoroutine(displayEndScreen());
            }
            currTime = (float)(AudioSettings.dspTime - dspStartTime) + calibrationConst;
            //Debug.Log("Current time: " + currTime);
            //Debug.Log("Current note: " + noteIndex);
            if (currTime >= activeNote.beat + 0.2 && !stopSong) 
            {
                inputManager.noNotePressedCheck();
                noteIndex += 1;
                activeNote = song.notes[noteIndex];
                NoteDisplayManager.enableTrigger();
            }
        }
    }

    public void nextNote()
    {
        inputManager.noNotePressedCheck();
        noteIndex += 1;
        activeNote = song.notes[noteIndex];
        NoteDisplayManager.enableTrigger();
    }

    IEnumerator displayEndScreen()
    {
        scoreText.text = inputManager.score.ToString();
        if (inputManager.score >= scoreCutoff)
        {
            nextLevelButton.SetActive(true);
            winMessage.SetActive(true);
            restartButton.SetActive(false);
            loseMessage.SetActive(false);
        }
        else if (inputManager.score < scoreCutoff)
        {
            nextLevelButton.SetActive(false);
            winMessage.SetActive(false);
            restartButton.SetActive(true);
            loseMessage.SetActive(true);
        }
        yield return new WaitForSeconds(2.5f);
        EndScreenAnimator.SetTrigger("lower screen");
    }

    IEnumerator startSong()
    {
        yield return new WaitForSeconds(60/bpm);
        audioManager.Play("gavel", Time.time);
        blackScreen.gavelScreenExit();
        yield return new WaitForSeconds(1);
        dspStartTime = AudioSettings.dspTime;
        activeSound = audioManager.Play(songToPlay, dspStartTime);
        soundAssigned = true;
        yield return new WaitForSeconds(1);
        line3.SetActive(false);
    }
}
