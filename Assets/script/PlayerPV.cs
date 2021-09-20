using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPV : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float invincibilityTimeAfter = 3f;
    public float invincibilitydelay = 0.15f;

    public bool invicible = false;

    public SpriteRenderer graphic;
    public Health healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            TakeDamage(80);
        }
    }
    //méthodes take damage
    public void TakeDamage(int damage)
    {
        if(!invicible)
        {
            currentHealth -= damage;
            //currentHealth = currentHealth - damage;
            healthBar.SetHealth(currentHealth);

            // Vérifier si le joueur est vivant
            if(currentHealth <=0)
            {
                Death();
                return;
            }

            invicible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(DeleteInvisibility());
        }
    }

    public void Death()
    {
        Debug.Log("Le joueur est éliminé");
        //bloquer le mouvement du personnage;
        PlayerMouvement.instance.enabled = false;
        //jouer l'animation de mort;
        PlayerMouvement.instance.animator.SetTrigger("Dead");
        //empêcher les interactions;
        PlayerMouvement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMouvement.instance.CapsuleCollider2D.enabled = false;
    }

    public IEnumerator InvincibilityFlash()
    {
        while(invicible)
        {
            graphic.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilitydelay);
            graphic.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilitydelay);
        }
    }

    public IEnumerator DeleteInvisibility()
    {
        yield return new WaitForSeconds(invincibilityTimeAfter);
        invicible = false;
    }
}
