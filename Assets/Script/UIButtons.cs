using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

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
        SceneManager.LoadScene(0);
		coin.Guardar ();
	}

	public void Shop(){
		coin = GameObject.FindGameObjectWithTag ("coin").GetComponent<Coins> ();
		SceneManager.LoadScene (1);
		coin.Cargar ();
	}

    public void Logros() {
		Social.ShowAchievementsUI ();
    }

    public void LeaderBoards() {
		PlayGamesPlatform.Instance.ShowLeaderboardUI ("CgkIp_mU24gMEAIQCA");
    }

}
