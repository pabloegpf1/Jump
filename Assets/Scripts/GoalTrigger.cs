using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour
{
    public Canvas canvas;

    void OnTriggerEnter(Collider other){
        //canvas.CrossFadeAlpha(0.1f, 2.0f, false);
        canvas.enabled = true;
    }

}
