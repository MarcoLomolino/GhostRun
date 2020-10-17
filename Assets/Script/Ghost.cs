using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Ghost : MonoBehaviour
{

    private Vector2 targetPos;
	public float Yincrement;
    public float speed;
    public static int hp = 3;
    public GameObject effect;
    

    public GameObject gameOver;


    // Update is called once per frame
    private void Update()
    {
        if (hp<=0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.UpArrow) && (transform.position.y == 0 || transform.position.y == -3))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && (transform.position.y == 0 || transform.position.y == 3))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);

        }
        

    }
}
