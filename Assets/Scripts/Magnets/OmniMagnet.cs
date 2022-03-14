using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaraGoLike
{
    public class OmniMagnet : MonoBehaviour
    {
        RaycastHit Lefthit;
        Ray Leftray; 
        RaycastHit Righthit;
        Ray Rightray; 
        RaycastHit Tophit;
        Ray Topray; 
        RaycastHit Backhit;
        Ray Backray;
      

        private void Start()
        {
            Leftray = new Ray(transform.position, Vector3.left);
            Rightray = new Ray(transform.position, Vector3.right);
            Topray = new Ray(transform.position, Vector3.forward);
            Backray = new Ray(transform.position, Vector3.back);
        }



        private void Update()
        {
            Debug.DrawRay(transform.position, Vector3.left, Color.red);
            Debug.DrawRay(transform.position, Vector3.right, Color.red);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);

            int layer_mask = LayerMask.GetMask("Default");
            if (Physics.Raycast(Leftray,out Lefthit, 1f, layer_mask,QueryTriggerInteraction.Ignore))
            {
                Train.instance.dir = 3;
            }
            if (Physics.Raycast(Rightray, out Righthit, 1f, layer_mask, QueryTriggerInteraction.Ignore))
            {
                Train.instance.dir = 2;
                
            }
            if (Physics.Raycast(Topray, out Tophit, 1f, layer_mask, QueryTriggerInteraction.Ignore))
            {
                Train.instance.dir = 0;
                
            }
            if (Physics.Raycast(Backray, out Backhit, 1f, layer_mask, QueryTriggerInteraction.Ignore))
            {
                Train.instance.dir = 1;
                
            }
        }
    }
}
