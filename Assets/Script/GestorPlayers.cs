using UnityEngine;
using System.Collections;

public class GestorPlayers : MonoBehaviour {

	public GameObject Helicoptero;
	public GameObject NyanCat;
	public GameObject AvionetaPrincipal;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt("Helicoptero") == 0) {
			Helicoptero.SetActive(true);
			NyanCat.SetActive(false);
			AvionetaPrincipal.SetActive(false);
		}
		
		
		if (PlayerPrefs.GetInt("NyanCat") == 0) {
            NyanCat.SetActive(true);
			Helicoptero.SetActive(false);
			AvionetaPrincipal.SetActive(false);
		}
	}
}
