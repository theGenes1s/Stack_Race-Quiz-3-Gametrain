using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public static GameController instance;
    [SerializeField] Text scoreDisplay;
    int score;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (instance == null)
        instance = this;
    }
    public void UpdateScore(int valueIn)
    {
        score += valueIn;
        scoreDisplay.text = score.ToString();


    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
