using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
     public GameObject game_area;
    public GameObject bee_prefab;
 
    public int bee_count = 0;
    public int bee_limit = 150;
    public int bee_per_frame = 1;
 
    public float spawn_circle_radius = 80.0f;
    public float death_circle_radius = 90.0f;
 
    public float fastest_speed = 12.0f;
    public float slowest_speed = 0.75f;
 
    void Start()
    {
        InitialPopulation();
    }
 
    void Update()
    {
        MaintainPopulation();
    }
 
    void InitialPopulation()
    {
        /** To avoid having to wait for the ships to enter the screen at start up, create an
        initial set of ships for instant action. **/
 
        for(int i=0; i<bee_limit; i++)
        {
            Vector3 position = GetRandomPosition(true);
            Bee bee_script = AddShip(position);
            bee_script.transform.Rotate(Vector3.forward * Random.Range(0.0f, 360.0f));
        }
    }
 
    void MaintainPopulation()
    {
        /** Create more ships as old ones are destroyed, while respecting the object limit. **/
 
        if(bee_count < bee_limit)
        {
            for(int i=0; i<bee_per_frame; i++)
            {
                Vector3 position = GetRandomPosition(false);
                Bee bee_script = AddShip(position);
                bee_script.transform.Rotate(Vector3.forward * Random.Range(-45.0f,45.0f));
            }
        }
    }
 
    Vector3 GetRandomPosition(bool within_camera)
    {
        /** Get a random spawn position, using a 2D circle around the game area. **/
 
        Vector3 position = Random.insideUnitCircle;
 
        if(within_camera == false)
        {
            position = position.normalized;
        }
 
        position *= spawn_circle_radius;
        position += game_area.transform.position;
 
        return position;
    }
 
    Bee AddShip(Vector3 position)
    {
        /**Add a new ship to the game and set the basic attributes. **/
 
        bee_count += 1;
        GameObject new_bee = Instantiate(
            bee_prefab,
            position,
            Quaternion.FromToRotation(Vector3.up, (game_area.transform.position-position)),
            gameObject.transform
        );
 
        Bee bee_script = new_bee.GetComponent<Bee>();
        bee_script.bee_spawner = this;
        bee_script.game_area = game_area;
        bee_script.speed = Random.Range(slowest_speed, fastest_speed);
 
        return bee_script;
    }
}
