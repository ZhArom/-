using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerShoot : MonoBehaviour {
	public AudioClip[] audioClips = new AudioClip[3];
	AudioSource au;
	// Use this for initialization
	void Start()
	{
		au = GetComponent<AudioSource>();
	}
	public void PlayAudio(int index)
	{
		au.clip = audioClips[index];
		au.Play();
	}
	// Update is called once per frame
	void Update()
	{

	}
}
