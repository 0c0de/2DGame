using UnityEngine;
using System.Collections;

public class PointsScore : MonoBehaviour {

	public Transform text;
	[HideInInspector] public int score;
	[HideInInspector] public int HighScore;
	public TextMesh TextoHighScore;
    // Use this for initialization
    void Start () {
		StoredHighScore ();
    }
	
	// Update is called once per frame
	void Update () {

    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Check") {
			incrementarPuntuacion();
		}
	}

	public void incrementarPuntuacion()
	{
		score = score + 1;
		text.GetComponent<TextMesh>().text = score.ToString();

	}

	void StoredHighScore(){
		if (PlayerPrefs.HasKey ("highscore")) {
			HighScore = PlayerPrefs.GetInt("highscore");
			TextoHighScore.GetComponent<TextMesh>().text = HighScore.ToString();
		}
	}
}
