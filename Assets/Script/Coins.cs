using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Coins : MonoBehaviour {

	public Image coin;
    public GameObject m_FloatingText;
	public GameObject textoMonedas;
	[HideInInspector]public int valor;
	private string rutaArchivo;
	public ParticleSystem ParticulasMoneda;

	//Google Logros
	private string Achivement1 = "CgkIp_mU24gMEAIQAQ";
	private string Achivement3 = "CgkIp_mU24gMEAIQAw";
	// Use this for initialization
	void Start () {
		Cargar ();
        textoMonedas.GetComponent<TextMesh>().text = valor.ToString();

		if (valor >= 1) {

			Social.ReportProgress (Achivement1, 100.0f, (bool success) => {
				Debug.Log ("1º Logro desbloqueado");
			});
		} else {
			Debug.Log("Logro no desbloqueado");
		}

		if (valor >= 1000) {
			Social.ReportProgress(Achivement3, 100.0f, (bool success) => {
				//Desbloqueado
			});
		}
    }

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos001.dat";
        
    }

	void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Check")
        {
            IncrementarMonedas();
            ParticulasMoneda.Play();
            coin.gameObject.SetActive(false);
            m_FloatingText.SetActive(true);
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