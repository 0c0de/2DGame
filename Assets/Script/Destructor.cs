using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	private float Tiempo = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Destroy (this.gameObject, Tiempo);
	
	}
}
