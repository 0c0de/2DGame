using UnityEngine;
using System.Collections;

public class UIButtons : MonoBehaviour {

	private Jump player;
	private Coins coin;
	private Tienda tienda;

	public void Start(){

	}

	public void ResetGame(){
		player = GameObject.FindGameObjectWithTag("Check").GetComponent<Jump>();
		player.Die ();
	}

	public void Back(){
		coin = GameObject.FindGameObjectWithTag ("coin").GetComponent<Coins> ();
		Application.LoadLevel (0);
		coin.Guardar ();
	}

	public void Shop(){
		coin = GameObject.FindGameObjectWithTag ("coin").GetComponent<Coins> ();
		Application.LoadLevel (1);
		coin.Cargar ();
	}
}
