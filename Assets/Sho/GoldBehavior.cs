using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class GoldBehavior : MonoBehaviour
	{
		[SerializeField]
		private int gold_count = 10;

		public int GoldCount
		{
			get { return gold_count; }
		}

		GoldManager Manager { get; set; }

		[SerializeField]
		private float offset_y = 1.0f;

		// Use this for initialization
		void Start()
		{
			Manager = GameObject.Find("GoldManager").GetComponent<GoldManager>();
			Manager.Add(this);
		}

		// Update is called once per frame
		void Update()
		{
			// test
			this.transform.Rotate(new Vector3(0, 20, 0));
		}

		private void OnDestroy()
		{
			Manager.DestroyFromList(this);
		}

		public void OnTriggerEnter(Collider other)
		{
			Debug.Log(other.tag);
			if(other.tag == "SeaRion")
			{
				var rion = other.gameObject.GetComponent<SeaRion>();
				rion.AddGold(GoldCount);
				Destroy(this);
			}
			else if(other.tag == "Penguin")
			{
				var p = other.gameObject.GetComponent<Penguin>();
				if(p.Type == PenguinManager.PenguinType.Gold)
				{
					var gold = other.gameObject.GetComponent<TakeGoldBehavior>();
					gold.TakeGold(GoldCount);
					Destroy(this.GetComponent<Rigidbody>());
					Destroy(this.GetComponent<Collider>());
					this.transform.parent = gold.transform;
					var lp = new Vector3();					
					lp.y = offset_y;
					this.transform.localPosition = lp;
				}
			}
		}
	}
}