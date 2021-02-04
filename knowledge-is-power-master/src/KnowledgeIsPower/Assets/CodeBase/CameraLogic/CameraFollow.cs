﻿using System;
using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
      private Transform _following;
        public float RotationAngleX;
        public float Distance;
        public float OffsetY;

        private void LateUpdate()
        {
            if(_following == null)
              return;
            Quaternion rotation = Quaternion.Euler(RotationAngleX, 0, 0);
            var followingPosition = FollowingPointPosition();
            Vector3 position = rotation * new Vector3(0, 0, -Distance) + followingPosition;

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Following(GameObject follow) => _following = follow.transform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += OffsetY;
            return followingPosition;
        }
    }
}