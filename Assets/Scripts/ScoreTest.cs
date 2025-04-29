using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreTest : MonoBehaviour
{

    public TextMeshProUGUI Stage1;
    public TextMeshProUGUI Stage2;

    // Start is called before the first frame update
    void Start()
    {
        Stage1.text = "STAGE 1 : " + HighScore.Load(1).ToString();
        Stage1.text = "STAGE 2 : " + HighScore.Load(2).ToString();
    }
}
