using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public static int level = 0;
    public int coins = 5;
    public int bank;
    public int maxHealth = 5;
    public int currentHealth;
    public float highScore;

    public healthBar healthBar;

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
    public int defaultAdditionalJumps;
    int additionalJumps;
	public float moveBy;

    public bool fell;
    public bool dead;
    public bool lastGroundedChecked;
    public bool hasJumped;

    public bool[] achievementsUnlocked = new bool[10];
    public float[] achievementsProgress = new float[10];
    public int kills;

    public GameObject achievementCanvas;
    public GameObject achievementDescription;
    public float achMoveSpeed = 2f;
    public bool achievementOn = false;

    public GameObject pauseMenu;
    public GameObject deadMenu;
    public TextMeshProUGUI textCoins;
    public Animator animator;
    private SpriteRenderer viewRender;
    private Vector3 originalPos;    

    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        viewRender = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
        originalPos = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        if (pauseMenu.activeSelf || deadMenu.activeSelf) {
            SavePlayer();
        }
         CheckIfFall();
         Heal();
         updateCoinText();
         CheckAchievementProgress();
          }



    // Player Functions
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

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
/*
    void Hurt(){
        health--;
        if (health <= 0){
            dead = true;
        }else {

        }
    }*/


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
        if (!pauseMenu.activeSelf && !deadMenu.activeSelf) {
            achievementsProgress[6] += Math.Abs(moveBy) * Time.deltaTime;
        }
        if (moveBy != 0) {
            achievementsProgress[8] = 0;
        }
    	rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    
    void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || additionalJumps > 0)){
            if (!pauseMenu.activeSelf && !deadMenu.activeSelf)
            {
                achievementsProgress[7] += 1;
            }
            achievementsProgress[8] = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            if (hasJumped) {
                additionalJumps--;
            }
            animator.SetBool("isJumping", true);
            hasJumped = true;
    	}
    }
    
    void CheckIfGrounded() {
	Collider2D collider = Physics2D.OverlapCircle( isGroundedChecker.position, checkGroundRadius, groundLayer );
	if (collider != null) {
         animator.SetBool("isJumping", false);
	     isGrounded = true;
	     additionalJumps = defaultAdditionalJumps;
        if (lastGroundedChecked)
        {
            hasJumped = false;
        }
        lastGroundedChecked = false;
    } else {
	    if (isGrounded && !lastGroundedChecked) {
	        lastTimeGrounded = Time.time;
            lastGroundedChecked = true;
        }
        if (Time.time - lastTimeGrounded <= rememberGroundedFor && !hasJumped)
        {
            isGrounded = true;
        }
        else {
            isGrounded = false;
        }
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
            TakeDamage(1);
            rb.transform.position = originalPos;
        }
    }

    public void addKill() {
        achievementsProgress[1] += 1;
    }

    void CheckAchievementProgress() {
        if (deadMenu.activeSelf)
        {
            achievementsProgress[1] = 0;
        }
        if (!pauseMenu.activeSelf && !deadMenu.activeSelf)
        {
            achievementsProgress[8] += Time.deltaTime;
        }
        achievementsProgress[9] = highScore;
        if (!achievementOn)
        {
            if (!achievementsUnlocked[0])
            {
                //Not Implementing Yet
            }
            if (achievementsProgress[1] >= 100 && !achievementsUnlocked[1])
            {
                achievementsUnlocked[1] = true;
                StartCoroutine(TriggerAchievement("Confirm 100 Kills Without Dying"));
            }
            if (!achievementsUnlocked[2])
            {
                //Not Implementing Yet
            }
            if (!achievementsUnlocked[3])
            {
                //Not Implementing Yet
            }
            if (!achievementsUnlocked[4])
            {
                //Not Implementing Yet
            }
            if (!achievementsUnlocked[5])
            {
                //Not Implementing Yet
            }
            if (achievementsProgress[6] > 180836 && !achievementsUnlocked[6])
            {
                achievementsUnlocked[6] = true;
                StartCoroutine(TriggerAchievement("Travel a Marathon's Distance (~42km)"));
            }
            if (achievementsProgress[7] >= 1000 && !achievementsUnlocked[7])
            {
                achievementsUnlocked[7] = true;
                StartCoroutine(TriggerAchievement("Jump 1000 Times"));
            }
            if (achievementsProgress[8] >= 900 && !achievementsUnlocked[8])
            {
                achievementsUnlocked[8] = true;
                StartCoroutine(TriggerAchievement("Stand Still for 15 Minutes"));
            }
            if (highScore > 428 && achievementsUnlocked[9]) {
                achievementsUnlocked[9] = true;
                StartCoroutine(TriggerAchievement("Get a Score of Over 100m in Endless Mode"));
            }
        }
    }

    IEnumerator TriggerAchievement(String s) {

        achievementOn = true;
        achievementDescription.GetComponent<TMPro.TextMeshProUGUI>().text = s;
        achievementCanvas.SetActive(true);
        Vector2 currentPos = achievementCanvas.transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / 1f;
            achievementCanvas.transform.position = Vector2.Lerp(currentPos, new Vector2(currentPos.x, 34), t);
            yield return null;
        }
        yield return new WaitForSeconds(3);
        currentPos = achievementCanvas.transform.position;
        t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / 1f;
            achievementCanvas.transform.position = Vector2.Lerp(currentPos, new Vector2(currentPos.x, -34), t);
            yield return null;
        }
        achievementCanvas.SetActive(false);
        achievementDescription.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        achievementOn = false;

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
    /*void updateHealtText() {

    }*/

    //moon rock collection
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "moonRock")
        {
            coins++;
            if (coins < 10)
                textCoins.text = "00" + coins.ToString();
            else if (coins < 100 && coins >= 10)
                textCoins.text = "0" + coins.ToString();
            else
                textCoins.text = coins.ToString();
            Destroy(other.gameObject);
        }
        else if (other.transform.tag == "Enemy")
        {
            TakeDamage(1);
            rb.transform.position = originalPos;

        }
        if (other.transform.tag == "Kill" ){
            addKill();
            Destroy(other.gameObject);
        }
    }



    public void levelCompleted() {
        bank = bank+coins;
    }

    public void Restart(){
        rb.transform.position = originalPos;
        bank = coins;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void loadPlayer() {
        PlayerData data = SaveSystem.loadPlayer();

        level = data.level;
        currentHealth = data.health;
        bank = data.bank;
        coins = bank;
        highScore = data.highScore;

        for (int i = 0; i < achievementsUnlocked.Length; i++)
        {
            achievementsUnlocked[i] = data.achievementsUnlocked[i];
        }
        for (int i = 0; i < achievementsProgress.Length; i++)
        {
            achievementsProgress[i] = data.achievementsProgress[i];
        }
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
