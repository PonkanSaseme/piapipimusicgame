using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int multplier = 1;
    int streak = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        ResetStreak();
    }

    public void addstreak()
    {
        streak++;

        if (streak >= 16)
        {
            multplier = 16;
        }
        else if (streak >= 12)
        {
            multplier = 8;
        }
        else if (streak >= 8)
        {
            multplier = 4;
        }
        else if (streak >= 4)
        {
            multplier = 2;
        }
        else
        {
            multplier = 1;
        }
        UpdateGUI();
    }

    public void ResetStreak()
    {
        streak = 0;
        multplier = 1;
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Multplier",multplier);
    }

    public int GetScore()
    {
        return 100 * multplier;
    }
}
