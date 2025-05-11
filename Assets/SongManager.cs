using UnityEngine;

public class SongManager : MonoBehaviour
{
    public NoteDisplayManager NoteDisplayManager;
    public AudioManager audioManager;
    public InputManager inputManager;
    public Song song;
    public string songToPlay;
    public Note activeNote;
    public float currTime;
    public int noteIndex;

    private Sound activeSound;
    private bool soundAssigned;
    private bool stopSong;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundAssigned = false;
        noteIndex = 0;
        activeNote = song.notes[noteIndex];
        stopSong = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            activeSound = audioManager.Play(songToPlay);
            soundAssigned = true;
        }
        manageSongTime();
    }

    void manageSongTime()
    {
        if (soundAssigned && !stopSong)
        {
            if (activeNote.stop) 
            {
                stopSong = true;
            }
            currTime = activeSound.source.timeSamples / activeSound.frequency;
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
}
