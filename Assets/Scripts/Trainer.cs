using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trainer : MonoBehaviour {

	private int _id;
	public int id { get { return _id; } }

	public List<Pokemon> pokemonList = new List<Pokemon> ();

	void Awake ()
	{
		_id = IDController.id;
	}

	public void Init (List<int> indexList)
	{
		for (int i = 0; i < indexList.Count; i++)
		{
			Pokemon pokemon = new Pokemon (indexList[i]);
			GameObject go = Instantiate (
								Resources.Load ("Prefabs/Pokemons/Generation" + pokemon.generation + "/" + pokemon.nameE), 
								Vector3.zero, 
								Quaternion.identity
							) as GameObject;
			go.transform.parent = transform;
			go.SetActive (false);
			pokemon.go = go;
		}
	}
}
