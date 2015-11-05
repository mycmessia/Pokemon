using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Group {
	
	private int _id;
	public int id { get { return _id; } }
	
	public List<Trainer> trainerList = new List<Trainer> ();
	
	public Group ()
	{
		_id = IDController.id;
	}
	
}