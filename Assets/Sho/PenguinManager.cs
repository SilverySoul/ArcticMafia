using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Sho
{
	public class PenguinManager : MonoBehaviour
	{
		public enum PenguinType
		{
			// has Chainsaw
			Json,
			// has Gun
			Gun,
			// to take some gold
			Gold,
		}
		[SerializeField]
		private List<Penguin> penguins = new List<Penguin>();
		private int CurrentId { get; set; }

		[SerializeField, Header("Penguin's Prehab")]
		private Penguin source_of_penguin = null;

		public int PenguinsCountInField
		{
			get { return penguins.Count; }
		}

		[SerializeField]
		private int penguins_count_max_in_field = 0;
		public int PenguinsCountInFieldMax
		{
			get { return penguins_count_max_in_field; }
		}


		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public Penguin CreatePenguins(Vector3 pos)
		{
			if (PenguinsCountInField >= PenguinsCountInFieldMax)
			{
				Debug.Log("Penguins are Max Count In Field");
				return null;
			}
			var ret = GameObject.Instantiate<Penguin>(source_of_penguin);
			ret.ID = CurrentId++;
			ret.transform.position = pos;
			penguins.Add(ret);
			return ret;
		}

		public Penguin SearchNearOne(GameObject actor)
		{
			if (penguins.Count <= 0) return null;
			return penguins.OrderBy(x => (x.transform.position - actor.transform.position).magnitude).First();
		}

		public void DeadPenguin(Penguin pen)
		{
			penguins.Remove(pen);
		}
	}
}