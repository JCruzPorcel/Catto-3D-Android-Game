using System.Collections;
using UnityEngine;

public class GenerateCube : MonoBehaviour
{
    public GameObject CubeObj;
    Vector3 Pos;
    bool next;
    public float[] posX;
    public float[] posZ;
    int value = 1;
    public int lastpos = 1;
    public Transform playerRange;


    void FixedUpdate()
    {
        Generate();
       // StartCoroutine(WaitSys());
    }
  /*  IEnumerator WaitSys()
    {
        yield return new WaitForSeconds(0f);
        next = true;
        Generate();
    }*/

    void Generate(){
      //  if (!next)
      //      return;
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        { 
        int i = Random.Range (0, 3);
        Pos.x = posX[i];
        Pos.z += posZ[i];
        GameObject CubeClone = Instantiate(CubeObj, Pos, CubeObj.transform.rotation);
        CubeClone.GetComponent<CubeScript>().myNum = value;
        CubeClone.transform.SetParent (this.transform);
            value += 1;
        //next = false;
        //return;
        }
    }
    public void Message(int i){
         if(lastpos == i) {
            lastpos += 1;
        }
    }
}
