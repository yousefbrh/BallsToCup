using Lean.Touch;
using UnityEngine;

namespace Components
{
    public class OrbitalMovement : MonoBehaviour
    {
        [SerializeField] private Transform centerTransform;
        [SerializeField] private MovementAxis movementAxis;
        [SerializeField] private TouchType touchType;
        [SerializeField] private float movementSpeedForUnity;
        [SerializeField] private float movementSpeedForExport;

        [SerializeField] private bool hasRotationLimit;
        [SerializeField] private float minLimitedAngel;
        [SerializeField] private float maxLimitedAngel;

        [SerializeField] private bool hasStartingPosition;

        [SerializeField] private Transform startingPositionTransform;
    
        private float _currentAngle;
        private float _deltaRotation;
        private bool _canMove;

        private void Start()
        {
            InitializeLean();
            SetupStartingPosition();
        }

        private void InitializeLean()
        {
            LeanTouch.OnFingerDown += ActivateMovement;
            LeanTouch.OnFingerUp += DeactivateMovement;
            LeanTouch.OnFingerUpdate += OrbitalMove;
        }

        private void SetupStartingPosition()
        {
            if (hasStartingPosition)
                transform.position = startingPositionTransform.position;
        }

        //In case that you want to initialize variables with script
        public void Initialize(Transform centerTransform)
        {
            this.centerTransform = centerTransform;
        }

        public void ActivateMovement(LeanFinger leanFinger)
        {
            _canMove = true;
        }

        public void DeactivateMovement(LeanFinger leanFinger)
        {
            _canMove = false;
        }

        //Main function for orbital movement
        public void OrbitalMove(LeanFinger leanFinger)
        {
            if (!_canMove) return;

            var screenDeltaAxisValue = GetScreenDeltaAxisValue(leanFinger);
        
            _deltaRotation = screenDeltaAxisValue * GetMovementSpeed() * Time.deltaTime;
        
            var newRotation = _currentAngle + _deltaRotation;

            CheckLimitAngle(newRotation);

            _currentAngle += _deltaRotation;
            
            var centerPosition = centerTransform.position;
        
            var axisForRotation = GetAxisForRotation();
        
            transform.RotateAround(centerPosition, axisForRotation, _deltaRotation);
        }

        private float GetMovementSpeed()
        {
#if UNITY_EDITOR
            return movementSpeedForUnity;
#else
            return movementSpeedForExport;
#endif
        }

        private void CheckLimitAngle(float newRotation)
        {
            if (hasRotationLimit)
                LimitAngle(newRotation);
            else
                NoAngleLimitation(newRotation);
        }

        private void NoAngleLimitation(float newRotation)
        {
            if (newRotation > 360) _currentAngle -= 360;
            if (newRotation < -360) _currentAngle -= -360;
        }

        private void LimitAngle(float newRotation)
        {
            if (newRotation > maxLimitedAngel) _deltaRotation = maxLimitedAngel - _currentAngle;
            if (newRotation < minLimitedAngel) _deltaRotation = minLimitedAngel - _currentAngle;
        }

        private float GetScreenDeltaAxisValue(LeanFinger leanFinger)
        {
            return leanFinger.ScreenDelta.magnitude * CoefficientHandler(leanFinger);
        }

        private int CoefficientHandler(LeanFinger leanFinger)
        {
            var screenSize = leanFinger.ScreenPosition;
            var screenDelta = leanFinger.ScreenDelta;
            if (screenSize.x < Screen.width / 2 && screenSize.y < Screen.height / 2)
            {
                if (screenDelta.x < 0 && screenDelta.y > 0)
                    return 1;
                if (screenDelta.x > 0 && screenDelta.y < 0)
                    return -1;
                if (screenDelta.y > screenDelta.x)
                    return 1;
                return -1;
            }
            if (screenSize.x < Screen.width / 2 && screenSize.y > Screen.height / 2)
            {
                if (screenDelta.x < 0 && screenDelta.y < 0)
                    return -1;
                if (screenDelta.x > 0 && screenDelta.y > 0)
                    return 1;
                if (screenDelta.x + screenDelta.y > 0)
                    return 1;
                return -1;
            }
            if (screenSize.x > Screen.width / 2 && screenSize.y > Screen.height / 2)
            {
                if (screenDelta.x < 0 && screenDelta.y > 0)
                    return -1;
                if (screenDelta.x > 0 && screenDelta.y < 0)
                    return 1;
                if (screenDelta.y > screenDelta.x)
                    return -1;
                return 1;
            }
            if (screenSize.x > Screen.width / 2 && screenSize.y < Screen.height / 2)
            {
                if (screenDelta.x < 0 && screenDelta.y < 0)
                    return 1;
                if (screenDelta.x > 0 && screenDelta.y > 0)
                    return -1;
                if (screenDelta.x + screenDelta.y > 0)
                    return -1;
                return 1;
            }
            
            return 0;
        }

        private Vector3 GetAxisForRotation()
        {
            return movementAxis switch
            {
                MovementAxis.X => -Vector3.right,
                MovementAxis.Y => -Vector3.up,
                MovementAxis.Z => -Vector3.forward,
                _ => -Vector3.up
            };
        }
    
        private enum MovementAxis
        {
            X,
            Y,
            Z
        }
    
        private enum TouchType
        {
            UpToDown,
            RightToLeft
        }

        private void OnDestroy()
        {
            LeanTouch.OnFingerDown -= ActivateMovement;
            LeanTouch.OnFingerUp -= DeactivateMovement;
            LeanTouch.OnFingerUpdate -= OrbitalMove;
        }
    }
}
