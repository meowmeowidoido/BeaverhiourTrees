using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveAT : ActionTask {
        public BBParameter<NavMeshAgent> agent;
        public BBParameter<GameObject> target;
        public BBParameter<NavMeshAgent> pointOfInterest;
        float timer;
        // Start is called before the first frame update


        // Update is called once per frame

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if(target.value== null)
            {
                timer += Time.deltaTime;
                if (timer ==0)
                {
                    pointOfInterest.value.transform.position = new Vector3(Random.Range(-100, 100), 2.72f, Random.Range(-100, 100));
                }
                if (timer > 10)
                {
                    timer=0;
                }
                    agent.value.SetDestination(pointOfInterest.value.transform.position);
                agent.value.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;

            }
            agent.value.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
            agent.value.SetDestination(target.value.transform.position);
          float dist = Vector3.Distance(agent.value.transform.position, target.value.transform.position);
            if (dist < 2.5F)
            {
                agent.value.transform.localScale += new Vector3(2, 2, 2);
                GameObject.Destroy(target.value);
            }

        }


	}
}