using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour{

    public bool isInitial, isFinal = false; //first or last scene
    public Text liveCounterText;
    public Text WorldNumberText;
    public int maxPlayerLives = 2; 

    void start(){
            liveCounterText.text = "Lives: " + 1000;//PlayerPrefs.GetInt("Lives");
            WorldNumberText.text = "World " + SceneManager.GetActiveScene().buildIndex; 
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
            liveCounterText.text = "Lives: " + 1000;//PlayerPrefs.GetInt("Lives");
            WorldNumberText.text = "World " + SceneManager.GetActiveScene().buildIndex;
        }
    }
}