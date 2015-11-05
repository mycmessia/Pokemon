using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	public Group group1 = new Group ();
	public Group group2 = new Group ();

	void Start ()
	{
		InitTrainer (group1.id);
		InitTrainer (group2.id);
	}
	
	void InitTrainer (int groupId)
	{
		List<int> tempPokemonList = new List<int> (); 
		tempPokemonList.Add (1);
		
		GameObject go = (GameObject) Instantiate (
			Resources.Load ("Prefabs/Trainer"), 
			Vector3.zero, 
			Quaternion.identity
		);
		
		Trainer trainer = go.GetComponent<Trainer> ();
		trainer.Init (tempPokemonList);
		
		if (groupId == group1.id)
		{	
			group1.trainerList.Add (trainer);	
		}
		else
		{
			group2.trainerList.Add (trainer);
		}
	}
}
