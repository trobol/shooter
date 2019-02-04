using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSounds : MonoBehaviour
{
	AudioSource audioSource;
	GameObject shell;
	void Start()
	{
		audioSource = transform.parent.parent.GetComponent<AudioSource>();
		reloadClip = Resources.Load<AudioClip>("Audio/reload");
		shell = Resources.Load<GameObject>("shell");
	}
	AudioClip reloadClip;
	void PlayReload()
	{
		audioSource.PlayOneShot(reloadClip);
	}

}
