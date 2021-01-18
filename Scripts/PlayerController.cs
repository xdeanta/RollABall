using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    // Start is called before the first frame update
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public TextMeshProUGUI CountText;
    public GameObject WinTextObject;

    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        setCountText();
        WinTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get < Vector2 >();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText(){
        CountText.text = "Count: " + count.ToString();
        if(count >= 8){
            WinTextObject.SetActive(true);
        }
    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(movementX,0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }
}
