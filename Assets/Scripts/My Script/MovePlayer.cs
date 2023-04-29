using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed = 10;
    private float TimeCounter = 0;

    float PosX;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() //A-D controller
    {
        TimeCounter += Time.deltaTime;
        if (TimeCounter > 30f)
        {
            moveSpeed += 0.5f;
            Debug.Log("Speed Increased");
            TimeCounter = 0f;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, moveSpeed);
        controller.Move(move * Time.deltaTime * moveSpeed);
    }
}
