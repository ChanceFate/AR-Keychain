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
        AudioSource audio = GetComponent<AudioSource>();

#if UNITY_STANDALONE

        // If the space bar is pressed
        if (Input.GetButtonDown ("Jump") && r.material.mainTexture.name == "123-Hic-4")
        {
            MovieTexture movie = (MovieTexture)r.material.mainTexture;
            movie.loop = true;

            audio.clip = movie.audioClip;

            if (movie.isPlaying)
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

#elif UNITY_ANDROID

        if (Input.touchCount == 2 && 
            Input.GetTouch(0).phase == TouchPhase.Began && 
            r.material.mainTexture.name == "123-Hic-4")
        {

            Handheld.PlayFullScreenMovie("123-Hic-4.mp4");
        }

#endif

        }
}
