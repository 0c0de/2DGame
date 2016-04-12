using UnityEngine;
using System.Collections;

public class MuscaJuego : MonoBehaviour {
	public AudioSource Taylor;
	// Use this for initialization
	void Start () {
		Musica ();
	}
	public void Musica(){
        Taylor.Play();
	}
}
