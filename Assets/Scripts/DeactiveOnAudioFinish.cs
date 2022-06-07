using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveOnAudioFinish : MonoBehaviour
{
    AudioSource _audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_audioSrc.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
