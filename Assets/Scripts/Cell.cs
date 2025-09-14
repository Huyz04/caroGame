using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cell : MonoBehaviour
{
    public Sprite xSprite, oSprite;
    private Image image;
    private Button button;
    private Board board;
    private EndGame endGame;
    public int row, col;

    private void Awake() {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        board = FindObjectOfType<Board>();
        endGame = FindObjectOfType<EndGame>();
    }

    private void OnClick(){

        if (image.sprite == xSprite || image.sprite == oSprite)
        {
            Debug.Log("Cell was chosen !");
            return;
        }

        ChangeImage(board.currentTurn);
        if(board.currentTurn == "x")
        {
            board.currentTurn = "o";
        } else
        {
            board.currentTurn = "x";
        }

        if (board.CheckWin(row, col))
        {
            Debug.Log("Win");
            endGame.end_text.SetActive(true);
            endGame.SetName(board.name);
        }
    }

    public void ChangeImage(string s){
        if(s == "x"){
            image.sprite = xSprite;
        } else {
            image.sprite = oSprite;
        }
    }
}