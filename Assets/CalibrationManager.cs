using System.Collections;
using TMPro;
using UnityEngine;

public class CalibrationManager : MonoBehaviour
{
    public CalibrationConstant calibrationConstant;
    public CalibrationDisplayManager calibrationDisplayManager;
    public AudioManager audioManager;
    public Song song;
    public string songToPlay;
    public Note activeNote;
    public float currTime;
    public int noteIndex;

    private Sound activeSound;
    private bool soundAssigned;
    private bool stopSong;
    private double dspStartTime;
    private float startTime;
    private float calibrationConst;

    private bool canPlayAgain;
    private float elapsedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        calibrationConstant = GameObject.Find("CalibrationConstant").GetComponent<CalibrationConstant>();
        calibrationConst = calibrationConstant.getCalibrationConst();
        canPlayAgain = true;
        startTime = Time.time;
        soundAssigned = false;
        noteIndex = 0;
        activeNote = song.notes[noteIndex];
        stopSong = false;
    }

    // Update is called once per frame
    void Update()
    {
        calibrationConst = calibrationConstant.getCalibrationConst();
        manageSongTime();
        if (Time.time > startTime)
        {
            startTime = Time.time + 5;
            startSequence();
        }
    }

    void manageSongTime()
    {
        if (soundAssigned && !stopSong)
        {
            currTime = (float)(AudioSettings.dspTime - dspStartTime) + calibrationConst;
            if (activeNote.stop)
            {
                stopSong = true;
                currTime = 0;
            }
            Debug.Log(currTime);
            //Debug.Log("Current time: " + currTime);
            //Debug.Log("Current note: " + noteIndex);
            if (currTime >= activeNote.beat + 0.2 && !stopSong)
            {
                noteIndex += 1;
                activeNote = song.notes[noteIndex];
                calibrationDisplayManager.enableTrigger();
            }
        }
    }

    public void startSequence()
    {
        noteIndex = 0;
        activeNote = song.notes[noteIndex];
        stopSong = false;
        dspStartTime = AudioSettings.dspTime;
        calibrationDisplayManager.enableTrigger();
        activeSound = audioManager.Play(songToPlay, dspStartTime);
        soundAssigned = true;
    }  
    
}
