using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDog : MonoBehaviour
{
    [SerializeField]
    private GameObject Dog;
    [SerializeField]
    private GameObject Car;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Spawn(1));
    }

    IEnumerator Spawn(int right)
    {
        var ran = Random.Range(4, 8);
        yield return new WaitForSeconds(ran);
        var obj = Random.Range(0, 10);
        if(obj < 9){
            if (right == 1) { 
                Vector3 temp = Dog.transform.position;
                temp.y = Random.Range(-4.0f, 5.0f);
                GameObject dog = Instantiate(Dog, temp, Quaternion.identity);
                dog.GetComponent<DogControler>().dir = right;
            }else
            {
                Vector3 temp = Dog.transform.position;
                temp.x += 7f;
                temp.y = Random.Range(-4.0f, 5.0f);
                GameObject dog = Instantiate(Dog, temp, Quaternion.identity);
                dog.transform.localScale = new Vector3(-dog.transform.localScale.x, dog.transform.localScale.y, dog.transform.localScale.z);
                dog.GetComponent<DogControler>().dir = right;
            }
            
        }else{
            Vector3 temp = Car.transform.position;
            temp.x = Random.Range(-1.5f, 1.5f);
            GameObject car = Instantiate(Car, temp,Quaternion.identity);
            car.GetComponent<CarController>().dir = temp.x;
            yield return new WaitForSeconds(20);    
        }
        var randir = Random.Range(0, 2)*2-1;
        StartCoroutine(Spawn(randir));
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
