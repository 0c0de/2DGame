using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coinsx10 : MonoBehaviour {

	public Image MonedaImagen;
	public Coins coin;
	public ParticleSystem ParticulasMoneda;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Check") {
			IncrementarMonedas ();
			MonedaImagen.gameObject.SetActive(false);
			ParticulasMoneda.Play ();
		}
	}

	public void IncrementarMonedas(){
		coin.valor += 10;
	}	
}