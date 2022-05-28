
using UnityEngine;

public class NoteCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Debug.Log("You've got hitted by Notes");
        }
    }
}
