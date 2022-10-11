using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public int myNum;
    private GenerateCube generate;
    private Renderer rend;

    private void Start()
    {
        generate = GetComponentInParent<GenerateCube> ();
        rend = GetComponent<Renderer> ();
    }
    private void OnTriggerEnter(Collider Collision)
    {
        if(Collision.tag == "Player"){
            PlayerController controller = Collision.GetComponent<PlayerController>();
            controller.Die();
        }
    }
}
