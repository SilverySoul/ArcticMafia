using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class ChainsawBehavior : MonoBehaviour
	{
		[SerializeField]
		float remain_time = 0.1f;

		// Use this for initialization
		void Start()
		{
			StartCoroutine(LifeTime());
		}

		// Update is called once per frame
		void Update()
		{
			
		}

		public void OnTriggerEnter(Collider other)
		{
			if(other.tag == "SeaRion")
			{
				var sea_rion = other.gameObject.GetComponent<SeaRion>();
				sea_rion.Damage(1);
				Destroy(this.gameObject);
			}
		}

		IEnumerator LifeTime()
		{
			yield return new WaitForSeconds(remain_time);
			Destroy(this.gameObject);
		}
	}
}