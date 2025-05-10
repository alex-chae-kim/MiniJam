using UnityEngine;

public class SongManager : MonoBehaviour
{
    public NoteDisplayManager NoteDisplayManager;
    public AudioManager audioManager;
    public Song song;
    public Note activeNote;
    public float currTime;
    public int noteIndex;

    private Sound activeSound;
    private bool soundAssigned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundAssigned = false;
        noteIndex = 0;
        activeNote = song.notes[noteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            activeSound = audioManager.Play("cringe");
            soundAssigned = true;
        }
        manageSongTime();
    }

    void manageSongTime()
    {
        if (soundAssigned)
        {
            currTime = activeSound.source.timeSamples / activeSound.frequency;
            Debug.Log("Current time: " + currTime);
            Debug.Log("Current note: " + noteIndex);
            if (currTime >= activeNote.beat + 0.2) 
            {
                noteIndex += 1;
                activeNote = song.notes[noteIndex];
                NoteDisplayManager.enableTrigger();
            }
        }
    }

    public void nextNote()
    {
        noteIndex += 1;
        activeNote = song.notes[noteIndex];
        NoteDisplayManager.enableTrigger();
    }
}
