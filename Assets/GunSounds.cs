using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSounds : MonoBehaviour
{
	AudioSource audioSource;

	void Start()
	{
		audioSource = transform.parent.parent.GetComponent<AudioSource>();
		reloadClip = Resources.Load<AudioClip>("Audio/reload");
		
	}
	AudioClip reloadClip;
	void PlayReload()
	{
		audioSource.PlayOneShot(reloadClip);
	}

}
