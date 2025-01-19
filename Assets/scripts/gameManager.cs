using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    public GameObject Star;
    public GameObject menu;
    public GameObject title;
    public GameObject win_img;
    public GameObject lose_img;
    public GameObject canvas;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public int score = 0;
    public float timer = 12f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateStar", 2.5f, 1.5f);
        scoreText.text = "" +score;
        Invoke("SetFalse", 2f);//closes menu after 2 seconds
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.ToString("#");
        timer = (timer - Time.deltaTime);
        if(timer < 1){
            timerText.text = "0";
        }
        if(timer <= 0){
            if(score >= 5){
                //player wins
                win_img.SetActive(true);
                menu.SetActive(true);
                StartCoroutine(PleaseStop(true));
            }else{
                //player loses
                lose_img.SetActive(true);
                menu.SetActive(true);
                StartCoroutine(PleaseStop(false));
            }
            
        }
    }

    //randomly spawns star from top of screen
    void CreateStar(){
        Instantiate(Star, new Vector3(Random.Range(-9f, 9f), 7f, 0), Quaternion.identity);
    }

    //increments score
    public void EarnScore(int NewScore){
        score += NewScore;
        scoreText.text = "" +score;
    }

    //closes menu and starts timer
    void SetFalse(){
        title.SetActive(false);
        menu.SetActive(false);
        canvas.SetActive(true);
    }

    //ends game after 2 seconds
    IEnumerator PleaseStop(bool win){
        yield return new WaitForSeconds(2f);
        if(win == true){
            Application.Quit();
        } else{
            SceneManager.LoadScene(0);
        }
    }
}
