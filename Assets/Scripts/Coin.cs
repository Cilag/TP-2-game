using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Le joueur a ramassé le coin, ajoutez +10 au score
            GameManager.Instance.currentScore += 10;
            // Désactivez le GameObject du coin pour le faire disparaître
            gameObject.SetActive(false);
        }
    }
}
