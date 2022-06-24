using System;


namespace Radman
{
    public class Project
    {
        public int Id { get; set; }
        public string TableId { get; set; }
        public bool Saved { get; set; }
        public bool Prepared { get; set; }
        public bool Checked { get; set; }
        public bool Approved { get; set; }
        public string LastRevisionNomber { get; set; }
        public bool IsQuickProject { get; set; }
        public string ProjectName { get; set; }
        public string Client { get; set; }
        public string End_User_Ref { get; set; }
        public string Location { get; set; }
        public string RadmanRef { get; set; }
        public string Project_Ref { get; set; }
        public string Tag_No { get; set; }
        public string PID_No { get; set; }
        public string Line_No { get; set; }
        public string Service { get; set; }
        public string Quantity { get; set; }
        public Telerik.WinControls.UI.RadGridView NewFields { get; set; }




        public string Valve_Type { get; set; }
        public string Fluid_Type { get; set; }
        public string Standard_Type { get; set; }
        public string Safety_Relief { get; set; }
        public string TemperaturesRanges { get; set; }
        public string InletConnection { get; set; }
        public string OutletConnection { get; set; }
        public string FlangeFace { get; set; }
        public string Nozzle { get; set; }
        public string Bonnet { get; set; }
        public string Cap_Type { get; set; }
        public string Inlet_Size_Connection { get; set; }
        public string Outlet_Size_Connection { get; set; }
        public string Body_Bonnet { get; set; }
        public string Nozzle_Materials { get; set; }
        public string Disc { get; set; }
        public string Guide { get; set; }
        public string Spring { get; set; }
        public string Gaskets { get; set; }
        public string Bellows { get; set; }
        public string Bolting { get; set; }
        public string NACE_MR0175 { get; set; }
        public string Valve_Model_No { get; set; }
        public string Series { get; set; }
        public string Orifice { get; set; }
        public string Kd { get; set; }
        public string Area_Calculated { get; set; }
        public string Area_Selected { get; set; }
        public string Flow_Actual { get; set; }
        public string Flow_Required { get; set; }
        public string Estimated_Reaction_Force { get; set; }
        public string Estimated_Noise_Level { get; set; }
        public string Design_Code { get; set; }
        public string Sizing_Std { get; set; }
        public string Sizing_Basis { get; set; }
        public string Fluid_State_at_Inlet { get; set; }
        public string Relieving_Case { get; set; }
        public string Fluid_Name { get; set; }
        public string Molecular_Weight { get; set; }
        public string Compressibility { get; set; }
        public string k { get; set; }
        public string Saturation_Temperature { get; set; }
        public string MAWP { get; set; }
        public string MAWP_Unit { get; set; }
        public string Operating_Pressures { get; set; }
        public string Operating_Pressures_Unit { get; set; }
        public string SET_PRESSURE { get; set; }
        public string SET_PRESSURE_Unit { get; set; }
        public string Over_Pressure { get; set; }
        public string Over_Pressure_Percent { get; set; }
        public string Constant_Superimposed { get; set; }
        public string Constant_Superimposed_Unit { get; set; }
        public string Variable_Superimposed { get; set; }
        public string Variable_Superimposed_Unit { get; set; }
        public string Built_Up { get; set; }
        public string Built_Up_Unit { get; set; }
        public string Total { get; set; }
        public string Total_Unit { get; set; }
        public string Inlet_Loss { get; set; }
        public string Inlet_Loss_Percent { get; set; }
        public string Relieving_Flowing { get; set; }
        public string Relieving_Flowing_Unit { get; set; }
        public string Atmospheric { get; set; }
        public string Atmospheric_Unit { get; set; }
        public string Operating { get; set; }
        public string Operating_Unit { get; set; }
        public string Relieving { get; set; }
        public string Relieving_Unit { get; set; }
        public string Design_Min { get; set; }
        public string Design_Min_Unit { get; set; }
        public string Design_Max { get; set; }
        public string Design_Max_Unit { get; set; }
        public string Normal_System { get; set; }
        public string Normal_System_Unit { get; set; }
        public string SelectedSeries { get; set; }
        public string SelectedOrifice { get; set; }
        public string ValveService { get; set; }
        public string CodeSection { get; set; }
        public string ValveOrifice { get; set; }

        public string ACCESSORIES1 { get; set; }
        public string ACCESSORIES2 { get; set; }
        public string ACCESSORIES3 { get; set; }
        public string ACCESSORIES4 { get; set; }
        public string ACCESSORIES5 { get; set; }
        public string ACCESSORIES6 { get; set; }
        public string ACCESSORIES7 { get; set; }
        public string ACCESSORIES8 { get; set; }
        public string ACCESSORIES9 { get; set; }
        public string ACCESSORIES10 { get; set; }
        public string Test_Certificates1 { get; set; }
        public string Test_Certificates2 { get; set; }
        public string Test_Certificates3 { get; set; }
        public string Test_Certificates4 { get; set; }
        public string Test_Certificates5 { get; set; }
        public string Test_Certificates6 { get; set; }
        public string Test_Certificates7 { get; set; }
        public string Test_Certificates8 { get; set; }
        public string Valve_Size { get; set; }
        public string Ratio_of_Specific_Heats { get; set; }
        public string Inlet_Stagnation_Enthalpy { get; set; }
        public string Required_Mass_Flow { get; set; }
        public string Required_Mass_Flow1 { get; set; }
        public string Set_Pressure { get; set; }
        public string Set_Pressure1 { get; set; }
        public string Over_Pressure1 { get; set; }
        public string Inlet_Line_Loss { get; set; }
        public string Kc { get; set; }

        public string Inlet_Line_Loss1 { get; set; }
        public string Back_Pressure { get; set; }
        public string Back_Pressure1 { get; set; }
        public string Atmospheric_Pressure { get; set; }
        public string Atmospheric_Pressure1 { get; set; }
        public string Relieving_Temperature { get; set; }
        public string Relieving_Temperature1 { get; set; }
        public string Distance_from_Valve { get; set; }
        public string Distance_From_Valve1 { get; set; }
        public string Rupture_Disc_CCF { get; set; }
        public string Rupture_Disc_CCF1 { get; set; }
        public string Superheat_Correction_Factor { get; set; }
        public string Superheat_Correction_Factor1 { get; set; }
        public string Supercritical_Correction_Factor { get; set; }
        public string Supercritical_Correction_Factor1 { get; set; }
        public string Discharge_Coefficient { get; set; }
        public string Discharge_Coefficient1 { get; set; }
        public string Discharge_Coefficien_derated { get; set; }
        public string Discharge_Coefficient_Derated1 { get; set; }
        public string Orifice_Area { get; set; }
        public string Back_Pressure_Correction_Factor { get; set; }
        public string Back_Pressure_Correction_Factor1 { get; set; }
        public string Outlet_Diameter { get; set; }
        public string Outlet_Diameter1 { get; set; }
        public string P1 { get; set; }
        public string P1_unit { get; set; }
        public string P2 { get; set; }
        public string P2_unit { get; set; }
        public string PR { get; set; }
        public string PR_unit { get; set; }
        public string Kn { get; set; }
        public string Kn1 { get; set; }
        public string W { get; set; }
        public string W1 { get; set; }
        public string Areq { get; set; }
        public string Areq1 { get; set; }
        public string L30 { get; set; }
        public string L1 { get; set; }
        public string Lp { get; set; }
        public string Ao { get; set; }
        public string Po { get; set; }
        public string Fr { get; set; }
        public string Kw { get; set; }
        public string Seat_Type { get; set; }
        public string Seat { get; set; }

        public string Inle_Size_Connection { get; set; }

        public string ACCESSORIES_Material { get; set; }
        public string ACCESSORIES_Material1 { get; set; }
        public string ACCESSORIES_Material2 { get; set; }
        public string ACCESSORIES_Material3 { get; set; }
        public string ACCESSORIES_Material4 { get; set; }
        public string A { get; set; }
        public string AA { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string CC { get; set; }
        public string D { get; set; }
        public string WEIGHT { get; set; }

        public string Pa { get; set; }
        public string Pa_unit { get; set; }
        public string Pb { get; set; }
        public string Pb_unit { get; set; }
        public string VL { get; set; }
        public string VL1 { get; set; }
        public string R { get; set; }
        public string R1 { get; set; }
        public string Specific_Gravity { get; set; }
        public string Viscosity { get; set; }
        public string Kv { get; set; }
        public string Kv_Max { get; set; }
        public string R_Max { get; set; }
        public string R_Max1 { get; set; }
        public string V { get; set; }
        public string V1 { get; set; }
        public string Operating_Density { get; set; }
        public string V0 { get; set; }
        public string V90 { get; set; }
        public string Omega { get; set; }
        public string Eta_c { get; set; }
        public string Pc { get; set; }
        public string Pc_Unit { get; set; }
        public string Sub_Critical { get; set; }
        public string G { get; set; }
        public string G_Unit { get; set; }
        public string Areq_Unit { get; set; }
        public string VaporPressure { get; set; }
        public string LiquidDensity { get; set; }
        public string LiquidSpecific { get; set; }
        public string SpesificGravity { get; set; }
        public bool HasRuptureDisk { get; set; }
        public string Eta_st { get; set; }
        public string High_Subcooling { get; set; }
        public string Ps { get; set; }
        public string ro_l0 { get; set; }
        public string ro_9 { get; set; }
        public string G_SubCritical { get; set; }
        public string G_Critical { get; set; }
        public string Current_TabPage_Name { get; set; }
        public string ANSIFlangeRating { get; set; }
        public string BodyMaterial { get; set; }
        public string SpringMaterial { get; set; }
        public string TrimMaterial { get; set; }
        public string NozzleMaterial { get; set; }
        public bool SelectionVIIIApplicationCheckBox { get; set; }
        public bool chbScrewedCap { get; set; }
        public bool chbBoltedCap { get; set; }
        public bool chbAuxiliaryBackupPiston { get; set; }
        public bool chbTestGag { get; set; }
        public bool chbHighPressure { get; set; }
        public bool chbOpenLever { get; set; }
        public bool chbPackedLever { get; set; }
        public bool chbDomedCap { get; set; }
        public bool chbFerrule { get; set; }
        public bool chbGag { get; set; }
        public bool chbNACEMaterial { get; set; }
        public bool chbResilientSeat { get; set; }
        public bool chbRemotePressureSensing { get; set; }
        public bool chbBackFlowPreventer { get; set; }
        public bool chbCoolingHeatingCoils { get; set; }
        public bool chbExternalFilter { get; set; }
        public bool chbLiquidDuty { get; set; }
        public bool chbFieldTestConnector { get; set; }
        public bool chbRemoteUnloader { get; set; }
        public bool chbSpecialFeatures { get; set; }
        public string GasDensity { get; set; }
        public string SpecificValumeGas { get; set; }
        public string SpecificValumeLiquid { get; set; }
        public string Notes { get; set; }
        public string VaporFlowCapacity { get; set; }
        public string LiquidFlowCapacity { get; set; }
        public string MixDensity90 { get; set; }
        public string SpVol90 { get; set; }
        public string ViscosityUnit { get; set; }
        public string RequiredPressureFlowUnit { get; set; }
        public string RequiredFlowCapacityUnit { get; set; }
        public string DensityUnit { get; set; }
        public string SpecificValumeUnit { get; set; }
        public string VaporFlowCapacityUnit { get; set; }
        public string VaporUnitC23 { get; set; }
        public string LiquidDensityUnit { get; set; }
        public string LiquidSpecificUnit { get; set; }
        public bool chbStandardCertificateOrigin { get; set; }
        public bool chbCertificateConformancePurchaseOrder { get; set; }
        public bool chbCertificateConformanceNACE_MR0175 { get; set; }
        public bool chbCertificateConformanceASMEHydrostaticTesting { get; set; }
        public bool chbMaterialTestReports { get; set; }
        public bool chbHydrostaticTestReportASME { get; set; }
        public bool chbFunctionalTestReport { get; set; }
        public bool chbHardnessTestReport { get; set; }
        public bool chbBendTestReportBodyBonnetCasting { get; set; }
        public bool chbRadiographyTestReport { get; set; }
        public bool chbSpecialPainting { get; set; }
        public bool chbRing { get; set; }
        public bool chbNACECompliance { get; set; }
        public bool chbBonnetExtention { get; set; }
        public bool chbOpenBonnet { get; set; }
        public bool chbHeatingJacket { get; set; }  
        public string Flow_Required_Converted { get; set; }

        public Project()
        {
            Id = -1;
            TableId = "";
            Current_TabPage_Name = "";
            Saved = false;
            Prepared = false;
            Checked = false;
            Approved = false;
            LastRevisionNomber = "";
            IsQuickProject = false;
            HasRuptureDisk = false;

            chbStandardCertificateOrigin = false;
            chbCertificateConformancePurchaseOrder = false;
            chbCertificateConformanceNACE_MR0175 = false;
            chbCertificateConformanceASMEHydrostaticTesting = false;
            chbMaterialTestReports = false;
            chbHydrostaticTestReportASME = false;
            chbFunctionalTestReport = false;
            chbHardnessTestReport = false;
            chbBendTestReportBodyBonnetCasting = false;
            chbRadiographyTestReport = false;
            chbSpecialPainting = false;
            chbRing = false;
            chbNACECompliance = false;
            chbBonnetExtention = false;
            chbOpenBonnet = false;
            chbHeatingJacket = false;
            chbScrewedCap = false;
            chbBoltedCap = false;
            chbAuxiliaryBackupPiston = false;
            chbTestGag = false;
            chbHighPressure = false;
            chbOpenLever = false;
            chbPackedLever = false;
            chbDomedCap = false;
            chbFerrule = false;
            chbGag = false;
            chbNACEMaterial = false;
            chbResilientSeat = false;
            chbRemotePressureSensing = false;
            chbBackFlowPreventer = false;
            chbCoolingHeatingCoils = false;
            chbExternalFilter = false;
            chbLiquidDuty = false;
            chbFieldTestConnector = false;
            chbRemoteUnloader = false;
            chbSpecialFeatures = false;
            SpecificValumeLiquid = "";
            VaporFlowCapacity = "";
            LiquidFlowCapacity = "";
            MixDensity90 = "";
            SpVol90 = "";
            Flow_Required_Converted = "";
            ViscosityUnit = "cP";
            RequiredPressureFlowUnit = "SCFM";
            RequiredFlowCapacityUnit = "GPM (US)";
            DensityUnit = "kg/L";
            SpecificValumeUnit = "ft³/lb";
            VaporFlowCapacityUnit = "lb/hr";
            VaporUnitC23 = "psia";
            LiquidDensityUnit = "kg/L";
            LiquidSpecificUnit = "ft³/lb";
            Fluid_Type = "";
            Standard_Type = "";
            SpecificValumeGas = "";
            Notes = "";
            GasDensity = "";
            FlangeFace = "";
            BodyMaterial = "";
            SpringMaterial = "";
            TrimMaterial = "";
            NozzleMaterial = "";
            ANSIFlangeRating = "";
            ValveOrifice = "";
            SelectedSeries = "";
            SelectedOrifice = "";
            ValveService = "";
            CodeSection = "";
            TemperaturesRanges = "";
            ProjectName = "";
            OutletConnection = "";
            Client = "";
            End_User_Ref = "";
            Location = "";
            RadmanRef = "";
            Project_Ref = "";
            Tag_No = "";
            PID_No = "";
            Line_No = "";
            Service = "";
            Quantity = "";
            NewFields = new Telerik.WinControls.UI.RadGridView();
            Valve_Type = "";
            Safety_Relief = "";
            SelectionVIIIApplicationCheckBox = false;
            Nozzle = "";
            Bonnet = "";
            Cap_Type = "";
            Inlet_Size_Connection = "";
            Outlet_Size_Connection = "";
            Body_Bonnet = "";
            Nozzle_Materials = "";
            Disc = "";
            Guide = "";
            Spring = "";
            Gaskets = "";
            Bellows = "";
            Bolting = "";
            NACE_MR0175 = "";
            Valve_Model_No = "";
            Series = "";
            Orifice = "";
            Kd = "";
            Kc = "1";
            Area_Calculated = "";
            Area_Selected = "";
            Flow_Actual = "";
            Flow_Required = "";
            Estimated_Reaction_Force = "";
            Estimated_Noise_Level = "";
            Design_Code = "";
            Sizing_Std = "";
            Sizing_Basis = "";
            Fluid_State_at_Inlet = "";
            Relieving_Case = "";
            Fluid_Name = "";
            Molecular_Weight = "";
            Compressibility = "";
            InletConnection = "";
            k = "";
            Saturation_Temperature = "";
            MAWP = "";
            MAWP_Unit = "";
            Operating_Pressures = "";
            Operating_Pressures_Unit = "";
            SET_PRESSURE = "";
            SET_PRESSURE_Unit = "";
            Over_Pressure = "";
            Over_Pressure_Percent = "10";
            Constant_Superimposed = "";
            Constant_Superimposed_Unit = "";
            Variable_Superimposed = "";
            Variable_Superimposed_Unit = "";
            Built_Up = "";
            Built_Up_Unit = "";
            Total = "";
            Total_Unit = "";
            Inlet_Loss = "";
            Inlet_Loss_Percent = "";
            Relieving_Flowing = "";
            Relieving_Flowing_Unit = "";
            Atmospheric = "14.696";
            Atmospheric_Unit = "psia";
            Operating = "";
            Operating_Unit = "";
            Relieving = "";
            Relieving_Unit = "°C";
            Design_Min = "";
            Design_Min_Unit = "";
            Design_Max = "";
            Design_Max_Unit = "";
            Normal_System = "";
            Normal_System_Unit = "";
            ACCESSORIES1 = "";
            ACCESSORIES2 = "";
            ACCESSORIES3 = "";
            ACCESSORIES4 = "";
            ACCESSORIES5 = "";
            ACCESSORIES6 = "";
            ACCESSORIES7 = "";
            ACCESSORIES8 = "";
            ACCESSORIES9 = "";
            ACCESSORIES10 = "";
            Test_Certificates1 = "";
            Test_Certificates2 = "";
            Test_Certificates3 = "";
            Test_Certificates4 = "";
            Test_Certificates5 = "";
            Test_Certificates6 = "";
            Test_Certificates7 = "";
            Test_Certificates8 = "";
            Valve_Size = "";
            Ratio_of_Specific_Heats = "";
            Inlet_Stagnation_Enthalpy = "";
            Required_Mass_Flow = "0";
            Required_Mass_Flow1 = "";
            Set_Pressure = "0";
            Set_Pressure1 = "";
            Over_Pressure1 = "";
            Inlet_Line_Loss = "0";
            Inlet_Line_Loss1 = "";
            Back_Pressure = "0";
            Back_Pressure1 = "0";
            Atmospheric_Pressure = "14.696";
            Atmospheric_Pressure1 = "";
            Relieving_Temperature = "";
            Relieving_Temperature1 = "";
            Distance_from_Valve = "1   m";
            Distance_From_Valve1 = "";
            Rupture_Disc_CCF = "";
            Rupture_Disc_CCF1 = "";
            Superheat_Correction_Factor = "";
            Superheat_Correction_Factor1 = "";
            Supercritical_Correction_Factor = "";
            Supercritical_Correction_Factor1 = "";
            Discharge_Coefficient = "";
            Discharge_Coefficient1 = "";
            Discharge_Coefficien_derated = "";
            Discharge_Coefficient_Derated1 = "";
            Orifice_Area = "";
            Back_Pressure_Correction_Factor = "";
            Back_Pressure_Correction_Factor1 = "";
            Outlet_Diameter = "";
            Outlet_Diameter1 = "";
            P1 = "";
            P1_unit = "";
            P2 = "";
            P2_unit = "";
            PR = "";
            PR_unit = "";
            Kn = "";
            Kn1 = "";
            W = "";
            W1 = "";
            Areq = "";
            Areq1 = "";
            L30 = "";
            L1 = "";
            Lp = "";
            Ao = "";
            Po = "";
            Fr = "";
            Inle_Size_Connection = "";
            ACCESSORIES_Material = "";
            ACCESSORIES_Material1 = "";
            ACCESSORIES_Material2 = "";
            ACCESSORIES_Material3 = "";
            ACCESSORIES_Material4 = "";
            A = "";
            AA = "";
            B = "";
            C = "";
            CC = "";
            D = "";
            WEIGHT = "";
            Pa = "";
            Pa_unit = "";
            Pb = "";
            Pb_unit = "";
            VL = "";
            VL1 = "";
            R = "";
            R1 = "";
            Specific_Gravity = "";
            Viscosity = "";
            Kv = "";
            Kv_Max = "";
            R_Max = "";
            R_Max1 = "";
            V = "";
            V1 = "";
            Kw = "";
            Operating_Density = "";
            V0 = "";
            V90 = "";
            Omega = "";
            Eta_c = "";
            Pc = "";
            Pc_Unit = "";
            Sub_Critical = "";
            G_Critical = "";
            G_SubCritical = "";
            G = "";
            G_Unit = "";
            Areq_Unit = "";
            VaporPressure = "";
            LiquidDensity = "";
            LiquidSpecific = "";
            SpesificGravity = "";
            Eta_st = "";
            High_Subcooling = "";
            Ps = "";
            ro_l0 = "";
            ro_9 = "";
            Seat_Type = "";
            Seat = "";
        }


    }   
}
