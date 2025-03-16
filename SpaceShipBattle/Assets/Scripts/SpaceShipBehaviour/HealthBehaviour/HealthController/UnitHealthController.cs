public class UnitHealthController : HealthController<PlayerShipData>
{
    public HealthBarUI healthBarUI;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        healthBarUI.SetMaxHealt(currentHealth);
    }

    protected override void SetCurrentHealth(int damage)
    {
        base.SetCurrentHealth(damage);
        healthBarUI.SetHealth(currentHealth);
    }
}
