using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int lives = 3;


    public TMP_Text scoreText;
    public TMP_Text livesText;

 
    public TMP_Text gameOverText;

   
    public GameObject player;

    private const int maxLives = 5;

    void Start()
    {
        UpdateHUD();

        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddPoints(5);
            Debug.Log("Adicionou 5 pontos. Pontuação atual: " + score);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            RemoveLife();
            Debug.Log("Removeu 1 vida. Vidas atuais: " + lives);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal();
            Debug.Log("Curou 1 vida. Vidas atuais: " + lives);
        }
    }

    public void AddPoints(int quantidade)
    {
        score += quantidade;
        UpdateHUD();
    }

    public void RemoveLife()
    {
        lives--;

        if (lives < 1)
        {
            Debug.Log("Game Over!");
            lives = 0;

            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true);
                gameOverText.text = "Game Over!";
            }

          
            if (player != null)
            {
                PlayerMovement movement = player.GetComponent<PlayerMovement>();
                if (movement != null)
                    movement.enabled = false;  
            }
        }

        UpdateHUD();
    }

    public void Heal()
    {
        if (lives < maxLives)
        {
            lives++;
            UpdateHUD();
        }
    }

    public void UpdateHUD()
    {
        if (scoreText != null)
            scoreText.text = "x" + score.ToString();

        if (livesText != null)
            livesText.text = "x" + lives.ToString();
    }
}
