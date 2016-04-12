using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Invencible : MonoBehaviour {

	private GameObject Player;
    public GameObject PointScore;
	public GameObject Check;
	public SpriteRenderer SimboloEscudo;
	public SpriteRenderer coin;
	private Animator m_anim;
	// Use this for initialization
	void Start () {
 
        Player = GameObject.FindGameObjectWithTag("Check");
    }
	
	// Update is called once per frame
	void Update(){

	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Check") {
            SimboloEscudo.enabled = false;
			Player.GetComponent<Animator>().SetBool("ColumnaEscudo",true);
			Player.GetComponent<Animator>().SetBool("InvencibleHelicopter",true);
			Player.GetComponent<Animator>().SetBool("NyanInvencible",true);
            Player.layer = 11;
            PointScore.layer = 11;
            Check.layer = 11;
            coin.gameObject.layer = 11;
        }
	}
}
