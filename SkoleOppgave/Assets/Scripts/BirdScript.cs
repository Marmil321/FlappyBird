using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb;

    public GameManager gm;

    bool dead;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        RotateBird();

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !dead)
        {
            rb.velocity = Vector2.up * jumpForce;
            //Debug.Log("jump");
        }
        //Reset Game
        if (Input.GetKeyDown(KeyCode.Space) && dead)
        {
            Restart();
        }
    }

    void RotateBird()
    {
        float angle = Vector3.Angle(Vector3.right, rb.velocity);

        if (rb.velocity.y > 0)
        {
            //Debug.Log("up");
            angle = angle - 30;

        }
        else if (rb.velocity.y < 0)
        {
            angle = -angle + 30;
            //Debug.Log("down");
        }

        transform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead();
    }

    void Dead()
    {
        dead = true;
        gm.scoreText.transform.localPosition = new Vector3(0,102,0);
        gm.showScoreImage.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
