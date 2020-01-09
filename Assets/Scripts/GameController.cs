using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues; // esto es donde tienen que aparecer los asteroides
    [Header("Cantidad de asteroides")]
    public int hazarount; // estos son la cantidad de asteroides
    [Header("Espera entre asteroides")]
    public float spanwait; // espera de los asteroides entre los asteroides
    [Header("Arranque de ola de asteroides")]
    public float esperainicialasteroide; // espera cuando arrana el primer asteroide
    [Header("Espera a la siguiente ola de asteroides")]
    public float wavewait; // espera a la siguiente ola de asteroides

    private int score;
    public Text scoretext;

    public GameObject gameOverGameObject;
    private bool gameOver;

    public GameObject RestartGameObject;
    private bool restart;

    void Start () {
        UpdateSpawnValues();
        restart = false;
        RestartGameObject.SetActive(false);  // esto activa o desactiva un componente ****
        gameOver = false;
        gameOverGameObject.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine(SpanWaves());
	}

    void UpdateSpawnValues()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();
        spawnValues = new Vector3(half.x - 0.7f, 0f, half.y + 6f);
    }

    private void Update()
    {
        if(restart && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        
    }

    public void Restart()   // esto es para el boton restart ...
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator SpanWaves () {

        yield return new WaitForSeconds(esperainicialasteroide); // espera cuando arrana el primer asteroide


        while (true)
            
        {
            for (int i = 0; i < hazarount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);

                yield return new WaitForSeconds(spanwait); // espera de los asteroides entre los asteroides
            }
            yield return new WaitForSeconds(wavewait);// espera a la siguiente ola de asteroides

            if (gameOver)
            {
                RestartGameObject.SetActive(true);
                restart = true;
                break;
            }
        }
        

    }

    void UpdateScore()  // metodo para marcar en el display
    {
        scoretext.text = "Score: " + score;
    }

    public void AddScore(int value)   // metodo para sumar puntos
    {
        score += value;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverGameObject.SetActive(true);
        gameOver = true;
    }
}
