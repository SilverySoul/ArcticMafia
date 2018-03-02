using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class Cursor : MonoBehaviour
	{
		public AudioPenguinScript SoundPlacementScript;

		private PenguinManager Manager { get; set; }
		private PolarBear Bear { get; set; }

		[SerializeField, Header("Offset of Penguin when create")]
		private float offset_height = 1.0f;

		public bool CanCreate { get; set; }

		// Use this for initialization
		void Start()
		{
			CanCreate = true;
			Manager = GameObject.Find("PenguinManager").GetComponent<PenguinManager>();
			Bear = GameObject.Find("PolarBear").GetComponent<PolarBear>();
		}

		// Update is called once per frame
		void Update()
		{
			if (CanCreate && Input.GetMouseButtonDown(0) && Bear.CheckCanBuyPenguin())
			{
				SoundPlacementScript.PenguingSpawnSound();
				var p = Bear.transform.position;
				//p.y += offset_height;
				p += Bear.transform.forward * 2;
				var type = Bear.BuyPenguin();
				var pen = Manager.CreatePenguins(p, type);
				if (!pen)
				{
					Bear.ToReturnPenguin(type);
					return;
				}
				switch (type)
				{
					case PenguinManager.PenguinType.Json:
						{
							var n = pen.gameObject.AddComponent<JsonBehavior>();
							n.SoundScript = SoundPlacementScript;
						}
						break;
					case PenguinManager.PenguinType.Gun:
						{
							var n = pen.gameObject.AddComponent<GunBehavior>();
							n.SoundScript = SoundPlacementScript;
						}
						break;
					case PenguinManager.PenguinType.Gold:
						{
							var n = pen.gameObject.AddComponent<TakeGoldBehavior>();
							//n.SoundScript = SoundPlacementScript;
						}
						break;
					default:
						break;
				}
			}
		}
	}
}