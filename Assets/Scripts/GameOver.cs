using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static BoxScript instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D target) {

      if (instance.ignoreTrigger)
            return;

         if(target.gameObject.tag == "Box") {
            CancelInvoke("Landed");
            instance.gameOver = true;
            instance.ignoreTrigger = true;

            instance.RestartGame();
        
         }
    }
}
