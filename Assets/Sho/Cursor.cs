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

		[SerializeField,Header("Offset of Penguin when create")]
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
				var ts = Input.mousePosition;

				ts.x = Mathf.Clamp(ts.x, 0.0f, Screen.width);
				ts.y = Mathf.Clamp(ts.y, 0.0f, Screen.height);

				var tpr = Camera.main.ScreenPointToRay(ts);

				var hit = new RaycastHit();
				if (Physics.Raycast(tpr, out hit))
				{
					if (hit.collider.gameObject.tag == "Ground")
					{
                        SoundPlacementScript.PenguingSpawnSound();
						var p = hit.point;
						p.y += offset_height;

						var pen = Manager.CreatePenguins(p);
						if (!pen) return;
						var type = Bear.BuyPenguin();
						switch (type)
						{
							case PenguinManager.PenguinType.Json:
								pen.gameObject.AddComponent<JsonBehavior>();
                                pen.GetComponent<JsonBehavior>().SoundScript = SoundPlacementScript;
                                break;
							case PenguinManager.PenguinType.Gun:
								pen.gameObject.AddComponent<GunBehavior>();
                                pen.GetComponent<GunBehavior>().SoundScript = SoundPlacementScript;

                                break;
							case PenguinManager.PenguinType.Gold:
								pen.gameObject.AddComponent<TakeGoldBehavior>();
                                break;
							default:
								break;
						}
					}
				}
			}
		}
	}
}