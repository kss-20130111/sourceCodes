using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearScript : MonoBehaviour
{
    //GameManagerの取得
    GameObject gameManager;
    GameManager gameManagerScript;

    private void Start()
    {
        //GameManagerの初期化
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    public void GameClearUIOn()
    {
        //ゲームクリアUIボタンオン
        gameManagerScript.GameClearNextButton.Select();
        Time.timeScale = 0f;
    }
}
