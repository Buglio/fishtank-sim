using System;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

namespace fishtank
{
    public class Boid : MonoBehaviour
    {
        // Instance variables
        public TankManager tank;
        public Vector2 velocity = new Vector2();
        public Vector2 acceleration = new Vector2();

        public float maxForce = 0.1f;
        public int maxSpeed = 5;
        public int perception = 100;

        private void Awake()
        {
            tank = TankManager.Instance;
            
            if (!tank.BoidsInTank.Contains(this))
                tank.BoidsInTank.Add(this);
        }

        public void Update()
        {
            Edges();
            ApplyBehavior(TankManager.Instance.BoidsInTank);
            
            // update position
            this.transform.position += (Vector3)velocity;
            
            // update velocity
            velocity += acceleration;
            
            // limit speed
            if (velocity.magnitude > maxSpeed)
                velocity = velocity.normalized * maxSpeed;
            
            // reset acceleration
            acceleration = new Vector2();
        }
        
        public void ApplyBehavior(List<Boid> boids)
        {
            var alignment = Align(boids);
            var cohesion = Cohesion(boids);
            var separation = Separation(boids);
            
            acceleration += alignment;
            acceleration += cohesion;
            acceleration += separation;
            
        }

        public void Edges()
        {
            // bind the movement to the screen bounds
            {}
        }

        public Vector2 Align(List<Boid> boids)
        {
            var steering = new Vector2();
            var total = 0; // amount of boids in perception range
            var averageVector = new Vector2();

            foreach (var boid in boids)
            {
                if ((boid.transform.position - this.transform.position).magnitude < perception)
                {
                    averageVector += boid.velocity;
                    total++;
                }
                
                if (total > 0)
                {
                    averageVector /= total;
                    averageVector = new Vector2(averageVector.x, averageVector.y); // TODO: Sus
                    averageVector *= averageVector.normalized * maxSpeed;
                    steering = averageVector - velocity;
                }
            }
            
            return steering;
        }

        private Vector2 Cohesion(List<Boid> boids)
        {
            var steering = new Vector2();
            var total = 0; // amount of boids in perception range
            var centerOfMass = new Vector2();

            foreach (var boid in boids)
            {
                if (!((boid.transform.position - this.transform.position).magnitude < perception)) continue;
                
                centerOfMass += (Vector2) this.transform.position;
                total++;
            }

            if (total <= 0) return steering;
            
            centerOfMass /= total;
            centerOfMass = new Vector2(centerOfMass.x, centerOfMass.y); // TODO: Sus
            var toCenterOfMassVector = centerOfMass - (Vector2)this.transform.position;
                
            if (toCenterOfMassVector.magnitude > 0)
            {
                toCenterOfMassVector = toCenterOfMassVector.normalized * maxSpeed;
            }
            steering = toCenterOfMassVector - velocity; // TODO: sus - should this be in the above if statement?
                
            if (steering.magnitude > maxForce)
            {
                steering = steering.normalized * maxForce;
            }

            return steering;
        }

        private Vector2 Separation(List<Boid> boids)
        {
            var steering = new Vector2();
            var total = 0; // amount of boids in perception range
            var averageVector = new Vector2();
            
            foreach (var boid in boids)
            {
                var distance = (boid.transform.position - this.transform.position).magnitude;

                if (this.transform.position == boid.transform.position || !(distance < perception)) continue;
                
                var diff = (Vector2)(this.transform.position - boid.transform.position);
                diff /= distance;
                averageVector += diff;
                total++;
            }

            if (total <= 0) return steering;
            
            averageVector /= total;
            averageVector = new Vector2(averageVector.x, averageVector.y); // TODO: Sus
                
            if (averageVector.magnitude > 0)
                averageVector *= averageVector.normalized * maxSpeed;
            steering = averageVector - velocity;
                
            if (steering.magnitude > maxForce)
                steering = steering.normalized * maxForce;

            return steering;
        }
    }
}
