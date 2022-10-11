using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject DeathMenu;
    public GameObject HudMenu;

    // This function runs when we hit another object.
    // We get information about the collision and call it "collisionInfo"
    void OnCollisionEnter (Collision collisionInfo){
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        DeathMenu.SetActive(true);
        HudMenu.SetActive(false);
        }
    }
}
