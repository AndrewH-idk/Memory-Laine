using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    

    private void Awake()
    { //starts health at starting health and initialized anim
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        // makes sure health cant go above or below max/min
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        { //plays "hurt" animation
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        { //plays "die" animation
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<playerMovement1>().enabled = false;
                dead = true;
            }
        }
    }

    private IEnumerator Invulnerability()
    {
        //makes player invulnerable
        Physics2D.IgnoreLayerCollision(10, 11, true);
        //invulnerability duration
        for (int  i = 0;  i < numberOfFlashes; i++)
        {
            //the parameters are the colors code
            spriteRend.color = new Color(0, 1, 1, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRend.color = new Color(1, 1, 1, 0.9f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}