using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;

    public Text winText;

    void Start()// called  on the first frame that the script is active
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void Update() // called before rendering a frame
    {
        // where most of the code will go

    }

    void FixedUpdate() // called before performing any physics calculations
    {
        // where physics code will go
        //grabs the Input from our player through the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    //called by Unity when our player game object first touches a trigger collider
    //given as argument : a reference to the trigger collider that we have touched
    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 13)
        {
            winText.text = "You win !";
        }
    }
}
