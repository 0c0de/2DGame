using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Obstacle : MonoBehaviour
{
	public Vector2 Oldvelocity = new Vector2(-5, 0);
	public float range = 5f;

    private GameObject m_Player;
    // Use this for initialization
    void Start()
	{
        m_Player = GameObject.FindGameObjectWithTag("Check");
            transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z);
    }

    void Update() {

        GetComponent<Rigidbody2D>().velocity = Oldvelocity;
        if (m_Player.gameObject.layer == 13)
        {
            Oldvelocity = new Vector2(-12, 0);
        }
        else {
            Oldvelocity = new Vector2(-5, 0);
        }
    }
}