using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    Rigidbody2D rd;
    public float speed;

    private void Awake()
    {
        rd=GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        rd.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
