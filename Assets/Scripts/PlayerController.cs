using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f;
    private int score = 0;
    public int health = 5;

    public Text scoreText;
    public Text healthText;
    public Text winLoseText;

    public Image winLoseBG;
    public GameObject winLose;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playermove();
        CheckHealth();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void playermove()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    private void CheckHealth()
    {
        if (health == 0)
        {
            //Debug.Log("Game Over!");
            SetGameOver();
            StartCoroutine(LoadScene(3));
            //SceneManager.LoadScene("maze");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            SetScoreText();
            //Debug.Log($"Score: {score}");
        }

        if (other.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
            //Debug.Log($"Health: {health}");
        }

        if (other.tag == "Goal")
        {
            SetWin();
            StartCoroutine(LoadScene(3));
            //Debug.Log("You win!");
        }
    }

    void SetScoreText()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void SetWin()
    {
        winLose.SetActive(true);
        winLoseBG.color = Color.green;
        winLoseText.text = "You win!";
        winLoseText.color = Color.black;
    }

    void SetGameOver()
    {
        winLose.SetActive(true);
        winLoseBG.color = Color.red;
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        health = 5;
        score = 0;
        SceneManager.LoadScene("maze");
    }
}
