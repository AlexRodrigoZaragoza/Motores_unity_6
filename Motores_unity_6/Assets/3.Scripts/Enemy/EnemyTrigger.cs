using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El enemigo ha alcanzado al jugador, muerte.");

            GameManager Manager = FindFirstObjectByType<GameManager>();
            Manager.Die();
        }
    }
}
