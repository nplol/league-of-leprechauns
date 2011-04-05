using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor
{
    class Display : GraphicsDeviceControl
    {
        internal event EventHandler OnInitialize;
        internal event EventHandler OnDraw;

        protected override void Initialize()
        {
            if (OnInitialize != null)
                OnInitialize(this, null);
        }

        protected override void Draw()
        {
            if (OnDraw != null)
                OnDraw(this, null);
        }
    }
}
