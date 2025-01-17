using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Line of Sight Check", story: "Check [Target] with [LineOfShightDetector]", category: "Conditions", id: "ba838637439b91a1d460426e53109957")]
public partial class LineOfSightCheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<LineOfSightDetector> LineOfShightDetector;

    public override bool IsTrue()
    {
        return LineOfShightDetector.Value.PerformDetection(Target.Value) == null; // esto no esta bien pero no afecta
    }
}
