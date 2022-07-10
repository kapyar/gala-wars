using UnityEngine;

namespace Game.Combat
{
    public class GunHolder : MonoBehaviour
    {
        [SerializeField] private GameObject _left;
        [SerializeField] private GameObject _right;
        [SerializeField] private GameObject _cannon;

        public GameObject Left => _left;
        public GameObject Right => _right;
        public GameObject Cannon => _cannon;
    }
}