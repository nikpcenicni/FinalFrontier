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
	public float moveBy;

    public bool fell;
    public bool dead;

    public TextMeshProUGUI textCoins;
    public Animator animator;
    private SpriteRenderer viewRender;
    private Vector3 originalPos;    

    Rigidbody2D rb;
    
    
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


    // Player Functions
    public void addCoins(int amount){
        coins += amount;
    }
    void Heal() {
        if (Input.GetKeyDown(KeyCode.E)){
            TryTakeHealthPot();
        }
    }

    void TryTakeHealthPot() {

    }

    void Hurt(){
        health--;
        if (health <= 0){
            dead = true;
        }else {

        }
    }


    // Movement
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
            fell = true;
            bank = coins;
        }
    }

    // Player UI

    void updateCoinText() {
        if (coins < 10) 
            textCoins.text = "00" + coins.ToString();
        else if (coins < 100 && coins >= 10) 
            textCoins.text = "0" + coins.ToString();
        else
            textCoins.text = coins.ToString();
    }
    void updateHealtText() {

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



    // enemy damage detection
    void OnTriggerEnter2D(Collision2D collision){
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null){
            Hurt();
        }
    }


    public void levelCompleted() {
        bank = bank+coins;
    }

    public void Restart(){
        rb.transform.position = originalPos;
        bank = coins;
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


    // weapons
    public void pistol(){
        //damage = shop.shopItems[3,1];
    }

    public void LaserRifle(){
        //damage = shop.shopItems[3,2];
    }

    public void PlasmaRifle(){
        //damage = shop.shopItems[3,3];

    }
}
