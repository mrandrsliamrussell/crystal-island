using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class L_AIManager : MonoBehaviour {
    [SerializeField]
    float  moveFreqMinDay = 1, moveFreqMaxDay = 6, moveFreqMinNight = 0, moveFreqMaxNight = 3; // this sets patrolling point changes so every x seconds between one of those times a jaguar in the pack will move to a new location
    [SerializeField]
    int NumberOfWolvesPerPack; // sets the pack size
    public GameObject packLocation, wolfPrefab, gameController, player;
    public List<GameObject> wolfList; //list of wolves in this pack
    public List<int> respawnIndexList;
	// Use this for initialization
	void Start () {
        spawnWolves();
        StartCoroutine(newPatrolPositions());
	}
	void Update()
    {
       
    }

    public void spawnWolves()
    {
        for(int i = 0; i< NumberOfWolvesPerPack; i++)
        {
            
                GameObject thisWolf = Instantiate(wolfPrefab, this.transform.position, Quaternion.identity); //creates a wolf
                thisWolf.name += i.ToString(); //names a wolf, mostly for debug reasons
                thisWolf.transform.position = this.transform.position; // moves the wolf to this location
                thisWolf.GetComponent<L_JaguarV2>().listIndex = i; // numbers the wolf so we know what one it is when it dies
                thisWolf.GetComponent<L_JaguarV2>().goal = packLocation.transform.position; // sets the firstwaypoint on the navmesh
                thisWolf.GetComponent<L_JaguarV2>().player = player; // lets the wolf know who to attack
                thisWolf.GetComponent<L_JaguarV2>().AiController = this.gameObject; // assigns the wolf to this instanced AI controller
                wolfList.Add(thisWolf); // finally assigns this wolf to this list
          
        }
        firstpositions();
    }
   
    IEnumerator newPatrolPositions()
    {
        
            Random.InitState(System.DateTime.Now.Millisecond);
        int i = Random.Range(0, NumberOfWolvesPerPack);
            wolfList[i].GetComponent<L_JaguarV2>().goal = new Vector3(
                 packLocation.transform.position.x + Random.Range(-packLocation.GetComponent<SphereCollider>().radius, +packLocation.GetComponent<SphereCollider>().radius),
                 wolfList[i].transform.position.y,
                 packLocation.transform.position.z + Random.Range(-packLocation.GetComponent<SphereCollider>().radius, +packLocation.GetComponent<SphereCollider>().radius));
        // chooses a random wolf in the list and moves it to a random point within the radius of the current collider
        if (gameController.GetComponent<L_gameController>().isItDay == true)
        {
            yield return new WaitForSeconds(Random.Range(moveFreqMinDay, moveFreqMaxDay));
            packLocation.GetComponent<SphereCollider>().radius = packLocation.GetComponent<L_wolfPackLocation>().dayRadius;
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(moveFreqMinNight, moveFreqMaxNight));
            packLocation.GetComponent<SphereCollider>().radius = packLocation.GetComponent<L_wolfPackLocation>().nightRadius;
        }
        // chooses which collider to use depending on the time of day
        if (respawnIndexList.Count != 0)
        {
            for (int k = 0; k < respawnIndexList.Count; k++) //if theres woves to respawn then see if they can be respawned
            {
                StartCoroutine(distanceRespawnDelay(respawnIndexList[k], k));
            }
        }
        StartCoroutine(newPatrolPositions());
    }
    void firstpositions()
    {
        for (int j = 0; j < NumberOfWolvesPerPack; j++)
        {
            wolfList[j].GetComponent<L_JaguarV2>().GetComponent<NavMeshAgent>().Warp( new Vector3(
                 packLocation.transform.position.x + Random.Range(-packLocation.GetComponent<SphereCollider>().radius, +packLocation.GetComponent<SphereCollider>().radius),
                 wolfList[j].transform.position.y,
                 packLocation.transform.position.z + Random.Range(-packLocation.GetComponent<SphereCollider>().radius, +packLocation.GetComponent<SphereCollider>().radius)));
        }
    }
   public IEnumerator distanceRespawnDelay(int jagIndex, int jagListIndex)
    {
        Debug.Log("respawn started" + (Vector3.Distance(player.transform.position, wolfList[jagIndex].transform.position)) + "   " + jagIndex);
        while (Vector3.Distance(player.transform.position, this.transform.position) < 50)
        {
            Debug.Log("player too close");
            // wolfList[jagIndex].SetActive(false); //keeps checking if the player is too close to the respawn for the jaguars to respawn.
            yield return new WaitForEndOfFrame();
        }
            yield return new WaitForSeconds(1);
            Debug.Log("jaguar respawned");
            wolfList[jagIndex].SetActive(true);
        try
        {
            respawnIndexList.RemoveAt(jagListIndex);
        }
        catch
        {

        }
        wolfList[jagIndex].GetComponent<L_JaguarV2>().patrol(this.transform.position);
    }
}
