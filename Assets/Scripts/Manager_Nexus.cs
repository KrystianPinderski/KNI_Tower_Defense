using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Nexus : MonoBehaviour {


    private static Manager_Nexus instance;
    public static Manager_Nexus Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Manager_Nexus>();
            }
            return instance;
        }
    }



    [Header("Nexus")]
	public GameObject nexus; //Must have public, because generate Gizmos.DrawLine error
	public float hp_Nexus = 100.00f;
	public float damage_Value = 0.10f;
	public GameObject enemy; // prefab

	[Header("Points spawn")]
	public GameObject[] points;

    [SerializeField]
	private GameObject Enemies;
	//private int id = 0;

	[Header("Generate Mobs - Waves of enemies")]
	public float stay_Time_Wave = 5.00f;
	public int how_Much_Mobs = 10;
	public float stay_Time_Generate_Next_Mob = 0.70f;
	private int id_Waves = 0;

	void Start () 
	{

		//nexus = this.gameObject;
		//Enemies = new GameObject (); //Parent clone
		//Enemies.name = "Parent - Clones Enemies";



		//StartCoroutine (GenerateEnemy(stay_Time_Wave,how_Much_Mobs,stay_Time_Generate_Next_Mob));


	}
	

	void Update () 
	{

		
	}

	void OnDrawGizmos()
	{

		foreach (GameObject a in points) 
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine (a.transform.position, nexus.transform.position);

		}
	}



	IEnumerator GenerateEnemy(float _stay_Time_Wave, int _how_Much_Mobs, float _stay_Time_Generate_Next_Mob)
	{
		//if think add button start

		//while (true) 
		//{
			//print ("Waves - Id: ("+id_Waves+")");

			int i = 0;
			while (i <_how_Much_Mobs) 
			{
				int random_Value = Random.Range (0, 5); // must have range 0-6
				//print ("Random number: "+random_Value);

				GameObject clone = Instantiate (enemy, points [random_Value].transform.position, Quaternion.identity);
				clone.name = "Enemy - Id: (" + i + ") - Random number: (" + random_Value + ")";
				clone.transform.SetParent (Enemies.transform);


				yield return new WaitForSeconds (_stay_Time_Generate_Next_Mob);
			i++;
			}
			//yield return new WaitForSeconds (_stay_Time_Wave);

			//id_Waves++;
		//}
	}


	public void TakeDamage()
	{
		if (hp_Nexus > 0) 
		{
			hp_Nexus = float.Parse ((hp_Nexus - damage_Value).ToString ("F")); // this line add because example value float: "90.0001", "90.0006"
			//print ("hp: " + hp_Nexus);
		} 
		else if (hp_Nexus == 0) 
		{
			print ("Nexus Destroyed!'\n'+Time frozen!");
			Time.timeScale = 0f;
		}
			
	}


    public void NextLevel(float time,int enemys,float timestep)
    {
        StartCoroutine(GenerateEnemy(time, enemys, timestep));
    }


}
