using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour {

	public Image TapIzq;
	public Image TapDer;
	public Image ManoClick;
	public CanvasRenderer table;
	public Image GetReady;
	public Image GameOver;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton0) && Application.isPlaying)
		{
			TapDer.enabled = false;
			TapIzq.enabled = false;
			ManoClick.enabled = false;
			GetReady.enabled = false;
			table.gameObject.SetActive(false);
			Time.timeScale = 1f;
			
		}

	}
}
