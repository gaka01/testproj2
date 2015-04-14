using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

using OpenTK.Input;

namespace MusicalInvaders
{
    class GameLogic
    {
        public List<Object> objects = new List<Object>();
        public int ticktime;
        public EventHandler handler = new EventHandler();
        public long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        public long oldTime;

        public GameLogic(int ttime) // load data and init
        {
            this.ticktime = ttime;
            this.oldTime = this.curTime;
            this.objects.Add(new Object(1, new Texture("Data/Textures/ship1.png"), 1f, 1.7f, 0.5f, 0.3f, 10f));
        }



        public void tick() // game loop
        {
            while (true)
            {
                this.curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                if (this.oldTime + ticktime < this.curTime)
                {
                    foreach (Object obj in this.objects)
                    {
                        obj.move();
                        if (!isLegalPosition(obj))
                        {
                            obj.unmove();
                        }
                    }
                    this.oldTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                }
                this.handler.tick();
            }
        }

        public bool isLegalPosition(Object obj) // to be changed
        {
            if (obj.x >= obj.width / 2f && obj.x <= 2-obj.width/2f && obj.y >= -1f && obj.y <= 2-obj.height/2f)
            {
                return true;
            }
            return false;
        }
    }
}
