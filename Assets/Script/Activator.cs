using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    SpriteRenderer outr;
    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject note,gm;
    Color old;
    Color oldchild;

    public bool createMode;
    public GameObject n;
    


    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        outr = GetComponent<SpriteRenderer>();
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        gm = GameObject.Find("GameManager");
        old = outr.color;
        oldchild = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }

            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                gm.GetComponent<GameManager>().addstreak();
                AddScore();
                active = false;
            }
            else if(Input.GetKeyDown(key) && !active)
            {
                gm.GetComponent<GameManager>().ResetStreak();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Note")
        {
            note = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
        //gm.GetComponent<GameManager>().ResetStreak();
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+gm.GetComponent<GameManager>().GetScore());
    }

    IEnumerator Pressed()
    {
        outr.color = new Color(255,255,255);
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = oldchild;
        outr.color = old;
    }

}
