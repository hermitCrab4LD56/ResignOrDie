using UnityEngine;

public class PlayerSwitchOnDeath : MonoBehaviour
{
    public GameObject player; // Assign GameObject A (with controller)
    public GameObject koSymbol; // Assign GameObject B (starts inactive)
    // public int playerHealth = 100;
    private Health playerHealth;

    private PlayerMovement controllerA;
    private SimpleMovement controllerB;

    void Start()
    {
        // Get controller components
        controllerA = player.GetComponent<PlayerMovement>();
        controllerB = koSymbol.GetComponent<SimpleMovement>();
        playerHealth = player.GetComponent<Health>();

        // Ensure B is hidden at scene start
        koSymbol.SetActive(false);
    }

    void Update()
    {
        // Example health check (in a real case, reduce health elsewhere)
        if (playerHealth.CurrentHealth == 0 && player.activeSelf)
        {
            Debug.Log("Hit!");
            SwitchPlayer();
        }
    }

    // public void Damageplayer(int damage)
    // {
    //     playerHealth -= damage;
    // }

    private void SwitchPlayer()
    {
        // Disable A
        controllerA.enabled = false;
        player.SetActive(false);

        // Enable B
        koSymbol.SetActive(true);
        controllerB.enabled = true;
    }
}
