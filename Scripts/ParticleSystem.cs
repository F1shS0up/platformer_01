using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


public class ParticleSystem
{
    private Random random;
    public Vector2 EmitterLocation { get; set; }
    public List<Particle> particles;
    private List<Texture2D> textures;
    public Color color;
    Vector2 velocityIncrease;

    public ParticleSystem(List<Texture2D> textures, Vector2 location, Color pColor, Vector2 pVelocityIncrease)
    {
        EmitterLocation = location;
        this.textures = textures;
        this.particles = new List<Particle>();
        random = new Random();
        color = pColor;
        velocityIncrease = pVelocityIncrease;
    }

    public void Update(GameTime gameTime)
    {
        int total = 10;

      /*  for (int i = 0; i < total; i++)
        {
            particles.Add(GenerateNewParticle());
        }*/

        for (int particle = 0; particle < particles.Count; particle++)
        {
            particles[particle].Update(gameTime);
            if (particles[particle].TTL <= 0)
            {
                particles.RemoveAt(particle);
                particle--;
            }
        }
    }
    public void LoadMoreParticles(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            particles.Add(GenerateNewParticle());
        }
    }

    public Particle GenerateNewParticle()
    {
        Texture2D texture = textures[random.Next(textures.Count)];
        Vector2 position = EmitterLocation;
        Vector2 velocity = new Vector2(
                                (float)((float)(random.NextDouble() * 2 - 1)) * velocityIncrease.X,
                                (float)((float)(-random.NextDouble() - 1)) * velocityIncrease.Y);
        float angle = 0;
        float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
       
        float size = (float)random.NextDouble();
        int ttl = 20 + random.Next(40);

        return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        
        for (int index = 0; index < particles.Count; index++)
        {
            particles[index].Draw(spriteBatch);
        }
        
    }
}
