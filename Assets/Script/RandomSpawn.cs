using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour {
    private GameObject m_Player;
	public GameObject ColumnasNormales;
	public GameObject[] ColumnasEspeciales;
	public GameObject Nuves;
	public GameObject Nuve2;
	[HideInInspector] public float m_SpeedForObstacle = 2f;
	[HideInInspector] public float m_SpeedForCloud = 5.5f;
    //Use this for initialization

	void Start()
	{
        m_Player = GameObject.FindGameObjectWithTag("Check");
		InvokeRepeating("CreateObstacle", m_SpeedForObstacle,2.5f);
		InvokeRepeating ("CreateClouds", m_SpeedForCloud, 5f);
	}

    void CreateObstacle()
    {
		if (Random.value <= 0.95f) {
            Instantiate (ColumnasNormales);
            
		} else {
			CreateSpecial();
		}
    }

    public void Update() {
        if (m_Player.gameObject.layer == 13)
        {
            m_SpeedForObstacle = 1f;
        }
    }

	void CreateClouds(){
        Instantiate(Nuves);
        Instantiate(Nuve2);

        if (m_Player.gameObject.layer == 13)
        {
            m_SpeedForCloud = 1f;
        }
    }

	void CreateSpecial(){
		Instantiate(ColumnasEspeciales[Random.Range(0, ColumnasEspeciales.Length)]);
	}
}