using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Android;
public class Jump : MonoBehaviour
{

    //Floats,Int,Doubles,etc
    public float m_InvencibilityCount = 7f;
	public float m_SpeedCount = 5f;
	[HideInInspector]public float m_DiesCount = 1f;
	private float m_RandomNumber;

    //Vectores
    public Vector2 jumpForce = new Vector2(0, 300);

    //GameObjects
    public GameObject Fire;
    private GameObject avion;
    public GameObject m_UltraSpeedFire;
	//Booleans
	private bool m_HelicopterDestroyed = false;

    //ReferenciasScripts
    private GestorPlayers GestorAviones;
	[HideInInspector]public Coins coin;
	public SuperSpeed m_SuperSpeed;
    public Invencible invencible;
	private Obstacle m_Random;
	private RandomSpawn m_Obstacle;

    //private PointsScore puntos;
    private MuscaJuego camara;

    //ReferenciasComponentes
    //private Animator m_anim;
    private Rigidbody2D rigid;

    //ADS
	public ADMob m_ADS;

    //UI
    public CanvasRenderer GameOver;
    public Button Music;
    public Button Reset;
    public CanvasRenderer Ventanilla;
    public Text M_TextInvencible;
	public Text m_TextSpeed;
    public Button m_Logros;
    public Button m_Marcadores;
	public Button m_Publicidad;

	//Google Logros
	private string Achivement2 = "CgkIp_mU24gMEAIQAg";

    void Start() {

        m_Obstacle = GameObject.FindGameObjectWithTag("Obstaculos").GetComponent<RandomSpawn>();
        camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MuscaJuego>();
		coin = GameObject.FindGameObjectWithTag ("coin").GetComponent<Coins> ();
        rigid = GetComponent<Rigidbody2D>();
        avion = gameObject;
        m_RandomNumber = Random.value;

		m_ADS.RequestInterstitial ();
		m_ADS.RequestRewardBasedVideo ();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.layer == 11) {
			m_InvencibilityCount -= Time.deltaTime;
			M_TextInvencible.enabled = true;
			M_TextInvencible.text = "Invencible for: " + m_InvencibilityCount.ToString ();
		} else {
			m_InvencibilityCount = 7f;
			M_TextInvencible.enabled = false;
		}

		if (gameObject.layer == 13) {
			m_SpeedCount -= Time.deltaTime;
			m_TextSpeed.enabled = true;
			m_TextSpeed.text = "Super Ultra Mega Hyper Speed: " + m_SpeedCount.ToString ();
            m_UltraSpeedFire.SetActive(true);
		} else {
			m_SpeedCount = 7f;
			m_TextSpeed.enabled = false;
		}

		if(m_InvencibilityCount <= 0f){
			avion.layer = 9;
			invencible.PointScore.gameObject.layer = 10;
			invencible.Check.gameObject.layer = 10;
			invencible.coin.gameObject.layer = 10;
		}

		if (m_SpeedCount <= 0f) {
			avion.layer = 9;
			m_SuperSpeed.m_coin.gameObject.layer = 10;
			m_SuperSpeed.m_Check.gameObject.layer = 10;
			m_SuperSpeed.m_Puntuacion.gameObject.layer = 10;
            m_UltraSpeedFire.SetActive(false);
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
            m_Marcadores.gameObject.SetActive(true);
            m_Logros.gameObject.SetActive(true);
			if (m_RandomNumber >= 0.6) {
                m_Publicidad.gameObject.SetActive(true);
            }
            gameObject.GetComponent<SpriteRenderer> ().enabled = false;
            camara.Taylor.Stop();
            coin.valor = GetComponent<Coins> ().valor;
			coin.Guardar ();

        }
    }

    // Die by collision
    public void OnCollisionEnter2D(Collision2D other)
    {
		m_HelicopterDestroyed = true;
		Reset.gameObject.SetActive(true);
		Ventanilla.gameObject.SetActive (true);
		Music.gameObject.SetActive(true);
		GameOver.gameObject.SetActive(true);
		m_Marcadores.gameObject.SetActive(true);
		m_Logros.gameObject.SetActive(true);
		if (m_RandomNumber >= 0.6) {
			m_Publicidad.gameObject.SetActive(true);
		}
        Fire.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 9;
        camara.Taylor.Stop();
        coin.valor = GetComponent<Coins> ().valor;
        coin.Guardar ();

    }

    public void Die()
    {
		coin.valor = this.GetComponent<Coins>().valor;
		coin.Guardar ();
		Social.ReportProgress(Achivement2, 100.0f, (bool success) => {
			//Desbloqueado
		});

		if (Random.value >= 0.8f && m_ADS.interstitial.IsLoaded()) {
			m_ADS.interstitial.Show ();
		}
    
        if (PlayerPrefs.HasKey ("highscore")) {
			if (PlayerPrefs.GetInt ("highscore") < GetComponent<PointsScore>().score) {
				PlayerPrefs.SetInt ("highscore", GetComponent<PointsScore>().score);
				PlayerPrefs.Save();
			}
		} else {
			PlayerPrefs.SetInt("highscore", GetComponent<PointsScore>().score);
		}
        SceneManager.LoadScene(0);

    }

    public void ShowADS() {

    }
}