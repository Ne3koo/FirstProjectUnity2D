using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiMovement : MonoBehaviour
{
    public SpriteRenderer serpent;
    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision;

    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        //déplacement de l'ennemi
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        // Si le NPC est quasiment arrivé à destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            serpent.flipX = !serpent.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerPV playerPV = collision.transform.GetComponent<PlayerPV>();
            playerPV.TakeDamage(10);
        }
    }
}
