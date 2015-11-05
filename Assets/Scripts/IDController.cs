using UnityEngine;
using System.Collections;

public class IDController {

	static int _idCounter = 0;				// unique id
	
	public static int id
	{
		get
		{
		 	return _idCounter++;
		}
	}
}
