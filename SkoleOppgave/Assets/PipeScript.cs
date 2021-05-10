using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float speed;
    public GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gm.score++;
    }
}
