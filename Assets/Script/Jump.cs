using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Jump : MonoBehaviour
{
    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    public Vector2 jumpForce = new Vector2(0, 300);
    private Rigidbody2D rigid;
	[HideInInspector]public GameObject avion;
	public CanvasRenderer GameOver;
	public Button Music;
	public Button Reset;
	public Transform InvencibleText;
	public Transform InvencibleTimeLeft;
	public CanvasRenderer Ventanilla;
	public GameObject Explosion;
	private GestorPlayers GestorAviones;
	private Coins coin;
	public Invencible invencible;
	private PointsScore puntos;
    private MuscaJuego camara;
	public float countdown = 11f;
	public Text M_TextInvencible;

    void Start() {
		camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MuscaJuego>();
		puntos = GameObject.FindGameObjectWithTag ("Puntos").GetComponent<PointsScore> ();
		coin = GameObject.FindGameObjectWithTag ("coin").GetComponent<Coins> ();
		GestorAviones = GameObject.Find ("GestorDeAviones").GetComponent<GestorPlayers> ();
		avion = this.gameObject;
        rigid = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
		if (avion.layer == 18) {
			countdown = countdown -= Time.deltaTime;
			M_TextInvencible.enabled = true;
			M_TextInvencible.text = "Invencible for: " + countdown.ToString ();
		} else {
			countdown = 20f;
			M_TextInvencible.enabled = false;
		}

		if(countdown <= 0f){
			avion.layer = 16;
			invencible.PointScore.gameObject.layer = 17;
			invencible.Check.gameObject.layer = 17;
			invencible.coin.gameObject.layer = 17;
			avion.GetComponent<Animator> ().SetBool ("ColumnaEscudo",false);
		}

        // Jump
        if (Input.GetKeyUp("space") || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(jumpForce);
        }

        // Die by being off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Reset.gameObject.SetActive(true);
			Ventanilla.gameObject.SetActive (true);
			Music.gameObject.SetActive(true);
		    GameOver.gameObject.SetActive(true);
			avion.GetComponent<SpriteRenderer> ().enabled = false;
			GestorAviones.Helicoptero.GetComponent<SpriteRenderer>().enabled = false;
			GestorAviones.NyanCat.GetComponent<SpriteRenderer>().enabled = false;
            camara.Taylor.Stop();
            coin.valor = GetComponent<Coins> ().valor;
			coin.Guardar ();
        }
    }

    // Die by collision
    public void OnCollisionEnter2D(Collision2D other)
    {
		Reset.gameObject.SetActive(true);
		Ventanilla.gameObject.SetActive (true);
		Music.gameObject.SetActive(true);
		GameOver.gameObject.SetActive(true);
		Instantiate(Explosion, avion.transform.position, avion.transform.rotation);
		Destroy (Explosion, 1f);
		GestorAviones.AvionetaPrincipal.GetComponent<SpriteRenderer> ().enabled = false;
		GestorAviones.Helicoptero.GetComponent<SpriteRenderer> ().enabled = false;
		GestorAviones.NyanCat.GetComponent<SpriteRenderer>().enabled = false;
        camara.Taylor.Stop();
        coin.valor = GetComponent<Coins> ().valor;
		coin.Guardar ();
    }

    public void Die()
    {
		coin.valor = this.GetComponent<Coins>().valor;
		coin.Guardar ();

		if (PlayerPrefs.HasKey ("highscore")) {
			if (PlayerPrefs.GetInt ("highscore") < GetComponent<PointsScore>().score) {
				PlayerPrefs.SetInt ("highscore", GetComponent<PointsScore>().score);
				PlayerPrefs.Save();
			}
		} else {
			PlayerPrefs.SetInt("highscore", GetComponent<PointsScore>().score);
		}

        Application.LoadLevel(0);

    }
}