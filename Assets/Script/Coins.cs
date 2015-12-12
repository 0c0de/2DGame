using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Coins : MonoBehaviour {

	public Image coin;
	public GameObject textoMonedas;
	[HideInInspector]public int valor;
	private string rutaArchivo;
	public ParticleSystem ParticulasMoneda;
	// Use this for initialization
	void Start () {
		Cargar ();
        textoMonedas.GetComponent<TextMesh>().text = valor.ToString();
    }

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos001.dat";
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Check") {
			IncrementarMonedas ();
			coin.gameObject.SetActive(false);
			ParticulasMoneda.Play ();
		}
	}

	public void IncrementarMonedas(){
		valor = valor+1;
		textoMonedas.GetComponent<TextMesh> ().text = valor.ToString ();

	}

	public void Cargar(){
		if (File.Exists (rutaArchivo)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (rutaArchivo, FileMode.Open);
			DatosAguardar datos = (DatosAguardar)bf.Deserialize (file);

			valor = datos.valor;
			file.Close ();
		} else {
			valor = 0;
		}
	}

	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (rutaArchivo);
		DatosAguardar datos = new DatosAguardar ();

		datos.valor = valor;
		bf.Serialize (file, datos);
		file.Close ();
	}
}
[Serializable]
class DatosAguardar{
	public int valor;
}