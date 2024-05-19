using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class cut : MonoBehaviour
{
    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VideoPlayer>().loopPointReached += videofinished;

    }

    // Update is called once per frame
    void videofinished(VideoPlayer VP)
    { 
        gameObject.SetActive (false); 
    }
}
