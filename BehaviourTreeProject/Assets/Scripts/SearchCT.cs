using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Conditions {

	public class SearchCT : ConditionTask {
		
		public NavMeshAgent agent;
		public BBParameter<GameObject> target;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			
			Collider[] hitColliders = Physics.OverlapSphere(agent.transform.position, 15f, LayerMask.GetMask("Droplets"));
			foreach (Collider collider in hitColliders)
			{
				target.value = collider.gameObject;
				return true; 
			}
			return false;
				}
	}
}