using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class Tienda : MonoBehaviour {
	public Transform textoMonedas;
	public Button myboton;
	public Transform textoHelicoptero;
	[HideInInspector] public bool CompradoHeli = false;
	private Coins coin;
	[HideInInspector] public int valorHelicoptero = 1500;
	[HideInInspector] public int valorNyan = 2000;
	[HideInInspector] public bool compradoNyan = false;
	public Button Nyan;
	public Transform textoNyan;
	void Start () {
        PlayerPrefs.SetInt("Helicoptero", 1);
        PlayerPrefs.SetInt("NyanCat", 1);
		coin = GameObject.FindGameObjectWithTag ("coin").GetComponent<Coins> ();

        if (coin.valor >= 1000) {
            textoHelicoptero.GetComponent<TextMesh>().text = "Comprado";
            textoHelicoptero.GetComponent<TextMesh>().fontSize = 30;
        }

        if (coin.valor >= 1500) {
            textoNyan.GetComponent<TextMesh>().text = "Comprado";
            textoNyan.GetComponent<TextMesh>().fontSize = 30;
        }
	}
	// Update is called once per frame
	void Update () {
		textoMonedas.GetComponent<TextMesh>().text = coin.valor.ToString();
	}

	public void Helicoptero(){

        if (coin.valor >= 1000)
        {
            PlayerPrefs.SetInt("Helicoptero", 0);
        }
        else {
            PlayerPrefs.SetInt("Helicoptero",1);
        }
	}
		
	public void NyanCat(){
        if (coin.valor >= 1500)
        {
            PlayerPrefs.SetInt("NyanCat", 0);
        }
        else {
            PlayerPrefs.SetInt("NyanCat", 1);
        }
  }
}