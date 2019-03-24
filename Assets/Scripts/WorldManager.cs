using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour{

    public bool isInitial, isFinal = false; //first or last scene
    public Text liveCounterText;
    public Text worldNumberText;
    public Text worldCompletedNumberText;
    public int maxPlayerLives = 2; 

    void Awake(){
        if(!isInitial && !isFinal){
            liveCounterText.text = "Lives: " + PlayerPrefs.GetInt("Lives");
            worldNumberText.text = "World " + SceneManager.GetActiveScene().buildIndex; 
            worldCompletedNumberText.text = "World " + SceneManager.GetActiveScene().buildIndex; 
        }
    }

    public void setPlayerLives(){
        PlayerPrefs.SetInt("Lives",maxPlayerLives);
    }

    public void RestartGame(){
         SceneManager.LoadScene(0);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void goToNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void reloadLevel(){
        
        PlayerPrefs.SetInt("Lives",PlayerPrefs.GetInt("Lives") -1); //Lives --

        if(PlayerPrefs.GetInt("Lives") <= 0){
            setPlayerLives();
            RestartGame();
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}