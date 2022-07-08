using UnityEngine;

namespace Game.Helpers
{
    public class BulletDestroyer : MonoBehaviour
    {
        public void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}