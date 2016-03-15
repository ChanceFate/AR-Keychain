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

        bool paused = true;

#if UNITY_STANDALONE

        // If the space bar is pressed
        if (Input.GetButtonDown ("Jump"))
        {

            if(movie.isPlaying)
            {
                movie.Pause();
                paused = true;
            }
            else
            {
                movie.Play();
                paused = false;
            }

        }

#endif

    }
}
