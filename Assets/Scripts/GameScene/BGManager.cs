using UnityEngine;

namespace GameScene
{
    public class BgManager : MonoBehaviour
    {
        public Transform player;
    
        void Update()
        {
            if (player == null)
            {
                return;
            }

            if (player.position.x - transform.position.x > 15f || player.position.x - transform.position.x < -15f)
            {
                transform.position = player.position;
            }

            if (player.position.y - transform.position.y > 15f || player.position.y - transform.position.y < -15f)
            {
                transform.position = player.position;
            }
        }
    }
}