using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public Rigidbody2D rbPlayer;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {

        rbPlayer.gameObject.GetComponent<AudioSource>().PlayOneShot(sound, 1f);
        Debug.Log(rbPlayer.gameObject.GetComponent<AudioSource>().clip);
    }

    // Update is called once per frame
    void Update()
    {
        if (!rbPlayer.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            Debug.Log("p");
            rbPlayer.gameObject.GetComponent<AudioSource>().Play();
        }
    }

}
