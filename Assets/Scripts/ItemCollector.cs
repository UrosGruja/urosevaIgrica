using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static int points = 0;
    [SerializeField] public static int nextLevel = 2500;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text levelText;
    [SerializeField] private int legCollectBonus = 100;
    [SerializeField] private int hamCollectBonus = 250;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ChickenLeg"))
        {
            points += legCollectBonus;
            Destroy(collision.gameObject);
        } 
        else if (collision.gameObject.CompareTag("Ham"))
        {
            points += hamCollectBonus;
            Destroy(collision.gameObject);   
        }

        pointsText.text = "Score: " + points;
        levelText.text = "Level: " + ((points / nextLevel) + 1);
    }
}
