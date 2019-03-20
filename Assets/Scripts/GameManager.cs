using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public static int maxLifes = 2;
    private static int lifes;

    void Start(){
        lifes = maxLifes;
    }

    public static void goToNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public static void reloadLevel(){
        lifes --;
        if(lifes <= 0){
            Debug.Log("GAME OVER");
            lifes = maxLifes;
            SceneManager.LoadScene(0);
        }else{
            Debug.Log("Lifes: "+lifes);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}