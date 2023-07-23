using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public List<GameObject> InitializePool(GameObject prefab, int size)
        {
            List<GameObject> pool = new List<GameObject>();
            for (int i = 0; i < size; i++)
            {
                GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
                obj.SetActive(false);
                pool.Add(obj);
            }
            return pool;
        }
        public GameObject GetObjectFromPool(List<GameObject> pool)
        {
            // Tìm đối tượng chưa được sử dụng trong Pool
            foreach (GameObject obj in pool)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            // Nếu không có đối tượng nào chưa được sử dụng, tạo thêm đối tượng mới và thêm vào Pool
            GameObject newObj = Instantiate(pool[0], transform.position, Quaternion.identity);
            newObj.SetActive(false);
            pool.Add(newObj);
            return newObj;
        }
    }
}
