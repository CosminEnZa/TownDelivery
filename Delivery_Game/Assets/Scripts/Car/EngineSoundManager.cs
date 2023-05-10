/*
 * This code is part of Arcade Car Physics for Unity by Saarg (2018)
 * 
 * This is distributed under the MIT Licence (see LICENSE.md for details)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VehicleBehaviour
{
    [RequireComponent(typeof(CarController))]
    [RequireComponent(typeof(AudioSource))]

    public class EngineSoundManager : MonoBehaviour
    {

        [Header("AudioClips")]
        public AudioClip starting;
        public AudioClip rolling;
       

        [Header("pitch parameter")]
        public float flatoutSpeed = 20.0f;
        [Range(0.0f, 3.0f)]
        public float minPitch = 0.7f;
        [Range(0.0f, 0.1f)]
        public float pitchSpeed = 0.05f;

        private AudioSource _source;
        //private CarController _vehicle;

        void Start()
        {
            _source = GetComponent<AudioSource>();
           // _vehicle = GetComponent<CarController>();
        }

        void Update()
        {
          

            if (!CarController.isBreaking && (_source.clip == null))
            {
               _source.clip = starting;
                _source.Play();

                _source.pitch = 1;

                FuelManager.EngineStart = true;
            }

            if (!CarController.isBreaking && !_source.isPlaying)
            {
                _source.clip = rolling;
                _source.Play();
            }

            if (_source.clip == rolling)
            {
                _source.pitch = Mathf.Lerp(_source.pitch, minPitch + Mathf.Abs(CarController.speed) / flatoutSpeed, pitchSpeed);
            }

            if(CarController.isBreaking)
            {
                _source.pitch = Mathf.Lerp(_source.pitch, minPitch + Mathf.Abs(CarController.speed) / flatoutSpeed, pitchSpeed);
            }

            if(CarSwitch.isOn == false)
            {
                _source.pitch = 0.74f;
            }
        }
    }
}
