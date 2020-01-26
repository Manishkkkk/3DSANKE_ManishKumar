using System.Collections.Generic;
using UnityEngine;

namespace Core.Snake
{

    public interface IBody
    {
        List<Transform> BodyPart { get; }
    }
}