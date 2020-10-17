using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public float speed;
	public GameObject effect;
	public int goal;
	public float maxSpeed;

	private Shake shake;

    void Start()
    {
		shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Update()
	{
		transform.Translate(Vector2.left * speed * Time.deltaTime);
		if(ScoreManager.score > goal && speed<maxSpeed)
        {
			speed += 2;
			goal += 30;
        }
        
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Instantiate(effect, transform.position, Quaternion.identity);
			shake.camShake();
			Ghost.hp -= 1;
			Destroy(gameObject);
		}
	}
}
