using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input; 

namespace MusicalInvaders
{
    class EventHandler
    {
        private KeyboardState keyboard;
        private KeyboardState oldkeyboard;
        public GameLogic logic;

        public EventHandler()
        {
            this.keyboard = OpenTK.Input.Keyboard.GetState();
            this.oldkeyboard = this.keyboard;
        }

        public void tick()
        {
            this.updateKeyboard();
            if (this.keyPressed(Key.Left))
            {
                this.logic.objects[0].speedx = this.logic.objects[0].speed * (-1);
            }

            if (this.keyPressed(Key.Right))
            {
                this.logic.objects[0].speedx = this.logic.objects[0].speed;
            }

            if (this.keyRelesed(Key.Left) && this.logic.objects[0].speedx == this.logic.objects[0].speed*(-1))
            {
                this.logic.objects[0].speedx = 0f;
            }

            if (this.keyRelesed(Key.Right) && this.logic.objects[0].speedx == this.logic.objects[0].speed)
            {
                this.logic.objects[0].speedx = 0f;
            }

            if (this.keyRelesed(Key.Up) && this.logic.objects[0].speedy == this.logic.objects[0].speed * (-1))
            {
                this.logic.objects[0].speedy = 0f;
            }

            if (this.keyRelesed(Key.Down) && this.logic.objects[0].speedy == this.logic.objects[0].speed)
            {
                this.logic.objects[0].speedy = 0f;
            }

            if (this.keyPressed(Key.Up))
            {
                this.logic.objects[0].speedy = this.logic.objects[0].speed * (-1);
            }

            if (this.keyPressed(Key.Down))
            {
                this.logic.objects[0].speedy = this.logic.objects[0].speed;
            }
        }

        public void setLogicRef(ref GameLogic logic)
        {
            this.logic = logic;
        }

        //public void setKeyboard(KeyboardState keyboard)
        //{
        //    this.oldkeyboard = this.keyboard;
        //    this.keyboard = keyboard;
        //}

        public void updateKeyboard()
        {
            this.oldkeyboard = this.keyboard;
            this.keyboard = OpenTK.Input.Keyboard.GetState();
        }

        private bool keyPressed(Key key)
        {
            if (this.keyboard[key] && !this.oldkeyboard[key])
            {
                return true;
            }
            return false;
        }

        private bool keyRelesed(Key key)
        {
            if (!this.keyboard[key] && this.oldkeyboard[key])
            {
                return true;
            }
            return false;
        }

        private bool keyIsPressed(Key key)
        {
            if (this.keyboard[key])
            {
                return true;
            }
            return false;
        }
    }
}
