using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreMenu; //Score in menu Death
    public Text highScoreText;

    public float scoreCount;   
    public float hiScoreCount;
    public float pointPerSecond;

    public int highScore;
    public bool scoreIncreasing;

    // Incrementace Difficulty

    public float difficultyLevel;
    public float maxDifficultyLevel;
    public float scoreToNextLevel;
    public float LevelMax;

    void Awake()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore").ToString();

    }
     void start ()
    {
        highScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
     void Update()
    {

        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (scoreIncreasing)
            {
                scoreCount += pointPerSecond * Time.deltaTime;
            }
            
            if (scoreCount >= scoreToNextLevel){
                LevelUp();
            }

            scoreText.text = "Score: " + Mathf.Round(scoreCount);
            scoreMenu.text = "Score: " + Mathf.Round(hiScoreCount);
            highScoreText.text = "HighScore: " + Mathf.Round(hiScoreCount);
            
            if (scoreCount > PlayerPrefs.GetFloat("HighScore", 0))
            {
                PlayerPrefs.SetFloat("HighScore", scoreCount);
                highScoreText.text = scoreCount.ToString();
                PlayerPrefs.Save();
            } 
                    
            if (scoreCount > hiScoreCount)
            {
                hiScoreCount = scoreCount;

                highScoreText.text = hiScoreCount.ToString();

                PlayerPrefs.SetFloat("HighScore", hiScoreCount);
                PlayerPrefs.Save();
            }     
        }
    }
    void LevelUp(){
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if(difficultyLevel == maxDifficultyLevel && difficultyLevel <= LevelMax)
                return;

            scoreToNextLevel *= 2;
            difficultyLevel += 250;
          //  GetComponent<SwipeMove>().SetSpeed(difficultyLevel);
            GetComponent<PlayerController>().SetSpeed (difficultyLevel);    
   
        }
    }
}
