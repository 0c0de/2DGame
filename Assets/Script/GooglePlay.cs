using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlay : MonoBehaviour {

	//Google Play Services

	private string Achivement4 = "CgkIp_mU24gMEAIQBA";
	private string Achivement5 = "CgkIp_mU24gMEAIQBQ";
	private string Achivement6 = "CgkIp_mU24gMEAIQBg";
	private string Achivement7 = "CgkIp_mU24gMEAIQBw";


	void Awake(){
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			.Build();

		PlayGamesPlatform.InitializeInstance(config);

		Social.localUser.Authenticate ((bool success) => {
			Debug.Log("Loguado correctamente");	
		});
	}

	// Use this for initialization
	void Start () {
       
		if (PlayerPrefs.GetInt("highscore") >= 25){
			Social.ReportProgress(Achivement4, 100.0f, (bool success) => {
				//Desbloqueado
			});
		}

		if (PlayerPrefs.GetInt("highscore") >= 35)
		{
			Social.ReportProgress(Achivement5, 100.0f, (bool success) => {
				//Desbloqueado
			});
		}

		if (PlayerPrefs.GetInt("highscore") >= 50)
		{
			Social.ReportProgress(Achivement6, 100.0f, (bool success) => {
				//Desbloqueado
			});
		}

		if (PlayerPrefs.GetInt("highscore") >= 100)
		{
			Social.ReportProgress(Achivement7, 100.0f, (bool success) => {
				//Desbloqueado
			});
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
