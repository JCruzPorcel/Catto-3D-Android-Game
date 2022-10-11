using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int myNum;
    private GenerateCoin generate;
    public float turnSpeed = 90f;

    private void Start()
    {
        generate = GetComponentInParent<GenerateCoin>();

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject); 
            return;
        }
        if (col.tag == "Obstacle"){
            Destroy(gameObject);
            return;
        }
    }
     private void Update()
    {
     transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}