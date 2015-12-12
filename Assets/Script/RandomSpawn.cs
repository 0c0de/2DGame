using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour {

	public GameObject Columna1;
	public GameObject[] ColumnasEspeciales;
	public GameObject Nuves;
	public GameObject Nuve2;
	 //Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 1f,2f);
		InvokeRepeating ("CreateClouds", 5.5f, 5f);
	}

    void CreateObstacle()
    {
		if (Random.value <= 0.95f) {
			Instantiate (Columna1);
		} else {
			CreateSpecial();
		}
    }

	void CreateClouds(){
		Instantiate (Nuves);
		Instantiate (Nuve2);
	}

	void CreateSpecial(){
		Instantiate(ColumnasEspeciales[Random.Range(0, ColumnasEspeciales.Length)]);
	}
}