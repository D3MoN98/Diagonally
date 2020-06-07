using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerBehavior playerBehavior;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Obstacle")
        {
            playerBehavior.stopMovement = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
