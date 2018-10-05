using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] levelMusicChange;

	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	private void OnLevelWasLoaded(int level)
	{
		AudioClip thisLevelMusic = levelMusicChange[level];
		if (thisLevelMusic)
		{
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void ChangeVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
