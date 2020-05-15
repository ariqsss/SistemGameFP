using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public int health = 2;
    string CurrentScene;


    Vector2 movement;
    // Update is called once per frame
    public void Start()
    {
         CurrentScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //////////////////////////////////////////////////////// need change if add level
        if (other.gameObject.name == "Right1")
        {
            SceneManager.LoadScene("level2");
        }
        if (other.gameObject.name == "Right2")
        {
            SceneManager.LoadScene("level3");
        }
        if (other.gameObject.name == "Right3")
        {
            SceneManager.LoadScene("level4");
        }
        if (other.gameObject.name == "Right4")
        {
            SceneManager.LoadScene("level5");
        }
        //////////////////////////////////////////////////////// need change if add level
        if (other.gameObject.name == "Wrong")
        {
            Debug.Log("Change Scene!");
            if (string.Equals(CurrentScene, "level1"))
            {

                PlayerPrefs.SetInt("level", 1);
                Debug.Log("SavedCurrentLevel : 1");
            }
            if (string.Equals(CurrentScene, "level2"))
            {
                PlayerPrefs.SetInt("level", 2);
                Debug.Log("SavedCurrentLevel : 2");
            }
            if (string.Equals(CurrentScene, "level3"))
            {
                PlayerPrefs.SetInt("level", 3);
                Debug.Log("SavedCurrentLevel : 3");
            }
            if (string.Equals(CurrentScene, "level4"))
            {
                PlayerPrefs.SetInt("level", 4);
                Debug.Log("SavedCurrentLevel : 4");
            }
            if (string.Equals(CurrentScene, "level5"))
            {
                PlayerPrefs.SetInt("level", 5);
                Debug.Log("SavedCurrentLevel : 5");
            }
            SceneManager.LoadScene("EnemyQuiz");
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
