using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Data.Save.Scripts
{
    using System;

    [Serializable]
    public struct PlayerTrasmforSaveData
    {
        public Vector3 playerPosition;
        public Quaternion playerRotation;
    }
}
