using System;
using System.Text;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Stimulsoft.Report;
using Telerik.WinControls.UI;



namespace Radman
{
    public partial class frmQuickCalc : Telerik.WinControls.UI.RadForm
    {
        private string FluidType;
        private int CurrentProjectIndex;
        /*Safety Gas Validation*/
        private bool Safety_Gas_MolecularWeightValidation;
        private bool Safety_Gas_KValidation;
        private bool Safety_Gas_ComperesibilityValidation;
        private bool Safety_Gas_RelievingValidation;
        private bool Safety_Gas_RequiredPressureFlowValidation;
        private bool Safety_Gas_SetPressureValidation;
        private bool Safety_Gas_OverPressureValidation;

        /*Safety Liquid Validation*/
        private bool Safety_Liquid_SpecificGravityValidation;
        private bool Safety_Liquid_ViscosityValidation;        
        private bool Safety_Liquid_RelievingValidation;
        private bool Safety_Liquid_RequiredPressureFlowValidation;
        private bool Safety_Liquid_SetPressureValidation;
        private bool Safety_Liquid_OverPressureValidation;

        /*Safety Steam Validation*/
        private bool Safety_Steam_MolecularWeightValidation;
        private bool Safety_Steam_KValidation;
        private bool Safety_Steam_ComperesibilityValidation;
        private bool Safety_Steam_RelievingValidation;
        private bool Safety_Steam_RequiredPressureFlowValidation;
        private bool Safety_Steam_SetPressureValidation;
        private bool Safety_Steam_OverPressureValidation;

        /*Safety 2-Phase-C22 Validation*/
        private bool Safety_2PhaseC22_V90Validation;
        private bool Safety_2PhaseC22_V1Validation;
        private bool Safety_2PhaseC22_RelievingValidation;
        private bool Safety_2PhaseC22_RequiredPressureFlowValidation;
        private bool Safety_2PhaseC22_SetPressureValidation;
        private bool Safety_2PhaseC22_OverPressureValidation;
        private bool Safety_2PhaseC22_KcValidation;
        private bool Safety_2PhaseC22_KvValidation;
        private bool Safety_2PhaseC22_KdValidation;

        /*Safety 2-Phase-C23 Validation*/
        private bool Safety_2PhaseC23_VaporPerssureValidation;
        private bool Safety_2PhaseC23_LiquidDensityValidation;
        private bool Safety_2PhaseC23_MixDensityValidation;
        private bool Safety_2PhaseC23_RelievingValidation;
        private bool Safety_2PhaseC23_RequiredPressureFlowValidation;
        private bool Safety_2PhaseC23_SetPressureValidation;
        private bool Safety_2PhaseC23_OverPressureValidation;
        private bool Safety_2PhaseC23_KcValidation;
        private bool Safety_2PhaseC23_KvValidation;
        private bool Safety_2PhaseC23_KdValidation;

        private string SelectedSeries;
        private string SelectedOrifice;
        private string SelectedCodeSection;
        private string AccessoriesCatalogNumber = "________________________";
        private string ConfigureCatalogNumber = "_________________________";
        private string TempConfigureCatalogNumber = "_________________________";
        private string SelectedValveType;
        private string SelectedOrificeArea;
        private string SelectedFlowCapacity;
        private string Formule2Phase;
        private string ReactionForceUnit;
        private string Selected_A;
        private string ClassA, ClassB;

        public frmQuickCalc(int ProjectId, string TagNomber)
        {            
            CurrentProjectIndex = Program.ProjectList.FindIndex(item => item.Id == ProjectId);
            Program.CurrentProjectSelectedIndex = CurrentProjectIndex;
            InitializeComponent();                        
        }

        public frmQuickCalc(int ProjectId, string TagNumber,string Client,string P_ID,string Service,string Line,string Quantity,string EndUserRef,string ProjectRef,string Project,string RadmanRef,string Location,Telerik.WinControls.UI.RadGridView NewField)
        {           
            CurrentProjectIndex = Program.ProjectList.FindIndex(item => item.Id == ProjectId);
            Program.CurrentProjectSelectedIndex = CurrentProjectIndex;
            InitializeComponent();
        }

        public frmQuickCalc(int ProjectListIndex)
        {
            CurrentProjectIndex = ProjectListIndex;
            Program.CurrentProjectSelectedIndex = CurrentProjectIndex;
            InitializeComponent();
            
        }

        private void LoadProjectToForm()
        {
            try
            {
                object sender = null;
                EventArgs e = null;
                switch (Program.ProjectList[CurrentProjectIndex].Fluid_Type)
                {

                    case "":
                        pageMain.SelectedPage = pageCalculationType;
                        break;
                    case "Gas/Vapor":
                        btnSafetyGasAsmeSec8_Click(sender, e);
                        break;
                    case "Liquid":
                        btnSafetyLiquidAsmeSec8_Click(sender, e);
                        break;
                    case "Steam":
                        btnSafetySteemAsmeSec1_Click(sender, e);
                        break;
                    case "2-Phase":
                        int f_index = Program.ProjectList[CurrentProjectIndex].Standard_Type.IndexOf("C.2.2");
                        if (f_index != -1)
                        {
                            Formule2Phase = "C22";
                            btnSafety2PhaseC22_Click(sender, e);
                        }
                        else
                        {
                            Formule2Phase = "C23";
                            btnSafety2PhaseC23_Click(sender, e);
                        }
                        break;
                }
                /*
                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageCalculationType")
                {
                    pageMain.SelectedPage = pageCalculationType;

                }
                else if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageSizingSelection")
                {
                    pageMain.SelectedPage = pageSizingSelection;
                    pageCalculationType.Image = Image.FromFile(Program.ImagesPath + "CalculationTypeOff.png");
                    pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionOn.png");
                    pageSizingSelection.Enabled = true;
                }
                else if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageConfiguration")
                    pageMain.SelectedPage = pageConfiguration;
                else if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageReports")
                    pageMain.SelectedPage = pageReports;
                if (Program.ProjectList[CurrentProjectIndex].Fluid_Name != "")
                {
                    if(Program.ProjectList[CurrentProjectIndex].Fluid_Type == "Gas")
                    {

                    }
                }
                */
            }
            catch
            {
                
            }
        }        

        private void frmQuickCalc_Load(object sender, EventArgs e)
        {
            try
            {
                pageMain.ViewElement.Items[4].Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                kgcm2a.Text = "kg/cm² a";
                lbft2a.Text = "lb/ft² a";
                ozin2a.Text = "oz/in² a";

                radMenuItem72.Text = "kg/cm² a";
                radMenuItem74.Text = "lb/ft² a";
                radMenuItem80.Text = "oz/in² a";

                SystemMAWP_kgcm2g.Text = "kg/cm² g";
                SystemMAWP_lbft2g.Text = "lb/ft² g";
                SystemMAWP_ozin2g.Text = "oz/in² g";

                radMenuItem99.Text = "kg/cm² g";
                radMenuItem101.Text = "lb/ft² g";
                radMenuItem107.Text = "oz/in² g";

                OperatingPressure_kgcm2g.Text = "kg/cm² g";
                OperatingPressure_lbft2g.Text = "lb/ft² g";
                OperatingPressure_ozin2g.Text = "oz/in² g";

                SetPressure_kgcm2g.Text = "kg/cm² g";
                SetPressure_lbft2g.Text = "lb/ft² g";
                SetPressure_ozin2g.Text = "oz/in² g";

                OverPressure_kgcm2g.Text = "kg/cm² g";
                OverPressure_lbft2g.Text = "lb/ft² g";
                OverPressure_ozin2g.Text = "oz/in² g";

                BuiltUp_kgcm2g.Text = "kg/cm² g";
                BuiltUp_lbft2g.Text = "lb/ft² g";
                BuiltUp_ozin2g.Text = "oz/in² g";

                ConstantSuperimposed_kgcm2g.Text = "kg/cm² g";
                ConstantSuperimposed_lbft2g.Text = "lb/ft² g";
                ConstantSuperimposed_ozin2g.Text = "oz/in² g";

                VaribleSuperimposed_kgcm2g.Text = "kg/cm² g";
                VaribleSuperimposed_lbft2g.Text = "lb/ft² g";
                VaribleSuperimposed_ozin2g.Text = "oz/in² g";

                TotalBackPressure_kgcm2g.Text = "kg/cm² g";
                TotalBackPressure_lbft2g.Text = "lb/ft² g";
                TotalBackPressure_ozin2g.Text = "oz/in² g";

                InletLoss_kgcm2g.Text = "kg/cm² g";
                InletLoss_lbft2g.Text = "lb/ft² g";
                InletLoss_ozin2g.Text = "oz/in² g";

                mnuCm2.Text = "cm²";
                mnuIn2.Text = "in²";
                mnuMm2.Text = "mm²";

                cm2s.Text = "cm²/s";
                ft2s.Text = "ft²/s";
                in2s.Text = "in²/s";
                lbfsft2.Text = "lbf.s/ft²";
                m2s.Text = "m²/s";
                mm2s.Text = "mm²/s";
                Nsm2.Text = "N.s/m²";

                btnRelievingTemp.Text = "°C";
                btnDesignMaxTemp.Text = "°C";
                btnDesignMinTemp.Text = "°C";
                btnOperatingTemp.Text = "°C";
                btnNormalSystemTemp.Text = "°C";

                mnuCelsius.Text = "°C";
                mnuKelvin.Text = "°K";
                mnuFahrenheit.Text = "°F";
                mnuRankine.Text = "°R";

                radMenuItem84.Text = "°C";
                radMenuItem85.Text = "°K";
                radMenuItem86.Text = "°F";
                radMenuItem87.Text = "°R";
                cmbInletTempUnit.Text = "°C";

                radMenuItem1.Text = "°C";
                radMenuItem2.Text = "°K";
                radMenuItem3.Text = "°F";
                radMenuItem4.Text = "°R";

                radMenuItem5.Text = "°C";
                radMenuItem6.Text = "°K";
                radMenuItem7.Text = "°F";
                radMenuItem8.Text = "°R";

                radMenuItem9.Text = "°C";
                radMenuItem10.Text = "°K";
                radMenuItem11.Text = "°F";
                radMenuItem12.Text = "°R";

                radMenuItem13.Text = "°C";
                radMenuItem14.Text = "°K";
                radMenuItem15.Text = "°F";
                radMenuItem16.Text = "°R";

                Nm3day.Text = "Nm³/day";
                Nm3hr.Text = "Nm³/hr";
                Nm3min.Text = "Nm³/min";
                Nm3s.Text = "Nm³/s";

                Sm3hr.Text = "Sm³/hr";
                Sm3min.Text = "Sm³/min";

                ft3day.Text = "ft³/day";
                ft3hr.Text = "ft³/hr";
                ft3min.Text = "ft³/min";
                ft3s.Text = "ft³/s";

                m3day.Text = "m³/day";
                m3hr.Text = "m³/hr";
                m3min.Text = "m³/min";
                m3s.Text = "m³/s";

                m3_hr.Text = "m³/hr";
                ft3_hr.Text = "ft³/hr";
                nm3_hr.Text = "Nm³/hr";
                sft3_hr.Text = "Sft³/hr";

                ft3day_Liquid.Text = "ft³/day";
                ft3hr_Liquid.Text = "ft³/hr";
                ft3min_Liquid.Text = "ft³/min";
                ft3s_Liquid.Text = "ft³/s";

                m3day_Liquid.Text = "m³/day";
                m3hr_Liquid.Text = "m³/hr";
                m3min_Liquid.Text = "m³/min";
                m3s_Liquid.Text = "m³/s";

                kgm3.Text = "kg/m³";
                lbft3.Text = "lb/ft³";
                ft3lb.Text = "ft³/lb";
                m3kg.Text = "m³/kg";

                radMenuItem88.Text = "kg/m³";
                radMenuItem94.Text = "lb/ft³";
                radMenuItem89.Text = "kg/m³ STP";
                radMenuItem90.Text = "kg/m³ NTP";
                radMenuItem95.Text = "lb/ft³ STP";
                radMenuItem96.Text = "lb/ft³ NTP";
                btnDensityControlUnit.Text = "kg/m³";

                ft3lb_v90.Text = "ft³/lb";
                m3kg_v90.Text = "m³/kg";
                ft3lb_vinlet.Text = "ft³/lb";
                m3kg_vinlet.Text = "m³/kg";
                btnSpecificValumeUnit.Text = "ft³/lb";
                btnV90.Text = "ft³/lb";
                btnVinletUnit.Text = "ft³/lb";
                btnLiquidSpecificUnit.Text = "ft³/lb";
                btnSpVol90Unit.Text = "ft³/lb";

                radMenuItem30.Text = "kg/cm² a";
                radMenuItem32.Text = "lb/ft² a";
                radMenuItem55.Text = "oz/in² a";

                radMenuItem63.Text = "kg/m³";
                radMenuItem64.Text = "lb/ft³";

                radMenuItem58.Text = "ft³/lb";
                radMenuItem61.Text = "m³/kg";

                radMenuItem21.Text = "kg/m³";
                radMenuItem23.Text = "lb/ft³";

                radMenuItem17.Text = "ft³/lb";
                radMenuItem20.Text = "m³/kg";

                btnOrificesAreaUnit.Text = mnuIn2.Text;
                this.Text = Program.ProjectList[CurrentProjectIndex].Tag_No;
                pageMain.ViewElement.ShowItemCloseButton = false;
                pageMain.ViewElement.ShowHorizontalLine = false;
                SetTemperatureUnit();
                SetPressuresUnit();
                SetPressureFlowUnit();
                SetViscosityUnit();
                SetFlowCapacityUnit();
                Set2PhaseUnit();
                if (Program.ProjectList[CurrentProjectIndex].TableId == "")
                {
                    pageMain.SelectedPage = pageCalculationType;
                    btnSafetyValve.Select();
                }
                else
                    LoadProjectToForm();
            }
            catch
            {

            }
        }

        private void Set2PhaseUnit()
        {
            try
            {
                kgm3.Click += Kgm3_Click;
                kgl.Click += Kgm3_Click;
                lbft3.Click += Kgm3_Click;
                lbgal_us.Click += Kgm3_Click;

                ft3lb.Click += Ft3lb_Click;
                gallb.Click += Ft3lb_Click;
                lkg.Click += Ft3lb_Click;
                m3kg.Click += Ft3lb_Click;

                ft3lb_v90.Click += Ft3lb_v90_Click;
                Gallb_v90.Click += Ft3lb_v90_Click;
                lkg_v90.Click += Ft3lb_v90_Click;
                m3kg_v90.Click += Ft3lb_v90_Click;

                ft3lb_vinlet.Click += Ft3lb_vinlet_Click;
                gallb_vinlet.Click += Ft3lb_vinlet_Click;
                lkg_vinlet.Click += Ft3lb_vinlet_Click;
                m3kg_vinlet.Click += Ft3lb_vinlet_Click;

                kgday_vapor.Click += Kgday_vapor_Click;
                kghr_vapor.Click += Kgday_vapor_Click;
                kgmin_vapor.Click += Kgday_vapor_Click;
                kgs_vapor.Click += Kgday_vapor_Click;
                lbday_vapor.Click += Kgday_vapor_Click;
                lbhr_vapor.Click += Kgday_vapor_Click;
                lbmin_vapor.Click += Kgday_vapor_Click;
                lbs_vapor.Click += Kgday_vapor_Click;
                tonlongday_vapor.Click += Kgday_vapor_Click;
                tonlonghr_vapor.Click += Kgday_vapor_Click;
                tonlongs_vapor.Click += Kgday_vapor_Click;
                tonday_vapor.Click += Kgday_vapor_Click;
                tonhr_vapor.Click += Kgday_vapor_Click;
                tons_vapor.Click += Kgday_vapor_Click;
                tonmtday_vapor.Click += Kgday_vapor_Click;
                tonmthr_vapor.Click += Kgday_vapor_Click;
                tonmts_vapor.Click += Kgday_vapor_Click;

                kgday_liquid_2phase.Click += Kgday_vapor_Click;
                kghr_liquid_2phase.Click += Kgday_vapor_Click;
                kgmin_liquid_2phase.Click += Kgday_vapor_Click;
                kgs_liquid_2phase.Click += Kgday_vapor_Click;
                lbday_liquid_2phase.Click += Kgday_vapor_Click;
                lbhr_liquid_2phase.Click += Kgday_vapor_Click;
                lbmin_liquid_2phase.Click += Kgday_vapor_Click;
                lbs_liquid_2phase.Click += Kgday_vapor_Click;
                tonlongday_liquid_2phase.Click += Kgday_vapor_Click;
                tonlonghr_liquid_2phase.Click += Kgday_vapor_Click;
                tonlongs_liquid_2phase.Click += Kgday_vapor_Click;
                tonday_liquid_2phase.Click += Kgday_vapor_Click;
                tonhr_liquid_2phase.Click += Kgday_vapor_Click;
                tons_liquid_2phase.Click += Kgday_vapor_Click;
                tonmtday_liquid_2phase.Click += Kgday_vapor_Click;
                tonmthr_liquid_2phase.Click += Kgday_vapor_Click;
                tonmts_liquid_2phase.Click += Kgday_vapor_Click;

                radMenuItem34.Click += Kgday_vapor_Click;
                radMenuItem35.Click += Kgday_vapor_Click;
                radMenuItem36.Click += Kgday_vapor_Click;
                radMenuItem37.Click += Kgday_vapor_Click;
                radMenuItem38.Click += Kgday_vapor_Click;
                radMenuItem39.Click += Kgday_vapor_Click;
                radMenuItem40.Click += Kgday_vapor_Click;
                radMenuItem41.Click += Kgday_vapor_Click;
                radMenuItem42.Click += Kgday_vapor_Click;
                radMenuItem43.Click += Kgday_vapor_Click;
                radMenuItem44.Click += Kgday_vapor_Click;
                radMenuItem45.Click += Kgday_vapor_Click;
                radMenuItem46.Click += Kgday_vapor_Click;
                radMenuItem47.Click += Kgday_vapor_Click;
                radMenuItem48.Click += Kgday_vapor_Click;
                radMenuItem49.Click += Kgday_vapor_Click;
                radMenuItem50.Click += Kgday_vapor_Click;

                radMenuItem25.Click += RadMenuItem25_Click;
                radMenuItem26.Click += RadMenuItem25_Click;
                radMenuItem27.Click += RadMenuItem25_Click;
                radMenuItem28.Click += RadMenuItem25_Click;
                radMenuItem29.Click += RadMenuItem25_Click;
                radMenuItem30.Click += RadMenuItem25_Click;
                radMenuItem31.Click += RadMenuItem25_Click;
                radMenuItem32.Click += RadMenuItem25_Click;
                radMenuItem33.Click += RadMenuItem25_Click;
                radMenuItem51.Click += RadMenuItem25_Click;
                radMenuItem52.Click += RadMenuItem25_Click;
                radMenuItem53.Click += RadMenuItem25_Click;
                radMenuItem54.Click += RadMenuItem25_Click;
                radMenuItem55.Click += RadMenuItem25_Click;
                radMenuItem56.Click += RadMenuItem25_Click;
                radMenuItem57.Click += RadMenuItem25_Click;
                radMenuItem66.Click += RadMenuItem25_Click;

                radMenuItem62.Click += RadMenuItem62_Click;
                radMenuItem63.Click += RadMenuItem62_Click;
                radMenuItem64.Click += RadMenuItem62_Click;
                radMenuItem65.Click += RadMenuItem62_Click;

                radMenuItem58.Click += RadMenuItem58_Click;
                radMenuItem59.Click += RadMenuItem58_Click;
                radMenuItem60.Click += RadMenuItem58_Click;
                radMenuItem61.Click += RadMenuItem58_Click;

                radMenuItem21.Click += RadMenuItem21_Click;
                radMenuItem22.Click += RadMenuItem21_Click;
                radMenuItem23.Click += RadMenuItem21_Click;
                radMenuItem24.Click += RadMenuItem21_Click;

                radMenuItem17.Click += RadMenuItem17_Click;
                radMenuItem18.Click += RadMenuItem17_Click;
                radMenuItem19.Click += RadMenuItem17_Click;
                radMenuItem20.Click += RadMenuItem17_Click;
            }
            catch
            {

            }

        }

        private void RadMenuItem17_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbSpVol90.Text == "")
                {
                    btnSpVol90Unit.Text = b.Text;
                    return;
                }

                string to = b.Text;
                string from = btnSpVol90Unit.Text;
                if (to == from)
                    return;
                decimal valueGas = 0;
                decimal new_valueGas = 0;
                if (txbSpVol90.Text != "")
                {
                    valueGas = Convert.ToDecimal(txbSpVol90.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbSpVol90.Text = Math.Round(new_valueGas, 3).ToString();
                }
                btnSpVol90Unit.Text = to;
            }
            catch
            {

            }
        }

        private void RadMenuItem21_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbMixDensity90.Text == "")
                {
                    btnMixDensity90Unit.Text = b.Text;
                    return;
                }

                string to = b.Text;
                string from = btnMixDensity90Unit.Text;
                if (to == from)
                    return;
                decimal valueGas = 0;
                decimal new_valueGas = 0;
                if (txbMixDensity90.Text != "")
                {
                    valueGas = Convert.ToDecimal(txbMixDensity90.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbMixDensity90.Text = Math.Round(new_valueGas, 3).ToString();
                }
                btnMixDensity90Unit.Text = to;
            }
            catch
            {

            }
        }

        private void RadMenuItem58_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbLiquidSpecific.Text == "")
                {
                    btnLiquidSpecificUnit.Text = b.Text;
                    return;
                }

                string to = b.Text;
                string from = btnLiquidSpecificUnit.Text;
                if (to == from)
                    return;
                decimal valueGas = 0;
                decimal new_valueGas = 0;
                if (txbLiquidSpecific.Text != "")
                {
                    valueGas = Convert.ToDecimal(txbLiquidSpecific.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbLiquidSpecific.Text = Math.Round(new_valueGas, 3).ToString();
                }
                btnLiquidSpecificUnit.Text = to;
            }
            catch
            {

            }
        }

        private void RadMenuItem62_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbLiquidDensity.Text == "")
                {
                    btnLiquidDensityUnit.Text = b.Text;
                    return;
                }

                string to = b.Text;
                string from = btnLiquidDensityUnit.Text;
                if (to == from)
                    return;
                decimal valueGas = 0;
                decimal new_valueGas = 0;
                if (txbLiquidDensity.Text != "")
                {
                    valueGas = Convert.ToDecimal(txbLiquidDensity.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbLiquidDensity.Text = Math.Round(new_valueGas, 3).ToString();
                }
                btnLiquidDensityUnit.Text = to;
            }
            catch
            {

            }
        }

        private void RadMenuItem25_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbVaporPressure.Text == "")
                    return;

                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                string to = b.Text;
                string from = btnVaporUnitC23.Text;
                if (to == from)
                    return;
                decimal value = Convert.ToDecimal(txbVaporPressure.Text);
                decimal Kf = BL.ConvertUnit(1, from, "psia");
                decimal Kt = BL.ConvertUnit(1, to, "psia");
                decimal exvalue = value * (Kf / Kt);
                txbVaporPressure.Text = Math.Round(exvalue, 3).ToString();
                btnVaporUnitC23.Text = to;
            }
            catch
            {

            }
        }

        private void Kgday_vapor_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                ChangeRatedCapacityUnit(btnVaporFlowCapacityUnit.Text, b.Text);
                string to = b.Text;
                string from = btnVaporFlowCapacityUnit.Text;
                if (txbVaporFlowCapacity.Text != "")
                {
                    if (to == from)
                        return;
                    decimal valueGas = 0;
                    decimal new_valueGas = 0;
                    valueGas = Convert.ToDecimal(txbVaporFlowCapacity.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbVaporFlowCapacity.Text = Math.Round(new_valueGas, 3).ToString();
                }
                if (txbLiquidFlowCapacity.Text != "")
                {
                    if (to == from)
                        return;
                    decimal valueGas = 0;
                    decimal new_valueGas = 0;
                    valueGas = Convert.ToDecimal(txbLiquidFlowCapacity.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbLiquidFlowCapacity.Text = Math.Round(new_valueGas, 3).ToString();
                }
                if (txbRequiredPressureFlow2Phase.Text != "")
                {
                    if (to == from)
                        return;
                    decimal valueGas = 0;
                    decimal new_valueGas = 0;
                    valueGas = Convert.ToDecimal(txbRequiredPressureFlow2Phase.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbRequiredPressureFlow2Phase.Text = Math.Round(new_valueGas, 3).ToString();
                }

                btnVaporFlowCapacityUnit.Text = to;
                btnLiquidFlowCapacityUnit.Text = to;
                btnRequiredFlow2PhaseUnit.Text = to;
            }
            catch
            {

            }
        }

        private void Ft3lb_vinlet_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbV1.Text == "")
                {
                    btnVinletUnit.Text = b.Text;
                    return;
                }

                string to = b.Text;
                string from = btnVinletUnit.Text;
                if (to == from)
                    return;
                decimal valueGas = 0;
                decimal new_valueGas = 0;
                if (txbV1.Text != "")
                {
                    valueGas = Convert.ToDecimal(txbV1.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbV1.Text = Math.Round(new_valueGas, 3).ToString();
                }
                btnVinletUnit.Text = to;
            }
            catch
            {

            }
        }

        private void Ft3lb_v90_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbV90.Text == "")
                {
                    btnV90.Text = b.Text;
                    return;
                }

                string to = b.Text;
                string from = btnV90.Text;
                if (to == from)
                    return;
                decimal valueGas = 0;
                decimal new_valueGas = 0;
                if (txbV90.Text != "")
                {
                    valueGas = Convert.ToDecimal(txbV90.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbV90.Text = Math.Round(new_valueGas, 3).ToString();
                }
                btnV90.Text = to;
            }
            catch
            {

            }
        }

        private void Ft3lb_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbSpecificValumeGas.Text == "" && txbSpecificValumeLiquid.Text == "")
                {
                    btnSpecificValumeUnit.Text = b.Text;
                    return;
                }

                string to = b.Text;
                string from = btnSpecificValumeUnit.Text;
                if (to == from)
                    return;
                decimal valueGas = 0;
                decimal new_valueGas = 0;
                decimal valueLiquid = 0;
                decimal new_valueLiquid = 0;
                if (txbSpecificValumeGas.Text != "")
                {
                    valueGas = Convert.ToDecimal(txbSpecificValumeGas.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbSpecificValumeGas.Text = Math.Round(new_valueGas, 3).ToString();
                }
                if (txbSpecificValumeLiquid.Text != "")
                {
                    valueLiquid = Convert.ToDecimal(txbSpecificValumeLiquid.Text);
                    new_valueLiquid = BL.ConvertUnit(valueLiquid, from, to);
                    txbSpecificValumeLiquid.Text = Math.Round(new_valueLiquid, 3).ToString();
                }

                btnSpecificValumeUnit.Text = to;
            }
            catch
            {

            }
        }

        private void Kgm3_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbDensityGas.Text == "" && txbDensityLiquid.Text == "")
                {
                    btnDensityUnit.Text = b.Text;
                    return;
                }

                string to = b.Text;
                string from = btnDensityUnit.Text;
                if (to == from)
                    return;
                decimal valueGas = 0;
                decimal new_valueGas = 0;
                decimal valueLiquid = 0;
                decimal new_valueLiquid = 0;
                if (txbDensityGas.Text != "")
                {
                    valueGas = Convert.ToDecimal(txbDensityGas.Text);
                    new_valueGas = BL.ConvertUnit(valueGas, from, to);
                    txbDensityGas.Text = Math.Round(new_valueGas, 3).ToString();
                }
                if (txbDensityLiquid.Text != "")
                {
                    valueLiquid = Convert.ToDecimal(txbDensityLiquid.Text);
                    new_valueLiquid = BL.ConvertUnit(valueLiquid, from, to);
                    txbDensityLiquid.Text = Math.Round(new_valueLiquid, 3).ToString();
                }

                btnDensityUnit.Text = to;
            }
            catch
            {

            }
        }

        private void SetFlowCapacityUnit()
        {
            try
            {
                lbhr_Liquid.Click += Lbhr_Liquid_Click;
                ft3hr_Liquid.Click += Lbhr_Liquid_Click;
                Kgday_Liquid.Click += Lbhr_Liquid_Click;
                Kghr_Liquid.Click += Lbhr_Liquid_Click;
                Kgmin_Liquid.Click += Lbhr_Liquid_Click;
                Kgs_Liquid.Click += Lbhr_Liquid_Click;
                lbday_Liquid.Click += Lbhr_Liquid_Click;
                lbmin_Liquid.Click += Lbhr_Liquid_Click;
                lbs_Liquid.Click += Lbhr_Liquid_Click;
                Tonlongday_Liquid.Click += Lbhr_Liquid_Click;
                Tonlonghr_Liquid.Click += Lbhr_Liquid_Click;
                Tonlongs_Liquid.Click += Lbhr_Liquid_Click;
                TonUSday_Liquid.Click += Lbhr_Liquid_Click;
                TonUShr_Liquid.Click += Lbhr_Liquid_Click;
                TonUSs_Liquid.Click += Lbhr_Liquid_Click;
                Tonmtday_Liquid.Click += Lbhr_Liquid_Click;
                Tonmthr_Liquid.Click += Lbhr_Liquid_Click;
                Tonmts_Liquid.Click += Lbhr_Liquid_Click;
                BBLd.Click += Lbhr_Liquid_Click;
                BBLh.Click += Lbhr_Liquid_Click;
                ft3day_Liquid.Click += Lbhr_Liquid_Click;
                ft3min_Liquid.Click += Lbhr_Liquid_Click;
                ft3s_Liquid.Click += Lbhr_Liquid_Click;
                GPD_Imp.Click += Lbhr_Liquid_Click;
                GPD_US.Click += Lbhr_Liquid_Click;
                GPH_Imp.Click += Lbhr_Liquid_Click;
                GPH_US.Click += Lbhr_Liquid_Click;
                GPM_Imp.Click += Lbhr_Liquid_Click;
                GPM_US.Click += Lbhr_Liquid_Click;
                GPS_Imp.Click += Lbhr_Liquid_Click;
                GPM_US.Click += Lbhr_Liquid_Click;
                lday.Click += Lbhr_Liquid_Click;
                lhr.Click += Lbhr_Liquid_Click;
                lmin.Click += Lbhr_Liquid_Click;
                ls.Click += Lbhr_Liquid_Click;
                m3day_Liquid.Click += Lbhr_Liquid_Click;
                m3hr_Liquid.Click += Lbhr_Liquid_Click;
                m3min_Liquid.Click += Lbhr_Liquid_Click;
                m3s_Liquid.Click += Lbhr_Liquid_Click;
            }
            catch
            {

            }
        }
        
        private void Lbhr_Liquid_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                ChangeRatedCapacityUnit(btnRequiredFlowCapacityUnit.Text, b.Text);
                if (txbRequiredPressureFlow.Text == "")
                {
                    btnRequiredFlowCapacityUnit.Text = b.Text;
                    return;
                }


                string to = b.Text;
                string from = btnRequiredFlowCapacityUnit.Text;
                if (to == from)
                    return;
                decimal value = Convert.ToDecimal(txbRequiredPressureFlow.Text);
                string result = BL.ConvertUnit(from, to, value, FluidType);
                string new_value;
                if (result == "Liquid_Type1")
                    new_value = BL.ConvertLiquidUnit(txbRequiredPressureFlow.Text, txbMolecularWeight.Text, from, to, 1);
                else
                    new_value = BL.ConvertLiquidUnit(txbRequiredPressureFlow.Text, txbMolecularWeight.Text, from, to, 2);
                // decimal value = Convert.ToDecimal(txbRequiredPressureFlow.Text);
                // decimal new_value = BL.ConvertUnit(value, from, to);
                txbRequiredPressureFlow.Text = new_value;
                btnRequiredFlowCapacityUnit.Text = to;
            }
            catch
            {

            }
        }

        private void SetViscosityUnit()
        {
            try
            {
                cm2s.Click += Cm2s_Click;
                cP.Click += Cm2s_Click;
                cSt.Click += Cm2s_Click;
                ft2s.Click += Cm2s_Click;
                in2s.Click += Cm2s_Click;
                kgmhr.Click += Cm2s_Click;
                lbfthr.Click += Cm2s_Click;
                lbfsft2.Click += Cm2s_Click;
                m2s.Click += Cm2s_Click;
                mm2s.Click += Cm2s_Click;
                mPas.Click += Cm2s_Click;
                Nsm2.Click += Cm2s_Click;
                Pas.Click += Cm2s_Click;
                Poise.Click += Cm2s_Click;
                SSU.Click += Cm2s_Click;
            }
            catch
            {

            }
        }

        private void Cm2s_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                if (txbK.Text == "")
                {
                    btnViscosityUnit.Text = b.Text;
                    return;
                }


                string to = b.Text;
                string from = btnViscosityUnit.Text;
                if (to == from)
                    return;
                decimal value = Convert.ToDecimal(txbK.Text);

                /*
                decimal Kf1 = BL.ConvertUnit(1, from, "lb/hr");
                decimal Kt1 = BL.ConvertUnit(1, to, "lb/hr");

                if (Kf1 != 0 && Kt1 != 0)
                {
                    decimal exvalue = value * (Kf1 / Kt1);
                    txbRequiredPressureFlow.Text = Math.Round(exvalue, 3).ToString();
                    btnRequiredPressureFlowUnit.Text = to;
                    return;
                }
                decimal Kf2 = BL.ConvertUnit(1, from, "ft³/hr");
                decimal Kt2 = BL.ConvertUnit(1, to, "ft³/hr");
                if (Kt2 != 0 && Kf2 != 0)
                {
                    decimal exvalue = value * (Kf2 / Kt2);
                    txbRequiredPressureFlow.Text = Math.Round(exvalue, 3).ToString();
                    btnRequiredPressureFlowUnit.Text = to;
                    return;
                }
                txbRequiredPressureFlow.Text = "";
                btnRequiredPressureFlowUnit.Text = to;
                */
            }
            catch
            {

            }
        }

        private void SetPressureFlowUnit()
        {
            try
            {
                Kgday.Click += Kgday_Click;
                Kghr.Click += Kgday_Click;
                Kgmin.Click += Kgday_Click;
                Kgs.Click += Kgday_Click;
                lbday.Click += Kgday_Click;
                lbhr.Click += Kgday_Click;
                lbmin.Click += Kgday_Click;
                lbs.Click += Kgday_Click;
                Tonlongday.Click += Kgday_Click;
                Tonlonghr.Click += Kgday_Click;
                Tonlongs.Click += Kgday_Click;
                Tonmtday.Click += Kgday_Click;
                Tonmthr.Click += Kgday_Click;
                Tonmts.Click += Kgday_Click;
                TonUSday.Click += Kgday_Click;
                TonUShr.Click += Kgday_Click;
                TonUSs.Click += Kgday_Click;

                MMSCFD.Click += Kgday_Click;
                MMSCFH.Click += Kgday_Click;
                MMSCFM.Click += Kgday_Click;
                Nm3day.Click += Kgday_Click;
                Nm3hr.Click += Kgday_Click;
                Nm3min.Click += Kgday_Click;
                Nm3s.Click += Kgday_Click;
                SCFD.Click += Kgday_Click;
                SCFH.Click += Kgday_Click;
                SCFM.Click += Kgday_Click;
                SCFS.Click += Kgday_Click;
                Sm3hr.Click += Kgday_Click;
                Sm3min.Click += Kgday_Click;
                ft3day.Click += Kgday_Click;
                ft3hr.Click += Kgday_Click;
                ft3min.Click += Kgday_Click;
                ft3s.Click += Kgday_Click;
                m3day.Click += Kgday_Click;
                m3hr.Click += Kgday_Click;
                m3s.Click += Kgday_Click;
                m3min.Click += Kgday_Click;
            }
            catch
            {

            }
        }

        private void Kgday_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                ChangeRatedCapacityUnit(btnRequiredPressureFlowUnit.Text, b.Text);
                if (txbRequiredPressureFlow.Text == "")
                {
                    btnRequiredPressureFlowUnit.Text = b.Text;
                    return;
                }


                string to = b.Text;
                string from = btnRequiredPressureFlowUnit.Text;
                decimal value = Convert.ToDecimal(txbRequiredPressureFlow.Text);
                decimal newValue = BL.ConvertUnit(value, from, to);
                txbRequiredPressureFlow.Text = newValue.ToString();
                /*
                string result = BL.ConvertUnit(from, to, value, FluidType);
                switch (result)
                {
                    case "MassToVolume_Gas_SI":
                        {
                            result = BL.ConvertMassToVolume_Gas_SI(from, to, value, txbRelieving.Text, btnRelievingTemp.Text, txbMolecularWeight.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbSetPressure.Text, btnSetPressureUnit.Text);
                            txbRequiredPressureFlow.Text = result;
                            break;
                        }
                    case "MassToVolume_Gas_BRITISH":
                        {
                            result = BL.ConvertMassToVolume_Gas_BRITISH(from, to, value, txbRelieving.Text, btnRelievingTemp.Text, txbMolecularWeight.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbSetPressure.Text, btnSetPressureUnit.Text);
                            txbRequiredPressureFlow.Text = result;
                            break;
                        }
                    case "VolumeToMass_Gas_BRITISH":
                        {
                            result = BL.ConvertVolumeToMass_Gas_BRITISH(from, to, value, txbRelieving.Text, btnRelievingTemp.Text, txbMolecularWeight.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbSetPressure.Text, btnSetPressureUnit.Text);
                            txbRequiredPressureFlow.Text = result;
                            break;
                        }
                    case "VolumeToMass_Gas_SI":
                        {
                            result = BL.ConvertVolumeToMass_Gas_SI(from, to, value, txbRelieving.Text, btnRelievingTemp.Text, txbMolecularWeight.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbSetPressure.Text, btnSetPressureUnit.Text);
                            txbRequiredPressureFlow.Text = result;
                            break;
                        }
                    default:
                        {
                            txbRequiredPressureFlow.Text = result;
                            break;
                        }
                }
                */

                btnRequiredPressureFlowUnit.Text = to;
            }
            catch
            {

            }
        }

       

        private void ChangeRatedCapacityUnit(string FromUnit,string ToUnit)
        {
            try
            {
                if (FromUnit == ToUnit)
                    return;
                if (dgvProduct.RowCount > 0)
                {
                    for (int i = 0; i < dgvProduct.RowCount; i++)
                    {
                        string w = dgvProduct.Rows[i].Cells["clmRatedFlowCapacity"].Value.ToString();
                        string w_converted = BL.ConvertUnit(Convert.ToDecimal(w), FromUnit, ToUnit).ToString();
                        dgvProduct.Rows[i].Cells["clmRatedFlowCapacity"].Value = w_converted;
                    }
                    dgvProduct.Columns["clmRatedFlowCapacity"].HeaderText = "Rated Flow Capacity (" + ToUnit + ")";
                    ReactionForceUnit = ToUnit;
                }
            }
            catch
            {

            }
        }

        private void SetPressuresUnit()
        {
            try
            {
                atma.Click += Atma_Click;
                psia.Click += Atma_Click;
                bara.Click += Atma_Click;
                ftwca.Click += Atma_Click;
                inHga.Click += Atma_Click;
                inwca.Click += Atma_Click;
                kgcm2a.Click += Atma_Click;
                kPaa.Click += Atma_Click;
                lbft2a.Click += Atma_Click;
                mbara.Click += Atma_Click;
                meterH2Oa.Click += Atma_Click;
                mmH2Oa.Click += Atma_Click;
                mmHga.Click += Atma_Click;
                MPaa.Click += Atma_Click;
                ozin2a.Click += Atma_Click;
                Paa.Click += Atma_Click;
                Torra.Click += Atma_Click;

                SystemMAWP_atmg.Click += SystemMAWP_atmg_Click;
                SystemMAWP_barg.Click += SystemMAWP_atmg_Click;
                SystemMAWP_ftwcg.Click += SystemMAWP_atmg_Click;
                SystemMAWP_inHgg.Click += SystemMAWP_atmg_Click;
                SystemMAWP_inwcg.Click += SystemMAWP_atmg_Click;
                SystemMAWP_kgcm2g.Click += SystemMAWP_atmg_Click;
                SystemMAWP_kPag.Click += SystemMAWP_atmg_Click;
                SystemMAWP_lbft2g.Click += SystemMAWP_atmg_Click;
                SystemMAWP_mbarg.Click += SystemMAWP_atmg_Click;
                SystemMAWP_meterH2Og.Click += SystemMAWP_atmg_Click;
                SystemMAWP_mmH2Og.Click += SystemMAWP_atmg_Click;
                SystemMAWP_mmHgg.Click += SystemMAWP_atmg_Click;
                SystemMAWP_MPag.Click += SystemMAWP_atmg_Click;
                SystemMAWP_ozin2g.Click += SystemMAWP_atmg_Click;
                SystemMAWP_Pag.Click += SystemMAWP_atmg_Click;
                SystemMAWP_psig.Click += SystemMAWP_atmg_Click;
                SystemMAWP_Torrg.Click += SystemMAWP_atmg_Click;

                OperatingPressure_atmg.Click += SystemMAWP_atmg_Click;
                OperatingPressure_barg.Click += SystemMAWP_atmg_Click;
                OperatingPressure_ftwcg.Click += SystemMAWP_atmg_Click;
                OperatingPressure_inHgg.Click += SystemMAWP_atmg_Click;
                OperatingPressure_inwcg.Click += SystemMAWP_atmg_Click;
                OperatingPressure_kgcm2g.Click += SystemMAWP_atmg_Click;
                OperatingPressure_kPag.Click += SystemMAWP_atmg_Click;
                OperatingPressure_lbft2g.Click += SystemMAWP_atmg_Click;
                OperatingPressure_mbarg.Click += SystemMAWP_atmg_Click;
                OperatingPressure_meterH2Og.Click += SystemMAWP_atmg_Click;
                OperatingPressure_mmH2Og.Click += SystemMAWP_atmg_Click;
                OperatingPressure_mmHgg.Click += SystemMAWP_atmg_Click;
                OperatingPressure_MPag.Click += SystemMAWP_atmg_Click;
                OperatingPressure_ozin2g.Click += SystemMAWP_atmg_Click;
                OperatingPressure_Pag.Click += SystemMAWP_atmg_Click;
                OperatingPressure_psig.Click += SystemMAWP_atmg_Click;
                OperatingPressure_Torrg.Click += SystemMAWP_atmg_Click;

                SetPressure_atmg.Click += SystemMAWP_atmg_Click;
                SetPressure_barg.Click += SystemMAWP_atmg_Click;
                SetPressure_ftwcg.Click += SystemMAWP_atmg_Click;
                SetPressure_inHgg.Click += SystemMAWP_atmg_Click;
                SetPressure_inwcg.Click += SystemMAWP_atmg_Click;
                SetPressure_kgcm2g.Click += SystemMAWP_atmg_Click;
                SetPressure_kPag.Click += SystemMAWP_atmg_Click;
                SetPressure_lbft2g.Click += SystemMAWP_atmg_Click;
                SetPressure_mbarg.Click += SystemMAWP_atmg_Click;
                SetPressure_meterH2Og.Click += SystemMAWP_atmg_Click;
                SetPressure_mmH2Og.Click += SystemMAWP_atmg_Click;
                SetPressure_mmHgg.Click += SystemMAWP_atmg_Click;
                SetPressure_MPag.Click += SystemMAWP_atmg_Click;
                SetPressure_ozin2g.Click += SystemMAWP_atmg_Click;
                SetPressure_Pag.Click += SystemMAWP_atmg_Click;
                SetPressure_psig.Click += SystemMAWP_atmg_Click;
                SetPressure_Torrg.Click += SystemMAWP_atmg_Click;

                OverPressure_atmg.Click += SystemMAWP_atmg_Click;
                OverPressure_barg.Click += SystemMAWP_atmg_Click;
                OverPressure_ftwcg.Click += SystemMAWP_atmg_Click;
                OverPressure_inHgg.Click += SystemMAWP_atmg_Click;
                OverPressure_inwcg.Click += SystemMAWP_atmg_Click;
                OverPressure_kgcm2g.Click += SystemMAWP_atmg_Click;
                OverPressure_kPag.Click += SystemMAWP_atmg_Click;
                OverPressure_lbft2g.Click += SystemMAWP_atmg_Click;
                OverPressure_mbarg.Click += SystemMAWP_atmg_Click;
                OverPressure_meterH2Og.Click += SystemMAWP_atmg_Click;
                OverPressure_mmH2Og.Click += SystemMAWP_atmg_Click;
                OverPressure_mmHgg.Click += SystemMAWP_atmg_Click;
                OverPressure_MPag.Click += SystemMAWP_atmg_Click;
                OverPressure_ozin2g.Click += SystemMAWP_atmg_Click;
                OverPressure_Pag.Click += SystemMAWP_atmg_Click;
                OverPressure_psig.Click += SystemMAWP_atmg_Click;
                OverPressure_Torrg.Click += SystemMAWP_atmg_Click;

                BuiltUp_atmg.Click += SystemMAWP_atmg_Click;
                BuiltUp_barg.Click += SystemMAWP_atmg_Click;
                BuiltUp_ftwcg.Click += SystemMAWP_atmg_Click;
                BuiltUp_inHgg.Click += SystemMAWP_atmg_Click;
                BuiltUp_inwcg.Click += SystemMAWP_atmg_Click;
                BuiltUp_kgcm2g.Click += SystemMAWP_atmg_Click;
                BuiltUp_kPag.Click += SystemMAWP_atmg_Click;
                BuiltUp_lbft2g.Click += SystemMAWP_atmg_Click;
                BuiltUp_mbarg.Click += SystemMAWP_atmg_Click;
                BuiltUp_meterH2Og.Click += SystemMAWP_atmg_Click;
                BuiltUp_mmH2Og.Click += SystemMAWP_atmg_Click;
                BuiltUp_mmHgg.Click += SystemMAWP_atmg_Click;
                BuiltUp_MPag.Click += SystemMAWP_atmg_Click;
                BuiltUp_ozin2g.Click += SystemMAWP_atmg_Click;
                BuiltUp_Pag.Click += SystemMAWP_atmg_Click;
                BuiltUp_psig.Click += SystemMAWP_atmg_Click;
                BuiltUp_Torrg.Click += SystemMAWP_atmg_Click;

                ConstantSuperimposed_atmg.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_barg.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_ftwcg.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_inHgg.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_inwcg.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_kgcm2g.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_kPag.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_lbft2g.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_mbarg.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_meterH2Og.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_mmH2Og.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_mmHgg.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_MPag.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_ozin2g.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_Pag.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_psig.Click += SystemMAWP_atmg_Click;
                ConstantSuperimposed_Torrg.Click += SystemMAWP_atmg_Click;

                VaribleSuperimposed_atmg.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_barg.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_ftwcg.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_inHgg.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_inwcg.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_kgcm2g.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_kPag.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_lbft2g.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_mbarg.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_meterH2Og.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_mmH2Og.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_mmHgg.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_MPag.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_ozin2g.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_Pag.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_psig.Click += SystemMAWP_atmg_Click;
                VaribleSuperimposed_Torrg.Click += SystemMAWP_atmg_Click;

                TotalBackPressure_atmg.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_barg.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_ftwcg.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_inHgg.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_inwcg.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_kgcm2g.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_kPag.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_lbft2g.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_mbarg.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_meterH2Og.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_mmH2Og.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_mmHgg.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_MPag.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_ozin2g.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_Pag.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_psig.Click += SystemMAWP_atmg_Click;
                TotalBackPressure_Torrg.Click += SystemMAWP_atmg_Click;

                InletLoss_atmg.Click += SystemMAWP_atmg_Click;
                InletLoss_barg.Click += SystemMAWP_atmg_Click;
                InletLoss_ftwcg.Click += SystemMAWP_atmg_Click;
                InletLoss_inHgg.Click += SystemMAWP_atmg_Click;
                InletLoss_inwcg.Click += SystemMAWP_atmg_Click;
                InletLoss_kgcm2g.Click += SystemMAWP_atmg_Click;
                InletLoss_kPag.Click += SystemMAWP_atmg_Click;
                InletLoss_lbft2g.Click += SystemMAWP_atmg_Click;
                InletLoss_mbarg.Click += SystemMAWP_atmg_Click;
                InletLoss_meterH2Og.Click += SystemMAWP_atmg_Click;
                InletLoss_mmH2Og.Click += SystemMAWP_atmg_Click;
                InletLoss_mmHgg.Click += SystemMAWP_atmg_Click;
                InletLoss_MPag.Click += SystemMAWP_atmg_Click;
                InletLoss_ozin2g.Click += SystemMAWP_atmg_Click;
                InletLoss_Pag.Click += SystemMAWP_atmg_Click;
                InletLoss_psig.Click += SystemMAWP_atmg_Click;
                InletLoss_Torrg.Click += SystemMAWP_atmg_Click;
            }
            catch
            {

            }
        }

        private void SystemMAWP_atmg_Click(object sender, EventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                string to = b.Text;
                string from = btnSystemMAWPUnit.Text;
                if (to == from)
                    return;
                ConvertPresuresUnit(txbSystemMAWP, from, to, btnSystemMAWPUnit);
                ConvertPresuresUnit(txbOperatingPressure, from, to, btnOperatingPressureUnit);
                ConvertPresuresUnit(txbSetPressure, from, to, btnSetPressureUnit);
                ConvertPresuresUnit(txbOverPressure, from, to, btnOverPressureUnit);
                ConvertPresuresUnit(txbBuiltUp, from, to, btnBuiltUpUnit);
                ConvertPresuresUnit(txbConstantSuperimposed, from, to, btnConstantSuperimposedUnit);
                ConvertPresuresUnit(txbVaribleSuperimposed, from, to, btnVaribleSuperimposedUnit);
                ConvertPresuresUnit(txbTotalBackPressure, from, to, btnTotalBackPressureUnit);
                ConvertPresuresUnit(txbInletLoss, from, to, btnInletLossUnit);
            }
            catch
            {

            }

        }

        private void ConvertPresuresUnit(Telerik.WinControls.UI.RadTextBox TextBox, string FromUnit, string ToUnit, Telerik.WinControls.UI.RadDropDownButton UnitButton)
        {
            try
            {
                if (TextBox.Text != "")
                {
                    decimal value = Convert.ToDecimal(TextBox.Text);

                    decimal exvalue = BL.ConvertUnit(value, FromUnit, ToUnit);
                    TextBox.Text = Math.Round(exvalue, 3).ToString();
                }
                UnitButton.Text = ToUnit;
            }
            catch
            {

            }
        }

        private void Atma_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbAtmPressure.Text == "")
                    return;

                Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
                string to = b.Text;
                string from = btnAtmPressureUnit.Text;
                if (to == from)
                    return;
                decimal value = Convert.ToDecimal(txbAtmPressure.Text);

                decimal exvalue = BL.ConvertUnit(value, from, to);
                txbAtmPressure.Text = Math.Round(exvalue, 3).ToString();
                btnAtmPressureUnit.Text = to;
            }
            catch
            {

            }
        }

        private void SetTemperatureUnit()
        {
            try
            {
                btnRelievingTemp.Items[0].Click += FrmQuickCalc_Click;
                btnRelievingTemp.Items[1].Click += FrmQuickCalc_Click1;
                btnRelievingTemp.Items[2].Click += FrmQuickCalc_Click2;
                btnRelievingTemp.Items[3].Click += FrmQuickCalc_Click3;

                btnOperatingTemp.Items[0].Click += FrmQuickCalc_Click;
                btnOperatingTemp.Items[1].Click += FrmQuickCalc_Click1;
                btnOperatingTemp.Items[2].Click += FrmQuickCalc_Click2;
                btnOperatingTemp.Items[3].Click += FrmQuickCalc_Click3;

                btnDesignMinTemp.Items[0].Click += FrmQuickCalc_Click;
                btnDesignMinTemp.Items[1].Click += FrmQuickCalc_Click1;
                btnDesignMinTemp.Items[2].Click += FrmQuickCalc_Click2;
                btnDesignMinTemp.Items[3].Click += FrmQuickCalc_Click3;

                btnDesignMaxTemp.Items[0].Click += FrmQuickCalc_Click;
                btnDesignMaxTemp.Items[1].Click += FrmQuickCalc_Click1;
                btnDesignMaxTemp.Items[2].Click += FrmQuickCalc_Click2;
                btnDesignMaxTemp.Items[3].Click += FrmQuickCalc_Click3;

                btnNormalSystemTemp.Items[0].Click += FrmQuickCalc_Click;
                btnNormalSystemTemp.Items[1].Click += FrmQuickCalc_Click1;
                btnNormalSystemTemp.Items[2].Click += FrmQuickCalc_Click2;
                btnNormalSystemTemp.Items[3].Click += FrmQuickCalc_Click3;
            }
            catch
            {

            }
        }

        private void FrmQuickCalc_Click3(object sender, EventArgs e)
        {
            try
            {
                switch (btnRelievingTemp.Text)
                {
                    case "°C":
                        ChangeTempratureUnit("C", "R");
                        break;
                    case "°K":
                        ChangeTempratureUnit("K", "R");
                        break;
                    case "°F":
                        ChangeTempratureUnit("F", "R");
                        break;
                    case "°R":
                        break;
                }
            }
            catch
            {

            }
        }

        private void FrmQuickCalc_Click2(object sender, EventArgs e)
        {
            try
            {
                switch (btnRelievingTemp.Text)
                {
                    case "°C":
                        ChangeTempratureUnit("C", "F");
                        break;
                    case "°K":
                        ChangeTempratureUnit("K", "F");
                        break;
                    case "°F":
                        break;
                    case "°R":
                        ChangeTempratureUnit("R", "F");
                        break;
                }
            }
            catch
            {

            }
        }

        private void FrmQuickCalc_Click1(object sender, EventArgs e)
        {
            try
            {
                switch (btnRelievingTemp.Text)
                {
                    case "°C":
                        ChangeTempratureUnit("C", "K");
                        break;
                    case "°K":
                        break;
                    case "°F":
                        ChangeTempratureUnit("F", "K");
                        break;
                    case "°R":
                        ChangeTempratureUnit("R", "K");
                        break;
                }
            }
            catch
            {

            }
        }

        private void FrmQuickCalc_Click(object sender, EventArgs e)
        {
            try
            {
                switch (btnRelievingTemp.Text)
                {
                    case "°C":
                        break;
                    case "°K":
                        ChangeTempratureUnit("K", "C");
                        break;
                    case "°F":
                        ChangeTempratureUnit("F", "C");
                        break;
                    case "°R":
                        ChangeTempratureUnit("R", "C");
                        break;
                }
            }
            catch
            {

            }

        }

        private void ChangeTempratureUnit(string FromUnit, string ToUnit)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Relieving_Unit = ToUnit;
                string change = FromUnit + ToUnit;
                switch (change)
                {
                    case "KC":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round(Convert.ToDecimal(txbRelieving.Text) - (decimal)273.15, 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round(Convert.ToDecimal(txbOperating.Text) - (decimal)273.15, 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round(Convert.ToDecimal(txbDesignMin.Text) - (decimal)273.15, 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round(Convert.ToDecimal(txbDesignMax.Text) - (decimal)273.15, 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round(Convert.ToDecimal(txbNormalSystem.Text) - (decimal)273.15, 3)).ToString();
                            btnRelievingTemp.Text = "°C";
                            btnOperatingTemp.Text = "°C";
                            btnDesignMinTemp.Text = "°C";
                            btnDesignMaxTemp.Text = "°C";
                            btnNormalSystemTemp.Text = "°C";
                            break;
                        }
                    case "FC":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) - (decimal)32) * ((decimal)5 / (decimal)9), 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round((Convert.ToDecimal(txbOperating.Text) - (decimal)32) * ((decimal)5 / (decimal)9), 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round((Convert.ToDecimal(txbDesignMin.Text) - (decimal)32) * ((decimal)5 / (decimal)9), 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round((Convert.ToDecimal(txbDesignMax.Text) - (decimal)32) * ((decimal)5 / (decimal)9), 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round((Convert.ToDecimal(txbNormalSystem.Text) - (decimal)32) * ((decimal)5 / (decimal)9), 3)).ToString();
                            btnRelievingTemp.Text = "°C";
                            btnOperatingTemp.Text = "°C";
                            btnDesignMinTemp.Text = "°C";
                            btnDesignMaxTemp.Text = "°C";
                            btnNormalSystemTemp.Text = "°C";
                            break;
                        }
                    case "RC":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) / (decimal)1.8) - (decimal)273.15, 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) / (decimal)1.8) - (decimal)273.15, 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) / (decimal)1.8) - (decimal)273.15, 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) / (decimal)1.8) - (decimal)273.15, 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) / (decimal)1.8) - (decimal)273.15, 3)).ToString();
                            btnRelievingTemp.Text = "°C";
                            btnOperatingTemp.Text = "°C";
                            btnDesignMinTemp.Text = "°C";
                            btnDesignMaxTemp.Text = "°C";
                            btnNormalSystemTemp.Text = "°C";
                            break;
                        }
                    case "CK":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round(Convert.ToDecimal(txbRelieving.Text) + (decimal)273.15, 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round(Convert.ToDecimal(txbOperating.Text) + (decimal)273.15, 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round(Convert.ToDecimal(txbDesignMin.Text) + (decimal)273.15, 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round(Convert.ToDecimal(txbDesignMax.Text) + (decimal)273.15, 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round(Convert.ToDecimal(txbNormalSystem.Text) + (decimal)273.15, 3)).ToString();
                            btnRelievingTemp.Text = "°K";
                            btnOperatingTemp.Text = "°K";
                            btnDesignMinTemp.Text = "°K";
                            btnDesignMaxTemp.Text = "°K";
                            btnNormalSystemTemp.Text = "°K";
                            break;
                        }
                    case "FK":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round(((Convert.ToDecimal(txbRelieving.Text) - 32) * ((decimal)5 / (decimal)9)) + (decimal)273.15, 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round(((Convert.ToDecimal(txbOperating.Text) - 32) * ((decimal)5 / (decimal)9)) + (decimal)273.15, 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round(((Convert.ToDecimal(txbDesignMin.Text) - 32) * ((decimal)5 / (decimal)9)) + (decimal)273.15, 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round(((Convert.ToDecimal(txbDesignMax.Text) - 32) * ((decimal)5 / (decimal)9)) + (decimal)273.15, 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round(((Convert.ToDecimal(txbNormalSystem.Text) - 32) * ((decimal)5 / (decimal)9)) + (decimal)273.15, 3)).ToString();
                            btnRelievingTemp.Text = "°K";
                            btnOperatingTemp.Text = "°K";
                            btnDesignMinTemp.Text = "°K";
                            btnDesignMaxTemp.Text = "°K";
                            btnNormalSystemTemp.Text = "°K";
                            break;
                        }
                    case "RK":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round(((Convert.ToDecimal(txbRelieving.Text)) / (decimal)1.8), 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round(((Convert.ToDecimal(txbOperating.Text)) / (decimal)1.8), 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round(((Convert.ToDecimal(txbDesignMin.Text)) / (decimal)1.8), 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round(((Convert.ToDecimal(txbDesignMax.Text)) / (decimal)1.8), 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round(((Convert.ToDecimal(txbNormalSystem.Text)) / (decimal)1.8), 3)).ToString();
                            btnRelievingTemp.Text = "°K";
                            btnOperatingTemp.Text = "°K";
                            btnDesignMinTemp.Text = "°K";
                            btnDesignMaxTemp.Text = "°K";
                            btnNormalSystemTemp.Text = "°K";
                            break;
                        }
                    case "CF":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) * (decimal)1.8) + (decimal)32, 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round((Convert.ToDecimal(txbOperating.Text) * (decimal)1.8) + (decimal)32, 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round((Convert.ToDecimal(txbDesignMin.Text) * (decimal)1.8) + (decimal)32, 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round((Convert.ToDecimal(txbDesignMax.Text) * (decimal)1.8) + (decimal)32, 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round((Convert.ToDecimal(txbNormalSystem.Text) * (decimal)1.8) + (decimal)32, 3)).ToString();
                            btnRelievingTemp.Text = "°F";
                            btnOperatingTemp.Text = "°F";
                            btnDesignMinTemp.Text = "°F";
                            btnDesignMaxTemp.Text = "°F";
                            btnNormalSystemTemp.Text = "°F";
                            break;
                        }
                    case "RF":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) - (decimal)459.67), 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round((Convert.ToDecimal(txbOperating.Text) - (decimal)459.67), 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round((Convert.ToDecimal(txbDesignMin.Text) - (decimal)459.67), 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round((Convert.ToDecimal(txbDesignMax.Text) - (decimal)459.67), 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round((Convert.ToDecimal(txbNormalSystem.Text) - (decimal)459.67), 3)).ToString();
                            btnRelievingTemp.Text = "°F";
                            btnOperatingTemp.Text = "°F";
                            btnDesignMinTemp.Text = "°F";
                            btnDesignMaxTemp.Text = "°F";
                            btnNormalSystemTemp.Text = "°F";
                            break;
                        }
                    case "KF":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) - (decimal)273.15) * ((decimal)9 / (decimal)5) + (decimal)32, 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round((Convert.ToDecimal(txbOperating.Text) - (decimal)273.15) * ((decimal)9 / (decimal)5) + (decimal)32, 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round((Convert.ToDecimal(txbDesignMin.Text) - (decimal)273.15) * ((decimal)9 / (decimal)5) + (decimal)32, 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round((Convert.ToDecimal(txbDesignMax.Text) - (decimal)273.15) * ((decimal)9 / (decimal)5) + (decimal)32, 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round((Convert.ToDecimal(txbNormalSystem.Text) - (decimal)273.15) * ((decimal)9 / (decimal)5) + (decimal)32, 3)).ToString();
                            btnRelievingTemp.Text = "°F";
                            btnOperatingTemp.Text = "°F";
                            btnDesignMinTemp.Text = "°F";
                            btnDesignMaxTemp.Text = "°F";
                            btnNormalSystemTemp.Text = "°F";
                            break;
                        }
                    case "CR":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round((Convert.ToDecimal(txbRelieving.Text) + (decimal)273.15) * (decimal)1.8, 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round((Convert.ToDecimal(txbOperating.Text) + (decimal)273.15) * (decimal)1.8, 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round((Convert.ToDecimal(txbDesignMin.Text) + (decimal)273.15) * (decimal)1.8, 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round((Convert.ToDecimal(txbDesignMax.Text) + (decimal)273.15) * (decimal)1.8, 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round((Convert.ToDecimal(txbNormalSystem.Text) + (decimal)273.15) * (decimal)1.8, 3)).ToString();
                            btnOperatingTemp.Text = "°R";
                            btnRelievingTemp.Text = "°R";
                            btnDesignMinTemp.Text = "°R";
                            btnDesignMaxTemp.Text = "°R";
                            btnNormalSystemTemp.Text = "°R";
                            break;
                        }
                    case "KR":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Math.Round(Convert.ToDecimal(txbRelieving.Text) * (decimal)1.8, 3)).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Math.Round(Convert.ToDecimal(txbOperating.Text) * (decimal)1.8, 3)).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Math.Round(Convert.ToDecimal(txbDesignMin.Text) * (decimal)1.8, 3)).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Math.Round(Convert.ToDecimal(txbDesignMax.Text) * (decimal)1.8, 3)).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Math.Round(Convert.ToDecimal(txbNormalSystem.Text) * (decimal)1.8, 3)).ToString();
                            btnRelievingTemp.Text = "°R";
                            btnOperatingTemp.Text = "°R";
                            btnDesignMinTemp.Text = "°R";
                            btnDesignMaxTemp.Text = "°R";
                            btnNormalSystemTemp.Text = "°R";
                            break;
                        }
                    case "FR":
                        {
                            if (txbRelieving.Text != "")
                                txbRelieving.Text = (Convert.ToDouble(txbRelieving.Text) + 459.67).ToString();
                            if (txbOperating.Text != "")
                                txbOperating.Text = (Convert.ToDouble(txbOperating.Text) + 459.67).ToString();
                            if (txbDesignMin.Text != "")
                                txbDesignMin.Text = (Convert.ToDouble(txbDesignMin.Text) + 459.67).ToString();
                            if (txbDesignMax.Text != "")
                                txbDesignMax.Text = (Convert.ToDouble(txbDesignMax.Text) + 459.67).ToString();
                            if (txbNormalSystem.Text != "")
                                txbNormalSystem.Text = (Convert.ToDouble(txbNormalSystem.Text) + 459.67).ToString();
                            btnRelievingTemp.Text = "°R";
                            btnOperatingTemp.Text = "°R";
                            btnDesignMinTemp.Text = "°R";
                            btnDesignMaxTemp.Text = "°R";
                            btnNormalSystemTemp.Text = "°R";
                            break;
                        }
                }
            }
            catch
            {

            }
        }

        private bool FloatValidation(string Input)
        {
            try
            {
                Convert.ToDecimal(Input);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        private void btnSafetyGasAsmeSec8_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.ProjectList[CurrentProjectIndex].ProjectName == "") //load
                    Program.ProjectList[CurrentProjectIndex].ProjectName = "Safety Relief Valve";
                Program.ProjectList[CurrentProjectIndex].Design_Code = "ASME Section VIII";
                Program.ProjectList[CurrentProjectIndex].Sizing_Std = "API 520";
                Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet = "Gas";
                Program.ProjectList[CurrentProjectIndex].Safety_Relief = "Safety"; //RULE: 2
                Program.ProjectList[CurrentProjectIndex].Relieving_Case = "Pressure Relief";
                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "")//load
                    Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name = "pageSizingSelection";
                Program.ProjectList[CurrentProjectIndex].Fluid_Type = "Gas/Vapor";
                Program.ProjectList[CurrentProjectIndex].Standard_Type = "ASME Section VIII-API 520 ";
                FluidType = "Gas";
                pageCalculationType.Image = Image.FromFile(Program.ImagesPath + "CalculationTypeOff.png");
                pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionOn.png");
                pageSizingSelection.Enabled = true;
                pageMain.SelectedPage = pageSizingSelection;
                SelectedCodeSection = "ASME Section VIII";
                FillPageSizing("Section VIII Gas/Vapor Sizing");
            }
            catch
            {

            }

        }

        private void mnuCm2_Click(object sender, EventArgs e)
        {

        }

        private void FillPageSizing(string StandardTitle)
        {
            try
            {
                lblStandardTitle.Text = StandardTitle;
                cmbSizingBasis.SelectedIndex = 0;
                switch (FluidType)
                {
                    case "Gas":
                        {
                            txbSteamName.Visible = false;
                            cmbFluidName.Visible = true;
                            grbFluidProperties.Visible = true;
                            grb2phaseFluidProperties.Visible = false;
                            grb2phaseFluidPropertiesC23.Visible = false;
                            chbSelectionVIII.Visible = true;
                            grbTemperatures.Location = new Point(6, 185);
                            grbFlowCapacity.Visible = true;
                            grbFlowCapacity2Phase.Visible = false;
                            grbFlowCapacity.Location = new Point(6, 372);
                            this.splitSizing.SplitterDistance = splitSizing.Height - 200;

                            lblViscosityCorrectionFactor.Visible = false;
                            lblKv.Visible = false;
                            txbKv.Visible = false;
                            // lblDischargeCoefficient.Visible = false;
                            // lblKd.Visible = false;
                            // cmbKd.Visible = false;

                            List<Fluid> GasList = new List<Fluid>();
                            GasList = Program.FluidList.Where(item => item.Type == 1).ToList();
                            cmbFluidName.Items.Clear();
                            for (int i = 0; i < GasList.Count; i++)
                            {
                                cmbFluidName.Items.Add(GasList[i].Name);
                            }
                            if (Program.ProjectList[CurrentProjectIndex].TableId == "")
                            {
                                txbMolecularWeight.Text = "";
                                txbK.Text = "";
                                txbCompressibility.Text = "";
                                txbRelieving.Text = "";
                                txbOperating.Text = "";
                                txbDesignMin.Text = "";
                                txbDesignMax.Text = "";
                                lblNormalSystem.Visible = true;
                                txbNormalSystem.Visible = true;
                                btnNormalSystemTemp.Visible = true;
                                txbNormalSystem.Text = "";
                                txbRequiredPressureFlow.Text = "";
                                txbSystemMAWP.Text = "";
                                txbOperatingPressure.Text = "";
                                txbSetPressure.Text = "";
                                txbOverPressure.Text = "";
                                dgvProduct.Visible = false;
                                txbAtmPressure.Text = "14.696";
                                txbOverPressurePercent.Text = "10";
                                txbOverPressure.Enabled = false;
                                txbBuiltUp.Text = "0";
                                txbConstantSuperimposed.Text = "0";
                                txbVaribleSuperimposed.Text = "0";
                                txbTotalBackPressure.Text = "0";
                                txbTotalBackPressure.Enabled = false;
                                txbInletLoss.Text = "0";
                                txbInletLossPercent.Enabled = false;
                                txbKc.Text = "1";
                                txbKc.Enabled = false;
                                lblMolecularWeight.Text = "Molecular Weight";
                                lblK.Text = "K. (CP /CV)";
                                txbMolecularWeight.Text = "";
                                txbK.Text = "";
                                txbCompressibility.Text = "";
                                lblMolecularWeight.ForeColor = Color.Navy;
                                lblK.ForeColor = Color.Navy;
                                lblCompressibility.ForeColor = Color.Navy;
                                lblCompressibility.Visible = true;
                                txbCompressibility.Visible = true;
                                btnViscosityUnit.Visible = false;
                                lblRequiredPressureFlow.Text = "Required Pressure Flow";
                                btnRequiredFlowCapacityUnit.Visible = false;
                                btnRequiredPressureFlowUnit.Visible = true;
                                Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnSetPressureUnit.Text;

                            }
                            else
                            {
                                object sender = null;
                                EventArgs e = null;
                                if (Program.ProjectList[CurrentProjectIndex].Fluid_Name != "")
                                {
                                    cmbFluidName.SelectedValue = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                                }
                                txbMolecularWeight.Text = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;

                                txbK.Text = Program.ProjectList[CurrentProjectIndex].k;

                                txbCompressibility.Text = Program.ProjectList[CurrentProjectIndex].Compressibility;

                                txbRelieving.Text = Program.ProjectList[CurrentProjectIndex].Relieving;

                                txbOperating.Text = Program.ProjectList[CurrentProjectIndex].Operating;
                                txbDesignMin.Text = Program.ProjectList[CurrentProjectIndex].Design_Min;
                                txbDesignMax.Text = Program.ProjectList[CurrentProjectIndex].Design_Max;
                                lblNormalSystem.Visible = true;
                                txbNormalSystem.Visible = true;
                                btnNormalSystemTemp.Visible = true;
                                txbNormalSystem.Text = Program.ProjectList[CurrentProjectIndex].Normal_System;
                                btnRelievingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnDesignMaxTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnDesignMinTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnOperatingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnNormalSystemTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                if (Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure == "")
                                    txbAtmPressure.Text = "14.696";
                                else
                                    txbAtmPressure.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;

                                if (Program.ProjectList[CurrentProjectIndex].Kc == "")
                                    txbKc.Text = "1";
                                else
                                    txbKc.Text = Program.ProjectList[CurrentProjectIndex].Kc;
                                txbRequiredPressureFlow.Text = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                                btnRequiredPressureFlowUnit.Text = Program.ProjectList[CurrentProjectIndex].RequiredPressureFlowUnit;
                                txbRequiredPressureFlow_Leave(sender, e);
                                txbSystemMAWP.Text = Program.ProjectList[CurrentProjectIndex].MAWP;
                                btnSystemMAWPUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbOperatingPressure.Text = Program.ProjectList[CurrentProjectIndex].Operating_Pressures; ;
                                btnOperatingPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbSetPressure.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                                btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbOverPressure.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                                btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                dgvProduct.Visible = false;

                                btnAtmPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                                if (Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent == "")
                                    txbOverPressurePercent.Text = "10";
                                else
                                    txbOverPressurePercent.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent;
                                txbOverPressure.Enabled = false;
                                if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                    txbInletLoss.Text = "0";
                                else
                                    txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;


                                if (Program.ProjectList[CurrentProjectIndex].Built_Up == "")
                                    txbBuiltUp.Text = "0";
                                else
                                    txbBuiltUp.Text = Program.ProjectList[CurrentProjectIndex].Built_Up;

                                btnBuiltUpUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                if (Program.ProjectList[CurrentProjectIndex].Constant_Superimposed == "")
                                    txbConstantSuperimposed.Text = "0";
                                else
                                    txbConstantSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                                btnConstantSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                if (Program.ProjectList[CurrentProjectIndex].Variable_Superimposed == "")
                                    txbVaribleSuperimposed.Text = "0";
                                else
                                    txbVaribleSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                                btnVaribleSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;


                                if (Program.ProjectList[CurrentProjectIndex].Total == "")
                                    txbTotalBackPressure.Text = "0";
                                else
                                    txbTotalBackPressure.Text = Program.ProjectList[CurrentProjectIndex].Total;
                                btnTotalBackPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                txbTotalBackPressure.Enabled = false;

                                if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                    txbInletLoss.Text = "0";
                                else
                                    txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                txbInletLossPercent.Enabled = false;


                                txbKc.Enabled = false;
                                lblMolecularWeight.Text = "Molecular Weight";
                                lblK.Text = "K. (CP /CV)";

                                lblCompressibility.Visible = true;
                                txbCompressibility.Visible = true;
                                btnViscosityUnit.Visible = false;
                                lblRequiredPressureFlow.Text = "Required Pressure Flow";
                                btnRequiredFlowCapacityUnit.Visible = false;
                                btnRequiredPressureFlowUnit.Visible = true;
                                txbMolecularWeight_Leave(sender, e);
                                txbK_Leave(sender, e);
                                txbCompressibility_Leave(sender, e);
                                txbRelieving_Leave(sender, e);
                                txbSetPressure_Leave(sender, e);
                                txbOverPressure_Leave(sender, e);
                                CheckAllValidation();
                                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageConfiguration")
                                {
                                    pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionCheck.png");
                                    pageConfiguration.Image = Image.FromFile(Program.ImagesPath + "ConfigurationOn.png");
                                    pageConfiguration.Enabled = true;
                                    pageMain.SelectedPage = pageConfiguration;
                                    FillConfigurationPage();
                                }
                            }
                            break;
                        }
                    case "Liquid":
                        {
                            txbSteamName.Visible = false;
                            cmbFluidName.Visible = true;
                            grbFluidProperties.Visible = true;
                            grb2phaseFluidProperties.Visible = false;
                            grb2phaseFluidPropertiesC23.Visible = false;
                            chbSelectionVIII.Visible = true;
                            grbTemperatures.Location = new Point(6, 185);
                            grbFlowCapacity.Visible = true;
                            grbFlowCapacity2Phase.Visible = false;
                            grbFlowCapacity.Location = new Point(6, 372);
                            this.splitSizing.SplitterDistance = splitSizing.Height - 200;
                            lblViscosityCorrectionFactor.Visible = false;
                            lblKv.Visible = false;
                            txbKv.Visible = false;
                            // lblDischargeCoefficient.Visible = false;
                            // lblKd.Visible = false;
                            // cmbKd.Visible = false;
                            List<Fluid> LiquidList = new List<Fluid>();
                            LiquidList = Program.FluidList.Where(item => item.Type == 2).ToList();
                            cmbFluidName.Items.Clear();
                            for (int i = 0; i < LiquidList.Count; i++)
                            {
                                cmbFluidName.Items.Add(LiquidList[i].Name);
                            }
                            if (Program.ProjectList[CurrentProjectIndex].TableId == "")
                            {
                                txbMolecularWeight.Text = "";
                                txbK.Text = "";
                                txbCompressibility.Text = "";
                                txbRelieving.Text = "";
                                txbOperating.Text = "";
                                txbDesignMin.Text = "";
                                txbDesignMax.Text = "";
                                lblNormalSystem.Visible = true;
                                txbNormalSystem.Visible = true;
                                btnNormalSystemTemp.Visible = true;
                                txbNormalSystem.Text = "";
                                txbRequiredPressureFlow.Text = "";
                                txbSystemMAWP.Text = "";
                                txbOperatingPressure.Text = "";
                                txbOperatingPressure.Text = "";
                                txbSetPressure.Text = "";
                                txbOverPressure.Text = "";
                                dgvProduct.Visible = false;
                                txbAtmPressure.Text = "14.696";
                                txbOverPressurePercent.Text = "10";
                                txbOverPressure.Enabled = false;
                                txbBuiltUp.Text = "0";
                                txbConstantSuperimposed.Text = "0";
                                txbVaribleSuperimposed.Text = "0";
                                txbTotalBackPressure.Text = "0";
                                txbTotalBackPressure.Enabled = false;
                                txbInletLoss.Text = "0";
                                txbInletLossPercent.Enabled = false;
                                txbKc.Text = "1";
                                txbKc.Enabled = false;
                                lblMolecularWeight.Text = "Specific Gravity";
                                lblK.Text = "Viscosity";
                                txbMolecularWeight.Text = "";
                                txbK.Text = "";
                                txbCompressibility.Text = "";
                                lblMolecularWeight.ForeColor = Color.Navy;
                                lblK.ForeColor = Color.Navy;
                                lblCompressibility.ForeColor = Color.Navy;
                                btnViscosityUnit.Visible = true;
                                lblCompressibility.Visible = false;
                                txbCompressibility.Visible = false;
                                lblRequiredPressureFlow.Text = "Required Flow Capacity";
                                btnRequiredFlowCapacityUnit.Visible = true;
                                btnRequiredPressureFlowUnit.Visible = false;
                            }
                            else
                            {
                                object sender = null;
                                EventArgs e = null;
                                if (Program.ProjectList[CurrentProjectIndex].Fluid_Name != "")
                                {
                                    cmbFluidName.SelectedValue = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                                }
                                txbMolecularWeight.Text = Program.ProjectList[CurrentProjectIndex].SpesificGravity;
                                txbK.Text = Program.ProjectList[CurrentProjectIndex].Viscosity;
                                btnViscosityUnit.Text = Program.ProjectList[CurrentProjectIndex].ViscosityUnit;

                                txbRelieving.Text = Program.ProjectList[CurrentProjectIndex].Relieving;

                                txbOperating.Text = Program.ProjectList[CurrentProjectIndex].Operating;
                                txbDesignMin.Text = Program.ProjectList[CurrentProjectIndex].Design_Min;
                                txbDesignMax.Text = Program.ProjectList[CurrentProjectIndex].Design_Max;
                                lblNormalSystem.Visible = true;
                                txbNormalSystem.Visible = true;
                                btnNormalSystemTemp.Visible = true;
                                txbNormalSystem.Text = Program.ProjectList[CurrentProjectIndex].Normal_System;
                                btnRelievingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnDesignMaxTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnDesignMinTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnOperatingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnNormalSystemTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                if (Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure == "")
                                    txbAtmPressure.Text = "14.696";
                                else
                                    txbAtmPressure.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;

                                if (Program.ProjectList[CurrentProjectIndex].Kc == "")
                                    txbKc.Text = "1";
                                else
                                    txbKc.Text = Program.ProjectList[CurrentProjectIndex].Kc;
                                txbRequiredPressureFlow.Text = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                                btnRequiredPressureFlowUnit.Text = Program.ProjectList[CurrentProjectIndex].RequiredPressureFlowUnit;
                                txbRequiredPressureFlow_Leave(sender, e);
                                txbSystemMAWP.Text = Program.ProjectList[CurrentProjectIndex].MAWP;
                                btnSystemMAWPUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbOperatingPressure.Text = Program.ProjectList[CurrentProjectIndex].Operating_Pressures; ;
                                btnOperatingPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbSetPressure.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                                btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbOverPressure.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                                btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                dgvProduct.Visible = false;

                                btnAtmPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                                if (Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent == "")
                                    txbOverPressurePercent.Text = "10";
                                else
                                    txbOverPressurePercent.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent;
                                txbOverPressure.Enabled = false;
                                if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                    txbInletLoss.Text = "0";
                                else
                                    txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;


                                if (Program.ProjectList[CurrentProjectIndex].Built_Up == "")
                                    txbBuiltUp.Text = "0";
                                else
                                    txbBuiltUp.Text = Program.ProjectList[CurrentProjectIndex].Built_Up;

                                btnBuiltUpUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                if (Program.ProjectList[CurrentProjectIndex].Constant_Superimposed == "")
                                    txbConstantSuperimposed.Text = "0";
                                else
                                    txbConstantSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                                btnConstantSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                if (Program.ProjectList[CurrentProjectIndex].Variable_Superimposed == "")
                                    txbVaribleSuperimposed.Text = "0";
                                else
                                    txbVaribleSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                                btnVaribleSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;


                                if (Program.ProjectList[CurrentProjectIndex].Total == "")
                                    txbTotalBackPressure.Text = "0";
                                else
                                    txbTotalBackPressure.Text = Program.ProjectList[CurrentProjectIndex].Total;
                                btnTotalBackPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                txbTotalBackPressure.Enabled = false;

                                if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                    txbInletLoss.Text = "0";
                                else
                                    txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                txbInletLossPercent.Enabled = false;
                                txbKc.Enabled = false;
                                lblMolecularWeight.ForeColor = Color.Navy;
                                lblK.ForeColor = Color.Navy;
                                lblCompressibility.ForeColor = Color.Navy;
                                btnViscosityUnit.Visible = true;
                                lblCompressibility.Visible = false;
                                txbCompressibility.Visible = false;
                                lblRequiredPressureFlow.Text = "Required Flow Capacity";
                                btnRequiredFlowCapacityUnit.Visible = true;
                                btnRequiredPressureFlowUnit.Visible = false;
                                txbMolecularWeight_Leave(sender, e);
                                txbK_Leave(sender, e);
                                txbCompressibility_Leave(sender, e);
                                txbRelieving_Leave(sender, e);
                                txbSetPressure_Leave(sender, e);
                                txbOverPressure_Leave(sender, e);
                                CheckAllValidation();
                                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageConfiguration")
                                {
                                    pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionCheck.png");
                                    pageConfiguration.Image = Image.FromFile(Program.ImagesPath + "ConfigurationOn.png");
                                    pageConfiguration.Enabled = true;
                                    pageMain.SelectedPage = pageConfiguration;
                                    FillConfigurationPage();
                                }


                            }
                            break;
                        }
                    case "Steam":
                        {
                            cmbFluidName.Visible = false;
                            txbSteamName.Visible = true;
                            grbFluidProperties.Visible = true;
                            grb2phaseFluidProperties.Visible = false;
                            grb2phaseFluidPropertiesC23.Visible = false;
                            chbSelectionVIII.Visible = true;
                            grbTemperatures.Location = new Point(6, 185);
                            grbFlowCapacity.Visible = true;
                            grbFlowCapacity2Phase.Visible = false;
                            grbFlowCapacity.Location = new Point(6, 372);
                            this.splitSizing.SplitterDistance = splitSizing.Height - 200;
                            lblViscosityCorrectionFactor.Visible = false;
                            lblKv.Visible = false;
                            txbKv.Visible = false;
                            // lblDischargeCoefficient.Visible = false;
                            // lblKd.Visible = false;
                            // cmbKd.Visible = false;
                            txbSteamName.Location = new Point(cmbFluidName.Location.X, cmbFluidName.Location.Y);
                            if (Program.ProjectList[CurrentProjectIndex].TableId == "")
                            {
                                txbMolecularWeight.Text = "18.020";
                                txbK.Text = "1.310";
                                txbCompressibility.Text = "1.000";
                                Safety_Steam_ComperesibilityValidation = true;
                                Safety_Steam_KValidation = true;
                                Safety_Steam_MolecularWeightValidation = true;
                                txbRelieving.Text = "";
                                txbOperating.Text = "";
                                txbDesignMin.Text = "";
                                txbDesignMax.Text = "";
                                lblNormalSystem.Visible = false;
                                txbNormalSystem.Visible = false;
                                btnNormalSystemTemp.Visible = false;
                                txbNormalSystem.Text = "";
                                txbRequiredPressureFlow.Text = "";
                                txbSystemMAWP.Text = "";
                                txbOperatingPressure.Text = "";
                                txbOperatingPressure.Text = "";
                                txbSetPressure.Text = "";
                                txbOverPressure.Text = "";
                                dgvProduct.Visible = false;
                                txbAtmPressure.Text = "14.696";
                                txbOverPressurePercent.Text = "3";
                                txbOverPressure.Enabled = false;
                                txbBuiltUp.Text = "0";
                                txbConstantSuperimposed.Text = "0";
                                txbVaribleSuperimposed.Text = "0";
                                txbTotalBackPressure.Text = "0";
                                txbTotalBackPressure.Enabled = false;
                                txbInletLoss.Text = "0";
                                txbInletLossPercent.Enabled = false;
                                txbKc.Text = "1";
                                txbKc.Enabled = false;
                                lblMolecularWeight.Text = "Molecular Weight";
                                lblK.Text = "K. (CP /CV)";
                                lblMolecularWeight.ForeColor = Color.Navy;
                                lblK.ForeColor = Color.Navy;
                                lblCompressibility.ForeColor = Color.Navy;
                                lblCompressibility.Visible = true;
                                txbCompressibility.Visible = true;
                                btnViscosityUnit.Visible = false;
                                lblRequiredPressureFlow.Text = "Required Pressure Flow";
                                btnRequiredFlowCapacityUnit.Visible = false;
                                btnRequiredPressureFlowUnit.Visible = true;
                                btnRequiredPressureFlowUnit.Text = "lb/hr";
                            }
                            else
                            {
                                object sender = null;
                                EventArgs e = null;
                                if (Program.ProjectList[CurrentProjectIndex].Fluid_Name == "")
                                    txbSteamName.Text = "Steam";
                                else
                                    txbSteamName.Text = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                                if (Program.ProjectList[CurrentProjectIndex].Molecular_Weight != "")
                                    txbMolecularWeight.Text = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                                else
                                    txbMolecularWeight.Text = "18.020";
                                if (Program.ProjectList[CurrentProjectIndex].k != "")
                                    txbK.Text = Program.ProjectList[CurrentProjectIndex].k;
                                else
                                    txbK.Text = "1.310";
                                if (Program.ProjectList[CurrentProjectIndex].Compressibility != "")
                                    txbCompressibility.Text = Program.ProjectList[CurrentProjectIndex].Compressibility;
                                else
                                    txbCompressibility.Text = "1.000";

                                txbRelieving.Text = Program.ProjectList[CurrentProjectIndex].Relieving;

                                txbOperating.Text = Program.ProjectList[CurrentProjectIndex].Operating;
                                txbDesignMin.Text = Program.ProjectList[CurrentProjectIndex].Design_Min;
                                txbDesignMax.Text = Program.ProjectList[CurrentProjectIndex].Design_Max;
                                lblNormalSystem.Visible = true;
                                txbNormalSystem.Visible = true;
                                btnNormalSystemTemp.Visible = true;
                                txbNormalSystem.Text = Program.ProjectList[CurrentProjectIndex].Normal_System;
                                btnRelievingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnDesignMaxTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnDesignMinTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnOperatingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                btnNormalSystemTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                if (Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure == "")
                                    txbAtmPressure.Text = "14.696";
                                else
                                    txbAtmPressure.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;

                                if (Program.ProjectList[CurrentProjectIndex].Kc == "")
                                    txbKc.Text = "1";
                                else
                                    txbKc.Text = Program.ProjectList[CurrentProjectIndex].Kc;
                                txbRequiredPressureFlow.Text = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                                btnRequiredPressureFlowUnit.Text = Program.ProjectList[CurrentProjectIndex].RequiredPressureFlowUnit;
                                txbRequiredPressureFlow_Leave(sender, e);
                                txbSystemMAWP.Text = Program.ProjectList[CurrentProjectIndex].MAWP;
                                btnSystemMAWPUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbOperatingPressure.Text = Program.ProjectList[CurrentProjectIndex].Operating_Pressures; ;
                                btnOperatingPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbSetPressure.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                                btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                txbOverPressure.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                                btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                dgvProduct.Visible = false;

                                btnAtmPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                                if (Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent == "")
                                    txbOverPressurePercent.Text = "10";
                                else
                                    txbOverPressurePercent.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent;
                                txbOverPressure.Enabled = false;
                                if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                    txbInletLoss.Text = "0";
                                else
                                    txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;


                                if (Program.ProjectList[CurrentProjectIndex].Built_Up == "")
                                    txbBuiltUp.Text = "0";
                                else
                                    txbBuiltUp.Text = Program.ProjectList[CurrentProjectIndex].Built_Up;

                                btnBuiltUpUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                if (Program.ProjectList[CurrentProjectIndex].Constant_Superimposed == "")
                                    txbConstantSuperimposed.Text = "0";
                                else
                                    txbConstantSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                                btnConstantSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                if (Program.ProjectList[CurrentProjectIndex].Variable_Superimposed == "")
                                    txbVaribleSuperimposed.Text = "0";
                                else
                                    txbVaribleSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                                btnVaribleSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;


                                if (Program.ProjectList[CurrentProjectIndex].Total == "")
                                    txbTotalBackPressure.Text = "0";
                                else
                                    txbTotalBackPressure.Text = Program.ProjectList[CurrentProjectIndex].Total;
                                btnTotalBackPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                txbTotalBackPressure.Enabled = false;

                                if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                    txbInletLoss.Text = "0";
                                else
                                    txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                txbInletLossPercent.Enabled = false;
                                txbKc.Enabled = false;


                                Safety_Steam_ComperesibilityValidation = true;
                                Safety_Steam_KValidation = true;
                                Safety_Steam_MolecularWeightValidation = true;
                                lblNormalSystem.Visible = false;
                                txbNormalSystem.Visible = false;
                                btnNormalSystemTemp.Visible = false;
                                dgvProduct.Visible = false;
                                txbOverPressure.Enabled = false;
                                txbTotalBackPressure.Enabled = false;
                                txbInletLossPercent.Enabled = false;
                                txbKc.Enabled = false;
                                lblMolecularWeight.Text = "Molecular Weight";
                                lblK.Text = "K. (CP /CV)";
                                lblMolecularWeight.ForeColor = Color.Navy;
                                lblK.ForeColor = Color.Navy;
                                lblCompressibility.ForeColor = Color.Navy;
                                lblCompressibility.Visible = true;
                                txbCompressibility.Visible = true;
                                btnViscosityUnit.Visible = false;
                                lblRequiredPressureFlow.Text = "Required Pressure Flow";
                                btnRequiredFlowCapacityUnit.Visible = false;
                                btnRequiredPressureFlowUnit.Visible = true;
                                btnRequiredPressureFlowUnit.Text = "lb/hr";
                                txbMolecularWeight_Leave(sender, e);
                                txbK_Leave(sender, e);
                                txbCompressibility_Leave(sender, e);
                                txbRelieving_Leave(sender, e);
                                txbSetPressure_Leave(sender, e);
                                txbOverPressure_Leave(sender, e);
                                CheckAllValidation();
                                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageConfiguration")
                                {
                                    pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionCheck.png");
                                    pageConfiguration.Image = Image.FromFile(Program.ImagesPath + "ConfigurationOn.png");
                                    pageConfiguration.Enabled = true;
                                    pageMain.SelectedPage = pageConfiguration;
                                    FillConfigurationPage();
                                }
                            }
                            break;
                        }
                    case "2-Phase":
                        {
                            if (Formule2Phase == "C22")
                            {

                                grb2phaseFluidProperties.Location = new Point(grbFluidProperties.Location.X, grbFluidProperties.Location.Y);
                                grbFluidProperties.Visible = false;
                                grb2phaseFluidProperties.Visible = true;
                                grb2phaseFluidPropertiesC23.Visible = false;
                                chbSelectionVIII.Visible = false;
                                grbTemperatures.Location = new Point(6, 310);
                                grbFlowCapacity.Visible = false;
                                grbFlowCapacity2Phase.Location = new Point(6, 495);
                                grbFlowCapacity2Phase.Visible = true;
                                this.splitSizing.SplitterDistance = splitSizing.Height + 200;
                                lblViscosityCorrectionFactor.Visible = true;
                                lblKv.Visible = true;
                                txbKv.Visible = true;
                                lblDischargeCoefficient.Visible = true;
                                lblKd.Visible = true;
                                cmbKd.Visible = true;
                                cmbKd.SelectedIndex = 0;
                                lblNormalSystem.Visible = true;
                                txbNormalSystem.Visible = true;
                                btnNormalSystemTemp.Visible = true;
                                dgvProduct.Visible = false;
                                txbOverPressure.Enabled = false;
                                txbTotalBackPressure.Enabled = false;
                                txbInletLossPercent.Enabled = false;
                                txbKc.Enabled = false;
                                Safety_2PhaseC22_KcValidation = true;
                                Safety_2PhaseC22_KdValidation = true;
                                Safety_2PhaseC22_KvValidation = true;
                                if (Program.ProjectList[CurrentProjectIndex].TableId == "")
                                {
                                    txbFluidName_2phase.Text = "";
                                    txbK_2phase.Text = "";
                                    txbDensityGas.Text = "";
                                    txbDensityLiquid.Text = "";
                                    txbSpecificValumeGas.Text = "";
                                    txbSpecificValumeLiquid.Text = "";
                                    txbSpecificGravity.Text = "";
                                    txbV90.Text = "";
                                    txbV1.Text = "";
                                    txbVaporFlowCapacity.Text = "";
                                    txbLiquidFlowCapacity.Text = "";
                                    txbRequiredPressureFlow2Phase.Text = "";
                                    txbRelieving.Text = "";
                                    txbOperating.Text = "";
                                    txbDesignMin.Text = "";
                                    txbDesignMax.Text = "";
                                    txbNormalSystem.Text = "";
                                    txbSystemMAWP.Text = "";
                                    txbOperatingPressure.Text = "";
                                    txbOperatingPressure.Text = "";
                                    txbSetPressure.Text = "";
                                    txbOverPressure.Text = "";
                                    txbAtmPressure.Text = "14.696";
                                    txbOverPressurePercent.Text = "10";
                                    txbBuiltUp.Text = "0";
                                    txbConstantSuperimposed.Text = "0";
                                    txbVaribleSuperimposed.Text = "0";
                                    txbTotalBackPressure.Text = "0";
                                    txbInletLoss.Text = "0";
                                    txbKc.Text = "1";
                                    txbKv.Text = "1.0";
                                }
                                else
                                {
                                    object sender = null;
                                    EventArgs e = null;
                                    txbFluidName_2phase.Text = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                                    txbK_2phase.Text = Program.ProjectList[CurrentProjectIndex].k;
                                    txbDensityGas.Text = Program.ProjectList[CurrentProjectIndex].GasDensity;
                                    txbDensityLiquid.Text = Program.ProjectList[CurrentProjectIndex].LiquidDensity;
                                    txbSpecificValumeGas.Text = Program.ProjectList[CurrentProjectIndex].SpecificValumeGas;
                                    txbSpecificValumeLiquid.Text = Program.ProjectList[CurrentProjectIndex].SpecificValumeLiquid;
                                    txbSpecificGravity.Text = Program.ProjectList[CurrentProjectIndex].SpesificGravity;
                                    txbV90.Text = Program.ProjectList[CurrentProjectIndex].V90;
                                    txbV1.Text = Program.ProjectList[CurrentProjectIndex].V1;
                                    txbVaporFlowCapacity.Text = Program.ProjectList[CurrentProjectIndex].VaporFlowCapacity;
                                    txbLiquidFlowCapacity.Text = Program.ProjectList[CurrentProjectIndex].LiquidFlowCapacity;
                                    txbRequiredPressureFlow2Phase.Text = (Convert.ToDecimal(txbLiquidFlowCapacity.Text) + Convert.ToDecimal(txbVaporFlowCapacity.Text)).ToString();
                                    btnDensityUnit.Text = Program.ProjectList[CurrentProjectIndex].DensityUnit;
                                    btnSpecificValumeUnit.Text = Program.ProjectList[CurrentProjectIndex].SpecificValumeUnit;
                                    btnV90.Text = Program.ProjectList[CurrentProjectIndex].SpecificValumeUnit;
                                    btnVinletUnit.Text = Program.ProjectList[CurrentProjectIndex].SpecificValumeUnit;
                                    btnVaporFlowCapacityUnit.Text = Program.ProjectList[CurrentProjectIndex].VaporFlowCapacityUnit;
                                    btnLiquidFlowCapacityUnit.Text = Program.ProjectList[CurrentProjectIndex].VaporFlowCapacityUnit;
                                    btnRequiredFlow2PhaseUnit.Text = Program.ProjectList[CurrentProjectIndex].VaporFlowCapacityUnit;

                                    txbRelieving.Text = Program.ProjectList[CurrentProjectIndex].Relieving;
                                    txbOperating.Text = Program.ProjectList[CurrentProjectIndex].Operating;
                                    txbDesignMin.Text = Program.ProjectList[CurrentProjectIndex].Design_Min;
                                    txbDesignMax.Text = Program.ProjectList[CurrentProjectIndex].Design_Max;
                                    txbNormalSystem.Text = Program.ProjectList[CurrentProjectIndex].Normal_System;
                                    btnRelievingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    btnDesignMaxTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    btnDesignMinTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    btnOperatingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    btnNormalSystemTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    if (Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure == "")
                                        txbAtmPressure.Text = "14.696";
                                    else
                                        txbAtmPressure.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;

                                    if (Program.ProjectList[CurrentProjectIndex].Kc == "")
                                        txbKc.Text = "1";
                                    else
                                        txbKc.Text = Program.ProjectList[CurrentProjectIndex].Kc;
                                    txbSystemMAWP.Text = Program.ProjectList[CurrentProjectIndex].MAWP;
                                    btnSystemMAWPUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                    txbOperatingPressure.Text = Program.ProjectList[CurrentProjectIndex].Operating_Pressures; ;
                                    btnOperatingPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                    txbSetPressure.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                                    btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                    txbOverPressure.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                                    btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    btnAtmPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                                    if (Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent == "")
                                        txbOverPressurePercent.Text = "10";
                                    else
                                        txbOverPressurePercent.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent;
                                    txbOverPressure.Enabled = false;
                                    if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                        txbInletLoss.Text = "0";
                                    else
                                        txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                    btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    if (Program.ProjectList[CurrentProjectIndex].Built_Up == "")
                                        txbBuiltUp.Text = "0";
                                    else
                                        txbBuiltUp.Text = Program.ProjectList[CurrentProjectIndex].Built_Up;

                                    btnBuiltUpUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    if (Program.ProjectList[CurrentProjectIndex].Constant_Superimposed == "")
                                        txbConstantSuperimposed.Text = "0";
                                    else
                                        txbConstantSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                                    btnConstantSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    if (Program.ProjectList[CurrentProjectIndex].Variable_Superimposed == "")
                                        txbVaribleSuperimposed.Text = "0";
                                    else
                                        txbVaribleSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                                    btnVaribleSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    if (Program.ProjectList[CurrentProjectIndex].Total == "")
                                        txbTotalBackPressure.Text = "0";
                                    else
                                        txbTotalBackPressure.Text = Program.ProjectList[CurrentProjectIndex].Total;
                                    btnTotalBackPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    txbTotalBackPressure.Enabled = false;

                                    if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                        txbInletLoss.Text = "0";
                                    else
                                        txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                    btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                    txbInletLossPercent.Enabled = false;
                                    txbV90_Leave(sender, e);
                                    txbV1_Leave(sender, e);
                                    txbRelieving_Leave(sender, e);
                                    txbVaporFlowCapacity_Leave(sender, e);
                                    txbLiquidFlowCapacity_Leave(sender, e);
                                    txbSetPressure_Leave(sender, e);
                                    CheckAllValidation();
                                    if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageConfiguration")
                                    {
                                        pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionCheck.png");
                                        pageConfiguration.Image = Image.FromFile(Program.ImagesPath + "ConfigurationOn.png");
                                        pageConfiguration.Enabled = true;
                                        pageMain.SelectedPage = pageConfiguration;
                                        FillConfigurationPage();
                                    }
                                }
                            }
                            if (Formule2Phase == "C23")
                            {
                                grb2phaseFluidPropertiesC23.Location = new Point(grbFluidProperties.Location.X, grbFluidProperties.Location.Y);
                                grbFluidProperties.Visible = false;
                                grb2phaseFluidPropertiesC23.Visible = true;
                                grb2phaseFluidProperties.Visible = false;
                                grbFlowCapacity2Phase.Visible = false;
                                chbSelectionVIII.Visible = false;
                                grbTemperatures.Location = new Point(6, 265);
                                grbFlowCapacity.Location = new Point(6, 450);
                                grbFlowCapacity.Visible = true;
                                this.splitSizing.SplitterDistance = splitSizing.Height + 150;
                                lblViscosityCorrectionFactor.Visible = true;
                                lblKv.Visible = true;
                                txbKv.Visible = true;
                                lblDischargeCoefficient.Visible = true;
                                lblKd.Visible = true;
                                cmbKd.Visible = true;
                                cmbKd.SelectedIndex = 0;
                                lblNormalSystem.Visible = true;
                                txbNormalSystem.Visible = true;
                                btnNormalSystemTemp.Visible = true;
                                dgvProduct.Visible = false;
                                txbOverPressure.Enabled = false;
                                txbTotalBackPressure.Enabled = false;
                                txbInletLossPercent.Enabled = false;
                                txbKc.Enabled = false;
                                btnRequiredFlowCapacityUnit.Visible = true;
                                btnRequiredPressureFlowUnit.Visible = false;
                                Safety_2PhaseC23_KcValidation = true;
                                Safety_2PhaseC23_KdValidation = true;
                                Safety_2PhaseC23_KvValidation = true;
                                lblRequiredPressureFlow.Text = "Required Flow Capacity";
                                if (Program.ProjectList[CurrentProjectIndex].TableId == "")
                                {
                                    txbFluidName_2phase_C23.Text = "";
                                    txbVaporPressure.Text = "";
                                    txbLiquidDensity.Text = "";
                                    txbLiquidSpecific.Text = "";
                                    txbSpecificGravity.Text = "";
                                    txbMixDensity90.Text = "";
                                    txbSpVol90.Text = "";
                                    txbRelieving.Text = "";
                                    txbOperating.Text = "";
                                    txbDesignMin.Text = "";
                                    txbDesignMax.Text = "";
                                    txbNormalSystem.Text = "";
                                    txbSystemMAWP.Text = "";
                                    txbOperatingPressure.Text = "";
                                    txbOperatingPressure.Text = "";
                                    txbSetPressure.Text = "";
                                    txbOverPressure.Text = "";
                                    txbAtmPressure.Text = "14.696";
                                    txbOverPressurePercent.Text = "10";
                                    txbBuiltUp.Text = "0";
                                    txbConstantSuperimposed.Text = "0";
                                    txbVaribleSuperimposed.Text = "0";
                                    txbTotalBackPressure.Text = "0";
                                    txbInletLoss.Text = "0";
                                    txbKc.Text = "1";
                                    txbKv.Text = "1.0";
                                }
                                else
                                {
                                    object sender = null;
                                    EventArgs e = null;
                                    txbFluidName_2phase_C23.Text = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                                    txbVaporPressure.Text = Program.ProjectList[CurrentProjectIndex].VaporPressure;
                                    txbLiquidDensity.Text = Program.ProjectList[CurrentProjectIndex].LiquidDensity;
                                    txbLiquidSpecific.Text = Program.ProjectList[CurrentProjectIndex].LiquidSpecific;
                                    txbSpecificGravity.Text = Program.ProjectList[CurrentProjectIndex].SpesificGravity;
                                    txbMixDensity90.Text = Program.ProjectList[CurrentProjectIndex].MixDensity90;
                                    txbSpVol90.Text = Program.ProjectList[CurrentProjectIndex].SpVol90;
                                    btnVaporUnitC23.Text = Program.ProjectList[CurrentProjectIndex].VaporUnitC23;
                                    btnLiquidDensityUnit.Text = Program.ProjectList[CurrentProjectIndex].LiquidDensityUnit;
                                    btnMixDensity90Unit.Text = Program.ProjectList[CurrentProjectIndex].LiquidDensityUnit; ;
                                    btnLiquidSpecificUnit.Text = Program.ProjectList[CurrentProjectIndex].LiquidSpecificUnit;
                                    btnSpVol90Unit.Text = Program.ProjectList[CurrentProjectIndex].LiquidSpecificUnit;

                                    txbRelieving.Text = Program.ProjectList[CurrentProjectIndex].Relieving;
                                    txbOperating.Text = Program.ProjectList[CurrentProjectIndex].Operating;
                                    txbDesignMin.Text = Program.ProjectList[CurrentProjectIndex].Design_Min;
                                    txbDesignMax.Text = Program.ProjectList[CurrentProjectIndex].Design_Max;
                                    txbNormalSystem.Text = Program.ProjectList[CurrentProjectIndex].Normal_System;
                                    btnRelievingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    btnDesignMaxTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    btnDesignMinTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    btnOperatingTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    btnNormalSystemTemp.Text = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                                    if (Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure == "")
                                        txbAtmPressure.Text = "14.696";
                                    else
                                        txbAtmPressure.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;

                                    if (Program.ProjectList[CurrentProjectIndex].Kc == "")
                                        txbKc.Text = "1";
                                    else
                                        txbKc.Text = Program.ProjectList[CurrentProjectIndex].Kc;
                                    txbSystemMAWP.Text = Program.ProjectList[CurrentProjectIndex].MAWP;
                                    btnSystemMAWPUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                    txbOperatingPressure.Text = Program.ProjectList[CurrentProjectIndex].Operating_Pressures; ;
                                    btnOperatingPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                    txbSetPressure.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                                    btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                    txbOverPressure.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                                    btnSetPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    btnAtmPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                                    if (Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent == "")
                                        txbOverPressurePercent.Text = "10";
                                    else
                                        txbOverPressurePercent.Text = Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent;
                                    txbOverPressure.Enabled = false;
                                    if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                        txbInletLoss.Text = "0";
                                    else
                                        txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                    btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    if (Program.ProjectList[CurrentProjectIndex].Built_Up == "")
                                        txbBuiltUp.Text = "0";
                                    else
                                        txbBuiltUp.Text = Program.ProjectList[CurrentProjectIndex].Built_Up;

                                    btnBuiltUpUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    if (Program.ProjectList[CurrentProjectIndex].Constant_Superimposed == "")
                                        txbConstantSuperimposed.Text = "0";
                                    else
                                        txbConstantSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                                    btnConstantSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    if (Program.ProjectList[CurrentProjectIndex].Variable_Superimposed == "")
                                        txbVaribleSuperimposed.Text = "0";
                                    else
                                        txbVaribleSuperimposed.Text = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                                    btnVaribleSuperimposedUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    if (Program.ProjectList[CurrentProjectIndex].Total == "")
                                        txbTotalBackPressure.Text = "0";
                                    else
                                        txbTotalBackPressure.Text = Program.ProjectList[CurrentProjectIndex].Total;
                                    btnTotalBackPressureUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;

                                    txbTotalBackPressure.Enabled = false;

                                    if (Program.ProjectList[CurrentProjectIndex].Inlet_Loss == "")
                                        txbInletLoss.Text = "0";
                                    else
                                        txbInletLoss.Text = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                                    btnInletLossUnit.Text = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                                    txbInletLossPercent.Enabled = false;
                                    txbRequiredPressureFlow_Leave(sender, e);
                                    txbLiquidDensity_Leave(sender, e);
                                    txbMixDensity90_Leave(sender, e);
                                    txbRelieving_Leave(sender, e);
                                    txbVaporPressure_Leave(sender, e);
                                    txbSetPressure_Leave(sender, e);
                                    txbOverPressure_Leave(sender, e);
                                    CheckAllValidation();
                                    if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "pageConfiguration")
                                    {
                                        pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionCheck.png");
                                        pageConfiguration.Image = Image.FromFile(Program.ImagesPath + "ConfigurationOn.png");
                                        pageConfiguration.Enabled = true;
                                        pageMain.SelectedPage = pageConfiguration;
                                        FillConfigurationPage();
                                    }

                                }
                            }
                            break;
                        }
                }
            }
            catch
            {

            }

        }

        private void rbtOverPressurePercent_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtOverPressurePercent.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    txbOverPressurePercent.Enabled = true;
                if (rbtOverPressurePercent.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
                    txbOverPressurePercent.Enabled = false;
            }
            catch
            {

            }

        }

        private void rbtOverPressure_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtOverPressure.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    txbOverPressure.Enabled = true;
                if (rbtOverPressure.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
                    txbOverPressure.Enabled = false;
            }
            catch
            {

            }
        }

        private void rbtInletLossPercent_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtInletLossPercent.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    txbInletLossPercent.Enabled = true;
                if (rbtInletLossPercent.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
                    txbInletLossPercent.Enabled = false;
            }
            catch
            {

            }
        }

        private void rbtInletLoss_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtInletLoss.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    txbInletLoss.Enabled = true;
                if (rbtInletLoss.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
                    txbInletLoss.Enabled = false;
            }
            catch
            {

            }
        }

        private void CheckAllValidation()
        {
            try
            {
                switch (FluidType)
                {
                    case "Gas":
                        {
                            if (Safety_Gas_MolecularWeightValidation == true && Safety_Gas_KValidation == true && Safety_Gas_ComperesibilityValidation == true &&
                                Safety_Gas_RelievingValidation == true && Safety_Gas_RequiredPressureFlowValidation == true &&
                                Safety_Gas_SetPressureValidation == true && Safety_Gas_OverPressureValidation == true)
                            {
                                Calculate_A(FluidType);
                            }
                            else
                            {
                                dgvProduct.Visible = false;
                                // show error message - input invalid
                            }
                            break;
                        }
                    case "Liquid":
                        {
                            if (Safety_Liquid_SpecificGravityValidation == true && Safety_Liquid_ViscosityValidation == true && Safety_Liquid_RelievingValidation == true &&
                               Safety_Liquid_RequiredPressureFlowValidation == true && Safety_Liquid_OverPressureValidation == true)
                            {
                                Calculate_A(FluidType);
                            }
                            else
                            {
                                dgvProduct.Visible = false;
                                // show error message - input invalid
                            }
                            break;
                        }
                    case "Steam":
                        {
                            if (Safety_Steam_MolecularWeightValidation == true && Safety_Steam_KValidation == true && Safety_Steam_ComperesibilityValidation == true &&
                                Safety_Steam_RelievingValidation == true && Safety_Steam_RequiredPressureFlowValidation == true &&
                                Safety_Steam_SetPressureValidation == true && Safety_Steam_OverPressureValidation == true)
                            {
                                Calculate_A(FluidType);
                            }
                            else
                            {
                                dgvProduct.Visible = false;
                                // show error message - input invalid
                            }
                            break;
                        }
                    case "2-Phase":
                        {
                            if (Formule2Phase == "C22")
                            {
                                if (txbV90.Text != "" && txbV1.Text != "")
                                {


                                    double v90 = Convert.ToDouble(txbV90.Text);
                                    double v1 = Convert.ToDouble(txbV1.Text);
                                    if (v90 <= v1)
                                    {
                                        MessageBox.Show("Combined Sp. Vol @ 90% P1 must be greater than Combined Sp. Vol @ Inlet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                    if (Safety_2PhaseC22_V90Validation == true && Safety_2PhaseC22_V1Validation == true && Safety_2PhaseC22_RelievingValidation == true &&
                                    Safety_2PhaseC22_RequiredPressureFlowValidation == true && Safety_2PhaseC22_SetPressureValidation == true &&
                                    Safety_2PhaseC22_OverPressureValidation == true && Safety_2PhaseC22_KcValidation == true && Safety_2PhaseC22_KvValidation == true && Safety_2PhaseC22_KdValidation == true)
                                    {
                                        Calculate_A(FluidType);
                                    }
                                    else
                                    {
                                        dgvProduct.Visible = false;
                                        // show error message - input invalid
                                    }
                                }
                            }
                            if (Formule2Phase == "C23")
                            {
                                if (txbTotalBackPressure.Text != "" && txbSetPressure.Text != "")
                                {


                                    double tb = Convert.ToDouble(txbTotalBackPressure.Text);
                                    double sp = Convert.ToDouble(txbSetPressure.Text);
                                    if (sp <= 0)
                                    {
                                        MessageBox.Show("Set Pressure must be greater than Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                    if (tb <= 0)
                                    {
                                        MessageBox.Show("Total Back Pressure must be greater than Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                    if (Safety_2PhaseC23_VaporPerssureValidation == true && Safety_2PhaseC23_LiquidDensityValidation == true && Safety_2PhaseC23_MixDensityValidation == true &&
                                    Safety_2PhaseC23_RelievingValidation == true && Safety_2PhaseC23_RequiredPressureFlowValidation == true &&
                                    Safety_2PhaseC23_SetPressureValidation == true && Safety_2PhaseC23_OverPressureValidation == true &&
                                    Safety_2PhaseC23_KcValidation == true && Safety_2PhaseC23_KvValidation == true && Safety_2PhaseC23_KdValidation == true)
                                    {
                                        Calculate_A(FluidType);
                                    }
                                    else
                                    {
                                        dgvProduct.Visible = false;
                                        // show error message - input invalid
                                    }
                                }
                            }
                            break;
                        }
                }
            }
            catch
            {

            }

        }

        private void txbMolecularWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbMolecularWeight.Text.Trim());
                if (!Validation)
                {
                    txbMolecularWeight.Text = "";
                    if (FluidType == "Gas")
                        Safety_Gas_MolecularWeightValidation = false;
                    if (FluidType == "Liquid")
                        Safety_Liquid_SpecificGravityValidation = false;
                    if (FluidType == "Steam")
                        Safety_Steam_MolecularWeightValidation = false;
                    lblMolecularWeight.ForeColor = Color.Navy;
                }
                else
                {
                    if (FluidType == "Gas")
                    {
                        Safety_Gas_MolecularWeightValidation = true;
                        Program.ProjectList[CurrentProjectIndex].Molecular_Weight = txbMolecularWeight.Text.Trim();
                    }
                    if (FluidType == "Liquid")
                    {
                        Safety_Liquid_SpecificGravityValidation = true;
                        Program.ProjectList[CurrentProjectIndex].SpesificGravity = txbMolecularWeight.Text.Trim();
                    }
                    if (FluidType == "Steam")
                    {
                        Safety_Steam_MolecularWeightValidation = true;
                        Program.ProjectList[CurrentProjectIndex].Molecular_Weight = txbMolecularWeight.Text.Trim();
                    }
                    lblMolecularWeight.ForeColor = Color.Black;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbK_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbK.Text.Trim());
                if (!Validation)
                {
                    txbK.Text = "";
                    if (FluidType == "Gas")
                        Safety_Gas_KValidation = false;
                    if (FluidType == "Liquid")
                        Safety_Liquid_ViscosityValidation = false;
                    if (FluidType == "Steam")
                        Safety_Steam_KValidation = false;
                    lblK.ForeColor = Color.Navy;
                }
                else
                {
                    lblK.ForeColor = Color.Black;
                    if (FluidType == "Gas")
                    {
                        Safety_Gas_KValidation = true;
                        Program.ProjectList[CurrentProjectIndex].k = txbK.Text.Trim();
                    }
                    if (FluidType == "Liquid")
                    {
                        Safety_Liquid_ViscosityValidation = true;
                        Program.ProjectList[CurrentProjectIndex].Viscosity = txbK.Text.Trim();
                    }
                    if (FluidType == "Steam")
                    {
                        Safety_Steam_KValidation = true;
                        Program.ProjectList[CurrentProjectIndex].k = txbK.Text.Trim();
                    }
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }

        }

        private void txbCompressibility_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbCompressibility.Text.Trim());
                if (!Validation)
                {
                    txbCompressibility.Text = "";
                    if (FluidType == "Gas")
                        Safety_Gas_ComperesibilityValidation = false;
                    if (FluidType == "Steam")
                        Safety_Steam_ComperesibilityValidation = false;
                    lblCompressibility.ForeColor = Color.Navy;

                }
                else
                {
                    lblCompressibility.ForeColor = Color.Black;
                    if (FluidType == "Gas")
                    {
                        Safety_Gas_ComperesibilityValidation = true;
                        Program.ProjectList[CurrentProjectIndex].Compressibility = txbCompressibility.Text.Trim();
                    }
                    if (FluidType == "Steam")
                    {
                        Safety_Steam_ComperesibilityValidation = true;
                        Program.ProjectList[CurrentProjectIndex].Compressibility = txbCompressibility.Text.Trim();
                    }
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbRelieving_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbRelieving.Text.Trim());
                if (!Validation)
                {
                    txbRelieving.Text = "";
                    lblRelieving.ForeColor = Color.Navy;
                    if (FluidType == "Gas")
                        Safety_Gas_RelievingValidation = false;
                    if (FluidType == "Liquid")
                        Safety_Liquid_RelievingValidation = false;
                    if (FluidType == "Steam")
                        Safety_Steam_RelievingValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_RelievingValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_RelievingValidation = false;
                }
                else
                {
                    lblRelieving.ForeColor = Color.Black;
                    if (FluidType == "Gas")
                        Safety_Gas_RelievingValidation = true;
                    if (FluidType == "Liquid")
                        Safety_Liquid_RelievingValidation = true;
                    if (FluidType == "Steam")
                        Safety_Steam_RelievingValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_RelievingValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_RelievingValidation = true;
                    Program.ProjectList[CurrentProjectIndex].Relieving = txbRelieving.Text.Trim();
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    //FillBodyMaterial();
                    CheckAllValidation();

                }
            }
            catch
            {

            }
        }

        private void txbOperating_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbOperating.Text.Trim());
                if (!Validation)
                    txbOperating.Text = "";
                Program.ProjectList[CurrentProjectIndex].Operating = txbOperating.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbDesignMin_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbDesignMin.Text.Trim());
                if (!Validation)
                    txbDesignMin.Text = "";
                Program.ProjectList[CurrentProjectIndex].Design_Min = txbDesignMin.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbDesignMax_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbDesignMax.Text.Trim());
                if (!Validation)
                    txbDesignMax.Text = "";
                Program.ProjectList[CurrentProjectIndex].Design_Max = txbDesignMax.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbNormalSystem_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbNormalSystem.Text.Trim());
                if (!Validation)
                    txbNormalSystem.Text = "";
                Program.ProjectList[CurrentProjectIndex].Normal_System = txbNormalSystem.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbAtmPressure_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbAtmPressure.Text.Trim());
                if (!Validation)
                    txbAtmPressure.Text = "";
                Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure = txbAtmPressure.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbSystemMAWP_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbSystemMAWP.Text.Trim());
                if (!Validation)
                    txbSystemMAWP.Text = "";
                Program.ProjectList[CurrentProjectIndex].MAWP = txbSystemMAWP.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbOperatingPressure_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbOperatingPressure.Text.Trim());
                if (!Validation)
                    txbOperatingPressure.Text = "";
                Program.ProjectList[CurrentProjectIndex].Operating_Pressures = txbOperatingPressure.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbSetPressure_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbSetPressure.Text.Trim());
                if (!Validation)
                {
                    txbSetPressure.Text = "";
                    lblSetPressure.ForeColor = Color.Navy;
                    if (FluidType == "Gas")
                        Safety_Gas_SetPressureValidation = false;
                    if (FluidType == "Liquid")
                        Safety_Liquid_SetPressureValidation = false;
                    if (FluidType == "Steam")
                        Safety_Steam_SetPressureValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_SetPressureValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_SetPressureValidation = false;
                }
                else
                {
                    lblSetPressure.ForeColor = Color.Black;
                    if (FluidType == "Gas")
                        Safety_Gas_SetPressureValidation = true;
                    if (FluidType == "Liquid")
                        Safety_Liquid_SetPressureValidation = true;
                    if (FluidType == "Steam")
                        Safety_Steam_SetPressureValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_SetPressureValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_SetPressureValidation = true;

                    Program.ProjectList[CurrentProjectIndex].SET_PRESSURE = txbSetPressure.Text.Trim();
                    CalculateOverPressure();
                    if (FluidType == "Gas")
                        Safety_Gas_OverPressureValidation = true;
                    if (FluidType == "Liquid")
                        Safety_Liquid_OverPressureValidation = true;
                    if (FluidType == "Steam")
                        Safety_Steam_OverPressureValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_OverPressureValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_OverPressureValidation = true;
                    Program.ProjectList[CurrentProjectIndex].Over_Pressure = txbOverPressure.Text.Trim();
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbOverPressurePercent_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbOverPressurePercent.Text.Trim());
                if (!Validation)
                {
                    txbOverPressurePercent.Text = "";
                    CalculateOverPressure();
                    if (FluidType == "Gas")
                        Safety_Gas_OverPressureValidation = false;
                    if (FluidType == "Liquid")
                        Safety_Liquid_OverPressureValidation = false;
                    if (FluidType == "Steam")
                        Safety_Steam_OverPressureValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_OverPressureValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_OverPressureValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    CalculateOverPressure();
                    if (FluidType == "Gas")
                        Safety_Gas_OverPressureValidation = true;
                    if (FluidType == "Liquid")
                        Safety_Liquid_OverPressureValidation = true;
                    if (FluidType == "Steam")
                        Safety_Steam_OverPressureValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_OverPressureValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_OverPressureValidation = true;
                    Program.ProjectList[CurrentProjectIndex].Over_Pressure_Percent = txbOverPressurePercent.Text.Trim();
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbOverPressure_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbOverPressure.Text.Trim());
                if (!Validation)
                {
                    txbOverPressure.Text = "";
                    rbtOverPressure.ForeColor = Color.Navy;
                    CalculateOverPressure();
                    if (FluidType == "Gas")
                        Safety_Gas_OverPressureValidation = false;
                    if (FluidType == "Liquid")
                        Safety_Liquid_OverPressureValidation = false;
                    if (FluidType == "Steam")
                        Safety_Steam_OverPressureValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_OverPressureValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_OverPressureValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    rbtOverPressure.ForeColor = Color.Black;
                    CalculateOverPressure();
                    if (FluidType == "Gas")
                        Safety_Gas_OverPressureValidation = true;
                    if (FluidType == "Liquid")
                        Safety_Liquid_OverPressureValidation = true;
                    if (FluidType == "Steam")
                        Safety_Steam_OverPressureValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_OverPressureValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_OverPressureValidation = true;
                    Program.ProjectList[CurrentProjectIndex].Over_Pressure = txbOverPressure.Text.Trim();
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbBuiltUp_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbBuiltUp.Text.Trim());
                if (!Validation)
                    txbBuiltUp.Text = "0";

                txbTotalBackPressure.Text = (Convert.ToDouble(txbBuiltUp.Text) + Convert.ToDouble(txbConstantSuperimposed.Text) + Convert.ToDouble(txbVaribleSuperimposed.Text)).ToString();
                Program.ProjectList[CurrentProjectIndex].Built_Up = txbBuiltUp.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Total = txbTotalBackPressure.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbConstantSuperimposed_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbConstantSuperimposed.Text.Trim());
                if (!Validation)
                    txbConstantSuperimposed.Text = "0";

                txbTotalBackPressure.Text = (Convert.ToDouble(txbBuiltUp.Text) + Convert.ToDouble(txbConstantSuperimposed.Text) + Convert.ToDouble(txbVaribleSuperimposed.Text)).ToString();
                Program.ProjectList[CurrentProjectIndex].Constant_Superimposed = txbConstantSuperimposed.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Total = txbTotalBackPressure.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }

        }

        private void txbVaribleSuperimposed_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbVaribleSuperimposed.Text.Trim());
                if (!Validation)
                    txbVaribleSuperimposed.Text = "0";

                txbTotalBackPressure.Text = (Convert.ToDouble(txbBuiltUp.Text) + Convert.ToDouble(txbConstantSuperimposed.Text) + Convert.ToDouble(txbVaribleSuperimposed.Text)).ToString();
                Program.ProjectList[CurrentProjectIndex].Variable_Superimposed = txbVaribleSuperimposed.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Total = txbTotalBackPressure.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

       
        private void txbInletLossPercent_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbInletLossPercent.Text.Trim());
                if (!Validation)
                    txbInletLossPercent.Text = "";
                CalculateInletLoss();
                Program.ProjectList[CurrentProjectIndex].Inlet_Loss_Percent = txbInletLossPercent.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbInletLoss_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbInletLoss.Text.Trim());
                if (!Validation)
                    txbInletLoss.Text = "";
                CalculateInletLoss();
                Program.ProjectList[CurrentProjectIndex].Inlet_Loss = txbInletLoss.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Inlet_Loss_Percent = txbInletLossPercent.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbRequiredPressureFlow_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbRequiredPressureFlow.Text.Trim());
                if (!Validation)
                {
                    txbRequiredPressureFlow.Text = "";
                    lblRequiredPressureFlow.ForeColor = Color.Navy;
                    if (FluidType == "Gas")
                        Safety_Gas_RequiredPressureFlowValidation = false;
                    if (FluidType == "Liquid")
                        Safety_Liquid_RequiredPressureFlowValidation = false;
                    if (FluidType == "Steam")
                        Safety_Steam_RequiredPressureFlowValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_RequiredPressureFlowValidation = false;
                }
                else
                {
                    lblRequiredPressureFlow.ForeColor = Color.Black;
                    if (FluidType == "Gas")
                        Safety_Gas_RequiredPressureFlowValidation = true;
                    if (FluidType == "Liquid")
                        Safety_Liquid_RequiredPressureFlowValidation = true;
                    if (FluidType == "Steam")
                        Safety_Steam_RequiredPressureFlowValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_RequiredPressureFlowValidation = true;
                    Program.ProjectList[CurrentProjectIndex].Flow_Required = txbRequiredPressureFlow.Text.Trim();
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbKc_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbKc.Text.Trim());
                if (!Validation)
                    txbKc.Text = "";
                Program.ProjectList[CurrentProjectIndex].Kc = txbKc.Text.Trim();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void chbHasRuptureDisk_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbHasRuptureDisk.CheckState == CheckState.Checked)
                {
                    txbKc.Text = "0.9";
                    txbKc.Enabled = true;
                    Program.ProjectList[CurrentProjectIndex].HasRuptureDisk = true;
                }
                if (chbHasRuptureDisk.CheckState == CheckState.Unchecked)
                {
                    txbKc.Text = "1";
                    txbKc.Enabled = false;
                    Program.ProjectList[CurrentProjectIndex].HasRuptureDisk = false;
                }
            }
            catch
            {

            }

        }

        private void Calculate_A(string FliudType)
        {
            try
            {
                switch (FluidType)
                {
                    case "Gas":
                        decimal A = BL.Calculate_A_For_Gas(CurrentProjectIndex, txbMolecularWeight.Text, txbK.Text, txbCompressibility.Text,
                                                           txbRelieving.Text, btnRelievingTemp.Text, txbRequiredPressureFlow.Text,
                                                           btnRequiredPressureFlowUnit.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text,
                                                           txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text,
                                                           txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                           btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text, cmbKd.Text);
                        FillDataGridView(A);
                        break;
                    case "Liquid":
                        List<string> A2_1 = BL.Calculate_A_For_Liquid_With_Kw_1(CurrentProjectIndex, txbMolecularWeight.Text, txbK.Text,
                                                           txbRelieving.Text, btnRelievingTemp.Text, txbRequiredPressureFlow.Text,
                                                           btnRequiredFlowCapacityUnit.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text,
                                                           txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text,
                                                           txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                           btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text, cmbKd.Text);

                        List<string> A2_2 = BL.Calculate_A_For_Liquid_With_Kw_No_1(CurrentProjectIndex, txbMolecularWeight.Text, txbK.Text,
                                                                               txbRelieving.Text, btnRelievingTemp.Text, txbRequiredPressureFlow.Text,
                                                                               btnRequiredFlowCapacityUnit.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text,
                                                                               txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text,
                                                                               txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                                               btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text, cmbKd.Text);
                        if (A2_1 != null)
                            FillDataGridView(A2_1, 1);
                        if (A2_2 != null)
                            FillDataGridView(A2_2, 2);

                        break;
                    case "Steam":
                        decimal A3 = BL.Calculate_A_For_Steam(CurrentProjectIndex, txbMolecularWeight.Text, txbK.Text, txbCompressibility.Text,
                                                           txbRelieving.Text, btnRelievingTemp.Text, txbRequiredPressureFlow.Text,
                                                           btnRequiredPressureFlowUnit.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text,
                                                           txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text,
                                                           txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                           btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text, cmbKd.Text);
                        if (A3 == 0)
                            MessageBox.Show("This Fluid is not Steam", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            FillDataGridView(A3);
                        break;
                    case "2-Phase":
                        if (Formule2Phase == "C22")
                        {
                            decimal A4 = BL.Calculate_A_For_2Phase_C22(CurrentProjectIndex, txbRequiredPressureFlow2Phase.Text, btnRequiredFlow2PhaseUnit.Text, txbV90.Text, btnV90.Text,
                                                                                   txbRelieving.Text, btnRelievingTemp.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbV1.Text, btnVinletUnit.Text,
                                                                                   txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text, txbKv.Text, cmbKd.Text,
                                                                                   txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                                                   btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text);
                            FillDataGridView(A4);
                        }
                        if (Formule2Phase == "C23")
                        {

                            decimal A4 = BL.Calculate_A_For_2Phase_C23(CurrentProjectIndex, txbLiquidDensity.Text, btnLiquidDensityUnit.Text, txbMixDensity90.Text, btnMixDensity90Unit.Text,
                                                                                   txbRelieving.Text, btnRelievingTemp.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbVaporPressure.Text,
                                                                                   txbRequiredPressureFlow.Text, txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text,
                                                                                   txbKv.Text, cmbKd.Text, btnRequiredPressureFlowUnit.Text, txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                                                   btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text);
                            FillDataGridView(A4);

                        }
                        break;
                }
            }
            catch
            {

            }

        }

        private void CalculateOverPressure()
        {
            try
            {
                if (rbtOverPressurePercent.CheckState == CheckState.Checked)
                {
                    if (txbSetPressure.Text != "" && txbOverPressurePercent.Text != "")
                        txbOverPressure.Text = ((Convert.ToDecimal(txbSetPressure.Text) * Convert.ToDecimal(txbOverPressurePercent.Text) / 100)).ToString();
                }
                if (rbtOverPressure.CheckState == CheckState.Checked)
                {
                    if (txbOverPressure.Text != "" && txbSetPressure.Text != "")
                        txbOverPressurePercent.Text = ((Convert.ToDecimal(txbOverPressure.Text) / Convert.ToDecimal(txbSetPressure.Text)) * 100).ToString();
                }
            }
            catch
            {

            }
        }

        private void CalculateInletLoss()
        {
            try
            {
                if (rbtInletLossPercent.CheckState == CheckState.Checked)
                {
                    if (txbSetPressure.Text != "" && txbInletLossPercent.Text != "")
                        txbInletLoss.Text = ((Convert.ToDecimal(txbSetPressure.Text) * Convert.ToDecimal(txbInletLossPercent.Text) / 100)).ToString();
                }
                if (rbtInletLoss.CheckState == CheckState.Checked)
                {
                    if (txbSetPressure.Text != "" && txbInletLoss.Text != "")
                        txbInletLossPercent.Text = ((Convert.ToDecimal(txbInletLoss.Text) * 100) / Convert.ToDecimal(txbSetPressure.Text)).ToString();
                }
            }
            catch
            {

            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CheckAllValidation();
        }

        private void FillDataGridView(List<string> A,int Kw)
        {
            try
            {
                dgvProduct.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                dgvProduct.ShowGroupPanel = false;
                dgvProduct.MasterTemplate.EnableGrouping = false;
                dgvProduct.EnableHotTracking = true;
                List<string> OrificeList = new List<string>();
                List<string> SeriesList = new List<string>();
                List<string> OrificeValueList = new List<string>();
                for (int i = 1; i < A.Count; i++)
                {
                    switch (A[i])
                    {
                        case "0.12167475665":
                            OrificeList.Add("D");
                            SeriesList.Add("A");
                            OrificeList.Add("D");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "0.284828437841985":
                            OrificeList.Add("E");
                            SeriesList.Add("A");
                            OrificeList.Add("E");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "0.33528695942474":
                            OrificeList.Add("F");
                            SeriesList.Add("A");
                            OrificeList.Add("F");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "0.54685502628776":
                            OrificeList.Add("G");
                            SeriesList.Add("A");
                            OrificeList.Add("G");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "0.86092190815274":
                            OrificeList.Add("H");
                            SeriesList.Add("A");
                            OrificeList.Add("H");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "1.406560186874":
                            OrificeList.Add("J");
                            SeriesList.Add("A");
                            OrificeList.Add("J");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "2.00563801871594":
                            OrificeList.Add("K");
                            SeriesList.Add("A");
                            OrificeList.Add("K");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "3.15236176276386":
                            OrificeList.Add("L");
                            SeriesList.Add("A");
                            OrificeList.Add("L");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "4.05090550567279":
                            OrificeList.Add("M");
                            SeriesList.Add("A");
                            OrificeList.Add("M");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "4.79865772266536":
                            OrificeList.Add("N");
                            SeriesList.Add("A");
                            OrificeList.Add("N");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "7.05570316544045":
                            OrificeList.Add("P");
                            SeriesList.Add("A");
                            OrificeList.Add("P");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "12.2161942375627":
                            OrificeList.Add("Q");
                            SeriesList.Add("A");
                            OrificeList.Add("Q");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "17.7849679974929":
                            OrificeList.Add("R");
                            SeriesList.Add("A");
                            OrificeList.Add("R");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;
                        case "28.8938732796379":
                            OrificeList.Add("T");
                            SeriesList.Add("A");
                            OrificeList.Add("T");
                            SeriesList.Add("M");
                            OrificeValueList.Add(A[i]);
                            OrificeValueList.Add(A[i]);
                            break;

                        case "0.122":
                            OrificeList.Add("I");
                            SeriesList.Add("D");
                            OrificeValueList.Add(A[i]);
                            break;
                        case "0.196":
                            OrificeList.Add("II");
                            SeriesList.Add("D");
                            OrificeValueList.Add(A[i]);
                            break;
                        case "0.307":
                            OrificeList.Add("III");
                            SeriesList.Add("D");
                            OrificeValueList.Add(A[i]);
                            break;
                        case "2.48":
                            OrificeList.Add("IV");
                            SeriesList.Add("D");
                            OrificeValueList.Add(A[i]);
                            break;
                        case "4.38":
                            OrificeList.Add("V");
                            SeriesList.Add("D");
                            OrificeValueList.Add(A[i]);
                            break;
                        case "6.67":
                            OrificeList.Add("VI");
                            SeriesList.Add("D");
                            OrificeValueList.Add(A[i]);
                            break;
                        case "10.3":
                            OrificeList.Add("VII");
                            SeriesList.Add("D");
                            OrificeValueList.Add(A[i]);
                            break;

                        case "0.07":
                            OrificeList.Add("6");
                            SeriesList.Add("R1");
                            OrificeValueList.Add(A[i]);
                            break;
                        case "0.169":
                            OrificeList.Add("7");
                            SeriesList.Add("R1");
                            OrificeValueList.Add(A[i]);
                            break;
                    }
                }
                dgvProduct.MasterTemplate.AllowAddNewRow = false;
                dgvProduct.MasterTemplate.AutoGenerateColumns = true;
                dgvProduct.TableElement.BeginUpdate();
                dgvProduct.Rows.Clear();

                for (int i = 0; i < OrificeList.Count; i++)
                {
                    string orif = OrificeList[i];
                    string series = SeriesList[i];
                    string orif_value = OrificeValueList[i];
                    string Q = "";
                    string Q_Converted = "";
                    string kw = Kw.ToString();
                    if (orif != "")
                    {
                        Q = BL.Calculate_Q_For_Liquid(orif_value, txbSetPressure.Text, btnSetPressureUnit.Text,
                                                      txbTotalBackPressure.Text, btnTotalBackPressureUnit.Text,
                                                      txbKc.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text,
                                                      txbOverPressure.Text, btnOverPressureUnit.Text, txbOverPressurePercent.Text,
                                                      txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text,
                                                      txbMolecularWeight.Text, cmbKd.Text);
                        Q_Converted = BL.ConvertUnit(Convert.ToDecimal(Q), "lb/hr", btnRequiredFlowCapacityUnit.Text).ToString();
                        if (Convert.ToDouble(txbBuiltUp.Text.Trim()) > (Convert.ToDouble(txbSetPressure.Text.Trim()) * 10 / 100))
                        {
                            dgvProduct.Rows.Add("Select", series, orif, "Bellows", orif_value, Q_Converted, kw);
                        }
                        else
                        {
                            if (Convert.ToDecimal(txbVaribleSuperimposed.Text.Trim()) != 0)
                            {
                                if (series == "M")
                                    dgvProduct.Rows.Add("Select", series, orif, "Pilot Operated", orif_value, Q_Converted, kw);
                                dgvProduct.Rows.Add("Select", series, orif, "Belows", orif_value, Q_Converted, kw);
                                dgvProduct.Rows.Add("Select", series, orif, "Piston", orif_value, Q_Converted, kw);
                            }
                            else if (Convert.ToDecimal(txbVaribleSuperimposed.Text.Trim()) == 0)
                            {
                                if (series == "M")
                                    dgvProduct.Rows.Add("Select", series, orif, "Pilot Operated", orif_value, Q_Converted, kw);
                                dgvProduct.Rows.Add("Select", series, orif, "Bellows", orif_value, Q_Converted, kw);
                                dgvProduct.Rows.Add("Select", series, orif, "Conventional", orif_value, Q_Converted, kw);
                                dgvProduct.Rows.Add("Select", series, orif, "Piston", orif_value, Q_Converted, kw);
                            }
                        }
                    }
                }
                dgvProduct.Columns["clmRatedFlowCapacity"].HeaderText = "Rated Flow Capacity (" + btnRequiredFlowCapacityUnit.Text + ")";
                dgvProduct.AllowAddNewRow = false;
                dgvProduct.Visible = true;
                dgvProduct.Refresh();
                dgvProduct.TableElement.EndUpdate(true);
            }
            catch
            {

            }

        }
        private void FillDataGridView(decimal A)
        {
            try
            {
                dgvProduct.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                dgvProduct.ShowGroupPanel = false;
                dgvProduct.MasterTemplate.EnableGrouping = false;
                dgvProduct.EnableHotTracking = true;
                List<string> OrificeList = new List<string>();
                List<string> SeriesList = new List<string>();
                List<string> OrificeValueList = new List<string>();
                OrificeList = BL.GetOrifices(A);
                SeriesList = BL.GetSeries(A);
                OrificeValueList = BL.GetOrificesValue(A);
                dgvProduct.MasterTemplate.AllowAddNewRow = false;
                dgvProduct.MasterTemplate.AutoGenerateColumns = true;
                dgvProduct.TableElement.BeginUpdate();
                dgvProduct.Rows.Clear();
                decimal BuiltUp = Convert.ToDecimal(txbBuiltUp.Text.Trim());
                decimal SetPressure = Convert.ToDecimal(txbSetPressure.Text.Trim());
                decimal TenPercent = (SetPressure * 10) / 100;
                decimal VaribleSuperimposed = Convert.ToDecimal(txbVaribleSuperimposed.Text.Trim());
                for (int i = 0; i < OrificeList.Count; i++)
                {
                    string orif = OrificeList[i];
                    string series = SeriesList[i];
                    string orifValue = OrificeValueList[i];
                    string W = "";
                    string W_Converted = "";
                    if (FluidType == "Gas" && orifValue != "")
                    {
                        W = BL.Calculate_W_For_Gas(OrificeValueList[i], txbMolecularWeight.Text, txbK.Text, txbCompressibility.Text,
                                                           txbRelieving.Text, btnRelievingTemp.Text, txbRequiredPressureFlow.Text,
                                                           btnRequiredPressureFlowUnit.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text,
                                                           txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text,
                                                           txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                           btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text, cmbKd.Text);
                        W_Converted = BL.ConvertUnit(Convert.ToDecimal(W), "lb/hr", btnRequiredPressureFlowUnit.Text).ToString();
                        dgvProduct.Columns["clmRatedFlowCapacity"].HeaderText = "Rated Flow Capacity (" + btnRequiredPressureFlowUnit.Text + ")";
                    }
                    else if (FluidType == "Steam" && orifValue != "")
                    {
                        W = BL.Calculate_W_For_Steam(CurrentProjectIndex, OrificeValueList[i], txbMolecularWeight.Text, txbK.Text, txbCompressibility.Text,
                                                           txbRelieving.Text, btnRelievingTemp.Text, txbRequiredPressureFlow.Text,
                                                           btnRequiredPressureFlowUnit.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text,
                                                           txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text,
                                                           txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                           btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text, cmbKd.Text);
                        W_Converted = BL.ConvertUnit(Convert.ToDecimal(W), "lb/hr", btnRequiredPressureFlowUnit.Text).ToString();
                        dgvProduct.Columns["clmRatedFlowCapacity"].HeaderText = "Rated Flow Capacity (" + btnRequiredPressureFlowUnit.Text + ")";
                    }
                    else if (FluidType == "2-Phase" && orifValue != "")
                    {
                        if (Formule2Phase == "C22")
                        {
                            W = BL.Calculate_W_For_2Phase_C22(OrificeValueList[i], txbRequiredPressureFlow2Phase.Text, btnRequiredFlow2PhaseUnit.Text, txbV90.Text, btnV90.Text,
                                                                                   txbRelieving.Text, btnRelievingTemp.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbV1.Text, btnVinletUnit.Text,
                                                                                   txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text, txbKv.Text, cmbKd.Text,
                                                                                   txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                                                   btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text);
                            W_Converted = BL.ConvertUnit(Convert.ToDecimal(W), "lb/hr", btnRequiredFlow2PhaseUnit.Text).ToString();
                            dgvProduct.Columns["clmRatedFlowCapacity"].HeaderText = "Rated Flow Capacity (" + btnRequiredFlow2PhaseUnit.Text + ")";
                        }
                        if (Formule2Phase == "C23")
                        {
                            W = BL.Calculate_W_For_2Phase_C23(OrificeValueList[i], txbLiquidDensity.Text, btnLiquidDensityUnit.Text, txbMixDensity90.Text, btnMixDensity90Unit.Text,
                                                                                   txbRelieving.Text, btnRelievingTemp.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbVaporPressure.Text,
                                                                                   txbRequiredPressureFlow.Text, txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text,
                                                                                   txbKv.Text, cmbKd.Text, btnRequiredPressureFlowUnit.Text, txbOverPressure.Text, btnOverPressureUnit.Text, txbTotalBackPressure.Text,
                                                                                   btnTotalBackPressureUnit.Text, txbKc.Text, txbInletLoss.Text, txbInletLossPercent.Text, btnInletLossUnit.Text);
                            W_Converted = BL.ConvertUnit(Convert.ToDecimal(W), "lb/hr", btnRequiredFlowCapacityUnit.Text).ToString();
                            dgvProduct.Columns["clmRatedFlowCapacity"].HeaderText = "Rated Flow Capacity (" + btnRequiredFlowCapacityUnit.Text + ")";
                        }

                    }



                    switch (series)
                    {
                        case "M":
                            if (orif != "")
                            {
                                if (BuiltUp > TenPercent) { }
                                else
                                {
                                    dgvProduct.Rows.Add("Select", series, orif, "Pilot Operated Modulating", orifValue, W_Converted);
                                    dgvProduct.Rows.Add("Select", series, orif, "Pilot Operated Pop action", orifValue, W_Converted);
                                }

                            }
                            break;
                        case "A":
                        case "R1":
                        case "D":
                            if (orif != "")
                            {
                                if (BuiltUp > TenPercent)
                                {
                                    dgvProduct.Rows.Add("Select", series, orif, "Spring Loaded ,Balance Bellows", orifValue, W_Converted);
                                }
                                else
                                {
                                    if (VaribleSuperimposed != 0)
                                    {
                                        dgvProduct.Rows.Add("Select", series, orif, "Spring Loaded ,Balance Bellows", orifValue, W_Converted);
                                    }
                                    else if (VaribleSuperimposed == 0)
                                    {
                                        dgvProduct.Rows.Add("Select", series, orif, "Spring Loaded ,Balance Bellows", orifValue, W_Converted);
                                        dgvProduct.Rows.Add("Select", series, orif, "Spring Loaded ,Balance Piston", orifValue, W_Converted);
                                        dgvProduct.Rows.Add("Select", series, orif, "Spring Loaded ,Conventional", orifValue, W_Converted);
                                    }
                                }
                            }
                            break;
                    }
                }

                dgvProduct.AllowAddNewRow = false;
                dgvProduct.Visible = true;
                dgvProduct.Refresh();
                dgvProduct.TableElement.EndUpdate(true);
            }
            catch
            {

            }
        }

        private void pageSubConfiguration_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void dgvProduct_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Telerik.WinControls.UI.GridCommandCellElement cell = (Telerik.WinControls.UI.GridCommandCellElement)sender;
                int SelectedRowIndex = cell.RowIndex;
                SelectedOrifice = dgvProduct.Rows[SelectedRowIndex].Cells[2].Value.ToString();
                SelectedSeries = dgvProduct.Rows[SelectedRowIndex].Cells[1].Value.ToString();
                SelectedValveType = dgvProduct.Rows[SelectedRowIndex].Cells[3].Value.ToString();
                if (dgvProduct.Rows[SelectedRowIndex].Cells[4].Value != null)
                    SelectedOrificeArea = dgvProduct.Rows[SelectedRowIndex].Cells[4].Value.ToString();
                if (dgvProduct.Rows[SelectedRowIndex].Cells[5].Value != null)
                    SelectedFlowCapacity = dgvProduct.Rows[SelectedRowIndex].Cells[5].Value.ToString();


                Program.ProjectList[CurrentProjectIndex].Valve_Type = SelectedValveType;
                Program.ProjectList[CurrentProjectIndex].Series = SelectedSeries;
                Program.ProjectList[CurrentProjectIndex].Orifice = SelectedOrifice;
                Program.ProjectList[CurrentProjectIndex].Area_Selected = Math.Round(Convert.ToDouble(SelectedOrificeArea), 4).ToString();
                Program.ProjectList[CurrentProjectIndex].Flow_Actual = SelectedFlowCapacity;
                Program.ProjectList[CurrentProjectIndex].Orifice_Area = SelectedOrificeArea;
                Program.ProjectList[CurrentProjectIndex].Flow_Required = txbRequiredPressureFlow.Text;
                Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF = txbKc.Text;
                if (dgvProduct.Rows[SelectedRowIndex].Cells[6].Value != null)
                    Program.ProjectList[CurrentProjectIndex].Kw = dgvProduct.Rows[SelectedRowIndex].Cells[6].Value.ToString();

                pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionCheck.png");
                pageConfiguration.Image = Image.FromFile(Program.ImagesPath + "ConfigurationOn.png");
                pageConfiguration.Enabled = true;
                pageMain.SelectedPage = pageConfiguration;
                FillConfigurationPage();
            }
            catch
            {

            }
        }

        private void FillConfigurationPage()
        {
            try
            {
                if (Program.ProjectList[CurrentProjectIndex].TableId == "" || Program.ProjectList[CurrentProjectIndex].Valve_Model_No == "")
                {
                    Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name = "pageConfiguration";
                    Program.ProjectList[CurrentProjectIndex].SelectedSeries = SelectedSeries;
                    Program.ProjectList[CurrentProjectIndex].SelectedSeries = SelectedOrifice;
                    txbValveModel.Text = "Series " + SelectedSeries + " , " + FluidType + " Service , " + SelectedValveType;
                    Program.ProjectList[CurrentProjectIndex].Valve_Model_No = txbValveModel.Text;
                    if (FluidType == "Steam")
                        txbValveService.Text = txbSteamName.Text;
                    else if (cmbSizingBasis.SelectedIndex == 4)
                        txbValveService.Text = "";
                    else if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        txbValveService.Text = txbFluidName_2phase.Text;
                    else if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        txbValveService.Text = txbFluidName_2phase_C23.Text;
                    else
                    {
                        if (cmbFluidName.SelectedItem != null)
                            txbValveService.Text = cmbFluidName.SelectedItem.ToString();
                        else
                            txbValveService.Text = cmbFluidName.Text;
                    }
                    Program.ProjectList[CurrentProjectIndex].ValveService = txbValveService.Text;

                    txbCodeSection.Text = SelectedCodeSection;
                    Program.ProjectList[CurrentProjectIndex].CodeSection = txbCodeSection.Text;
                    txbCodeSection.ReadOnly = true;
                    txbValveOrifice.Text = SelectedOrifice + " Orifice";
                    Program.ProjectList[CurrentProjectIndex].ValveOrifice = txbValveOrifice.Text;
                    txbValveOrifice.ReadOnly = true;
                    FillSize();
                    //FillBodyMaterial();
                    FillSpringMaterial();
                    //FillDiskMaterial();
                    //FillSeat();
                    //FillAnsiFlangeRating();
                    FillFlangeFace();
                    FillInletConnection();
                    FillOutletConnection();
                    // SetAccessories();
                    pageSubConfiguration.SelectedPage = pageConfig;
                    CreateCatalogNumber();
                    CalculateNoise();
                    int bellows_index = SelectedValveType.IndexOf("Bellows");
                    if (SelectedSeries == "A" && bellows_index != -1)
                    {
                        lblBellowsMaterial.Enabled = true;
                        cmbBellowsMaterial.Enabled = true;
                        chbBellowsMaterial.Enabled = true;
                    }
                    else
                    {
                        lblBellowsMaterial.Enabled = false;
                        cmbBellowsMaterial.Enabled = false;
                        chbBellowsMaterial.Enabled = false;
                    }
                    /* RULE:1
                    According to API 526 safety valve sizing, Nuzzle must be full.  */
                    if (Program.ProjectList[CurrentProjectIndex].Sizing_Std == "API 520" &&
                        Program.ProjectList[CurrentProjectIndex].Safety_Relief == "Safety")
                    {
                        cmbNozzle.Items[1].Enabled = false;
                        cmbNozzle.SelectedIndex = 0;
                    }
                    /* End of RULE:1 */
                }
                else
                {
                    // Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name = "pageConfiguration";
                    SelectedSeries = Program.ProjectList[CurrentProjectIndex].Series;
                    SelectedOrifice = Program.ProjectList[CurrentProjectIndex].Orifice;
                    txbValveModel.Text = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                    txbValveService.Text = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                    txbCodeSection.Text = Program.ProjectList[CurrentProjectIndex].CodeSection;
                    txbValveOrifice.Text = Program.ProjectList[CurrentProjectIndex].ValveOrifice;
                    txbCodeSection.ReadOnly = true;
                    txbValveOrifice.ReadOnly = true;

                    FillSize();
                    if (Program.ProjectList[CurrentProjectIndex].Inlet_Size_Connection != "")
                        cmbSize.SelectedValue = Program.ProjectList[CurrentProjectIndex].Inlet_Size_Connection;

                    FillBodyMaterial();
                    if (Program.ProjectList[CurrentProjectIndex].BodyMaterial != "")
                        cmbBodyMaterial.SelectedIndex = cmbBodyMaterial.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].BodyMaterial);

                    FillSpringMaterial();
                    if (Program.ProjectList[CurrentProjectIndex].SpringMaterial != "")
                        cmbSpringMaterial.SelectedIndex = cmbSpringMaterial.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].SpringMaterial);

                    FillDiskMaterial();
                    if (Program.ProjectList[CurrentProjectIndex].TrimMaterial != "")
                        cmbDiskMaterial.SelectedIndex = cmbDiskMaterial.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].TrimMaterial);

                    FillAnsiFlangeRating();
                    if (Program.ProjectList[CurrentProjectIndex].ANSIFlangeRating != "")
                        cmbANSIFlangeRating.SelectedIndex = cmbANSIFlangeRating.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].ANSIFlangeRating);

                    FillFlangeFace();
                    if (Program.ProjectList[CurrentProjectIndex].FlangeFace != "")
                        cmbFlangeFace.SelectedIndex = cmbFlangeFace.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].FlangeFace);

                    FillInletConnection();
                    if (Program.ProjectList[CurrentProjectIndex].InletConnection != "")
                        cmbInletConnection.SelectedIndex = cmbInletConnection.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].InletConnection);

                    FillOutletConnection();
                    if (Program.ProjectList[CurrentProjectIndex].OutletConnection != "")
                        cmbOutletConnection.SelectedIndex = cmbOutletConnection.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].OutletConnection);

                    if (Program.ProjectList[CurrentProjectIndex].Seat != "")
                        cmbSeat.SelectedIndex = cmbSeat.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].Seat);

                    if (Program.ProjectList[CurrentProjectIndex].Nozzle != "")
                        cmbNozzle.SelectedIndex = cmbNozzle.Items.IndexOf(Program.ProjectList[CurrentProjectIndex].Nozzle);

                    SetAccessories();
                    SetCertificates();
                    pageSubConfiguration.SelectedPage = pageConfig;
                    CreateCatalogNumber();
                    CalculateNoise();

                }
            }
            catch
            {

            }
        }

        private void FillInletConnection()
        {
            try
            {
                cmbInletConnection.Items[0].Enabled = false;
                cmbInletConnection.Items[1].Enabled = false;
                cmbInletConnection.Items[2].Enabled = false;
                cmbInletConnection.Items[3].Enabled = false;
                cmbInletConnection.Items[4].Enabled = false;
                cmbInletConnection.Items[5].Enabled = false;
                cmbInletConnection.Items[6].Enabled = false;
                cmbInletConnection.Items[7].Enabled = false;
                cmbInletConnection.Items[8].Enabled = false;
                cmbInletConnection.Items[9].Enabled = false;
                cmbInletConnection.Items[10].Enabled = false;
                cmbInletConnection.Items[11].Enabled = false;
                cmbInletConnection.Items[12].Enabled = false;
                cmbInletConnection.Items[13].Enabled = false;
                cmbInletConnection.Items[14].Enabled = false;
                cmbInletConnection.Items[15].Enabled = false;
                cmbInletConnection.Items[16].Enabled = false;
                cmbInletConnection.Items[17].Enabled = false;
                cmbInletConnection.Items[18].Enabled = false;
                cmbInletConnection.Items[19].Enabled = false;
                cmbInletConnection.Items[20].Enabled = false;
                cmbInletConnection.Items[21].Enabled = false;

                switch (SelectedSeries)
                {
                    case "A":
                    case "M":
                        cmbInletConnection.Items[0].Enabled = true;
                        cmbInletConnection.Items[1].Enabled = true;
                        cmbInletConnection.Items[2].Enabled = true;
                        cmbInletConnection.Items[3].Enabled = true;
                        cmbInletConnection.Items[4].Enabled = true;
                        cmbInletConnection.Items[5].Enabled = true;
                        break;
                    case "D":
                        cmbInletConnection.Items[6].Enabled = true;
                        cmbInletConnection.Items[7].Enabled = true;
                        cmbInletConnection.Items[8].Enabled = true;
                        cmbInletConnection.Items[9].Enabled = true;
                        cmbInletConnection.Items[10].Enabled = true;
                        cmbInletConnection.Items[11].Enabled = true;
                        cmbInletConnection.Items[12].Enabled = true;
                        break;
                    case "R":
                    case "N":
                    case "R1":
                    case "R2":
                        cmbInletConnection.Items[13].Enabled = true;
                        cmbInletConnection.Items[14].Enabled = true;
                        cmbInletConnection.Items[15].Enabled = true;
                        cmbInletConnection.Items[16].Enabled = true;
                        cmbInletConnection.Items[17].Enabled = true;
                        cmbInletConnection.Items[8].Enabled = true;
                        break;
                    case "R3":
                        cmbInletConnection.Items[14].Enabled = true;
                        cmbInletConnection.Items[15].Enabled = true;
                        cmbInletConnection.Items[8].Enabled = true;
                        cmbInletConnection.Items[9].Enabled = true;
                        break;
                }
            }
            catch
            {

            }
        }

        private void FillOutletConnection()
        {
            try
            {
                cmbOutletConnection.Items[0].Enabled = false;
                cmbOutletConnection.Items[1].Enabled = false;
                cmbOutletConnection.Items[2].Enabled = false;
                cmbOutletConnection.Items[3].Enabled = false;
                cmbOutletConnection.Items[4].Enabled = false;
                cmbOutletConnection.Items[5].Enabled = false;
                cmbOutletConnection.Items[6].Enabled = false;
                cmbOutletConnection.Items[7].Enabled = false;
                cmbOutletConnection.Items[8].Enabled = false;
                cmbOutletConnection.Items[9].Enabled = false;
                cmbOutletConnection.Items[10].Enabled = false;

                switch (SelectedSeries)
                {
                    case "A":
                        cmbOutletConnection.Items[0].Enabled = true;
                        cmbOutletConnection.Items[1].Enabled = true;
                        break;
                    case "M":
                        cmbOutletConnection.Items[0].Enabled = true;
                        cmbOutletConnection.Items[1].Enabled = true;
                        cmbOutletConnection.Items[2].Enabled = true;
                        break;
                    case "D":
                        cmbOutletConnection.Items[3].Enabled = true;
                        cmbOutletConnection.Items[4].Enabled = true;
                        cmbOutletConnection.Items[5].Enabled = true;
                        cmbOutletConnection.Items[6].Enabled = true;
                        break;
                    case "N":
                    case "R":
                    case "R2":
                    case "R3":
                        cmbOutletConnection.Items[7].Enabled = true;
                        cmbOutletConnection.Items[8].Enabled = true;
                        cmbOutletConnection.Items[9].Enabled = true;
                        cmbOutletConnection.Items[10].Enabled = true;
                        break;
                    case "R1":
                        cmbOutletConnection.Items[8].Enabled = true;
                        cmbOutletConnection.Items[9].Enabled = true;
                        cmbOutletConnection.Items[10].Enabled = true;
                        break;
                }
            }
            catch
            {

            }
        }

        private void CalculateNoise()
        {
            try
            {
                if (FluidType == "Gas" || FluidType == "Steam")
                {
                    decimal l30 = BL.Calculate_L30_For_Gas(txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressure.Text, btnOverPressureUnit.Text,
                                                           txbOverPressurePercent.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbTotalBackPressure.Text,
                                                           btnTotalBackPressureUnit.Text, SelectedFlowCapacity, txbMolecularWeight.Text, txbK.Text,
                                                           txbRelieving.Text, btnRelievingTemp.Text, txbS.Text);
                    decimal l1 = BL.Calculate_L1_For_Gas(l30);
                    // decimal l1p = BL.Calculate_L1P_For_Gas(l1, txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressure.Text, btnOverPressureUnit.Text,
                    //                                        txbOverPressurePercent.Text, txbAtmPressure.Text, btnAtmPressureUnit.Text, txbTotalBackPressure.Text,
                    //                                       btnTotalBackPressureUnit.Text, SelectedFlowCapacity, txbMolecularWeight.Text, txbK.Text,
                    //                                       txbRelieving.Text, btnRelievingTemp.Text, txbDi.Text, txbS.Text);
                    txbL30m.Text = Math.Round(l30, 2).ToString();
                    txbL1m.Text = Math.Round(l1, 2).ToString();
                    // txbL1p.Text = Math.Round(l1p, 3).ToString();
                }
            }
            catch
            {

            }
        }

        private void FillSize()
        {
            try
            {
                cmbSize.Items[0].Enabled = false;
                cmbSize.Items[1].Enabled = false;
                cmbSize.Items[2].Enabled = false;
                cmbSize.Items[3].Enabled = false;
                cmbSize.Items[4].Enabled = false;
                cmbSize.Items[5].Enabled = false;
                cmbSize.Items[6].Enabled = false;
                cmbSize.Items[7].Enabled = false;
                cmbSize.Items[8].Enabled = false;
                cmbSize.Items[9].Enabled = false;
                cmbSize.Items[10].Enabled = false;
                cmbSize.Items[11].Enabled = false;
                cmbSize.Items[12].Enabled = false;
                cmbSize.Items[13].Enabled = false;
                cmbSize.Items[14].Enabled = false;
                cmbSize.Items[15].Enabled = false;
                cmbSize.Items[16].Enabled = false;
                cmbSize.Items[17].Enabled = false;
                cmbSize.Items[18].Enabled = false;
                cmbSize.Items[19].Enabled = false;
                cmbSize.Items[20].Enabled = false;
                switch (SelectedSeries)
                {
                    case "A":
                    case "M":
                        {
                            switch (SelectedOrifice)
                            {
                                case "D":
                                case "E":
                                    cmbSize.Items[0].Enabled = true;
                                    cmbSize.Items[1].Enabled = true;
                                    cmbSize.Items[2].Enabled = true;
                                    break;
                                case "F":
                                    cmbSize.Items[1].Enabled = true;
                                    cmbSize.Items[2].Enabled = true;
                                    break;
                                case "G":
                                case "H":
                                    cmbSize.Items[2].Enabled = true;
                                    cmbSize.Items[3].Enabled = true;
                                    break;
                                case "K":
                                    cmbSize.Items[4].Enabled = true;
                                    cmbSize.Items[5].Enabled = true;
                                    break;
                                case "L":
                                    cmbSize.Items[4].Enabled = true;
                                    cmbSize.Items[6].Enabled = true;
                                    break;
                                case "M":
                                case "N":
                                case "P":
                                    cmbSize.Items[6].Enabled = true;
                                    break;
                                case "Q":
                                    cmbSize.Items[7].Enabled = true;
                                    break;
                                case "R":
                                    cmbSize.Items[7].Enabled = true;
                                    cmbSize.Items[8].Enabled = true;
                                    break;
                                case "T":
                                    cmbSize.Items[9].Enabled = true;
                                    break;
                                case "J":
                                    cmbSize.Items[3].Enabled = true;
                                    cmbSize.Items[4].Enabled = true;
                                    break;
                            }
                            break;
                        }
                    case "R1":
                        {
                            switch (SelectedOrifice)
                            {
                                case "5":
                                case "6":
                                case "7":
                                    cmbSize.Items[10].Enabled = true;
                                    cmbSize.Items[11].Enabled = true;
                                    cmbSize.Items[12].Enabled = true;
                                    cmbSize.Items[18].Enabled = true;
                                    cmbSize.Items[19].Enabled = true;
                                    cmbSize.Items[20].Enabled = true;
                                    break;
                            }
                            break;
                        }
                    case "D":
                        {
                            switch (SelectedOrifice)
                            {
                                case "I":
                                    cmbSize.Items[13].Enabled = true;
                                    break;
                                case "II":
                                    cmbSize.Items[14].Enabled = true;
                                    break;
                                case "III":
                                    cmbSize.Items[15].Enabled = true;
                                    break;
                                case "IV":
                                    cmbSize.Items[3].Enabled = true;
                                    break;
                                case "V":
                                    cmbSize.Items[16].Enabled = true;
                                    break;
                                case "VI":
                                    cmbSize.Items[17].Enabled = true;
                                    break;
                                case "VII":
                                    cmbSize.Items[6].Enabled = true;
                                    break;
                            }
                            break;
                        }
                }
            }
            catch
            {

            }
        }

        private void BackingSizeCode(int SelectedSizeIndex)
        {
            try
            {
                switch (SelectedSeries)
                {
                    case "A":
                    case "M":
                        switch (SelectedSizeIndex)
                        {
                            case 0:
                                CreateCatalogNumber("1", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("2", 10, 1);
                                Selected_A = "2";
                                break;
                            case 1:
                                CreateCatalogNumber("1.1/2", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("2", 10, 1);
                                Selected_A = "2";
                                break;
                            case 2:
                                CreateCatalogNumber("1.1/2", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("3", 10, 1);
                                Selected_A = "3";
                                break;
                            case 3:
                                CreateCatalogNumber("2", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("3", 10, 1);
                                Selected_A = "3";
                                break;
                            case 4:
                                CreateCatalogNumber("3", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("4", 10, 1);
                                Selected_A = "4";
                                break;
                            case 5:
                                CreateCatalogNumber("3", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("6", 10, 1);
                                Selected_A = "6";
                                break;
                            case 6:
                                CreateCatalogNumber("4", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("6", 10, 1);
                                Selected_A = "6";
                                break;
                            case 7:
                                CreateCatalogNumber("6", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("8", 10, 1);
                                Selected_A = "8";
                                break;
                            case 8:
                                CreateCatalogNumber("6", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("10", 10, 1);
                                Selected_A = "10";
                                break;
                            case 9:
                                CreateCatalogNumber("8", 4, 1);
                                CreateCatalogNumber(SelectedOrifice, 9, 1);
                                CreateCatalogNumber("10", 10, 1);
                                Selected_A = "10";
                                break;
                        }
                        break;
                    case "R":
                    case "R1":
                        switch (SelectedSizeIndex)
                        {
                            case 10:
                                CreateCatalogNumber("2", 5, 1);
                                Selected_A = "1";
                                break;
                            case 11:
                                CreateCatalogNumber("3", 5, 1);
                                Selected_A = "1";
                                break;
                            case 12:
                                CreateCatalogNumber("4", 5, 1);
                                Selected_A = "1";
                                break;
                            case 18:
                                CreateCatalogNumber("0", 5, 1);
                                Selected_A = "1/2";
                                break;
                            case 19:
                                CreateCatalogNumber("1", 5, 1);
                                Selected_A = "1/2";
                                break;
                            case 20:
                                CreateCatalogNumber("X", 5, 1);
                                Selected_A = "";
                                break;
                        }
                        break;
                    case "D":
                        switch (SelectedSizeIndex)
                        {
                            case 0:
                                CreateCatalogNumber("1", 2, 1);
                                Selected_A = "2";
                                break;
                            case 13:
                                CreateCatalogNumber("2", 2, 1);
                                Selected_A = "1.5";
                                break;
                            case 14:
                                CreateCatalogNumber("3", 2, 1);
                                Selected_A = "2";
                                break;
                            case 15:
                                CreateCatalogNumber("4", 2, 1);
                                Selected_A = "2.5";
                                break;
                            case 3:
                                CreateCatalogNumber("5", 2, 1);
                                Selected_A = "3";
                                break;
                            case 16:
                                CreateCatalogNumber("6", 2, 1);
                                Selected_A = "4";
                                break;
                            case 17:
                                CreateCatalogNumber("7", 2, 1);
                                Selected_A = "5";
                                break;
                            case 6:
                                CreateCatalogNumber("8", 2, 1);
                                Selected_A = "6";
                                break;
                        }
                        break;
                }
            }
            catch
            {

            }
        }

        private void FillBodyMaterial()
        {
            try
            {
                if (Program.BodyMaterialsList.Count > 0)
                {
                    lblBodyMaterial.Enabled = true;
                    cmbBodyMaterial.Enabled = true;
                    chbBodyMaterial.Enabled = true;
                    decimal temp = BL.ConvertTempToCelsius(txbRelieving.Text, btnRelievingTemp.Text);
                    cmbBodyMaterial.Items.Clear();
                    for (int i = 0; i < Program.BodyMaterialsList.Count; i++)
                    {
                        Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                        string max_temp = Program.BodyMaterialsList[i].MaxTemp;
                        string BodyMaterial = Program.BodyMaterialsList[i].BodyMaterial;
                        string ReturnCode = Program.BodyMaterialsList[i].ReturnCode;
                        string Alias = Program.BodyMaterialsList[i].Alias;
                        string StandardName = Program.BodyMaterialsList[i].StandardName;
                        string Series = Program.BodyMaterialsList[i].Series;


                        item.Value = ReturnCode;
                        item.Text = Alias;
                        item.ForeColor = Color.Black;
                        if (max_temp != "NL")
                        {
                            if (temp > Convert.ToDecimal(max_temp))
                            {
                                item.ForeColor = Color.Gray;
                                item.Tag = "Limited-Temp";
                            }
                            else
                            {
                                item.ForeColor = Color.Black;
                                item.Tag = "";
                            }
                        }
                        if (Series == SelectedSeries)
                            cmbBodyMaterial.Items.Add(item);
                    }
                }
                else
                {
                    lblBodyMaterial.Enabled = false;
                    cmbBodyMaterial.Enabled = false;
                    chbBodyMaterial.Enabled = false;
                }
            }
            catch
            {

            }

        }

        private void FillSpringMaterial()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BL.GetSpringMaterial(SelectedSeries);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblSpringMaterial.Enabled = true;
                    cmbSpringMaterial.Enabled = true;
                    chbSpringMaterial.Enabled = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                        item.Value = dt.Rows[i]["ReturnCode"].ToString(); ;
                        item.Text = dt.Rows[i]["SpringMaterial"].ToString();
                        string series = dt.Rows[i]["Series"].ToString();
                        if (series == SelectedSeries)
                            cmbSpringMaterial.Items.Add(item);
                    }
                }
                else
                {
                    lblSpringMaterial.Enabled = false;
                    cmbSpringMaterial.Enabled = false;
                    chbSpringMaterial.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void FillDiskMaterial()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BL.GetDiskMaterial(SelectedSeries);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblDiskMaterial.Enabled = true;
                    cmbDiskMaterial.Enabled = true;
                    chbDiskMaterial.Enabled = true;

                    lblNozzleMaterial.Enabled = true;
                    cmbNozzleMaterial.Enabled = true;
                    chbNozzleMaterial.Enabled = true;

                    if (cmbDiskMaterial.Items.Count > 0)
                    {
                        cmbDiskMaterial.Items.Clear();
                        cmbNozzleMaterial.Items.Clear();
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                        Telerik.WinControls.UI.RadListDataItem item2 = new Telerik.WinControls.UI.RadListDataItem();
                        item.Value = dt.Rows[i]["ReturnCode"].ToString();
                        item.Text = dt.Rows[i]["Material"].ToString();
                        item2.Value = dt.Rows[i]["ReturnCode"].ToString();
                        item2.Text = dt.Rows[i]["Material"].ToString();
                        string max_temp = dt.Rows[i]["MaxTemp"].ToString();
                        string min_temp = dt.Rows[i]["MinTemp"].ToString();
                        decimal temp = BL.ConvertTempToCelsius(txbRelieving.Text, btnRelievingTemp.Text);
                        string series = dt.Rows[i]["Series"].ToString();
                        if (series == SelectedSeries)
                        {
                            if (min_temp != "NL" && max_temp != "NL")
                            {
                                if (temp >= Convert.ToDecimal(min_temp) && temp <= Convert.ToDecimal(max_temp))
                                {
                                    item.ForeColor = Color.Black;
                                    item.Tag = "";
                                    item2.ForeColor = Color.Black;
                                    item2.Tag = "";
                                }
                                else
                                {
                                    item.ForeColor = Color.Gray;
                                    item.Tag = "Limited-Temp";
                                    item2.ForeColor = Color.Gray;
                                    item2.Tag = "Limited-Temp";
                                }
                            }
                            cmbDiskMaterial.Items.Add(item);
                            cmbNozzleMaterial.Items.Add(item2);
                        }

                    }
                }
                else
                {
                    lblDiskMaterial.Enabled = false;
                    cmbDiskMaterial.Enabled = false;
                    chbDiskMaterial.Enabled = false;

                    lblNozzleMaterial.Enabled = false;
                    cmbNozzleMaterial.Enabled = false;
                    chbNozzleMaterial.Enabled = false;
                }
            }
            catch
            {

            }
        }

      
        private void FillSeat()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BL.GetSeat(SelectedSeries);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblSeat.Enabled = true;
                    cmbSeat.Enabled = true;
                    chbSeat.Enabled = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                        item.Value = dt.Rows[i]["ReturnCode"].ToString(); ;
                        item.Text = dt.Rows[i]["Seat"].ToString();
                        cmbSeat.Items.Add(item);
                    }
                }
                else
                {
                    lblSeat.Enabled = false;
                    cmbSeat.Enabled = false;
                    chbSeat.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void FillAnsiFlangeRating()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BL.GetAnsiFlangeRating(SelectedSeries);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblANSIFlangeRating.Enabled = true;
                    cmbANSIFlangeRating.Enabled = true;
                    chbANSIFlangeRating.Enabled = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                        item.Value = dt.Rows[i]["ReturnCode"].ToString(); ;
                        item.Text = dt.Rows[i]["Rating"].ToString();
                        cmbANSIFlangeRating.Items.Add(item);
                    }
                }
                else
                {
                    lblANSIFlangeRating.Enabled = false;
                    cmbANSIFlangeRating.Enabled = false;
                    chbANSIFlangeRating.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void FillFlangeFace()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BL.GetFlangeFace(SelectedSeries);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblFlangeFace.Enabled = true;
                    cmbFlangeFace.Enabled = true;
                    chbFlangeFace.Enabled = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                        item.Value = dt.Rows[i]["ReturnCode"].ToString(); ;
                        item.Text = dt.Rows[i]["FlangeFace"].ToString();
                        cmbFlangeFace.Items.Add(item);
                    }
                }
                else
                {
                    lblFlangeFace.Enabled = false;
                    cmbFlangeFace.Enabled = false;
                    chbFlangeFace.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void SetAccessories()
        {
            try
            {
                chbNACECompliance.Enabled = false;
                chbBonnetExtention.Enabled = false;
                chbOpenBonnet.Enabled = false;
                chbHeatingJacket.Enabled = false;


                chbRing.Enabled = false;
                chbAuxiliaryBackupPiston.Enabled = false;
                chbBackFlowPreventer.Enabled = false;
                chbBoltedCap.Enabled = false;
                chbCoolingHeatingCoils.Enabled = false;
                chbDomedCap.Enabled = false;
                chbExternalFilter.Enabled = false;
                chbFerrule.Enabled = false;
                chbFieldTestConnector.Enabled = false;
                chbGag.Enabled = false;
                chbLiquidDuty.Enabled = false;
                chbNACEMaterial.Enabled = false;
                chbOpenLever.Enabled = false;
                chbPackedLever.Enabled = false;
                chbRemotePressureSensing.Enabled = false;
                chbRemoteUnloader.Enabled = false;
                chbResilientSeat.Enabled = false;
                chbScrewedCap.Enabled = false;
                chbSpecialFeatures.Enabled = false;
                chbTestGag.Enabled = false;
                chbHighPressure.Enabled = false;


                switch (SelectedSeries)
                {
                    case "A":
                        //chbScrewedCap.Enabled = true;
                        chbBoltedCap.Enabled = true;
                        chbAuxiliaryBackupPiston.Enabled = true;
                        chbTestGag.Enabled = true;
                        //chbHighPressure.Enabled = true;
                        chbOpenLever.Enabled = true;
                        chbPackedLever.Enabled = true;
                        chbSpecialFeatures.Enabled = true;
                        chbNACECompliance.Enabled = true;
                        chbBonnetExtention.Enabled = true;
                        chbOpenBonnet.Enabled = true;
                        chbHeatingJacket.Enabled = true;
                        break;
                    case "D":
                        chbDomedCap.Enabled = true;
                        chbFerrule.Enabled = true;
                        chbGag.Enabled = true;
                        chbOpenLever.Enabled = true;
                        chbPackedLever.Enabled = true;
                        chbNACEMaterial.Enabled = true;
                        chbResilientSeat.Enabled = true;
                        chbHighPressure.Enabled = true;
                        chbSpecialFeatures.Enabled = true;
                        break;
                    case "M":
                        chbRemotePressureSensing.Enabled = true;
                        chbBackFlowPreventer.Enabled = true;
                        chbCoolingHeatingCoils.Enabled = true;
                        chbScrewedCap.Enabled = true;
                        chbExternalFilter.Enabled = true;
                        chbTestGag.Enabled = true;
                        chbLiquidDuty.Enabled = true;
                        chbPackedLever.Enabled = true;
                        chbFieldTestConnector.Enabled = true;
                        chbRemoteUnloader.Enabled = true;
                        chbSpecialFeatures.Enabled = true;
                        break;
                    case "R1":
                        chbNACECompliance.Enabled = true;
                        chbPackedLever.Enabled = true;
                        chbTestGag.Enabled = true;
                        chbSpecialFeatures.Enabled = true;
                        chbRing.Enabled = true;
                        break;
                }
                if (Program.ProjectList[CurrentProjectIndex].TableId != "")
                {
                    chbAuxiliaryBackupPiston.Checked = Program.ProjectList[CurrentProjectIndex].chbAuxiliaryBackupPiston;
                    chbBackFlowPreventer.Checked = Program.ProjectList[CurrentProjectIndex].chbBackFlowPreventer;
                    chbBoltedCap.Checked = Program.ProjectList[CurrentProjectIndex].chbBoltedCap;
                    chbCoolingHeatingCoils.Checked = Program.ProjectList[CurrentProjectIndex].chbCoolingHeatingCoils;
                    chbDomedCap.Checked = Program.ProjectList[CurrentProjectIndex].chbDomedCap;
                    chbExternalFilter.Checked = Program.ProjectList[CurrentProjectIndex].chbExternalFilter;
                    chbFerrule.Checked = Program.ProjectList[CurrentProjectIndex].chbFerrule;
                    chbFieldTestConnector.Checked = Program.ProjectList[CurrentProjectIndex].chbFieldTestConnector;
                    chbGag.Checked = Program.ProjectList[CurrentProjectIndex].chbGag;
                    chbLiquidDuty.Checked = Program.ProjectList[CurrentProjectIndex].chbLiquidDuty;
                    chbNACEMaterial.Checked = Program.ProjectList[CurrentProjectIndex].chbNACEMaterial;
                    chbOpenLever.Checked = Program.ProjectList[CurrentProjectIndex].chbOpenLever;
                    chbPackedLever.Checked = Program.ProjectList[CurrentProjectIndex].chbPackedLever;
                    chbRemotePressureSensing.Checked = Program.ProjectList[CurrentProjectIndex].chbRemotePressureSensing;
                    chbRemoteUnloader.Checked = Program.ProjectList[CurrentProjectIndex].chbRemoteUnloader;
                    chbResilientSeat.Checked = Program.ProjectList[CurrentProjectIndex].chbResilientSeat;
                    chbScrewedCap.Checked = Program.ProjectList[CurrentProjectIndex].chbScrewedCap;
                    chbSpecialFeatures.Checked = Program.ProjectList[CurrentProjectIndex].chbSpecialFeatures;
                    chbTestGag.Checked = Program.ProjectList[CurrentProjectIndex].chbTestGag;
                    chbHighPressure.Checked = Program.ProjectList[CurrentProjectIndex].chbHighPressure;
                    chbRing.Checked = Program.ProjectList[CurrentProjectIndex].chbRing;
                    chbNACECompliance.Checked = Program.ProjectList[CurrentProjectIndex].chbNACECompliance;
                    chbBonnetExtention.Checked = Program.ProjectList[CurrentProjectIndex].chbBonnetExtention;
                    chbOpenBonnet.Checked = Program.ProjectList[CurrentProjectIndex].chbOpenBonnet;
                    chbHeatingJacket.Checked = Program.ProjectList[CurrentProjectIndex].chbHeatingJacket;
                }
            }
            catch
            {

            }
        }

        private void SetCertificates()
        {
            try
            {
                chbStandardCertificateOrigin.Checked = Program.ProjectList[CurrentProjectIndex].chbStandardCertificateOrigin;
                chbCertificateConformancePurchaseOrder.Checked = Program.ProjectList[CurrentProjectIndex].chbCertificateConformancePurchaseOrder;
                chbCertificateConformanceNACE_MR0175.Checked = Program.ProjectList[CurrentProjectIndex].chbCertificateConformanceNACE_MR0175;
                chbCertificateConformanceASMEHydrostaticTesting.Checked = Program.ProjectList[CurrentProjectIndex].chbCertificateConformanceASMEHydrostaticTesting;
                chbMaterialTestReports.Checked = Program.ProjectList[CurrentProjectIndex].chbMaterialTestReports;
                chbHydrostaticTestReportASME.Checked = Program.ProjectList[CurrentProjectIndex].chbHydrostaticTestReportASME;
                chbFunctionalTestReport.Checked = Program.ProjectList[CurrentProjectIndex].chbFunctionalTestReport;
                chbHardnessTestReport.Checked = Program.ProjectList[CurrentProjectIndex].chbHardnessTestReport;
                chbBendTestReportBodyBonnetCasting.Checked = Program.ProjectList[CurrentProjectIndex].chbBendTestReportBodyBonnetCasting;
                chbRadiographyTestReport.Checked = Program.ProjectList[CurrentProjectIndex].chbRadiographyTestReport;
                chbSpecialPainting.Checked = Program.ProjectList[CurrentProjectIndex].chbSpecialPainting;
            }
            catch
            {

            }
        }

        private void btnSafetyLiquidAsmeSec8_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.ProjectList[CurrentProjectIndex].ProjectName == "") //load
                    Program.ProjectList[CurrentProjectIndex].ProjectName = "Safety Relief Valve";
                Program.ProjectList[CurrentProjectIndex].Design_Code = "ASME Section VIII";
                Program.ProjectList[CurrentProjectIndex].Sizing_Std = "API 520";
                Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet = "Liquid";
                Program.ProjectList[CurrentProjectIndex].Safety_Relief = "Relief";  //RULE: 2
                Program.ProjectList[CurrentProjectIndex].Relieving_Case = "Pressure Relief";
                Program.ProjectList[CurrentProjectIndex].Fluid_Type = "Liquid";
                Program.ProjectList[CurrentProjectIndex].Standard_Type = "ASME Section VIII-API 520 ";
                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "")//load
                    Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name = "pageSizingSelection";


                FluidType = "Liquid";
                pageCalculationType.Image = Image.FromFile(Program.ImagesPath + "CalculationTypeOff.png");
                pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionOn.png");
                pageSizingSelection.Enabled = true;
                pageMain.SelectedPage = pageSizingSelection;
                SelectedCodeSection = "ASME Section VIII";
                FillPageSizing("Section VIII Liquid Sizing");
            }
            catch
            {

            }
        }

        private void cmbSize_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                int SelectedSizeIndex = cmbSize.SelectedIndex;
                Program.ProjectList[CurrentProjectIndex].Inlet_Size_Connection = cmbSize.SelectedItem.ToString();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                BackingSizeCode(SelectedSizeIndex);
            }
            catch
            {

            }
        }

        private void FillInletOutlet(int SelectedSizeIndex)
        {
            try
            {
                cmbInletConnection.Items[0].Enabled = false;
                cmbInletConnection.Items[1].Enabled = false;
                cmbInletConnection.Items[2].Enabled = false;
                cmbInletConnection.Items[3].Enabled = false;
                cmbInletConnection.Items[4].Enabled = false;
                cmbInletConnection.Items[5].Enabled = false;
                cmbInletConnection.Items[6].Enabled = false;
                cmbInletConnection.Items[7].Enabled = false;
                cmbInletConnection.Items[8].Enabled = false;
                cmbInletConnection.Items[9].Enabled = false;
                cmbInletConnection.Items[10].Enabled = false;
                cmbInletConnection.Items[11].Enabled = false;
                cmbInletConnection.Items[12].Enabled = false;
                cmbInletConnection.Items[13].Enabled = false;
                cmbInletConnection.Items[14].Enabled = false;
                cmbInletConnection.Items[15].Enabled = false;
                cmbInletConnection.Items[16].Enabled = false;
                cmbInletConnection.Items[17].Enabled = false;
                cmbInletConnection.Items[18].Enabled = false;
                cmbInletConnection.Items[19].Enabled = false;
                cmbInletConnection.Items[20].Enabled = false;
                cmbInletConnection.Items[21].Enabled = false;
                cmbInletConnection.Items[22].Enabled = false;
                switch (SelectedSeries)
                {
                    case "A":
                    case "M":
                        {
                            switch (SelectedOrifice)
                            {
                                case "J":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 3:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                break;
                                            case 4:
                                                cmbInletConnection.Items[1].Enabled = true;
                                                cmbInletConnection.Items[2].Enabled = true;
                                                cmbInletConnection.Items[6].Enabled = true;
                                                cmbInletConnection.Items[4].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }

                                case "D":
                                case "E":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 0:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                cmbInletConnection.Items[2].Enabled = true;
                                                break;
                                            case 1:
                                                cmbInletConnection.Items[3].Enabled = true;
                                                cmbInletConnection.Items[4].Enabled = true;
                                                break;
                                            case 2:
                                                cmbInletConnection.Items[5].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "F":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 1:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                cmbInletConnection.Items[2].Enabled = true;
                                                break;
                                            case 2:
                                                cmbInletConnection.Items[3].Enabled = true;
                                                cmbInletConnection.Items[4].Enabled = true;
                                                cmbInletConnection.Items[5].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "G":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 2:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                cmbInletConnection.Items[2].Enabled = true;
                                                cmbInletConnection.Items[3].Enabled = true;
                                                break;
                                            case 3:
                                                cmbInletConnection.Items[4].Enabled = true;
                                                cmbInletConnection.Items[5].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "H":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 2:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                break;
                                            case 3:
                                                cmbInletConnection.Items[2].Enabled = true;
                                                cmbInletConnection.Items[3].Enabled = true;
                                                cmbInletConnection.Items[7].Enabled = true;
                                                cmbInletConnection.Items[5].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "K":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 4:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                cmbInletConnection.Items[2].Enabled = true;
                                                break;
                                            case 5:
                                                cmbInletConnection.Items[6].Enabled = true;
                                                cmbInletConnection.Items[4].Enabled = true;
                                                break;

                                        }
                                        break;
                                    }
                                case "L":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 4:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                break;
                                            case 6:
                                                cmbInletConnection.Items[1].Enabled = true;
                                                cmbInletConnection.Items[2].Enabled = true;
                                                cmbInletConnection.Items[6].Enabled = true;
                                                cmbInletConnection.Items[7].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "M":
                                case "N":
                                case "P":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 6:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                cmbInletConnection.Items[2].Enabled = true;
                                                cmbInletConnection.Items[6].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "Q":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 7:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                cmbInletConnection.Items[2].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "R":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 7:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                break;
                                            case 8:
                                                cmbInletConnection.Items[2].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "T":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 9:
                                                cmbInletConnection.Items[0].Enabled = true;
                                                cmbInletConnection.Items[1].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case "R1":
                        {
                            switch (SelectedOrifice)
                            {
                                case "5":
                                case "6":
                                case "7":
                                    {
                                        cmbInletConnection.Items[15].Enabled = true;
                                        cmbInletConnection.Items[16].Enabled = true;
                                        cmbInletConnection.Items[8].Enabled = true;
                                        cmbInletConnection.Items[9].Enabled = true;
                                        cmbInletConnection.Items[18].Enabled = true;


                                        cmbInletConnection.Items[19].Enabled = true;
                                        cmbInletConnection.Items[20].Enabled = true;

                                        cmbInletConnection.Items[21].Enabled = true;
                                        cmbInletConnection.Items[22].Enabled = true;
                                        break;

                                    }

                            }
                            break;
                        }
                    case "D":
                        {
                            switch (SelectedOrifice)
                            {
                                case "I":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 13:
                                                cmbInletConnection.Items[12].Enabled = true;
                                                cmbInletConnection.Items[13].Enabled = true;
                                                cmbInletConnection.Items[14].Enabled = true;
                                                cmbInletConnection.Items[15].Enabled = true;
                                                cmbInletConnection.Items[16].Enabled = true;
                                                cmbInletConnection.Items[17].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "II":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 14:
                                                cmbInletConnection.Items[12].Enabled = true;
                                                cmbInletConnection.Items[13].Enabled = true;
                                                cmbInletConnection.Items[14].Enabled = true;
                                                cmbInletConnection.Items[15].Enabled = true;
                                                cmbInletConnection.Items[16].Enabled = true;
                                                cmbInletConnection.Items[17].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "III":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 15:
                                                cmbInletConnection.Items[12].Enabled = true;
                                                cmbInletConnection.Items[13].Enabled = true;
                                                cmbInletConnection.Items[14].Enabled = true;
                                                cmbInletConnection.Items[15].Enabled = true;
                                                cmbInletConnection.Items[16].Enabled = true;
                                                cmbInletConnection.Items[17].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "IV":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 3:
                                                cmbInletConnection.Items[12].Enabled = true;
                                                cmbInletConnection.Items[13].Enabled = true;
                                                cmbInletConnection.Items[14].Enabled = true;
                                                cmbInletConnection.Items[15].Enabled = true;
                                                cmbInletConnection.Items[16].Enabled = true;
                                                cmbInletConnection.Items[17].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "V":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 16:
                                                cmbInletConnection.Items[12].Enabled = true;
                                                cmbInletConnection.Items[13].Enabled = true;
                                                cmbInletConnection.Items[14].Enabled = true;
                                                cmbInletConnection.Items[15].Enabled = true;
                                                cmbInletConnection.Items[16].Enabled = true;
                                                cmbInletConnection.Items[17].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "VI":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 17:
                                                cmbInletConnection.Items[12].Enabled = true;
                                                cmbInletConnection.Items[13].Enabled = true;
                                                cmbInletConnection.Items[14].Enabled = true;
                                                cmbInletConnection.Items[15].Enabled = true;
                                                cmbInletConnection.Items[16].Enabled = true;
                                                cmbInletConnection.Items[17].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                                case "VII":
                                    {
                                        switch (SelectedSizeIndex)
                                        {
                                            case 6:
                                                cmbInletConnection.Items[12].Enabled = true;
                                                cmbInletConnection.Items[13].Enabled = true;
                                                cmbInletConnection.Items[14].Enabled = true;
                                                cmbInletConnection.Items[15].Enabled = true;
                                                cmbInletConnection.Items[16].Enabled = true;
                                                cmbInletConnection.Items[17].Enabled = true;
                                                break;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            catch
            {

            }
        }

        private void chbValveModel_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbValveModel.CheckState == CheckState.Checked)
                {
                    txbValveModel.ReadOnly = false;
                    txbValveModel.Text = "";
                    txbValveModel.Focus();
                }
                if (chbValveModel.CheckState == CheckState.Unchecked)
                {
                    txbValveModel.Text = "Series " + SelectedSeries + " , " + FluidType + " Service";
                    txbValveModel.ReadOnly = true;
                }
            }
            catch
            {

            }
        }

        private void chbCodeSection_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbCodeSection.CheckState == CheckState.Checked)
                {
                    txbCodeSection.ReadOnly = false;
                    txbCodeSection.Text = "";
                    txbCodeSection.Focus();
                }
                if (chbCodeSection.CheckState == CheckState.Unchecked)
                {
                    txbCodeSection.Text = SelectedCodeSection;
                    txbCodeSection.ReadOnly = true;
                }
            }
            catch
            {

            }
        }

        private void chbValveService_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbValveService.CheckState == CheckState.Checked)
                {
                    txbValveService.ReadOnly = false;
                    txbValveService.Text = "";
                    txbValveService.Focus();
                }
                if (chbValveService.CheckState == CheckState.Unchecked)
                {
                    txbValveService.Text = cmbFluidName.SelectedItem.ToString();
                    txbValveService.ReadOnly = true;
                }
            }
            catch
            {

            }
        }

        private void chbValveOrifice_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbValveOrifice.CheckState == CheckState.Checked)
                {
                    txbValveOrifice.ReadOnly = false;
                    txbValveOrifice.Text = "";
                    txbValveOrifice.Focus();
                }
                if (chbValveOrifice.CheckState == CheckState.Unchecked)
                {
                    txbValveOrifice.Text = SelectedOrifice + " Orifice";
                    txbValveOrifice.ReadOnly = true;
                }
            }
            catch
            {

            }
        }

        private void chbSize_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbSize.CheckState == CheckState.Checked)
                {
                    cmbSize.Visible = false;
                    txbSize.Location = new Point(cmbSize.Location.X, cmbSize.Location.Y);
                    txbSize.Visible = true;
                    txbSize.Focus();
                }
                if (chbSize.CheckState == CheckState.Unchecked)
                {
                    cmbSize.Visible = true;
                    txbSize.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void chbInletOutlet_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbInletConnection.CheckState == CheckState.Checked)
                {
                    cmbInletConnection.Visible = false;
                    txbInletOutlet.Location = new Point(cmbInletConnection.Location.X, cmbInletConnection.Location.Y);
                    txbInletOutlet.Visible = true;
                    txbInletOutlet.ReadOnly = false;
                    txbInletOutlet.Focus();
                }
                if (chbInletConnection.CheckState == CheckState.Unchecked)
                {
                    cmbInletConnection.Visible = true;
                    txbInletOutlet.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void chbBodyMaterial_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbBodyMaterial.CheckState == CheckState.Checked)
                {
                    cmbBodyMaterial.Visible = false;
                    txbBodyMaterial.Location = new Point(cmbBodyMaterial.Location.X, cmbBodyMaterial.Location.Y);
                    txbBodyMaterial.Visible = true;
                    txbBodyMaterial.Focus();
                }
                if (chbBodyMaterial.CheckState == CheckState.Unchecked)
                {
                    cmbBodyMaterial.Visible = true;
                    txbBodyMaterial.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void chbSpringMaterial_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbSpringMaterial.CheckState == CheckState.Checked)
                {
                    cmbSpringMaterial.Visible = false;
                    txbSpringMaterial.Location = new Point(cmbSpringMaterial.Location.X, cmbSpringMaterial.Location.Y);
                    txbSpringMaterial.Visible = true;
                    txbSpringMaterial.Focus();
                }
                if (chbSpringMaterial.CheckState == CheckState.Unchecked)
                {
                    cmbSpringMaterial.Visible = true;
                    txbSpringMaterial.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void chbTrimMaterial_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbDiskMaterial.CheckState == CheckState.Checked)
                {
                    cmbDiskMaterial.Visible = false;
                    txbTrimMaterial.Location = new Point(cmbDiskMaterial.Location.X, cmbDiskMaterial.Location.Y);
                    txbTrimMaterial.Visible = true;
                    txbTrimMaterial.Focus();
                }
                if (chbDiskMaterial.CheckState == CheckState.Unchecked)
                {
                    cmbDiskMaterial.Visible = true;
                    txbTrimMaterial.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void chbSeat_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbSeat.CheckState == CheckState.Checked)
                {
                    cmbSeat.Visible = false;
                    txbSeat.Location = new Point(cmbSeat.Location.X, cmbSeat.Location.Y);
                    txbSeat.Visible = true;
                    txbSeat.Focus();
                }
                if (chbSeat.CheckState == CheckState.Unchecked)
                {
                    cmbSeat.Visible = true;
                    txbSeat.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void chbANSIFlangeRating_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbANSIFlangeRating.CheckState == CheckState.Checked)
                {
                    cmbANSIFlangeRating.Visible = false;
                    txbANSIFlangeRating.Location = new Point(cmbANSIFlangeRating.Location.X, cmbANSIFlangeRating.Location.Y);
                    txbANSIFlangeRating.Visible = true;
                    txbANSIFlangeRating.Focus();
                }
                if (chbANSIFlangeRating.CheckState == CheckState.Unchecked)
                {
                    cmbANSIFlangeRating.Visible = true;
                    txbANSIFlangeRating.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void chbFlangeFace_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (chbFlangeFace.CheckState == CheckState.Checked)
                {
                    cmbFlangeFace.Visible = false;
                    txbFlangeFace.Location = new Point(cmbFlangeFace.Location.X, cmbFlangeFace.Location.Y);
                    txbFlangeFace.Visible = true;
                    txbFlangeFace.Focus();
                }
                if (chbFlangeFace.CheckState == CheckState.Unchecked)
                {
                    cmbFlangeFace.Visible = true;
                    txbFlangeFace.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void CreateCatalogNumber(string NewValue, int Position, int Count)
        {
            try
            {
                string OldValue = txbCatalogNumber.Text[Position].ToString();
                StringBuilder sb = new StringBuilder(txbCatalogNumber.Text.Trim());
                sb.Replace(OldValue, NewValue, Position, Count);
                txbCatalogNumber.Text = sb.ToString();
            }
            catch
            {

            }
        }

        private void CreateCatalogNumber()
        {
            try
            {
                switch (SelectedSeries)
                {
                    case "A":
                        CreateCatalogNumber("A-", 0, 2);
                        if (FluidType == "Gas")
                            CreateCatalogNumber("1", 2, 1);
                        if (FluidType == "Liquid")
                            CreateCatalogNumber("2", 2, 1);
                        if (SelectedValveType == null)
                            SelectedValveType = Program.ProjectList[CurrentProjectIndex].Valve_Type;
                        int bellows_index = SelectedValveType.IndexOf("Bellows");
                        int Conventional_index = SelectedValveType.IndexOf("Conventional");
                        int Piston_index = SelectedValveType.IndexOf("Piston");

                        if (bellows_index != -1)
                            CreateCatalogNumber("B", 3, 1);
                        else if (Conventional_index == -1)
                            CreateCatalogNumber("C", 3, 1);
                        else if (Piston_index == -1)
                            CreateCatalogNumber("P", 3, 1);

                        break;
                    case "D":
                        CreateCatalogNumber("D", 0, 1);
                        if (FluidType == "Gas" && SelectedValveType == "Conventional")
                            CreateCatalogNumber("1", 1, 1);

                        if (FluidType == "Gas" && SelectedValveType == "Bellows")
                            CreateCatalogNumber("2", 1, 1);

                        if (FluidType == "Liquid" && SelectedValveType == "Conventional")
                            CreateCatalogNumber("3", 1, 1);

                        if (FluidType == "Liquid" && SelectedValveType == "Bellows")
                            CreateCatalogNumber("4", 1, 1);
                        break;
                    case "M":
                        CreateCatalogNumber("M", 0, 1);
                        if (FluidType == "Gas" && SelectedValveType == "Pilot Operated Pop action")
                            CreateCatalogNumber("1", 1, 1);
                        if (FluidType == "Gas" && SelectedValveType == "Pilot Operated Modulating")
                            CreateCatalogNumber("2", 1, 1);

                        break;
                    case "R1":
                        CreateCatalogNumber("R1-", 0, 1);
                        CreateCatalogNumber(SelectedOrifice, 4, 1);
                        break;
                }
            }
            catch
            {

            }
        }

        private void CreateAccesoriesCatalogNumber(string NewValue, int Position)
        {
            try
            {
                string OldValue = AccessoriesCatalogNumber[Position].ToString();
                StringBuilder sb = new StringBuilder(AccessoriesCatalogNumber);
                sb.Replace(OldValue, NewValue, Position, 1);
                AccessoriesCatalogNumber = sb.ToString();
                string temp = AccessoriesCatalogNumber;
                lblFinalAccesCatalogNumber.Text = temp.Replace("_", string.Empty);
                lblFinalAccesCatalogNumber2.Text = lblFinalAccesCatalogNumber.Text;
            }
            catch
            {

            }
        }

        private void cmbFluidName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (cmbFluidName.Items.Count > 0)
                {
                    switch (FluidType)
                    {
                        case "Gas":
                            {
                                int SelectedFluidIdx = Program.FluidList.FindIndex(item => item.Name == cmbFluidName.SelectedItem.ToString() && item.Type == 1);
                                txbMolecularWeight.Text = Program.FluidList[SelectedFluidIdx].MolecularWeight.ToString();
                                txbK.Text = Program.FluidList[SelectedFluidIdx].K.ToString();
                                txbCompressibility.Text = Program.FluidList[SelectedFluidIdx].Comperessibility.ToString();
                                lblMolecularWeight.ForeColor = Color.Black;
                                lblK.ForeColor = Color.Black;
                                lblCompressibility.ForeColor = Color.Black;
                                Safety_Gas_MolecularWeightValidation = true;
                                Safety_Gas_KValidation = true;
                                Safety_Gas_ComperesibilityValidation = true;
                                Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName.SelectedItem.ToString();
                                Program.ProjectList[CurrentProjectIndex].Molecular_Weight = txbMolecularWeight.Text;
                                Program.ProjectList[CurrentProjectIndex].k = txbK.Text;
                                Program.ProjectList[CurrentProjectIndex].Compressibility = txbCompressibility.Text;
                                break;
                            }
                        case "Liquid":
                            {
                                int SelectedFluidIdx = Program.FluidList.FindIndex(item => item.Name == cmbFluidName.SelectedItem.ToString() && item.Type == 2);
                                txbMolecularWeight.Text = Program.FluidList[SelectedFluidIdx].SpecificGravity.ToString();
                                txbK.Text = Program.FluidList[SelectedFluidIdx].Viscosity.ToString();
                                lblMolecularWeight.ForeColor = Color.Black;
                                lblK.ForeColor = Color.Black;
                                Safety_Liquid_SpecificGravityValidation = true;
                                Safety_Liquid_ViscosityValidation = true;
                                Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName.SelectedItem.ToString();
                                Program.ProjectList[CurrentProjectIndex].SpesificGravity = txbMolecularWeight.Text;
                                Program.ProjectList[CurrentProjectIndex].Viscosity = txbK.Text;
                                break;
                            }
                    }
                }
            }
            catch
            {

            }
        }

        private void cmbANSIFlangeRating_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                CreateCatalogNumber(cmbANSIFlangeRating.SelectedValue.ToString(), 10, 1);
                Program.ProjectList[CurrentProjectIndex].ANSIFlangeRating = cmbANSIFlangeRating.SelectedText;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void cmbFlangeFace_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (SelectedSeries == "A")
                    CreateCatalogNumber(cmbFlangeFace.SelectedValue.ToString(), 12, 1);
                Program.ProjectList[CurrentProjectIndex].FlangeFace = cmbFlangeFace.SelectedItem.ToString();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void cmbBodyMaterial_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cmbBodyMaterial.SelectedItem != null)
                {
                    if (SelectedSeries == "A")
                        CreateCatalogNumber(cmbBodyMaterial.SelectedValue.ToString(), 13, 1);
                    if (SelectedSeries == "R1")
                        CreateCatalogNumber(cmbBodyMaterial.SelectedValue.ToString(), 8, 1);

                    Program.ProjectList[CurrentProjectIndex].BodyMaterial = cmbBodyMaterial.SelectedItem.ToString();
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    cmbBodyMaterial.ForeColor = cmbBodyMaterial.SelectedItem.ForeColor;
                    DoClassLimit();

                }
            }
            catch
            {

            }
        }

        private void cmbSpringMaterial_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (SelectedSeries == "A")
                    CreateCatalogNumber(cmbSpringMaterial.SelectedValue.ToString(), 14, 1);
                if (SelectedSeries == "R1")
                    CreateCatalogNumber(cmbSpringMaterial.SelectedValue.ToString(), 9, 1);
                Program.ProjectList[CurrentProjectIndex].SpringMaterial = cmbSpringMaterial.SelectedItem.ToString();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void cmbTrimMaterial_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void chbScrewedCap_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbScrewedCap.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "A" || SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("D", 0);
                    if (SelectedSeries == "R" || SelectedSeries == "R1")
                        CreateAccesoriesCatalogNumber("C", 0);
                    chbBoltedCap.CheckState = CheckState.Unchecked;
                    Program.ProjectList[CurrentProjectIndex].Cap_Type = "Screwed";
                    Program.ProjectList[CurrentProjectIndex].chbScrewedCap = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 0);
                    Program.ProjectList[CurrentProjectIndex].chbScrewedCap = false;
                }
            }
            catch
            {

            }
        }

        private void chbBoltedCap_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbBoltedCap.CheckState == CheckState.Checked)
                {
                    CreateAccesoriesCatalogNumber("F", 2);
                    Program.ProjectList[CurrentProjectIndex].Cap_Type = "Bolted";
                    Program.ProjectList[CurrentProjectIndex].chbBoltedCap = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 2);
                    Program.ProjectList[CurrentProjectIndex].chbBoltedCap = false;
                }
            }
            catch
            {

            }
        }

        private void txbCatalogNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string currentCat = txbCatalogNumber.Text.Trim();
                string noline = currentCat.Replace("_", string.Empty);
                lblFinalConfigCatalogNumber.Text = noline;
                lblFinalConfigCatalogNumber2.Text = noline;
                lblFinalCatalogNumber.Text = lblFinalConfigCatalogNumber.Text + "/" + lblFinalAccesCatalogNumber.Text;
                lblFinalCatalogNumber2.Text = lblFinalConfigCatalogNumber2.Text + "/" + lblFinalAccesCatalogNumber2.Text;
            }
            catch
            {

            }
        }

        private void lblFinalAccesCatalogNumber2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblFinalCatalogNumber.Text = lblFinalConfigCatalogNumber.Text + "/" + lblFinalAccesCatalogNumber.Text;
                lblFinalCatalogNumber2.Text = lblFinalConfigCatalogNumber2.Text + "/" + lblFinalAccesCatalogNumber2.Text;
            }
            catch
            {

            }
        }

        private void chbAuxiliaryBackupPiston_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbAuxiliaryBackupPiston.CheckState == CheckState.Checked)
                {
                    CreateAccesoriesCatalogNumber("G", 10);
                    Program.ProjectList[CurrentProjectIndex].chbAuxiliaryBackupPiston = true;

                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 10);
                    Program.ProjectList[CurrentProjectIndex].chbAuxiliaryBackupPiston = false;
                }
            }
            catch
            {

            }
        }

        private void chbTestGag_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbTestGag.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "A")
                        CreateAccesoriesCatalogNumber("M", 7);
                    if (SelectedSeries == "R1")
                        CreateAccesoriesCatalogNumber("M", 3);
                    if (SelectedSeries == "R" || SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("G", 3);
                    Program.ProjectList[CurrentProjectIndex].chbTestGag = true;
                }
                else
                {
                    if (SelectedSeries == "A")
                        CreateAccesoriesCatalogNumber("_", 7);
                    Program.ProjectList[CurrentProjectIndex].chbTestGag = false;
                }
            }
            catch
            {

            }
        }

        private void chbHighPressure_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbHighPressure.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "A" || SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("P", 4);
                    if (SelectedSeries == "D")
                        CreateAccesoriesCatalogNumber("H", 4);
                    Program.ProjectList[CurrentProjectIndex].chbHighPressure = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 4);
                    Program.ProjectList[CurrentProjectIndex].chbHighPressure = false;
                }
            }
            catch
            {

            }
        }

        private void chbOpenLever_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbOpenLever.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "A" || SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("N", 8);
                    if (SelectedSeries == "R" || SelectedSeries == "R1" || SelectedSeries == "D")
                        CreateAccesoriesCatalogNumber("M", 5);
                    chbPackedLever.CheckState = CheckState.Unchecked;
                    Program.ProjectList[CurrentProjectIndex].Bonnet = "Open";
                    Program.ProjectList[CurrentProjectIndex].chbOpenLever = true;
                }
                else
                {
                    if (SelectedSeries == "A" || SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("_", 8);
                    Program.ProjectList[CurrentProjectIndex].chbOpenLever = false;
                }
            }
            catch
            {

            }
        }

        private void chbPackedLever_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbPackedLever.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "A")
                        CreateAccesoriesCatalogNumber("R", 3);
                    if (SelectedSeries == "R1")
                        CreateAccesoriesCatalogNumber("R", 2);
                    if (SelectedSeries == "R" || SelectedSeries == "D" || SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("P", 6);
                    Program.ProjectList[CurrentProjectIndex].Bonnet = "Packed";
                    Program.ProjectList[CurrentProjectIndex].chbPackedLever = true;
                }
                else
                {
                    if (SelectedSeries == "A")
                        CreateAccesoriesCatalogNumber("_", 3);
                    Program.ProjectList[CurrentProjectIndex].chbPackedLever = false;
                }
            }
            catch
            {

            }
        }
      

        private void cmbSeat_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cmbSeat.SelectedItem.Index == 0)
                {
                    Program.ProjectList[CurrentProjectIndex].Seat_Type = "Metal to Metal";
                    Program.ProjectList[CurrentProjectIndex].Seat = cmbSeat.SelectedItem.Text;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CreateAccesoriesCatalogNumber("_", 7);
                }
                else
                {
                    Program.ProjectList[CurrentProjectIndex].Seat_Type = "Soft Seat";
                    Program.ProjectList[CurrentProjectIndex].Seat = cmbSeat.SelectedItem.Text;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    if (SelectedSeries == "R1")
                        CreateAccesoriesCatalogNumber("H", 3);
                    else
                        CreateAccesoriesCatalogNumber("H", 7);
                }
            }
            catch
            {

            }

        }

        private void chbDomedCap_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbDomedCap.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "D")
                        CreateAccesoriesCatalogNumber("D", 8);
                    Program.ProjectList[CurrentProjectIndex].chbDomedCap = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 8);
                    Program.ProjectList[CurrentProjectIndex].chbDomedCap = false;
                }
            }
            catch
            {

            }
        }

        private void chbFerrule_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbFerrule.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "D")
                        CreateAccesoriesCatalogNumber("F", 9);
                    Program.ProjectList[CurrentProjectIndex].chbFerrule = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 9);
                    Program.ProjectList[CurrentProjectIndex].chbFerrule = false;
                }
            }
            catch
            {

            }
        }

        private void chbGag_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbGag.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "D")
                        CreateAccesoriesCatalogNumber("G", 10);
                    Program.ProjectList[CurrentProjectIndex].chbGag = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 10);
                    Program.ProjectList[CurrentProjectIndex].chbGag = false;
                }
            }
            catch
            {

            }
        }

        private void chbNACEMaterial_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbNACEMaterial.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "D")
                        CreateAccesoriesCatalogNumber("N", 11);
                    Program.ProjectList[CurrentProjectIndex].chbNACEMaterial = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 11);
                    Program.ProjectList[CurrentProjectIndex].chbNACEMaterial = false;
                }
            }
            catch
            {

            }
        }

        private void chbResilientSeat_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbResilientSeat.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "D")
                        CreateAccesoriesCatalogNumber("R", 12);
                    Program.ProjectList[CurrentProjectIndex].chbResilientSeat = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 12);
                    Program.ProjectList[CurrentProjectIndex].chbResilientSeat = true;
                }
            }
            catch
            {

            }
        }

        private void chbRemotePressureSensing_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbRemotePressureSensing.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("A", 13);
                    Program.ProjectList[CurrentProjectIndex].chbRemotePressureSensing = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 13);
                    Program.ProjectList[CurrentProjectIndex].chbRemotePressureSensing = false;
                }
            }
            catch
            {

            }
        }

        private void chbBackFlowPreventer_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbBackFlowPreventer.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("B", 14);
                    Program.ProjectList[CurrentProjectIndex].chbBackFlowPreventer = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 14);
                    Program.ProjectList[CurrentProjectIndex].chbBackFlowPreventer = false;
                }
            }
            catch
            {

            }
        }

        private void chbCoolingHeatingCoils_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbCoolingHeatingCoils.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("C", 15);
                    Program.ProjectList[CurrentProjectIndex].chbCoolingHeatingCoils = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 15);
                    Program.ProjectList[CurrentProjectIndex].chbCoolingHeatingCoils = false;
                }
            }
            catch
            {

            }
        }

        private void chbExternalFilter_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbExternalFilter.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("E", 16);
                    Program.ProjectList[CurrentProjectIndex].chbExternalFilter = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 16);
                    Program.ProjectList[CurrentProjectIndex].chbExternalFilter = false;
                }
            }
            catch
            {

            }
        }

        private void chbLiquidDuty_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbLiquidDuty.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("L", 17);
                    Program.ProjectList[CurrentProjectIndex].chbLiquidDuty = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 17);
                    Program.ProjectList[CurrentProjectIndex].chbLiquidDuty = false;
                }
            }
            catch
            {

            }
        }

        private void chbFieldTestConnector_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbFieldTestConnector.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("T", 18);
                    Program.ProjectList[CurrentProjectIndex].chbFieldTestConnector = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 18);
                    Program.ProjectList[CurrentProjectIndex].chbFieldTestConnector = false;
                }
            }
            catch
            {

            }
        }

        private void chbRemoteUnloader_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbRemoteUnloader.CheckState == CheckState.Checked)
                {
                    if (SelectedSeries == "M")
                        CreateAccesoriesCatalogNumber("U", 19);
                    Program.ProjectList[CurrentProjectIndex].chbRemoteUnloader = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 19);
                    Program.ProjectList[CurrentProjectIndex].chbRemoteUnloader = false;
                }
            }
            catch
            {

            }
        }

        private void chbSpecialFeatures_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbSpecialFeatures.CheckState == CheckState.Checked)
                {
                    CreateAccesoriesCatalogNumber("X", 20);
                    Program.ProjectList[CurrentProjectIndex].chbSpecialFeatures = true;
                }
                else
                {
                    CreateAccesoriesCatalogNumber("_", 20);
                    Program.ProjectList[CurrentProjectIndex].chbSpecialFeatures = false;
                }
            }
            catch
            {

            }
        }

        private void mnuAllValvesType_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.Visible = true && dgvProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvProduct.RowCount; i++)
                    {
                        dgvProduct.Rows[i].IsVisible = true;
                    }
                }
                btnAllValve.Text = "All Valves Type";
            }
            catch
            {

            }
        }

        private void mnuPilotOperatedOnly_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.Visible = true && dgvProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvProduct.RowCount; i++)
                    {
                        if (dgvProduct.Rows[i].Cells[1].Value.ToString() == "M")
                            dgvProduct.Rows[i].IsVisible = true;
                        else
                            dgvProduct.Rows[i].IsVisible = false;
                    }
                }
                btnAllValve.Text = "Pilot Operated Only";
            }
            catch
            {

            }
        }

        private void mnuSpringOperatedOnly_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.Visible = true && dgvProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvProduct.RowCount; i++)
                    {
                        if (dgvProduct.Rows[i].Cells[1].Value.ToString() == "M")
                            dgvProduct.Rows[i].IsVisible = false;
                        else
                            dgvProduct.Rows[i].IsVisible = true;
                    }
                }
                btnAllValve.Text = "Spring Operated Only";
            }
            catch
            {

            }

        }

       

        private void cmbNozzle_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cmbNozzle.SelectedIndex == 0)
                    CreateCatalogNumber("1", 2, 1);
                if (cmbNozzle.SelectedIndex == 1)
                    CreateCatalogNumber("2", 2, 1);
                Program.ProjectList[CurrentProjectIndex].Nozzle = cmbNozzle.SelectedItem.ToString();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnSafetySteemAsmeSec1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.ProjectList[CurrentProjectIndex].ProjectName == "") //load
                    Program.ProjectList[CurrentProjectIndex].ProjectName = "Safety Relief Valve";
                Program.ProjectList[CurrentProjectIndex].Design_Code = "ASME Section I";
                Program.ProjectList[CurrentProjectIndex].Sizing_Std = "API 520";
                Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet = "Steam";
                Program.ProjectList[CurrentProjectIndex].Safety_Relief = "Safety-Relief"; //RULE: 2
                Program.ProjectList[CurrentProjectIndex].Relieving_Case = "Pressure Relief";
                Program.ProjectList[CurrentProjectIndex].Fluid_Type = "Steam";
                Program.ProjectList[CurrentProjectIndex].Fluid_Name = "Steam";
                Program.ProjectList[CurrentProjectIndex].Standard_Type = "ASME Section I-API 520 ";
                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "")//load
                    Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name = "pageSizingSelection";


                FluidType = "Steam";
                pageCalculationType.Image = Image.FromFile(Program.ImagesPath + "CalculationTypeOff.png");
                pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionOn.png");
                pageSizingSelection.Enabled = true;
                pageMain.SelectedPage = pageSizingSelection;
                SelectedCodeSection = "ASME Section I";
                FillPageSizing("Section I Steam Sizing");
            }
            catch
            {

            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                pageReports.Image = Image.FromFile(Program.ImagesPath + "ReportsOn.png");
                pageConfiguration.Image = Image.FromFile(Program.ImagesPath + "ConfigurationCheck.png");
                pageReports.Enabled = true;
                pageMain.SelectedPage = pageReports;
                Program.ProjectList[CurrentProjectIndex].Sizing_Basis = cmbSizingBasis.SelectedItem.Text;
                if (FluidType == "2-Phase")
                {
                    if (Formule2Phase == "C22")
                    {
                        Program.ProjectList[CurrentProjectIndex].Fluid_Name = txbFluidName_2phase.Text;
                        Program.ProjectList[CurrentProjectIndex].Molecular_Weight = txbMolecularWeightC22.Text;
                        Program.ProjectList[CurrentProjectIndex].Compressibility = txbCompressibilityC22.Text;
                        Program.ProjectList[CurrentProjectIndex].k = txbK.Text;
                        Program.ProjectList[CurrentProjectIndex].Operating_Density = txbDensityGas.Text + "/" + txbDensityLiquid.Text;
                    }
                    if (Formule2Phase == "C23")
                    {
                        Program.ProjectList[CurrentProjectIndex].Fluid_Name = txbFluidName_2phase_C23.Text;
                        Program.ProjectList[CurrentProjectIndex].VaporPressure = txbVaporPressure.Text;
                        Program.ProjectList[CurrentProjectIndex].LiquidDensity = txbLiquidDensity.Text;
                        Program.ProjectList[CurrentProjectIndex].LiquidSpecific = txbLiquidSpecific.Text;
                        Program.ProjectList[CurrentProjectIndex].SpesificGravity = txbSpecificGravity.Text;
                    }
                }
                if (FluidType == "Steam")
                {
                    Program.ProjectList[CurrentProjectIndex].Fluid_Name = txbSteamName.Text;
                    Program.ProjectList[CurrentProjectIndex].Molecular_Weight = txbMolecularWeight.Text;
                    Program.ProjectList[CurrentProjectIndex].Compressibility = txbCompressibility.Text;
                    Program.ProjectList[CurrentProjectIndex].k = txbK.Text;
                }

                if (FluidType == "Gas")
                {
                    if (cmbFluidName.SelectedItem != null)
                        Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName.SelectedItem.Text;
                    else
                        Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName.Text;
                    Program.ProjectList[CurrentProjectIndex].Molecular_Weight = txbMolecularWeight.Text;
                    Program.ProjectList[CurrentProjectIndex].Compressibility = txbCompressibility.Text;
                    Program.ProjectList[CurrentProjectIndex].k = txbK.Text;

                }
                if (FluidType == "Liquid")
                {
                    Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName.SelectedItem.Text;
                    Program.ProjectList[CurrentProjectIndex].Specific_Gravity = txbSpecificGravity.Text;
                    Program.ProjectList[CurrentProjectIndex].Viscosity = txbK.Text;
                }


                Program.ProjectList[CurrentProjectIndex].Valve_Model_No = lblFinalCatalogNumber.Text;
                Program.ProjectList[CurrentProjectIndex].MAWP = txbSystemMAWP.Text;
                Program.ProjectList[CurrentProjectIndex].MAWP_Unit = btnSystemMAWPUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Operating_Pressures = txbOperatingPressure.Text;
                Program.ProjectList[CurrentProjectIndex].Operating_Pressures_Unit = btnOperatingPressureUnit.Text;
                Program.ProjectList[CurrentProjectIndex].SET_PRESSURE = txbSetPressure.Text;
                Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnSetPressureUnit.Text;
                if (rbtOverPressurePercent.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    Program.ProjectList[CurrentProjectIndex].Over_Pressure = txbOverPressurePercent.Text + " %";
                else
                    Program.ProjectList[CurrentProjectIndex].Over_Pressure = txbOverPressure.Text;
                Program.ProjectList[CurrentProjectIndex].Constant_Superimposed = txbConstantSuperimposed.Text;
                Program.ProjectList[CurrentProjectIndex].Constant_Superimposed_Unit = btnConstantSuperimposedUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Variable_Superimposed = txbVaribleSuperimposed.Text;
                Program.ProjectList[CurrentProjectIndex].Variable_Superimposed_Unit = btnVaribleSuperimposedUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Built_Up = txbBuiltUp.Text;
                Program.ProjectList[CurrentProjectIndex].Built_Up_Unit = btnBuiltUpUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Total = txbTotalBackPressure.Text;
                Program.ProjectList[CurrentProjectIndex].Total_Unit = btnTotalBackPressureUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor = txbTotalBackPressure.Text;

                if (rbtInletLossPercent.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    Program.ProjectList[CurrentProjectIndex].Inlet_Loss = txbInletLossPercent.Text + " %";
                else
                    Program.ProjectList[CurrentProjectIndex].Inlet_Loss = txbInletLoss.Text;

                Program.ProjectList[CurrentProjectIndex].Atmospheric = txbAtmPressure.Text;
                Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit = btnAtmPressureUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure = txbAtmPressure.Text + " " + btnAtmPressureUnit.Text;
                if (cmbBodyMaterial.SelectedItem != null)
                    Program.ProjectList[CurrentProjectIndex].Body_Bonnet = cmbBodyMaterial.SelectedItem.Text;
                if (cmbDiskMaterial.SelectedItem != null)
                {
                    Program.ProjectList[CurrentProjectIndex].Disc = cmbDiskMaterial.SelectedItem.Text;
                    Program.ProjectList[CurrentProjectIndex].Guide = cmbDiskMaterial.SelectedItem.Text;
                }
                if (cmbNozzleMaterial.SelectedItem != null)
                {
                    Program.ProjectList[CurrentProjectIndex].Nozzle_Materials = cmbNozzleMaterial.SelectedItem.Text;
                }
                if (cmbSpringMaterial.SelectedItem != null)
                    Program.ProjectList[CurrentProjectIndex].Spring = cmbSpringMaterial.SelectedItem.Text;

                if (cmbSize.SelectedItem != null)
                    Program.ProjectList[CurrentProjectIndex].Valve_Size = cmbSize.SelectedItem.Text;

                if (FluidType == "Liquid")
                    Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient = "0.62";
                else
                    Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient = "0.846";

                Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level = txbL30m.Text;
                Program.ProjectList[CurrentProjectIndex].Operating = txbOperating.Text;
                Program.ProjectList[CurrentProjectIndex].Operating_Unit = btnOperatingTemp.Text;
                Program.ProjectList[CurrentProjectIndex].Relieving = txbRelieving.Text;
                Program.ProjectList[CurrentProjectIndex].Relieving_Unit = btnRelievingTemp.Text;
                Program.ProjectList[CurrentProjectIndex].Design_Min = txbDesignMin.Text;
                Program.ProjectList[CurrentProjectIndex].Design_Min_Unit = btnDesignMinTemp.Text;
                Program.ProjectList[CurrentProjectIndex].Design_Max = txbDesignMax.Text;
                Program.ProjectList[CurrentProjectIndex].Design_Max_Unit = btnDesignMaxTemp.Text;
                Program.ProjectList[CurrentProjectIndex].L1 = txbL1m.Text;
                Program.ProjectList[CurrentProjectIndex].L30 = txbL30m.Text;
                Program.ProjectList[CurrentProjectIndex].Lp = txbL1p.Text;
                Program.ProjectList[CurrentProjectIndex].Kv = "1";
                Program.ProjectList[CurrentProjectIndex].Kv_Max = "1";
                if (cmbANSIFlangeRating.SelectedItem != null && cmbFlangeFace.SelectedItem != null)
                    Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection = cmbANSIFlangeRating.SelectedItem.Text + " " + cmbFlangeFace.SelectedItem.Text;
                if (cmbNozzle.SelectedItem != null)
                    Program.ProjectList[CurrentProjectIndex].Nozzle = cmbNozzle.SelectedItem.Text;
                AddAccessoriesToReport();
                AddTestCertificateToReport();
                BL.Calculate_ReactionForce(CurrentProjectIndex, FluidType, SelectedFlowCapacity, ReactionForceUnit, txbK.Text, txbRelieving.Text, btnRelievingTemp.Text, txbMolecularWeight.Text, Selected_A, txbSetPressure.Text, btnSetPressureUnit.Text, txbOverPressurePercent.Text);
            }
            catch
            {

            }


        }

        private void AddAccessoriesToReport()
        {
            try
            {
                List<string> AccessoriesList = new List<string>();
                AccessoriesList.Clear();
                if (chbRemoteUnloader.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Remote Unloader");
                if (chbFieldTestConnector.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Field Test Connector");
                if (chbLiquidDuty.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Liquid Duty");
                if (chbExternalFilter.CheckState == CheckState.Checked)
                    AccessoriesList.Add("External Filter");
                if (chbCoolingHeatingCoils.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Cooling/Heating Coils");
                if (chbBackFlowPreventer.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Back Flow Preventer");
                if (chbSpecialFeatures.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Special Features");
                if (chbRemotePressureSensing.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Remote Pressure Sensing");
                if (chbResilientSeat.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Resilient Seat");
                if (chbNACEMaterial.CheckState == CheckState.Checked)
                    AccessoriesList.Add("NACE Material");
                if (chbGag.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Gag");
                if (chbFerrule.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Ferrule");
                if (chbDomedCap.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Domed Cap");
                if (chbPackedLever.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Packed Lever");
                if (chbOpenLever.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Open Lever");
                if (chbHighPressure.CheckState == CheckState.Checked)
                    AccessoriesList.Add("High Pressure");
                if (chbTestGag.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Test Gag");
                if (chbAuxiliaryBackupPiston.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Auxiliary Backup Piston");
                if (chbBoltedCap.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Bolted Cap");
                if (chbScrewedCap.CheckState == CheckState.Checked)
                    AccessoriesList.Add("Screwed Cap");

                for (int i = 0; i < AccessoriesList.Count; i++)
                {
                    if (i > 9)
                        break;
                    switch (i)
                    {
                        case 0:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES1 = AccessoriesList[i];
                            break;
                        case 1:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES2 = AccessoriesList[i];
                            break;
                        case 2:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES3 = AccessoriesList[i];
                            break;
                        case 3:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES4 = AccessoriesList[i];
                            break;
                        case 4:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES5 = AccessoriesList[i];
                            break;
                        case 5:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES6 = AccessoriesList[i];
                            break;
                        case 6:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES7 = AccessoriesList[i];
                            break;
                        case 7:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES8 = AccessoriesList[i];
                            break;
                        case 8:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES9 = AccessoriesList[i];
                            break;
                        case 9:
                            Program.ProjectList[CurrentProjectIndex].ACCESSORIES10 = AccessoriesList[i];
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        private void AddTestCertificateToReport()
        {
            try
            {
                List<string> TestCertificateList = new List<string>();
                TestCertificateList.Clear();
                if (chbStandardCertificateOrigin.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbStandardCertificateOrigin.Text);
                if (chbCertificateConformancePurchaseOrder.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbCertificateConformancePurchaseOrder.Text);
                if (chbCertificateConformanceNACE_MR0175.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbCertificateConformanceNACE_MR0175.Text);
                if (chbCertificateConformanceASMEHydrostaticTesting.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbCertificateConformanceASMEHydrostaticTesting.Text);
                if (chbMaterialTestReports.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbMaterialTestReports.Text);
                if (chbHydrostaticTestReportASME.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbHydrostaticTestReportASME.Text);
                if (chbFunctionalTestReport.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbFunctionalTestReport.Text);
                if (chbHardnessTestReport.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbHardnessTestReport.Text);
                if (chbBendTestReportBodyBonnetCasting.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbBendTestReportBodyBonnetCasting.Text);
                if (chbRadiographyTestReport.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbRadiographyTestReport.Text);
                if (chbSpecialPainting.CheckState == CheckState.Checked)
                    TestCertificateList.Add(chbSpecialPainting.Text);


                for (int i = 0; i < TestCertificateList.Count; i++)
                {
                    if (i > 7)
                        break;
                    switch (i)
                    {
                        case 0:
                            Program.ProjectList[CurrentProjectIndex].Test_Certificates1 = TestCertificateList[i];
                            break;
                        case 1:
                            Program.ProjectList[CurrentProjectIndex].Test_Certificates2 = TestCertificateList[i];
                            break;
                        case 2:
                            Program.ProjectList[CurrentProjectIndex].Test_Certificates3 = TestCertificateList[i];
                            break;
                        case 3:
                            Program.ProjectList[CurrentProjectIndex].Test_Certificates4 = TestCertificateList[i];
                            break;
                        case 4:
                            Program.ProjectList[CurrentProjectIndex].Test_Certificates5 = TestCertificateList[i];
                            break;
                        case 5:
                            Program.ProjectList[CurrentProjectIndex].Test_Certificates6 = TestCertificateList[i];
                            break;
                        case 6:
                            Program.ProjectList[CurrentProjectIndex].Test_Certificates7 = TestCertificateList[i];
                            break;
                        case 7:
                            Program.ProjectList[CurrentProjectIndex].Test_Certificates8 = TestCertificateList[i];
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        private void CreateGasDataSheetReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\GasDataSheetSafety.mrt");
                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["PID_No"] = Program.ProjectList[CurrentProjectIndex].PID_No;
                stiReport1["Line_No"] = Program.ProjectList[CurrentProjectIndex].Line_No;
                stiReport1["Service"] = Program.ProjectList[CurrentProjectIndex].Service;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Type"] = Program.ProjectList[CurrentProjectIndex].Valve_Type;
                stiReport1["Safety_Relief"] = Program.ProjectList[CurrentProjectIndex].Safety_Relief;
                stiReport1["Nozzle"] = Program.ProjectList[CurrentProjectIndex].Nozzle;
                stiReport1["Bonnet"] = Program.ProjectList[CurrentProjectIndex].Bonnet;
                stiReport1["Cap_Type"] = Program.ProjectList[CurrentProjectIndex].Cap_Type;
                stiReport1["Inlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Inlet_Size_Connection;
                stiReport1["Outlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection;
                stiReport1["Body_Bonnet"] = Program.ProjectList[CurrentProjectIndex].Body_Bonnet;
                stiReport1["Nozzle_Materials"] = Program.ProjectList[CurrentProjectIndex].Nozzle_Materials;
                stiReport1["Disc"] = Program.ProjectList[CurrentProjectIndex].Disc;
                stiReport1["Guide"] = Program.ProjectList[CurrentProjectIndex].Guide;
                stiReport1["Spring"] = Program.ProjectList[CurrentProjectIndex].Spring;
                stiReport1["Gaskets"] = Program.ProjectList[CurrentProjectIndex].Gaskets;
                stiReport1["Bellows"] = Program.ProjectList[CurrentProjectIndex].Bellows;
                stiReport1["Bolting"] = Program.ProjectList[CurrentProjectIndex].Bolting;
                stiReport1["NACE_MR0175"] = Program.ProjectList[CurrentProjectIndex].NACE_MR0175;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Series"] = Program.ProjectList[CurrentProjectIndex].Series;
                stiReport1["Orifice"] = Program.ProjectList[CurrentProjectIndex].Orifice;
                stiReport1["Kd"] = Program.ProjectList[CurrentProjectIndex].Kd;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Sizing_Basis"] = Program.ProjectList[CurrentProjectIndex].Sizing_Basis;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Relieving_Case"] = Program.ProjectList[CurrentProjectIndex].Relieving_Case;
                stiReport1["Fluid_Name"] = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                stiReport1["Molecular_Weight"] = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                stiReport1["Compressibility"] = Program.ProjectList[CurrentProjectIndex].Compressibility;
                stiReport1["k"] = Program.ProjectList[CurrentProjectIndex].k;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].C;
                stiReport1["MAWP"] = Program.ProjectList[CurrentProjectIndex].MAWP;
                stiReport1["MAWP_Unit"] = Program.ProjectList[CurrentProjectIndex].MAWP_Unit;
                stiReport1["Operating_Pressures"] = Program.ProjectList[CurrentProjectIndex].Operating_Pressures;
                stiReport1["Operating_Pressures_Unit"] = Program.ProjectList[CurrentProjectIndex].Operating_Pressures_Unit;
                stiReport1["SET_PRESSURE"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["SET_PRESSURE_Unit"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Constant_Superimposed"] = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                stiReport1["Constant_Superimposed_Unit"] = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed_Unit;
                stiReport1["Variable_Superimposed"] = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                stiReport1["Variable_Superimposed_Unit"] = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed_Unit;
                stiReport1["Built_Up"] = Program.ProjectList[CurrentProjectIndex].Built_Up;
                stiReport1["Built_Up_Unit"] = Program.ProjectList[CurrentProjectIndex].Built_Up_Unit;
                stiReport1["Total"] = Program.ProjectList[CurrentProjectIndex].Total;
                stiReport1["Total_Unit"] = Program.ProjectList[CurrentProjectIndex].Total_Unit;
                stiReport1["Inlet_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                stiReport1["Relieving_Flowing"] = Program.ProjectList[CurrentProjectIndex].Relieving_Flowing;
                stiReport1["Relieving_Flowing_Unit"] = Program.ProjectList[CurrentProjectIndex].Relieving_Flowing_Unit;
                stiReport1["Atmospheric"] = Program.ProjectList[CurrentProjectIndex].Atmospheric;
                stiReport1["Atmospheric_Unit"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                stiReport1["Operating"] = Program.ProjectList[CurrentProjectIndex].Operating;
                stiReport1["Operating_Unit"] = Program.ProjectList[CurrentProjectIndex].Operating_Unit;
                stiReport1["Relieving"] = Program.ProjectList[CurrentProjectIndex].Relieving;
                stiReport1["Relieving_Unit"] = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                stiReport1["Design_Min"] = Program.ProjectList[CurrentProjectIndex].Design_Min;
                stiReport1["Design_Min_Unit"] = Program.ProjectList[CurrentProjectIndex].Design_Min_Unit;
                stiReport1["Design_Max"] = Program.ProjectList[CurrentProjectIndex].Design_Max;
                stiReport1["Design_Max_Unit"] = Program.ProjectList[CurrentProjectIndex].Design_Max_Unit;
                stiReport1["ACCESSORIES1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES1;
                stiReport1["ACCESSORIES2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES2;
                stiReport1["ACCESSORIES3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES3;
                stiReport1["ACCESSORIES4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES4;
                stiReport1["ACCESSORIES5"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES5;
                stiReport1["ACCESSORIES6"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES6;
                stiReport1["ACCESSORIES7"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES7;
                stiReport1["ACCESSORIES8"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES8;
                stiReport1["ACCESSORIES9"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES9;
                stiReport1["ACCESSORIES10"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES10;
                stiReport1["Test_Certificates1"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates1;
                stiReport1["Test_Certificates2"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates2;
                stiReport1["Test_Certificates3"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates3;
                stiReport1["Test_Certificates4"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates4;
                stiReport1["Test_Certificates5"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates5;
                stiReport1["Test_Certificates6"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates6;
                stiReport1["Test_Certificates7"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates7;
                stiReport1["Test_Certificates8"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates8;
                stiReport1["Seat_Type"] = Program.ProjectList[CurrentProjectIndex].Seat_Type;
                stiReport1["Seat"] = Program.ProjectList[CurrentProjectIndex].Seat;
                stiReport1["Flange_Face"] = Program.ProjectList[CurrentProjectIndex].FlangeFace;
                stiReport1["End_Connection"] = Program.ProjectList[CurrentProjectIndex].InletConnection + " X " + Program.ProjectList[CurrentProjectIndex].OutletConnection;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }
        private void CreateLiquidDataSheetReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\LiquidDataSheetSafety.mrt");
                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["PID_No"] = Program.ProjectList[CurrentProjectIndex].PID_No;
                stiReport1["Line_No"] = Program.ProjectList[CurrentProjectIndex].Line_No;
                stiReport1["Service"] = Program.ProjectList[CurrentProjectIndex].Service;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Type"] = Program.ProjectList[CurrentProjectIndex].Valve_Type;
                stiReport1["Safety_Relief"] = Program.ProjectList[CurrentProjectIndex].Safety_Relief;
                stiReport1["Nozzle"] = Program.ProjectList[CurrentProjectIndex].Nozzle;
                stiReport1["Bonnet"] = Program.ProjectList[CurrentProjectIndex].Bonnet;
                stiReport1["Cap_Type"] = Program.ProjectList[CurrentProjectIndex].Cap_Type;
                stiReport1["Inlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Inlet_Size_Connection;
                stiReport1["Outlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection;
                stiReport1["Body_Bonnet"] = Program.ProjectList[CurrentProjectIndex].Body_Bonnet;
                stiReport1["Nozzle_Materials"] = Program.ProjectList[CurrentProjectIndex].Nozzle_Materials;
                stiReport1["Disc"] = Program.ProjectList[CurrentProjectIndex].Disc;
                stiReport1["Guide"] = Program.ProjectList[CurrentProjectIndex].Guide;
                stiReport1["Spring"] = Program.ProjectList[CurrentProjectIndex].Spring;
                stiReport1["Gaskets"] = Program.ProjectList[CurrentProjectIndex].Gaskets;
                stiReport1["Bellows"] = Program.ProjectList[CurrentProjectIndex].Bellows;
                stiReport1["Bolting"] = Program.ProjectList[CurrentProjectIndex].Bolting;
                stiReport1["NACE_MR0175"] = Program.ProjectList[CurrentProjectIndex].NACE_MR0175;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Series"] = Program.ProjectList[CurrentProjectIndex].Series;
                stiReport1["Orifice"] = Program.ProjectList[CurrentProjectIndex].Orifice;
                stiReport1["Kd"] = Program.ProjectList[CurrentProjectIndex].Kd;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Sizing_Basis"] = Program.ProjectList[CurrentProjectIndex].Sizing_Basis;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Relieving_Case"] = Program.ProjectList[CurrentProjectIndex].Relieving_Case;
                stiReport1["Fluid_Name"] = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                stiReport1["Molecular_Weight"] = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                stiReport1["Compressibility"] = Program.ProjectList[CurrentProjectIndex].Compressibility;
                stiReport1["k"] = Program.ProjectList[CurrentProjectIndex].k;
                stiReport1["Saturation_Temperature"] = Program.ProjectList[CurrentProjectIndex].Saturation_Temperature;
                stiReport1["MAWP"] = Program.ProjectList[CurrentProjectIndex].MAWP;
                stiReport1["MAWP_Unit"] = Program.ProjectList[CurrentProjectIndex].MAWP_Unit;
                stiReport1["Operating_Pressures"] = Program.ProjectList[CurrentProjectIndex].Operating_Pressures;
                stiReport1["Operating_Pressures_Unit"] = Program.ProjectList[CurrentProjectIndex].Operating_Pressures_Unit;
                stiReport1["SET_PRESSURE"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["SET_PRESSURE_Unit"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Constant_Superimposed"] = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                stiReport1["Constant_Superimposed_Unit"] = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed_Unit;
                stiReport1["Variable_Superimposed"] = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                stiReport1["Variable_Superimposed_Unit"] = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed_Unit;
                stiReport1["Built_Up"] = Program.ProjectList[CurrentProjectIndex].Built_Up;
                stiReport1["Built_Up_Unit"] = Program.ProjectList[CurrentProjectIndex].Built_Up_Unit;
                stiReport1["Total"] = Program.ProjectList[CurrentProjectIndex].Total;
                stiReport1["Total_Unit"] = Program.ProjectList[CurrentProjectIndex].Total_Unit;
                stiReport1["Inlet_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                stiReport1["Relieving_Flowing"] = Program.ProjectList[CurrentProjectIndex].Relieving_Flowing;
                stiReport1["Relieving_Flowing_Unit"] = Program.ProjectList[CurrentProjectIndex].Relieving_Flowing_Unit;
                stiReport1["Atmospheric"] = Program.ProjectList[CurrentProjectIndex].Atmospheric;
                stiReport1["Atmospheric_Unit"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                stiReport1["Operating"] = Program.ProjectList[CurrentProjectIndex].Operating;
                stiReport1["Operating_Unit"] = Program.ProjectList[CurrentProjectIndex].Operating_Unit;
                stiReport1["Relieving"] = Program.ProjectList[CurrentProjectIndex].Relieving;
                stiReport1["Relieving_Unit"] = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                stiReport1["Design_Min"] = Program.ProjectList[CurrentProjectIndex].Design_Min;
                stiReport1["Design_Min_Unit"] = Program.ProjectList[CurrentProjectIndex].Design_Min_Unit;
                stiReport1["Design_Max"] = Program.ProjectList[CurrentProjectIndex].Design_Max;
                stiReport1["Design_Max_Unit"] = Program.ProjectList[CurrentProjectIndex].Design_Max_Unit;
                stiReport1["ACCESSORIES1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES1;
                stiReport1["ACCESSORIES2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES2;
                stiReport1["ACCESSORIES3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES3;
                stiReport1["ACCESSORIES4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES4;
                stiReport1["ACCESSORIES5"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES5;
                stiReport1["ACCESSORIES6"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES6;
                stiReport1["ACCESSORIES7"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES7;
                stiReport1["ACCESSORIES8"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES8;
                stiReport1["Test_Certificates1"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates1;
                stiReport1["Test_Certificates2"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates2;
                stiReport1["Test_Certificates3"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates3;
                stiReport1["Test_Certificates4"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates4;
                stiReport1["Test_Certificates5"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates5;
                stiReport1["Test_Certificates6"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates6;
                stiReport1["Test_Certificates7"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates7;
                stiReport1["Test_Certificates8"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates8;
                stiReport1["Flange_Face"] = Program.ProjectList[CurrentProjectIndex].FlangeFace;
                stiReport1["End_Connection"] = Program.ProjectList[CurrentProjectIndex].InletConnection + " X " + Program.ProjectList[CurrentProjectIndex].OutletConnection;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }
        private void CreateSteamDataSheetReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\SteamDataSheetSafety.mrt");
                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["PID_No"] = Program.ProjectList[CurrentProjectIndex].PID_No;
                stiReport1["Line_No"] = Program.ProjectList[CurrentProjectIndex].Line_No;
                stiReport1["Service"] = Program.ProjectList[CurrentProjectIndex].Service;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Type"] = Program.ProjectList[CurrentProjectIndex].Valve_Type;
                stiReport1["Safety_Relief"] = Program.ProjectList[CurrentProjectIndex].Safety_Relief;
                stiReport1["Nozzle"] = Program.ProjectList[CurrentProjectIndex].Nozzle;
                stiReport1["Bonnet"] = Program.ProjectList[CurrentProjectIndex].Bonnet;
                stiReport1["Cap_Type"] = Program.ProjectList[CurrentProjectIndex].Cap_Type;
                stiReport1["Inlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Inlet_Size_Connection;
                stiReport1["Outlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection;
                stiReport1["Body_Bonnet"] = Program.ProjectList[CurrentProjectIndex].Body_Bonnet;
                stiReport1["Nozzle_Materials"] = Program.ProjectList[CurrentProjectIndex].Nozzle_Materials;
                stiReport1["Disc"] = Program.ProjectList[CurrentProjectIndex].Disc;
                stiReport1["Guide"] = Program.ProjectList[CurrentProjectIndex].Guide;
                stiReport1["Spring"] = Program.ProjectList[CurrentProjectIndex].Spring;
                stiReport1["Gaskets"] = Program.ProjectList[CurrentProjectIndex].Gaskets;
                stiReport1["Bellows"] = Program.ProjectList[CurrentProjectIndex].Bellows;
                stiReport1["Bolting"] = Program.ProjectList[CurrentProjectIndex].Bolting;
                stiReport1["NACE_MR0175"] = Program.ProjectList[CurrentProjectIndex].NACE_MR0175;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Series"] = Program.ProjectList[CurrentProjectIndex].Series;
                stiReport1["Orifice"] = Program.ProjectList[CurrentProjectIndex].Orifice;
                stiReport1["Kd"] = Program.ProjectList[CurrentProjectIndex].Kd;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Sizing_Basis"] = Program.ProjectList[CurrentProjectIndex].Sizing_Basis;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Relieving_Case"] = Program.ProjectList[CurrentProjectIndex].Relieving_Case;
                stiReport1["Fluid_Name"] = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                stiReport1["Molecular_Weight"] = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                stiReport1["Compressibility"] = Program.ProjectList[CurrentProjectIndex].Compressibility;
                stiReport1["k"] = Program.ProjectList[CurrentProjectIndex].k;
                stiReport1["Saturation_Temperature"] = Program.ProjectList[CurrentProjectIndex].Saturation_Temperature;
                stiReport1["MAWP"] = Program.ProjectList[CurrentProjectIndex].MAWP;
                stiReport1["MAWP_Unit"] = Program.ProjectList[CurrentProjectIndex].MAWP_Unit;
                stiReport1["Operating_Pressures"] = Program.ProjectList[CurrentProjectIndex].Operating_Pressures;
                stiReport1["Operating_Pressures_Unit"] = Program.ProjectList[CurrentProjectIndex].Operating_Pressures_Unit;
                stiReport1["SET_PRESSURE"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["SET_PRESSURE_Unit"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Constant_Superimposed"] = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                stiReport1["Constant_Superimposed_Unit"] = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed_Unit;
                stiReport1["Variable_Superimposed"] = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                stiReport1["Variable_Superimposed_Unit"] = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed_Unit;
                stiReport1["Built_Up"] = Program.ProjectList[CurrentProjectIndex].Built_Up;
                stiReport1["Built_Up_Unit"] = Program.ProjectList[CurrentProjectIndex].Built_Up_Unit;
                stiReport1["Total"] = Program.ProjectList[CurrentProjectIndex].Total;
                stiReport1["Total_Unit"] = Program.ProjectList[CurrentProjectIndex].Total_Unit;
                stiReport1["Inlet_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                stiReport1["Relieving_Flowing"] = Program.ProjectList[CurrentProjectIndex].Relieving_Flowing;
                stiReport1["Relieving_Flowing_Unit"] = Program.ProjectList[CurrentProjectIndex].Relieving_Flowing_Unit;
                stiReport1["Atmospheric"] = Program.ProjectList[CurrentProjectIndex].Atmospheric;
                stiReport1["Atmospheric_Unit"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                stiReport1["Operating"] = Program.ProjectList[CurrentProjectIndex].Operating;
                stiReport1["Operating_Unit"] = Program.ProjectList[CurrentProjectIndex].Operating_Unit;
                stiReport1["Relieving"] = Program.ProjectList[CurrentProjectIndex].Relieving;
                stiReport1["Relieving_Unit"] = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                stiReport1["Design_Min"] = Program.ProjectList[CurrentProjectIndex].Design_Min;
                stiReport1["Design_Min_Unit"] = Program.ProjectList[CurrentProjectIndex].Design_Min_Unit;
                stiReport1["Design_Max"] = Program.ProjectList[CurrentProjectIndex].Design_Max;
                stiReport1["Design_Max_Unit"] = Program.ProjectList[CurrentProjectIndex].Design_Max_Unit;
                stiReport1["ACCESSORIES1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES1;
                stiReport1["ACCESSORIES2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES2;
                stiReport1["ACCESSORIES3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES3;
                stiReport1["ACCESSORIES4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES4;
                stiReport1["ACCESSORIES5"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES5;
                stiReport1["ACCESSORIES6"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES6;
                stiReport1["ACCESSORIES7"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES7;
                stiReport1["ACCESSORIES8"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES8;
                stiReport1["Test_Certificates1"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates1;
                stiReport1["Test_Certificates2"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates2;
                stiReport1["Test_Certificates3"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates3;
                stiReport1["Test_Certificates4"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates4;
                stiReport1["Test_Certificates5"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates5;
                stiReport1["Test_Certificates6"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates6;
                stiReport1["Test_Certificates7"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates7;
                stiReport1["Test_Certificates8"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates8;
                stiReport1["Flange_Face"] = Program.ProjectList[CurrentProjectIndex].FlangeFace;
                stiReport1["End_Connection"] = Program.ProjectList[CurrentProjectIndex].InletConnection + " X " + Program.ProjectList[CurrentProjectIndex].OutletConnection;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }

        private void Create2PhaseDataSheetReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();
                if (Formule2Phase == "C22")
                    stiReport1.Load(Application.StartupPath + "\\Reports\\TwoPhaseC22DataSheetSafety.mrt");
                if (Formule2Phase == "C23")
                    stiReport1.Load(Application.StartupPath + "\\Reports\\TwoPhaseC23DataSheetSafety.mrt");

                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["PID_No"] = Program.ProjectList[CurrentProjectIndex].PID_No;
                stiReport1["Line_No"] = Program.ProjectList[CurrentProjectIndex].Line_No;
                stiReport1["Service"] = Program.ProjectList[CurrentProjectIndex].Service;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Type"] = Program.ProjectList[CurrentProjectIndex].Valve_Type;
                stiReport1["Safety_Relief"] = Program.ProjectList[CurrentProjectIndex].Safety_Relief;
                stiReport1["Nozzle"] = Program.ProjectList[CurrentProjectIndex].Nozzle;
                stiReport1["Bonnet"] = Program.ProjectList[CurrentProjectIndex].Bonnet;
                stiReport1["Cap_Type"] = Program.ProjectList[CurrentProjectIndex].Cap_Type;
                stiReport1["Inlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Inlet_Size_Connection;
                stiReport1["Outlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection;
                stiReport1["Body_Bonnet"] = Program.ProjectList[CurrentProjectIndex].Body_Bonnet;
                stiReport1["Nozzle_Materials"] = Program.ProjectList[CurrentProjectIndex].Nozzle_Materials;
                stiReport1["Disc"] = Program.ProjectList[CurrentProjectIndex].Disc;
                stiReport1["Guide"] = Program.ProjectList[CurrentProjectIndex].Guide;
                stiReport1["Spring"] = Program.ProjectList[CurrentProjectIndex].Spring;
                stiReport1["Gaskets"] = Program.ProjectList[CurrentProjectIndex].Gaskets;
                stiReport1["Bellows"] = Program.ProjectList[CurrentProjectIndex].Bellows;
                stiReport1["Bolting"] = Program.ProjectList[CurrentProjectIndex].Bolting;
                stiReport1["NACE_MR0175"] = Program.ProjectList[CurrentProjectIndex].NACE_MR0175;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Series"] = Program.ProjectList[CurrentProjectIndex].Series;
                stiReport1["Orifice"] = Program.ProjectList[CurrentProjectIndex].Orifice;
                stiReport1["Kd"] = Program.ProjectList[CurrentProjectIndex].Kd;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Sizing_Basis"] = Program.ProjectList[CurrentProjectIndex].Sizing_Basis;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Relieving_Case"] = Program.ProjectList[CurrentProjectIndex].Relieving_Case;
                stiReport1["Fluid_Name"] = Program.ProjectList[CurrentProjectIndex].Fluid_Name;
                stiReport1["Molecular_Weight"] = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                stiReport1["Compressibility"] = Program.ProjectList[CurrentProjectIndex].Compressibility;
                stiReport1["k"] = Program.ProjectList[CurrentProjectIndex].k;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].C;
                stiReport1["MAWP"] = Program.ProjectList[CurrentProjectIndex].MAWP;
                stiReport1["MAWP_Unit"] = Program.ProjectList[CurrentProjectIndex].MAWP_Unit;
                stiReport1["Operating_Pressures"] = Program.ProjectList[CurrentProjectIndex].Operating_Pressures;
                stiReport1["Operating_Pressures_Unit"] = Program.ProjectList[CurrentProjectIndex].Operating_Pressures_Unit;
                stiReport1["SET_PRESSURE"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["SET_PRESSURE_Unit"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Constant_Superimposed"] = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed;
                stiReport1["Constant_Superimposed_Unit"] = Program.ProjectList[CurrentProjectIndex].Constant_Superimposed_Unit;
                stiReport1["Variable_Superimposed"] = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed;
                stiReport1["Variable_Superimposed_Unit"] = Program.ProjectList[CurrentProjectIndex].Variable_Superimposed_Unit;
                stiReport1["Built_Up"] = Program.ProjectList[CurrentProjectIndex].Built_Up;
                stiReport1["Built_Up_Unit"] = Program.ProjectList[CurrentProjectIndex].Built_Up_Unit;
                stiReport1["Total"] = Program.ProjectList[CurrentProjectIndex].Total;
                stiReport1["Total_Unit"] = Program.ProjectList[CurrentProjectIndex].Total_Unit;
                stiReport1["Inlet_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Loss;
                stiReport1["Relieving_Flowing"] = Program.ProjectList[CurrentProjectIndex].Relieving_Flowing;
                stiReport1["Relieving_Flowing_Unit"] = Program.ProjectList[CurrentProjectIndex].Relieving_Flowing_Unit;
                stiReport1["Atmospheric"] = Program.ProjectList[CurrentProjectIndex].Atmospheric;
                stiReport1["Atmospheric_Unit"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit;
                stiReport1["Operating"] = Program.ProjectList[CurrentProjectIndex].Operating;
                stiReport1["Operating_Unit"] = Program.ProjectList[CurrentProjectIndex].Operating_Unit;
                stiReport1["Relieving"] = Program.ProjectList[CurrentProjectIndex].Relieving;
                stiReport1["Relieving_Unit"] = Program.ProjectList[CurrentProjectIndex].Relieving_Unit;
                stiReport1["Design_Min"] = Program.ProjectList[CurrentProjectIndex].Design_Min;
                stiReport1["Design_Min_Unit"] = Program.ProjectList[CurrentProjectIndex].Design_Min_Unit;
                stiReport1["Design_Max"] = Program.ProjectList[CurrentProjectIndex].Design_Max;
                stiReport1["Design_Max_Unit"] = Program.ProjectList[CurrentProjectIndex].Design_Max_Unit;
                stiReport1["ACCESSORIES1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES1;
                stiReport1["ACCESSORIES2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES2;
                stiReport1["ACCESSORIES3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES3;
                stiReport1["ACCESSORIES4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES4;
                stiReport1["ACCESSORIES5"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES5;
                stiReport1["ACCESSORIES6"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES6;
                stiReport1["ACCESSORIES7"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES7;
                stiReport1["ACCESSORIES8"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES8;
                stiReport1["Test_Certificates1"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates1;
                stiReport1["Test_Certificates2"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates2;
                stiReport1["Test_Certificates3"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates3;
                stiReport1["Test_Certificates4"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates4;
                stiReport1["Test_Certificates5"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates5;
                stiReport1["Test_Certificates6"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates6;
                stiReport1["Test_Certificates7"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates7;
                stiReport1["Test_Certificates8"] = Program.ProjectList[CurrentProjectIndex].Test_Certificates8;
                stiReport1["Flange_Face"] = Program.ProjectList[CurrentProjectIndex].FlangeFace;
                stiReport1["End_Connection"] = Program.ProjectList[CurrentProjectIndex].InletConnection + " X " + Program.ProjectList[CurrentProjectIndex].OutletConnection;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;
                return;
            }
        }
        private void btnDataSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (FluidType == "Gas")
                    CreateGasDataSheetReports();
                else if (FluidType == "Liquid")
                    CreateLiquidDataSheetReports();
                else if (FluidType == "Steam")
                    CreateSteamDataSheetReports();
                else if (FluidType == "2-Phase")
                    Create2PhaseDataSheetReports();
            }
            catch
            {

            }
        }


        private void btnCalculation_Click(object sender, EventArgs e)
        {
            try
            {
                if (FluidType == "Gas")
                    CreateGasCalculationReports();
                else if (FluidType == "Liquid")
                    CreateLiquidCalculationReports();
                else if (FluidType == "Steam")
                    CreateSteamCalculationReports();
                else if (FluidType == "2-Phase")
                {
                    if (Formule2Phase == "C22")
                        Create2PhaseC22CalculationReports();
                    if (Formule2Phase == "C23")
                        Create2PhaseC23CalculationReports();
                }
            }
            catch
            {

            }

        }

        private void CreateGasCalculationReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\GasCalculationSheetSafety.mrt");
                stiReport1.Compile();
                Program.ProjectList[CurrentProjectIndex].P2 = (Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].Back_Pressure) + Convert.ToDecimal(txbAtmPressure.Text)).ToString();
                Program.ProjectList[CurrentProjectIndex].P2_unit = "Psia";
                Program.ProjectList[CurrentProjectIndex].PR = (Math.Round(Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].P2) / Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].P1),2)).ToString();
                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Valve_Size"] = Program.ProjectList[CurrentProjectIndex].Valve_Size;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Molecular_Weight"] = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                stiReport1["Compressibility"] = Program.ProjectList[CurrentProjectIndex].Compressibility;
                stiReport1["K"] = Program.ProjectList[CurrentProjectIndex].k;
                stiReport1["Required_Mass_Flow"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Required_Mass_Flow1"] = Program.ProjectList[CurrentProjectIndex].Required_Mass_Flow1;
                stiReport1["Set_Pressure"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["Set_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Set_Pressure1;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Over_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure1;
                stiReport1["Inlet_Line_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss;
                stiReport1["Inlet_Line_Loss1"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss1;
                stiReport1["Back_Pressure"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure;
                stiReport1["Back_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure1;
                stiReport1["Atmospheric_Pressure"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;
                stiReport1["Atmospheric_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure1;
                stiReport1["Relieving_Temperature"] = Program.ProjectList[CurrentProjectIndex].Relieving_Temperature;
                stiReport1["Relieving_Temperature1"] = Program.ProjectList[CurrentProjectIndex].Relieving_Temperature1;
                stiReport1["Distance_from_Valve"] = Program.ProjectList[CurrentProjectIndex].Distance_from_Valve;
                stiReport1["Distance_From_Valve1"] = Program.ProjectList[CurrentProjectIndex].Distance_From_Valve1;
                stiReport1["Rupture_Disc_CCF"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF;
                stiReport1["Rupture_Disc_CCF1"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF1;
                stiReport1["Superheat_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Superheat_Correction_Factor;
                stiReport1["Superheat_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Superheat_Correction_Factor1;
                stiReport1["Supercritical_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Supercritical_Correction_Factor;
                stiReport1["Supercritical_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Supercritical_Correction_Factor1;
                stiReport1["Discharge_Coefficient"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient;
                stiReport1["Discharge_Coefficient1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient1;
                stiReport1["Discharge_Coefficien_derated"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficien_derated;
                stiReport1["Discharge_Coefficient_Derated1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient_Derated1;
                stiReport1["Orifice_Area"] = Program.ProjectList[CurrentProjectIndex].Orifice_Area;
                stiReport1["Back_Pressure_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor;
                stiReport1["Back_Pressure_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor1;
                stiReport1["Outlet_Diameter"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter;
                stiReport1["Outlet_Diameter1"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter1;
                stiReport1["P1"] = Program.ProjectList[CurrentProjectIndex].P1;
                stiReport1["P1_unit"] = Program.ProjectList[CurrentProjectIndex].P1_unit;
                stiReport1["P2"] = Program.ProjectList[CurrentProjectIndex].P2;
                stiReport1["P2_unit"] = Program.ProjectList[CurrentProjectIndex].P2_unit;
                stiReport1["PR"] = Program.ProjectList[CurrentProjectIndex].PR;
                stiReport1["PR_unit"] = Program.ProjectList[CurrentProjectIndex].PR_unit;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].C;
                stiReport1["A"] = Program.ProjectList[CurrentProjectIndex].A;
                stiReport1["V"] = Program.ProjectList[CurrentProjectIndex].V;
                stiReport1["V1"] = Program.ProjectList[CurrentProjectIndex].V1;
                stiReport1["L30"] = Program.ProjectList[CurrentProjectIndex].L30;
                stiReport1["L1"] = Program.ProjectList[CurrentProjectIndex].L1;
                stiReport1["Lp"] = Program.ProjectList[CurrentProjectIndex].Lp;
                stiReport1["Ao"] = Program.ProjectList[CurrentProjectIndex].Ao;
                stiReport1["Po"] = Program.ProjectList[CurrentProjectIndex].Po;
                stiReport1["Fr"] = Program.ProjectList[CurrentProjectIndex].Fr;
                stiReport1["W"] = Program.ProjectList[CurrentProjectIndex].W;
                stiReport1["W1"] = Program.ProjectList[CurrentProjectIndex].W1;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }

        private void Create2PhaseC23CalculationReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\TwoPhaseC23CalculationSheetSafety.mrt");
                stiReport1.Compile();
                Program.ProjectList[CurrentProjectIndex].P2 = (Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].Back_Pressure) + Convert.ToDecimal(txbAtmPressure.Text)).ToString();
                Program.ProjectList[CurrentProjectIndex].P2_unit = "Psia";
                Program.ProjectList[CurrentProjectIndex].PR = (Math.Round(Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].P2) / Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].P1), 2)).ToString();
                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Valve_Size"] = Program.ProjectList[CurrentProjectIndex].Valve_Size;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Molecular_Weight"] = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                stiReport1["Compressibility"] = Program.ProjectList[CurrentProjectIndex].Compressibility;
                stiReport1["K"] = Program.ProjectList[CurrentProjectIndex].k;
                stiReport1["Required_Mass_Flow"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Required_Mass_Flow1"] = Program.ProjectList[CurrentProjectIndex].Required_Mass_Flow1;
                stiReport1["Set_Pressure"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["Set_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Set_Pressure1;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Over_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure1;
                stiReport1["Inlet_Line_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss;
                stiReport1["Inlet_Line_Loss1"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss1;
                stiReport1["Back_Pressure"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure;
                stiReport1["Back_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure1;
                stiReport1["Atmospheric_Pressure"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;
                stiReport1["Atmospheric_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure1;
                stiReport1["Relieving_Temperature"] = Program.ProjectList[CurrentProjectIndex].Relieving_Temperature;
                stiReport1["Relieving_Temperature1"] = Program.ProjectList[CurrentProjectIndex].Relieving_Temperature1;
                stiReport1["Distance_from_Valve"] = Program.ProjectList[CurrentProjectIndex].Distance_from_Valve;
                stiReport1["Distance_From_Valve1"] = Program.ProjectList[CurrentProjectIndex].Distance_From_Valve1;
                stiReport1["Rupture_Disc_CCF"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF;
                stiReport1["Rupture_Disc_CCF1"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF1;
                stiReport1["Superheat_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Superheat_Correction_Factor;
                stiReport1["Superheat_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Superheat_Correction_Factor1;
                stiReport1["Supercritical_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Supercritical_Correction_Factor;
                stiReport1["Supercritical_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Supercritical_Correction_Factor1;
                stiReport1["Discharge_Coefficient"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient;
                stiReport1["Discharge_Coefficient1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient1;
                stiReport1["Discharge_Coefficien_derated"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficien_derated;
                stiReport1["Discharge_Coefficient_Derated1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient_Derated1;
                stiReport1["Orifice_Area"] = Program.ProjectList[CurrentProjectIndex].Orifice_Area;
                stiReport1["Back_Pressure_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor;
                stiReport1["Back_Pressure_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor1;
                stiReport1["Outlet_Diameter"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter;
                stiReport1["Outlet_Diameter1"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter1;
                stiReport1["P1"] = Program.ProjectList[CurrentProjectIndex].P1;
                stiReport1["P1_unit"] = Program.ProjectList[CurrentProjectIndex].P1_unit;
                stiReport1["P2"] = Program.ProjectList[CurrentProjectIndex].P2;
                stiReport1["P2_unit"] = Program.ProjectList[CurrentProjectIndex].P2_unit;
                stiReport1["PR"] = Program.ProjectList[CurrentProjectIndex].PR;
                stiReport1["PR_unit"] = Program.ProjectList[CurrentProjectIndex].PR_unit;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].C;
                stiReport1["A"] = Program.ProjectList[CurrentProjectIndex].A;
                stiReport1["W"] = Program.ProjectList[CurrentProjectIndex].W;
                stiReport1["W1"] = Program.ProjectList[CurrentProjectIndex].W1;
                stiReport1["Kv"] = Program.ProjectList[CurrentProjectIndex].Kv;
                stiReport1["Eta_st"] = Program.ProjectList[CurrentProjectIndex].Eta_st;
                stiReport1["Pc"] = Program.ProjectList[CurrentProjectIndex].Pc;
                stiReport1["Pc_Unit"] = Program.ProjectList[CurrentProjectIndex].Pc_Unit;
                stiReport1["High_Subcooling"] = Program.ProjectList[CurrentProjectIndex].High_Subcooling;
                stiReport1["Omega"] = Program.ProjectList[CurrentProjectIndex].Omega;
                stiReport1["G"] = Program.ProjectList[CurrentProjectIndex].G;
                stiReport1["G_Unit"] = Program.ProjectList[CurrentProjectIndex].G_Unit;
                stiReport1["G_Critical"] = Program.ProjectList[CurrentProjectIndex].G_Critical;
                stiReport1["G_SubCritical"] = Program.ProjectList[CurrentProjectIndex].G_SubCritical;
                stiReport1["Ps"] = Program.ProjectList[CurrentProjectIndex].Ps;
                stiReport1["Sub_Critical"] = Program.ProjectList[CurrentProjectIndex].Sub_Critical;
                stiReport1["ro_l0"] = Program.ProjectList[CurrentProjectIndex].ro_l0;
                stiReport1["ro_9"] = Program.ProjectList[CurrentProjectIndex].ro_9;
                stiReport1["Areq"] = Program.ProjectList[CurrentProjectIndex].Areq;
                stiReport1["Areq_Unit"] = Program.ProjectList[CurrentProjectIndex].Areq_Unit;


                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }

        private void Create2PhaseC22CalculationReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\TwoPhaseC22CalculationSheetSafety.mrt");
                stiReport1.Compile();
                Program.ProjectList[CurrentProjectIndex].P2 = (Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].Back_Pressure) + Convert.ToDecimal(txbAtmPressure.Text)).ToString();
                Program.ProjectList[CurrentProjectIndex].P2_unit = "Psia";
                Program.ProjectList[CurrentProjectIndex].PR = (Math.Round(Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].P2) / Convert.ToDecimal(Program.ProjectList[CurrentProjectIndex].P1), 2)).ToString();
                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Valve_Size"] = Program.ProjectList[CurrentProjectIndex].Valve_Size;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Molecular_Weight"] = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                stiReport1["Compressibility"] = Program.ProjectList[CurrentProjectIndex].Compressibility;
                stiReport1["K"] = Program.ProjectList[CurrentProjectIndex].k;
                stiReport1["Required_Mass_Flow"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Required_Mass_Flow1"] = Program.ProjectList[CurrentProjectIndex].Required_Mass_Flow1;
                stiReport1["Set_Pressure"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["Set_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Set_Pressure1;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Over_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure1;
                stiReport1["Inlet_Line_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss;
                stiReport1["Inlet_Line_Loss1"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss1;
                stiReport1["Back_Pressure"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure;
                stiReport1["Back_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure1;
                stiReport1["Atmospheric_Pressure"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;
                stiReport1["Atmospheric_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure1;
                stiReport1["Relieving_Temperature"] = Program.ProjectList[CurrentProjectIndex].Relieving_Temperature;
                stiReport1["Relieving_Temperature1"] = Program.ProjectList[CurrentProjectIndex].Relieving_Temperature1;
                stiReport1["Distance_from_Valve"] = Program.ProjectList[CurrentProjectIndex].Distance_from_Valve;
                stiReport1["Distance_From_Valve1"] = Program.ProjectList[CurrentProjectIndex].Distance_From_Valve1;
                stiReport1["Rupture_Disc_CCF"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF;
                stiReport1["Rupture_Disc_CCF1"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF1;
                stiReport1["Superheat_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Superheat_Correction_Factor;
                stiReport1["Superheat_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Superheat_Correction_Factor1;
                stiReport1["Supercritical_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Supercritical_Correction_Factor;
                stiReport1["Supercritical_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Supercritical_Correction_Factor1;
                stiReport1["Discharge_Coefficient"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient;
                stiReport1["Discharge_Coefficient1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient1;
                stiReport1["Discharge_Coefficien_derated"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficien_derated;
                stiReport1["Discharge_Coefficient_Derated1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient_Derated1;
                stiReport1["Orifice_Area"] = Program.ProjectList[CurrentProjectIndex].Orifice_Area;
                stiReport1["Back_Pressure_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor;
                stiReport1["Back_Pressure_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor1;
                stiReport1["Outlet_Diameter"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter;
                stiReport1["Outlet_Diameter1"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter1;
                stiReport1["P1"] = Program.ProjectList[CurrentProjectIndex].P1;
                stiReport1["P1_unit"] = Program.ProjectList[CurrentProjectIndex].P1_unit;
                stiReport1["P2"] = Program.ProjectList[CurrentProjectIndex].P2;
                stiReport1["P2_unit"] = Program.ProjectList[CurrentProjectIndex].P2_unit;
                stiReport1["PR"] = Program.ProjectList[CurrentProjectIndex].PR;
                stiReport1["PR_unit"] = Program.ProjectList[CurrentProjectIndex].PR_unit;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].C;
                stiReport1["A"] = Program.ProjectList[CurrentProjectIndex].A;
                stiReport1["W"] = Program.ProjectList[CurrentProjectIndex].W;
                stiReport1["W1"] = Program.ProjectList[CurrentProjectIndex].W1;
                stiReport1["Operating_Density"] = Program.ProjectList[CurrentProjectIndex].Operating_Density;
                stiReport1["Viscosity"] = Program.ProjectList[CurrentProjectIndex].Viscosity;
                stiReport1["V0"] = Program.ProjectList[CurrentProjectIndex].V0;
                stiReport1["V90"] = Program.ProjectList[CurrentProjectIndex].V90;
                stiReport1["Kv"] = Program.ProjectList[CurrentProjectIndex].Kv;
                stiReport1["Omega"] = Program.ProjectList[CurrentProjectIndex].Omega;
                stiReport1["Eta_c"] = Program.ProjectList[CurrentProjectIndex].Eta_c;
                stiReport1["Pc"] = Program.ProjectList[CurrentProjectIndex].Pc;
                stiReport1["Pc_Unit"] = Program.ProjectList[CurrentProjectIndex].Pc_Unit;
                stiReport1["Sub_Critical"] = Program.ProjectList[CurrentProjectIndex].Sub_Critical;
                stiReport1["G"] = Program.ProjectList[CurrentProjectIndex].G;
                stiReport1["G_Unit"] = Program.ProjectList[CurrentProjectIndex].G_Unit;
                stiReport1["Areq"] = Program.ProjectList[CurrentProjectIndex].Areq;
                stiReport1["Areq_Unit"] = Program.ProjectList[CurrentProjectIndex].Areq_Unit;


                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }
        private void CreateLiquidCalculationReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\LiquidCalculationSheetSafety.mrt");
                stiReport1.Compile();

                Program.ProjectList[CurrentProjectIndex].Pa = (Convert.ToDecimal(txbSetPressure.Text) + Convert.ToDecimal(txbAtmPressure.Text) + Convert.ToDecimal(txbOverPressure.Text) - Convert.ToDecimal(txbInletLoss.Text)).ToString() + "   Psia" ;
                Program.ProjectList[CurrentProjectIndex].Pb = (Convert.ToDecimal(txbTotalBackPressure.Text) + Convert.ToDecimal(txbAtmPressure.Text)).ToString() + "   Psia";
                Program.ProjectList[CurrentProjectIndex].VL = Program.ProjectList[CurrentProjectIndex].Flow_Actual + "  lb/hr";

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Valve_Size"] = Program.ProjectList[CurrentProjectIndex].Valve_Size;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Specific_Gravity"] = Program.ProjectList[CurrentProjectIndex].Specific_Gravity;
                stiReport1["Viscosity"] = Program.ProjectList[CurrentProjectIndex].Viscosity;
                stiReport1["Required_Mass_Flow"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Required_Mass_Flow1"] = Program.ProjectList[CurrentProjectIndex].Required_Mass_Flow1;
                stiReport1["Set_Pressure"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["Set_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Set_Pressure1;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Over_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure1;
                stiReport1["Inlet_Line_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss;
                stiReport1["Inlet_Line_Loss1"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss1;
                stiReport1["Back_Pressure"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure;
                stiReport1["Back_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure1;
                stiReport1["Rupture_Disc_CCF"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF;
                stiReport1["Rupture_Disc_CCF1"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF1;
                stiReport1["Discharge_Coefficient"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient;
                stiReport1["Discharge_Coefficient1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient1;
                stiReport1["Discharge_Coefficien_derated"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficien_derated;
                stiReport1["Discharge_Coefficient_Derated1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient_Derated1;
                stiReport1["Orifice_Area"] = Program.ProjectList[CurrentProjectIndex].Orifice_Area;
                stiReport1["Back_Pressure_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor;
                stiReport1["Back_Pressure_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor1;
                stiReport1["Kv"] = Program.ProjectList[CurrentProjectIndex].Kv;
                stiReport1["Kv_Max"] = Program.ProjectList[CurrentProjectIndex].Kv_Max;
                stiReport1["Outlet_Diameter"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter;
                stiReport1["Pa"] = Program.ProjectList[CurrentProjectIndex].Pa;
                stiReport1["Pa_unit"] = Program.ProjectList[CurrentProjectIndex].Pa_unit;
                stiReport1["Pb"] = Program.ProjectList[CurrentProjectIndex].Pb;
                stiReport1["Pb_unit"] = Program.ProjectList[CurrentProjectIndex].Pb_unit;
                stiReport1["PR"] = Program.ProjectList[CurrentProjectIndex].PR;
                stiReport1["PR_unit"] = Program.ProjectList[CurrentProjectIndex].PR_unit;
                stiReport1["VL"] = Program.ProjectList[CurrentProjectIndex].VL;
                stiReport1["VL1"] = Program.ProjectList[CurrentProjectIndex].VL1;
                stiReport1["R"] = Program.ProjectList[CurrentProjectIndex].R;
                stiReport1["R1"] = Program.ProjectList[CurrentProjectIndex].R1;
                stiReport1["L30"] = Program.ProjectList[CurrentProjectIndex].L30;
                stiReport1["L1"] = Program.ProjectList[CurrentProjectIndex].L1;
                stiReport1["Lp"] = Program.ProjectList[CurrentProjectIndex].Lp;
                stiReport1["Ao"] = Program.ProjectList[CurrentProjectIndex].Ao;
                stiReport1["Po"] = Program.ProjectList[CurrentProjectIndex].Po;
                stiReport1["Fr"] = Program.ProjectList[CurrentProjectIndex].Fr;
                stiReport1["Areq"] = Program.ProjectList[CurrentProjectIndex].Areq;
                stiReport1["Areq1"] = Program.ProjectList[CurrentProjectIndex].Areq1;
                stiReport1["R_Max"] = Program.ProjectList[CurrentProjectIndex].R_Max;
                stiReport1["R_Max1"] = Program.ProjectList[CurrentProjectIndex].R_Max1;
                stiReport1["Kw"] = Program.ProjectList[CurrentProjectIndex].Kw;
                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }

        private void CreateSteamCalculationReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\SteamCalculationSheetSafety.mrt");
                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["Fluid_State_at_Inlet"] = Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet;
                stiReport1["Valve_Size"] = Program.ProjectList[CurrentProjectIndex].Valve_Size;
                stiReport1["Area_Calculated"] = Program.ProjectList[CurrentProjectIndex].Area_Calculated;
                stiReport1["Area_Selected"] = Program.ProjectList[CurrentProjectIndex].Area_Selected;
                stiReport1["Flow_Actual"] = Program.ProjectList[CurrentProjectIndex].Flow_Actual;
                stiReport1["Flow_Required"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Estimated_Reaction_Force"] = Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force;
                stiReport1["Estimated_Noise_Level"] = Program.ProjectList[CurrentProjectIndex].Estimated_Noise_Level;
                stiReport1["Design_Code"] = Program.ProjectList[CurrentProjectIndex].Design_Code;
                stiReport1["Sizing_Std"] = Program.ProjectList[CurrentProjectIndex].Sizing_Std;
                stiReport1["Molecular_Weight"] = Program.ProjectList[CurrentProjectIndex].Molecular_Weight;
                stiReport1["Ratio_of_Specific_Heats"] = Program.ProjectList[CurrentProjectIndex].Ratio_of_Specific_Heats;
                stiReport1["Inlet_Stagnation_Enthalpy"] = Program.ProjectList[CurrentProjectIndex].Inlet_Stagnation_Enthalpy;


                stiReport1["Required_Mass_Flow"] = Program.ProjectList[CurrentProjectIndex].Flow_Required;
                stiReport1["Required_Mass_Flow1"] = Program.ProjectList[CurrentProjectIndex].Required_Mass_Flow1;
                stiReport1["Set_Pressure"] = Program.ProjectList[CurrentProjectIndex].SET_PRESSURE;
                stiReport1["Set_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Set_Pressure1;
                stiReport1["Over_Pressure"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure;
                stiReport1["Over_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Over_Pressure1;
                stiReport1["Inlet_Line_Loss"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss;
                stiReport1["Inlet_Line_Loss1"] = Program.ProjectList[CurrentProjectIndex].Inlet_Line_Loss1;
                stiReport1["Back_Pressure"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure;
                stiReport1["Back_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure1;
                stiReport1["Atmospheric_Pressure"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure;
                stiReport1["Atmospheric_Pressure1"] = Program.ProjectList[CurrentProjectIndex].Atmospheric_Pressure1;
                stiReport1["Relieving_Temperature"] = Program.ProjectList[CurrentProjectIndex].Relieving_Temperature;
                stiReport1["Relieving_Temperature1"] = Program.ProjectList[CurrentProjectIndex].Relieving_Temperature1;
                stiReport1["Distance_from_Valve"] = Program.ProjectList[CurrentProjectIndex].Distance_from_Valve;
                stiReport1["Distance_From_Valve1"] = Program.ProjectList[CurrentProjectIndex].Distance_From_Valve1;
                stiReport1["Rupture_Disc_CCF"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF;
                stiReport1["Rupture_Disc_CCF1"] = Program.ProjectList[CurrentProjectIndex].Rupture_Disc_CCF1;
                stiReport1["Superheat_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Superheat_Correction_Factor;
                stiReport1["Superheat_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Superheat_Correction_Factor1;
                stiReport1["Supercritical_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Supercritical_Correction_Factor;
                stiReport1["Supercritical_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Supercritical_Correction_Factor1;


                stiReport1["Discharge_Coefficient"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient;
                stiReport1["Discharge_Coefficient1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient1;
                stiReport1["Discharge_Coefficien_derated"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficien_derated;
                stiReport1["Discharge_Coefficient_Derated1"] = Program.ProjectList[CurrentProjectIndex].Discharge_Coefficient_Derated1;
                stiReport1["Orifice_Area"] = Program.ProjectList[CurrentProjectIndex].Orifice_Area;
                stiReport1["Back_Pressure_Correction_Factor"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor;
                stiReport1["Back_Pressure_Correction_Factor1"] = Program.ProjectList[CurrentProjectIndex].Back_Pressure_Correction_Factor1;
                stiReport1["Outlet_Diameter"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter;
                stiReport1["Outlet_Diameter1"] = Program.ProjectList[CurrentProjectIndex].Outlet_Diameter1;
                stiReport1["P1"] = Program.ProjectList[CurrentProjectIndex].P1;
                stiReport1["P1_unit"] = Program.ProjectList[CurrentProjectIndex].P1_unit;
                stiReport1["P2"] = Program.ProjectList[CurrentProjectIndex].P2;
                stiReport1["P2_unit"] = Program.ProjectList[CurrentProjectIndex].P2_unit;
                stiReport1["PR"] = Program.ProjectList[CurrentProjectIndex].PR;
                stiReport1["PR_unit"] = Program.ProjectList[CurrentProjectIndex].PR_unit;
                stiReport1["Kn"] = Program.ProjectList[CurrentProjectIndex].Kn;
                stiReport1["Kn1"] = Program.ProjectList[CurrentProjectIndex].Kn1;
                stiReport1["W"] = Program.ProjectList[CurrentProjectIndex].W;
                stiReport1["W1"] = Program.ProjectList[CurrentProjectIndex].W1;
                stiReport1["Areq"] = Program.ProjectList[CurrentProjectIndex].Areq;
                stiReport1["Areq1"] = Program.ProjectList[CurrentProjectIndex].Areq1;
                stiReport1["L30"] = Program.ProjectList[CurrentProjectIndex].L30;
                stiReport1["L1"] = Program.ProjectList[CurrentProjectIndex].L1;
                stiReport1["Lp"] = Program.ProjectList[CurrentProjectIndex].Lp;
                stiReport1["Ao"] = Program.ProjectList[CurrentProjectIndex].Ao;
                stiReport1["Po"] = Program.ProjectList[CurrentProjectIndex].Po;
                stiReport1["Fr"] = Program.ProjectList[CurrentProjectIndex].Fr;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }

        private void btnDrawing_Click(object sender, EventArgs e)
        {
            try
            {
                if (FluidType == "Gas")
                    CreateGasDrowingReports();
                else if (FluidType == "Liquid")
                    CreateLiquidDrowingReports();
                else if (FluidType == "Steam")
                    CreateSteamDrowingReports();
                else if (FluidType == "2-Phase")
                    Create2PhaseDrowingReports();
            }
            catch
            {

            }
        }

        private void CreateGasDrowingReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\GasGeneralDrawingSafety.mrt");
                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;

                stiReport1["Inle_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Inle_Size_Connection;
                stiReport1["Outlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection;
                stiReport1["ACCESSORIES"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES1;
                stiReport1["ACCESSORIES1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES2;
                stiReport1["ACCESSORIES2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES3;
                stiReport1["ACCESSORIES3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES4;
                stiReport1["ACCESSORIES4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES5;
                stiReport1["ACCESSORIES_Material"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material;
                stiReport1["ACCESSORIES_Material1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material1;
                stiReport1["ACCESSORIES_Material2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material2;
                stiReport1["ACCESSORIES_Material3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material3;
                stiReport1["ACCESSORIES_Material4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material4;
                stiReport1["A"] = Program.ProjectList[CurrentProjectIndex].AA;
                stiReport1["B"] = Program.ProjectList[CurrentProjectIndex].B;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].CC;
                stiReport1["D"] = Program.ProjectList[CurrentProjectIndex].D;
                stiReport1["WEIGHT"] = Program.ProjectList[CurrentProjectIndex].WEIGHT;
                stiReport1["Body_Material"] = Program.ProjectList[CurrentProjectIndex].Body_Bonnet;
                stiReport1["Disk_Material"] = Program.ProjectList[CurrentProjectIndex].Disc;
                stiReport1["Spring_Material"] = Program.ProjectList[CurrentProjectIndex].Spring;
                stiReport1["Nozzle_Material"] = Program.ProjectList[CurrentProjectIndex].Nozzle_Materials;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }

        private void Create2PhaseDrowingReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                if (Formule2Phase == "C22")
                    stiReport1.Load(Application.StartupPath + "\\Reports\\TwoPhaseC22DrawingSafety.mrt");
                if (Formule2Phase == "C23")
                    stiReport1.Load(Application.StartupPath + "\\Reports\\TwoPhaseC23DrawingSafety.mrt");

                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;

                stiReport1["Inle_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Inle_Size_Connection;
                stiReport1["Outlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection;
                stiReport1["ACCESSORIES"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES1;
                stiReport1["ACCESSORIES1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES2;
                stiReport1["ACCESSORIES2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES3;
                stiReport1["ACCESSORIES3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES4;
                stiReport1["ACCESSORIES4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES5;
                stiReport1["ACCESSORIES_Material"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material;
                stiReport1["ACCESSORIES_Material1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material1;
                stiReport1["ACCESSORIES_Material2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material2;
                stiReport1["ACCESSORIES_Material3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material3;
                stiReport1["ACCESSORIES_Material4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material4;
                stiReport1["A"] = Program.ProjectList[CurrentProjectIndex].AA;
                stiReport1["B"] = Program.ProjectList[CurrentProjectIndex].B;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].CC;
                stiReport1["D"] = Program.ProjectList[CurrentProjectIndex].D;
                stiReport1["WEIGHT"] = Program.ProjectList[CurrentProjectIndex].WEIGHT;
                stiReport1["Body_Material"] = Program.ProjectList[CurrentProjectIndex].Body_Bonnet;
                stiReport1["Disk_Material"] = Program.ProjectList[CurrentProjectIndex].Disc;
                stiReport1["Spring_Material"] = Program.ProjectList[CurrentProjectIndex].Spring;
                stiReport1["Nozzle_Material"] = Program.ProjectList[CurrentProjectIndex].Nozzle_Materials;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }
        private void CreateLiquidDrowingReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\LiquidGeneralDrawingSafety.mrt");
                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;

                stiReport1["Inle_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Inle_Size_Connection;
                stiReport1["Outlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection;
                stiReport1["ACCESSORIES"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES1;
                stiReport1["ACCESSORIES1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES2;
                stiReport1["ACCESSORIES2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES3;
                stiReport1["ACCESSORIES3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES4;
                stiReport1["ACCESSORIES4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES5;
                stiReport1["ACCESSORIES_Material"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material;
                stiReport1["ACCESSORIES_Material1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material1;
                stiReport1["ACCESSORIES_Material2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material2;
                stiReport1["ACCESSORIES_Material3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material3;
                stiReport1["ACCESSORIES_Material4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material4;
                stiReport1["A"] = Program.ProjectList[CurrentProjectIndex].AA;
                stiReport1["B"] = Program.ProjectList[CurrentProjectIndex].B;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].CC;
                stiReport1["D"] = Program.ProjectList[CurrentProjectIndex].D;
                stiReport1["WEIGHT"] = Program.ProjectList[CurrentProjectIndex].WEIGHT;
                stiReport1["Body_Material"] = Program.ProjectList[CurrentProjectIndex].Body_Bonnet;
                stiReport1["Disk_Material"] = Program.ProjectList[CurrentProjectIndex].Disc;
                stiReport1["Spring_Material"] = Program.ProjectList[CurrentProjectIndex].Spring;
                stiReport1["Nozzle_Material"] = Program.ProjectList[CurrentProjectIndex].Nozzle_Materials;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }

        private void CreateSteamDrowingReports()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\SteamGeneralDrawingSafety.mrt");
                stiReport1.Compile();

                stiReport1["Client"] = Program.ProjectList[CurrentProjectIndex].Client;
                stiReport1["End_User_Ref"] = Program.ProjectList[CurrentProjectIndex].End_User_Ref;
                stiReport1["Location"] = Program.ProjectList[CurrentProjectIndex].Location;
                stiReport1["Project"] = Program.ProjectList[CurrentProjectIndex].ProjectName;
                stiReport1["Project_Ref"] = Program.ProjectList[CurrentProjectIndex].Project_Ref;
                stiReport1["Tag_No"] = Program.ProjectList[CurrentProjectIndex].Tag_No;
                stiReport1["Quantity"] = Program.ProjectList[CurrentProjectIndex].Quantity;
                stiReport1["Valve_Model_No"] = Program.ProjectList[CurrentProjectIndex].Valve_Model_No;
                stiReport1["RadmanRef"] = Program.ProjectList[CurrentProjectIndex].RadmanRef;

                stiReport1["Inle_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Inle_Size_Connection;
                stiReport1["Outlet_Size_Connection"] = Program.ProjectList[CurrentProjectIndex].Outlet_Size_Connection;
                stiReport1["ACCESSORIES"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES1;
                stiReport1["ACCESSORIES1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES2;
                stiReport1["ACCESSORIES2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES3;
                stiReport1["ACCESSORIES3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES4;
                stiReport1["ACCESSORIES4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES5;
                stiReport1["ACCESSORIES_Material"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material;
                stiReport1["ACCESSORIES_Material1"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material1;
                stiReport1["ACCESSORIES_Material2"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material2;
                stiReport1["ACCESSORIES_Material3"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material3;
                stiReport1["ACCESSORIES_Material4"] = Program.ProjectList[CurrentProjectIndex].ACCESSORIES_Material4;
                stiReport1["A"] = Program.ProjectList[CurrentProjectIndex].AA;
                stiReport1["B"] = Program.ProjectList[CurrentProjectIndex].B;
                stiReport1["C"] = Program.ProjectList[CurrentProjectIndex].CC;
                stiReport1["D"] = Program.ProjectList[CurrentProjectIndex].D;
                stiReport1["WEIGHT"] = Program.ProjectList[CurrentProjectIndex].WEIGHT;
                stiReport1["Body_Material"] = Program.ProjectList[CurrentProjectIndex].Body_Bonnet;
                stiReport1["Disk_Material"] = Program.ProjectList[CurrentProjectIndex].Disc;
                stiReport1["Spring_Material"] = Program.ProjectList[CurrentProjectIndex].Spring;
                stiReport1["Nozzle_Material"] = Program.ProjectList[CurrentProjectIndex].Nozzle_Materials;

                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;

                return;
            }
        }

        private void btnSafety2PhaseC22_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.ProjectList[CurrentProjectIndex].ProjectName == "")
                    Program.ProjectList[CurrentProjectIndex].ProjectName = "Safety Relief Valve";

                Program.ProjectList[CurrentProjectIndex].Design_Code = "API 520, Part I, 9th ed, C.2.2";
                Program.ProjectList[CurrentProjectIndex].Sizing_Std = "API 520";
                Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet = "2-Phase";
                Program.ProjectList[CurrentProjectIndex].Safety_Relief = "Safety-Relief"; //RULE: 2
                Program.ProjectList[CurrentProjectIndex].Relieving_Case = "Pressure Relief";
                Program.ProjectList[CurrentProjectIndex].Fluid_Type = "2-Phase";
                Program.ProjectList[CurrentProjectIndex].Standard_Type = "API 520, Part I, 9th ed, C.2.2";
                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "")//load
                    Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name = "pageSizingSelection";


                FluidType = "2-Phase";
                Formule2Phase = "C22";
                pageCalculationType.Image = Image.FromFile(Program.ImagesPath + "CalculationTypeOff.png");
                pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionOn.png");
                pageSizingSelection.Enabled = true;
                pageMain.SelectedPage = pageSizingSelection;
                SelectedCodeSection = "API 520";
                FillPageSizing("2 Phase Flashing or Non-Flashing Flow (API 520, Part I, 9th ed, C.2.2 )");
            }
            catch
            {

            }
        }

        private void txbK_2phase_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbK_2phase.Text.Trim());
                if (!Validation)
                {
                    txbK_2phase.Text = "";
                    CheckAllValidation();
                }
                else
                {
                    Program.ProjectList[CurrentProjectIndex].k = txbK_2phase.Text;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbDensityGas_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbDensityGas.Text.Trim());
                if (!Validation)
                {
                    txbDensityGas.Text = "";
                    CheckAllValidation();
                }
                else
                {
                    Program.ProjectList[CurrentProjectIndex].GasDensity = txbDensityGas.Text;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbDensityLiquid_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbDensityLiquid.Text.Trim());
                if (!Validation)
                    txbDensityLiquid.Text = "";
                Program.ProjectList[CurrentProjectIndex].LiquidDensity = txbDensityLiquid.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbSpecificValumeGas_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbSpecificValumeGas.Text.Trim());
                if (!Validation)
                    txbSpecificValumeGas.Text = "";
                Program.ProjectList[CurrentProjectIndex].SpecificValumeGas = txbSpecificValumeGas.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbSpecificValumeLiquid_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbSpecificValumeLiquid.Text.Trim());
                if (!Validation)
                    txbSpecificValumeLiquid.Text = "";
                Program.ProjectList[CurrentProjectIndex].SpecificValumeLiquid = txbSpecificValumeLiquid.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbSpecificGravity_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbSpecificGravity.Text.Trim());
                if (!Validation)
                    txbSpecificGravity.Text = "";
                Program.ProjectList[CurrentProjectIndex].SpesificGravity = txbSpecificGravity.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbV90_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbV90.Text.Trim());
                if (!Validation)
                {
                    txbV90.Text = "";
                    Safety_2PhaseC22_V90Validation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC22_V90Validation = true;
                    Program.ProjectList[CurrentProjectIndex].V90 = txbV90.Text;

                    CheckAllValidation();
                }
            }
            catch
            {

            }

        }

        private void txbV1_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbV1.Text.Trim());
                if (!Validation)
                {
                    txbV1.Text = "";
                    Safety_2PhaseC22_V1Validation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC22_V1Validation = true;
                    Program.ProjectList[CurrentProjectIndex].V1 = txbV1.Text;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbVaporFlowCapacity_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbVaporFlowCapacity.Text.Trim());
                if (!Validation)
                {
                    txbVaporFlowCapacity.Text = "";
                    txbRequiredPressureFlow2Phase.Text = txbLiquidFlowCapacity.Text;
                }
                else
                {
                    if (txbLiquidFlowCapacity.Text != "")
                        txbRequiredPressureFlow2Phase.Text = (Convert.ToDecimal(txbLiquidFlowCapacity.Text) + Convert.ToDecimal(txbVaporFlowCapacity.Text)).ToString();
                    else
                        txbRequiredPressureFlow2Phase.Text = txbVaporFlowCapacity.Text;
                }
                bool RequiredPressureFlow2PhaseValidation = FloatValidation(txbRequiredPressureFlow2Phase.Text.Trim());
                if (!RequiredPressureFlow2PhaseValidation)
                {
                    Safety_2PhaseC22_RequiredPressureFlowValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC22_RequiredPressureFlowValidation = true;
                    Program.ProjectList[CurrentProjectIndex].VaporFlowCapacity = txbVaporFlowCapacity.Text;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbLiquidFlowCapacity_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbLiquidFlowCapacity.Text.Trim());
                if (!Validation)
                {
                    txbLiquidFlowCapacity.Text = "";
                    txbRequiredPressureFlow2Phase.Text = txbVaporFlowCapacity.Text;
                }
                else
                {
                    if (txbVaporFlowCapacity.Text != "")
                        txbRequiredPressureFlow2Phase.Text = (Convert.ToDecimal(txbLiquidFlowCapacity.Text) + Convert.ToDecimal(txbVaporFlowCapacity.Text)).ToString();
                    else
                        txbRequiredPressureFlow2Phase.Text = txbLiquidFlowCapacity.Text;
                }
                bool RequiredPressureFlow2PhaseValidation = FloatValidation(txbRequiredPressureFlow2Phase.Text.Trim());
                if (!RequiredPressureFlow2PhaseValidation)
                {
                    Safety_2PhaseC22_RequiredPressureFlowValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC22_RequiredPressureFlowValidation = true;
                    Program.ProjectList[CurrentProjectIndex].LiquidFlowCapacity = txbLiquidFlowCapacity.Text;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }



        private void btnSafety2PhaseC23_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.ProjectList[CurrentProjectIndex].ProjectName == "")
                    Program.ProjectList[CurrentProjectIndex].ProjectName = "Safety Relief Valve";

                Program.ProjectList[CurrentProjectIndex].Design_Code = "API 520, Part I, 9th ed, C.2.3";
                Program.ProjectList[CurrentProjectIndex].Sizing_Std = "API 520";
                Program.ProjectList[CurrentProjectIndex].Fluid_State_at_Inlet = "2-Phase";
                Program.ProjectList[CurrentProjectIndex].Safety_Relief = "Safety-Relief"; //RULE: 2
                Program.ProjectList[CurrentProjectIndex].Relieving_Case = "Pressure Relief";
                Program.ProjectList[CurrentProjectIndex].Fluid_Type = "2-Phase";
                Program.ProjectList[CurrentProjectIndex].Standard_Type = "API 520, Part I, 9th ed, C.2.3";
                if (Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name == "")//load
                    Program.ProjectList[CurrentProjectIndex].Current_TabPage_Name = "pageSizingSelection";


                FluidType = "2-Phase";
                Formule2Phase = "C23";
                pageCalculationType.Image = Image.FromFile(Program.ImagesPath + "CalculationTypeOff.png");
                pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionOn.png");
                pageSizingSelection.Enabled = true;
                pageMain.SelectedPage = pageSizingSelection;
                SelectedCodeSection = "API 520";
                FillPageSizing("Flashing Liquid - No Gas or Vapor (API 520, Part I, 9th ed, C.2.3 )");
            }
            catch
            {

            }
        }

        private void txbKv_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbKv.Text.Trim());
                if (!Validation)
                {
                    txbKv.Text = "1.0";
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_KvValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_KvValidation = true;
                    CheckAllValidation();
                }
                else
                {
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_KvValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_KvValidation = true;
                    CheckAllValidation();
                }
                Program.ProjectList[CurrentProjectIndex].Kv = txbKv.Text;
            }
            catch
            {

            }
        }

        private void cmbKd_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(cmbKd.Text.Trim());
                if (!Validation)
                {
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_KdValidation = false;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_KdValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    if (FluidType == "2-Phase" && Formule2Phase == "C22")
                        Safety_2PhaseC22_KdValidation = true;
                    if (FluidType == "2-Phase" && Formule2Phase == "C23")
                        Safety_2PhaseC23_KdValidation = true;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbVaporPressure_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbVaporPressure.Text.Trim());
                if (!Validation)
                {
                    txbVaporPressure.Text = "";
                    Safety_2PhaseC23_VaporPerssureValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC23_VaporPerssureValidation = true;
                    Program.ProjectList[CurrentProjectIndex].VaporPressure = txbVaporPressure.Text;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbLiquidDensity_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbLiquidDensity.Text.Trim());
                if (!Validation)
                {
                    txbLiquidDensity.Text = "";
                    Safety_2PhaseC23_LiquidDensityValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC23_LiquidDensityValidation = true;
                    Program.ProjectList[CurrentProjectIndex].LiquidDensity = txbLiquidDensity.Text;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbLiquidSpecific_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbLiquidSpecific.Text.Trim());
                if (!Validation)
                {
                    txbLiquidSpecific.Text = "";
                    Safety_2PhaseC23_LiquidDensityValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC23_LiquidDensityValidation = true;
                    Program.ProjectList[CurrentProjectIndex].LiquidSpecific = txbLiquidSpecific.Text;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbSpesificGravity_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbSpesificGravity.Text.Trim());
                if (!Validation)
                    txbSpesificGravity.Text = "";
                Program.ProjectList[CurrentProjectIndex].SpesificGravity = txbSpesificGravity.Text;
                CheckAllValidation();
            }
            catch
            {

            }
        }

        private void txbMixDensity90_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbMixDensity90.Text.Trim());
                if (!Validation)
                {
                    txbMixDensity90.Text = "";
                    Safety_2PhaseC23_MixDensityValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC23_MixDensityValidation = true;
                    Program.ProjectList[CurrentProjectIndex].MixDensity90 = txbMixDensity90.Text;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbSpVol90_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbSpVol90.Text.Trim());
                if (!Validation)
                {
                    txbSpVol90.Text = "";
                    Safety_2PhaseC23_MixDensityValidation = false;
                    CheckAllValidation();
                }
                else
                {
                    Safety_2PhaseC23_MixDensityValidation = true;
                    Program.ProjectList[CurrentProjectIndex].SpVol90 = txbSpVol90.Text;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void cmbSizingBasis_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                string op = "10";
                switch (cmbSizingBasis.SelectedIndex)
                {
                    case 1:
                    case 2:
                        op = "25";
                        break;
                    case 20:
                        op = "21";
                        break;
                    default:
                        op = "10";
                        break;
                }
                txbOverPressurePercent.Text = op;
                if (cmbSizingBasis.SelectedIndex == 4)
                {
                    //Thermal 
                    if (txbRelieving.Text != "" || txbSetPressure.Text != "")
                    {
                        pageSizingSelection.Image = Image.FromFile(Program.ImagesPath + "Sizing&SelectionCheck.png");
                        pageConfiguration.Image = Image.FromFile(Program.ImagesPath + "ConfigurationOn.png");
                        pageConfiguration.Enabled = true;
                        pageMain.SelectedPage = pageConfiguration;
                        FillConfigurationPage();
                        Program.ProjectList[CurrentProjectIndex].Sizing_Basis = cmbSizingBasis.SelectedText;
                        Program.ProjectList[CurrentProjectIndex].Saved = false;
                    }
                    else
                    {
                        frmShowInfo shinf = new frmShowInfo("Please enter required values", 2, "", "OK", "", "");
                        shinf.ShowDialog();
                        return;
                    }
                }

                
            }
            catch 
            {

            }
        }

        private void txbMolecularWeightC22_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbMolecularWeightC22.Text.Trim());
                if (!Validation)
                {
                    txbMolecularWeightC22.Text = "";
                    CheckAllValidation();
                }
                else
                {
                    Program.ProjectList[CurrentProjectIndex].Molecular_Weight = txbMolecularWeightC22.Text;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void txbCompressibilityC22_Leave(object sender, EventArgs e)
        {
            try
            {
                bool Validation = FloatValidation(txbCompressibilityC22.Text.Trim());
                if (!Validation)
                {
                    txbCompressibilityC22.Text = "";
                    CheckAllValidation();
                }
                else
                {
                    Program.ProjectList[CurrentProjectIndex].Compressibility = txbCompressibilityC22.Text;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                    CheckAllValidation();
                }
            }
            catch
            {

            }
        }

        private void rbtLiquidDensity_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtLiquidDensity.CheckState == CheckState.Checked)
                {
                    txbLiquidDensity.Enabled = true;
                    txbLiquidSpecific.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void rbtLiquidSpecific_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtLiquidSpecific.CheckState == CheckState.Checked)
                {
                    txbLiquidDensity.Enabled = false;
                    txbLiquidSpecific.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void rbtMixDensity90_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtMixDensity90.CheckState == CheckState.Checked)
                {
                    txbMixDensity90.Enabled = true;
                    txbSpVol90.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void rbtSpVol90_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtSpVol90.CheckState == CheckState.Checked)
                {
                    txbMixDensity90.Enabled = false;
                    txbSpVol90.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void rbtDensity_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtDensity.CheckState == CheckState.Checked)
                {
                    txbDensityGas.Enabled = true;
                    txbDensityLiquid.Enabled = true;
                    txbSpecificValumeGas.Enabled = false;
                    txbSpecificValumeLiquid.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void rbtSpecificValume_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (rbtSpecificValume.CheckState == CheckState.Checked)
                {
                    txbDensityGas.Enabled = false;
                    txbDensityLiquid.Enabled = false;
                    txbSpecificValumeGas.Enabled = true;
                    txbSpecificValumeLiquid.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void chbTemperaturesRanges_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Program.ProjectList[CurrentProjectIndex].Saved = false;
        }

        private void btnSafetyGasAsmeSec8_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetyGasAsmeSec8.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetyGasAsmeSec8.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyGasAsmeSec8.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetyGasAsmeSec8_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetyGasAsmeSec8.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetyGasAsmeSec8.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyGasAsmeSec8.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetyGasNoneCode9_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetyGasNoneCode9.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetyGasNoneCode9.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyGasNoneCode9.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetyGasNoneCode9_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetyGasNoneCode9.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetyGasNoneCode9.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyGasNoneCode9.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetyGasNoneCode6_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetyGasNoneCode6.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetyGasNoneCode6.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyGasNoneCode6.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetyGasNoneCode6_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetyGasNoneCode6.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetyGasNoneCode6.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyGasNoneCode6.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetyGasISO4126_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetyGasISO4126.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetyGasISO4126.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyGasISO4126.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetyGasISO4126_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetyGasISO4126.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetyGasISO4126.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyGasISO4126.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetyLiquidAsmeSec8_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetyLiquidAsmeSec8.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetyLiquidAsmeSec8.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyLiquidAsmeSec8.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetyLiquidAsmeSec8_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetyLiquidAsmeSec8.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetyLiquidAsmeSec8.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyLiquidAsmeSec8.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetyLiquidNoneCode9_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetyLiquidNoneCode9.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetyLiquidNoneCode9.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyLiquidNoneCode9.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetyLiquidNoneCode9_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetyLiquidNoneCode9.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetyLiquidNoneCode9.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyLiquidNoneCode9.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetyLiquidISO4126_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetyLiquidISO4126.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetyLiquidISO4126.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyLiquidISO4126.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetyLiquidISO4126_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetyLiquidISO4126.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetyLiquidISO4126.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetyLiquidISO4126.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetySteemAsmeSec1_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetySteemAsmeSec1.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetySteemAsmeSec1.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetySteemAsmeSec1.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetySteemAsmeSec1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetySteemAsmeSec1.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetySteemAsmeSec1.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetySteemAsmeSec1.ForeColor = Color.White;
            }
            catch
            {

            }

        }

        private void btnSafetySteemAsmeSec8_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetySteemAsmeSec8.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetySteemAsmeSec8.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetySteemAsmeSec8.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetySteemAsmeSec8_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetySteemAsmeSec8.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetySteemAsmeSec8.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetySteemAsmeSec8.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetySteemNonCode_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetySteemNonCode.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetySteemNonCode.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetySteemNonCode.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetySteemNonCode_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetySteemNonCode.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetySteemNonCode.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetySteemNonCode.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafetySteemISO4126_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafetySteemISO4126.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafetySteemISO4126.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetySteemISO4126.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafetySteemISO4126_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafetySteemISO4126.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafetySteemISO4126.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafetySteemISO4126.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafety2PhaseC22_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafety2PhaseC22.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafety2PhaseC22.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafety2PhaseC22.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafety2PhaseC22_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafety2PhaseC22.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafety2PhaseC22.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafety2PhaseC22.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void btnSafety2PhaseC23_MouseHover(object sender, EventArgs e)
        {
            try
            {
                btnSafety2PhaseC23.BackgroundImage = Properties.Resources.gary_curve_png;
                btnSafety2PhaseC23.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafety2PhaseC23.ForeColor = Color.Black;
            }
            catch
            {

            }
        }

        private void btnSafety2PhaseC23_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnSafety2PhaseC23.BackgroundImage = Properties.Resources.blue_curve_1;
                btnSafety2PhaseC23.BackgroundImageLayout = ImageLayout.Stretch;
                btnSafety2PhaseC23.ForeColor = Color.White;
            }
            catch
            {

            }
        }

        private void chbSelectionVIII_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                if (chbSelectionVIII.CheckState == CheckState.Checked)
                {
                    Program.ProjectList[CurrentProjectIndex].SelectionVIIIApplicationCheckBox = true;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                }
                else
                {
                    Program.ProjectList[CurrentProjectIndex].SelectionVIIIApplicationCheckBox = false;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                }
            }
            catch
            {

            }
        }

        private void txbValveModel_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Valve_Model_No = txbValveModel.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbCodeSection_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].CodeSection = txbCodeSection.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbValveService_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].ValveService = txbValveService.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbValveOrifice_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].ValveOrifice = txbValveOrifice.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void cmbTemperaturesRanges_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].TemperaturesRanges = cmbTemperaturesRanges.SelectedText;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void cmbInletConnection_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                DoBodyMaterialsLimit();
                int selectedIndex = cmbInletConnection.Items.IndexOf(cmbInletConnection.SelectedItem.Text);
                cmbInletConnection.ForeColor = cmbInletConnection.Items[selectedIndex].ForeColor;
                if ((string)cmbInletConnection.Items[selectedIndex].Tag == "Limited")
                {
                    cmbInletConnection.Items[selectedIndex].ForeColor = Color.Red;
                    rtxError.Visible = true;
                    string msg = "The following items cannot be chosen together: Inlet Connection (" + cmbInletConnection.Items[selectedIndex].Text + ") and Body Materials (" + Program.ProjectList[CurrentProjectIndex].BodyMaterial + ") in Relieving Temp(" + txbRelieving.Text + " °C) and Set Pressure (" + txbSetPressure.Text + " barg). (ASME B16.34-2017)";
                    CreateErrorLog("Class", msg);
                }
                else
                {
                    rtxError.Visible = false;
                    rtxError.Document.Selection.SelectAll();
                    rtxError.DocumentEditor.Delete(false);
                    cmbBodyMaterial.ForeColor = Color.Black;

                }
                switch (cmbInletConnection.SelectedIndex)
                {
                    case 0:
                        ClassA = "150";
                        if (SelectedSeries == "A")
                        {
                            if (ClassB == "150")
                                CreateCatalogNumber("1", 11, 1);
                        }
                        break;
                    case 1:
                        ClassA = "300";
                        if (SelectedSeries == "A")
                        {
                            if (ClassB == "150")
                                CreateCatalogNumber("2", 11, 1);
                        }
                        break;
                    case 2:
                        ClassA = "600";
                        if (SelectedSeries == "A")
                        {
                            if (ClassB == "150")
                                CreateCatalogNumber("3", 11, 1);
                        }
                        break;
                    case 3:
                        ClassA = "900";
                        if (SelectedSeries == "A")
                        {
                            if (ClassB == "150")
                                CreateCatalogNumber("4", 11, 1);
                            if (ClassB == "300")
                                CreateCatalogNumber("5", 11, 1);
                        }
                        break;
                    case 4:
                        ClassA = "1500";
                        if (SelectedSeries == "A")
                        {
                            if (ClassB == "150")
                                CreateCatalogNumber("6", 11, 1);
                            if (ClassB == "300")
                                CreateCatalogNumber("7", 11, 1);
                        }
                        break;
                    case 5:
                        ClassA = "2500";
                        if (SelectedSeries == "A")
                        {
                            if (ClassB == "300")
                                CreateCatalogNumber("8", 11, 1);
                        }
                        break;
                    case 8:
                        CreateCatalogNumber("1", 6, 1);
                        //CreateCatalogNumber("2", 4, 1);
                        break;
                    case 9:
                        CreateCatalogNumber("2", 6, 1);
                        // CreateCatalogNumber("2", 4, 1);
                        break;

                    case 12:
                        CreateCatalogNumber("2", 3, 1);
                        CreateCatalogNumber("2", 4, 1);
                        break;
                    case 13:
                        CreateCatalogNumber("3", 3, 1);
                        CreateCatalogNumber("2", 4, 1);
                        break;
                    case 14:
                        CreateCatalogNumber("7", 3, 1);
                        CreateCatalogNumber("6", 4, 1);
                        break;
                    case 15:
                        CreateCatalogNumber("C", 6, 1);
                        //CreateCatalogNumber("6", 4, 1);
                        break;
                    case 16:
                        CreateCatalogNumber("D", 6, 1);
                        //CreateCatalogNumber("6", 4, 1);
                        break;
                    case 17:
                        CreateCatalogNumber("4", 3, 1);
                        CreateCatalogNumber("4", 4, 1);
                        break;
                    case 18:
                        CreateCatalogNumber("3", 6, 1);
                        // CreateCatalogNumber("4", 4, 1);
                        break;
                    case 19:
                        CreateCatalogNumber("4", 6, 1);
                        // CreateCatalogNumber("4", 4, 1);
                        break;
                    case 20:
                        CreateCatalogNumber("5", 6, 1);
                        // CreateCatalogNumber("4", 4, 1);
                        break;
                    case 21:
                        CreateCatalogNumber("6", 6, 1);
                        // CreateCatalogNumber("4", 4, 1);
                        break;
                    case 22:
                        CreateCatalogNumber("X", 6, 1);
                        // CreateCatalogNumber("4", 4, 1);
                        break;

                }
                Program.ProjectList[CurrentProjectIndex].InletConnection = cmbInletConnection.SelectedItem.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void CreateErrorLog(string ErrorType, string ErrorMessage)
        {
            try
            {
                if (rtxError.Visible == false)
                    rtxError.Visible = true;
                rtxError.InsertLine(ErrorMessage);
            }
            catch
            {

            }
        }

        private void cmbOutletConnection_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].OutletConnection = cmbOutletConnection.SelectedItem.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
                switch (cmbOutletConnection.SelectedIndex)
                {
                    case 0:
                        ClassB = "150";
                        if (SelectedSeries == "A")
                        {
                            if (ClassA == "150")
                                CreateCatalogNumber("1", 6, 1);
                            if (ClassA == "300")
                                CreateCatalogNumber("2", 6, 1);
                            if (ClassA == "600")
                                CreateCatalogNumber("3", 6, 1);
                            if (ClassA == "900")
                                CreateCatalogNumber("4", 6, 1);
                            if (ClassA == "1500")
                                CreateCatalogNumber("6", 6, 1);
                        }
                        break;
                    case 1:
                        ClassB = "300";
                        if (SelectedSeries == "A")
                        {
                            if (ClassA == "900")
                                CreateCatalogNumber("5", 6, 1);
                            if (ClassA == "1500")
                                CreateCatalogNumber("7", 6, 1);
                            if (ClassA == "2500")
                                CreateCatalogNumber("8", 6, 1);
                        }
                        break;
                    case 8:
                        CreateCatalogNumber("D", 7, 1);
                        break;
                    case 9:
                        CreateCatalogNumber("1", 7, 1);
                        break;
                    case 10:
                        CreateCatalogNumber("2", 7, 1);
                        break;
                    case 11:
                        CreateCatalogNumber("X", 7, 1);
                        break;

                }
            }
            catch
            {

            }

        }

        private void cmbNozzleMaterial_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cmbNozzleMaterial.SelectedItem != null)
                {
                    if (SelectedSeries == "A")
                        CreateCatalogNumber(cmbNozzleMaterial.SelectedItem.Value.ToString(), 15, 1);
                    if (SelectedSeries == "R1")
                        CreateCatalogNumber(cmbNozzleMaterial.SelectedValue.ToString(), 10, 1);
                    Program.ProjectList[CurrentProjectIndex].NozzleMaterial = cmbNozzleMaterial.SelectedItem.Text;
                    Program.ProjectList[CurrentProjectIndex].Saved = false;
                }
            }
            catch
            {

            }
        }

        private void txbSeat_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Seat = txbSeat.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbANSIFlangeRating_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].ANSIFlangeRating = txbANSIFlangeRating.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbFlangeFace_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].FlangeFace = txbFlangeFace.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbNozzle_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Nozzle = txbNozzle.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbSize_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].Inlet_Size_Connection = txbSize.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbInletOutlet_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].OutletConnection = txbInletOutlet.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbBodyMaterial_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].BodyMaterial = txbBodyMaterial.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbSpringMaterial_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SpringMaterial = txbSpringMaterial.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbTrimMaterial_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].TrimMaterial = txbTrimMaterial.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbFluidName_2phase_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Fluid_Name = txbFluidName_2phase.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void txbFluidName_2phase_C23_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Fluid_Name = txbFluidName_2phase_C23.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void cmbKd_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Kd = cmbKd.SelectedText;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnViscosityUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].ViscosityUnit = btnViscosityUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnRelievingTemp_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Relieving_Unit = btnRelievingTemp.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnOperatingTemp_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Relieving_Unit = btnRelievingTemp.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnDesignMinTemp_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Relieving_Unit = btnRelievingTemp.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnDesignMaxTemp_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Relieving_Unit = btnRelievingTemp.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnNormalSystemTemp_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Relieving_Unit = btnRelievingTemp.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnRequiredPressureFlowUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].RequiredPressureFlowUnit = btnRequiredPressureFlowUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnRequiredFlowCapacityUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].RequiredFlowCapacityUnit = btnRequiredFlowCapacityUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnAtmPressureUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Atmospheric_Unit = btnAtmPressureUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnSystemMAWPUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnSystemMAWPUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnOperatingPressureUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnOperatingPressureUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnSetPressureUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnSetPressureUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnOverPressureUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnOverPressureUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnBuiltUpUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnBuiltUpUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnConstantSuperimposedUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnConstantSuperimposedUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnVaribleSuperimposedUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnVaribleSuperimposedUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnTotalBackPressureUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnTotalBackPressureUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnInletLossUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SET_PRESSURE_Unit = btnInletLossUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnDensityUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].DensityUnit = btnDensityUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnSpecificValumeUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SpecificValumeUnit = btnSpecificValumeUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnV90_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SpecificValumeUnit = btnV90.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnVinletUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].SpecificValumeUnit = btnVinletUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnVaporFlowCapacityUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].VaporFlowCapacityUnit = btnVaporFlowCapacityUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnLiquidFlowCapacityUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].VaporFlowCapacityUnit = btnLiquidFlowCapacityUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnRequiredFlow2PhaseUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].VaporFlowCapacityUnit = btnRequiredFlow2PhaseUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnVaporUnitC23_Leave(object sender, EventArgs e)
        {
            try {
            Program.ProjectList[CurrentProjectIndex].VaporUnitC23 = btnVaporUnitC23.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnLiquidDensityUnit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].LiquidDensityUnit = btnLiquidDensityUnit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnMixDensity90Unit_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].LiquidDensityUnit = btnMixDensity90Unit.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void btnLiquidSpecificUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].LiquidSpecificUnit = btnLiquidSpecificUnit.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }            
            catch
            {

            }
        }

        private void btnSpVol90Unit_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ProjectList[CurrentProjectIndex].LiquidSpecificUnit = btnSpVol90Unit.Text;
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            
            }
            catch
            {

            }
        }

        private void chbStandardCertificateOrigin_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbStandardCertificateOrigin.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbStandardCertificateOrigin = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbStandardCertificateOrigin = false;
            }
            catch
            {

            }
        }

        private void chbCertificateConformancePurchaseOrder_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbCertificateConformancePurchaseOrder.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbCertificateConformancePurchaseOrder = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbCertificateConformancePurchaseOrder = false;
            }
            catch
            {

            }
        }

        private void chbCertificateConformanceNACE_MR0175_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbCertificateConformanceNACE_MR0175.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbCertificateConformanceNACE_MR0175 = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbCertificateConformanceNACE_MR0175 = false;
            }
            catch
            {

            }
        }

        private void chbCertificateConformanceASMEHydrostaticTesting_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbCertificateConformanceASMEHydrostaticTesting.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbCertificateConformanceASMEHydrostaticTesting = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbCertificateConformanceASMEHydrostaticTesting = false;
            }
            catch
            {

            }
        }

        private void chbMaterialTestReports_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbMaterialTestReports.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbMaterialTestReports = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbMaterialTestReports = false;
            }
            catch
            {

            }
        }

        private void chbHydrostaticTestReportASME_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbHydrostaticTestReportASME.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbHydrostaticTestReportASME = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbHydrostaticTestReportASME = false;
            }
            catch
            {

            }
        }

        private void chbFunctionalTestReport_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbFunctionalTestReport.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbFunctionalTestReport = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbFunctionalTestReport = false;
            }
            catch
            {

            }
        }

        private void chbHardnessTestReport_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbHardnessTestReport.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbHardnessTestReport = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbHardnessTestReport = false;
            }
            catch
            {

            }
        }

        private void chbBendTestReportBodyBonnetCasting_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbBendTestReportBodyBonnetCasting.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbBendTestReportBodyBonnetCasting = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbBendTestReportBodyBonnetCasting = false;
            }
            catch
            {

            }
        }

        private void chbRadiographyTestReport_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbRadiographyTestReport.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbRadiographyTestReport = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbRadiographyTestReport = false;
            }
            catch
            {

            }
        }

        private void chbSpecialPainting_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbSpecialPainting.CheckState == CheckState.Checked)
            {
                Program.ProjectList[CurrentProjectIndex].chbSpecialPainting = true;
            }
            else
                Program.ProjectList[CurrentProjectIndex].chbSpecialPainting = false;
            }
            catch
            {

            }
        }

        private void txbSteamName_Leave(object sender, EventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Fluid_Name = txbSteamName.Text;
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            catch
            {

            }
        }

        private void pageMain_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageMain.SelectedPage == pageConfiguration)
                {
                    FillBodyMaterial();
                    FillDiskMaterial();
                }
                if (pageMain.SelectedPage == pageControl)
                {
                    FillControlValve();
                }
            }
            catch
            {

            }
        }

        private void DoClassLimit()
        {
            try
            {
                int index = Program.BodyMaterialsList.FindIndex(item => item.Alias == Program.ProjectList[CurrentProjectIndex].BodyMaterial);
                string material = Program.BodyMaterialsList[index].BodyMaterial;

                decimal reliving = BL.ConvertTempToCelsius(txbRelieving.Text, btnRelievingTemp.Text);
                decimal set_pressure = BL.ConvertUnit(Convert.ToDecimal(txbSetPressure.Text), btnSetPressureUnit.Text, "barg");
                DataTable dt = new DataTable();
                dt = BL.GetClassLimits(reliving.ToString(), set_pressure.ToString(), material);
                bool is_in_unlimited_list = false;
                if (dt.Rows.Count > 0)
                {
                    foreach (RadListDataItem item in cmbInletConnection.Items)
                    {
                        string _class = item.Text;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string _unlimit_class = dt.Rows[i]["Class"].ToString();
                            if (_class == _unlimit_class)
                            {
                                is_in_unlimited_list = true;
                                break;
                            }
                        }
                        if (is_in_unlimited_list)
                        {
                            item.ForeColor = Color.Black;
                            item.Tag = "";
                        }
                        else
                        {
                            item.ForeColor = Color.Red;
                            item.Tag = "Limited";
                            if (cmbInletConnection.SelectedItem != null)
                            {
                                if (cmbInletConnection.SelectedItem.Text == item.Text)
                                {
                                    cmbInletConnection.ForeColor = Color.Red;
                                    string msg = "(doclass)The following items cannot be chosen together: Inlet Connection (" + item.Text + ") and Body Materials (" + Program.ProjectList[CurrentProjectIndex].BodyMaterial + ") in Relieving Temp(" + reliving.ToString() + " °C) and Set Pressure (" + set_pressure.ToString() + " barg). (ASME B16.34-2017)";
                                    CreateErrorLog("Class", msg);
                                }

                            }


                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void DoBodyMaterialsLimit()
        {
            try { 
            decimal reliving = BL.ConvertTempToCelsius(txbRelieving.Text, btnRelievingTemp.Text);
            decimal set_pressure = BL.ConvertUnit(Convert.ToDecimal(txbSetPressure.Text), btnSetPressureUnit.Text, "barg");
            DataTable dt = new DataTable();
            dt = BL.GetBodyMaterialsLimits(reliving.ToString(), set_pressure.ToString(), cmbInletConnection.SelectedItem.Text);
            bool is_in_unlimited_list = false;
            if (dt.Rows.Count > 0)
            {
                foreach (RadListDataItem item in cmbBodyMaterial.Items)
                {
                    string _material = item.Text;
                    int index = Program.BodyMaterialsList.FindIndex(item2 => item2.Alias == item.Text);
                    string material = Program.BodyMaterialsList[index].BodyMaterial;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string _unlimit_material = dt.Rows[i]["Material"].ToString();
                        if (material == _unlimit_material)
                        {
                            is_in_unlimited_list = true;
                            break;
                        }
                    }
                    if (is_in_unlimited_list)
                    {
                        if ((string)item.Tag == "Limited-Temp")
                        {
                            item.ForeColor = Color.Gray;
                        }
                        else
                        {
                            item.ForeColor = Color.Black;
                            item.Tag = "";
                            cmbBodyMaterial.ForeColor = item.ForeColor;
                        }
                    }
                    else
                    {
                        item.ForeColor = Color.Red;
                        item.Tag = "Limited";                        
                        if (cmbBodyMaterial.SelectedItem != null)
                        {
                            if (cmbBodyMaterial.SelectedItem.Text == item.Text)
                            {
                                cmbBodyMaterial.ForeColor = Color.Red;
                                return;
                            }
                        }





                        string msg = "(dobody)The following items cannot be chosen together: Inlet Connection (" + cmbInletConnection.SelectedItem.Text + ") and Body Materials (" + item.Text + ") in Relieving Temp(" + reliving.ToString() + " °C) and Set Pressure (" + set_pressure.ToString() + " barg). (ASME B16.34-2017)";
                        CreateErrorLog("Class", msg);
                    }
                    }
                }
                else
                {
                    foreach (RadListDataItem item in cmbBodyMaterial.Items)
                    {
                        item.ForeColor = Color.Red;
                    }
                }
            }
            catch
            {

            }
        }

        private void cmbDiskMaterial_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try { 
            if (cmbDiskMaterial.SelectedItem != null)
            {
                if (SelectedSeries == "A")
                    CreateCatalogNumber(cmbDiskMaterial.SelectedValue.ToString(), 16, 1);
                if (SelectedSeries == "R1")
                    CreateCatalogNumber(cmbDiskMaterial.SelectedValue.ToString(), 11, 1);

                //CreateCatalogNumber(cmbDiskMaterial.SelectedValue.ToString(), 15, 1);
                Program.ProjectList[CurrentProjectIndex].TrimMaterial = cmbDiskMaterial.SelectedItem.ToString();
                Program.ProjectList[CurrentProjectIndex].Saved = false;
            }
            }
            catch
            {

            }
        }

        private void chbNACECompliance_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbNACECompliance.CheckState == CheckState.Checked)
            {
                if (SelectedSeries == "A")
                    CreateAccesoriesCatalogNumber("N", 1);
                if (SelectedSeries == "R1")
                    CreateAccesoriesCatalogNumber("N", 1);
                if (SelectedSeries == "R" || SelectedSeries == "D" || SelectedSeries == "M")
                    CreateAccesoriesCatalogNumber("P", 6);                              
                Program.ProjectList[CurrentProjectIndex].chbNACECompliance = true;
            }
            else
            {
                if (SelectedSeries == "A")
                    CreateAccesoriesCatalogNumber("_", 1);
                Program.ProjectList[CurrentProjectIndex].chbNACECompliance = false;
            }
            }
            catch
            {

            }
        }

        private void chbBonnetExtention_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbBonnetExtention.CheckState == CheckState.Checked)
            {
                if (SelectedSeries == "A")
                    CreateAccesoriesCatalogNumber("P", 4);
                if (SelectedSeries == "R" || SelectedSeries == "R1" || SelectedSeries == "D" || SelectedSeries == "M")
                    CreateAccesoriesCatalogNumber("P", 6);
                Program.ProjectList[CurrentProjectIndex].chbBonnetExtention = true;
            }
            else
            {
                if (SelectedSeries == "A")
                    CreateAccesoriesCatalogNumber("_", 4);
                Program.ProjectList[CurrentProjectIndex].chbBonnetExtention = false;
            }
            }
            catch
            {

            }
        }

        private void chbOpenBonnet_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbOpenBonnet.CheckState == CheckState.Checked)
            {
                if (SelectedSeries == "A")
                    CreateAccesoriesCatalogNumber("O", 5);
                if (SelectedSeries == "R" || SelectedSeries == "R1" || SelectedSeries == "D" || SelectedSeries == "M")
                    CreateAccesoriesCatalogNumber("P", 6);
                Program.ProjectList[CurrentProjectIndex].chbOpenBonnet = true;
            }
            else
            {
                if (SelectedSeries == "A")
                    CreateAccesoriesCatalogNumber("_", 5);
                Program.ProjectList[CurrentProjectIndex].chbOpenBonnet = false;
            }
            }
            catch
            {

            }
        }

        private void chbHeatingJacket_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbHeatingJacket.CheckState == CheckState.Checked)
            {
                if (SelectedSeries == "A" || SelectedSeries == "M")
                    CreateAccesoriesCatalogNumber("J", 9);
                if (SelectedSeries == "D")
                    CreateAccesoriesCatalogNumber("H", 4);
                Program.ProjectList[CurrentProjectIndex].chbHeatingJacket = true;
            }
            else
            {
                if (SelectedSeries == "A" || SelectedSeries == "M")
                    CreateAccesoriesCatalogNumber("_", 9);
                Program.ProjectList[CurrentProjectIndex].chbHeatingJacket = false;
            }
            }
            catch
            {

            }
        }

        private void btnControlValve_Click(object sender, EventArgs e)
        {
            try { 
            grbSafety.Visible = false;
            pageMain.ViewElement.Items[1].Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            pageMain.ViewElement.Items[2].Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            pageMain.ViewElement.Items[3].Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            pageMain.ViewElement.Items[4].Visibility = Telerik.WinControls.ElementVisibility.Visible;
            pageMain.Pages.ChangeIndex(pageControl, 1);
            pageMain.SelectedPage = pageControl;
            cmbFluidType.SelectedIndex = 0;            
            cmbInletPipeSizeUnit.SelectedIndex = 0;
            cmbInletPipeSizeSchUnit.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void btnSafetyValve_Click(object sender, EventArgs e)
        {
            try { 
            grbSafety.Visible = true;
            int size_index = pageMain.Pages.IndexOf(pageSizingSelection);
            if (size_index != 1)
            {
                pageMain.Pages.ChangeIndex(pageSizingSelection, 1);
                pageMain.Pages.ChangeIndex(pageConfiguration, 2);
                pageMain.Pages.ChangeIndex(pageReports, 3);
                pageMain.Pages.ChangeIndex(pageControl, 4);     

            }
            pageMain.ViewElement.Items[1].Visibility = Telerik.WinControls.ElementVisibility.Visible;
            pageMain.ViewElement.Items[2].Visibility = Telerik.WinControls.ElementVisibility.Visible;
            pageMain.ViewElement.Items[3].Visibility = Telerik.WinControls.ElementVisibility.Visible;
            pageMain.ViewElement.Items[4].Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            }
            catch
            {

            }
        }      

        private void chbRing_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (chbRing.CheckState == CheckState.Checked)
            {
                if (SelectedSeries == "R1")
                    CreateCatalogNumber("1", 3, 1);
                Program.ProjectList[CurrentProjectIndex].chbRing = true;
            }
            else
            {
                if (SelectedSeries == "R1")
                    CreateCatalogNumber("2", 3, 1);
                Program.ProjectList[CurrentProjectIndex].chbRing = false;
            }
            }
            catch
            {

            }
        }       
        #region Control Valve
       
        private void FillControlValve()
        {
            try { 
            kg_hr.Click += Kg_hr_Click;
            ton_hr.Click += Kg_hr_Click;
            lb_hr.Click += Kg_hr_Click;
            LPM.Click += Kg_hr_Click;
            GPM.Click += Kg_hr_Click;
            m3_hr.Click += Kg_hr_Click;
            ft3_hr.Click += Kg_hr_Click;
            nm3_hr.Click += Kg_hr_Click;
            sft3_hr.Click += Kg_hr_Click;

            radMenuItem67.Click += RadMenuItem67_Click;
            radMenuItem68.Click += RadMenuItem67_Click;
            radMenuItem69.Click += RadMenuItem67_Click;
            radMenuItem70.Click += RadMenuItem67_Click;
            radMenuItem71.Click += RadMenuItem67_Click;
            radMenuItem72.Click += RadMenuItem67_Click;
            radMenuItem73.Click += RadMenuItem67_Click;
            radMenuItem74.Click += RadMenuItem67_Click;
            radMenuItem75.Click += RadMenuItem67_Click;
            radMenuItem76.Click += RadMenuItem67_Click;
            radMenuItem77.Click += RadMenuItem67_Click;
            radMenuItem78.Click += RadMenuItem67_Click;
            radMenuItem79.Click += RadMenuItem67_Click;
            radMenuItem80.Click += RadMenuItem67_Click;
            radMenuItem81.Click += RadMenuItem67_Click;
            radMenuItem82.Click += RadMenuItem67_Click;
            radMenuItem83.Click += RadMenuItem67_Click;

            radMenuItem91.Click += RadMenuItem67_Click;
            radMenuItem92.Click += RadMenuItem67_Click;
            radMenuItem93.Click += RadMenuItem67_Click;           
            radMenuItem97.Click += RadMenuItem67_Click;
            radMenuItem98.Click += RadMenuItem67_Click;
            radMenuItem99.Click += RadMenuItem67_Click;
            radMenuItem100.Click += RadMenuItem67_Click;
            radMenuItem101.Click += RadMenuItem67_Click;
            radMenuItem102.Click += RadMenuItem67_Click;
            radMenuItem103.Click += RadMenuItem67_Click;
            radMenuItem104.Click += RadMenuItem67_Click;
            radMenuItem105.Click += RadMenuItem67_Click;
            radMenuItem106.Click += RadMenuItem67_Click;
            radMenuItem107.Click += RadMenuItem67_Click;
            radMenuItem108.Click += RadMenuItem67_Click;
            radMenuItem109.Click += RadMenuItem67_Click;
            radMenuItem110.Click += RadMenuItem67_Click;


            radMenuItem84.Click += RadMenuItem84_Click;
            radMenuItem85.Click += RadMenuItem84_Click;
            radMenuItem86.Click += RadMenuItem84_Click;
            radMenuItem87.Click += RadMenuItem84_Click;

            radMenuItem88.Click += RadMenuItem88_Click;
            radMenuItem89.Click += RadMenuItem88_Click;
            radMenuItem90.Click += RadMenuItem88_Click;
            radMenuItem94.Click += RadMenuItem88_Click;
            radMenuItem95.Click += RadMenuItem88_Click;
            radMenuItem96.Click += RadMenuItem88_Click;



            FillBodyType();
            FillBodySize();
            FillTrimType();
            FillPortSize();
            FillRatedCV();
            FillStroke();
            }
            catch
            {

            }
        }

        private void RadMenuItem88_Click(object sender, EventArgs e)
        {
            try { 
            Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;

            string to = b.Text;
            string from = btnDensityControlUnit.Text;
            btnDensityControlUnit.Text = to;
            }
            catch
            {

            }

        }

        private void RadMenuItem84_Click(object sender, EventArgs e)
        {
            try { 
            Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;

            string to = b.Text;
            string from = cmbInletTempUnit.Text;
            cmbInletTempUnit.Text = to;
            lblDesignTempUnit.Text = to;
            }
            catch
            {

            }
        }

        private void RadMenuItem67_Click(object sender, EventArgs e)
        {
            try { 
            Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;

            string to = b.Text;
            string from = cmbInletPressureUnit.Text;
            cmbInletPressureUnit.Text = to;
            btnOutletPressureUnit.Text = to;
            lblDesignPresUnit.Text = to;
            if (cmbFluidType.SelectedItem.Text == "Liquid")
                btnUnit2.Text = to;
            string diff = to.Remove(to.Length - 1);
            btnDiffPresUnit.Text = diff.Trim();         
            btnMaxShutUnit.Text = btnDiffPresUnit.Text;
            btnUnit4.Text = to;
            }
            catch
            {

            }
        }

        private void Kg_hr_Click(object sender, EventArgs e)
        {
            try { 
            Telerik.WinControls.UI.RadMenuItem b = sender as Telerik.WinControls.UI.RadMenuItem;
            
            string to = b.Text;
            string from = cmbFlowRateUnit.Text;
            cmbFlowRateUnit.Text = to;
            }
            catch
            {

            }
        }

        private void FillBodyType()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetBodyType();
            if (dt != null && dt.Rows.Count > 0)
            {                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                    item.Value = dt.Rows[i]["Id"].ToString(); ;
                    item.Text = dt.Rows[i]["Name"].ToString();
                    cmbBodyType.Items.Add(item);
                }
            }
            }
            catch
            {

            }
        }

        private void FillRatedCV()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetRatedCV();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                    item.Value = dt.Rows[i]["Id"].ToString(); ;
                    item.Text = dt.Rows[i]["Name"].ToString();
                    cmbRatedCV.Items.Add(item);
                }
            }
            }
            catch
            {

            }
        }

        private void FillStroke()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetStroke();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                    item.Value = dt.Rows[i]["Id"].ToString(); ;
                    item.Text = dt.Rows[i]["Name"].ToString();
                    cmbStroke.Items.Add(item);
                }
            }
            }
            catch
            {

            }
        }

        private void FillPortSize()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetPortSize();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                    item.Value = dt.Rows[i]["Id"].ToString(); ;
                    item.Text = dt.Rows[i]["Name"].ToString();
                    cmbPortSize.Items.Add(item);
                }
            }
            }
            catch
            {

            }
        }

        private void FillBodySize()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetBodySize();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                    item.Value = dt.Rows[i]["Id"].ToString(); ;
                    item.Text = dt.Rows[i]["Name"].ToString();
                    cmbBodySize.Items.Add(item);
                }
            }
            }
            catch
            {

            }
        }

        private void FillTrimType()
        {
            try { 
            DataTable dt = new DataTable();
            dt = BL.GetTrimType();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                    item.Value = dt.Rows[i]["Id"].ToString(); ;
                    item.Text = dt.Rows[i]["Name"].ToString();
                    cmbTrimType.Items.Add(item);
                }
            }
            }
            catch
            {

            }
        }

        private void cmbFluidType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try { 
            FluidType = cmbFluidType.SelectedText;
            switch (FluidType)
            {
                case "Gas":
                    {
                        lbl1.Text = "Molecular Weight";
                        lbl2.Text = "Specific Heat Ratio";
                        lbl3.Text = "Compressibility";
                        btnUnit1.Text = "MW";
                        btnUnit2.Text = "k";
                        btnUnit3.Text = "Z";
                        btnUnit4.Text = "psia";
                        txbCriticalPressure_Min.Enabled = false;
                        txbCriticalPressure_Norm.Enabled = false;
                        txbCriticalPressure_Max.Enabled = false;
                        txbCriticalPressure_Case1.Enabled = false;
                        txbCriticalPressure_Case2.Enabled = false;
                        List<Fluid> GasList = new List<Fluid>();
                        GasList = Program.FluidList.Where(item => item.Type == 1).ToList();
                        cmbFluidName_Ctrl.Items.Clear();
                        for (int i = 0; i < GasList.Count; i++)
                        {
                            cmbFluidName_Ctrl.Items.Add(GasList[i].Name);
                        }
                        break;
                    }
                case "Liquid":
                    {
                        lbl1.Text = "Specific Gravity";
                        lbl2.Text = "Vapor Pressure";
                        lbl3.Text = "Viscosity";
                        btnUnit1.Text = "SG";
                        btnUnit2.Text = "psia";
                        btnUnit3.Text = "cP";
                        btnUnit4.Text = "psia";
                        txbCriticalPressure_Min.Enabled = true;
                        txbCriticalPressure_Norm.Enabled = true;
                        txbCriticalPressure_Max.Enabled = true;
                        txbCriticalPressure_Case1.Enabled = true;
                        txbCriticalPressure_Case2.Enabled = true;
                        List<Fluid> LiquidList = new List<Fluid>();
                        LiquidList = Program.FluidList.Where(item => item.Type == 2).ToList();
                        cmbFluidName_Ctrl.Items.Clear();
                        for (int i = 0; i < LiquidList.Count; i++)
                        {
                            cmbFluidName_Ctrl.Items.Add(LiquidList[i].Name);
                        }
                        break;
                    }
                case "Steam":
                    {
                        lbl1.Text = "Molecular Weight";
                        lbl2.Text = "Specific Heat Ratio";
                        lbl3.Text = "Compressibility";
                        btnUnit1.Text = "MW";
                        btnUnit2.Text = "k";
                        btnUnit3.Text = "Z";
                        btnUnit4.Text = "psia";
                        cmbFluidName_Ctrl.Items.Clear();
                        txbSG_MW_Case2.Text = "";
                        txbSG_MW_Case1.Text = txbSG_MW_Case2.Text;
                        txbSG_MW_Min.Text = txbSG_MW_Case2.Text;
                        txbSG_MW_Norm.Text = txbSG_MW_Case2.Text;
                        txbVP_K_Case2.Text = "";
                        txbVP_K_Case1.Text = txbVP_K_Case2.Text;
                        txbVP_K_Min.Text = txbVP_K_Case2.Text;
                        txbVP_K_Norm.Text = txbVP_K_Case2.Text;
                        txbViscosity_Z_Case2.Text = "";
                        txbViscosity_Z_Case1.Text = txbViscosity_Z_Case2.Text;
                        txbViscosity_Z_Min.Text = txbViscosity_Z_Case2.Text;
                        txbViscosity_Z_Norm.Text = txbViscosity_Z_Case2.Text;
                        Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName_Ctrl.Text;
                        break;
                    }
            }
            }
            catch
            {

            }

        }

        private void cmbFluidName_Ctrl_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try { 
            Program.ProjectList[CurrentProjectIndex].Saved = false;
            if (cmbFluidName_Ctrl.SelectedItem != null)
            {
                if (cmbFluidName_Ctrl.Items.Count > 0)
                {
                    switch (FluidType)
                    {
                        case "Gas":
                            {
                                int SelectedFluidIdx = Program.FluidList.FindIndex(item => item.Name == cmbFluidName_Ctrl.SelectedItem.ToString() && item.Type == 1);
                                txbSG_MW_Case2.Text = Program.FluidList[SelectedFluidIdx].MolecularWeight.ToString();
                                txbSG_MW_Case1.Text = txbSG_MW_Case2.Text;
                                txbSG_MW_Min.Text = txbSG_MW_Case2.Text;
                                txbSG_MW_Norm.Text = txbSG_MW_Case2.Text;
                                txbSG_MW_Max.Text = txbSG_MW_Case2.Text;
                                txbVP_K_Case2.Text = Program.FluidList[SelectedFluidIdx].K.ToString();
                                txbVP_K_Case1.Text = txbVP_K_Case2.Text;
                                txbVP_K_Min.Text = txbVP_K_Case2.Text;
                                txbVP_K_Norm.Text = txbVP_K_Case2.Text;
                                txbVP_K_Max.Text = txbVP_K_Case2.Text;
                                txbViscosity_Z_Case2.Text = Program.FluidList[SelectedFluidIdx].Comperessibility.ToString();
                                txbViscosity_Z_Case1.Text = txbViscosity_Z_Case2.Text;
                                txbViscosity_Z_Min.Text = txbViscosity_Z_Case2.Text;
                                txbViscosity_Z_Norm.Text = txbViscosity_Z_Case2.Text;
                                txbViscosity_Z_Max.Text = txbViscosity_Z_Case2.Text;
                                Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName_Ctrl.SelectedItem.ToString();
                                break;
                            }
                        case "Liquid":
                            {
                                int SelectedFluidIdx = Program.FluidList.FindIndex(item => item.Name == cmbFluidName_Ctrl.SelectedItem.ToString() && item.Type == 2);
                                txbSG_MW_Case2.Text = Program.FluidList[SelectedFluidIdx].SpecificGravity.ToString();
                                txbSG_MW_Case1.Text = txbSG_MW_Case2.Text;
                                txbSG_MW_Min.Text = txbSG_MW_Case2.Text;
                                txbSG_MW_Norm.Text = txbSG_MW_Case2.Text;
                                txbSG_MW_Max.Text = txbSG_MW_Case2.Text;
                                txbVP_K_Case2.Text = "0.104";
                                txbVP_K_Case1.Text = "0.086";
                                txbVP_K_Min.Text = "0.072";
                                txbVP_K_Norm.Text = "0.084";
                                txbVP_K_Max.Text = "0.085";
                                txbViscosity_Z_Case2.Text = Program.FluidList[SelectedFluidIdx].Viscosity.ToString();
                                txbViscosity_Z_Case1.Text = txbViscosity_Z_Case2.Text;
                                txbViscosity_Z_Min.Text = txbViscosity_Z_Case2.Text;
                                txbViscosity_Z_Norm.Text = txbViscosity_Z_Case2.Text;
                                txbViscosity_Z_Max.Text = txbViscosity_Z_Case2.Text;
                                Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName_Ctrl.SelectedItem.ToString();
                                break;
                            }
                    }
                }
            }
            }
            catch
            {

            }
        }

        private void cmbFluidName_Ctrl_Leave(object sender, EventArgs e)
        {            
            Program.ProjectList[CurrentProjectIndex].Fluid_Name = cmbFluidName_Ctrl.Text;            
        }      
      

        private void chbFluidName_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try { 
            if(chbFluidName.CheckState == CheckState.Checked)
            {
                cmbFluidName_Ctrl.Visible = false;
                txbFluidName.Location = new Point(cmbFluidName_Ctrl.Location.X, cmbFluidName_Ctrl.Location.Y);
                txbFluidName.Visible = true;
            }
            else
            {
                cmbFluidName_Ctrl.Visible = true;
                txbFluidName.Visible = false;
            }
            }
            catch
            {

            }
        }

        private void cmbInletPipeSizeUnit_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try { 
            cmbOutletPipeSizeUnit.SelectedIndex = cmbInletPipeSizeUnit.SelectedIndex;
            if(cmbInletPipeSizeUnit.SelectedIndex == 0)
            {
                cmbInletPipeSizeInch.Visible = true;
                cmbInletPipeSizemm.Visible = false;
            }
            else
            {
                cmbInletPipeSizeInch.Visible = false;
                cmbInletPipeSizemm.Location = new Point(cmbInletPipeSizeInch.Location.X, cmbInletPipeSizeInch.Location.Y);
                cmbInletPipeSizemm.Visible = true;
            }
            }
            catch
            {

            }
        }

        private void cmbInletPipeSizeSchUnit_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            cmbOutletPipeSizeSchUnit.SelectedIndex = cmbInletPipeSizeSchUnit.SelectedIndex;
        }

        private void cmbOutletPipeSizeUnit_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try { 
            cmbInletPipeSizeUnit.SelectedIndex = cmbOutletPipeSizeUnit.SelectedIndex;
            if (cmbOutletPipeSizeUnit.SelectedIndex == 0)
            {
                cmbOutletPipeSizeInch.Visible = true;
                cmbOutletPipeSizemm.Visible = false;
            }
            else
            {
                cmbOutletPipeSizeInch.Visible = false;
                cmbOutletPipeSizemm.Location = new Point(cmbOutletPipeSizeInch.Location.X, cmbOutletPipeSizeInch.Location.Y);
                cmbOutletPipeSizemm.Visible = true;
            }
            }
            catch
            {

            }
        }

        private void txbInletPressure_Min_TextChanged(object sender, EventArgs e)
        {
            try { 
            decimal p1 = 0;
            decimal p2 = 0;
            if (txbInletPressure_Min.Text != "")
                p1 = Convert.ToDecimal(txbInletPressure_Min.Text);
            if (txbOutletPressure_Min.Text != "")
                p2 = Convert.ToDecimal(txbOutletPressure_Min.Text);
            decimal delta_p = p1 - p2;
            if(delta_p < 0)
            {
                txbDifferentialPressure_Min.ForeColor = Color.Red;
                txbDifferentialPressure_Min.Text = "Negative";
            }
            else
            {
                txbDifferentialPressure_Min.ForeColor = Color.Black;
                txbDifferentialPressure_Min.Text = delta_p.ToString();
            }
            }
            catch
            {

            }

        }

        private void txbInletPressure_Norm_TextChanged(object sender, EventArgs e)
        {
            try { 
            decimal p1 = 0;
            decimal p2 = 0;
            if (txbInletPressure_Norm.Text != "")
                p1 = Convert.ToDecimal(txbInletPressure_Norm.Text);
            if (txbOutletPressure_Norm.Text != "")
                p2 = Convert.ToDecimal(txbOutletPressure_Norm.Text);
            decimal delta_p = p1 - p2;
            if (delta_p < 0)
            {
                txbDifferentialPressure_Norm.ForeColor = Color.Red;
                txbDifferentialPressure_Norm.Text = "Negative";
            }
            else
            {
                txbDifferentialPressure_Norm.ForeColor = Color.Black;
                txbDifferentialPressure_Norm.Text = delta_p.ToString();
            }
            }
            catch
            {

            }
        }

        private void txbInletPressure_Max_TextChanged(object sender, EventArgs e)
        {
            try { 
            decimal p1 = 0;
            decimal p2 = 0;
            if (txbInletPressure_Max.Text != "")
                p1 = Convert.ToDecimal(txbInletPressure_Max.Text);
            if (txbOutletPressure_Max.Text != "")
                p2 = Convert.ToDecimal(txbOutletPressure_Max.Text);
            decimal delta_p = p1 - p2;
            if (delta_p < 0)
            {
                txbDifferentialPressure_Max.ForeColor = Color.Red;
                txbDifferentialPressure_Max.Text = "Negative";
            }
            else
            {
                txbDifferentialPressure_Max.ForeColor = Color.Black;
                txbDifferentialPressure_Max.Text = delta_p.ToString();
            }
            }
            catch
            {

            }
        }

        private void txbInletPressure_Case1_TextChanged(object sender, EventArgs e)
        {
            try { 
            decimal p1 = 0;
            decimal p2 = 0;
            if (txbInletPressure_Case1.Text != "")
                p1 = Convert.ToDecimal(txbInletPressure_Case1.Text);
            if (txbOutletPressure_Case1.Text != "")
                p2 = Convert.ToDecimal(txbOutletPressure_Case1.Text);
            decimal delta_p = p1 - p2;
            if (delta_p < 0)
            {
                txbDifferentialPressure_Case1.ForeColor = Color.Red;
                txbDifferentialPressure_Case1.Text = "Negative";
            }
            else
            {
                txbDifferentialPressure_Case1.ForeColor = Color.Black;
                txbDifferentialPressure_Case1.Text = delta_p.ToString();
            }
            }
            catch
            {

            }
        }

        private void txbInletPressure_Case2_TextChanged(object sender, EventArgs e)
        {
            try { 
            decimal p1 = 0;
            decimal p2 = 0;
            if (txbInletPressure_Case2.Text != "")
                p1 = Convert.ToDecimal(txbInletPressure_Case2.Text);
            if (txbOutletPressure_Case2.Text != "")
                p2 = Convert.ToDecimal(txbOutletPressure_Case2.Text);
            decimal delta_p = p1 - p2;
            if (delta_p < 0)
            {
                txbDifferentialPressure_Case2.ForeColor = Color.Red;
                txbDifferentialPressure_Case2.Text = "Negative";
            }
            else
            {
                txbDifferentialPressure_Case2.ForeColor = Color.Black;
                txbDifferentialPressure_Case2.Text = delta_p.ToString();
            }
            }
            catch
            {

            }
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
            try { 
            if (FluidType == "Gas" || FluidType == "Steam")
            {
                if (lbl1.Text == "Molecular Weight")
                {
                    lbl1.Text = "Density";
                    btnDensityControlUnit.Location = new Point(btnUnit1.Location.X, btnUnit1.Location.Y);
                    btnUnit1.Visible = false;
                    btnDensityControlUnit.Visible = true;
                }
                else if (lbl1.Text == "Density")
                {
                    lbl1.Text = "Molecular Weight";
                    btnUnit1.Text = "MW";
                    btnUnit1.Visible = true;
                    btnDensityControlUnit.Visible = false; 
                }
            }
            if (FluidType == "Liquid")
            {
                if (lbl1.Text == "Specific Gravity")
                {
                    lbl1.Text = "Density";
                    btnDensityControlUnit.Location = new Point(btnUnit1.Location.X, btnUnit1.Location.Y);
                    btnUnit1.Visible = false;
                    btnDensityControlUnit.Visible = true;
                }
                else if (lbl1.Text == "Density")
                {
                    lbl1.Text = "Specific Gravity";
                    btnUnit1.Text = "SG";
                    btnUnit1.Visible = true;
                    btnDensityControlUnit.Visible = false;
                }
            }
            }
            catch
            {

            }
        }

        private void lbl1_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void lbl1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            try { 
            ControlCalculate.Q_Min = txbFlowRate_Min.Text;
            ControlCalculate.Q_Norm = txbFlowRate_Norm.Text;
            ControlCalculate.Q_Max = txbFlowRate_Max.Text;
            ControlCalculate.Q_Case1 = txbFlowRate_Case1.Text;
            ControlCalculate.Q_Case2 = txbFlowRate_Case2.Text;
            ControlCalculate.Q_Unit = cmbFlowRateUnit.Text;

            ControlCalculate.P1_Min = txbInletPressure_Min.Text;
            ControlCalculate.P1_Norm = txbInletPressure_Norm.Text;
            ControlCalculate.P1_Max = txbInletPressure_Max.Text;
            ControlCalculate.P1_Case1 = txbInletPressure_Case1.Text;
            ControlCalculate.P1_Case2 = txbInletPressure_Case2.Text;

            ControlCalculate.P2_Min = txbOutletPressure_Min.Text;
            ControlCalculate.P2_Norm = txbOutletPressure_Norm.Text;
            ControlCalculate.P2_Max = txbOutletPressure_Max.Text;
            ControlCalculate.P2_Case1 = txbOutletPressure_Case1.Text;
            ControlCalculate.P2_Case2 = txbOutletPressure_Case2.Text;
            ControlCalculate.P_Unit = btnOutletPressureUnit.Text;

            ControlCalculate.SG_Min = txbSG_MW_Min.Text;
            ControlCalculate.SG_Norm = txbSG_MW_Norm.Text;
            ControlCalculate.SG_Max = txbSG_MW_Max.Text;
            ControlCalculate.SG_Case1 = txbSG_MW_Case1.Text;
            ControlCalculate.SG_Case2 = txbSG_MW_Case2.Text;
           

            ControlCalculate.Delta_P_Min = txbDifferentialPressure_Min.Text;
            ControlCalculate.Delta_P_Norm = txbDifferentialPressure_Norm.Text;
            ControlCalculate.Delta_P_Max = txbDifferentialPressure_Max.Text;
            ControlCalculate.Delta_P_Case1 = txbDifferentialPressure_Case1.Text;
            ControlCalculate.Delta_P_Case2 = txbDifferentialPressure_Case2.Text;
            ControlCalculate.Delta_P_Unit = btnDiffPresUnit.Text;

            ControlCalculate.Pc_Min = txbCriticalPressure_Min.Text;
            ControlCalculate.Pc_Norm = txbCriticalPressure_Norm.Text;
            ControlCalculate.Pc_Max = txbCriticalPressure_Max.Text;
            ControlCalculate.Pc_Case1 = txbCriticalPressure_Case1.Text;
            ControlCalculate.Pc_Case2 = txbCriticalPressure_Case2.Text;
            ControlCalculate.Pc_Unit = btnUnit4.Text;

            ControlCalculate.Pv_Min = txbVP_K_Min.Text;
            ControlCalculate.Pv_Norm = txbVP_K_Norm.Text;
            ControlCalculate.Pv_Max = txbVP_K_Max.Text;
            ControlCalculate.Pv_Case1 = txbVP_K_Case1.Text;
            ControlCalculate.Pv_Case2 = txbVP_K_Case2.Text;
            ControlCalculate.Pv_Unit = btnUnit2.Text;

           
            ControlCalculate.T_Min = txbInletTemp_Min.Text;
            ControlCalculate.T_Norm = txbInletTemp_Norm.Text;
            ControlCalculate.T_Max = txbInletTemp_Max.Text;
            ControlCalculate.T_Case1 = txbInletTemp_Case1.Text;
            ControlCalculate.T_Case2 = txbInletTemp_Case2.Text;
            ControlCalculate.T_Unit = cmbInletTempUnit.Text;

            ControlCalculate.Z_Min = txbViscosity_Z_Min.Text;
            ControlCalculate.Z_Norm = txbViscosity_Z_Norm.Text;
            ControlCalculate.Z_Max = txbViscosity_Z_Max.Text;
            ControlCalculate.Z_Case1 = txbViscosity_Z_Case1.Text;
            ControlCalculate.Z_Case2 = txbViscosity_Z_Case2.Text;

            if (lbl1.Text == "Molecular Weight")
                ControlCalculate.IsMolcularWeight = true;
            else
                ControlCalculate.IsMolcularWeight = false;

            ControlCalculate.D1_Unit = cmbInletPipeSizeUnit.SelectedItem.Text;
            if (ControlCalculate.D1_Unit == "inch")
            {
                if (cmbInletPipeSizeInch.SelectedItem != null)
                    ControlCalculate.D1 = cmbInletPipeSizeInch.SelectedItem.Text;
                else
                {
                    if (cmbInletPipeSizeInch.Text != "")                    
                        ControlCalculate.D1 = cmbInletPipeSizeInch.Text;                   
                    else                                            
                        ControlCalculate.D1 = "";                    
                }
            }
            else
            {
                if (cmbInletPipeSizemm.SelectedItem != null)
                    ControlCalculate.D1 = cmbInletPipeSizemm.SelectedItem.Text;
                else
                {
                    if (cmbInletPipeSizemm.Text != "")
                        ControlCalculate.D1 = cmbInletPipeSizemm.Text;
                    else
                        ControlCalculate.D1 = "";
                }
            }

            ControlCalculate.D2_Unit = cmbOutletPipeSizeUnit.SelectedItem.Text;
            if (ControlCalculate.D2_Unit == "inch")
            {
                if (cmbOutletPipeSizeInch.SelectedItem != null)
                    ControlCalculate.D2 = cmbOutletPipeSizeInch.SelectedItem.Text;
                else
                {
                    if (cmbOutletPipeSizeInch.Text != "")
                        ControlCalculate.D2 = cmbOutletPipeSizeInch.Text;
                    else
                        ControlCalculate.D2 = "";
                }
            }
            else
            {
                if (cmbOutletPipeSizemm.SelectedItem != null)
                    ControlCalculate.D2 = cmbOutletPipeSizemm.SelectedItem.Text;
                else
                {
                    if (cmbOutletPipeSizemm.Text != "")
                        ControlCalculate.D2 = cmbOutletPipeSizemm.Text;
                    else
                        ControlCalculate.D2 = "";
                }
            }

            if (cmbBodyType.SelectedItem != null)
                ControlCalculate.BodyType_selected_index = cmbBodyType.SelectedIndex;
            else
                ControlCalculate.BodyType_selected_index = -1;

           
            if (cmbBodySize.SelectedItem != null)
                ControlCalculate.d_selected_index = cmbBodySize.SelectedIndex;
            else
            {
                if (cmbBodySize.Text != "")
                {
                    ControlCalculate.D = cmbBodySize.Text;
                    ControlCalculate.d_selected_index = -1;
                }
                else
                {
                    ControlCalculate.d_selected_index = -1;
                    ControlCalculate.D = "";
                }

            }
               

            if (cmbTrimType.SelectedItem != null)
                ControlCalculate.TrimTypeIndex = cmbTrimType.SelectedIndex;
            else
                ControlCalculate.TrimTypeIndex = -1;

            if (lbl1.Text == "Density")
                ControlCalculate.Density_Unit = btnDensityControlUnit.Text;
            else
                ControlCalculate.Density_Unit = "";

            if (cmbPortSize.SelectedItem != null)
                ControlCalculate.PortSizeIndex = cmbPortSize.SelectedIndex;
            else
                ControlCalculate.PortSizeIndex = -1;

            if (cmbFlowCharacter.SelectedItem != null)
                ControlCalculate.FlowCharacterIndex = cmbFlowCharacter.SelectedIndex;
            else
                ControlCalculate.FlowCharacterIndex = -1;

            if (cmbRatedCV.SelectedItem != null)
                ControlCalculate.Cv_Rated = cmbRatedCV.SelectedItem.Text;
            else
            {
                if (cmbRatedCV.Text != "")
                    ControlCalculate.Cv_Rated = cmbRatedCV.Text;
                else
                    ControlCalculate.Cv_Rated = "";
            }


            Program.SymbolList.Clear();
            ControlCalculate.Calculate(FluidType);


            
            dgvControlResult.BeginUpdate();
            dgvControlResult.DataSource = null;
            dgvControlResult.DataSource = Program.SymbolList;
            dgvControlResult.EndUpdate(true);
            dgvControlResult.Refresh();

            dgvControlResult.Columns["Symbol"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Symbol"].Width = 70;            
            dgvControlResult.Columns["Symbol"].MinWidth = 70;
            dgvControlResult.Columns["Symbol"].HeaderText = "Symbol";
            dgvControlResult.Columns["Symbol"].TextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Symbol"].DisableHTMLRendering = false;

            dgvControlResult.Columns["Min_Value"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Min_Value"].Width = 50;             
            dgvControlResult.Columns["Min_Value"].MinWidth = 50;
            dgvControlResult.Columns["Min_Value"].HeaderText = "Min.";
            dgvControlResult.Columns["Min_Value"].TextAlignment = ContentAlignment.MiddleCenter;

            dgvControlResult.Columns["Norm_Value"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Norm_Value"].Width = 50;            
            dgvControlResult.Columns["Norm_Value"].MinWidth = 50;
            dgvControlResult.Columns["Norm_Value"].HeaderText = "Norm.";
            dgvControlResult.Columns["Norm_Value"].TextAlignment = ContentAlignment.MiddleCenter;

            dgvControlResult.Columns["Max_Value"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Max_Value"].Width = 50;             
            dgvControlResult.Columns["Max_Value"].MinWidth = 50;
            dgvControlResult.Columns["Max_Value"].HeaderText = "Max.";
            dgvControlResult.Columns["Max_Value"].TextAlignment = ContentAlignment.MiddleCenter;

            dgvControlResult.Columns["Case1_Value"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Case1_Value"].Width = 50;            
            dgvControlResult.Columns["Case1_Value"].MinWidth = 50;
            dgvControlResult.Columns["Case1_Value"].HeaderText = "Case 1";
            dgvControlResult.Columns["Case1_Value"].TextAlignment = ContentAlignment.MiddleCenter;

            dgvControlResult.Columns["Case2_Value"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Case2_Value"].Width = 50;             
            dgvControlResult.Columns["Case2_Value"].MinWidth = 50;
            dgvControlResult.Columns["Case2_Value"].HeaderText = "Case 2";
            dgvControlResult.Columns["Case2_Value"].TextAlignment = ContentAlignment.MiddleCenter;

            dgvControlResult.Columns["Unit"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Unit"].Width = 50;             
            dgvControlResult.Columns["Unit"].MinWidth = 50;
            dgvControlResult.Columns["Unit"].HeaderText = "Unit";
            dgvControlResult.Columns["Unit"].TextAlignment = ContentAlignment.MiddleCenter;

            dgvControlResult.Columns["Description"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            dgvControlResult.Columns["Description"].Width = 800;             
            dgvControlResult.Columns["Description"].MinWidth = 400;
            dgvControlResult.Columns["Description"].HeaderText = "Description";
            dgvControlResult.Columns["Description"].TextAlignment = ContentAlignment.MiddleLeft;
           
            pageMain.SelectedPage = pageControlResult;
            }
            catch
            {

            }
        }

        private void btnMinToNorm_Click(object sender, EventArgs e)
        {
            try { 
            txbFlowRate_Norm.Text = txbFlowRate_Min.Text;
            txbInletPressure_Norm.Text = txbInletPressure_Min.Text;
            txbOutletPressure_Norm.Text = txbOutletPressure_Min.Text;
            txbInletTemp_Norm.Text = txbInletTemp_Min.Text;
            txbSG_MW_Norm.Text = txbSG_MW_Min.Text;
            txbVP_K_Norm.Text = txbVP_K_Min.Text;
            txbCriticalPressure_Norm.Text = txbCriticalPressure_Min.Text;
            txbViscosity_Z_Norm.Text = txbViscosity_Z_Min.Text;
            txbRequiredCapacity_Norm.Text = txbRequiredCapacity_Min.Text;
            txbOpeningTravel_Norm.Text = txbOpeningTravel_Min.Text;
            txbPredictedSPL_Norm.Text = txbPredictedSPL_Min.Text;
            }
            catch
            {

            }
        }

        private void btnNormToMax_Click(object sender, EventArgs e)
        {
            try { 
            txbFlowRate_Max.Text = txbFlowRate_Norm.Text;
            txbInletPressure_Max.Text = txbInletPressure_Norm.Text;
            txbOutletPressure_Max.Text = txbOutletPressure_Norm.Text;
            txbInletTemp_Max.Text = txbInletTemp_Norm.Text;
            txbSG_MW_Max.Text = txbSG_MW_Norm.Text;
            txbVP_K_Max.Text = txbVP_K_Norm.Text;
            txbCriticalPressure_Max.Text = txbCriticalPressure_Norm.Text;
            txbViscosity_Z_Max.Text = txbViscosity_Z_Norm.Text;
            txbRequiredCapacity_Max.Text = txbRequiredCapacity_Norm.Text;
            txbOpeningTravel_Max.Text = txbOpeningTravel_Norm.Text;
            txbPredictedSPL_Max.Text = txbPredictedSPL_Norm.Text;
            }
            catch
            {

            }
        }

        private void btnMaxToCase1_Click(object sender, EventArgs e)
        {
            try { 
            txbFlowRate_Case1.Text = txbFlowRate_Max.Text;
            txbInletPressure_Case1.Text = txbInletPressure_Max.Text;
            txbOutletPressure_Case1.Text = txbOutletPressure_Max.Text;
            txbInletTemp_Case1.Text = txbInletTemp_Max.Text;
            txbSG_MW_Case1.Text = txbSG_MW_Max.Text;
            txbVP_K_Case1.Text = txbVP_K_Max.Text;
            txbCriticalPressure_Case1.Text = txbCriticalPressure_Max.Text;
            txbViscosity_Z_Case1.Text = txbViscosity_Z_Max.Text;
            txbRequiredCapacity_Case1.Text = txbRequiredCapacity_Max.Text;
            txbOpeningTravel_Case1.Text = txbOpeningTravel_Max.Text;
            txbPredictedSPL_Case1.Text = txbPredictedSPL_Max.Text;
            }
            catch
            {

            }
        }

        private void btnCase1ToCase2_Click(object sender, EventArgs e)
        {
            try { 
            txbFlowRate_Case2.Text = txbFlowRate_Case1.Text;
            txbInletPressure_Case2.Text = txbInletPressure_Case1.Text;
            txbOutletPressure_Case2.Text = txbOutletPressure_Case1.Text;
            txbInletTemp_Case2.Text = txbInletTemp_Case1.Text;
            txbSG_MW_Case2.Text = txbSG_MW_Case1.Text;
            txbVP_K_Case2.Text = txbVP_K_Case1.Text;
            txbCriticalPressure_Case2.Text = txbCriticalPressure_Case1.Text;
            txbViscosity_Z_Case2.Text = txbViscosity_Z_Case1.Text;
            txbRequiredCapacity_Case2.Text = txbRequiredCapacity_Case1.Text;
            txbOpeningTravel_Case2.Text = txbOpeningTravel_Case1.Text;
            txbPredictedSPL_Case2.Text = txbPredictedSPL_Case1.Text;
            }
            catch
            {

            }
        }

        private void btnNormToMin_Click(object sender, EventArgs e)
        {
            try { 
            txbFlowRate_Min.Text = txbFlowRate_Norm.Text;
            txbInletPressure_Min.Text = txbInletPressure_Norm.Text;
            txbOutletPressure_Min.Text = txbOutletPressure_Norm.Text;
            txbInletTemp_Min.Text = txbInletTemp_Norm.Text;
            txbSG_MW_Min.Text = txbSG_MW_Norm.Text;
            txbVP_K_Min.Text = txbVP_K_Norm.Text;
            txbCriticalPressure_Min.Text = txbCriticalPressure_Norm.Text;
            txbViscosity_Z_Min.Text = txbViscosity_Z_Norm.Text;
            txbRequiredCapacity_Min.Text = txbRequiredCapacity_Norm.Text;
            txbOpeningTravel_Min.Text = txbOpeningTravel_Norm.Text;
            txbPredictedSPL_Min.Text = txbPredictedSPL_Norm.Text;
            }
            catch
            {

            }
        }

        private void btnMaxToNorm_Click(object sender, EventArgs e)
        {
            try { 
            txbFlowRate_Norm.Text = txbFlowRate_Max.Text;
            txbInletPressure_Norm.Text = txbInletPressure_Max.Text;
            txbOutletPressure_Norm.Text = txbOutletPressure_Max.Text;
            txbInletTemp_Norm.Text = txbInletTemp_Max.Text;
            txbSG_MW_Norm.Text = txbSG_MW_Max.Text;
            txbVP_K_Norm.Text = txbVP_K_Max.Text;
            txbCriticalPressure_Norm.Text = txbCriticalPressure_Max.Text;
            txbViscosity_Z_Norm.Text = txbViscosity_Z_Max.Text;
            txbRequiredCapacity_Norm.Text = txbRequiredCapacity_Max.Text;
            txbOpeningTravel_Norm.Text = txbOpeningTravel_Max.Text;
            txbPredictedSPL_Norm.Text = txbPredictedSPL_Max.Text;
            }
            catch
            {

            }
        }

        private void btnCase1ToMax_Click(object sender, EventArgs e)
        {
            try { 
            txbFlowRate_Max.Text = txbFlowRate_Case1.Text;
            txbInletPressure_Max.Text = txbInletPressure_Case1.Text;
            txbOutletPressure_Max.Text = txbOutletPressure_Case1.Text;
            txbInletTemp_Max.Text = txbInletTemp_Case1.Text;
            txbSG_MW_Max.Text = txbSG_MW_Case1.Text;
            txbVP_K_Max.Text = txbVP_K_Case1.Text;
            txbCriticalPressure_Max.Text = txbCriticalPressure_Case1.Text;
            txbViscosity_Z_Max.Text = txbViscosity_Z_Case1.Text;
            txbRequiredCapacity_Max.Text = txbRequiredCapacity_Case1.Text;
            txbOpeningTravel_Max.Text = txbOpeningTravel_Case1.Text;
            txbPredictedSPL_Max.Text = txbPredictedSPL_Case1.Text;
            }
            catch
            {

            }
        }

        private void btnCase2ToCase1_Click(object sender, EventArgs e)
        {
            try { 
            txbFlowRate_Case1.Text = txbFlowRate_Case2.Text;
            txbInletPressure_Case1.Text = txbInletPressure_Case2.Text;
            txbOutletPressure_Case1.Text = txbOutletPressure_Case2.Text;
            txbInletTemp_Case1.Text = txbInletTemp_Case2.Text;
            txbSG_MW_Case1.Text = txbSG_MW_Case2.Text;
            txbVP_K_Case1.Text = txbVP_K_Case2.Text;
            txbCriticalPressure_Case1.Text = txbCriticalPressure_Case2.Text;
            txbViscosity_Z_Case1.Text = txbViscosity_Z_Case2.Text;
            txbRequiredCapacity_Case1.Text = txbRequiredCapacity_Case2.Text;
            txbOpeningTravel_Case1.Text = txbOpeningTravel_Case2.Text;
            txbPredictedSPL_Case1.Text = txbPredictedSPL_Case2.Text;
            }
            catch
            {

            }
        } 
      

        private void txbPredictedSPL_Others_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }    
      


        #endregion
    }
}
