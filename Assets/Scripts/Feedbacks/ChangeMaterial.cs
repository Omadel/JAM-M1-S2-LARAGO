using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Etienne.Feedback;

namespace LaraGoLike
{
    [GameFeedback(224,125,12,"Change Material")]
    public class ChangeMaterial : Etienne.Feedback.GameFeedback
    {
        [SerializeField] private Material material;
        public override IEnumerator Execute(GameEvent gameEvent)
        {
            gameEvent.GameObject.GetComponent<MeshRenderer>().material = material;
            yield break;
        }
    }
}
