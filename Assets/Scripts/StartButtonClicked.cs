using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonClicked : MonoBehaviour{

    public void start(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
