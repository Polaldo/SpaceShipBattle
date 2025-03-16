using UnityEngine;

public abstract class HealthController<T> : MonoBehaviour, IDamageble where T : SpaceShipData
{
    public T spaceShipData;
    protected Animator animator;
    public int currentHealth;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = spaceShipData.health;
    }

    protected bool CheckHealth()
    {
        return currentHealth <= 0;
    }

    protected virtual void Kill()
    {
        animator.SetTrigger("Death");
    }

    public void ApplyDamage(int damage)
    {
        SetCurrentHealth(damage);
        if (CheckHealth())
        {
            Kill();
        }
    }

    protected virtual void SetCurrentHealth(int damage)
    {
        currentHealth = currentHealth - damage;
    }

    public virtual void DestroyObject()
    {
        Destroy(gameObject);
    }
}
