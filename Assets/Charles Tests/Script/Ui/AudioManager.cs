using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource[] audioSource;
	public AudioClip[] clips;
	public float volume;


	public void OnClickSound(int _clip)
	{
		if (audioSource[0].isPlaying)
		{
			audioSource[0].Stop();
		}
		audioSource[0].PlayOneShot(clips[_clip], volume);
	}

	//public void OnClickSound(int _clip)
	//{
	//	if (!audioSource.isPlaying)
	//	{
	//		audioSource.PlayOneShot(clips[_clip], volume);
	//	}
	//	else
	//	{
	//		audioSource.Stop();
	//	}
	//}
}
