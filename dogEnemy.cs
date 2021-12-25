using UnityEngine;

public class dogEnemy : MonoBehaviour
{
    
    [SerializeField] private float damage;
    [SerializeField] private float range;


    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;
    private SpriteRenderer spriteRend;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + (-1 * transform.right) * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 2, playerLayer);
            
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + (-1 * transform.right) * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 2, playerLayer))
    }

    private void Test()
    {
        if (PlayerInSight())
        {
            spriteRend.color = new Color(1, 0, 0, 1);
        }
        else
        {
            spriteRend.color = new Color(0, 1, 0.7f, 0.5f);
        }
    }


 
}