using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CinematiqueScript : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;

    private void Start()
    {
        video.loopPointReached += ChangeScene;
    }

    private void ChangeScene(VideoPlayer source)
    {
        SceneManager.LoadScene(2);
    }
    
}
