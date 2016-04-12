using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coinsx10 : MonoBehaviour {

	public Image MonedaImagen;
	private Coins coin;
    public GameObject m_Floating10XCoin;
	public ParticleSystem ParticulasMoneda;
	// Use this for initialization
	void Start () {
        coin = GameObject.FindGameObjectWithTag("Check").GetComponent<Coins>();
	}

	// Update is called once per frame
	void Update () {
    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Check") {
			IncrementarMonedas ();
			MonedaImagen.gameObject.SetActive(false);
			ParticulasMoneda.Play ();
            m_Floating10XCoin.SetActive(true);
		}
	}

	public void IncrementarMonedas(){
        coin.valor = coin.valor + 9;
	}	
}