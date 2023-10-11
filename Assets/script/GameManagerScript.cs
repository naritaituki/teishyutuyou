using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameManagerScript : MonoBehaviour
{
    public enum GAME_STATUS { Play, Clear, Pause, GameOver };
    public static GAME_STATUS status;
    public static int tempCoinNum;
    [SerializeField] Text coinNumText, resultCoinText, levelNumText;
    int stageCoinNum;

    int levelNum;
    int stageNum;
    void Start()
    {
        stageCoinNum = GameObject.FindGameObjectsWithTag("BOX").Length;

        tempCoinNum = PlayerPrefs.GetInt("coinNum", 0);
        //ステータスをPlayに
        status = GAME_STATUS.Play;
    }

    void Update()
    {
        if (status == GAME_STATUS.Clear)
        {
            int getCoinNum = tempCoinNum - PlayerPrefs.GetInt("coinNum", 0);
            resultCoinText.text = getCoinNum.ToString().PadLeft(3) + "/" + stageCoinNum;
            PlayerPrefs.SetInt("coinNum", tempCoinNum);
            enabled = false;
        }
        else if (status == GAME_STATUS.GameOver)
        {
            Invoke("ShowGameOverUI", 3f);
            enabled = false;
            return;
        }
        coinNumText.text = tempCoinNum.ToString();
    }
}