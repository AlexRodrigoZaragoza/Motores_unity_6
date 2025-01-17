using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RangeDetector", story: "Update [Range_Detector] & asign [Target]", category: "Action", id: "b3223ad4543de71eb73dd8b093e6f79e")]
public partial class RangeDetectorAction : Action
{
    [SerializeReference] public BlackboardVariable<RangeDetector> Range_Detector;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    protected override Status OnUpdate()
    {
        Target.Value = Range_Detector.Value.UpdateDetector();
        return Target.Value == null ? Status.Failure : Status.Success;
    }

}

