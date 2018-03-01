using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Sho
{
	public class GoldManager : MonoBehaviour
	{
		[SerializeField]
		private List<GoldBehavior> golds_prehab = new List<GoldBehavior>();

		private List<GoldBehavior> golds_list = new List<GoldBehavior>();

		private readonly Vector3 invaild_value = new Vector3(-100000, -100000, -100000);

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			
		}

		public Vector3 SearchNearGold(Vector3 p)
		{
			if (golds_list.Count <= 0) return invaild_value;
			return golds_list.OrderBy(x => (x.transform.position - p).magnitude).First().transform.position;
		}

		public bool IsInValidValue(Vector3 value)
		{
			return value == invaild_value;
		}

		public void Add(GoldBehavior gold)
		{
			golds_list.Add(gold);
		}

		public void DestroyFromList(GoldBehavior gold)
		{
			golds_list.Remove(gold);
		}
	}
}