﻿namespace SpotEngine
{
    public abstract class Controller
    {
        public Entity entity { get; set; }

        private bool initialized = false;

        public void InitializeOnce()
        {
            if (!initialized)
            {
                Init();
                initialized = true;
            }
        }

        public abstract void Init();
        public abstract void Flow(float deltaTime);
    }
}


