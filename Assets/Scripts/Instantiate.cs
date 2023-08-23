using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Instantiate : MonoBehaviour
{
    [SerializeField] GameObject prefabInstantiate;
    [SerializeField] Transform aim;
    [SerializeField] List<GameObject> ballsList;
    [SerializeField] List<Rigidbody> rigidbodies;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject refBall = Instantiate(prefabInstantiate, aim.position, aim.rotation);
            refBall.name = refBall.name + Time.time.ToString();
            ballsList.Add(GameObject.Find(refBall.name));
            rigidbodies.Add(GameObject.Find(refBall.name).GetComponent<Rigidbody>());
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (GameObject itens in ballsList)
            {
                //itens.SetActive(false);
                Destroy(itens);
                
            }
            System.GC.Collect();
        }
    }
}
