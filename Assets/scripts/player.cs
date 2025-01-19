using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public float speed = 6.0f;
    private float hInput;
    private float vInput;

 
    private gameManager gameManager;
    public AudioSource get;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("game manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement(){
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hInput,vInput,0) * Time.deltaTime * speed);
        //if player leaves screen then they loop around
        if (transform.position.x > 10f || transform.position.x <= -10f){
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        } else if (transform.position.y > 6f || transform.position.y <= -6f){
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D getStar){
        if(getStar.tag == "Respawn"){
            //player gets star
            get.Play();
            gameManager.EarnScore(1);
            Destroy(getStar.gameObject);
        }
    }

    
}
