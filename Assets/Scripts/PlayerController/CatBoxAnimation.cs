using UnityEngine;

public class CatBoxAnimation : MonoBehaviour
{

        private Vector2 startTouchPosition, endTouchPosition;

    void Update()
    {
        
        // PC Controller 

        if (Input.GetKeyDown("d"))
        {
            gameObject.GetComponent<Animator>().SetBool("movingRight", true);
        }
        if (!Input.GetKeyDown("a") && !Input.GetKeyDown("d"))
        {
            gameObject.GetComponent<Animator>().SetBool("movingRight", false);
            gameObject.GetComponent<Animator>().SetBool("movingLeft", false);
        }

        if (Input.GetKeyDown("a"))
        {
            gameObject.GetComponent<Animator>().SetBool("movingLeft", true);
        }


        // Android Touch Controller

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            // Right
            if (endTouchPosition.x > startTouchPosition.x)
            {
              gameObject.GetComponent<Animator>().SetBool("movingRight", true);

            }
        if(endTouchPosition.x > startTouchPosition.x && endTouchPosition.x < startTouchPosition.x){
            gameObject.GetComponent<Animator>().SetBool("movingRight", false);
            gameObject.GetComponent<Animator>().SetBool("movingLeft", false);            
        }

            // Left
            if (endTouchPosition.x < startTouchPosition.x)
            {
             gameObject.GetComponent<Animator>().SetBool("movingLeft", true);

            }
        }
    }
}
