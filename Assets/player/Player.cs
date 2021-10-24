using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static int level = 0;
    public int coins = 5;
    public int bank;
    public int health = 5;
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
    public bool dead;
    public TextMeshProUGUI textCoins;
    private Vector3 originalPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        viewRender = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
        originalPos = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
        loadPlayer();
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
         Heal();
         updateCoinText();
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    private void Heal() {
        if (Input.GetKeyDown(KeyCode.E)){
            TryTakeHealthPot();
        }
    }

    private void TryTakeHealthPot() {

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


    void updateCoinText() {
        if (coins < 10) 
            textCoins.text = "00" + coins.ToString();
        else if (coins < 100 && coins >= 10) 
            textCoins.text = "0" + coins.ToString();
        else
            textCoins.text = coins.ToString();
    }
    
    //moon rock collection
    void OnTriggerEnter2D(Collider2D other ){
        if(other.transform.tag == "moonRock"){
            coins ++;
            if (coins < 10) 
                textCoins.text = "00" + coins.ToString();
            else if (coins < 100 && coins >= 10) 
                textCoins.text = "0" + coins.ToString();
            else
                textCoins.text = coins.ToString();
            Destroy(other.gameObject);
        }
    }

    void Hurt(){
        health--;
        if (health <= 0){
            dead = true;
        }else {

        }
    }

    // enemy damage detection
    void OnTriggerEnter2D(Collision2D collision){
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null){
            Hurt();
        }
    }

    void CheckIfFall() {
        if (rb.transform.position.y < -11) {
            fallen = true;
            coins = 0;
        }
    }
    public void levelCompleted() {
        bank = bank+coins;
    }

    public void Restart(){
        rb.transform.position = originalPos;
        coins = 0;
        textCoins.text = "000";
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void loadPlayer() {
        PlayerData data = SaveSystem.loadPlayer();

        level = data.level;
        health = data.health;
        bank = data.bank;
        coins = bank;
    }
}
