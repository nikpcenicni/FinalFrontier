using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 0;
    public int coins = 0;
    public int health = 1;
    Rigidbody2D rb;
    public float speed;
    public float jumpforce;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    public int defaultAdditionalJumps = 1;
    int additionalJumps;
    private SpriteRenderer viewRender;
	public Animator animator;
	public float moveBy;
    public bool fallen;
    private Vector3 originalPos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        viewRender = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
        originalPos = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
        //loadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
         Move();
		 animator.SetFloat("Speed", Mathf.Abs(moveBy));
         Jump();
         BetterJump();
         CheckIfGrounded();
         CheckDirection();
         SavePlayer();
         CheckIfFall();
    }

    public Vector3 GetPosition() {
        return transform.position;
    }
    
    void CheckDirection(){
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            viewRender.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            viewRender.flipX = true;
        }
    }
    
    void Move(){
    	float x = Input.GetAxisRaw("Horizontal");
    	moveBy = x * speed;
    	rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    
    void Jump(){
    	if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 1)){
    	    rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    	    additionalJumps--;
            animator.SetBool("isJumping", true);
    	}
    }
    
    void CheckIfGrounded() {
	Collider2D collider = Physics2D.OverlapCircle( isGroundedChecker.position, checkGroundRadius, groundLayer );
	if (collider != null) {
        animator.SetBool("isJumping", false);
	     isGrounded = true;
	     additionalJumps = defaultAdditionalJumps;
	} else {
	     if (isGrounded) {
	     	lastTimeGrounded = Time.time;
	     }
	     isGrounded = false;
	}
    }
    
    void BetterJump() {
    	if (rb.velocity.y < 0) {
    	     rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
    	} else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
    	     rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    	}  
    }

    void CheckIfFall() {
        if (rb.transform.position.y < -11) {
            fallen = true;
        }
    }

    public void Restart(){
        rb.transform.position = originalPos;
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void loadPlayer() {
        PlayerData data = SaveSystem.loadPlayer();

        level = data.level;
        health = data.health;
        coins = data.coins;

        Vector3 position; 
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}