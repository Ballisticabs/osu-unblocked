// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Textures;
using osu.Framework.Utils;
using osuTK;

namespace osu.Game.Graphics.Particles
{
    public class ParticleJet : ParticleSpewer
    {
        private const int particles_per_second = 80;
        private const double particle_lifetime = 500;
        private const float angular_velocity = 3f;
        private const int angle_spread = 10;
        private const float velocity_min = 1.3f;
        private const float velocity_max = 1.5f;

        private readonly int angle;

        protected override float ParticleGravity => 0.25f;

        public ParticleJet(Texture texture, int angle)
            : base(texture, particles_per_second, particle_lifetime)
        {
            this.angle = angle;
        }

        protected override FallingParticle SpawnParticle()
        {
            var directionRads = MathUtils.DegreesToRadians(
                RNG.NextSingle(angle - angle_spread / 2, angle + angle_spread / 2)
            );
            var direction = new Vector2(MathF.Sin(directionRads), MathF.Cos(directionRads));

            return new FallingParticle
            {
                StartTime = (float)Time.Current,
                Position = OriginPosition,
                Duration = RNG.NextSingle((float)particle_lifetime * 0.8f, (float)particle_lifetime),
                Velocity = direction * new Vector2(RNG.NextSingle(velocity_min, velocity_max)),
                AngularVelocity = RNG.NextSingle(-angular_velocity, angular_velocity),
                StartScale = 1f,
                EndScale = 2f,
            };
        }
    }
}
