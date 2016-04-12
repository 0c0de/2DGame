using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	public float velocity = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 offset = new Vector2 (Time.time * velocity, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;

	}
}
