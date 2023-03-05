using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GTA5_VH.SigScan;
using static GTA5_VH.Tasks;
using static GTA5_VH.Bools;
using static GTA5_VH.Globals;
using static GTA5_VH.GetAddress;
using static GTA5_VH.Vehicle;
using static GTA5_VH.Player;
using static GTA5_VH.AiHandling;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using System.Diagnostics;

namespace GTA5_VH
{
    public partial class VH : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        Point dragCursorPoint;
        Point dragFormPoint;
        public VH()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            CheckForIllegalCrossThreadCalls = false;
            Thread shm = new Thread(ShowHideMenu);
            shm.Start();
            var T = "";
            Task.Run(async () =>
            {
                while (true)
                {
                    if (GTA_PROCESS != null)
                    {
                        if (GTA_PROCESS.HasExited)
                        {
                            GTA_PROCESS = null;
                            IsProcessOpen = false;
                        }
                    }
                    AttemptOpenProcess();
                    RainbowXenon_Loop();
                    RainbowCar_Loop();
                    RainbowTireSmoke_Loop();
                    CarRainbowNeon_Loop();
                    T = IsProcessOpen ? MemLib.mProc.Process.ProcessName.ToString() + " Loaded !" : "Please Open GTA V !";
                    if (ConnectionText.Text != T)
                        ConnectionText.Text = T;
                    ConnectionText.ForeColor = IsProcessOpen ? Color.Green : Color.Red;
                    await Task.Delay(100);
                }
            });
        }
        void ShowHideMenu()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.Insert) < 0 && showing == true) //HIDE
                {
                    this.Hide();
                    Process[] p = Process.GetProcessesByName("GTA5");
                    if (p.Length > 0)
                    {
                        SetForegroundWindow(p[0].MainWindowHandle);
                    }
                    showing = false;
                    Thread.Sleep(20);
                }
                else if (GetAsyncKeyState(Keys.Insert) < 0 && showing == false) // SHOW
                {
                    this.Show();
                    Cursor.Position = new Point(this.Location.X + this.Size.Width / 2, this.Location.Y + this.Size.Height / 2);
                    SetForegroundWindow(this.Handle);
                    this.Activate();
                    this.Focus();
                    showing = true;
                    Thread.Sleep(20);
                }
                else if (GetAsyncKeyState(Keys.Delete) < 0) // UNLOAD
                {
                    Environment.Exit(0);
                    Application.Exit();
                }
                Thread.Sleep(70);
            }
        }
        private void VH_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void VH_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void VH_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }
        private void GetHandling_Click(object sender, EventArgs e)
        {
            tbmass.Text = MemLib.ReadFloat(CHandlingData + "+" + mass).ToString("F4");
            tbsuspension_force.Text = MemLib.ReadFloat(CHandlingData + "+" + suspension_force).ToString("F4");
            tbupshift.Text = MemLib.ReadFloat(CHandlingData + "+" + upshift).ToString("F4");
            tbdownshift.Text = MemLib.ReadFloat(CHandlingData + "+" + downshift).ToString("F4");
            tbsuspension_raise.Text = MemLib.ReadFloat(CHandlingData + "+" + suspension_raise).ToString("F4");
            tbsuspension_lower_limit.Text = MemLib.ReadFloat(CHandlingData + "+" + suspension_lower_limit).ToString("F4");
            tbsuspension_upper_limit.Text = MemLib.ReadFloat(CHandlingData + "+" + suspension_upper_limit).ToString("F4");
            tbsuspension_rebound_damp.Text = MemLib.ReadFloat(CHandlingData + "+" + suspension_rebound_damp).ToString("F4");
            tbsuspension_comp_damp.Text = MemLib.ReadFloat(CHandlingData + "+" + suspension_comp_damp).ToString("F4");
            tbroll_centre_height_rear.Text = MemLib.ReadFloat(CHandlingData + "+" + roll_centre_height_rear).ToString("F4");
            tbtraction_loss_mult.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_loss_mult).ToString("F4");
            tbcamber_stiffness.Text = MemLib.ReadFloat(CHandlingData + "+" + camber_stiffness).ToString("F4");
            tbtraction_bias_rear.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_bias_rear).ToString("F4");
            tbtraction_bias_front.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_bias_front).ToString("F4");
            tbanti_rollbar_bias_rear.Text = MemLib.ReadFloat(CHandlingData + "+" + anti_rollbar_bias_rear).ToString("F4");
            tbroll_centre_height_front.Text = MemLib.ReadFloat(CHandlingData + "+" + roll_centre_height_front).ToString("F4");
            tbbrake_force.Text = MemLib.ReadFloat(CHandlingData + "+" + brake_force).ToString("F4");
            tbhandbrake_force.Text = MemLib.ReadFloat(CHandlingData + "+" + handbrake_force).ToString("F4");
            tbbrake_bias_front.Text = MemLib.ReadFloat(CHandlingData + "+" + brake_bias_front).ToString("F4");
            tbbrake_bias_rear.Text = MemLib.ReadFloat(CHandlingData + "+" + brake_bias_rear).ToString("F4");
            tbsteering_lock.Text = MemLib.ReadFloat(CHandlingData + "+" + steering_lock).ToString("F4");
            tbsteering_lock_ratio.Text = MemLib.ReadFloat(CHandlingData + "+" + steering_lock_ratio).ToString("F4");
            tbtraction_curve_max.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_curve_max).ToString("F4");
            tbtraction_curve_lateral.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_curve_lateral).ToString("F4");
            tbtraction_curve_min.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_curve_min).ToString("F4");
            tbtraction_curve_ratio.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_curve_ratio).ToString("F4");
            tbcurve_lateral.Text = MemLib.ReadFloat(CHandlingData + "+" + curve_lateral).ToString("F4");
            tbcurve_lateral_ratio.Text = MemLib.ReadFloat(CHandlingData + "+" + curve_lateral_ratio).ToString("F4");
            tbbuoyancy.Text = MemLib.ReadFloat(CHandlingData + "+" + buoyancy).ToString("F4");
            tbanti_rollbar_force.Text = MemLib.ReadFloat(CHandlingData + "+" + anti_rollbar_force).ToString("F4");
            tbanti_rollbar_bias_front.Text = MemLib.ReadFloat(CHandlingData + "+" + anti_rollbar_bias_front).ToString("F4");
            tbinitial_drag_coeff.Text = MemLib.ReadFloat(CHandlingData + "+" + initial_drag_coeff).ToString("F4");
            tbdownforce_multiplier.Text = MemLib.ReadFloat(CHandlingData + "+" + downforce_multiplier).ToString("F4");
            tbpopup_light_rotation.Text = MemLib.ReadFloat(CHandlingData + "+" + popup_light_rotation).ToString("F4");
            tblow_speed_traction_loss_mult.Text = MemLib.ReadFloat(CHandlingData + "+" + low_speed_traction_loss_mult).ToString("F4");
            tbtraction_spring_delta_max_ratio.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_spring_delta_max_ratio).ToString("F4");
            tbtraction_spring_delta_max.Text = MemLib.ReadFloat(CHandlingData + "+" + traction_spring_delta_max).ToString("F4");
            tbdrive_bias_rear.Text = MemLib.ReadFloat(CHandlingData + "+" + drive_bias_rear).ToString("F4");
            tbdrive_bias_front.Text = MemLib.ReadFloat(CHandlingData + "+" + drive_bias_front).ToString("F4");
            tbacceleration.Text = MemLib.ReadFloat(CHandlingData + "+" + acceleration).ToString("F4");
            tbdrive_inertia.Text = MemLib.ReadFloat(CHandlingData + "+" + drive_inertia).ToString("F4");
            tbinitial_drive_force.Text = MemLib.ReadFloat(CHandlingData + "+" + initial_drive_force).ToString("F4");
            tbdrive_max_flat_velocity.Text = MemLib.ReadFloat(CHandlingData + "+" + drive_max_flat_velocity).ToString("F4");
            tbinitial_drive_max_flat_vel.Text = MemLib.ReadFloat(CHandlingData + "+" + initial_drive_max_flat_vel).ToString("F4");
            tbsuspension_bias_front.Text = MemLib.ReadFloat(CHandlingData + "+" + suspension_bias_front).ToString("F4");
            tbsuspension_bias_rear.Text = MemLib.ReadFloat(CHandlingData + "+" + suspension_bias_rear).ToString("F4");
            tbgravity.Text = MemLib.ReadFloat(CVehicle + "+" + vehicle_gravity_).ToString("F4");
            tbcolldmgmult.Text = MemLib.ReadFloat(CHandlingData + "+" + collision_damage_mult).ToString("F4");
            tbweapon_damage_mult.Text = MemLib.ReadFloat(CHandlingData + "+" + weapon_damage_mult).ToString("F4");
            tbdeformation_mult.Text = MemLib.ReadFloat(CHandlingData + "+" + deformation_mult).ToString("F4");
            tbengine_damage_mult.Text = MemLib.ReadFloat(CHandlingData + "+" + engine_damage_mult).ToString("F4");
            tbpetrol_tank_volume.Text = MemLib.ReadFloat(CHandlingData + "+" + petrol_tank_volume).ToString("F4");
            tboil_volume.Text = MemLib.ReadFloat(CHandlingData + "+" + oil_volume).ToString("F4");
            tbvehicle_headlightmult_.Text = MemLib.ReadFloat(CVehicle + "+" + vehicle_headlightmult_).ToString("F4");         
            tbvehicle_boost_recharge_.Text = MemLib.ReadFloat(CVehicle + "+" + vehicle_boost_recharge_).ToString("F4");
            tbvehicle_color1_r_.Text = MemLib.ReadByte(CVehicleVisual + "+" + vehicle_color1_r_).ToString("F0");
            tbvehicle_color1_g_.Text = MemLib.ReadByte(CVehicleVisual + "+" + vehicle_color1_g_).ToString("F0");
            tbvehicle_color1_b_.Text = MemLib.ReadByte(CVehicleVisual + "+" + vehicle_color1_b_).ToString("F0");
            tbvehicle_color2_r_.Text = MemLib.ReadByte(CVehicleVisual + "+" + vehicle_color2_r_).ToString("F0");
            tbvehicle_color2_g_.Text = MemLib.ReadByte(CVehicleVisual + "+" + vehicle_color2_g_).ToString("F0");
            tbvehicle_color2_b_.Text = MemLib.ReadByte(CVehicleVisual + "+" + vehicle_color2_b_).ToString("F0");
            tbvehicle_tiresmoke_r_.Text = MemLib.ReadByte(CVehicleDrawHandler + "+" + vehicle_tiresmoke_r_).ToString("F0");
            tbvehicle_tiresmoke_g_.Text = MemLib.ReadByte(CVehicleDrawHandler + "+" + vehicle_tiresmoke_g_).ToString("F0");
            tbvehicle_tiresmoke_b_.Text = MemLib.ReadByte(CVehicleDrawHandler + "+" + vehicle_tiresmoke_b_).ToString("F0");
            tbvehicle_neon_r_.Text = MemLib.ReadByte(CVehicleDrawHandler + "+" + vehicle_neon_r_).ToString("F0");
            tbvehicle_neon_g_.Text = MemLib.ReadByte(CVehicleDrawHandler + "+" + vehicle_neon_g_).ToString("F0");
            tbvehicle_neon_b_.Text = MemLib.ReadByte(CVehicleDrawHandler + "+" + vehicle_neon_b_).ToString("F0");
            tbvehicle_xenon_.Text = MemLib.ReadByte(CVehicleDrawHandler + "+" + vehicle_xenon_).ToString("F0");
            tbvehicle_xenoncolor_.Text = MemLib.ReadByte(CVehicleDrawHandler + "+" + vehicle_xenoncolor_).ToString("F0");
        }
        private void SetHandling_Click(object sender, EventArgs e)
        {      
            string[] values = { tbmass.Text, tbsuspension_force.Text, tbupshift.Text, tbdownshift.Text, tbsuspension_raise.Text, tbsuspension_lower_limit.Text, tbsuspension_upper_limit.Text, tbsuspension_rebound_damp.Text, tbsuspension_comp_damp.Text, tbroll_centre_height_rear.Text, tbtraction_loss_mult.Text, tbcamber_stiffness.Text, tbtraction_bias_rear.Text, tbtraction_bias_front.Text, tbanti_rollbar_bias_rear.Text, tbroll_centre_height_front.Text, tbbrake_force.Text, tbhandbrake_force.Text, tbbrake_bias_front.Text, tbbrake_bias_rear.Text, tbsteering_lock.Text, tbsteering_lock_ratio.Text, tbtraction_curve_max.Text, tbtraction_curve_lateral.Text, tbtraction_curve_min.Text, tbtraction_curve_ratio.Text, tbcurve_lateral.Text, tbcurve_lateral_ratio.Text, tbbuoyancy.Text, tbanti_rollbar_force.Text, tbanti_rollbar_bias_front.Text, tbinitial_drag_coeff.Text, tbdownforce_multiplier.Text, tbpopup_light_rotation.Text, tblow_speed_traction_loss_mult.Text, tbtraction_spring_delta_max_ratio.Text, tbtraction_spring_delta_max.Text, tbdrive_bias_rear.Text, tbdrive_bias_front.Text, tbacceleration.Text, tbdrive_inertia.Text, tbinitial_drive_force.Text, tbdrive_max_flat_velocity.Text, tbinitial_drive_max_flat_vel.Text, tbsuspension_bias_front.Text, tbsuspension_bias_rear.Text, tbcolldmgmult.Text, tbweapon_damage_mult.Text, tbdeformation_mult.Text, tbengine_damage_mult.Text, tbpetrol_tank_volume.Text, tboil_volume.Text };
            string[] offsets = { mass, suspension_force, upshift, downshift, suspension_raise, suspension_lower_limit, suspension_upper_limit, suspension_rebound_damp, suspension_comp_damp, roll_centre_height_rear, traction_loss_mult, camber_stiffness, traction_bias_rear, traction_bias_front, anti_rollbar_bias_rear, roll_centre_height_front, brake_force, handbrake_force, brake_bias_front, brake_bias_rear, steering_lock, steering_lock_ratio, traction_curve_max, traction_curve_lateral, traction_curve_min, traction_curve_ratio, curve_lateral, curve_lateral_ratio, buoyancy, anti_rollbar_force, anti_rollbar_bias_front, initial_drag_coeff, downforce_multiplier, popup_light_rotation, low_speed_traction_loss_mult, traction_spring_delta_max_ratio, traction_spring_delta_max, drive_bias_rear, drive_bias_front, acceleration, drive_inertia, initial_drive_force, drive_max_flat_velocity, initial_drive_max_flat_vel, suspension_bias_front, suspension_bias_rear, collision_damage_mult, weapon_damage_mult, deformation_mult, engine_damage_mult, petrol_tank_volume, oil_volume };
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != "")
                    MemLib.WriteMemory(CHandlingData + "+" + offsets[i], "float", values[i]);
                
            }
            MemLib.WriteMemory(CVehicle + "+" + vehicle_gravity_, "float", tbgravity.Text);
            MemLib.WriteMemory(CVehicle + "+" + vehicle_headlightmult_, "float", tbvehicle_headlightmult_.Text);
            MemLib.WriteMemory(CVehicle + "+" + vehicle_boost_recharge_, "float", tbvehicle_boost_recharge_.Text);
            MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color1_r_, new byte[] { byte.Parse(tbvehicle_color1_r_.Text) });
            MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color1_g_, new byte[] { byte.Parse(tbvehicle_color1_g_.Text) });
            MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color1_b_, new byte[] { byte.Parse(tbvehicle_color1_b_.Text) });
            MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color2_r_, new byte[] { byte.Parse(tbvehicle_color2_r_.Text) });
            MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color2_g_, new byte[] { byte.Parse(tbvehicle_color2_g_.Text) });
            MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color2_b_, new byte[] { byte.Parse(tbvehicle_color2_b_.Text) });
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_tiresmoke_r_, new byte[] { byte.Parse(tbvehicle_tiresmoke_r_.Text) });
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_tiresmoke_r_, new byte[] { byte.Parse(tbvehicle_tiresmoke_g_.Text) });
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_tiresmoke_r_, new byte[] { byte.Parse(tbvehicle_tiresmoke_b_.Text) });
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_neon_r_, new byte[] { byte.Parse(tbvehicle_neon_r_.Text) });
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_neon_g_, new byte[] { byte.Parse(tbvehicle_neon_g_.Text) });
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_neon_b_, new byte[] { byte.Parse(tbvehicle_neon_b_.Text) });
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_xenon_, new byte[] { byte.Parse(tbvehicle_xenon_.Text) });
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_xenoncolor_, new byte[] { byte.Parse(tbvehicle_xenoncolor_.Text) });
        }
        private void SaveHandling_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Handling File saved to Desktop/VehicleHandler/HandlingData/xxxx "        
            );
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\VehicleHandler\HandlingData\", "Handling*.txt");
            int maxFileNumber = 0;
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                int fileNumber = int.Parse(fileName.Replace("Handling", ""));
                if (fileNumber > maxFileNumber)
                    maxFileNumber = fileNumber;
            }
            maxFileNumber++;
            StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\VehicleHandler\HandlingData\" + tbConfigName.Text + ".txt");
            writer.WriteLine("---------------");
            writer.WriteLine("Vehicle Handler Configuration File (this file can be shared with other Vehicle Handler user :)");
            writer.WriteLine("------------------------------------------------------");
            writer.WriteLine("------------------------------------------------------");
            writer.WriteLine("------------------------------------------------------");
            writer.WriteLine("Config Name: " + tbConfigName.Text);
            writer.WriteLine("------------------------------------------------------");
            writer.WriteLine("VEHICLE HANDLING DATA");
            writer.WriteLine("------------------------------------------------------");
            writer.WriteLine("Mass: " + tbmass.Text);
            writer.WriteLine("Suspension Force: " + tbsuspension_force.Text);
            writer.WriteLine("Upshift: " + tbupshift.Text);
            writer.WriteLine("Downshift: " + tbdownshift.Text);
            writer.WriteLine("Suspension Raise: " + tbsuspension_raise.Text);
            writer.WriteLine("Suspension Lower Limit: " + tbsuspension_lower_limit.Text);
            writer.WriteLine("Suspension Upper Limit: " + tbsuspension_upper_limit.Text);
            writer.WriteLine("Suspension Rebound Damp: " + tbsuspension_rebound_damp.Text);
            writer.WriteLine("Suspension Comp Damp: " + tbsuspension_comp_damp.Text);
            writer.WriteLine("Roll Centre Height Rear: " + tbroll_centre_height_rear.Text);
            writer.WriteLine("Traction Loss Mult: " + tbtraction_loss_mult.Text);
            writer.WriteLine("Camber Stiffness: " + tbcamber_stiffness.Text);
            writer.WriteLine("Traction Bias Rear: " + tbtraction_bias_rear.Text);
            writer.WriteLine("Traction Bias Front: " + tbtraction_bias_front.Text);
            writer.WriteLine("Anti Rollbar Bias Rear: " + tbanti_rollbar_bias_rear.Text);
            writer.WriteLine("Roll Centre Height Front: " + tbroll_centre_height_front.Text);
            writer.WriteLine("Brake Force: " + tbbrake_force.Text);
            writer.WriteLine("Handbrake Force: " + tbhandbrake_force.Text);
            writer.WriteLine("Brake Bias Front: " + tbbrake_bias_front.Text);
            writer.WriteLine("Brake Bias Rear: " + tbbrake_bias_rear.Text);
            writer.WriteLine("Steering Lock: " + tbsteering_lock.Text);
            writer.WriteLine("Steering Lock Ratio: " + tbsteering_lock_ratio.Text);
            writer.WriteLine("Traction Curve Max: " + tbtraction_curve_max.Text);
            writer.WriteLine("Traction Curve Lateral: " + tbtraction_curve_lateral.Text);
            writer.WriteLine("Traction Curve Min: " + tbtraction_curve_min.Text);
            writer.WriteLine("Traction Curve Ratio: " + tbtraction_curve_ratio.Text);
            writer.WriteLine("Curve Lateral: " + tbcurve_lateral.Text);
            writer.WriteLine("Curve Lateral Ratio: " + tbcurve_lateral_ratio.Text);
            writer.WriteLine("Buoyancy: " + tbbuoyancy.Text);
            writer.WriteLine("Anti Rollbar Force: " + tbanti_rollbar_force.Text);
            writer.WriteLine("Anti Rollbar Bias Front: " + tbanti_rollbar_bias_front.Text);
            writer.WriteLine("Initial Drag Coeff: " + tbinitial_drag_coeff.Text);
            writer.WriteLine("Downforce Multiplier: " + tbdownforce_multiplier.Text);
            writer.WriteLine("Popup Light Rotation: " + tbpopup_light_rotation.Text);
            writer.WriteLine("Low Speed Traction Loss Mult: " + tblow_speed_traction_loss_mult.Text);
            writer.WriteLine("Traction Spring Delta Max Ratio: " + tbtraction_spring_delta_max_ratio.Text);
            writer.WriteLine("Traction Spring Delta Max: " + tbtraction_spring_delta_max.Text);
            writer.WriteLine("Drive Bias Rear: " + tbdrive_bias_rear.Text);
            writer.WriteLine("Drive Bias Front: " + tbdrive_bias_front.Text);
            writer.WriteLine("Acceleration: " + tbacceleration.Text);
            writer.WriteLine("Drive Inertia: " + tbdrive_inertia.Text);
            writer.WriteLine("Initial Drive Force: " + tbinitial_drive_force.Text);
            writer.WriteLine("Drive Max Flat Velocity: " + tbdrive_max_flat_velocity.Text);
            writer.WriteLine("Initial Drive Max Flat Vel: " + tbinitial_drive_max_flat_vel.Text);
            writer.WriteLine("Suspension Bias Front: " + tbsuspension_bias_front.Text);
            writer.WriteLine("Suspension Bias Rear: " + tbsuspension_bias_rear.Text);
            writer.WriteLine("Gravity: " + tbgravity.Text);
            writer.WriteLine("Collision Damage Multiplier: " + tbcolldmgmult.Text);
            writer.WriteLine("Weapon Damage Multiplier: " + tbweapon_damage_mult.Text);
            writer.WriteLine("Deformation Multiplier: " + tbdeformation_mult.Text);
            writer.WriteLine("Engine Damage Multiplier: " + tbengine_damage_mult.Text);
            writer.WriteLine("Petrol Tank Volume: " + tbpetrol_tank_volume.Text);
            writer.WriteLine("Oil Volume: " + tboil_volume.Text);
            writer.WriteLine("Headlight Multiplier: " + tbvehicle_headlightmult_.Text);
            writer.WriteLine("Vehicle Color R1: " + tbvehicle_color1_r_.Text);
            writer.WriteLine("Vehicle Color G1: " + tbvehicle_color1_g_.Text);
            writer.WriteLine("Vehicle Color B1: " + tbvehicle_color1_b_.Text);
            writer.WriteLine("Vehicle Color R2: " + tbvehicle_color2_r_.Text);
            writer.WriteLine("Vehicle Color G2: " + tbvehicle_color2_g_.Text);
            writer.WriteLine("Vehicle Color B2: " + tbvehicle_color2_b_.Text);
            writer.WriteLine("Neon Color R: " + tbvehicle_neon_r_.Text);
            writer.WriteLine("Neon Color G: " + tbvehicle_neon_g_.Text);
            writer.WriteLine("Neon Color B: " + tbvehicle_neon_b_.Text);
            writer.WriteLine("Tire Smoke Color R: " + tbvehicle_tiresmoke_r_.Text);
            writer.WriteLine("Tire Smoke Color G: " + tbvehicle_tiresmoke_g_.Text);
            writer.WriteLine("Tire Smoke Color B: " + tbvehicle_tiresmoke_b_.Text);
            writer.WriteLine("Xenon Color (255 = NO COLOR) Colors start at 0-12: " + tbvehicle_xenoncolor_.Text);
            writer.WriteLine("Xenon (255 = OFF / 1 = ON): " + tbvehicle_xenon_.Text);         
            writer.WriteLine("Vehicle Boost Recharge: " + tbvehicle_boost_recharge_.Text);
            writer.Close();
        }

        private void LoadHandling_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\VehicleHandler\HandlingData\", "Handling*.txt");
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\VehicleHandler\HandlingData\",
                Filter = "Handling files (*.txt)|*.txt",
                FilterIndex = 0,
                RestoreDirectory = true,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                Dictionary<string, TextBox> handlingDataDict = new Dictionary<string, TextBox>
        {
            { "Config Name", tbConfigName },
            { "Mass", tbmass },
            { "Suspension Force", tbsuspension_force },
            { "Upshift", tbupshift },
            { "Downshift", tbdownshift },
            { "Suspension Raise", tbsuspension_raise },
            { "Suspension Lower Limit", tbsuspension_lower_limit },
            { "Suspension Upper Limit", tbsuspension_upper_limit },
            { "Suspension Rebound Damp", tbsuspension_rebound_damp },
            { "Suspension Comp Damp", tbsuspension_comp_damp },
            { "Roll Centre Height Rear", tbroll_centre_height_rear },
            { "Traction Loss Mult", tbtraction_loss_mult },
            { "Camber Stiffness", tbcamber_stiffness },
            { "Traction Bias Rear", tbtraction_bias_rear },
            { "Traction Bias Front", tbtraction_bias_front },
            { "Anti Rollbar Bias Rear", tbanti_rollbar_bias_rear },
            { "Roll Centre Height Front", tbroll_centre_height_front },
            { "Brake Force", tbbrake_force },
            { "Handbrake Force", tbhandbrake_force },
            { "Brake Bias Front", tbbrake_bias_front },
            { "Brake Bias Rear", tbbrake_bias_rear },
            { "Steering Lock", tbsteering_lock },
            { "Steering Lock Ratio", tbsteering_lock_ratio },
            { "Traction Curve Max", tbtraction_curve_max },
            { "Traction Curve Lateral", tbtraction_curve_lateral },
            { "Traction Curve Min", tbtraction_curve_min },
            { "Traction Curve Ratio", tbtraction_curve_ratio },
            { "Curve Lateral", tbcurve_lateral },
            { "Curve Lateral Ratio", tbcurve_lateral_ratio },
            { "Buoyancy", tbbuoyancy },
            { "Anti Rollbar Force", tbanti_rollbar_force },
            { "Anti Rollbar Bias Front", tbanti_rollbar_bias_front },
            { "Initial Drag Coeff", tbinitial_drag_coeff },
            { "Downforce Multiplier", tbdownforce_multiplier },
            { "Popup Light Rotation", tbpopup_light_rotation },
            { "Low Speed Traction Loss Mult", tblow_speed_traction_loss_mult },
            { "Traction Spring Delta Max Ratio", tbtraction_spring_delta_max_ratio },
            { "Traction Spring Delta Max", tbtraction_spring_delta_max },
            { "Drive Bias Rear", tbdrive_bias_rear },
            { "Drive Bias Front", tbdrive_bias_front },
            { "Acceleration", tbacceleration },
            { "Drive Inertia", tbdrive_inertia },
            { "Initial Drive Force", tbinitial_drive_force },
            { "Drive Max Flat Velocity", tbdrive_max_flat_velocity },
            { "Initial Drive Max Flat Vel", tbinitial_drive_max_flat_vel },
            { "Suspension Bias Front", tbsuspension_bias_front },
            { "Suspension Bias Rear", tbsuspension_bias_rear },
            { "Gravity", tbgravity },
            { "Collision Damage Multiplier", tbcolldmgmult },
            { "Weapon Damage Multiplier", tbweapon_damage_mult },
            { "Deformation Multiplier", tbdeformation_mult },
            { "Engine Damage Multiplier", tbengine_damage_mult },
            { "Petrol Tank Volume", tbpetrol_tank_volume },
            { "Oil Volume", tboil_volume },
            { "Headlight Multiplier", tbvehicle_headlightmult_ },
            { "Vehicle Color R1", tbvehicle_color1_r_ },
            { "Vehicle Color G1", tbvehicle_color1_g_ },
            { "Vehicle Color B1", tbvehicle_color1_b_ },
            { "Vehicle Color R2", tbvehicle_color2_r_ },
            { "Vehicle Color G2", tbvehicle_color2_g_ },
            { "Vehicle Color B2", tbvehicle_color2_b_ },
            { "Xenon Color (255 = NO COLOR) Colors start at 0-12", tbvehicle_xenoncolor_ },
            { "Xenon (255 = OFF / 1 = ON)", tbvehicle_xenon_ },
            { "Vehicle Boost Recharge", tbvehicle_boost_recharge_ },
            { "Neon Color R", tbvehicle_neon_r_ },
            { "Neon Color G", tbvehicle_neon_g_ },
            { "Neon Color B", tbvehicle_neon_b_ },
            { "Tire Smoke Color R", tbvehicle_tiresmoke_r_ },
            { "Tire Smoke Color G", tbvehicle_tiresmoke_g_ },
            { "Tire Smoke Color B", tbvehicle_tiresmoke_b_ }
        };

                while (reader.Peek() >= 0)
                {
                    string[] lineParts = reader.ReadLine().Split(':');
                    string name = lineParts[0].Trim();
                    string value = "";
                    if (lineParts.Length > 1)
                    {
                        value = lineParts[1].Trim();
                    }

                    if (handlingDataDict.ContainsKey(name))
                    {
                        handlingDataDict[name].Text = value;
                    }
                }

                reader.Close();
            }
        }
        private void EmtpyLobby_Click(object sender, EventArgs e)
        {
            Process process = Process.GetProcessesByName("GTA5")[0];
            process.Suspend();
            System.Threading.Thread.Sleep(10000);
            process.Resume();
        }
        private void RainbowCarBox_CheckedChanged(object sender, EventArgs e)
        {
            RainbowCarLooperEnabled();      
        }
        private void GMods_Tick(object sender, EventArgs e)
        {
            if (WeatherTimeBP.Checked)
            {
                MemLib.WriteMemory(TimeBaseAddress + "+104", "int", "1");
                MemLib.WriteMemory(TimeBPBaseAddress, "int", "1");
            }
            wanted_level = WantedCheckBox.Checked ? 0 : wanted_level;
        }
        private void VH_Load(object sender, EventArgs e)
        {
            GMods.Start();
        }
        private void SnowBox_CheckedChanged(object sender, EventArgs e)
        {
            Global_toggle_snow = SnowBox.Checked ? 1 : 0;
        }
        private void XenonLoopBox_CheckedChanged(object sender, EventArgs e)
        {
            RainbowXenonLooperEnabled();
            MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_xenon_, new byte[] { 1 });
        }
        private void TireSmokeLoopBox_CheckedChanged(object sender, EventArgs e)
        {
            RainbowTireSmokeLooperEnabled();
        }
        private void NeonLoopBox_CheckedChanged(object sender, EventArgs e)
        {
            RainbowNeonLooperEnabled();
        }
        private void PlayerGodmodeBox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleGodMode();
        }
        private void AutoHealBox_CheckedChanged(object sender, EventArgs e)
        {
            Thread VehicleAutoHeal = new Thread(() =>
            {
                while (AutoHealBox.Checked)
                {
                    MemLib.WriteMemory(CVehicle + "+" + vehicle_health1_, "float", "1000");
                    MemLib.WriteMemory(CVehicle + "+" + vehicle_health2_, "float", "1000");
                    MemLib.WriteMemory(CVehicle + "+" + vehicle_health3_, "float", "1000");
                    MemLib.WriteMemory(CVehicle + "+" + vehicle_health4_, "float", "1000");
                }
            });
            if (AutoHealBox.Checked)
            {
                VehicleAutoHeal.Start();
            }
        }
        private void AggressiveTraffic_Click(object sender, EventArgs e)
        {
            s_min_brake_distance = 1;
            s_max_brake_distance = 1;
            s_max_speed_at_brake_distance = 100;
            s_absolute_min_speed = 100;
            a_min_brake_distance = 1;
            a_max_brake_distance = 1;
            a_max_speed_at_brake_distance = 100;
            a_absolute_min_speed = 100;
            c_min_brake_distance = 1;
            c_max_brake_distance = 1;
            c_max_speed_at_brake_distance = 100;
            c_absolute_min_speed = 100;
            t_min_brake_distance = 1;
            t_max_brake_distance = 1;
            t_max_speed_at_brake_distance = 100;
            t_absolute_min_speed = 100;
        }
        private void RemoveTraffic_Click(object sender, EventArgs e)
        {
            s_max_brake_distance = 0;
            a_max_brake_distance = 0;
            c_max_brake_distance = 0;
            t_max_brake_distance = 0;
        }
        private void ResetTraffic_Click(object sender, EventArgs e)
        {
            //DEFAULT VALUES
            s_min_brake_distance = 10;
            s_max_brake_distance = 80;
            s_max_speed_at_brake_distance = 50;
            s_absolute_min_speed = 1;
            a_min_brake_distance = 10;
            a_max_brake_distance = 80;
            a_max_speed_at_brake_distance = 30;
            a_absolute_min_speed = 1;
            c_min_brake_distance = 10;
            c_max_brake_distance = 100;
            c_max_speed_at_brake_distance = 30;
            c_absolute_min_speed = 1;
            t_min_brake_distance = 10;
            t_max_brake_distance = 100;
            t_max_speed_at_brake_distance = 30;
            t_absolute_min_speed = 1;
        }

        private void TPHighway_Click(object sender, EventArgs e)
        {
            player_coord_x = -952;
            player_visual_coord_x = -952;
            player_coord_y = -571;
            player_visual_coord_y = -571;
            player_coord_z = 18;
            player_visual_coord_z = 18;
            vehicle_coord_x = -952;
            vehicle_coord_y = -571;
            vehicle_coord_z = 18;
        }

        private void TPLSC_Click(object sender, EventArgs e)
        {
            player_coord_x = -371;
            player_visual_coord_x = -371;
            player_coord_y = -130;
            player_visual_coord_y = -130;
            player_coord_z = 38;
            player_visual_coord_z = 38;
            vehicle_coord_x = -371;
            vehicle_coord_y = -130;
            vehicle_coord_z = 38;
        }

        private void RemoveWanted_Click(object sender, EventArgs e)
        {
            wanted_level = 0;
        }

        private void HealPlayer_Click(object sender, EventArgs e)
        {
            player_armor = 200;
            player_health = 328;
        }

        private void ChristmasHalloweenHorns_Click(object sender, EventArgs e)
        {
            Global_christmas_Horns = 1;
            Global_halloween_Horns = 1;
        }

        private void RocketBoost_Click(object sender, EventArgs e)
        {
            vehicle_extras = 64;
        }

        private void CarJMPRAMPPARA_Click(object sender, EventArgs e)
        {
            vehicle_extras = 864;
        }

        private void ResetCarMods_Click(object sender, EventArgs e)
        {
            vehicle_extras = 0;
        }

        private void Clock18_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(TimeBaseAddress + "+10", "int", "18");
            MemLib.WriteMemory(TimeBaseAddress + "+14", "int", "0");
        }

        private void Clock12_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(TimeBaseAddress + "+10", "int", "12");
            MemLib.WriteMemory(TimeBaseAddress + "+14", "int", "0");
        }

        private void Clock6_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(TimeBaseAddress + "+10", "int", "6");
            MemLib.WriteMemory(TimeBaseAddress + "+14", "int", "0");
        }

        private void Clock00_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(TimeBaseAddress + "+10", "int", "0");
            MemLib.WriteMemory(TimeBaseAddress + "+14", "int", "0");
        }

        private void WeatherRain_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "6");
        }

        private void WeatherSmog_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "3");
        }

        private void WeatherWindySnow_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "11");
        }

        private void WeatherThunder_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "7");
        }

        private void WeatherHalloween_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "14");
        }

        private void WeatherSunny_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "0");
        }

        private void WeatherClear_Click(object sender, EventArgs e)
        {
            MemLib.WriteMemory(WeatherBaseAddress + "+104", "int", "1");
        }

    }
}
