using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private GameObject gameOverText;
    public bool isGameOver = false;


    //getter for Singleton
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake() // Awake is called even before Start
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        isGameOver= true;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
