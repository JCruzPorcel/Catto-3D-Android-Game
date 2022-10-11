using System.Collections;
using UnityEngine;

public class GenerateCoin : MonoBehaviour
{
    public GameObject CoinObj;
    Vector3 Pos;
    bool next;
    public float[] posX;
    public float[] posZ;
    int value = 1;
    public int lastpos = 1;
    public float coinY;

    void FixedUpdate()
    {
     //   StartCoroutine(WaitSys());
        Generate();
    }
   /* IEnumerator WaitSys()
    {
        yield return new WaitForSeconds(0f);
        next = true;
        Generate();
    }*/
    void Generate()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
        // if (!next)
        //     return;
        int i = Random.Range(0, 3);
        Pos.x = posX[i];
        Pos.z += posZ[i];
        Pos.y = coinY;
        GameObject CoinClone = Instantiate(CoinObj, Pos, CoinObj.transform.rotation);
        CoinClone.GetComponent<CoinScript>().myNum = value;
        CoinClone.transform.SetParent(this.transform);
        value += 1;
        //next = false;  
        //return;
        }
    }
    public void Message(int i)
    {
        if (lastpos == i)
        {
            lastpos += 1;
        }
    }
}
