using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement player
    public float jumpForce = 6f;
    public float runningSpeed = 2f;
    private Rigidbody2D _playerRigidbody;
    private Animator _animator;
    private Vector3 _startPosition;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";
    
    // Detect which elements it can collide with me
    public LayerMask groundMask;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _animator.SetBool(STATE_ALIVE, true);
        _animator.SetBool(STATE_ON_THE_GROUND, false);

        // Player initial position
        _startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        _animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        
        Debug.DrawRay(this.transform.position, 
            Vector2.down * 1.5f, 
            Color.red
            );
    }

    void FixedUpdate()
    {
        if (GameManager.SharedInstance.currentGameState == GameState.InGame)
        { // If we're playing
            if (_playerRigidbody.velocity.x < runningSpeed)
            {
                _playerRigidbody.velocity = new Vector2(runningSpeed, _playerRigidbody.velocity.y);
            }
        }
        else
        {   // If we aren't into play game
            // Vector2.zero is an special vector2 (0,0)
            _playerRigidbody.velocity = new Vector2(0, _playerRigidbody.velocity.y);
        }
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
            
            return true;
        }else {
            return false;
        }
    }

    public void StartGame()
    {
        this.transform.position = _startPosition;
        this._playerRigidbody.velocity = Vector2.zero;
    }

    public void Die()
    {
        this._animator.SetBool(STATE_ALIVE, false);
        GameManager.SharedInstance.GameOver();
    }
}
