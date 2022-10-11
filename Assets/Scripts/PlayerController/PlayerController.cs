using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    [Range(-2.8f, 2.8f)] public float value;
    public float Speed = 1000f;
    Rigidbody rb;
    public Vector3 startPosition;



    private void Awake()
    {
        rb =  this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startPosition = this.transform.position;
    }

    void LateUpdate()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            transform.position = new Vector3 (value, transform.position.y, transform.position.z);
            rb.velocity = (Vector3.forward * Speed * Time.deltaTime);
            
            if (Input.GetButtonDown("Right"))
            {
                if (value == 0f)
                    value = 2.8f;

                else if (value == -2.8f)
                    value = 0f;
            }
            if (Input.GetButtonDown("Left"))
            {
                if (value == 0f)
                    value = -2.8f;

                else if (value == 2.8f)
                    value = 0f;
            }
            MobileController();
        }
    }

    public void StartGame()
    {
        Invoke("RestartPosition", 0f);
    }
    void RestartPosition()
    {
        this.transform.position = startPosition;
        this.rb.velocity = Vector2.zero;

    }

    // Difficulty Level
    public void SetSpeed(float modifier)
    {
        Speed = 1000f + modifier;
    }

 public void MobileController(){
     
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    startTouchPosition = Input.GetTouch(0).position;

    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
    {
        endTouchPosition = Input.GetTouch(0).position;

        // Right
        if (endTouchPosition.x > startTouchPosition.x)
        {
            if (value == 2.8f)
                return;
            value += 2.8f;
        } 

        // Left
        if (endTouchPosition.x < startTouchPosition.x)
        {
            if (value == -2.8f)
                return;
            value -= 2.8f;
        }
    }
 }

    public void Die()
    {
        GameManager.sharedInstance.GameOver();
    }
}
