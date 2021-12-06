using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement player
    public float jumpForce = 6f;
    private Rigidbody2D _playerRigidbody;
    
    // Detect which elements it can collide with me
    public LayerMask groundMask;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        
        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.red);
    }

    void Jump()
    {
        if (IsTouchingTheGround())
        {
            _playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    //It tells us whether or not the character is touching the ground
    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(
            this.transform.position, // Where am I
            Vector2.down, // Lightning to the ground
            1.5f, // Distance to ground
            groundMask // Ground mask for contact
            )){
            //TODO: program ground contact logic
            Debug.Log("Ground collision!");
            return true;
        }else {
            //TODO: program non-contact logic
            return false;
        }
    }
}
