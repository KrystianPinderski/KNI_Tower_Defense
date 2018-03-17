using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour {


    [SerializeField]
    private Text enemyinfo;
    [SerializeField]
    private Text battleinfo;
    [SerializeField]
    private Text battleinfopanel;



    public int EnemyDeath
    {
        get
        {
            return enemyDeath;
        }
        set
        {
            enemyDeath = value;
            if(enemyalive==enemyDeath)
            {
                Time.timeScale = 0;
                Level_completed_Panel.SetActive(true);
                Mouse.Instance.changeVisible();
            }
            enemyinfo.text = "Enemy: " + enemyDeath + "/" + enemyalive;
        }
    }

    public GameObject Level_info;
    public GameObject GameOver_Panel;
    public GameObject Level_completed_Panel;

    private int enemyDeath;
    private int enemyalive=10;

    public int bonusStepBattle = 4;
    private int battle=0;

    public int MyBattle
    {
        get
        {
            return battle;
        }
        set
        {
            battle = value;
            battleinfo.text = "BATTLE:" + battle;
            battleinfopanel.text = "You win the battle:" + battle; 

        }
    }

    private static MyGameManager instance;
    public static MyGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MyGameManager>();
            }
            return instance;
        }
    }

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("Battle", 1);
        NextLevel();
        Mouse.Instance.changeVisible();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextLevel()
    {
        MyBattle += 1;
        PlayerPrefs.SetInt("Battle", MyBattle);
        if (PlayerPrefs.GetInt("Battle")==1)
        {
            Manager_Nexus.Instance.NextLevel(1, 10, 2);
            EnemyDeath = 0;
            enemyalive = 10;
        }
        else
        {
            enemyalive += bonusStepBattle;
            EnemyDeath = 0;
            Manager_Nexus.Instance.NextLevel(1, enemyalive, 2);
        }
        Time.timeScale = 1;
        Mouse.Instance.changeVisible();
        Level_completed_Panel.SetActive(false);
    }

    public void GameOver()
    {

    }
}
