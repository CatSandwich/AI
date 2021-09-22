using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static List<Transform> Enemies = new List<Transform>();

    public Transform Parent;
    public GameObject EnemyPrefab;
    public float Cooldown;
    public int Max;

    void Start() => StartCoroutine(_spawnerCoroutine()); 
    
    private IEnumerator _spawnerCoroutine()
    {
        while (true)
        {
            if (Enemies.Count <= Max)
            {
                var go = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
                go.transform.SetParent(Parent, true);
                Enemies.Add(go.transform);
            }
            yield return new WaitForSeconds(Cooldown);
        }
    }
}
