using ClickableTransparentOverlay;
using ImGuiNET;
using Swed64;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;


namespace Cs2_multi
{
    class Program : Overlay
    {


        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);


        [DllImport("user32.dll")]


        static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

        [StructLayout(LayoutKind.Sequential)]

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public RECT GetWindowRect(IntPtr hWnd)
        {
            RECT rect = new RECT();
            GetWindowRect(hWnd, out rect);
            return rect;
        }


              Swed swed = new Swed("cs2");
              Offsets offset = new Offsets();
              ImDrawListPtr drawList;

              Entity localplayer = new Entity();
              List<Entity> entities = new List<Entity>();
              List<Entity> enemyTeam = new List<Entity>();
              List<Entity> playerTeam = new List<Entity>();



        IntPtr client;

        const int AİMBOT_HOTKEY = 0x01;

        Vector3 offsetsVector = new Vector3(0, 0, 10);


        //global colors

        Vector4 teamColor = new Vector4(0, 0, 1, 1);// RGBA,blue teammates
        Vector4 enemyColor = new Vector4(1,0,0,1); // enemes red
        Vector4 healthBarColor = new Vector4 (0,1,0,1);// green
        Vector4 healthTextColor = new Vector4(0,0,0,1);// black


        Vector2 windowsLocation = new Vector2(0, 0);
        Vector2 windowSize = new Vector2(1920, 1080);
        Vector2 lineOrgin = new Vector2(1920 / 2, 1080);
        Vector2 windowCenter = new Vector2(1920 / 2, 1080 / 2);

        bool enableEsp = true;
        bool anebleAimbot = true;

        bool enableTeamLine = true;
        bool enableTeamBox = true;
        bool enableTeamDot = false;
        bool enableTeamHealtBar = true;
        bool enableTeamHealtDistance = true;
        

        bool enableEnemyLİne = true;
        bool enableEnemyBox = true;
        bool enableEnemyDot = false;
        bool enableEnemyHealtBar = true;
        bool enableEnemyDistance = true;



    
        protected override void Render()
        {
            DrawMenu();
            DrawOverlay();
            Esp();
            Aimbot();
            ImGui.End();
        }

        void Aimbot()
        {
            if (GetAsyncKeyState(AİMBOT_HOTKEY) < 0 && anebleAimbot) 
            {
                if (enemyTeam.Count > 0)
                {
                    var angles = CalculateAngles(localplayer.origin, Vector3.Subtract(enemyTeam[0].origin, offsetsVector));
                    AimAt(angles);
                }
            }
        }

        void AimAt(Vector3 angles)
        {
            swed.WriteFloat(client, offset.viewAngles, angles.Y);
            swed.WriteFloat(client, offset.viewAngles + 0x04, angles.X);
        }

        Vector3 CalculateAngles(Vector3 from , Vector3 destintion)
        {
            float yaw;
            float pitch;



            float deltaX = destintion.X - from.X;
            float deltaY = destintion.Y - from.Y;
            yaw = (float)(Math.Atan2(deltaY, deltaX) * 180 / Math.PI);



            float deltaZ = destintion.Z - from.Z;
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            pitch = -(float)(Math.Atan2(deltaZ, distance) * 180 / Math.PI);


            return new Vector3(yaw, pitch, 0);

        }

        float CalculateMagnitude(Vector3 v1 , Vector3 v2 ) 
        {
            return (float)Math.Sqrt(Math.Pow(v2.X - v1.X, 2) + Math.Pow(v2.Y - v1.Y, 2) + Math.Pow(v2.Z - v1.Z, 2));
        } 

        void Esp()
        {
            drawList = ImGui.GetWindowDrawList();

            if (enableEsp)
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        if (entity.teamNum == localplayer.teamNum)
                        {
                            DrawVisual(entity, teamColor, enableTeamLine, enableTeamBox, enableTeamDot, enableTeamHealtBar, enableTeamHealtDistance);
                        }
                        else
                        {
                            DrawVisual(entity, enemyColor, enableEnemyLİne, enableEnemyBox, enableEnemyDot, enableEnemyHealtBar, enableEnemyDistance);
                        }
                    }
                }
                catch (Exception)
                {

                    
                }
            }
        }


        void DrawVisual(Entity entity, Vector4 color, bool line , bool box, bool dot, bool healthBar, bool distance)
        {
            if (IsPixelInsideScreen(entity.originScreenPosition))
            {


                uint uintColor = ImGui.ColorConvertFloat4ToU32(color);
                uint uintHealthTextColor = ImGui.ColorConvertFloat4ToU32(healthTextColor);
                uint uinyHealtBarColor = ImGui.ColorConvertFloat4ToU32(healthBarColor);

                
                Vector2 boxWitdh = new Vector2((entity.originScreenPosition.Y - entity.absScreenPosition.Y) / 2, 0f);
                Vector2 boxStart = Vector2.Subtract(entity.absScreenPosition, boxWitdh);
                Vector2 boxEnd = Vector2.Add(entity.originScreenPosition, boxWitdh);

                float barParcent = entity.healt / 100f;
                Vector2 barHeight = new Vector2(0, barParcent * (entity.originScreenPosition.Y - entity.absScreenPosition.Y));
                Vector2 barStart = Vector2.Subtract(Vector2.Subtract(entity.originScreenPosition, boxWitdh), barHeight);
                Vector2 barEnd = Vector2.Subtract(entity.originScreenPosition, Vector2.Add(boxWitdh, new Vector2(-4, 0)));



                if (line)
                {
                    drawList.AddLine(lineOrgin, entity.originScreenPosition, uintColor, 3);
                }
                if (box)
                {
                    drawList.AddRect(boxStart, boxEnd, uintColor, 3);
                }
                if (dot)
                {
                    drawList.AddCircleFilled(entity.originScreenPosition, 5, uintColor);
                }
                if (healthBar)
                {
                    drawList.AddText(entity.originScreenPosition, uintHealthTextColor, $"hp:  {entity.healt}");

                    drawList.AddRectFilled(barStart, barEnd, uinyHealtBarColor);
                }

            }
        }

        bool IsPixelInsideScreen(Vector2 pixel)
        {
            return pixel.X > windowsLocation.X && pixel.X < windowsLocation.X + windowSize.X && pixel.Y > windowsLocation.Y && pixel.Y <windowSize.Y + windowsLocation.Y;
        }

        ViewMatrix ReadMatrix(IntPtr matrixAdress) 
        {
            var viewMatrix = new ViewMatrix();
            var floatMatrix = swed.ReadMatrix(matrixAdress);

            viewMatrix.m11 = floatMatrix[0];
            viewMatrix.m12 = floatMatrix[1];
            viewMatrix.m13 = floatMatrix[2];
            viewMatrix.m14 = floatMatrix[3];

            viewMatrix.m21 = floatMatrix[4];
            viewMatrix.m22 = floatMatrix[5];
            viewMatrix.m23 = floatMatrix[6];
            viewMatrix.m24 = floatMatrix[7];

            viewMatrix.m31 = floatMatrix[8];
            viewMatrix.m32 = floatMatrix[9];
            viewMatrix.m33 = floatMatrix[10];
            viewMatrix.m34 = floatMatrix[11];
            
            viewMatrix.m41 = floatMatrix[12];
            viewMatrix.m42 = floatMatrix[13];
            viewMatrix.m43 = floatMatrix[14];
            viewMatrix.m44 = floatMatrix[15];

            return viewMatrix;
        }

        Vector2 WorldToScreen(ViewMatrix matrix, Vector3 pos , int width, int height)
        {
            Vector2 screenCoordinates = new Vector2();


            float screenW = (matrix.m41 * pos.X) + (matrix.m42 * pos.Y) + (matrix.m43 * pos.Z) + matrix.m44;

            if (screenW >0.001f)
            {
                float screenX =  (matrix.m11 * pos.X) + (matrix.m12 * pos.Y) + (matrix.m13 * pos.Z) + matrix.m14;

                float screenY = (matrix.m21 * pos.X) + (matrix.m22 * pos.Y) + (matrix.m23 * pos.Z) + matrix.m24;

                float camX = width / 2;
                float camY = height / 2;


                float X = camX + (camX * screenX / screenW);
                float Y = camY - (camY * screenY / screenW);
                

                screenCoordinates.X = X;
                screenCoordinates.Y = Y;
                return screenCoordinates;
            }
            else
            {
                return  new Vector2(-99, -99);
            }
        }


        void DrawMenu()
        {
            ImGui.Begin("Counter-Strike 2 Multi Cheat");

            if (ImGui.BeginTabBar("Tabs"))
            {
                if (ImGui.BeginTabItem("General"))
                {
                    ImGui.Checkbox("Esp", ref enableEsp);
                    ImGui.Checkbox("AimBot", ref anebleAimbot);
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("Colors"))
                {
                    ImGui.ColorPicker4("Team Color", ref teamColor);
                    ImGui.Checkbox("Team Lİne", ref enableTeamLine);
                    ImGui.Checkbox("Team Box", ref  enableTeamBox);
                    ImGui.Checkbox("Team dot", ref enableTeamDot);
                    ImGui.Checkbox("Team HealthBar", ref enableTeamHealtBar);

                     ImGui.ColorPicker4("Enemy Color", ref enemyColor);
                    ImGui.Checkbox("Enemy Lİne", ref enableEnemyLİne);
                    ImGui.Checkbox("Enemy Box", ref  enableEnemyBox);
                    ImGui.Checkbox("Enemy dot", ref enableEnemyDot);
                    ImGui.Checkbox("Enemy HealthBar", ref enableEnemyHealtBar);
                    ImGui.EndTabItem();

                }
            }
            ImGui.EndTabBar();
        }

        void DrawOverlay()
        {
            ImGui.SetNextWindowSize(windowSize);
            ImGui.SetNextWindowPos(windowsLocation);
            ImGui.Begin("overlay", ImGuiWindowFlags.NoDecoration
                | ImGuiWindowFlags.NoBackground
                | ImGuiWindowFlags.NoBringToFrontOnFocus
                | ImGuiWindowFlags.NoMove
                | ImGuiWindowFlags.NoInputs
                | ImGuiWindowFlags.NoCollapse
                | ImGuiWindowFlags.NoScrollbar
                | ImGuiWindowFlags.NoScrollWithMouse
                );
        }

        void Mainlogic()
        {
            

            var window = GetWindowRect(swed.GetProcess().MainWindowHandle);
            windowsLocation = new Vector2(window.left, window.top);
            windowSize = Vector2.Subtract(new Vector2(window.right, window.bottom), windowsLocation);
            lineOrgin = new Vector2(windowsLocation.X + windowSize.X/2,window.bottom);
            windowCenter = new Vector2(lineOrgin.X, window.bottom - windowSize.Y /2);

            client = swed.GetModuleBase("client.dll");



            while (true)
            {
              
                ReloadEntities();
                Thread.Sleep(3);


            }

           
        }

        void ReloadEntities()
        {


            entities.Clear();
            playerTeam.Clear();
            enemyTeam.Clear();
            localplayer.addres = swed.ReadPointer(client, offset.localPlayer);
            UpdateEntity(localplayer);

            UpadateEtities();

            enemyTeam = enemyTeam.OrderBy(o => o.magnitude).ToList();

        }

        void UpadateEtities()
        {
            for (int i = 0; i < 64; i++)
            {
                IntPtr tempEntityAddres = swed.ReadPointer(client,offset.entityList + i * 0x08);
                if (tempEntityAddres == IntPtr.Zero)
                    continue;
                


                Entity entity = new Entity();
                entity.addres = tempEntityAddres;

                UpdateEntity(entity);

                if (entity.healt < 1 || entity.healt > 100)
                    continue;

                if (!entities.Any(element => element.origin.X == entity.origin.X))
                {
                    entities.Add(entity);

                    if (entity.teamNum == localplayer.teamNum)
                    {
                        playerTeam.Add(entity);
                    }
                    else
                    {
                        playerTeam.Add(entity);
                    }
                } 

                

            }
        }


        void UpdateEntity(Entity entity)
        {
 

            entity.origin = swed.ReadVec(entity.addres, offset.origin);
            entity.viewOffset = new Vector3(0, 0, 65);
            entity.abs = Vector3.Add(entity.origin, entity.viewOffset);





            var currentviewmatrix = ReadMatrix(client + offset.viewMatrix);
            entity.originScreenPosition = Vector2.Add(WorldToScreen(currentviewmatrix, entity.origin, (int)windowSize.X, (int)windowSize.Y), windowsLocation);
            entity.absScreenPosition = Vector2.Add(WorldToScreen(currentviewmatrix, entity.abs, (int)windowSize.X, (int)windowSize.Y), windowsLocation);




            entity.healt = swed.ReadInt(entity.addres, offset.health);
            entity.origin = swed.ReadVec(entity.addres, offset.origin);
            entity.teamNum = swed.ReadInt(entity.addres, offset.teamNum);
            entity.magnitude = CalculateMagnitude(localplayer.origin, entity.origin);
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            program.Start().Wait();

            Thread mainLogic = new Thread(program.Mainlogic) { IsBackground = true };
            mainLogic.Start();

        }

    }


}