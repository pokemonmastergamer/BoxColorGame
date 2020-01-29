using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileMaterialScript : MonoBehaviour
{
    public Material tileMaterial;
    public Material player1TileMaterial;
    public Material defaultMaterial;
    public Material player2TileMaterial;

    public Text winText;
    public Text Player1ScoreText;
    public Text Player2ScoreText;
    public Text restartText;

    public bool player1Win = false;
    public bool player2Win = false;

    public GlobalScore globalScore;

    private Text[] texts = new Text[4];



    private void Start()
    {
        texts = FindObjectsOfType<Text>();

        for(int h = 0; h < 4; h++)
        {
            if(texts[h].CompareTag("WinText"))
            {
                winText = texts[h];
            }
            if(texts[h].CompareTag("Player1ScoreText"))
            {
                Player1ScoreText = texts[h];
            }
            if(texts[h].CompareTag("Player2ScoreText"))
            {
                Player2ScoreText = texts[h];
            }
            if (texts[h].CompareTag("RestartText"))
            {
                restartText = texts[h];
            }

        }

        globalScore = FindObjectOfType<GlobalScore>();
    }

    void OnTriggerEnter(Collider other)
    {
        tileMaterial = GetComponent<MeshRenderer>().material;
        //Player 1
        if (other.gameObject.tag == "Player1")
        {
            if(tileMaterial.color == defaultMaterial.color)
            {
                globalScore.player1Score++;
            }
            else if(tileMaterial.color == player2TileMaterial.color)
            {
                globalScore.player1Score++;
                globalScore.player2Score--;
            }

            tileMaterial.color = player1TileMaterial.color;
            

            }

        //Player 2
        if (other.gameObject.tag == "Player2")
        {
            if (tileMaterial.color == defaultMaterial.color)
            {
                globalScore.player2Score++;
            }
            else if (tileMaterial.color == player1TileMaterial.color)
            {
                globalScore.player2Score++;
                globalScore.player1Score--;
            }
            tileMaterial.color = player2TileMaterial.color;
        }
    }

    private void LateUpdate()
    {
        UpdateTextVariables();
    }

    public void UpdateTextVariables()
    {
        if(player1Win)
        {
            winText.text = "Player 1 Wins!";
            winText.enabled = true;
        }
        else if(player2Win)
        {
            winText.text = "Player 2 Wins!";
            winText.enabled = true;
        }

        Player1ScoreText.text = "Player 1 Score: <b>" + globalScore.player1Score + "</b>";
        Player2ScoreText.text = "Player 2 Score: <b>" + globalScore.player2Score + "</b>";
    }

    private void Update()
    {
        if(globalScore.player1Score + globalScore.player2Score == 100)
        {
            if(globalScore.player1Score > globalScore.player2Score)
            {
                player1Win = true;
            }
            else if(globalScore.player2Score > globalScore.player1Score)
            {
                player2Win = true;
            }
            restartText.enabled = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            globalScore.ReloadCurrentScene();
        }
    }

}
