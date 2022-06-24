using System;
using System.Collections.Generic;
using System.Text;


namespace Radman
{
    public static class ControlCalculate
    {
        public static string P1_Min { get; set; }
        public static string P2_Min { get; set; }
        public static string Delta_P_Min { get; set; }
        public static string Delta_P_Min_Choked { get; set; }
        public static string Delta_P_Min_Sizing { get; set; }
        public static string SG_Min { get; set; }
        public static string Cv_Real_Min { get; set; }


        public static string P1_Norm { get; set; }
        public static string P2_Norm { get; set; }
        public static string Delta_P_Norm { get; set; }
        public static string Delta_P_Norm_Choked { get; set; }
        public static string Delta_P_Norm_Sizing { get; set; }
        public static string SG_Norm { get; set; }
        public static string Cv_Real_Norm { get; set; }

        public static string P1_Max { get; set; }
        public static string P2_Max { get; set; }
        public static string Delta_P_Max { get; set; }
        public static string Delta_P_Max_Choked { get; set; }
        public static string Delta_P_Max_Sizing { get; set; }
        public static string SG_Max { get; set; }
        public static string Cv_Real_Max { get; set; }

        public static string P1_Case1 { get; set; }
        public static string P2_Case1 { get; set; }
        public static string Delta_P_Case1 { get; set; }
        public static string Delta_P_Case1_Choked { get; set; }
        public static string Delta_P_Case1_Sizing { get; set; }
        public static string SG_Case1 { get; set; }
        public static string Cv_Real_Case1 { get; set; }
        public static bool IsMolcularWeight { get; set; }

        public static string P1_Case2 { get; set; }
        public static string P2_Case2 { get; set; }
        public static string Delta_P_Case2 { get; set; }
        public static string Delta_P_Case2_Choked { get; set; }
        public static string Delta_P_Case2_Sizing { get; set; }
        public static string SG_Case2 { get; set; }
        public static string Cv_Real_Case2 { get; set; }

        public static string P_Unit { get; set; }
        public static string P_Unit_a { get; set; }

        public static string Delta_P_Unit { get; set; }


        public static string Q_Min { get; set; }
        public static string Q_Norm { get; set; }
        public static string Q_Max { get; set; }
        public static string Q_Case1 { get; set; }
        public static string Q_Case2 { get; set; }
        public static string Q_Unit { get; set; }

        public static string T_Min { get; set; }
        public static string T_Norm { get; set; }
        public static string T_Max { get; set; }
        public static string T_Case1 { get; set; }
        public static string T_Case2 { get; set; }
        public static string T_Unit { get; set; }

        public static string Z_Min { get; set; }
        public static string Z_Norm { get; set; }
        public static string Z_Max { get; set; }
        public static string Z_Case1 { get; set; }
        public static string Z_Case2 { get; set; }
       


        private static string W_Min_Convert { get; set; }
        private static string W_Norm_Convert { get; set; }
        private static string W_Max_Convert { get; set; }
        private static string W_Case1_Convert { get; set; }
        private static string W_Case2_Convert { get; set; }
      

        public static string Pc_Min { get; set; }
        public static string Pc_Norm { get; set; }
        public static string Pc_Max { get; set; }
        public static string Pc_Case1 { get; set; }
        public static string Pc_Case2 { get; set; }

        public static string Pc_Min_Input { get; set; }
        public static string Pc_Norm_Input { get; set; }
        public static string Pc_Max_Input { get; set; }
        public static string Pc_Case1_Input { get; set; }
        public static string Pc_Case2_Input { get; set; }

        public static string Pc_Unit { get; set; }


        public static string Pv_Min { get; set; }
        public static string Pv_Norm { get; set; }
        public static string Pv_Max { get; set; }
        public static string Pv_Case1 { get; set; }
        public static string Pv_Case2 { get; set; }

        public static string Pv_Min_Input { get; set; }
        public static string Pv_Norm_Input { get; set; }
        public static string Pv_Max_Input { get; set; }
        public static string Pv_Case1_Input { get; set; }
        public static string Pv_Case2_Input { get; set; }
        public static string Pv_Unit { get; set; }

        private static string Ff_Min { get; set; }
        private static string Ff_Norm { get; set; }
        private static string Ff_Max { get; set; }
        private static string Ff_Case1 { get; set; }
        private static string Ff_Case2 { get; set; }

        private static string Mu_Min { get; set; }
        private static string Mu_Norm { get; set; }
        private static string Mu_Max { get; set; }
        private static string Mu_Case1 { get; set; }
        private static string Mu_Case2 { get; set; }

        private static string F_Minuscule_Min { get; set; }
        private static string F_Minuscule_Norm { get; set; }
        private static string F_Minuscule_Max { get; set; }
        private static string F_Minuscule_Case1 { get; set; }
        private static string F_Minuscule_Case2 { get; set; }


        private static string Xsixing_Min { get; set; }
        private static string Xsixing_Norm { get; set; }
        private static string Xsixing_Max { get; set; }
        private static string Xsixing_Case1 { get; set; }
        private static string Xsixing_Case2 { get; set; }

        private static string Qs_Min { get; set; }
        private static string Qs_Norm { get; set; }
        private static string Qs_Max { get; set; }
        private static string Qs_Case1 { get; set; }
        private static string Qs_Case2 { get; set; }

        private static string Xchoked_Min { get; set; }
        private static string Xchoked_Norm { get; set; }
        private static string Xchoked_Max { get; set; }
        private static string Xchoked_Case1 { get; set; }
        private static string Xchoked_Case2 { get; set; }

        private static string X_Min { get; set; }
        private static string X_Norm { get; set; }
        private static string X_Max { get; set; }
        private static string X_Case1 { get; set; }
        private static string X_Case2 { get; set; } 
        private static string Xtp { get; set; }
      

        public static string Density_Unit { get; set; }

        public static string D1 { get; set; }        
        public static string D1_Unit { get; set; }

        public static string D2 { get; set; }
        public static string D2_Unit { get; set; }

        private static string Ksi1 { get; set; }
        private static string Ksi2 { get; set; }

        private static string KsiB1 { get; set; }
        private static string KsiB2 { get; set; }
        private static string KsiI { get; set; }
        private static string SigmaKsi { get; set; }  
        public static int BodyType_selected_index { get; set; }
        private static string d { get; set; }
        public static string D { get; set; }
        public static int d_selected_index { get; set; }
        private static string d_Unit { get; set; }
        private static string Fl { get; set; }
        private static string Xt { get; set; }
        private static string Fp { get; set; }
        private static string Flp { get; set; }
        public static int TrimTypeIndex { get; set; }
        public static int PortSizeIndex { get; set; }
        public static int FlowCharacterIndex { get; set; }

        public static string Cv_Rated { get; set; }


        private static string N2 { get; set; }
        private static string N1 { get; set; }
        private static string N6 { get; set; } 
        private static string N8 { get; set; }
        private static string N5 { get; set; }
        private static string N9 { get; set; }


        private static string P1_Description = "Inlet absolute static perssure.";
        private static string P2_Description = "Outlet absolute static perssure.";
        private static string Delta_P_Actual_Description = "Differential pressure between upstream and downstream pressure taps (P" + "\x2081" + " - P" + "\x2082" + ")";
        private static string Q_Description = "Actual volumetric flow rate.";
        private static string Pc_Description = "Absolute thermodynamic critical pressure.";
        private static string Pv_Description = "Absolute vapor pressure for the liquid at inlet temperature.";
        private static string Ff_Description = "Liquid critical pressure ratio factor.";
        private static string D1_Description = "Internal diameter of upstream piping.";
        private static string D2_Description = "Internal diameter of downstream piping.";
        private static string d_Description = "Nominal valve size.";
        private static string Ksi1_Description = "Upstream velocity head loss ceofficient to fitting.";
        private static string Ksi2_Description = "Downstream velocity head loss ceofficient to fitting.";
        private static string KsiB1_Description = "Inlet Bernoull coefficient.";
        private static string KsiB2_Description = "Outlet Bernoull coefficient.";
        private static string KsiI_Description = "ξᵢ = ξ₁ + ξB₁";
        private static string SigmaKsi_Description = "Σξ = ξ₁ + ξ₂ + ξB₁ - ξB₂";
        private static string Fl_Description = "Liquid pressure recovery factor of a control valve without attached fittings.";
        private static string N_Description = "Numerical Constant.";       
        private static string Flp_Description = "Combined liquid pressure recovery factor and piping geometry factor of a control valve with attached fittings.";
        private static string Fp_Description = "Piping geometry factor.";
        private static string Delta_P_Choked_Description = "Computed value of limiting pressure differential for incompressible flow.";
        private static string Delta_P_Sizing_Description = "Value op pressure differential used in computing flow or required flow coefficient for incompressible flows.";
        private static string SG_Description = "Relative density(ρ₁/ρ₀ = 1.0 for water at 15°C)";
        private static string C_Description = "Flow coefficient (Kᵥ, Cᵥ).";
        private static string W_Description = "Mass flow rate.";
        private static string M_Description = "Molecular mass of flowing fluid.";
        private static string X_Description = "Ratio of actual differential to inlet absolute pressure (∆P/P₁).";
        private static string Xt_Description = "Pressure differential ratio factor of a control valve without attached fitting at choked flow.";
        private static string Qs_Description = "Standard volumetric flow rate.";
        private static string Xtp_Description = "Pressure differential ratio factor of a control valve with attached fitting at choked flow.";
        private static string Xchoked_Description = "choked pressure drop ratio for compressible flow.";
        private static string Xsizing_Description = "Value of pressure drop ratio used in computing flow or required flow coefficient for compressible flows.";
        private static string F_Minuscule_Description = "Specific heat ratio factor.";
        private static string Mu_Description = "Expansion factor.";


        public static void Calculate(string FluidType)
        {
            try { 
            switch (FluidType)
            {
                case "Liquid":
                    {
                        switch (ControlCalculate.Q_Unit)
                        {
                            case "kg/hr":
                            case "lb/hr":
                            case "ton/hr":
                                {
                                    CalculateLiquidMass();
                                    break;
                                }
                            default:
                                {
                                    CalculateLiquidVolumetric();
                                    break;
                                }
                        }
                        break;
                    }
                case "Gas":
                    {
                        switch (ControlCalculate.Q_Unit)
                        {
                            case "kg/hr":
                            case "lb/hr":
                            case "ton/hr":
                                {
                                    CalculateGasMass();
                                    break;
                                }
                            default:
                                {
                                    CalculateGasVolometric();
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
        private static void CalculateLiquidVolumetric()
        {
            try { 
            CalculatePv_Pc();            
            CalculateFf();
            CalculateBodySize();
            CalculateKsi1();
            CalculateKsi2();
            CalculateKsiB1();
            CalculateKsiB2();
            CalculateKsiI();
            CalculateSigmaKsi();
            CalculateFl();
            CalculateN2();
            CalculateN1();
            CalculateFlp();
            CalculateFp();
            CalculateDelteChoked();
            CalculateDeltaSizing();
            CalculateCvReal();
            SetLiquidVolometricSymbolList();
            }
            catch
            {

            }
        } 
        private static void CalculateLiquidMass()
        {
            try { 
            CalculatePv_Pc();
            CalculateFf();
            CalculateBodySize();
            CalculateKsi1();
            CalculateKsi2();
            CalculateKsiB1();
            CalculateKsiB2();
            CalculateKsiI();
            CalculateSigmaKsi();
            CalculateFl();
            CalculateN2();
            CalculateN1();
            CalculateN6();
            CalculateFlp();
            CalculateFp();
            CalculateDelteChoked();
            CalculateDeltaSizing();
            CalculateCvRealLiquidMass();
            SetLiquidMassSymbolList();
            }
            catch
            {

            }
        }
        private static void CalculateGasMass()
        {
            try { 
            if (IsMolcularWeight == true)
                CalculateGasMass_MW();
            else
                CalculateGasMass_Density();
            }
            catch
            {

            }
        }    
        private static void CalculateGasVolometric()
        {
            try { 
            if (IsMolcularWeight == true)
                CalculateGasVolometric_MW();
            else
            {
                //CalculateGasVolometric_Density();
            }
            }
            catch
            {

            }
        }
        private static void CalculateGasMass_MW()
        {
            try { 
            CalculateW();
            CalculateN8();
            CalculateKsi1();
            CalculateKsi2();
            CalculateKsiB1();
            CalculateKsiB2();
            CalculateKsiI();
            CalculateSigmaKsi();
            CalculateBodySize();
            CalculateFlGas();
            CalculateN2();
            CalculateN5();
            CalculateFp();
            CalculateX();            
            CalculateXt();
            CalculateXtp();
            CalculateFminuscule();
            CalculateXchoked();
            CalculateXsizing();
            CalculateMu();
            CalculateCvReal_GasMass_MW();
            SetGasMassMWSymbolList();
            }
            catch
            {

            }
        }      
        private static void CalculateGasVolometric_MW()
        {
            try {           
            CalculateQs();
            CalculateKsi1();
            CalculateKsi2();
            CalculateKsiB1();
            CalculateKsiB2();
            CalculateKsiI();
            CalculateSigmaKsi();
            CalculateBodySize();
            CalculateFlGas();
            CalculateN2();
            CalculateN5();
            CalculateFp();
            CalculateX();
            CalculateXt();
            CalculateXtp();
            CalculateFminuscule();
            CalculateXchoked();
            CalculateXsizing();
            CalculateMu();
            CalculateN9();
            CalculateCvReal_GasVolometric_MW();
            SetGasVolometricMWSymbolList();
            }
            catch
            {

            }

        } 
        
        private static void CalculateN9()
        {
            try { 
            if (Q_Unit == "Nm³/hr")
                N9 = "21.20";
            else if (Q_Unit == "Sft³/hr")
                N9 = "7320";
            else
                N9 = "22.50";
            }
            catch
            {

            }
        }
        private static void CalculateGasMass_Density()
        {
            try { 
            CalculateW();
            CalculateN6();
            CalculateKsi1();
            CalculateKsi2();
            CalculateKsiB1();
            CalculateKsiB2();
            CalculateKsiI();
            CalculateSigmaKsi();
            CalculateBodySize();
            CalculateFlGas();
            CalculateN2();
            CalculateN5();
            CalculateFp();
            CalculateX();
            CalculateXt();
            CalculateXtp();
            CalculateFminuscule();
            CalculateXchoked();
            CalculateXsizing();
            CalculateMu();
            CalculateCvReal_GasMass_Density();
            SetGasMassDensitySymbolList();
            }
            catch
            {

            }

        }    
        private static void CalculateW()
        {
            try { 
            decimal w_min = 0;
            decimal w_norm = 0;
            decimal w_max = 0;
            decimal w_case1 = 0;
            decimal w_case2 = 0;
            if (Q_Unit == "ton/hr")
                Q_Unit = "Ton(mt)/hr";
            if(Q_Min != "")
                w_min = BL.ConvertUnit(Convert.ToDecimal(Q_Min), Q_Unit, "kg/hr");
            if (Q_Norm != "")
                w_norm = BL.ConvertUnit(Convert.ToDecimal(Q_Norm), Q_Unit, "kg/hr");
            if (Q_Max != "")
                w_max = BL.ConvertUnit(Convert.ToDecimal(Q_Max), Q_Unit, "kg/hr");
            if (Q_Case1 != "")
                w_case1 = BL.ConvertUnit(Convert.ToDecimal(Q_Case1), Q_Unit, "kg/hr");
            if (Q_Case2 != "")
                w_case2 = BL.ConvertUnit(Convert.ToDecimal(Q_Case2), Q_Unit, "kg/hr");
            W_Min_Convert = Math.Round(w_min, 3).ToString();
            W_Norm_Convert = Math.Round(w_norm, 3).ToString();
            W_Max_Convert = Math.Round(w_max, 3).ToString();
            W_Case1_Convert = Math.Round(w_case1, 3).ToString();
            W_Case2_Convert = Math.Round(w_case2, 3).ToString();
            }
            catch
            {

            }
        }    
        private static void CalculateQs()
        {
            try { 
            if (Q_Unit == "Nm³/ hr" || Q_Unit == "Sft³/hr")
            {
                Qs_Min = Q_Min;
                Qs_Norm = Q_Norm;
                Qs_Max = Q_Max;
                Qs_Case1 = Q_Case1;
                Qs_Case2 = Q_Case2;
            }
            else
            {
                double ts = 288.15;
                double ps = 1.013;
                decimal add = 0;
                switch (P_Unit)
                {
                    case "atm g":
                        {
                            add = 1;
                            P_Unit_a = "atm a";
                            break;
                        }
                    case "barg":
                        {
                            add = 1;
                            P_Unit_a = "bara";
                            break;
                        }
                    case "ft wc g":
                        {
                            add = 1;
                            P_Unit_a = "ft wc a";
                            break;
                        }

                    case "in Hg g":
                        {
                            add = 1;
                            P_Unit_a = "in Hg a";
                            break;
                        }
                    case "in wc g":
                        {
                            add = 1;
                            P_Unit_a = "in wc a";
                            break;
                        }
                    case "kg/cm² g":
                        {
                            add = 1;
                            P_Unit_a = "kg/cm²  a";
                            break;
                        }
                    case "kPa g":
                        {
                            add = 1;
                            P_Unit_a = "kPa  a";
                            break;
                        }
                    case "lb/ft² g":
                        {
                            add = 1;
                            P_Unit_a = "lb/ft² a";
                            break;
                        }
                    case "mbarg":
                        {
                            add = 1;
                            P_Unit_a = "mbara";
                            break;
                        }
                    case "meter H2O g":
                        {
                            add = 1;
                            P_Unit_a = "meter H2O a";
                            break;
                        }
                    case "mm H2O g":
                        {
                            add = 1;
                            P_Unit_a = "mm H2O a";
                            break;
                        }
                    case "mm Hg g":
                        {
                            add = 1;
                            P_Unit_a = "mm Hg a";
                            break;
                        }
                    case "Mpa g":
                        {
                            add = 1;
                            P_Unit_a = "Mpa a";
                            break;
                        }
                    case "oz/in² g":
                        {
                            add = 1;
                            P_Unit_a = "oz/in² a";
                            break;
                        }
                    case "psig":
                        {
                            add = 1;
                            P_Unit_a = "psia";
                            break;
                        }
                    case "Pa g":
                        {
                            add = 1;
                            P_Unit_a = "Pa a";
                            break;
                        }
                    case "Torr g ":
                        {
                            add = 1;
                            P_Unit_a = "Torr a";
                            break;
                        }
                    default:
                        {
                            add = 0;
                            P_Unit_a = P_Unit;
                            break;
                        }
                }

                if (P1_Min != "" && P_Unit_a != "" && T_Min != "" && Q_Min != "")
                {
                    decimal p1 = BL.ConvertUnit(Convert.ToDecimal(P1_Min), P_Unit_a, "bara") + add;
                    decimal t1 = BL.ConvertTempToKelvin(T_Min, T_Unit);
                    double qs = (Convert.ToDouble(Q_Min) * (double)p1 * ts) / (ps * (double)t1);
                    Qs_Min = Math.Round(qs, 3).ToString();
                }
                else
                    Qs_Min = "";

                if (P1_Norm != "" && P_Unit_a != "" && T_Norm != "" && Q_Norm != "")
                {
                    decimal p1 = BL.ConvertUnit(Convert.ToDecimal(P1_Norm), P_Unit_a, "bara") + add;
                    decimal t1 = BL.ConvertTempToKelvin(T_Norm, T_Unit);
                    double qs = (Convert.ToDouble(Q_Norm) * (double)p1 * ts) / (ps * (double)t1);
                    Qs_Norm = Math.Round(qs, 3).ToString();
                }
                else
                    Qs_Norm = "";

                if (P1_Max != "" && P_Unit_a != "" && T_Max != "" && Q_Max != "")
                {
                    decimal p1 = BL.ConvertUnit(Convert.ToDecimal(P1_Max), P_Unit_a, "bara") + add;
                    decimal t1 = BL.ConvertTempToKelvin(T_Max, T_Unit);
                    double qs = (Convert.ToDouble(Q_Max) * (double)p1 * ts) / (ps * (double)t1);
                    Qs_Max = Math.Round(qs, 3).ToString();
                }
                else
                    Qs_Max = "";

                if (P1_Case1 != "" && P_Unit_a != "" && T_Case1 != "" && Q_Case1 != "")
                {
                    decimal p1 = BL.ConvertUnit(Convert.ToDecimal(P1_Case1), P_Unit_a, "bara") + add;
                    decimal t1 = BL.ConvertTempToKelvin(T_Case1, T_Unit);
                    double qs = (Convert.ToDouble(Q_Case1) * (double)p1 * ts) / (ps * (double)t1);
                    Qs_Case1 = Math.Round(qs, 3).ToString();
                }
                else
                    Qs_Case1 = "";

                if (P1_Case2 != "" && P_Unit_a != "" && T_Case2 != "" && Q_Case2 != "")
                {
                    decimal p1 = BL.ConvertUnit(Convert.ToDecimal(P1_Case2), P_Unit_a, "bara") + add;
                    decimal t1 = BL.ConvertTempToKelvin(T_Case2, T_Unit);
                    double qs = (Convert.ToDouble(Q_Case2) * (double)p1 * ts) / (ps * (double)t1);
                    Qs_Case2 = Math.Round(qs, 3).ToString();
                }
                else
                    Qs_Case2 = "";


            }
            }
            catch
            {

            }
        }
        private static void CalculateN8()
        {
            N8 = "0.948";
        }  
        private static void CalculateN5()
        {
            N5 = "0.00241";
        }  
        private static void CalculateMu()
        {
            try { 
            if (Xsixing_Min != "" && Xchoked_Min != "")
            {
                double mu = 1 - (Convert.ToDouble(Xsixing_Min) / (3 * Convert.ToDouble(Xchoked_Min)));
                Mu_Min = Math.Round(mu, 3).ToString();
            }
            else
                Mu_Min = "";

            if (Xsixing_Norm != "" && Xchoked_Norm != "")
            {
                double mu = 1 - (Convert.ToDouble(Xsixing_Norm) / (3 * Convert.ToDouble(Xchoked_Norm)));
                Mu_Norm = Math.Round(mu, 3).ToString();
            }
            else
                Mu_Norm = "";

            if (Xsixing_Max != "" && Xchoked_Max != "")
            {
                double mu = 1 - (Convert.ToDouble(Xsixing_Max) / (3 * Convert.ToDouble(Xchoked_Max)));
                Mu_Max = Math.Round(mu, 3).ToString();
            }
            else
                Mu_Max = "";

            if (Xsixing_Case1 != "" && Xchoked_Case1 != "")
            {
                double mu = 1 - (Convert.ToDouble(Xsixing_Case1) / (3 * Convert.ToDouble(Xchoked_Case1)));
                Mu_Case1 = Math.Round(mu, 3).ToString();
            }
            else
                Mu_Case1 = "";

            if (Xsixing_Case2 != "" && Xchoked_Case2 != "")
            {
                double mu = 1 - (Convert.ToDouble(Xsixing_Case2) / (3 * Convert.ToDouble(Xchoked_Case2)));
                Mu_Case2 = Math.Round(mu, 3).ToString();
            }
            else
                Mu_Case2 = "";
            }
            catch
            {

            }
        }
        private static void CalculatePv_Pc()
        {
            try { 
            decimal pv_min = 0;
            decimal pv_norm = 0;
            decimal pv_max = 0;
            decimal pv_case1 = 0;
            decimal pv_case2 = 0;

            decimal pc_min = 0;
            decimal pc_norm = 0;
            decimal pc_max = 0;
            decimal pc_case1 = 0;
            decimal pc_case2 = 0;
            decimal add = 0;
           
            switch (Pv_Unit)
            {
                case "atm g":
                    {
                        add = 1;
                        P_Unit_a = "atm a";
                        break;
                    }
                case "barg":
                    {
                        add = 1;
                        P_Unit_a = "bara";
                        break;
                    }
                case "ft wc g":
                    {
                        add = 1;
                        P_Unit_a = "ft wc a";
                        break;
                    }

                case "in Hg g":
                    {
                        add = 1;
                        P_Unit_a = "in Hg a";
                        break;
                    }
                case "in wc g":
                    {
                        add = 1;
                        P_Unit_a = "in wc a";
                        break;
                    }
                case "kg/cm² g":
                    {
                        add = 1;
                        P_Unit_a = "kg/cm²  a";
                        break;
                    }
                case "kPa g":
                    {
                        add = 1;
                        P_Unit_a = "kPa  a";
                        break;
                    }
                case "lb/ft² g":
                    {
                        add = 1;
                        P_Unit_a = "lb/ft² a";
                        break;
                    }
                case "mbarg":
                    {
                        add = 1;
                        P_Unit_a = "mbara";
                        break;
                    }
                case "meter H2O g":
                    {
                        add = 1;
                        P_Unit_a = "meter H2O a";
                        break;
                    }
                case "mm H2O g":
                    {
                        add = 1;
                        P_Unit_a = "mm H2O a";
                        break;
                    }
                case "mm Hg g":
                    {
                        add = 1;
                        P_Unit_a = "mm Hg a";
                        break;
                    }
                case "Mpa g":
                    {
                        add = 1;
                        P_Unit_a = "Mpa a";
                        break;
                    }
                case "oz/in² g":
                    {
                        add = 1;
                        P_Unit_a = "oz/in² a";
                        break;
                    }
                case "psig":
                    {
                        add = 1;
                        P_Unit_a = "psia";
                        break;
                    }
                case "Pa g":
                    {
                        add = 1;
                        P_Unit_a = "Pa a";
                        break;
                    }
                case "Torr g ":
                    {
                        add = 1;
                        P_Unit_a = "Torr a";
                        break;
                    }
                default:
                    {
                        add = 0;
                        P_Unit_a = P_Unit;
                        break;
                    }
            }

            if (Pv_Min != "")
            {
                Pv_Min_Input = Pv_Min;
                pv_min = BL.ConvertUnit(Convert.ToDecimal(Pv_Min), P_Unit_a, "kPa a") + add;
                Pv_Min = Math.Round(pv_min,3).ToString();
            }
            if (Pv_Norm != "")
            {
                Pv_Norm_Input = Pv_Norm;
                pv_norm = BL.ConvertUnit(Convert.ToDecimal(Pv_Norm), P_Unit_a, "kPa a") + add;
                Pv_Norm = Math.Round(pv_norm,3).ToString();
            }
            if (Pv_Max != "")
            {
                Pv_Max_Input = Pv_Max;
                pv_max = BL.ConvertUnit(Convert.ToDecimal(Pv_Max), P_Unit_a, "kPa a") + add;
                Pv_Max = Math.Round(pv_max,3).ToString();
            }
            if (Pv_Case1 != "")
            {
                Pv_Case1_Input = Pv_Case1;
                pv_case1 = BL.ConvertUnit(Convert.ToDecimal(Pv_Case1), P_Unit_a, "kPa a") + add;
                Pv_Case1 = Math.Round(pv_case1,3).ToString();
            }
            if (Pv_Case2 != "")
            {
                Pv_Case2_Input = Pv_Case2;
                pv_case2 = BL.ConvertUnit(Convert.ToDecimal(Pv_Case2), P_Unit_a, "kPa a") + add;
                Pv_Case2 = Math.Round(pv_case2,3).ToString();
            }


            if (Pc_Min != "")
            {
                Pc_Min_Input = Pc_Min;
                pc_min = BL.ConvertUnit(Convert.ToDecimal(Pc_Min), P_Unit_a, "kPa a") + add;
                Pc_Min = Math.Round(pc_min,3).ToString();
            }
            if (Pc_Norm != "")
            {
                Pc_Norm_Input = Pc_Norm;
                pc_norm = BL.ConvertUnit(Convert.ToDecimal(Pc_Norm), P_Unit_a, "kPa a") + add;
                Pc_Norm = Math.Round(pc_norm,3).ToString();
            }
            if (Pc_Max != "")
            {
                Pc_Max_Input = Pc_Max;
                pc_max = BL.ConvertUnit(Convert.ToDecimal(Pc_Max), P_Unit_a, "kPa a") + add;
                Pc_Max = Math.Round(pc_max,3).ToString();
            }
            if (Pc_Case1 != "")
            {
                Pc_Case1_Input = Pc_Case1;
                pc_case1 = BL.ConvertUnit(Convert.ToDecimal(Pc_Case1), P_Unit_a, "kPa a") + add;
                Pc_Case1 = Math.Round(pc_case1,3).ToString();
            }
            if (Pc_Case2 != "")
            {
                Pc_Case2_Input = Pc_Case2;
                pc_case2 = BL.ConvertUnit(Convert.ToDecimal(Pc_Case2), P_Unit_a, "kPa a") + add;
                Pc_Case2 = Math.Round(pc_case2,3).ToString();
            }
            }
            catch
            {

            }
        }
        private static void CalculateFf()
        {
            try { 
            if (Pv_Min != "" && Pc_Min != "")
            {
                double pv_min = Convert.ToDouble(Pv_Min);
                double pc_min = Convert.ToDouble(Pc_Min);
                double ff_min = 0.96 - (0.28 * Math.Sqrt(pv_min / pc_min));
                Ff_Min = Math.Round(ff_min,3).ToString();
            }
            else
            {
                Ff_Min = "";
            }

            if (Pv_Norm != "" && Pc_Norm != "")
            {
                double pv_norm = Convert.ToDouble(Pv_Norm);
                double pc_norm = Convert.ToDouble(Pc_Norm);
                double ff_norm = 0.96 - (0.28 * Math.Sqrt(pv_norm / pc_norm));
                Ff_Norm = Math.Round(ff_norm,3).ToString();
            }
            else
            {
                Ff_Norm = "";
            }

            if (Pv_Max != "" && Pc_Max != "")
            {
                double pv_max = Convert.ToDouble(Pv_Max);
                double pc_max = Convert.ToDouble(Pc_Max);
                double ff_max = 0.96 - (0.28 * Math.Sqrt(pv_max / pc_max));
                Ff_Max = Math.Round(ff_max,3).ToString();
            }
            else
            {
                Ff_Max = "";
            }

            if (Pv_Case1 != "" && Pc_Case1 != "")
            {
                double pv_case1 = Convert.ToDouble(Pv_Case1);
                double pc_case1 = Convert.ToDouble(Pc_Case1);
                double ff_case1 = 0.96 - (0.28 * Math.Sqrt(pv_case1 / pc_case1));
                Ff_Case1 = Math.Round(ff_case1,3).ToString();
            }
            else
            {
                Ff_Case1 = "";
            }

            if (Pv_Case2 != "" && Pc_Case2 != "")
            {
                double pv_case2 = Convert.ToDouble(Pv_Case2);
                double pc_case2 = Convert.ToDouble(Pc_Case2);
                double ff_case2 = 0.96 - (0.28 * Math.Sqrt(pv_case2 / pc_case2));
                Ff_Case2 = Math.Round(ff_case2,3).ToString();
            }
            else
            {
                Ff_Case2 = "";
            }
            }
            catch
            {

            }
        }
        private static void CalculateKsi1()
        {
            try { 
            if (d != "" && D1 != "")
            {
                double _d = Convert.ToDouble(d);
                double _D1 = Convert.ToDouble(D1);
                double ksi1 = 0.5 * Math.Pow((1 - Math.Pow((_d / _D1), 2)), 2);
                Ksi1 = Math.Round(ksi1,3).ToString();
            }
            else
                Ksi1 = "";
            }
            catch
            {

            }
        }
        private static void CalculateKsi2()
        {
            try { 
            if (d != "" && D2 != "")
            {
                double _d = Convert.ToDouble(d);
                double _D2 = Convert.ToDouble(D2);
                double ksi2 = Math.Pow((1 - Math.Pow((_d / _D2), 2)), 2);
                Ksi2 = Math.Round(ksi2,3).ToString();
            }
            else
                Ksi2 = "";
            }
            catch
            {

            }
        }  
        private static void CalculateKsiB1()
        {
            try { 
            if (d != "" && D1 != "")
            {
                double _d = Convert.ToDouble(d);
                double _D1 = Convert.ToDouble(D1);
                double ksib1 = 1 - (Math.Pow((_d / _D1), 4));
                KsiB1 = Math.Round(ksib1,3).ToString();
            }
            else
                KsiB1 = "";
            }
            catch
            {

            }
        } 
        private static void CalculateKsiB2()
        {
            try { 
            if (d != "" && D2 != "")
            {
                double _d = Convert.ToDouble(d);
                double _D2 = Convert.ToDouble(D2);
                double ksib2 = 1 - (Math.Pow((_d / _D2), 4));
                KsiB2 = Math.Round(ksib2,3).ToString();
            }
            else
                KsiB2 = "";
            }
            catch
            {

            }
        }
        private static void CalculateKsiI()
        {
            try { 
            if (Ksi1 != "" && KsiB1 != "")
            {
                double _Ksi1 = Convert.ToDouble(Ksi1);
                double _KsiB1 = Convert.ToDouble(KsiB1);
                double _KsiI = _Ksi1 + _KsiB1;
                KsiI = Math.Round(_KsiI,3).ToString();
            }
            else
                KsiI = "";
            }
            catch
            {

            }
        }
        private static void CalculateSigmaKsi()
        {
            try { 
            if (Ksi1 != "" && KsiB1 != "" && KsiB1 != "" && KsiB2 != "")
            {
                double _Ksi1 = Convert.ToDouble(Ksi1);
                double _KsiB1 = Convert.ToDouble(KsiB1);
                double _Ksi2 = Convert.ToDouble(Ksi2);
                double _KsiB2 = Convert.ToDouble(KsiB2);
                double _sigmaKsi = _Ksi1 + _Ksi2 + _KsiB1 - _KsiB2;
                SigmaKsi = Math.Round(_sigmaKsi,3).ToString();
            }
            else
                SigmaKsi = "";
            }
            catch
            {

            }
        }
        private static void CalculateBodySize()
        {
            try { 
            if (d_selected_index != -1)
            {
                d_Unit = "mm";
                switch (d_selected_index)
                {
                    case 0:
                        d = "15";
                        break;
                    case 1:
                        d = "20";
                        break;
                    case 2:
                        d = "25";
                        break;
                    case 3:
                        d = "32";
                        break;
                    case 4:
                        d = "40";
                        break;
                    case 5:
                        d = "50";
                        break;
                    case 6:
                        d = "65";
                        break;
                    case 7:
                        d = "80";
                        break;
                    case 8:
                        d = "100";
                        break;
                    case 9:
                        d = "125";
                        break;
                    case 10:
                        d = "150";
                        break;
                    case 11:
                        d = "200";
                        break;
                    case 12:
                        d = "250";
                        break;
                    case 13:
                        d = "300";
                        break;
                    case 14:
                        d = "350";
                        break;
                    case 15:
                        d = "400";
                        break;
                    case 16:
                        d = "450";
                        break;
                    case 17:
                        d = "500";
                        break;
                    case 18:
                        d = "600";
                        break;
                    case 19:
                        d = "700";
                        break;
                    case 20:
                        d = "800";
                        break;
                    case 21:
                        d = "900";
                        break;
                    case 22:
                        d = "950";
                        break;
                    case 23:
                        d = "1000";
                        break;
                    case 24:
                        d = "1050";
                        break;
                    case 25:
                        d = "1100";
                        break;
                    case 26:
                        d = "1150";
                        break;
                    case 27:
                        d = "1200";
                        break;
                    case 28:
                        d = "1300";
                        break;
                    case 29:
                        d = "1350";
                        break;
                }
            }
            else
            {
                d = D;
                d_Unit = "mm"; 
            }
            }
            catch
            {

            }
        }
        private static void CalculateFl()
        {
            try {      
            switch (TrimTypeIndex)
            {
                case 0: //S-P / TOP
                case 1: //C-B / CAGE
                case 8: //MIXING
                case 9: //DIVERTING
                    {
                        Fl = "0.89";
                        break;
                    }
                case 2: //MULTI HOLE  (1 - STAGE)
                    {
                        Fl = "0.95";
                        break;
                    }
                case 3: //MULTI HOLE  (2 - STAGE)
                case 4: //MULTI HOLE  (MULTI - STAGE)
                case 5: //X[iks]-TRIM  (DISC STACK)
                    {
                        Fl = "1.0";
                        break;
                    }
                case 6: //VANE
                    {
                        Fl = "0.6";
                        break;
                    }
                case 7: //ECCENTRIC BALL
                    {
                        Fl = "0.85";
                        break;
                    }
                default:
                    {
                        Fl = "";
                        break;
                    }
            }
            }
            catch
            {

            }
        } 
        private static void CalculateFlGas()
        {
            try { 
            switch (TrimTypeIndex)
            {
                case 0: //S-P / TOP
                case 1: //C-B / CAGE
                case 8: //MIXING
                case 9: //DIVERTING
                    {
                        Fl = "0.9";
                        break;
                    }
                case 2: //MULTI HOLE  (1 - STAGE)
                    {
                        Fl = "0.95";
                        break;
                    }
                case 3: //MULTI HOLE  (2 - STAGE)
                case 4: //MULTI HOLE  (MULTI - STAGE)
                case 5: //X[iks]-TRIM  (DISC STACK)
                    {
                        Fl = "1.0";
                        break;
                    }
                case 6: //VANE
                    {
                        Fl = "0.6";
                        break;
                    }
                case 7: //ECCENTRIC BALL
                    {
                        Fl = "0.85";
                        break;
                    }
                default:
                    {
                        Fl = "";
                        break;
                    }
            }
            }
            catch
            {

            }
        }  
        private static void CalculateXt()
        {
            try { 
            switch (TrimTypeIndex)
            {
                case 0: //S-P / TOP
                case 1: //C-B / CAGE
                case 8: //MIXING
                case 9: //DIVERTING
                    {
                        Xt = "0.75";
                        break;
                    }
                case 2: //MULTI HOLE  (1 - STAGE)
                    {
                        Xt = "0.78";
                        break;
                    }
                case 3: //MULTI HOLE  (2 - STAGE)
                    {
                        Xt = "0.95";
                        break;
                    }
                case 4: //MULTI HOLE  (MULTI - STAGE)
                case 5: //X[iks]-TRIM  (DISC STACK)
                    {
                        Xt = "1.0";
                        break;
                    }
                case 6: //VANE
                    {
                        Xt = "0.25";
                        break;
                    }
                case 7: //ECCENTRIC BALL
                    {
                        Xt = "0.65";
                        break;
                    }
                default:
                    {
                        Xt = "";
                        break;
                    }
            }
            }
            catch
            {

            }
        }
        private static void CalculateN2()
        {
            try { 
            if (d_Unit != "")
            {
                if (d_Unit == "mm")
                    N2 = "0.00214";
                else
                    N2 = "890";
            }
            else
                N2 = "";
            }
            catch
            {

            }
        }   
        private static void CalculateN1()
        {            
            N1 = "0.0865";   //Q = m3/hr   P = Kpa
        } 
        private static void CalculateN6()
        {
           // if (Q_Unit == "kg/hr" && P_Unit == "kPa a")
                N6 = "3.16";
           // if (Q_Unit == "kg/hr" && P_Unit == "bara")
           //     N6 = "0.316";           

        }
        private static void CalculateFlp()
        {
            try { 
            if (Fl != "" && N2 != "" && Cv_Rated != "" && d != "" && KsiI != "")
            {
                double part1 = Math.Pow(Convert.ToDouble(Fl), 2) / Convert.ToDouble(N2);
                double part2 = Math.Pow((Convert.ToDouble(Cv_Rated) / Math.Pow(Convert.ToDouble(d), 2)), 2);
                double flp = Convert.ToDouble(Fl) / Math.Sqrt(1 + part1 * Convert.ToDouble(KsiI) * part2);
                Flp = Math.Round(flp,3).ToString();
            }
            else
                Flp = "";
            }
            catch
            {

            }
        } 
        private static void CalculateFp()
        {
            try { 
            if (N2 != "" && Cv_Rated != "" && d != "" && SigmaKsi != "")
            {
                double part1 = Convert.ToDouble(SigmaKsi) / Convert.ToDouble(N2);
                double part2 = Math.Pow((Convert.ToDouble(Cv_Rated) / Math.Pow(Convert.ToDouble(d), 2)), 2);
                double fp = 1 / Math.Sqrt(1 + part1 * part2);
                Fp = Math.Round(fp,3).ToString();
            }
            else
                Fp = "";
            }
            catch
            {

            }
        }
        private static void CalculateDelteChoked()
        {
            try { 
            if (Flp != "" && Fp != "" && P1_Min != "" && Ff_Min != "" && Pv_Min != "")
            {
                double d_min = Math.Pow((Convert.ToDouble(Flp) / Convert.ToDouble(Fp)), 2) * (Convert.ToDouble(P1_Min) - (Convert.ToDouble(Ff_Min) * Convert.ToDouble(Pv_Min)));
                Delta_P_Min_Choked = Math.Round(d_min,3).ToString();
            }
            else
                Delta_P_Min_Choked = "";

            if (Flp != "" && Fp != "" && P1_Norm != "" && Ff_Norm != "" && Pv_Norm != "")
            {
                double d_norm = Math.Pow((Convert.ToDouble(Flp) / Convert.ToDouble(Fp)), 2) * (Convert.ToDouble(P1_Norm) - (Convert.ToDouble(Ff_Norm) * Convert.ToDouble(Pv_Norm)));
                Delta_P_Norm_Choked = Math.Round(d_norm,3).ToString();
            }
            else
                Delta_P_Norm_Choked = "";

            if (Flp != "" && Fp != "" && P1_Max != "" && Ff_Max != "" && Pv_Max != "")
            {
                double d_max = Math.Pow((Convert.ToDouble(Flp) / Convert.ToDouble(Fp)), 2) * (Convert.ToDouble(P1_Max) - (Convert.ToDouble(Ff_Max) * Convert.ToDouble(Pv_Max)));
                Delta_P_Max_Choked = Math.Round(d_max,3).ToString();
            }
            else
                Delta_P_Max_Choked = "";

            if (Flp != "" && Fp != "" && P1_Case1 != "" && Ff_Case1 != "" && Pv_Case1 != "")
            {
                double d_case1 = Math.Pow((Convert.ToDouble(Flp) / Convert.ToDouble(Fp)), 2) * (Convert.ToDouble(P1_Case1) - (Convert.ToDouble(Ff_Case1) * Convert.ToDouble(Pv_Case1)));
                Delta_P_Case1_Choked = Math.Round(d_case1,3).ToString();
            }
            else
                Delta_P_Case1_Choked = "";

            if (Flp != "" && Fp != "" && P1_Case1 != "" && Ff_Case2 != "" && Pv_Case2 != "")
            {
                double d_case2 = Math.Pow((Convert.ToDouble(Flp) / Convert.ToDouble(Fp)), 2) * (Convert.ToDouble(P1_Case2) - (Convert.ToDouble(Ff_Case2) * Convert.ToDouble(Pv_Case2)));
                Delta_P_Case2_Choked = Math.Round(d_case2,3).ToString();
            }
            else
                Delta_P_Case2_Choked = "";
            }
            catch
            {

            }
        }
        private static void CalculateDeltaSizing()
        {
            try { 
            if (Delta_P_Norm_Choked != "" && Delta_P_Norm != "")
            {
                if (Convert.ToDouble(Delta_P_Norm) < Convert.ToDouble(Delta_P_Norm_Choked))
                    Delta_P_Norm_Sizing = Delta_P_Norm;
                else
                    Delta_P_Norm_Sizing = Delta_P_Norm_Choked;
            }
            else
                Delta_P_Norm_Sizing = "";

            if (Delta_P_Min_Choked != "" && Delta_P_Min != "")
            {
                if (Convert.ToDouble(Delta_P_Min) < Convert.ToDouble(Delta_P_Min_Choked))
                    Delta_P_Min_Sizing = Delta_P_Min;
                else
                    Delta_P_Min_Sizing = Delta_P_Min_Choked;
            }
            else
                Delta_P_Min_Sizing = "";

            if (Delta_P_Max_Choked != "" && Delta_P_Max != "")
            {
                if (Convert.ToDouble(Delta_P_Max) < Convert.ToDouble(Delta_P_Max_Choked))
                    Delta_P_Max_Sizing = Delta_P_Max;
                else
                    Delta_P_Max_Sizing = Delta_P_Max_Choked;
            }
            else
                Delta_P_Max_Sizing = "";

            if (Delta_P_Case1_Choked != "" && Delta_P_Case1 != "")
            {
                if (Convert.ToDouble(Delta_P_Case1) < Convert.ToDouble(Delta_P_Case1_Choked))
                    Delta_P_Case1_Sizing = Delta_P_Case1;
                else
                    Delta_P_Case1_Sizing = Delta_P_Case1_Choked;
            }
            else
                Delta_P_Case1_Sizing = "";

            if (Delta_P_Case2_Choked != "" && Delta_P_Case2 != "")
            {
                if (Convert.ToDouble(Delta_P_Case2) < Convert.ToDouble(Delta_P_Case2_Choked))
                    Delta_P_Case2_Sizing = Delta_P_Case2;
                else
                    Delta_P_Case2_Sizing = Delta_P_Case2_Choked;
            }
            else
                Delta_P_Case2_Sizing = "";
            }
            catch
            {

            }
        }
        private static void CalculateCvReal()
        {
            try { 
            if (Q_Min != "" && SG_Min != "" && N1 != "" && Delta_P_Min_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Min), Q_Unit, "m³/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Min) / Convert.ToDouble(Delta_P_Min_Sizing))) / (Convert.ToDouble(N1) * Convert.ToDouble(Fp));
                Cv_Real_Min = Math.Round(cv,3).ToString(); 
            }
            else
                Cv_Real_Min = "";

            if (Q_Norm != "" && SG_Norm != "" && N1 != "" && Delta_P_Norm_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Norm), Q_Unit, "m³/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Norm) / Convert.ToDouble(Delta_P_Norm_Sizing))) / (Convert.ToDouble(N1) * Convert.ToDouble(Fp));
                Cv_Real_Norm = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Norm = "";

            if (Q_Max != "" && SG_Max != "" && N1 != "" && Delta_P_Max_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Max), Q_Unit, "m³/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Max) / Convert.ToDouble(Delta_P_Max_Sizing))) / (Convert.ToDouble(N1) * Convert.ToDouble(Fp));
                Cv_Real_Max = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Max = "";

            if (Q_Case1 != "" && SG_Case1 != "" && N1 != "" && Delta_P_Case1_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Case1), Q_Unit, "m³/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Case1) / Convert.ToDouble(Delta_P_Case1_Sizing))) / (Convert.ToDouble(N1) * Convert.ToDouble(Fp));
                Cv_Real_Case1 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case1 = "";

            if (Q_Case2 != "" && SG_Case2 != "" && N1 != "" && Delta_P_Case2_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Case2), Q_Unit, "m³/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Case2) / Convert.ToDouble(Delta_P_Case2_Sizing))) / (Convert.ToDouble(N1) * Convert.ToDouble(Fp));
                Cv_Real_Case2 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case2 = "";
            }
            catch
            {

            }
        } 
        private static void CalculateCvRealLiquidMass()
        {
            try { 
            if (Q_Min != "" && SG_Min != "" && N6 != "" && Delta_P_Min_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Min), Q_Unit, "kg/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Min) / Convert.ToDouble(Delta_P_Min_Sizing))) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp));
                Cv_Real_Min = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Min = "";

            if (Q_Norm != "" && SG_Norm != "" && N6 != "" && Delta_P_Norm_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Norm), Q_Unit, "kg/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Norm) / Convert.ToDouble(Delta_P_Norm_Sizing))) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp));
                Cv_Real_Norm = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Norm = "";

            if (Q_Max != "" && SG_Max != "" && N6 != "" && Delta_P_Max_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Max), Q_Unit, "kg/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Max) / Convert.ToDouble(Delta_P_Max_Sizing))) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp));
                Cv_Real_Max = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Max = "";

            if (Q_Case1 != "" && SG_Case1 != "" && N6 != "" && Delta_P_Case1_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Case1), Q_Unit, "kg/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Case1) / Convert.ToDouble(Delta_P_Case1_Sizing))) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp));
                Cv_Real_Case1 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case1 = "";

            if (Q_Case2 != "" && SG_Case2 != "" && N6 != "" && Delta_P_Case2_Sizing != "" && Fp != "")
            {
                decimal q = BL.ConvertUnit(Convert.ToDecimal(Q_Case2), Q_Unit, "kg/hr");
                double cv = (Convert.ToDouble(q) * Math.Sqrt(Convert.ToDouble(SG_Case2) / Convert.ToDouble(Delta_P_Case2_Sizing))) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp));
                Cv_Real_Case2 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case2 = "";
            }
            catch
            {

            }
        }
        private static void CalculateCvReal_GasMass_MW()
        {
            try { 
            if (Q_Min != "" && SG_Min != "" && N8 != "" && Xsixing_Min != "" && Fp != "" && T_Min != "" && Z_Min != "" && P1_Min != "" && Mu_Min != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Min), Q_Unit, "kg/hr");
                decimal t = BL.ConvertTempToKelvin(T_Min, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Min)) / (Convert.ToDouble(Xsixing_Min) * Convert.ToDouble(SG_Min)));
                double cv = (Convert.ToDouble(w) * part1) / (Convert.ToDouble(N8) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Min) * Convert.ToDouble(Mu_Min));
                Cv_Real_Min = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Min = "";

            if (Q_Norm != "" && SG_Norm != "" && N8 != "" && Xsixing_Norm != "" && Fp != "" && T_Norm != "" && Z_Norm != "" && P1_Norm != "" && Mu_Norm != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Norm), Q_Unit, "kg/hr");
                decimal t = BL.ConvertTempToKelvin(T_Norm, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Norm)) / (Convert.ToDouble(Xsixing_Norm) * Convert.ToDouble(SG_Norm)));
                double cv = (Convert.ToDouble(w) * part1) / (Convert.ToDouble(N8) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Norm) * Convert.ToDouble(Mu_Norm));
                Cv_Real_Norm = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Norm = "";

            if (Q_Max != "" && SG_Max != "" && N8 != "" && Xsixing_Max != "" && Fp != "" && T_Max != "" && Z_Max != "" && P1_Max != "" && Mu_Max != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Max), Q_Unit, "kg/hr");
                decimal t = BL.ConvertTempToKelvin(T_Max, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Max)) / (Convert.ToDouble(Xsixing_Max) * Convert.ToDouble(SG_Max)));
                double cv = (Convert.ToDouble(w) * part1) / (Convert.ToDouble(N8) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Max) * Convert.ToDouble(Mu_Max));
                Cv_Real_Max = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Max = "";

            if (Q_Case1 != "" && SG_Case1 != "" && N8 != "" && Xsixing_Case1 != "" && Fp != "" && T_Case1 != "" && Z_Case1 != "" && P1_Case1 != "" && Mu_Case1 != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Case1), Q_Unit, "kg/hr");
                decimal t = BL.ConvertTempToKelvin(T_Case1, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Case1)) / (Convert.ToDouble(Xsixing_Case1) * Convert.ToDouble(SG_Case1)));
                double cv = (Convert.ToDouble(w) * part1) / (Convert.ToDouble(N8) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Case1) * Convert.ToDouble(Mu_Case1));
                Cv_Real_Case1 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case1 = "";

            if (Q_Case2 != "" && SG_Case2 != "" && N8 != "" && Xsixing_Case2 != "" && Fp != "" && T_Case2 != "" && Z_Case2 != "" && P1_Case2 != "" && Mu_Case2 != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Case2), Q_Unit, "kg/hr");
                decimal t = BL.ConvertTempToKelvin(T_Case2, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Case2)) / (Convert.ToDouble(Xsixing_Case2) * Convert.ToDouble(SG_Case2)));
                double cv = (Convert.ToDouble(w) * part1) / (Convert.ToDouble(N8) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Case2) * Convert.ToDouble(Mu_Case2));
                Cv_Real_Case2 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case2 = "";
            }
            catch
            {

            }


        }
        private static void CalculateCvReal_GasMass_Density()
        {
            try { 
            if (Q_Min != "" && SG_Min != "" && N6 != "" && Xsixing_Min != "" && Fp != "" && P1_Min != "" && Mu_Min != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Min), Q_Unit, "kg/hr");
               
                double part1 = Math.Sqrt(Convert.ToDouble(Xsixing_Min) * Convert.ToDouble(SG_Min) * Convert.ToDouble(P1_Min));
                double cv = Convert.ToDouble(w)  / (Convert.ToDouble(N6) * Convert.ToDouble(Fp) * part1 * Convert.ToDouble(Mu_Min));
                Cv_Real_Min = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Min = "";

            if (Q_Norm != "" && SG_Norm != "" && N6 != "" && Xsixing_Norm != "" && Fp != "" && P1_Norm != "" && Mu_Norm != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Norm), Q_Unit, "kg/hr");

                double part1 = Math.Sqrt(Convert.ToDouble(Xsixing_Norm) * Convert.ToDouble(SG_Norm) * Convert.ToDouble(P1_Norm));
                double cv = Convert.ToDouble(w) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp) * part1 * Convert.ToDouble(Mu_Norm));
                Cv_Real_Norm = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Norm = "";

            if (Q_Max != "" && SG_Max != "" && N6 != "" && Xsixing_Max != "" && Fp != "" && P1_Max != "" && Mu_Max != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Max), Q_Unit, "kg/hr");

                double part1 = Math.Sqrt(Convert.ToDouble(Xsixing_Max) * Convert.ToDouble(SG_Max) * Convert.ToDouble(P1_Max));
                double cv = Convert.ToDouble(w) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp) * part1 * Convert.ToDouble(Mu_Max));
                Cv_Real_Max = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Max = "";

            if (Q_Case1 != "" && SG_Case1 != "" && N6 != "" && Xsixing_Case1 != "" && Fp != "" && P1_Case1 != "" && Mu_Case1 != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Case1), Q_Unit, "kg/hr");

                double part1 = Math.Sqrt(Convert.ToDouble(Xsixing_Case1) * Convert.ToDouble(SG_Case1) * Convert.ToDouble(P1_Case1));
                double cv = Convert.ToDouble(w) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp) * part1 * Convert.ToDouble(Mu_Case1));
                Cv_Real_Case1 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case1 = "";

            if (Q_Case2 != "" && SG_Case2 != "" && N6 != "" && Xsixing_Case2 != "" && Fp != "" && P1_Case2 != "" && Mu_Case2 != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Case2), Q_Unit, "kg/hr");

                double part1 = Math.Sqrt(Convert.ToDouble(Xsixing_Case2) * Convert.ToDouble(SG_Case2) * Convert.ToDouble(P1_Case2));
                double cv = Convert.ToDouble(w) / (Convert.ToDouble(N6) * Convert.ToDouble(Fp) * part1 * Convert.ToDouble(Mu_Case2));
                Cv_Real_Case2 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case2 = "";
            }
            catch
            {

            }
        }  
        private static void CalculateFminuscule()
        {
            try { 
            if (Pv_Min != "")
            {
                double f_minuscule = Convert.ToDouble(Pv_Min) / 1.4;
                F_Minuscule_Min = Math.Round(f_minuscule, 3).ToString();
            }
            else
                F_Minuscule_Min = "";

            if (Pv_Norm != "")
            {
                double f_minuscule = Convert.ToDouble(Pv_Norm) / 1.4;
                F_Minuscule_Norm = Math.Round(f_minuscule, 3).ToString();
            }
            else
                F_Minuscule_Norm = "";

            if (Pv_Max != "")
            {
                double f_minuscule = Convert.ToDouble(Pv_Max) / 1.4;
                F_Minuscule_Max = Math.Round(f_minuscule, 3).ToString();
            }
            else
                F_Minuscule_Max = "";

            if (Pv_Case1 != "")
            {
                double f_minuscule = Convert.ToDouble(Pv_Case1) / 1.4;
                F_Minuscule_Case1 = Math.Round(f_minuscule, 3).ToString();
            }
            else
                F_Minuscule_Case1 = "";

            if (Pv_Case2 != "")
            {
                double f_minuscule = Convert.ToDouble(Pv_Case2) / 1.4;
                F_Minuscule_Case2 = Math.Round(f_minuscule, 3).ToString();
            }
            else
                F_Minuscule_Case2 = "";
            }
            catch
            {

            }
        } 
        private static void CalculateX()
        {
            try { 
            if (P1_Min != "" && P2_Min != "")
            {
                double x = (Convert.ToDouble(P1_Min) - Convert.ToDouble(P2_Min)) / Convert.ToDouble(P1_Min);
                X_Min = Math.Round(x, 3).ToString();
            }
            else
                X_Min = "";

            if (P1_Norm != "" && P2_Norm != "")
            {
                double x = (Convert.ToDouble(P1_Norm) - Convert.ToDouble(P2_Norm)) / Convert.ToDouble(P1_Norm);
                X_Norm = Math.Round(x, 3).ToString();
            }
            else
                X_Norm = "";

            if (P1_Max != "" && P2_Max != "")
            {
                double x = (Convert.ToDouble(P1_Max) - Convert.ToDouble(P2_Max)) / Convert.ToDouble(P1_Max);
                X_Max = Math.Round(x, 3).ToString();
            }
            else
                X_Max = "";

            if (P1_Case2 != "" && P2_Case2 != "")
            {
                double x = (Convert.ToDouble(P1_Case2) - Convert.ToDouble(P2_Case2)) / Convert.ToDouble(P1_Case2);
                X_Case2 = Math.Round(x, 3).ToString();
            }
            else
                X_Case2 = "";

            if (P1_Case1 != "" && P2_Case1 != "")
            {
                double x = (Convert.ToDouble(P1_Case1) - Convert.ToDouble(P2_Case1)) / Convert.ToDouble(P1_Case1);
                X_Case1 = Math.Round(x, 3).ToString();
            }
            else
                X_Case1 = "";
            }
            catch
            {

            }

        }
        private static void CalculateXchoked()
        {
            try { 
            if (F_Minuscule_Min != "" && Xtp != "")
            {
                double x = Convert.ToDouble(F_Minuscule_Min) * Convert.ToDouble(Xtp);
                Xchoked_Min = Math.Round(x, 3).ToString();
            }
            else
                Xchoked_Min = "";

            if (F_Minuscule_Norm != "" && Xtp != "")
            {
                double x = Convert.ToDouble(F_Minuscule_Norm) * Convert.ToDouble(Xtp);
                Xchoked_Norm = Math.Round(x, 3).ToString();
            }
            else
                Xchoked_Norm = "";

            if (F_Minuscule_Max != "" && Xtp != "")
            {
                double x = Convert.ToDouble(F_Minuscule_Max) * Convert.ToDouble(Xtp);
                Xchoked_Max = Math.Round(x, 3).ToString();
            }
            else
                Xchoked_Max = "";


            if (F_Minuscule_Case1 != "" && Xtp != "")
            {
                double x = Convert.ToDouble(F_Minuscule_Case1) * Convert.ToDouble(Xtp);
                Xchoked_Case1 = Math.Round(x, 3).ToString();
            }
            else
                Xchoked_Case1 = "";


            if (F_Minuscule_Case2 != "" && Xtp != "")
            {
                double x = Convert.ToDouble(F_Minuscule_Case2) * Convert.ToDouble(Xtp);
                Xchoked_Case2 = Math.Round(x, 3).ToString();
            }
            else
                Xchoked_Case2 = "";
            }
            catch
            {

            }

        }
        private static void CalculateXsizing()
        {
            try { 
            if (X_Min != "" && Xchoked_Min != "")
            {
                if (Convert.ToDouble(X_Min) < Convert.ToDouble(Xchoked_Min))
                    Xsixing_Min = X_Min;
                else
                    Xsixing_Min = Xchoked_Min;
            }
            else
                Xsixing_Min = "";

            if (X_Norm != "" && Xchoked_Norm != "")
            {
                if (Convert.ToDouble(X_Norm) < Convert.ToDouble(Xchoked_Norm))
                    Xsixing_Norm = X_Norm;
                else
                    Xsixing_Norm = Xchoked_Norm;
            }
            else
                Xsixing_Norm = "";

            if (X_Max != "" && Xchoked_Max != "")
            {
                if (Convert.ToDouble(X_Max) < Convert.ToDouble(Xchoked_Max))
                    Xsixing_Max = X_Max;
                else
                    Xsixing_Max = Xchoked_Max;
            }
            else
                Xsixing_Max = "";

            if (X_Case1 != "" && Xchoked_Case1 != "")
            {
                if (Convert.ToDouble(X_Case1) < Convert.ToDouble(Xchoked_Case1))
                    Xsixing_Case1 = X_Case1;
                else
                    Xsixing_Case1 = Xchoked_Case1;
            }
            else
                Xsixing_Case1 = "";

            if (X_Case2 != "" && Xchoked_Case2 != "")
            {
                if (Convert.ToDouble(X_Case2) < Convert.ToDouble(Xchoked_Case2))
                    Xsixing_Case2 = X_Case2;
                else
                    Xsixing_Case2 = Xchoked_Case2;
            }
            else
                Xsixing_Case2 = "";
            }
            catch
            {

            }
        }
        private static void CalculateXtp()
        {
            try { 
            if (Xt != "" && Fp != "" && KsiI != "" && N5 != "" && Cv_Rated != "" && d != "")
            {
                double xt = Convert.ToDouble(Xt);
                double fp = Convert.ToDouble(Fp);
                double ksii = Convert.ToDouble(KsiI);
                double n5 = Convert.ToDouble(N5);
                double c = Convert.ToDouble(Cv_Rated);
                double _d = Convert.ToDouble(d);
                double xtp = (xt / Math.Pow(fp, 2)) / (1 + (((xt * ksii) / n5) * Math.Pow((c / Math.Pow(_d, 2)), 2)));
                Xtp = Math.Round(xtp, 3).ToString();
            }
            else
                Xtp = "";
            }
            catch
            {

            }

        }
        private static void SetLiquidVolometricSymbolList()
        {
            try { 
            Program.SymbolList.Add(new Symbols("P₁", P1_Min, P1_Norm,P1_Max, P1_Case1, P1_Case2,P_Unit, P1_Description));
            Program.SymbolList.Add(new Symbols("P₂", P2_Min, P2_Norm,P2_Max, P2_Case1, P2_Case2, P_Unit, P2_Description));
            Program.SymbolList.Add(new Symbols("∆P actual", Delta_P_Min, Delta_P_Norm,Delta_P_Max, Delta_P_Case1, Delta_P_Case2, Delta_P_Unit, Delta_P_Actual_Description));
            Program.SymbolList.Add(new Symbols("∆P choked", Delta_P_Min_Choked, Delta_P_Norm_Choked, Delta_P_Max_Choked, Delta_P_Case1_Choked, Delta_P_Case2_Choked, Delta_P_Unit, Delta_P_Choked_Description));
            Program.SymbolList.Add(new Symbols("∆P sizing", Delta_P_Min_Sizing, Delta_P_Norm_Sizing, Delta_P_Max_Sizing, Delta_P_Case1_Sizing, Delta_P_Case2_Sizing, Delta_P_Unit, Delta_P_Sizing_Description));

            Program.SymbolList.Add(new Symbols("Q", Q_Min, Q_Norm, Q_Max, Q_Case1, Q_Case2, Q_Unit, Q_Description));
            Program.SymbolList.Add(new Symbols("<html>P<b>ᴄ</b>", Pc_Min, Pc_Norm,Pc_Max, Pc_Case1, Pc_Case2, Pc_Unit, Pc_Description));
            Program.SymbolList.Add(new Symbols("<html>P<b>ѵ</b>", Pv_Min, Pv_Norm, Pv_Max, Pv_Case1, Pv_Case2, Pv_Unit, Pv_Description));
            Program.SymbolList.Add(new Symbols("<html>F<b>F</b>", Ff_Min, Ff_Norm, Ff_Max, Ff_Case1, Ff_Case2, "", Ff_Description));
            Program.SymbolList.Add(new Symbols("FL", Fl, Fl, Fl, Fl, Fl, "", Fl_Description));
            Program.SymbolList.Add(new Symbols("D₁", D1, D1, D1, D1, D1, D1_Unit, D1_Description));
            Program.SymbolList.Add(new Symbols("D₂", D2, D2, D2, D2, D2, D2_Unit, D2_Description));
            Program.SymbolList.Add(new Symbols("d", d, d, d, d, d, d_Unit, d_Description));
            Program.SymbolList.Add(new Symbols("ξ₁", Ksi1, Ksi1, Ksi1, Ksi1, Ksi1, "", Ksi1_Description));
            Program.SymbolList.Add(new Symbols("ξ₂", Ksi2, Ksi2, Ksi2, Ksi2, Ksi2, "", Ksi2_Description));
            Program.SymbolList.Add(new Symbols("ξB₁", KsiB1, KsiB1, KsiB1, KsiB1, KsiB1, "", KsiB1_Description));
            Program.SymbolList.Add(new Symbols("ξB₂", KsiB2, KsiB2, KsiB2, KsiB2, KsiB2, "", KsiB2_Description));
            Program.SymbolList.Add(new Symbols("ξᵢ", KsiI, KsiI, KsiI, KsiI, KsiI, "", KsiI_Description));
            Program.SymbolList.Add(new Symbols("Σξ", SigmaKsi, SigmaKsi, SigmaKsi, SigmaKsi, SigmaKsi, "", SigmaKsi_Description));
            Program.SymbolList.Add(new Symbols("N₂", N2, N2, N2, N2, N2, "", N_Description));
            Program.SymbolList.Add(new Symbols("Cv Rated", Cv_Rated, Cv_Rated, Cv_Rated, Cv_Rated, Cv_Rated, "", ""));
            Program.SymbolList.Add(new Symbols("N₁", N1, N1, N1, N1, N1, "", N_Description));
            Program.SymbolList.Add(new Symbols("FLP", Flp, Flp, Flp, Flp, Flp, "", Flp_Description));
            Program.SymbolList.Add(new Symbols("Fp", Fp, Fp, Fp, Fp, Fp, "", Fp_Description));
            Program.SymbolList.Add(new Symbols("ρ₁/ρ₀", SG_Min, SG_Norm, SG_Max, SG_Case1, SG_Case2, "", SG_Description));
            Program.SymbolList.Add(new Symbols("Cv", Cv_Real_Min, Cv_Real_Norm, Cv_Real_Max, Cv_Real_Case1, Cv_Real_Case2, "", C_Description));
            }
            catch
            {

            }
        }   
        private static void SetLiquidMassSymbolList()
        {
            try { 
            Program.SymbolList.Add(new Symbols("P₁", P1_Min, P1_Norm, P1_Max, P1_Case1, P1_Case2, P_Unit, P1_Description));
            Program.SymbolList.Add(new Symbols("P₂", P2_Min, P2_Norm, P2_Max, P2_Case1, P2_Case2, P_Unit, P2_Description));
            Program.SymbolList.Add(new Symbols("∆P actual", Delta_P_Min, Delta_P_Norm, Delta_P_Max, Delta_P_Case1, Delta_P_Case2, Delta_P_Unit, Delta_P_Actual_Description));
            Program.SymbolList.Add(new Symbols("∆P choked", Delta_P_Min_Choked, Delta_P_Norm_Choked, Delta_P_Max_Choked, Delta_P_Case1_Choked, Delta_P_Case2_Choked, Delta_P_Unit, Delta_P_Choked_Description));
            Program.SymbolList.Add(new Symbols("∆P sizing", Delta_P_Min_Sizing, Delta_P_Norm_Sizing, Delta_P_Max_Sizing, Delta_P_Case1_Sizing, Delta_P_Case2_Sizing, Delta_P_Unit, Delta_P_Sizing_Description));

            Program.SymbolList.Add(new Symbols("W", Q_Min, Q_Norm, Q_Max, Q_Case1, Q_Case2, Q_Unit, W_Description));
            Program.SymbolList.Add(new Symbols("<html>P<b>ᴄ</b>", Pc_Min, Pc_Norm, Pc_Max, Pc_Case1, Pc_Case2, Pc_Unit, Pc_Description));
            Program.SymbolList.Add(new Symbols("<html>P<b>ѵ</b>", Pv_Min, Pv_Norm, Pv_Max, Pv_Case1, Pv_Case2, Pv_Unit, Pv_Description));
            Program.SymbolList.Add(new Symbols("<html>F<b>F</b>", Ff_Min, Ff_Norm, Ff_Max, Ff_Case1, Ff_Case2, "", Ff_Description));
            Program.SymbolList.Add(new Symbols("FL", Fl, Fl, Fl, Fl, Fl, "", Fl_Description));
            Program.SymbolList.Add(new Symbols("D₁", D1, D1, D1, D1, D1, D1_Unit, D1_Description));
            Program.SymbolList.Add(new Symbols("D₂", D2, D2, D2, D2, D2, D2_Unit, D2_Description));
            Program.SymbolList.Add(new Symbols("d", d, d, d, d, d, d_Unit, d_Description));
            Program.SymbolList.Add(new Symbols("ξ₁", Ksi1, Ksi1, Ksi1, Ksi1, Ksi1, "", Ksi1_Description));
            Program.SymbolList.Add(new Symbols("ξ₂", Ksi2, Ksi2, Ksi2, Ksi2, Ksi2, "", Ksi2_Description));
            Program.SymbolList.Add(new Symbols("ξB₁", KsiB1, KsiB1, KsiB1, KsiB1, KsiB1, "", KsiB1_Description));
            Program.SymbolList.Add(new Symbols("ξB₂", KsiB2, KsiB2, KsiB2, KsiB2, KsiB2, "", KsiB2_Description));
            Program.SymbolList.Add(new Symbols("ξᵢ", KsiI, KsiI, KsiI, KsiI, KsiI, "", KsiI_Description));
            Program.SymbolList.Add(new Symbols("Σξ", SigmaKsi, SigmaKsi, SigmaKsi, SigmaKsi, SigmaKsi, "", SigmaKsi_Description));
            Program.SymbolList.Add(new Symbols("N₂", N2, N2, N2, N2, N2, "", N_Description));
            Program.SymbolList.Add(new Symbols("N₆", N6, N6, N6, N6, N6, "", N_Description));
            Program.SymbolList.Add(new Symbols("Cv Rated", Cv_Rated, Cv_Rated, Cv_Rated, Cv_Rated, Cv_Rated, "", ""));
            Program.SymbolList.Add(new Symbols("N₁", N1, N1, N1, N1, N1, "", N_Description));
            Program.SymbolList.Add(new Symbols("FLP", Flp, Flp, Flp, Flp, Flp, "", Flp_Description));
            Program.SymbolList.Add(new Symbols("Fp", Fp, Fp, Fp, Fp, Fp, "", Fp_Description));
            Program.SymbolList.Add(new Symbols("ρ₁/ρ₀", SG_Min, SG_Norm, SG_Max, SG_Case1, SG_Case2, "", SG_Description));
            Program.SymbolList.Add(new Symbols("Cv", Cv_Real_Min, Cv_Real_Norm, Cv_Real_Max, Cv_Real_Case1, Cv_Real_Case2, "", C_Description));
            }
            catch
            {

            }
        }   
        private static void SetGasMassMWSymbolList()
        {
            try { 
            Program.SymbolList.Add(new Symbols("P₁", P1_Min, P1_Norm, P1_Max, P1_Case1, P1_Case2, P_Unit, P1_Description));
            Program.SymbolList.Add(new Symbols("P₂", P2_Min, P2_Norm, P2_Max, P2_Case1, P2_Case2, P_Unit, P2_Description));
            Program.SymbolList.Add(new Symbols("∆P actual", Delta_P_Min, Delta_P_Norm, Delta_P_Max, Delta_P_Case1, Delta_P_Case2, Delta_P_Unit, Delta_P_Actual_Description));
            Program.SymbolList.Add(new Symbols("X choked", Xchoked_Min, Xchoked_Norm, Xchoked_Max, Xchoked_Case1, Xchoked_Case2, "", Xchoked_Description));
            Program.SymbolList.Add(new Symbols("X sizing", Xsixing_Min, Xsixing_Norm, Xsixing_Max, Xsixing_Case1, Xsixing_Case2, "", Xsizing_Description));
            Program.SymbolList.Add(new Symbols("W input", Q_Min, Q_Norm, Q_Max, Q_Case1, Q_Case2, Q_Unit, W_Description));
            Program.SymbolList.Add(new Symbols("W", W_Min_Convert, W_Norm_Convert, W_Max_Convert, W_Case1_Convert, W_Case2_Convert, "kg/hr", W_Description));                      
            Program.SymbolList.Add(new Symbols("<html>P<b>ѵ</b>", Pv_Min, Pv_Norm, Pv_Max, Pv_Case1, Pv_Case2, Pv_Unit, Pv_Description));
            Program.SymbolList.Add(new Symbols("<html>F<b>F</b>", Ff_Min, Ff_Norm, Ff_Max, Ff_Case1, Ff_Case2, "", Ff_Description));
            Program.SymbolList.Add(new Symbols("FL", Fl, Fl, Fl, Fl, Fl, "", Fl_Description));
            Program.SymbolList.Add(new Symbols("D₁", D1, D1, D1, D1, D1, D1_Unit, D1_Description));
            Program.SymbolList.Add(new Symbols("D₂", D2, D2, D2, D2, D2, D2_Unit, D2_Description));
            Program.SymbolList.Add(new Symbols("d", d, d, d, d, d, d_Unit, d_Description));
            Program.SymbolList.Add(new Symbols("ξ₁", Ksi1, Ksi1, Ksi1, Ksi1, Ksi1, "", Ksi1_Description));
            Program.SymbolList.Add(new Symbols("ξ₂", Ksi2, Ksi2, Ksi2, Ksi2, Ksi2, "", Ksi2_Description));
            Program.SymbolList.Add(new Symbols("ξB₁", KsiB1, KsiB1, KsiB1, KsiB1, KsiB1, "", KsiB1_Description));
            Program.SymbolList.Add(new Symbols("ξB₂", KsiB2, KsiB2, KsiB2, KsiB2, KsiB2, "", KsiB2_Description));
            Program.SymbolList.Add(new Symbols("ξᵢ", KsiI, KsiI, KsiI, KsiI, KsiI, "", KsiI_Description));
            Program.SymbolList.Add(new Symbols("Σξ", SigmaKsi, SigmaKsi, SigmaKsi, SigmaKsi, SigmaKsi, "", SigmaKsi_Description));
            Program.SymbolList.Add(new Symbols("N₈", N8, N8, N8, N8, N8, "", N_Description));
            Program.SymbolList.Add(new Symbols("N₆", N6, N6, N6, N6, N6, "", N_Description));
            Program.SymbolList.Add(new Symbols("Cv Rated", Cv_Rated, Cv_Rated, Cv_Rated, Cv_Rated, Cv_Rated, "", ""));
            Program.SymbolList.Add(new Symbols("N₅", N5, N5, N5, N5, N5, "", N_Description));
            Program.SymbolList.Add(new Symbols("X", X_Min, X_Norm, X_Max, X_Case1, X_Case2, "", X_Description));
            Program.SymbolList.Add(new Symbols("XT", Xt, Xt, Xt, Xt, Xt, "", Xt_Description));
            Program.SymbolList.Add(new Symbols("XTP", Xtp, Xtp, Xtp, Xtp, Xtp, "", Xtp_Description));
            Program.SymbolList.Add(new Symbols("FƳ", F_Minuscule_Min, F_Minuscule_Norm, F_Minuscule_Max, F_Minuscule_Case1, F_Minuscule_Case2, "", F_Minuscule_Description));
            Program.SymbolList.Add(new Symbols("Fp", Fp, Fp, Fp, Fp, Fp, "", Fp_Description));
            Program.SymbolList.Add(new Symbols("μ", Mu_Min, Mu_Norm, Mu_Max, Mu_Case1, Mu_Case2, "", Mu_Description));
            Program.SymbolList.Add(new Symbols("M", SG_Min, SG_Norm, SG_Max, SG_Case1, SG_Case2, "", M_Description));
            Program.SymbolList.Add(new Symbols("Cv", Cv_Real_Min, Cv_Real_Norm, Cv_Real_Max, Cv_Real_Case1, Cv_Real_Case2, "", C_Description));
            }
            catch
            {

            }
        }
        private static void SetGasMassDensitySymbolList()
        {

        }  
        private static void CalculateCvReal_GasVolometric_MW()
        {
            try { 
            if(Qs_Min != "" && SG_Min != "" && N9 != "" && Xsixing_Min != "" && Fp != "" && T_Min != "" && Z_Min != "" && P1_Min != "" && Mu_Min != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Min), Q_Unit, "m³/hr");
                decimal t = BL.ConvertTempToKelvin(T_Min, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Min) * Convert.ToDouble(SG_Min)) / Convert.ToDouble(Xsixing_Min));
                double cv = (Convert.ToDouble(Qs_Min) * part1) / (Convert.ToDouble(N9) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Min) * Convert.ToDouble(Mu_Min));
                Cv_Real_Min = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Min = "";
            if (Qs_Norm != "" && SG_Norm != "" && N9 != "" && Xsixing_Norm != "" && Fp != "" && T_Norm != "" && Z_Norm != "" && P1_Norm != "" && Mu_Norm != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Norm), Q_Unit, "m³/hr");
                decimal t = BL.ConvertTempToKelvin(T_Norm, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Norm) * Convert.ToDouble(SG_Norm)) / Convert.ToDouble(Xsixing_Norm));
                double cv = (Convert.ToDouble(Qs_Norm) * part1) / (Convert.ToDouble(N9) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Norm) * Convert.ToDouble(Mu_Norm));
                Cv_Real_Norm = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Norm = "";
            if (Qs_Max != "" && SG_Max != "" && N9 != "" && Xsixing_Max != "" && Fp != "" && T_Max != "" && Z_Max != "" && P1_Max != "" && Mu_Max != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Max), Q_Unit, "m³/hr");
                decimal t = BL.ConvertTempToKelvin(T_Max, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Max) * Convert.ToDouble(SG_Max)) / Convert.ToDouble(Xsixing_Max));
                double cv = (Convert.ToDouble(Qs_Max) * part1) / (Convert.ToDouble(N9) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Max) * Convert.ToDouble(Mu_Max));
                Cv_Real_Max = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Max = "";
            if (Qs_Case1 != "" && SG_Case1 != "" && N9 != "" && Xsixing_Case1 != "" && Fp != "" && T_Case1 != "" && Z_Case1 != "" && P1_Case1 != "" && Mu_Case1 != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Case1), Q_Unit, "m³/hr");
                decimal t = BL.ConvertTempToKelvin(T_Case1, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Case1) * Convert.ToDouble(SG_Case1)) / Convert.ToDouble(Xsixing_Case1));
                double cv = (Convert.ToDouble(Qs_Case1) * part1) / (Convert.ToDouble(N9) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Case1) * Convert.ToDouble(Mu_Case1));
                Cv_Real_Case1 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case1 = "";
            if (Qs_Case2 != "" && SG_Case2 != "" && N9 != "" && Xsixing_Case2 != "" && Fp != "" && T_Case2 != "" && Z_Case2 != "" && P1_Case2 != "" && Mu_Case2 != "")
            {
                decimal w = BL.ConvertUnit(Convert.ToDecimal(Q_Case2), Q_Unit, "m³/hr");
                decimal t = BL.ConvertTempToKelvin(T_Case2, T_Unit);
                double part1 = Math.Sqrt(((double)t * Convert.ToDouble(Z_Case2) * Convert.ToDouble(SG_Case2)) / Convert.ToDouble(Xsixing_Case2));
                double cv = (Convert.ToDouble(Qs_Case2) * part1) / (Convert.ToDouble(N9) * Convert.ToDouble(Fp) * Convert.ToDouble(P1_Case2) * Convert.ToDouble(Mu_Case2));
                Cv_Real_Case2 = Math.Round(cv, 3).ToString();
            }
            else
                Cv_Real_Case2 = "";
            }
            catch
            {

            }
        }
        private static void SetGasVolometricMWSymbolList()
        {
            try
            {
                Program.SymbolList.Add(new Symbols("P₁", P1_Min, P1_Norm, P1_Max, P1_Case1, P1_Case2, P_Unit, P1_Description));
                Program.SymbolList.Add(new Symbols("P₂", P2_Min, P2_Norm, P2_Max, P2_Case1, P2_Case2, P_Unit, P2_Description));
                Program.SymbolList.Add(new Symbols("∆P actual", Delta_P_Min, Delta_P_Norm, Delta_P_Max, Delta_P_Case1, Delta_P_Case2, Delta_P_Unit, Delta_P_Actual_Description));
                Program.SymbolList.Add(new Symbols("X choked", Xchoked_Min, Xchoked_Norm, Xchoked_Max, Xchoked_Case1, Xchoked_Case2, "", Xchoked_Description));
                Program.SymbolList.Add(new Symbols("X sizing", Xsixing_Min, Xsixing_Norm, Xsixing_Max, Xsixing_Case1, Xsixing_Case2, "", Xsizing_Description));
                Program.SymbolList.Add(new Symbols("Q", Q_Min, Q_Norm, Q_Max, Q_Case1, Q_Case2, Q_Unit, Q_Description));
                Program.SymbolList.Add(new Symbols("Qs", Qs_Min, Qs_Norm, Qs_Max, Qs_Case1, Qs_Case2, "", Qs_Description));
                Program.SymbolList.Add(new Symbols("<html>P<b>ѵ</b>", Pv_Min, Pv_Norm, Pv_Max, Pv_Case1, Pv_Case2, Pv_Unit, Pv_Description));
                Program.SymbolList.Add(new Symbols("FL", Fl, Fl, Fl, Fl, Fl, "", Fl_Description));
                Program.SymbolList.Add(new Symbols("D₁", D1, D1, D1, D1, D1, D1_Unit, D1_Description));
                Program.SymbolList.Add(new Symbols("D₂", D2, D2, D2, D2, D2, D2_Unit, D2_Description));
                Program.SymbolList.Add(new Symbols("d", d, d, d, d, d, d_Unit, d_Description));
                Program.SymbolList.Add(new Symbols("ξ₁", Ksi1, Ksi1, Ksi1, Ksi1, Ksi1, "", Ksi1_Description));
                Program.SymbolList.Add(new Symbols("ξ₂", Ksi2, Ksi2, Ksi2, Ksi2, Ksi2, "", Ksi2_Description));
                Program.SymbolList.Add(new Symbols("ξB₁", KsiB1, KsiB1, KsiB1, KsiB1, KsiB1, "", KsiB1_Description));
                Program.SymbolList.Add(new Symbols("ξB₂", KsiB2, KsiB2, KsiB2, KsiB2, KsiB2, "", KsiB2_Description));
                Program.SymbolList.Add(new Symbols("ξᵢ", KsiI, KsiI, KsiI, KsiI, KsiI, "", KsiI_Description));
                Program.SymbolList.Add(new Symbols("Σξ", SigmaKsi, SigmaKsi, SigmaKsi, SigmaKsi, SigmaKsi, "", SigmaKsi_Description));
                Program.SymbolList.Add(new Symbols("N₉", N9, N9, N9, N9, N9, "", N_Description));
                Program.SymbolList.Add(new Symbols("Cv Rated", Cv_Rated, Cv_Rated, Cv_Rated, Cv_Rated, Cv_Rated, "", ""));
                Program.SymbolList.Add(new Symbols("N₅", N5, N5, N5, N5, N5, "", N_Description));
                Program.SymbolList.Add(new Symbols("N₂", N2, N2, N2, N2, N2, "", N_Description));
                Program.SymbolList.Add(new Symbols("X", X_Min, X_Norm, X_Max, X_Case1, X_Case2, "", X_Description));
                Program.SymbolList.Add(new Symbols("XT", Xt, Xt, Xt, Xt, Xt, "", Xt_Description));
                Program.SymbolList.Add(new Symbols("XTP", Xtp, Xtp, Xtp, Xtp, Xtp, "", Xtp_Description));
                Program.SymbolList.Add(new Symbols("FƳ", F_Minuscule_Min, F_Minuscule_Norm, F_Minuscule_Max, F_Minuscule_Case1, F_Minuscule_Case2, "", F_Minuscule_Description));
                Program.SymbolList.Add(new Symbols("Fp", Fp, Fp, Fp, Fp, Fp, "", Fp_Description));
                Program.SymbolList.Add(new Symbols("μ", Mu_Min, Mu_Norm, Mu_Max, Mu_Case1, Mu_Case2, "", Mu_Description));
                Program.SymbolList.Add(new Symbols("M", SG_Min, SG_Norm, SG_Max, SG_Case1, SG_Case2, "", M_Description));
                Program.SymbolList.Add(new Symbols("Cv", Cv_Real_Min, Cv_Real_Norm, Cv_Real_Max, Cv_Real_Case1, Cv_Real_Case2, "", C_Description));
            }
            catch
            {

            }
        }
    }



    public class Symbols
    {
        public string Symbol { get; set; }
        public string Min_Value { get; set; }
        public string Norm_Value { get; set; }
        public string Max_Value { get; set; }
        public string Case1_Value { get; set; }
        public string Case2_Value { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }

        public Symbols(string ISymbol,string IMin_Value, string INorm_Value, string IMax_Value, string ICase1_Value, string ICase2_Value, string IUnit, string IDescription)
        {
            Symbol = ISymbol;
            Min_Value = IMin_Value;
            Norm_Value = INorm_Value;
            Max_Value = IMax_Value;
            Case1_Value = ICase1_Value;
            Case2_Value = ICase2_Value;
            Unit = IUnit;
            Description = IDescription;
        }

    }
}
