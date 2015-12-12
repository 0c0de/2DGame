using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Obstacle : MonoBehaviour
{
	public Vector2 Oldvelocity = new Vector2(-5, 0);
	public float range = 5f;
	// Use this for initialization
	void Start()
	{
			GetComponent<Rigidbody2D> ().velocity = Oldvelocity;
			transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z);
	}
}