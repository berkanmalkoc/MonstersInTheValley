using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterWait : MonoBehaviour
{
	public float lifeTime ;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
	}
}
