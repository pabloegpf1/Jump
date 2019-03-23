using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour{

    public bool isInitial, isFinal = false; //first or last scene
    public Text liveCounterText;
    public Text WorldNumberText;
    public int playerLives = 2; 

    void start(){
        if(isInitial == false && isFinal == false){
            liveCounterText.text = "Lives: " + PlayerPrefs.GetInt("Lives");
            WorldNumberText.text = "World " + SceneManager.GetActiveScene().buildIndex;
        }    
    }

    public void setPlayerLives(){
        PlayerPrefs.SetInt("Lives",playerLives);
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
            SceneManager.LoadScene(0);
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}