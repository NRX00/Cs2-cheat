using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs2_multi
{
    public class Offsets
    {
        //client Offsets

        public int viewAngles = 0x192F940;
        public int viewMatrix = 0x19231B0;
        public int localPlayer = 0x1911578;
        public int entityList = 0x18C1DB8;



        // entity Offsets
        public int teamNum = 0x3CB;
        public int jumpFlag = 0x63;
        public int health = 0x334;
        public int origin = 0X80;


    }
}
