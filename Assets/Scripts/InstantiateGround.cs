using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class InstantiateGround : MonoBehaviour {

    JsonController jc;
    private GameObject jsonObject;
    float maxDestroyTime = 5f;
    float spawnTime = 2f;
    float cpyDestroy;
    
    //float cpySpawn;

    bool newGroundInstanciated;
    

    private void Awake() {
        jsonObject = GameObject.Find("JsonObj");
        jc = jsonObject.GetComponent<JsonController>();
        newGroundInstanciated = false;
        StartCoroutine(Wait());
    }
    private IEnumerator Wait() {
        Debug.Log("Waiting for the json data loading");
        yield return new WaitUntil(() => jc.isJsonLoaded == true);
        Debug.Log("Done");

        maxDestroyTime = jc.getMaxDestroyTime();
        spawnTime = jc.getSpawnTime();
        cpyDestroy = maxDestroyTime;
        //cpySpawn = spawnTime;

        Debug.Log("Max destroy time : " + maxDestroyTime);
        Debug.Log("Spawn time : " + spawnTime);
    }
    private void Update() {
        maxDestroyTime -= 1 * Time.deltaTime;
        GroundTimer(maxDestroyTime);

        if (!newGroundInstanciated && maxDestroyTime < spawnTime) {
            GenerateGround();
        }
        if (maxDestroyTime <= 0) {
            DestroyGround();
            //maxDestroyTime = cpyDestroy;
        }


    }
    private void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.name == "Destroyer") {
            DestroyGround();
        }
    } 

    private void GenerateGround() {
        List<Vector3> pos = new List<Vector3>() { new Vector3(9, 0, 0), new Vector3(-9, 0, 0), new Vector3(0, 0, 9), new Vector3(0, 0, -9) };
        newGroundInstanciated = true;
        int index = Random.Range(0, pos.Capacity);
        Vector3 currpos = GameObject.FindWithTag("Ground").transform.position;
        pos.Remove(currpos);
        
        Vector3 newpos = new Vector3(gameObject.transform.position.x + pos[index].x, 0, gameObject.transform.position.z + pos[index].z);
        pos.Remove(newpos);
        if (currpos != newpos) {
            Instantiate(gameObject, newpos, Quaternion.identity);
        }
        
        
    }

    private void DestroyGround() {
        Destroy(this.gameObject);
    }

    
    private void GroundTimer(float maxDestroyTime) {
        gameObject.transform.Find("Canvas").Find("Timer").GetComponent<TMP_Text>().text = maxDestroyTime.ToString().Substring(0, 4);
    }
}
