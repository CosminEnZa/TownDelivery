using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSounds : MonoBehaviour
{
    public AudioClip starting;

    private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
