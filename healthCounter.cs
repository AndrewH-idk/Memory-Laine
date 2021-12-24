using UnityEngine;
using UnityEngine.UI;

public class healthCounter : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image currentHealthCount;

    private void Update()
    {
        currentHealthCount.fillAmount = playerHealth.currentHealth / 10 ;
    }
}
