using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoLeavesMod
{
    public class removeleaf : MonoBehaviour
    {
        private const string forestlocation = "Environment Objects/LocalObjects_Prefab/Forest";
        private const string leaves = "UnityTempFile-5642b89260ac826449cafb7fdeb899e4 (combined by EdMeshCombiner)";
        private static readonly int[] leafindex = { 22, 23, 24 };

        private void Start()
        {
            StartCoroutine(Run());
        }

        private IEnumerator Run()
        {
            for (int i = 0; i < 15; i++)
            {
                Remove();
                yield return new WaitForSeconds(0.5f);
            }

            while (true)
            {
                yield return new WaitForSeconds(5f);
                Remove();
            }
        }

        private void Remove()
        {
            foreach (GameObject obj in GetLeaves())
            {
                if (obj != null && obj.activeSelf)
                    obj.SetActive(false);
            }
        }

        private static IEnumerable<GameObject> GetLeaves()
        {
            HashSet<GameObject> found = new HashSet<GameObject>();
            GameObject forest = GameObject.Find(forestlocation);
            if (forest == null)
                return found;

            findbydaname(forest.transform, found);
            findbyindex(forest.transform, found);
            return found;
        }

        private static void findbydaname(Transform parent, ISet<GameObject> found)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child == null) continue;

                if (string.Equals(child.name, leaves, System.StringComparison.Ordinal))
                    found.Add(child.gameObject);

                findbydaname(child, found);
            }
        }

        private static void findbyindex(Transform root, ISet<GameObject> found)
        {
            foreach (int index in leafindex)
            {
                if (index < 0 || index >= root.childCount)
                    continue;

                Transform child = root.GetChild(index);
                if (child != null)
                    found.Add(child.gameObject);
            }
        }
    }
}