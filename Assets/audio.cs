
using UnityEngine;

//Make sure there is an Audio Source component on the GameObject
[RequireComponent(typeof(AudioSource))]

public class ExampleScript : MonoBehaviour
{
    public int startingPitch = 4;
    public int timeToDecrease = 5;
    AudioSource audioSource;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        audioSource.pitch = startingPitch;
    }

    void Update()
    {
        //While the pitch is over 0, decrease it as time passes.
        if (audioSource.pitch > 0)
        {
            audioSource.pitch -= Time.deltaTime * startingPitch / timeToDecrease;
        }
    }
}