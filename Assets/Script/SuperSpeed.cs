using UnityEngine;
using System.Collections;

public class SuperSpeed : MonoBehaviour {
	//Scripts References

	private RandomSpawn m_Random;
	private Obstacle m_Obstaculos;

	//GameObjects
	private GameObject m_Player;
	public GameObject m_Check;
	public GameObject m_Puntuacion;

	//SpriteRenderer

	public SpriteRenderer m_SimboloSpeed;
	public SpriteRenderer m_coin;

	//Numeric Variables

	public float m_Speed;

	// Use this for initialization
	void Start () {
		//Buscamos los scripts referenciados
		m_Random = GameObject.FindGameObjectWithTag("Obstaculos").GetComponent<RandomSpawn>();
		m_Obstaculos = GameObject.FindGameObjectWithTag ("Colum").GetComponent<Obstacle> ();
		m_Player = GameObject.FindGameObjectWithTag ("Check");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Check") {
			//Desabilitamos Sprites
			m_SimboloSpeed.enabled = false;
			//Cambiamos de capa desde linea 43-47
			m_Player.gameObject.layer = 13;
			m_Check.gameObject.layer = 13;
            m_coin.gameObject.layer = 13;

		}
	}
}
