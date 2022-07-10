using System;
using UnityEngine;

namespace Game.Movement
{
    [Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;

        public Bounds(Camera camera, MeshRenderer renderer)
        {
            var bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
            var renderBoundaries = renderer.bounds.extents;

            xMax = bounds.x - renderBoundaries.x;
            xMin = -bounds.x + renderBoundaries.x;

            yMax = bounds.y - renderBoundaries.y;
            yMin = -bounds.y + renderBoundaries.y;
        }
    }
}