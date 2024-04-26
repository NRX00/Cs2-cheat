using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Cs2_multi
{
    public class Entity
    {
        public IntPtr addres {  get; set; }

        public int healt { get; set; }

        public int teamNum { get; set; }

        public int  jumpFlag { get; set; }

        public float magnitude { get; set; }

        public float angleDiffrence { get; set; }

        public Vector3 origin { get; set; }

        public Vector3 viewOffset { get; set; }

        public Vector3 abs { get; set; }

        public Vector2 originScreenPosition {  get; set; }

        public Vector2 absScreenPosition { get; set; }




    }
}
