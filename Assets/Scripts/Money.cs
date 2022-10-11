using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text gemsAmt;
    public void Update(){
        gemsAmt.text =  PlayerPrefs.GetInt("gems").ToString();
    }
}
