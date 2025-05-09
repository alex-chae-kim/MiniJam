using UnityEngine;

public class SongManager : MonoBehaviour
{
    public AudioManager audioManager;
    public Song song;
    public Note activeNote;

    private Sound activeSound;
    private bool soundAssigned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundAssigned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            activeSound = audioManager.Play("cringe");
            soundAssigned = true;
        }
        if (soundAssigned)
        {
            Debug.Log("Current time: " + activeSound.source.timeSamples / activeSound.frequency);
            activeNote = song.notes[0];
        }
    }
}
