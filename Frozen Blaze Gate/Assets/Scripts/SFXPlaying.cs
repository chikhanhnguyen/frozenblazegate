using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
	public AudioSource Launch;
	public AudioSource Ambiance;
	public AudioSource DoorOpen;
	public AudioSource DoorClose;

	float fadeTime = 0.195f;

	public void PlayDoorOpen() {
		DoorOpen.Play();
	}

	public void PlayDoorClose() {
		DoorClose.Play();
	}

	public void PlayLaunch() {
		Launch.Play();
	}

	IEnumerator _FadeSound() {
	float t = fadeTime;
	while (t > 0) {
		yield return null;
		 t-= (Time.deltaTime/30);
		 Ambiance.volume = t;
	 }
	 yield break;
	 }

	public void FadeSound() { 
	 if(fadeTime == 0) { 
		 Ambiance.volume = 0;
		 return;
	 }
	 StartCoroutine(_FadeSound()); 
 	}
}
