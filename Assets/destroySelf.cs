using UnityEngine;

public class destroySelf : MonoBehaviour
{
    public float timeAlive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeAlive);
    }
}
