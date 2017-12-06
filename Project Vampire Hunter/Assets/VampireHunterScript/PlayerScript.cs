using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	Rigidbody2D rb;
	Animator animator;
	SpriteRenderer sprite;
	public float moveSpeed = 5f;
	public float jumpPower = 6f;
	public float attackTimer = 0.07f;
	private float timer;
	public int maxHealth = 100;
	public int currentHealth;
	int attackDamage = 1;

	bool onGround;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();
		currentHealth = maxHealth;
	}

	void FixedUpdate()
	{
		DoGroundCheck ();
		DoInput ();

		timer += Time.deltaTime;
		if(timer >= attackTimer)
		{
			
		}

		if(transform.position.y < -5)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void DoGroundCheck()
	{
		Collider2D[] colliderList = Physics2D.OverlapBoxAll (transform.position, new Vector2 (0.5f, 0.5f), 0);
		foreach (Collider2D collider in colliderList) {
			if (collider.tag == "ground" && rb.velocity.y == 0) {
				print (collider.tag);
				onGround = true;
			}
		}
		if(onGround == true)
		{
			print (onGround);
		}
	}

	void DoInput()
	{
		if (Input.GetAxis ("Horizontal") > 0) {
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			animator.SetBool ("isWalking", true);
			sprite.flipX = false;
		}
		if (Input.GetAxis ("Horizontal") < 0) {
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
			animator.SetBool ("isWalking", true);
			sprite.flipX = true;
		}
		if (Input.GetAxis ("Horizontal") == 0) {
			rb.velocity = new Vector2 (0, rb.velocity.y);
			animator.SetBool ("isWalking", false);
		}

		if (Input.GetButton ("Jump") && onGround && rb.velocity.y == 0) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
			print (onGround);
			onGround = false;
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		if(currentHealth <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
