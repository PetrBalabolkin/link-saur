using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class IconsSpawner : MonoBehaviour
    {
        public GameObject[] connects;
        public GameObject[] disconnects;
        public GameObject kill;
        public int countConnects;
        public int countDisconnects;
        public int countKills;
    
        public GameObject player;
    
        private Vector2 _spawnAreaMin;
        private Vector2 _spawnAreaMax;
        private Vector2 _lastPosition;

        private List<GameObject> _spawned = new List<GameObject>();
    
        private void Start()
        {
            Vector3 playerPos = player.transform.position;
            _spawnAreaMin = new Vector2(playerPos.x - 15, playerPos.y - 15);
            _spawnAreaMax = new Vector2(playerPos.x + 15, playerPos.y + 15);
            SpawnIcons();
            _lastPosition = new Vector2(playerPos.x, playerPos.y);
        }
    
        private void Update()
        {
            float deltaPosX = player.transform.position.x - _lastPosition.x;
            float deltaPosY = player.transform.position.y - _lastPosition.y;
            if (Mathf.Abs(deltaPosX) > 15 || Mathf.Abs(deltaPosY) > 15)
            {
                _lastPosition = new Vector2(player.transform.position.x, player.transform.position.y);
                _spawnAreaMin = new Vector2(_lastPosition.x - 20, _lastPosition.y - 20);
                _spawnAreaMax = new Vector2(_lastPosition.x + 20, _lastPosition.y + 20);
                ClearIcons();
                SpawnIcons();
            }
        }

        private void SpawnIcons()
        {
            SpawnObjects(connects, countConnects);
            SpawnObjects(disconnects, countDisconnects);
            SpawnObjects(new GameObject[] { kill }, countKills);
        }

        private void SpawnObjects(GameObject[] prefabs, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 pos = new Vector3(Random.Range(_spawnAreaMin.x, _spawnAreaMax.x), Random.Range(_spawnAreaMin.y, _spawnAreaMax.y), 0);
                GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
                GameObject icon = Instantiate(prefab, pos, Quaternion.identity);
                _spawned.Add(icon);
            }
        }
    
        private void ClearIcons()
        {
            foreach (var icon in _spawned)
            {
                if (icon != null)
                    Destroy(icon);
            }
            _spawned.Clear();
        }
    }
}