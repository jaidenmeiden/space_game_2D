using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Detect which elements it can collide with me
    public LayerMask groundMask;
    // Movement player
    public float jumpForce = 6f, runningSpeed = 2f, jumpRaycastDistance = 1.5f;
    
    private Rigidbody2D _playerRigidbody;
    private Animator _animator;
    private Vector3 _startPosition;
    [SerializeField]
    private int helthPoints, manaPoints;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";
    public const float SUPER_JUMP_FORCE = 1.5f;
    public const int INITIAL_HEALTH = 100, MAX_HEALTH = 200, MIN_HEALTH = 10, 
        INITIAL_MANA = 15, MAX_MANA = 30, MIN_MANA = 0,
        SUPER_JUMP_COST = 5;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Player initial position
        _startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump(false);
        }
        if (Input.GetButtonDown("SuperJump"))
        {
            Jump(true);
        }

        _animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        
        Debug.DrawRay(this.transform.position, 
            Vector2.down * jumpRaycastDistance, 
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

    void Jump(bool isSuperJump)
    {
        float jumpForceFactor = jumpForce;
        if (isSuperJump && manaPoints >= SUPER_JUMP_COST)
        {
            manaPoints -= SUPER_JUMP_COST;
            jumpForceFactor *= SUPER_JUMP_FORCE;
        }
        if (GameManager.SharedInstance.currentGameState == GameState.InGame)
        {
            if (IsTouchingTheGround())
            {
                _playerRigidbody.AddForce(Vector2.up * jumpForceFactor, ForceMode2D.Impulse);
            } 
        }
    }
    
    //It tells us whether or not the character is touching the ground
    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(
            this.transform.position, // Where am I
            Vector2.down, // Lightning to the ground
            jumpRaycastDistance, // Distance to ground
            groundMask // Ground mask for contact
            )){
            
            return true;
        }else {
            return false;
        }
    }

    public void StartGame()
    {
        _animator.SetBool(STATE_ALIVE, true);
        _animator.SetBool(STATE_ON_THE_GROUND, false);

        helthPoints = INITIAL_HEALTH;
        manaPoints = INITIAL_MANA;

        Invoke("RestartPosition", 0.1f);
    }

    private void RestartPosition()
    {
        this.transform.position = _startPosition;
        this._playerRigidbody.velocity = Vector2.zero;
        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<CameraFollow>().ResetCameraPosition();
    }

    public void Die()
    {
        float travelledDistance = GetTravelledDistance();
        float previousMaxDistance = PlayerPrefs.GetFloat("maxscore", 0f);
        if (travelledDistance > previousMaxDistance)
        {
            PlayerPrefs.SetFloat("maxscore", travelledDistance);
        }
        
        this._animator.SetBool(STATE_ALIVE, false);
        GameManager.SharedInstance.GameOver();
    }

    public void CollectHealth(int points)
    {
        this.helthPoints += points;
        if (this.helthPoints > MAX_HEALTH)
        {
            this.helthPoints = MAX_HEALTH;
        }

        if (this.helthPoints <= 0)
        {
            Die();
        }
    }

    public void CollectMana(int points)
    {
        this.manaPoints += points;
        if (this.manaPoints > MAX_MANA)
        {
            this.manaPoints = MAX_MANA;
        }
    }

    public int GetHealth()
    {
        return this.helthPoints;
    }

    public int GetMana()
    {
        return this.manaPoints;
    }

    public float GetTravelledDistance()
    {
        return this.transform.position.x - _startPosition.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Big Rock"))
        {
            this.jumpRaycastDistance = 2.7f;
            return;
        }
        else
        {
            if (collision.tag.Equals("Medium Rock"))
            {
                this.jumpRaycastDistance = 2.0f;
                return;
            }
            else
            {
                this.jumpRaycastDistance = 1.5f;
                return;
            }
        }
    }
}
