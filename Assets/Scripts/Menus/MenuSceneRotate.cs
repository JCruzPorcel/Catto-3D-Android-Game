using UnityEngine;

public class MenuSceneRotate : MonoBehaviour
{
    private void Update() {
        transform.Rotate(new Vector3(0, 0.05f, 0));
    }
}