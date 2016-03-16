using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {


	
	}
	
	// Update is called once per frame
	void Update ()
    {

        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        movie.loop = true;

        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        

#if UNITY_STANDALONE

        // If the space bar is pressed
        if (Input.GetButtonDown ("Jump"))
        {

            if(movie.isPlaying)
            {
                movie.Pause();
                audio.Pause();
            }
            else
            {
                movie.Play();
                audio.Play(); 
            }

        }

        Debug.Log("Audio is playing: " + audio.isPlaying);

#endif

    }
}
