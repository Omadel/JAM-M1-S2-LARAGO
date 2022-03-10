using UnityEngine;

namespace LaraGoLike
{
    public class Spawnner : MonoBehaviour
    {
        public void SetPositions(Tile tile, MagnetType type)
        {
            transform.position = tile.OffsettedPosition;
            foreach (var item in tile.neighbours.tiles)
            {

            }
        }
        public void SetMagnetAt(Tile tile)
        {

        }
    }
}
