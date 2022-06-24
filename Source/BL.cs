using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Radman
{
    public static class BL
    {

        public static DataTable GetPersonelList()
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetPersonelList";
                dt = dl.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetCustomerList()
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetCustomerList";
                dt = dl.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static int DeletePersonel(string Id)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcDeletePersonel";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@Id";
                newparams[0, 1] = Id;
                result = dl.IntExcuteSP(newparams);
                return result;
            }
            catch
            {
                return 0;
            }

        }

        public static DataTable GetProjectHeaderList()
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetProjectHeaderList";
                dt = dl.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetCustomerListNoAddToThisPersonel(string PersonelId)
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetCustomerListNoAddToThisPersonel";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@Personel_Id";
                newparams[0, 1] = PersonelId;
                dt = dl.ExcecuteQueryToDataTable(newparams);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static int DeleteCustomer(string Id)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcDeleteCustomer";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@Id";
                newparams[0, 1] = Id;
                result = dl.IntExcuteSP(newparams);
                return result;
            }
            catch
            {
                return 0;
            }

        }

        public static DataTable GetCustomerListByPersonnelId(string PersonelId)
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetCustomerListByPersonnelId";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@PersonelId";
                newparams[0, 1] = PersonelId;

                dt = dl.ExcecuteQueryToDataTable(newparams);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static List<Personel> GetPersonelListByProjectHeaderId(string ProjectHeaderId)
        {
            try
            {
                List<Personel> result = new List<Personel>();
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetPersonelListByProjectHeaderId";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@ProjectHeaderId";
                newparams[0, 1] = ProjectHeaderId;
                dt = dl.ExcecuteQueryToDataTable(newparams);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Id = dt.Rows[i]["PersonelId"].ToString();
                        string Name = dt.Rows[i]["Name"].ToString();
                        string Family = dt.Rows[i]["Family"].ToString();
                        string PersonelCode = dt.Rows[i]["PersonelyCode"].ToString();
                        string GenderId = dt.Rows[i]["Gender"].ToString();
                        string Gender = "";
                        if (GenderId == "0")
                            Gender = "Female";
                        else
                            Gender = "Male";
                        string Address = dt.Rows[i]["Address"].ToString();
                        string Contact = dt.Rows[i]["Contact"].ToString();
                        string InternalCode = dt.Rows[i]["InternalNo"].ToString();
                        string Email = dt.Rows[i]["Email"].ToString();
                        string JobTitle = dt.Rows[i]["JobTitle"].ToString();
                        string Username = "admin";
                        byte[] UserImageData;
                        Image UserImage = null;
                        if (dt.Rows[0]["Image"] != DBNull.Value)
                        {
                            UserImageData = (byte[])dt.Rows[i]["Image"];
                            MemoryStream ms = new MemoryStream(UserImageData);
                            UserImage = Image.FromStream(ms);
                        }
                        else
                        {
                            UserImage = Properties.Resources.unknown;
                        }
                        result.Add(new Personel(UserImage, Id, Name, Family, JobTitle, InternalCode, PersonelCode,
                                          Username, Email, Gender, Contact, Address));
                    }
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static int InsertPersonel(string Name, string Family, string PersonelyCode, int Gender,
                                      string InternalNo, string Address, string Contact, string JobTitle, string Email,
                                      Image UserImage)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcInsertPersonel";
                string[,] newparams = new string[9, 2];

                newparams[0, 0] = "@Name";
                newparams[0, 1] = Name;

                newparams[1, 0] = "@Family";
                newparams[1, 1] = Family;

                newparams[2, 0] = "@PersonelyCode";
                newparams[2, 1] = PersonelyCode;

                newparams[3, 0] = "@Gender";
                newparams[3, 1] = Gender.ToString();

                newparams[4, 0] = "@Address";
                newparams[4, 1] = Address;

                newparams[5, 0] = "@Contact";
                newparams[5, 1] = Contact;

                newparams[6, 0] = "@InternalNo";
                newparams[6, 1] = InternalNo;

                newparams[7, 0] = "@Email";
                newparams[7, 1] = Email;

                newparams[8, 0] = "@JobTitle";
                newparams[8, 1] = JobTitle;

                byte[] userImage = imageToByteArray(UserImage);
                result = dl.IntExcuteSP(newparams, userImage);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static int UpdatePersonel(string Id, string Name, string Family, string PersonelyCode,int Gender,
                                      string InternalNo, string Address, string Contact, string JobTitle, string Email,
                                      Image UserImage)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcUpdatePersonel";
                string[,] newparams = new string[10, 2];
                newparams[0, 0] = "@Id";
                newparams[0, 1] = Id;

                newparams[1, 0] = "@Name";
                newparams[1, 1] = Name;

                newparams[2, 0] = "@Family";
                newparams[2, 1] = Family;

                newparams[3, 0] = "@PersonelyCode";
                newparams[3, 1] = PersonelyCode;

                newparams[4, 0] = "@Gender";
                newparams[4, 1] = Gender.ToString();

                newparams[5, 0] = "@Address";
                newparams[5, 1] = Address;

                newparams[6, 0] = "@Contact";
                newparams[6, 1] = Contact;

                newparams[7, 0] = "@InternalNo";
                newparams[7, 1] = InternalNo;

                newparams[8, 0] = "@Email";
                newparams[8, 1] = Email;

                newparams[9, 0] = "@JobTitle";
                newparams[9, 1] = JobTitle;

                byte[] userImage = imageToByteArray(UserImage);
                result = dl.IntExcuteSP(newparams, userImage);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static int InsertPersonelToCustomer(string PersonelId, string CustomerId)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcInsertCustomerToPersonel";
                string[,] newparams = new string[2, 2];

                newparams[0, 0] = "@Personel_Id";
                newparams[0, 1] = PersonelId;

                newparams[1, 0] = "@Customer_Id";
                newparams[1, 1] = CustomerId;


                result = dl.IntExcuteSP(newparams);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static int UpdateCustomer(string Id, string Name, string DefultRefNo, string Fax, string Address,string Contact, string Email)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcUpdateCustomer";
                string[,] newparams = new string[7, 2];
                newparams[0, 0] = "@Id";
                newparams[0, 1] = Id;

                newparams[1, 0] = "@Name";
                newparams[1, 1] = Name;

                newparams[2, 0] = "@DefultRefNo";
                newparams[2, 1] = DefultRefNo;

                newparams[3, 0] = "@Fax";
                newparams[3, 1] = Fax;

                newparams[4, 0] = "@Address";
                newparams[4, 1] = Address;

                newparams[5, 0] = "@Contact";
                newparams[5, 1] = Contact;

                newparams[6, 0] = "@Email";
                newparams[6, 1] = Email;

                result = dl.IntExcuteSP(newparams);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static int UpdateProjectHeader(string Id, string Name, string ProjectRefNo, string CustomerRefNo, string ContactPerson,
                                              string ContactNo, string Location, string RadmanRefNo, string EndUserName,
                                              string CustomerId, Telerik.WinControls.Data.IReadOnlyCollection<RadListDataItem> SelectedPersonels,
                                              string RadmanNote,string ProjectNote,string CustomerNote,string EndUserNameId)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcUpdateProjectHeader";
                string[,] newparams = new string[14, 2];
                newparams[0, 0] = "@Id";
                newparams[0, 1] = Id;

                newparams[1, 0] = "@Name";
                newparams[1, 1] = Name;

                newparams[2, 0] = "@ProjectRefNo";
                newparams[2, 1] = ProjectRefNo;

                newparams[3, 0] = "@CustomerRefNo";
                newparams[3, 1] = CustomerRefNo;

                newparams[4, 0] = "@ContactPerson";
                newparams[4, 1] = ContactPerson;

                newparams[5, 0] = "@ContactNo";
                newparams[5, 1] = ContactNo;

                newparams[6, 0] = "@Location";
                newparams[6, 1] = Location;

                newparams[7, 0] = "@RadmanRefNo";
                newparams[7, 1] = RadmanRefNo;

                newparams[8, 0] = "@EndUserRefNo";
                newparams[8, 1] = EndUserName;

                newparams[9, 0] = "@CustomerId";
                newparams[9, 1] = CustomerId;

                newparams[10, 0] = "@RadmanNote";
                newparams[10, 1] = RadmanNote;

                newparams[11, 0] = "@ProjectNote";
                newparams[11, 1] = ProjectNote;


                newparams[12, 0] = "@CustomerNote";
                newparams[12, 1] = CustomerNote;

                newparams[13, 0] = "@EndUserNameId";
                newparams[13, 1] = EndUserNameId;

                result = dl.IntExcuteSP(newparams);
                if (result == 1)
                {
                    if (SelectedPersonels.Count > 0)
                    {
                        DeletePersonelsFromProjectHeader(Id);
                        for (int i = 0; i < SelectedPersonels.Count; i++)
                        {
                            string personel_id = SelectedPersonels[i].Value.ToString();
                            InsertPersonelsToProjectHeader(Id, personel_id);
                        }
                    }
                }
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static DataTable GetProjectHeaderByRadmanRefNo(string RadmanRefNo)
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetProjectHeaderByRadmanRefNo2";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@RadmanRefNo";
                newparams[0, 1] = RadmanRefNo;
                dt = dl.ExcecuteQueryToDataTable(newparams);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsRadmanRefNo_Unique(string RadmanRefNo)
        {
            try
            {
                bool result = false;
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetProjectHeaderByRadmanRefNo";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@RadmanRefNo";
                newparams[0, 1] = RadmanRefNo;
                dt = dl.ExcecuteQueryToDataTable(newparams);
                if (dt.Rows.Count == 0)
                    result = true;
                return result;
            }
            catch
            {
                return false;
            }
        }


        public static bool IsTagNumber_Unique(string TagNumber)
        {
            try
            {
                bool result = false;
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetProjectHeaderByTagNo";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@TagNo";
                newparams[0, 1] = TagNumber;
                dt = dl.ExcecuteQueryToDataTable(newparams);
                if (dt.Rows.Count == 0)
                    result = true;
                return result;
            }
            catch
            {
                return false;
            }
        }
        public static int InsertProjectHeader(string Name, string ProjectRefNo, string CustomerRefNo, string ContactPerson,
                                              string ContactNo, string Location, string RadmanRefNo, string EndUserName,
                                              string CustomerId, DropDownCheckedItemsCollection SelectedPersonels,
                                              string RadmanNote, string ProjectNote, string CustomerNote, string EndUserNameId)
        {
            try
            {
                int result = 0;
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcInsertProjectHeader";
                string[,] newparams = new string[13, 2];

                newparams[0, 0] = "@Name";
                newparams[0, 1] = Name;

                newparams[1, 0] = "@ProjectRefNo";
                newparams[1, 1] = ProjectRefNo;

                newparams[2, 0] = "@CustomerRefNo";
                newparams[2, 1] = CustomerRefNo;

                newparams[3, 0] = "@ContactPerson";
                newparams[3, 1] = ContactPerson;

                newparams[4, 0] = "@ContactNo";
                newparams[4, 1] = ContactNo;

                newparams[5, 0] = "@Location";
                newparams[5, 1] = Location;

                newparams[6, 0] = "@RadmanRefNo";
                newparams[6, 1] = RadmanRefNo;

                newparams[7, 0] = "@EndUserRefNo";
                newparams[7, 1] = EndUserName;

                newparams[8, 0] = "@CustomerId";
                newparams[8, 1] = CustomerId;

                newparams[9, 0] = "@RadmanNote";
                newparams[9, 1] = RadmanNote;

                newparams[10, 0] = "@ProjectNote";
                newparams[10, 1] = ProjectNote;


                newparams[11, 0] = "@CustomerNote";
                newparams[11, 1] = CustomerNote;

                newparams[12, 0] = "@EndUserNameId";
                newparams[12, 1] = EndUserNameId;

                result = dl.IntExcuteSP(newparams);

                if (result != 0)
                {
                    if (SelectedPersonels.Count > 0)
                    {
                        for (int i = 0; i < SelectedPersonels.Count; i++)
                        {
                            string personel_id = SelectedPersonels[i].Value.ToString();
                            InsertPersonelsToProjectHeader(result.ToString(), personel_id);
                        }
                    }
                }
                return result;
            }
            catch
            {
                return 0;
            }
        }

        private static void InsertPersonelsToProjectHeader(string ProjectHeaderId, string PersonelId)
        {
            try
            {
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcInsertPersonelsToProjectHeader";
                string[,] newparams = new string[2, 2];

                newparams[0, 0] = "@ProjectHeaderId";
                newparams[0, 1] = ProjectHeaderId;

                newparams[1, 0] = "@PersonelId";
                newparams[1, 1] = PersonelId;

                int result = dl.IntExcuteSP(newparams);
            }
            catch
            {
                
            }
        }

        private static void DeletePersonelsFromProjectHeader(string Id)
        {
            try
            {
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcDeletePersonelsFromProjectHeader";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@ProjectHeaderId";
                newparams[0, 1] = Id;

                int result = dl.IntExcuteSP(newparams);
            }
            catch
            {
                
            }
        }

        public static int DeletePersonelFromCustomer(string PersonelId, string CustomerId)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcDeletePersonelFromCustomer";
                string[,] newparams = new string[2, 2];

                newparams[0, 0] = "@Personel_Id";
                newparams[0, 1] = PersonelId;

                newparams[1, 0] = "@Customer_Id";
                newparams[1, 1] = CustomerId;
                result = dl.IntExcuteSP(newparams);
                return result;
            }
            catch
            {
                return 0;
            }
        }

		
        public static int InsertCustomer(string Name, string DefultRefNo, string Fax, string Address, string Contact, string Email)
        {
            try
            {
                int result = 0;
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcInsertCustomer";
                string[,] newparams = new string[6, 2];

                newparams[0, 0] = "@Name";
                newparams[0, 1] = Name;

                newparams[1, 0] = "@DefultRefNo";
                newparams[1, 1] = DefultRefNo;

                newparams[2, 0] = "@Fax";
                newparams[2, 1] = Fax;

                newparams[3, 0] = "@Address";
                newparams[3, 1] = Address;

                newparams[4, 0] = "@Contact";
                newparams[4, 1] = Contact;

                newparams[5, 0] = "@Email";
                newparams[5, 1] = Email;

                result = dl.IntExcuteSP(newparams);
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public static byte[] imageToByteArray(Image imageIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            catch
            {
                return null;
            }
        }
        public static Image GetImageFromData(byte[] imageData)
        {
            try
            {
                const int OleHeaderLength = 78;
                MemoryStream memoryStream = new MemoryStream();
                if (HasOleContainerHeader(imageData))
                {
                    memoryStream.Write(imageData, OleHeaderLength, imageData.Length - OleHeaderLength);
                }
                else
                {
                    memoryStream.Write(imageData, 0, imageData.Length);
                }
                Bitmap bitmap = new Bitmap(memoryStream);
                return bitmap.GetThumbnailImage(48, 48, null, new IntPtr());
            }
            catch
            {
                return null;
            }
        }

        public static Image GetImageFromData24(byte[] imageData)
        {
            try
            {
                const int OleHeaderLength = 78;
                MemoryStream memoryStream = new MemoryStream();
                if (HasOleContainerHeader(imageData))
                {
                    memoryStream.Write(imageData, OleHeaderLength, imageData.Length - OleHeaderLength);
                }
                else
                {
                    memoryStream.Write(imageData, 0, imageData.Length);
                }
                Bitmap bitmap = new Bitmap(memoryStream);
                return bitmap.GetThumbnailImage(24, 24, null, new IntPtr());
            }
            catch
            {
                return null;
            }
        }

        private static bool HasOleContainerHeader(byte[] imageByteArray)
        {
            try
            {
                const byte OleByte0 = 21;
                const byte OleByte1 = 28;
                return (imageByteArray[0] == OleByte0) && (imageByteArray[1] == OleByte1);
            }
            catch
            {
                return false;
            }
        }
        public static byte[] ReadFile(string sPath)
        {
            try
            {
                //Initialize byte array with a null value initially.
                byte[] data = null;

                //Use FileInfo object to get file size.
                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;

                //Open FileStream to read file
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

                //Use BinaryReader to read file stream into byte array.
                BinaryReader br = new BinaryReader(fStream);

                //When you use BinaryReader, you need to supply number of bytes to read from file.
                //In this case we want to read entire file. So supplying total number of bytes.
                data = br.ReadBytes((int)numBytes);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetCustomerListForThisPersonel(string personelId)
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetCustomerListForThisPersonel";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@Personel_Id";
                newparams[0, 1] = personelId;
                dt = dl.ExcecuteQueryToDataTable(newparams);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static int SaveProjectToDatabase(int ProjectIndex)
        {
            try
            {
                int result = -1;
                if (Program.ProjectList[ProjectIndex].TableId == "")
                {
                    string id = SaveProjectHeader(ProjectIndex);
                    if (id != "-1")
                    {
                        if (Program.ProjectList[ProjectIndex].NewFields.RowCount > 0)
                        {
                            int res = SaveProjectNewFields(id, Program.ProjectList[ProjectIndex].NewFields);
                            if (res == 0)
                                return -1;
                        }
                        result = SaveProjectDetails(id, ProjectIndex, "prcInsertTagsDetails");
                        if (result == 1)
                        {
                            if (Program.ProjectList[ProjectIndex].Prepared == false)
                                result = SaveProjectAction(id, 1, 1); // ActionId,RevisionNomber = 1


                        }
                    }
                }
                else
                {
                    //todo: go to update
                    result = UpdateProjectHeader(Program.ProjectList[ProjectIndex].TableId, ProjectIndex);
                    if (result == 1)
                    {
                        if (Program.ProjectList[ProjectIndex].NewFields.RowCount > 0)
                        {
                            //first delete all new field if exist
                            //second insert new field
                        }
                        result = SaveProjectDetails(Program.ProjectList[ProjectIndex].TableId, ProjectIndex, "prcUpdateTagsDetails");
                        if (result == 1)
                        {
                            result = SaveProjectAction(Program.ProjectList[ProjectIndex].TableId, 5, 1); // ActionId,RevisionNomber = 1


                        }
                    }

                }

                return result;
            }
            catch
            {
                return 0;
            }
        }
       
        private static int UpdateProjectHeader(string TableId,int ProjectIndex)
        {
            try
            {
                int res = 0;
                DAL dal_header = new DAL();
                dal_header.StoredProcedureName = "prcUpdateTagsHeader";
                string[,] newparams = new string[12, 2];
                newparams[0, 0] = "@TagNumber";
                newparams[0, 1] = Program.ProjectList[ProjectIndex].Tag_No;

                newparams[1, 0] = "@Project";
                newparams[1, 1] = Program.ProjectList[ProjectIndex].ProjectName;

                newparams[2, 0] = "@P_ID";
                newparams[2, 1] = Program.ProjectList[ProjectIndex].PID_No;

                newparams[3, 0] = "@Service";
                newparams[3, 1] = Program.ProjectList[ProjectIndex].Service;

                newparams[4, 0] = "@LineNumber";
                newparams[4, 1] = Program.ProjectList[ProjectIndex].Line_No;

                newparams[5, 0] = "@Quentity";
                newparams[5, 1] = Program.ProjectList[ProjectIndex].Quantity;

                newparams[6, 0] = "@Customer";
                newparams[6, 1] = Program.ProjectList[ProjectIndex].Client;

                newparams[7, 0] = "@CustomerRefNo";
                newparams[7, 1] = Program.ProjectList[ProjectIndex].End_User_Ref;

                newparams[8, 0] = "@RadmanRefNo";
                newparams[8, 1] = Program.ProjectList[ProjectIndex].RadmanRef;

                newparams[9, 0] = "@ProjectRefNo";
                newparams[9, 1] = Program.ProjectList[ProjectIndex].Project_Ref;

                newparams[10, 0] = "@Location";
                newparams[10, 1] = Program.ProjectList[ProjectIndex].Location;

                newparams[11, 0] = "@Id";
                newparams[11, 1] = TableId;


                res = dal_header.IntExcuteSP(newparams);
                return res;
            }
            catch
            {
                return 0;
            }
        }

        private static int SaveProjectAction(string Id, int ActionId,int RevisionNumber)
        {
            try
            {
                int result = 0;
                DAL dal_action = new DAL();
                dal_action.StoredProcedureName = "prcInsertTagsAction";
                DateTime dt = DateTime.Now;

                string[,] newparams = new string[6, 2];

                newparams[0, 0] = "@Tag_Id";
                newparams[0, 1] = Id;

                newparams[1, 0] = "@Action_Id";
                newparams[1, 1] = ActionId.ToString();

                newparams[2, 0] = "@ActionDate";
                newparams[2, 1] = dt.ToString("yyyy/MM/dd");

                newparams[3, 0] = "@ActionTime";
                newparams[3, 1] = dt.ToString("hh:mm:ss");

                newparams[4, 0] = "@User_Id";
                newparams[4, 1] = Program.UserId;

                newparams[5, 0] = "@RevisionNumber";
                newparams[5, 1] = RevisionNumber.ToString();

                result = dal_action.IntExcuteSP(newparams);
                return result;
            }
            catch
            {
                return 0;
            }
        }
        private static int SaveProjectDetails(string Id, int ProjectIndex,string ProcName)
        {
            try
            {
                int result = 0;
                Program.ProjectList[ProjectIndex].TableId = Id;
                DAL dal_details = new DAL();
                dal_details.StoredProcedureName = ProcName;
                string[,] newparams = new string[151, 2];

                newparams[0, 0] = "@TagHeader_Id";
                newparams[0, 1] = Id;

                newparams[1, 0] = "@Fluid_Type";
                newparams[1, 1] = Program.ProjectList[ProjectIndex].Fluid_Type;

                newparams[2, 0] = "@Standard_Type";
                newparams[2, 1] = Program.ProjectList[ProjectIndex].Standard_Type;

                newparams[3, 0] = "@Valve_Type";
                newparams[3, 1] = Program.ProjectList[ProjectIndex].Valve_Type;

                newparams[4, 0] = "@Safety_Relief";
                newparams[4, 1] = Program.ProjectList[ProjectIndex].Safety_Relief;

                newparams[5, 0] = "@TemperaturesRanges";
                newparams[5, 1] = Program.ProjectList[ProjectIndex].TemperaturesRanges;

                newparams[6, 0] = "@InletConnection";
                newparams[6, 1] = Program.ProjectList[ProjectIndex].InletConnection;

                newparams[7, 0] = "@OutletConnection";
                newparams[7, 1] = Program.ProjectList[ProjectIndex].OutletConnection;

                newparams[8, 0] = "@FlangeFace";
                newparams[8, 1] = Program.ProjectList[ProjectIndex].FlangeFace;

                newparams[9, 0] = "@Nozzle";
                newparams[9, 1] = Program.ProjectList[ProjectIndex].Nozzle;

                newparams[10, 0] = "@Bonnet";
                newparams[10, 1] = Program.ProjectList[ProjectIndex].Bonnet;

                newparams[11, 0] = "@Bolting";
                newparams[11, 1] = Program.ProjectList[ProjectIndex].Bolting;

                newparams[12, 0] = "@NACE_MR0175";
                newparams[12, 1] = Program.ProjectList[ProjectIndex].NACE_MR0175;

                newparams[13, 0] = "@Valve_Model_No";
                newparams[13, 1] = Program.ProjectList[ProjectIndex].Valve_Model_No;

                newparams[14, 0] = "@Series";
                newparams[14, 1] = Program.ProjectList[ProjectIndex].Series;

                newparams[15, 0] = "@Orifice";
                newparams[15, 1] = Program.ProjectList[ProjectIndex].Orifice;

                newparams[16, 0] = "@Kd";
                newparams[16, 1] = Program.ProjectList[ProjectIndex].Kd;

                newparams[17, 0] = "@Area_Calculated";
                newparams[17, 1] = Program.ProjectList[ProjectIndex].Area_Calculated;

                newparams[18, 0] = "@Area_Selected";
                newparams[18, 1] = Program.ProjectList[ProjectIndex].Area_Selected;

                newparams[19, 0] = "@Flow_Actual";
                newparams[19, 1] = Program.ProjectList[ProjectIndex].Flow_Actual;

                newparams[20, 0] = "@Flow_Required";
                newparams[20, 1] = Program.ProjectList[ProjectIndex].Flow_Required;

                newparams[21, 0] = "@Estimated_Reaction_Force";
                newparams[21, 1] = Program.ProjectList[ProjectIndex].Estimated_Reaction_Force;

                newparams[22, 0] = "@Estimated_Noise_Level";
                newparams[22, 1] = Program.ProjectList[ProjectIndex].Estimated_Noise_Level;

                newparams[23, 0] = "@Design_Code";
                newparams[23, 1] = Program.ProjectList[ProjectIndex].Design_Code;

                newparams[24, 0] = "@Sizing_Std";
                newparams[24, 1] = Program.ProjectList[ProjectIndex].Sizing_Std;

                newparams[25, 0] = "@Sizing_Basis";
                newparams[25, 1] = Program.ProjectList[ProjectIndex].Sizing_Basis;

                newparams[26, 0] = "@Fluid_State_at_Inlet";
                newparams[26, 1] = Program.ProjectList[ProjectIndex].Fluid_State_at_Inlet;

                newparams[27, 0] = "@Relieving_Case";
                newparams[27, 1] = Program.ProjectList[ProjectIndex].Relieving_Case;

                newparams[28, 0] = "@Fluid_Name";
                newparams[28, 1] = Program.ProjectList[ProjectIndex].Fluid_Name;

                newparams[29, 0] = "@Molecular_Weight";
                newparams[29, 1] = Program.ProjectList[ProjectIndex].Molecular_Weight;

                newparams[30, 0] = "@Compressibility";
                newparams[30, 1] = Program.ProjectList[ProjectIndex].Compressibility;

                newparams[31, 0] = "@k";
                newparams[31, 1] = Program.ProjectList[ProjectIndex].k;

                newparams[32, 0] = "@Saturation_Temperature";
                newparams[32, 1] = Program.ProjectList[ProjectIndex].Saturation_Temperature;

                newparams[33, 0] = "@MAWP";
                newparams[33, 1] = Program.ProjectList[ProjectIndex].MAWP;

                newparams[34, 0] = "@MAWP_Unit";
                newparams[34, 1] = Program.ProjectList[ProjectIndex].MAWP_Unit;

                newparams[35, 0] = "@Operating_Pressures";
                newparams[35, 1] = Program.ProjectList[ProjectIndex].Operating_Pressures;

                newparams[36, 0] = "@Operating_Pressures_Unit";
                newparams[36, 1] = Program.ProjectList[ProjectIndex].Operating_Pressures_Unit;

                newparams[37, 0] = "@SET_PRESSURE";
                newparams[37, 1] = Program.ProjectList[ProjectIndex].SET_PRESSURE;

                newparams[38, 0] = "@SET_PRESSURE_Unit";
                newparams[38, 1] = Program.ProjectList[ProjectIndex].SET_PRESSURE_Unit;

                newparams[39, 0] = "@Over_Pressure";
                newparams[39, 1] = Program.ProjectList[ProjectIndex].Over_Pressure;

                newparams[40, 0] = "@Over_Pressure_Percent";
                newparams[40, 1] = Program.ProjectList[ProjectIndex].Over_Pressure_Percent;

                newparams[41, 0] = "@Constant_Superimposed";
                newparams[41, 1] = Program.ProjectList[ProjectIndex].Constant_Superimposed;

                newparams[42, 0] = "@Constant_Superimposed_Unit";
                newparams[42, 1] = Program.ProjectList[ProjectIndex].Constant_Superimposed_Unit;

                newparams[43, 0] = "@Variable_Superimposed";
                newparams[43, 1] = Program.ProjectList[ProjectIndex].Variable_Superimposed;

                newparams[44, 0] = "@Variable_Superimposed_Unit";
                newparams[44, 1] = Program.ProjectList[ProjectIndex].Variable_Superimposed_Unit;

                newparams[45, 0] = "@Built_Up";
                newparams[45, 1] = Program.ProjectList[ProjectIndex].Built_Up;

                newparams[46, 0] = "@Built_Up_Unit";
                newparams[46, 1] = Program.ProjectList[ProjectIndex].Built_Up_Unit;

                newparams[47, 0] = "@Total";
                newparams[47, 1] = Program.ProjectList[ProjectIndex].Total;

                newparams[48, 0] = "@Total_Unit";
                newparams[48, 1] = Program.ProjectList[ProjectIndex].Total_Unit;

                newparams[49, 0] = "@Inlet_Loss";
                newparams[49, 1] = Program.ProjectList[ProjectIndex].Inlet_Loss;

                newparams[50, 0] = "@Inlet_Loss_Percent";
                newparams[50, 1] = Program.ProjectList[ProjectIndex].Inlet_Loss_Percent;

                newparams[51, 0] = "@Relieving_Flowing_Unit";
                newparams[51, 1] = Program.ProjectList[ProjectIndex].Relieving_Flowing_Unit;

                newparams[52, 0] = "@Relieving_Flowing";
                newparams[52, 1] = Program.ProjectList[ProjectIndex].Relieving_Flowing;

                newparams[53, 0] = "@Atmospheric";
                newparams[53, 1] = Program.ProjectList[ProjectIndex].Atmospheric_Pressure;

                newparams[54, 0] = "@Atmospheric_Unit";
                newparams[54, 1] = Program.ProjectList[ProjectIndex].Atmospheric_Unit;

                newparams[55, 0] = "@Operating";
                newparams[55, 1] = Program.ProjectList[ProjectIndex].Operating;

                newparams[56, 0] = "@Operating_Unit";
                newparams[56, 1] = Program.ProjectList[ProjectIndex].Operating_Unit;

                newparams[57, 0] = "@Relieving";
                newparams[57, 1] = Program.ProjectList[ProjectIndex].Relieving;

                newparams[58, 0] = "@Relieving_Unit";
                newparams[58, 1] = Program.ProjectList[ProjectIndex].Relieving_Unit;

                newparams[59, 0] = "@Design_Min";
                newparams[59, 1] = Program.ProjectList[ProjectIndex].Design_Min;

                newparams[60, 0] = "@Design_Min_Unit";
                newparams[60, 1] = Program.ProjectList[ProjectIndex].Design_Min_Unit;

                newparams[61, 0] = "@Design_Max";
                newparams[61, 1] = Program.ProjectList[ProjectIndex].Design_Max;

                newparams[62, 0] = "@Design_Max_Unit";
                newparams[62, 1] = Program.ProjectList[ProjectIndex].Design_Max_Unit;

                newparams[63, 0] = "@Normal_System";
                newparams[63, 1] = Program.ProjectList[ProjectIndex].Normal_System;

                newparams[64, 0] = "@Normal_System_Unit";
                newparams[64, 1] = Program.ProjectList[ProjectIndex].Normal_System_Unit;

                newparams[65, 0] = "@SelectedSeries";
                newparams[65, 1] = Program.ProjectList[ProjectIndex].SelectedSeries;

                newparams[66, 0] = "@SelectedOrifice";
                newparams[66, 1] = Program.ProjectList[ProjectIndex].SelectedOrifice;

                newparams[67, 0] = "@ValveService";
                newparams[67, 1] = Program.ProjectList[ProjectIndex].ValveService;

                newparams[68, 0] = "@CodeSection";
                newparams[68, 1] = Program.ProjectList[ProjectIndex].CodeSection;

                newparams[69, 0] = "@ValveOrifice";
                newparams[69, 1] = Program.ProjectList[ProjectIndex].ValveOrifice;

                newparams[70, 0] = "@Valve_Size";
                newparams[70, 1] = Program.ProjectList[ProjectIndex].Valve_Size;

                newparams[71, 0] = "@Seat_Type";
                newparams[71, 1] = Program.ProjectList[ProjectIndex].Seat_Type;

                newparams[72, 0] = "@Seat";
                newparams[72, 1] = Program.ProjectList[ProjectIndex].Seat;

                newparams[73, 0] = "@Specific_Gravity";
                newparams[73, 1] = Program.ProjectList[ProjectIndex].Specific_Gravity;

                newparams[74, 0] = "@Viscosity";
                newparams[74, 1] = Program.ProjectList[ProjectIndex].Viscosity;

                newparams[75, 0] = "@Kv";
                newparams[75, 1] = Program.ProjectList[ProjectIndex].Kv;

                newparams[76, 0] = "@V";
                newparams[76, 1] = Program.ProjectList[ProjectIndex].V;

                newparams[77, 0] = "@V1";
                newparams[77, 1] = Program.ProjectList[ProjectIndex].V1;

                newparams[78, 0] = "@Operating_Density";
                newparams[78, 1] = Program.ProjectList[ProjectIndex].Operating_Density;

                newparams[79, 0] = "@V0";
                newparams[79, 1] = Program.ProjectList[ProjectIndex].V0;

                newparams[80, 0] = "@V90";
                newparams[80, 1] = Program.ProjectList[ProjectIndex].V90;

                newparams[81, 0] = "@VaporPressure";
                newparams[81, 1] = Program.ProjectList[ProjectIndex].VaporPressure;

                newparams[82, 0] = "@LiquidDensity";
                newparams[82, 1] = Program.ProjectList[ProjectIndex].LiquidDensity;

                newparams[83, 0] = "@LiquidSpecific";
                newparams[83, 1] = Program.ProjectList[ProjectIndex].LiquidSpecific;

                newparams[84, 0] = "@SpesificGravity";
                newparams[84, 1] = Program.ProjectList[ProjectIndex].SpesificGravity;

                newparams[85, 0] = "@HasRuptureDisk";
                newparams[85, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].HasRuptureDisk);

                newparams[86, 0] = "@Current_TabPage_Name";
                newparams[86, 1] = Program.ProjectList[ProjectIndex].Current_TabPage_Name;

                newparams[87, 0] = "@ANSIFlangeRating";
                newparams[87, 1] = Program.ProjectList[ProjectIndex].ANSIFlangeRating;

                newparams[88, 0] = "@BodyMaterial";
                newparams[88, 1] = Program.ProjectList[ProjectIndex].BodyMaterial;

                newparams[89, 0] = "@SpringMaterial";
                newparams[89, 1] = Program.ProjectList[ProjectIndex].SpringMaterial;

                newparams[90, 0] = "@TrimMaterial";
                newparams[90, 1] = Program.ProjectList[ProjectIndex].TrimMaterial;

                newparams[91, 0] = "@NozzleMaterial";
                newparams[91, 1] = Program.ProjectList[ProjectIndex].NozzleMaterial;

                newparams[92, 0] = "@SelectionVIIIApplicationCheckBox";
                newparams[92, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].SelectionVIIIApplicationCheckBox);

                newparams[93, 0] = "@chbScrewedCap";
                newparams[93, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbScrewedCap);

                newparams[94, 0] = "@chbBoltedCap";
                newparams[94, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbBoltedCap);

                newparams[95, 0] = "@chbAuxiliaryBackupPiston";
                newparams[95, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbAuxiliaryBackupPiston);

                newparams[96, 0] = "@chbTestGag";
                newparams[96, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbTestGag);

                newparams[97, 0] = "@chbHighPressure";
                newparams[97, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbHighPressure);

                newparams[98, 0] = "@chbOpenLever";
                newparams[98, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbOpenLever);

                newparams[99, 0] = "@chbPackedLever";
                newparams[99, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbPackedLever);

                newparams[100, 0] = "@chbDomedCap";
                newparams[100, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbDomedCap);

                newparams[101, 0] = "@chbFerrule";
                newparams[101, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbFerrule);

                newparams[102, 0] = "@chbGag";
                newparams[102, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbGag);

                newparams[103, 0] = "@chbNACEMaterial";
                newparams[103, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbNACEMaterial);

                newparams[104, 0] = "@chbResilientSeat";
                newparams[104, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbResilientSeat);

                newparams[105, 0] = "@chbRemotePressureSensing";
                newparams[105, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbRemotePressureSensing);

                newparams[106, 0] = "@chbBackFlowPreventer";
                newparams[106, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbBackFlowPreventer);

                newparams[107, 0] = "@chbCoolingHeatingCoils";
                newparams[107, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbCoolingHeatingCoils);

                newparams[108, 0] = "@chbExternalFilter";
                newparams[108, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbExternalFilter);

                newparams[109, 0] = "@chbLiquidDuty";
                newparams[109, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbLiquidDuty);

                newparams[110, 0] = "@chbFieldTestConnector";
                newparams[110, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbFieldTestConnector);

                newparams[111, 0] = "@chbRemoteUnloader";
                newparams[111, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbRemoteUnloader);

                newparams[112, 0] = "@chbSpecialFeatures";
                newparams[112, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbSpecialFeatures);

                newparams[113, 0] = "@GasDensity";
                newparams[113, 1] = Program.ProjectList[ProjectIndex].GasDensity;

                newparams[114, 0] = "@SpecificValumeGas";
                newparams[114, 1] = Program.ProjectList[ProjectIndex].SpecificValumeGas;

                newparams[115, 0] = "@SpecificValumeLiquid";
                newparams[115, 1] = Program.ProjectList[ProjectIndex].SpecificValumeLiquid;

                newparams[116, 0] = "@Notes";
                newparams[116, 1] = Program.ProjectList[ProjectIndex].Notes;

                newparams[117, 0] = "@VaporFlowCapacity";
                newparams[117, 1] = Program.ProjectList[ProjectIndex].VaporFlowCapacity;

                newparams[118, 0] = "@LiquidFlowCapacity";
                newparams[118, 1] = Program.ProjectList[ProjectIndex].LiquidFlowCapacity;

                newparams[119, 0] = "@MixDensity90";
                newparams[119, 1] = Program.ProjectList[ProjectIndex].MixDensity90;

                newparams[120, 0] = "@SpVol90";
                newparams[120, 1] = Program.ProjectList[ProjectIndex].SpVol90;

                newparams[121, 0] = "@ViscosityUnit";
                newparams[121, 1] = Program.ProjectList[ProjectIndex].ViscosityUnit;

                newparams[122, 0] = "@RequiredPressureFlowUnit";
                newparams[122, 1] = Program.ProjectList[ProjectIndex].RequiredPressureFlowUnit;

                newparams[123, 0] = "@RequiredFlowCapacityUnit";
                newparams[123, 1] = Program.ProjectList[ProjectIndex].RequiredFlowCapacityUnit;

                newparams[124, 0] = "@DensityUnit";
                newparams[124, 1] = Program.ProjectList[ProjectIndex].DensityUnit;

                newparams[125, 0] = "@SpecificValumeUnit";
                newparams[125, 1] = Program.ProjectList[ProjectIndex].SpecificValumeUnit;

                newparams[126, 0] = "@VaporFlowCapacityUnit";
                newparams[126, 1] = Program.ProjectList[ProjectIndex].VaporFlowCapacityUnit;

                newparams[127, 0] = "@VaporUnitC23";
                newparams[127, 1] = Program.ProjectList[ProjectIndex].VaporUnitC23;

                newparams[128, 0] = "@LiquidDensityUnit";
                newparams[128, 1] = Program.ProjectList[ProjectIndex].LiquidDensityUnit;

                newparams[129, 0] = "@LiquidSpecificUnit";
                newparams[129, 1] = Program.ProjectList[ProjectIndex].LiquidSpecificUnit;

                newparams[130, 0] = "@chbStandardCertificateOrigin";
                newparams[130, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbStandardCertificateOrigin);

                newparams[131, 0] = "@chbCertificateConformancePurchaseOrder";
                newparams[131, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbCertificateConformancePurchaseOrder);

                newparams[132, 0] = "@chbCertificateConformanceNACE_MR0175";
                newparams[132, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbCertificateConformanceNACE_MR0175);

                newparams[133, 0] = "@chbCertificateConformanceASMEHydrostaticTesting";
                newparams[133, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbCertificateConformanceASMEHydrostaticTesting);

                newparams[134, 0] = "@chbMaterialTestReports";
                newparams[134, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbMaterialTestReports);

                newparams[135, 0] = "@chbHydrostaticTestReportASME";
                newparams[135, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbHydrostaticTestReportASME);

                newparams[136, 0] = "@chbFunctionalTestReport";
                newparams[136, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbFunctionalTestReport);

                newparams[137, 0] = "@chbHardnessTestReport";
                newparams[137, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbHardnessTestReport);

                newparams[138, 0] = "@chbBendTestReportBodyBonnetCasting";
                newparams[138, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbBendTestReportBodyBonnetCasting);

                newparams[139, 0] = "@chbRadiographyTestReport";
                newparams[139, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbRadiographyTestReport);

                newparams[140, 0] = "@chbSpecialPainting";
                newparams[140, 1] = Convert.ToString(Program.ProjectList[ProjectIndex].chbSpecialPainting);

                newparams[141, 0] = "@Cap_Type";
                newparams[141, 1] = Program.ProjectList[ProjectIndex].Cap_Type;

                newparams[142, 0] = "@Inlet_Size_Connection";
                newparams[142, 1] = Program.ProjectList[ProjectIndex].Inlet_Size_Connection;

                newparams[143, 0] = "@Outlet_Size_Connection";
                newparams[143, 1] = Program.ProjectList[ProjectIndex].Outlet_Size_Connection;

                newparams[144, 0] = "@Body_Bonnet";
                newparams[144, 1] = Program.ProjectList[ProjectIndex].Body_Bonnet;

                newparams[145, 0] = "@Nozzle_Materials";
                newparams[145, 1] = Program.ProjectList[ProjectIndex].Nozzle_Materials;

                newparams[146, 0] = "@Disc";
                newparams[146, 1] = Program.ProjectList[ProjectIndex].Disc;

                newparams[147, 0] = "@Guide";
                newparams[147, 1] = Program.ProjectList[ProjectIndex].Guide;

                newparams[148, 0] = "@Spring";
                newparams[148, 1] = Program.ProjectList[ProjectIndex].Spring;

                newparams[149, 0] = "@Gaskets";
                newparams[149, 1] = Program.ProjectList[ProjectIndex].Gaskets;

                newparams[150, 0] = "@Bellows";
                newparams[150, 1] = Program.ProjectList[ProjectIndex].Bellows;

                result = dal_details.IntExcuteSP(newparams);
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static int AddProjectToList(string TableId)
        {
            try
            {
                int res = -1;
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetTagListById";
                string[,] newparams = new string[1, 2];
                newparams[0, 0] = "@Id";
                newparams[0, 1] = TableId;
                dt = dl.ExcecuteQueryToDataTable(newparams);
                if (dt.Rows.Count > 0)
                {
                    Project prj = new Project();
                    prj.Id = Program.ProjectList.Count + 1;
                    prj.TableId = TableId;
                    prj.Tag_No = dt.Rows[0]["TagNumber"].ToString();
                    prj.ProjectName = dt.Rows[0]["Project"].ToString();
                    prj.PID_No = dt.Rows[0]["P_ID"].ToString();
                    prj.Service = dt.Rows[0]["Service"].ToString();
                    prj.Line_No = dt.Rows[0]["LineNumber"].ToString();
                    prj.Quantity = dt.Rows[0]["Quentity"].ToString();
                    prj.Client = dt.Rows[0]["Customer"].ToString();
                    prj.End_User_Ref = dt.Rows[0]["CustomerRefNo"].ToString();
                    prj.RadmanRef = dt.Rows[0]["RadmanRefNo"].ToString();
                    prj.Project_Ref = dt.Rows[0]["ProjectRefNo"].ToString();
                    prj.Location = dt.Rows[0]["Location"].ToString();
                    prj.TemperaturesRanges = dt.Rows[0]["TemperaturesRanges"].ToString();
                    prj.chbExternalFilter = Convert.ToBoolean(dt.Rows[0]["chbExternalFilter"].ToString());
                    prj.Fluid_Type = dt.Rows[0]["Fluid_Type"].ToString();
                    prj.Standard_Type = dt.Rows[0]["Standard_Type"].ToString();
                    prj.Valve_Type = dt.Rows[0]["Valve_Type"].ToString();
                    prj.Safety_Relief = dt.Rows[0]["Safety_Relief"].ToString();
                    prj.Safety_Relief = dt.Rows[0]["Safety_Relief"].ToString();
                    prj.InletConnection = dt.Rows[0]["InletConnection"].ToString();
                    prj.OutletConnection = dt.Rows[0]["OutletConnection"].ToString();
                    prj.FlangeFace = dt.Rows[0]["FlangeFace"].ToString();
                    prj.Nozzle = dt.Rows[0]["Nozzle"].ToString();
                    prj.Bonnet = dt.Rows[0]["Bonnet"].ToString();
                    prj.Cap_Type = dt.Rows[0]["Cap_Type"].ToString();
                    prj.Inlet_Size_Connection = dt.Rows[0]["Inlet_Size_Connection"].ToString();
                    prj.Outlet_Size_Connection = dt.Rows[0]["Outlet_Size_Connection"].ToString();
                    prj.Body_Bonnet = dt.Rows[0]["Body_Bonnet"].ToString();
                    prj.Nozzle_Materials = dt.Rows[0]["Nozzle_Materials"].ToString();
                    prj.Disc = dt.Rows[0]["Disc"].ToString();
                    prj.Guide = dt.Rows[0]["Guide"].ToString();
                    prj.Spring = dt.Rows[0]["Spring"].ToString();
                    prj.Gaskets = dt.Rows[0]["Gaskets"].ToString();
                    prj.Bellows = dt.Rows[0]["Bellows"].ToString();
                    prj.Bolting = dt.Rows[0]["Bolting"].ToString();
                    prj.NACE_MR0175 = dt.Rows[0]["NACE_MR0175"].ToString();
                    prj.Valve_Model_No = dt.Rows[0]["Valve_Model_No"].ToString();
                    prj.Series = dt.Rows[0]["Series"].ToString();
                    prj.Orifice = dt.Rows[0]["Orifice"].ToString();
                    prj.Kd = dt.Rows[0]["Kd"].ToString();
                    prj.Area_Calculated = dt.Rows[0]["Area_Calculated"].ToString();
                    prj.Area_Selected = dt.Rows[0]["Area_Selected"].ToString();
                    prj.Flow_Actual = dt.Rows[0]["Flow_Actual"].ToString();
                    prj.Flow_Required = dt.Rows[0]["Flow_Required"].ToString();
                    prj.Estimated_Reaction_Force = dt.Rows[0]["Estimated_Reaction_Force"].ToString();
                    prj.Estimated_Noise_Level = dt.Rows[0]["Estimated_Noise_Level"].ToString();
                    prj.Design_Code = dt.Rows[0]["Design_Code"].ToString();
                    prj.Sizing_Std = dt.Rows[0]["Sizing_Std"].ToString();
                    prj.Sizing_Basis = dt.Rows[0]["Sizing_Basis"].ToString();
                    prj.Fluid_State_at_Inlet = dt.Rows[0]["Fluid_State_at_Inlet"].ToString();
                    prj.Relieving_Case = dt.Rows[0]["Relieving_Case"].ToString();
                    prj.Fluid_Name = dt.Rows[0]["Fluid_Name"].ToString();
                    prj.Molecular_Weight = dt.Rows[0]["Molecular_Weight"].ToString();
                    prj.Compressibility = dt.Rows[0]["Compressibility"].ToString();
                    prj.k = dt.Rows[0]["k"].ToString();
                    prj.Saturation_Temperature = dt.Rows[0]["Saturation_Temperature"].ToString();
                    prj.MAWP = dt.Rows[0]["MAWP"].ToString();
                    prj.MAWP_Unit = dt.Rows[0]["MAWP_Unit"].ToString();
                    prj.Operating_Pressures = dt.Rows[0]["Operating_Pressures"].ToString();
                    prj.Operating_Pressures_Unit = dt.Rows[0]["Operating_Pressures_Unit"].ToString();
                    prj.SET_PRESSURE = dt.Rows[0]["SET_PRESSURE"].ToString();
                    prj.SET_PRESSURE_Unit = dt.Rows[0]["SET_PRESSURE_Unit"].ToString();
                    prj.Over_Pressure = dt.Rows[0]["Over_Pressure"].ToString();
                    prj.Over_Pressure_Percent = dt.Rows[0]["Over_Pressure_Percent"].ToString();
                    prj.Constant_Superimposed = dt.Rows[0]["Constant_Superimposed"].ToString();
                    prj.Constant_Superimposed_Unit = dt.Rows[0]["Constant_Superimposed_Unit"].ToString();
                    prj.Variable_Superimposed = dt.Rows[0]["Variable_Superimposed"].ToString();
                    prj.Variable_Superimposed_Unit = dt.Rows[0]["Variable_Superimposed_Unit"].ToString();
                    prj.Built_Up = dt.Rows[0]["Built_Up"].ToString();
                    prj.Built_Up_Unit = dt.Rows[0]["Built_Up_Unit"].ToString();
                    prj.Total = dt.Rows[0]["Total"].ToString();
                    prj.Total_Unit = dt.Rows[0]["Total_Unit"].ToString();
                    prj.Inlet_Loss = dt.Rows[0]["Inlet_Loss"].ToString();
                    prj.Inlet_Loss_Percent = dt.Rows[0]["Inlet_Loss_Percent"].ToString();
                    prj.Relieving_Flowing_Unit = dt.Rows[0]["Relieving_Flowing_Unit"].ToString();
                    prj.Relieving_Flowing = dt.Rows[0]["Relieving_Flowing"].ToString();
                    prj.Relieving = dt.Rows[0]["Relieving"].ToString();
                    prj.Atmospheric_Pressure = dt.Rows[0]["Atmospheric"].ToString();
                    prj.Atmospheric_Unit = dt.Rows[0]["Atmospheric_Unit"].ToString();
                    prj.Operating = dt.Rows[0]["Operating"].ToString();
                    prj.Operating_Unit = dt.Rows[0]["Operating_Unit"].ToString();
                    prj.Operating_Unit = dt.Rows[0]["Operating_Unit"].ToString();
                    prj.Operating_Unit = dt.Rows[0]["Operating_Unit"].ToString();
                    prj.Operating_Unit = dt.Rows[0]["Operating_Unit"].ToString();
                    prj.Design_Min = dt.Rows[0]["Design_Min"].ToString();
                    prj.Design_Min_Unit = dt.Rows[0]["Design_Min_Unit"].ToString();
                    prj.Design_Max = dt.Rows[0]["Design_Max"].ToString();
                    prj.Design_Max_Unit = dt.Rows[0]["Design_Max_Unit"].ToString();
                    prj.Normal_System = dt.Rows[0]["Normal_System"].ToString();
                    prj.Normal_System_Unit = dt.Rows[0]["Normal_System_Unit"].ToString();
                    prj.SelectedSeries = dt.Rows[0]["SelectedSeries"].ToString();
                    prj.SelectedOrifice = dt.Rows[0]["SelectedOrifice"].ToString();
                    prj.ValveService = dt.Rows[0]["ValveService"].ToString();
                    prj.CodeSection = dt.Rows[0]["CodeSection"].ToString();
                    prj.ValveOrifice = dt.Rows[0]["ValveOrifice"].ToString();
                    prj.Valve_Size = dt.Rows[0]["Valve_Size"].ToString();
                    prj.Seat_Type = dt.Rows[0]["Seat_Type"].ToString();
                    prj.Seat = dt.Rows[0]["Seat"].ToString();
                    prj.Specific_Gravity = dt.Rows[0]["Specific_Gravity"].ToString();
                    prj.Viscosity = dt.Rows[0]["Viscosity"].ToString();
                    prj.Kv = dt.Rows[0]["Kv"].ToString();
                    prj.V = dt.Rows[0]["V"].ToString();
                    prj.V1 = dt.Rows[0]["V1"].ToString();
                    prj.Operating_Density = dt.Rows[0]["Operating_Density"].ToString();
                    prj.V0 = dt.Rows[0]["V0"].ToString();
                    prj.V90 = dt.Rows[0]["V90"].ToString();
                    prj.VaporPressure = dt.Rows[0]["VaporPressure"].ToString();
                    prj.LiquidDensity = dt.Rows[0]["LiquidDensity"].ToString();
                    prj.LiquidSpecific = dt.Rows[0]["LiquidSpecific"].ToString();
                    prj.SpesificGravity = dt.Rows[0]["SpesificGravity"].ToString();
                    prj.HasRuptureDisk = Convert.ToBoolean(dt.Rows[0]["HasRuptureDisk"].ToString());
                    prj.Current_TabPage_Name = dt.Rows[0]["Current_TabPage_Name"].ToString();
                    prj.ANSIFlangeRating = dt.Rows[0]["ANSIFlangeRating"].ToString();
                    prj.BodyMaterial = dt.Rows[0]["BodyMaterial"].ToString();
                    prj.SpringMaterial = dt.Rows[0]["SpringMaterial"].ToString();
                    prj.TrimMaterial = dt.Rows[0]["TrimMaterial"].ToString();
                    prj.NozzleMaterial = dt.Rows[0]["NozzleMaterial"].ToString();
                    prj.SelectionVIIIApplicationCheckBox = Convert.ToBoolean(dt.Rows[0]["SelectionVIIIApplicationCheckBox"].ToString());
                    prj.chbScrewedCap = Convert.ToBoolean(dt.Rows[0]["chbScrewedCap"].ToString());
                    prj.chbBoltedCap = Convert.ToBoolean(dt.Rows[0]["chbBoltedCap"].ToString());
                    prj.chbAuxiliaryBackupPiston = Convert.ToBoolean(dt.Rows[0]["chbAuxiliaryBackupPiston"].ToString());
                    prj.chbTestGag = Convert.ToBoolean(dt.Rows[0]["chbTestGag"].ToString());
                    prj.chbHighPressure = Convert.ToBoolean(dt.Rows[0]["chbHighPressure"].ToString());
                    prj.chbOpenLever = Convert.ToBoolean(dt.Rows[0]["chbOpenLever"].ToString());
                    prj.chbPackedLever = Convert.ToBoolean(dt.Rows[0]["chbPackedLever"].ToString());
                    prj.chbDomedCap = Convert.ToBoolean(dt.Rows[0]["chbDomedCap"].ToString());
                    prj.chbFerrule = Convert.ToBoolean(dt.Rows[0]["chbFerrule"].ToString());
                    prj.chbGag = Convert.ToBoolean(dt.Rows[0]["chbGag"].ToString());
                    prj.chbNACEMaterial = Convert.ToBoolean(dt.Rows[0]["chbNACEMaterial"].ToString());
                    prj.chbResilientSeat = Convert.ToBoolean(dt.Rows[0]["chbResilientSeat"].ToString());
                    prj.chbRemotePressureSensing = Convert.ToBoolean(dt.Rows[0]["chbRemotePressureSensing"].ToString());
                    prj.chbBackFlowPreventer = Convert.ToBoolean(dt.Rows[0]["chbBackFlowPreventer"].ToString());
                    prj.chbCoolingHeatingCoils = Convert.ToBoolean(dt.Rows[0]["chbCoolingHeatingCoils"].ToString());
                    prj.chbExternalFilter = Convert.ToBoolean(dt.Rows[0]["chbExternalFilter"].ToString());
                    prj.chbLiquidDuty = Convert.ToBoolean(dt.Rows[0]["chbLiquidDuty"].ToString());
                    prj.chbFieldTestConnector = Convert.ToBoolean(dt.Rows[0]["chbFieldTestConnector"].ToString());
                    prj.chbRemoteUnloader = Convert.ToBoolean(dt.Rows[0]["chbRemoteUnloader"].ToString());
                    prj.chbSpecialFeatures = Convert.ToBoolean(dt.Rows[0]["chbSpecialFeatures"].ToString());
                    prj.GasDensity = dt.Rows[0]["GasDensity"].ToString();
                    prj.SpecificValumeGas = dt.Rows[0]["SpecificValumeGas"].ToString();
                    prj.SpecificValumeLiquid = dt.Rows[0]["SpecificValumeLiquid"].ToString();
                    prj.Notes = dt.Rows[0]["Notes"].ToString();
                    prj.VaporFlowCapacity = dt.Rows[0]["VaporFlowCapacity"].ToString();
                    prj.LiquidFlowCapacity = dt.Rows[0]["LiquidFlowCapacity"].ToString();
                    prj.MixDensity90 = dt.Rows[0]["MixDensity90"].ToString();
                    prj.SpVol90 = dt.Rows[0]["SpVol90"].ToString();
                    prj.ViscosityUnit = dt.Rows[0]["ViscosityUnit"].ToString();
                    prj.RequiredPressureFlowUnit = dt.Rows[0]["RequiredPressureFlowUnit"].ToString();
                    prj.RequiredFlowCapacityUnit = dt.Rows[0]["RequiredFlowCapacityUnit"].ToString();
                    prj.DensityUnit = dt.Rows[0]["DensityUnit"].ToString();
                    prj.SpecificValumeUnit = dt.Rows[0]["SpecificValumeUnit"].ToString();
                    prj.VaporFlowCapacityUnit = dt.Rows[0]["VaporFlowCapacityUnit"].ToString();
                    prj.VaporUnitC23 = dt.Rows[0]["VaporUnitC23"].ToString();
                    prj.LiquidDensityUnit = dt.Rows[0]["LiquidDensityUnit"].ToString();
                    prj.LiquidSpecificUnit = dt.Rows[0]["LiquidSpecificUnit"].ToString();
                    prj.chbStandardCertificateOrigin = Convert.ToBoolean(dt.Rows[0]["chbStandardCertificateOrigin"].ToString());
                    prj.chbCertificateConformancePurchaseOrder = Convert.ToBoolean(dt.Rows[0]["chbCertificateConformancePurchaseOrder"].ToString());
                    prj.chbCertificateConformanceNACE_MR0175 = Convert.ToBoolean(dt.Rows[0]["chbCertificateConformanceNACE_MR0175"].ToString());
                    prj.chbCertificateConformanceASMEHydrostaticTesting = Convert.ToBoolean(dt.Rows[0]["chbCertificateConformanceASMEHydrostaticTesting"].ToString());
                    prj.chbMaterialTestReports = Convert.ToBoolean(dt.Rows[0]["chbMaterialTestReports"].ToString());
                    prj.chbHydrostaticTestReportASME = Convert.ToBoolean(dt.Rows[0]["chbHydrostaticTestReportASME"].ToString());
                    prj.chbFunctionalTestReport = Convert.ToBoolean(dt.Rows[0]["chbFunctionalTestReport"].ToString());
                    prj.chbHardnessTestReport = Convert.ToBoolean(dt.Rows[0]["chbHardnessTestReport"].ToString());
                    prj.chbBendTestReportBodyBonnetCasting = Convert.ToBoolean(dt.Rows[0]["chbBendTestReportBodyBonnetCasting"].ToString());
                    prj.chbRadiographyTestReport = Convert.ToBoolean(dt.Rows[0]["chbRadiographyTestReport"].ToString());
                    prj.chbSpecialPainting = Convert.ToBoolean(dt.Rows[0]["chbSpecialPainting"].ToString());
                    prj.IsQuickProject = false;
                    prj.Saved = true;
                    Program.ProjectList.Add(prj);
                    res = Program.ProjectList.FindIndex(item => item.TableId == TableId);

                }
                return res;
            }
            catch
            {
                return 0;
            }
        }

        public static DataTable GetTags()
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dal_gettags = new DAL();
                dal_gettags.StoredProcedureName = "prcGetTagList";
                dt = dal_gettags.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        private static int SaveProjectNewFields(string Id,Telerik.WinControls.UI.RadGridView NewField)
        {
            try
            {
                int result = 0;
                DAL dal_newfields = new DAL();
                dal_newfields.StoredProcedureName = "prcInsertTagsNewField";

                string[,] newparams = new string[3, 2];
                newparams[0, 0] = "@TagHeader_Id";
                newparams[0, 1] = Id;
                for (int i = 0; i < NewField.Rows.Count; i++)
                {
                    newparams[1, 0] = "@NewFieldTitle";
                    newparams[1, 1] = NewField.Rows[i].Cells[0].Value.ToString();

                    newparams[2, 0] = "@NewFieldValue";
                    newparams[2, 1] = NewField.Rows[i].Cells[1].Value.ToString();
                    result = dal_newfields.IntExcuteSP(newparams);
                    if (result == 0)
                        break;
                }

                return result;
            }
            catch
            {
                return 0;
            }

        }

        private static string SaveProjectHeader(int ProjectIndex)
        {
            try
            {
                string id = "-1";
                DAL dal_header = new DAL();
                dal_header.StoredProcedureName = "prcInsertTagsHeader";
                string[,] newparams = new string[11, 2];
                newparams[0, 0] = "@TagNumber";
                newparams[0, 1] = Program.ProjectList[ProjectIndex].Tag_No;

                newparams[1, 0] = "@Project";
                newparams[1, 1] = Program.ProjectList[ProjectIndex].ProjectName;

                newparams[2, 0] = "@P_ID";
                newparams[2, 1] = Program.ProjectList[ProjectIndex].PID_No;

                newparams[3, 0] = "@Service";
                newparams[3, 1] = Program.ProjectList[ProjectIndex].Service;

                newparams[4, 0] = "@LineNumber";
                newparams[4, 1] = Program.ProjectList[ProjectIndex].Line_No;

                newparams[5, 0] = "@Quentity";
                newparams[5, 1] = Program.ProjectList[ProjectIndex].Quantity;

                newparams[6, 0] = "@Customer";
                newparams[6, 1] = Program.ProjectList[ProjectIndex].Client;

                newparams[7, 0] = "@CustomerRefNo";
                newparams[7, 1] = Program.ProjectList[ProjectIndex].End_User_Ref;

                newparams[8, 0] = "@RadmanRefNo";
                newparams[8, 1] = Program.ProjectList[ProjectIndex].RadmanRef;

                newparams[9, 0] = "@ProjectRefNo";
                newparams[9, 1] = Program.ProjectList[ProjectIndex].Project_Ref;

                newparams[10, 0] = "@Location";
                newparams[10, 1] = Program.ProjectList[ProjectIndex].Location;

                DataTable dt = new DataTable();
                dt = dal_header.ExcecuteQueryToDataTable(newparams);
                if (dt != null)
                {
                    id = dt.Rows[0]["Id"].ToString();
                }
                return id;
            }
            catch
            {
                return null;
            }

        }
        public static string IsTagExist(string TagNo)
        {
            try
            {
                string projectId = "";
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcFindProjectId";
                string[,] newparams = new string[1, 2];

                newparams[0, 0] = "@TagNumber";
                newparams[0, 1] = TagNo;

                int result = dal.IntExcuteSP(newparams);
                projectId = result.ToString();
                return projectId;
            }
            catch
            {
                return null;
            }
        }
        public static int GetFluidList()
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetFluidList";
                dt = dal.ExcecuteStoredProcedureToDataTable();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                            int type = Convert.ToInt32(dt.Rows[i]["FluidsId"].ToString());
                            if (type == 1)
                            {
                                string name = dt.Rows[i]["Name"].ToString();
                                decimal mw = 0;
                                if (dt.Rows[i]["MolecularWeight"].ToString() != "")
                                    mw = Convert.ToDecimal(dt.Rows[i]["MolecularWeight"].ToString());
                                decimal k = 0;
                                if (dt.Rows[i]["K"].ToString() != "")
                                    k = Convert.ToDecimal(dt.Rows[i]["K"].ToString());
                                decimal compres = 0;
                                if (dt.Rows[i]["Compressibility"].ToString() != "")
                                    compres = Convert.ToDecimal(dt.Rows[i]["Compressibility"].ToString());
                                Program.FluidList.Add(new Fluid(id, name, type, mw, k, compres));
                            }
                            if (type == 2)
                            {
                                string name = dt.Rows[i]["Name"].ToString();
                                decimal sg = 0;
                                if (dt.Rows[i]["SpecificGravity"].ToString() != "")
                                    sg = Convert.ToDecimal(dt.Rows[i]["SpecificGravity"].ToString());
                                decimal v = 0;
                                if (dt.Rows[i]["Viscosity"].ToString() != "")
                                    v = Convert.ToDecimal(dt.Rows[i]["Viscosity"].ToString());
                                Program.FluidList.Add(new Fluid(id, name, type, sg, v));
                            }
                        }
                        return 0; // no error

                    }
                    else
                        return -1; //Table in SQL server is empty

                }
                else
                    return -2; // Error in SQL Server
            }
            catch
            {
                return -3;
            }

        }

        public static string ConvertMassToVolume_Gas_SI(string FromUnit, string ToUnit, decimal Value, string Relieving,string RelievingUnit, string MolecularWeight, string AtmPressure,string AtmPressureUnit,string SetPressure,string SetPressureUnit)
        {
            try
            {
                string result = "";
                if (Relieving == "" || MolecularWeight == "" || SetPressure == "" || AtmPressure == "")
                    return result;
                decimal T = ConvertTempToKelvin(Relieving, RelievingUnit);
                decimal R = 8314 / Convert.ToDecimal(MolecularWeight);
                decimal sp;
                decimal atp;
                decimal m_dot;
                decimal Q;
                int index_sp = Program.UnitsList.FindIndex(item => item.Name == SetPressureUnit && item.Base == "Pa g");
                if (index_sp == -1)
                    sp = Convert.ToDecimal(SetPressure);
                else
                    sp = Convert.ToDecimal(SetPressure) * Program.UnitsList[index_sp].K;
                int index_atp = Program.UnitsList.FindIndex(item => item.Name == AtmPressureUnit && item.Base == "Pa a");
                if (index_atp == -1)
                    atp = Convert.ToDecimal(AtmPressure);
                else
                    atp = Convert.ToDecimal(AtmPressure) * Program.UnitsList[index_atp].K;
                decimal P = sp + atp;
                decimal ro = P / (R * T);
                int index_m = Program.UnitsList.FindIndex(item => item.Name == FromUnit && item.Base == "kg/min");
                if (index_m == -1)
                    m_dot = Value;
                else
                    m_dot = Value * Program.UnitsList[index_m].K;
                decimal q = m_dot / ro;   //m3/min
                int index_q = Program.UnitsList.FindIndex(item => item.Name == "m³/min" && item.Base == ToUnit);
                if (index_q == -1)
                    Q = q;
                else
                    Q = q * Program.UnitsList[index_q].K;
                result = Convert.ToString(Math.Round(Q, 2));
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string ConvertMassToVolume_Gas_BRITISH(string FromUnit, string ToUnit, decimal Value, string Relieving, string RelievingUnit, string MolecularWeight, string AtmPressure, string AtmPressureUnit, string SetPressure, string SetPressureUnit)
        {
            try
            {
                string result = "";
                if (Relieving == "" || MolecularWeight == "" || SetPressure == "" || AtmPressure == "")
                    return result;
                decimal T = ConvertTempToRankine(Relieving, RelievingUnit);
                decimal R = 1545 / Convert.ToDecimal(MolecularWeight);
                decimal sp;
                decimal atp;
                decimal m_dot;
                decimal Q;
                int index_sp = Program.UnitsList.FindIndex(item => item.Name == SetPressureUnit && item.Base == "psig");
                if (index_sp == -1)
                    sp = Convert.ToDecimal(SetPressure);
                else
                    sp = Convert.ToDecimal(SetPressure) * Program.UnitsList[index_sp].K;

                int index_atp = Program.UnitsList.FindIndex(item => item.Name == AtmPressureUnit && item.Base == "psia");
                if (index_atp == -1)
                    atp = Convert.ToDecimal(AtmPressure);
                else
                    atp = Convert.ToDecimal(AtmPressure) * Program.UnitsList[index_atp].K;
                decimal P = sp + atp;
                decimal ro = (144 * P) / (R * T);
                int index_m = Program.UnitsList.FindIndex(item => item.Name == FromUnit && item.Base == "lb/min");
                if (index_m == -1)
                    m_dot = Value;
                else
                    m_dot = Value * Program.UnitsList[index_m].K;
                decimal q = m_dot / ro;   //ft3/min
                int index_q = Program.UnitsList.FindIndex(item => item.Name == "ft³/min" && item.Base == ToUnit);
                if (index_q == -1)
                    Q = q;
                else
                    Q = q * Program.UnitsList[index_q].K;
                result = Convert.ToString(Math.Round(Q, 2));
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string ConvertVolumeToMass_Gas_BRITISH(string FromUnit, string ToUnit, decimal Value, string Relieving, string RelievingUnit, string MolecularWeight, string AtmPressure, string AtmPressureUnit, string SetPressure, string SetPressureUnit)
        {
            try
            {
                string result = "";
                if (Relieving == "" || MolecularWeight == "" || SetPressure == "" || AtmPressure == "")
                    return result;
                decimal T = ConvertTempToRankine(Relieving, RelievingUnit);
                decimal R = 1545 / Convert.ToDecimal(MolecularWeight);
                decimal sp;
                decimal atp;
                decimal m_dot;
                decimal M_Dot;
                decimal Q = 0;
                int index_sp = Program.UnitsList.FindIndex(item => item.Name == SetPressureUnit && item.Base == "psig");
                if (index_sp == -1)
                    sp = Convert.ToDecimal(SetPressure);
                else
                    sp = Convert.ToDecimal(SetPressure) * Program.UnitsList[index_sp].K;
                int index_atp = Program.UnitsList.FindIndex(item => item.Name == AtmPressureUnit && item.Base == "psia");
                if (index_atp == -1)
                    atp = Convert.ToDecimal(AtmPressure);
                else
                    atp = Convert.ToDecimal(AtmPressure) * Program.UnitsList[index_atp].K;
                decimal P = sp + atp;
                decimal ro = (144 * P) / (R * T);

                int index_q = Program.UnitsList.FindIndex(item => item.Name == FromUnit && item.Base == "ft³/min");
                if (index_q == -1)
                {
                    if (FromUnit == "ft³/min")
                        Q = Value;
                    else
                    {
                        switch (FromUnit)
                        {
                            case "MMSCFD":
                            case "MMSCFH":
                            case "MMSCFM":
                            case "SCFM":
                            case "SCFD":
                            case "SCFH":
                            case "SCFS":
                            case "Sm³/hr":
                            case "Sm³/min":
                                {
                                    Q = (decimal)1.08 * Value * (((144 * atp) / (R * (decimal)519.67)) / ((144 * (decimal)1.08 * (sp + atp)) / (R * T)));
                                    break;
                                }
                            case "Nm³/day":
                            case "Nm³/hr":
                            case "Nm³/min":
                            case "Nm³/s":
                                {
                                    Q = (decimal)1.08 * Value * (((144 * atp) / (R * (decimal)491.67)) / ((144 * (decimal)1.08 * (sp + atp)) / (R * T)));
                                    break;
                                }
                        }
                        switch (ToUnit)
                        {
                            case "MMSCFD":
                            case "MMSCFH":
                            case "MMSCFM":
                            case "SCFM":
                            case "SCFD":
                            case "SCFH":
                            case "SCFS":
                            case "Sm³/hr":
                            case "Sm³/min":
                                {
                                    Q = 1 / ((decimal)1.08 * Value * (((144 * atp) / (R * (decimal)519.67)) / ((144 * (decimal)1.08 * (sp + atp)) / (R * T))));
                                    break;
                                }
                            case "Nm³/day":
                            case "Nm³/hr":
                            case "Nm³/min":
                            case "Nm³/s":
                                {
                                    Q = 1 / ((decimal)1.08 * Value * (((144 * atp) / (R * (decimal)491.67)) / ((144 * (decimal)1.08 * (sp + atp)) / (R * T))));
                                    break;
                                }
                        }

                    }
                }
                else
                    Q = Value * Program.UnitsList[index_q].K;
                m_dot = Q * ro;   //lb/min
                int index_m = Program.UnitsList.FindIndex(item => item.Name == "lb/min" && item.Base == ToUnit);
                if (index_m == -1)
                    M_Dot = m_dot;
                else
                    M_Dot = m_dot * Program.UnitsList[index_m].K;
                result = Convert.ToString(Math.Round(M_Dot, 2));
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string ConvertVolumeToMass_Gas_SI(string FromUnit, string ToUnit, decimal Value, string Relieving, string RelievingUnit, string MolecularWeight, string AtmPressure, string AtmPressureUnit, string SetPressure, string SetPressureUnit)
        {
            try
            {
                string result = "";
                if (Relieving == "" || MolecularWeight == "" || SetPressure == "" || AtmPressure == "")
                    return result;
                decimal T = ConvertTempToKelvin(Relieving, RelievingUnit);
                decimal R = 8314 / Convert.ToDecimal(MolecularWeight);
                decimal sp;
                decimal atp;
                decimal m_dot;
                decimal M_Dot;
                decimal Q;
                int index_sp = Program.UnitsList.FindIndex(item => item.Name == SetPressureUnit && item.Base == "Pa g");
                if (index_sp == -1)
                    sp = Convert.ToDecimal(SetPressure);
                else
                    sp = Convert.ToDecimal(SetPressure) * Program.UnitsList[index_sp].K;
                int index_atp = Program.UnitsList.FindIndex(item => item.Name == AtmPressureUnit && item.Base == "Pa a");
                if (index_atp == -1)
                    atp = Convert.ToDecimal(AtmPressure);
                else
                    atp = Convert.ToDecimal(AtmPressure) * Program.UnitsList[index_atp].K;
                decimal P = sp + atp;
                decimal ro = P / (R * T);

                int index_q = Program.UnitsList.FindIndex(item => item.Name == FromUnit && item.Base == "m³/min");
                if (index_q == -1)
                    Q = Value;
                else
                    Q = Value * Program.UnitsList[index_q].K;
                m_dot = Q * ro;   //kg/min
                int index_m = Program.UnitsList.FindIndex(item => item.Name == "kg/min" && item.Base == ToUnit);
                if (index_m == -1)
                    M_Dot = m_dot;
                else
                    M_Dot = m_dot * Program.UnitsList[index_m].K;
                result = Convert.ToString(Math.Round(M_Dot, 2));
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string ConvertUnit(string FromUnit,string ToUnit,decimal Value,string FluidType)
        {
            try
            {
                string result = "";
                if (FromUnit == ToUnit)
                {
                    result = Convert.ToString(Value);
                    return result;
                }
                int index_unit = Program.UnitsList.FindIndex(item => item.Base == ToUnit && item.Name == FromUnit);
                if (index_unit != -1)
                {
                    decimal k = Program.UnitsList[index_unit].K;
                    decimal res = Value * k;
                    result = Convert.ToString(Math.Round(res, 2));
                    return result;
                }
                else
                {

                    if (FluidType == "Gas")
                    {
                        switch (FromUnit)
                        {
                            case "kg/day":
                            case "kg/hr":
                            case "kg/min":
                            case "kg/s":
                            case "Ton,long/day":
                            case "Ton,long/hr":
                            case "Ton,long/s":
                            case "Ton(US)/day":
                            case "Ton(US)/hr":
                            case "Ton(US)/s":
                            case "Ton(mt)/day":
                            case "Ton(mt)/hr":
                            case "Ton(mt)/s":
                                {
                                    result = "MassToVolume_Gas_SI";
                                    break;
                                }
                            case "lb/day":
                            case "lb/hr":
                            case "lb/min":
                            case "lb/s":
                                {
                                    result = "MassToVolume_Gas_BRITISH";
                                    break;
                                }
                            case "SCFS":
                            case "SCFM":
                            case "SCFH":
                            case "SCFD":
                            case "MMSCFM":
                            case "MMSCFH":
                            case "MMSCFD":
                            case "ft³/s":
                            case "ft³/min":
                            case "ft³/hr":
                            case "ft³/day":
                                {
                                    result = "VolumeToMass_Gas_BRITISH";
                                    break;
                                }
                            case "Sm³/min":
                            case "Sm³/hr":
                            case "Nm³/ s":
                            case "Nm³/min":
                            case "Nm³/hr":
                            case "Nm³/day":
                            case "m³/hr":
                            case "m³/s":
                            case "m³/min":
                            case "m³/day":
                                {
                                    result = "VolumeToMass_Gas_SI";
                                    break;
                                }
                        }
                    }
                    if (FluidType == "Liquid")
                    {
                        switch (FromUnit)
                        {
                            case "kg/day":
                            case "kg/hr":
                            case "kg/min":
                            case "kg/s":
                            case "lb/day":
                            case "lb/hr":
                            case "lb/min":
                            case "lb/s":
                            case "Ton,long/day":
                            case "Ton,long/hr":
                            case "Ton,long/s":
                            case "Ton(US)/day":
                            case "Ton(US)/hr":
                            case "Ton(US)/s":
                            case "Ton(mt)/day":
                            case "Ton(mt)/hr":
                            case "Ton(mt)/s":
                                {
                                    result = "Liquid_Type1";
                                    break;
                                }
                            default:
                                {
                                    result = "Liquid_Type2";
                                    break;
                                }

                        }
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static void FillUnitsList()
        {
            try
            {
                //OK
                Program.UnitsList.Add(new Units("atm a", "psia", (decimal)14.696));
                Program.UnitsList.Add(new Units("bara", "psia", (decimal)14.504));
                Program.UnitsList.Add(new Units("ft wc a", "psia", (decimal)0.434));
                Program.UnitsList.Add(new Units("in Hg a", "psia", (decimal)0.491));
                Program.UnitsList.Add(new Units("in wc a", "psia", (decimal)0.036));
                Program.UnitsList.Add(new Units("kg/cm² a", "psia", (decimal)14.223));
                Program.UnitsList.Add(new Units("kPa a", "psia", (decimal)0.145));
                Program.UnitsList.Add(new Units("lb/ft² a", "psia", (decimal)0.007));
                Program.UnitsList.Add(new Units("mbara", "psia", (decimal)0.015));
                Program.UnitsList.Add(new Units("meter H2O a", "psia", (decimal)1.422));
                Program.UnitsList.Add(new Units("mm H2O a", "psia", (decimal)0.001));
                Program.UnitsList.Add(new Units("mm Hg a", "psia", (decimal)0.019));
                Program.UnitsList.Add(new Units("Mpa a", "psia", (decimal)145.038));
                Program.UnitsList.Add(new Units("oz/in² a", "psia", (decimal)0.062));
                Program.UnitsList.Add(new Units("Pa a", "psia", (decimal)0.0001));
                Program.UnitsList.Add(new Units("Torr a", "psia", (decimal)0.019));

                //OK
                Program.UnitsList.Add(new Units("bara", "atm a", (decimal)0.987));
                Program.UnitsList.Add(new Units("ft wc a", "atm a", (decimal)0.029));
                Program.UnitsList.Add(new Units("in Hg a", "atm a", (decimal)0.033));
                Program.UnitsList.Add(new Units("in wc a", "atm a", (decimal)0.002));
                Program.UnitsList.Add(new Units("kg/cm² a", "atm a", (decimal)0.968));
                Program.UnitsList.Add(new Units("kPa a", "atm a", (decimal)0.010));
                Program.UnitsList.Add(new Units("lb/ft² a", "atm a", (decimal)0.0005));
                Program.UnitsList.Add(new Units("mbara", "atm a", (decimal)0.001));
                Program.UnitsList.Add(new Units("meter H2O a", "atm a", (decimal)0.097));
                Program.UnitsList.Add(new Units("mm H2O a", "atm a", (decimal)0.0001));
                Program.UnitsList.Add(new Units("mm Hg a", "atm a", (decimal)0.001));
                Program.UnitsList.Add(new Units("Mpa a", "atm a", (decimal)9.869));
                Program.UnitsList.Add(new Units("oz/in² a", "atm a", (decimal)0.004));
                Program.UnitsList.Add(new Units("Pa a", "atm a", (decimal)0.00001));
                Program.UnitsList.Add(new Units("psia", "atm a", (decimal)0.068));
                Program.UnitsList.Add(new Units("Torr a", "atm a", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("atm a", "bara", (decimal)1.013));
                Program.UnitsList.Add(new Units("ft wc a", "bara", (decimal)0.030));
                Program.UnitsList.Add(new Units("in Hg a", "bara", (decimal)0.034));
                Program.UnitsList.Add(new Units("in wc a", "bara", (decimal)0.002));
                Program.UnitsList.Add(new Units("kg/cm² a", "bara", (decimal)0.981));
                Program.UnitsList.Add(new Units("kPa a", "bara", (decimal)0.010));
                Program.UnitsList.Add(new Units("lb/ft² a", "bara", (decimal)0.0005));
                Program.UnitsList.Add(new Units("mbara", "bara", (decimal)0.001));
                Program.UnitsList.Add(new Units("meter H2O a", "bara", (decimal)0.098));
                Program.UnitsList.Add(new Units("mm H2O g", "barg", (decimal)0.0001));
                Program.UnitsList.Add(new Units("mm Hg a", "bara", (decimal)0.001));
                Program.UnitsList.Add(new Units("Mpa a", "bara", (decimal)10));
                Program.UnitsList.Add(new Units("oz/in² a", "bara", (decimal)0.004));
                Program.UnitsList.Add(new Units("Pa a", "bara", (decimal)0.00001));
                Program.UnitsList.Add(new Units("psia", "bara", (decimal)0.069));
                Program.UnitsList.Add(new Units("Torr a", "bara", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("atm a", "ft wc a", (decimal)33.899));
                Program.UnitsList.Add(new Units("bara", "ft wc a", (decimal)33.455));
                Program.UnitsList.Add(new Units("in Hg a", "ft wc a", (decimal)1.133));
                Program.UnitsList.Add(new Units("in wc a", "ft wc a", (decimal)0.083));
                Program.UnitsList.Add(new Units("kg/cm² a", "ft wc a", (decimal)32.808));
                Program.UnitsList.Add(new Units("kPa a", "ft wc a", (decimal)0.335));
                Program.UnitsList.Add(new Units("lb/ft² a", "ft wc a", (decimal)0.016));
                Program.UnitsList.Add(new Units("mbara", "ft wc a", (decimal)0.033));
                Program.UnitsList.Add(new Units("meter H2O a", "ft wc a", (decimal)3.281));
                Program.UnitsList.Add(new Units("mm H2O a", "ft wc a", (decimal)0.003));
                Program.UnitsList.Add(new Units("mm Hg a", "ft wc a", (decimal)0.045));
                Program.UnitsList.Add(new Units("Mpa a", "ft wc a", (decimal)334.553));
                Program.UnitsList.Add(new Units("oz/in² a", "ft wc a", (decimal)0.144));
                Program.UnitsList.Add(new Units("Pa a", "ft wc a", (decimal)0.0003));
                Program.UnitsList.Add(new Units("psia", "ft wc a", (decimal)2.307));
                Program.UnitsList.Add(new Units("Torr a", "ft wc a", (decimal)0.045));

                //OK
                Program.UnitsList.Add(new Units("atm a", "in Hg a", (decimal)29.921));
                Program.UnitsList.Add(new Units("bara", "in Hg a", (decimal)29.530));
                Program.UnitsList.Add(new Units("ft wc a", "in Hg a", (decimal)0.883));
                Program.UnitsList.Add(new Units("in wc a", "in Hg a", (decimal)0.074));
                Program.UnitsList.Add(new Units("kg/cm² a", "in Hg a", (decimal)28.959));
                Program.UnitsList.Add(new Units("kPa a", "in Hg a", (decimal)0.295));
                Program.UnitsList.Add(new Units("lb/ft² a", "in Hg a", (decimal)0.014));
                Program.UnitsList.Add(new Units("mbara", "in Hg a", (decimal)0.03));
                Program.UnitsList.Add(new Units("meter H2O a", "in Hg a", (decimal)2.896));
                Program.UnitsList.Add(new Units("mm H2O a", "in Hg a", (decimal)0.003));
                Program.UnitsList.Add(new Units("mm Hg a", "in Hg a", (decimal)0.039));
                Program.UnitsList.Add(new Units("Mpa a", "in Hg a", (decimal)295.3));
                Program.UnitsList.Add(new Units("oz/in² a", "in Hg a", (decimal)0.127));
                Program.UnitsList.Add(new Units("Pa a", "in Hg a", (decimal)0.0003));
                Program.UnitsList.Add(new Units("psia", "in Hg a", (decimal)2.036));
                Program.UnitsList.Add(new Units("Torr a", "in Hg a", (decimal)0.039));

                //OK
                Program.UnitsList.Add(new Units("atm a", "in wc a", (decimal)406.782));
                Program.UnitsList.Add(new Units("bara", "in wc a", (decimal)401.463));
                Program.UnitsList.Add(new Units("ft wc a", "in wc a", (decimal)12));
                Program.UnitsList.Add(new Units("in Hg a", "in wc a", (decimal)13.595));
                Program.UnitsList.Add(new Units("kg/cm² a", "in wc a", (decimal)393.701));
                Program.UnitsList.Add(new Units("kPa a", "in wc a", (decimal)4.015));
                Program.UnitsList.Add(new Units("lb/ft² a", "in wc a", (decimal)0.192));
                Program.UnitsList.Add(new Units("mbara", "in wc a", (decimal)0.401));
                Program.UnitsList.Add(new Units("meter H2O a", "in wc a", (decimal)39.370));
                Program.UnitsList.Add(new Units("mm H2O a", "in wc a", (decimal)0.039));
                Program.UnitsList.Add(new Units("mm Hg a", "in wc a", (decimal)0.535));
                Program.UnitsList.Add(new Units("Mpa a", "in wc a", (decimal)4014.631));
                Program.UnitsList.Add(new Units("oz/in² a", "in wc a", (decimal)1.730));
                Program.UnitsList.Add(new Units("Pa a", "in wc a", (decimal)0.004));
                Program.UnitsList.Add(new Units("psia", "in wc a", (decimal)27.680));
                Program.UnitsList.Add(new Units("Torr a", "in wc a", (decimal)0.535));

                //OK
                Program.UnitsList.Add(new Units("atm a", "kg/cm² a", (decimal)1.0332));
                Program.UnitsList.Add(new Units("bara", "kg/cm² a", (decimal)1.02));
                Program.UnitsList.Add(new Units("ft wc a", "kg/cm² a", (decimal)0.03));
                Program.UnitsList.Add(new Units("in Hg a", "kg/cm² a", (decimal)0.035));
                Program.UnitsList.Add(new Units("in wc a", "kg/cm² a", (decimal)0.003));
                Program.UnitsList.Add(new Units("kPa a", "kg/cm² a", (decimal)0.01));
                Program.UnitsList.Add(new Units("lb/ft² a", "kg/cm² a", (decimal)0.0005));
                Program.UnitsList.Add(new Units("mbara", "kg/cm² a", (decimal)0.001));
                Program.UnitsList.Add(new Units("meter H2O a", "kg/cm² a", (decimal)0.1));
                Program.UnitsList.Add(new Units("mm H2O a", "kg/cm² a", (decimal)0.0001));
                Program.UnitsList.Add(new Units("mm Hg a", "kg/cm² a", (decimal)0.001));
                Program.UnitsList.Add(new Units("Mpa a", "kg/cm² a", (decimal)10.197));
                Program.UnitsList.Add(new Units("oz/in² a", "kg/cm² a", (decimal)0.004));
                Program.UnitsList.Add(new Units("Pa a", "kg/cm² a", (decimal)0.00001));
                Program.UnitsList.Add(new Units("psia", "kg/cm² a", (decimal)0.07));
                Program.UnitsList.Add(new Units("Torr a", "kg/cm² a", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("atm a", "kPa a", (decimal)101.325));
                Program.UnitsList.Add(new Units("bara", "kPa a", (decimal)100));
                Program.UnitsList.Add(new Units("ft wc a", "kPa a", (decimal)2.989));
                Program.UnitsList.Add(new Units("in Hg a", "kPa a", (decimal)3.386));
                Program.UnitsList.Add(new Units("in wc a", "kPa a", (decimal)0.249));
                Program.UnitsList.Add(new Units("kg/cm² a", "kPa a", (decimal)98.066));
                Program.UnitsList.Add(new Units("lb/ft² a", "kPa a", (decimal)0.048));
                Program.UnitsList.Add(new Units("mbara", "kPa a", (decimal)0.1));
                Program.UnitsList.Add(new Units("meter H2O a", "kPa a", (decimal)9.807));
                Program.UnitsList.Add(new Units("mm H2O a", "kPa a", (decimal)0.01));
                Program.UnitsList.Add(new Units("mm Hg a", "kPa a", (decimal)0.133));
                Program.UnitsList.Add(new Units("Mpa a", "kPa a", (decimal)1000));
                Program.UnitsList.Add(new Units("oz/in² a", "kPa a", (decimal)0.431));
                Program.UnitsList.Add(new Units("Pa a", "kPa a", (decimal)0.001));
                Program.UnitsList.Add(new Units("psia", "kPa a", (decimal)6.895));
                Program.UnitsList.Add(new Units("Torr a", "kPa a", (decimal)0.133));

                //OK
                Program.UnitsList.Add(new Units("atm a", "lb/ft² a", (decimal)2116.217));
                Program.UnitsList.Add(new Units("bara", "lb/ft² a", (decimal)2088.543));
                Program.UnitsList.Add(new Units("ft wc a", "lb/ft² a", (decimal)62.428));
                Program.UnitsList.Add(new Units("in Hg a", "lb/ft² a", (decimal)70.726));
                Program.UnitsList.Add(new Units("in wc a", "lb/ft² a", (decimal)5.202));
                Program.UnitsList.Add(new Units("kg/cm² a", "lb/ft² a", (decimal)2048.161));
                Program.UnitsList.Add(new Units("kPa a", "lb/ft² a", (decimal)20.885));
                Program.UnitsList.Add(new Units("mbara", "lb/ft² a", (decimal)2.089));
                Program.UnitsList.Add(new Units("meter H2O a", "lb/ft² a", (decimal)204.816));
                Program.UnitsList.Add(new Units("mm H2O a", "lb/ft² a", (decimal)0.205));
                Program.UnitsList.Add(new Units("mm Hg a", "lb/ft² a", (decimal)2.784));
                Program.UnitsList.Add(new Units("Mpa a", "lb/ft² a", (decimal)20885.434));
                Program.UnitsList.Add(new Units("oz/in² a", "lb/ft² a", (decimal)9));
                Program.UnitsList.Add(new Units("Pa a", "lb/ft² a", (decimal)0.021));
                Program.UnitsList.Add(new Units("psia", "lb/ft² a", (decimal)144));
                Program.UnitsList.Add(new Units("Torr a", "lb/ft² a", (decimal)2.784));

                //OK
                Program.UnitsList.Add(new Units("atm a", "mbara", (decimal)1013.250));
                Program.UnitsList.Add(new Units("bara", "mbara", (decimal)1000));
                Program.UnitsList.Add(new Units("ft wc a", "mbara", (decimal)29.891));
                Program.UnitsList.Add(new Units("in Hg a", "mbara", (decimal)33.864));
                Program.UnitsList.Add(new Units("in wc a", "mbara", (decimal)2.491));
                Program.UnitsList.Add(new Units("kg/cm² a", "mbara", (decimal)980.665));
                Program.UnitsList.Add(new Units("kPa a", "mbara", (decimal)10));
                Program.UnitsList.Add(new Units("lb/ft² a", "mbara", (decimal)0.479));
                Program.UnitsList.Add(new Units("meter H2O a", "mbara", (decimal)98.066));
                Program.UnitsList.Add(new Units("mm H2O a", "mbara", (decimal)0.098));
                Program.UnitsList.Add(new Units("mm Hg a", "mbara", (decimal)1.333));
                Program.UnitsList.Add(new Units("Mpa a", "mbara", (decimal)10000));
                Program.UnitsList.Add(new Units("oz/in² a", "mbara", (decimal)4.309));
                Program.UnitsList.Add(new Units("Pa a", "mbara", (decimal)0.01));
                Program.UnitsList.Add(new Units("psia", "mbara", (decimal)68.948));
                Program.UnitsList.Add(new Units("Torr a", "mbara", (decimal)1.333));

                //OK
                Program.UnitsList.Add(new Units("atm a", "meter H2O a", (decimal)10.332));
                Program.UnitsList.Add(new Units("bara", "meter H2O a", (decimal)10.197));
                Program.UnitsList.Add(new Units("ft wc a", "meter H2O a", (decimal)0.305));
                Program.UnitsList.Add(new Units("in Hg a", "meter H2O a", (decimal)0.345));
                Program.UnitsList.Add(new Units("in wc a", "meter H2O a", (decimal)0.025));
                Program.UnitsList.Add(new Units("kg/cm² a", "meter H2O a", (decimal)10));
                Program.UnitsList.Add(new Units("kPa a", "meter H2O a", (decimal)0.102));
                Program.UnitsList.Add(new Units("lb/ft² a", "meter H2O a", (decimal)0.005));
                Program.UnitsList.Add(new Units("mbara", "meter H2O a", (decimal)0.01));
                Program.UnitsList.Add(new Units("mm H2O a", "meter H2O a", (decimal)0.001));
                Program.UnitsList.Add(new Units("mm Hg a", "meter H2O a", (decimal)0.014));
                Program.UnitsList.Add(new Units("Mpa a", "meter H2O a", (decimal)101.972));
                Program.UnitsList.Add(new Units("oz/in² a", "meter H2O a", (decimal)0.044));
                Program.UnitsList.Add(new Units("Pa a", "meter H2O a", (decimal)0.0001));
                Program.UnitsList.Add(new Units("psia", "meter H2O a", (decimal)0.703));
                Program.UnitsList.Add(new Units("Torr a", "meter H2O a", (decimal)0.014));

                //OK
                Program.UnitsList.Add(new Units("atm a", "mm H2O a", (decimal)10332.275));
                Program.UnitsList.Add(new Units("bara", "mm H2O a", (decimal)10197.162));
                Program.UnitsList.Add(new Units("ft wc a", "mm H2O a", (decimal)304.8));
                Program.UnitsList.Add(new Units("in Hg a", "mm H2O a", (decimal)345.315));
                Program.UnitsList.Add(new Units("in wc a", "mm H2O a", (decimal)25.400));
                Program.UnitsList.Add(new Units("kg/cm² a", "mm H2O a", (decimal)10000));
                Program.UnitsList.Add(new Units("kPa a", "mm H2O a", (decimal)101.972));
                Program.UnitsList.Add(new Units("lb/ft² a", "mm H2O a", (decimal)4.882));
                Program.UnitsList.Add(new Units("mbara", "mm H2O a", (decimal)10.197));
                Program.UnitsList.Add(new Units("meter H2O a", "mm H2O a", (decimal)1000));
                Program.UnitsList.Add(new Units("mm Hg a", "mm H2O a", (decimal)13.595));
                Program.UnitsList.Add(new Units("Mpa a", "mm H2O a", (decimal)101971.621));
                Program.UnitsList.Add(new Units("oz/in² a", "mm H2O a", (decimal)43.942));
                Program.UnitsList.Add(new Units("Pa a", "mm H2O a", (decimal)0.102));
                Program.UnitsList.Add(new Units("psia", "mm H2O a", (decimal)703.070));
                Program.UnitsList.Add(new Units("Torr a", "mm H2O a", (decimal)13.595));

                //OK
                Program.UnitsList.Add(new Units("atm a", "mm Hg a", (decimal)760));
                Program.UnitsList.Add(new Units("bara", "mm Hg a", (decimal)750.062));
                Program.UnitsList.Add(new Units("ft wc a", "mm Hg a", (decimal)22.420));
                Program.UnitsList.Add(new Units("in Hg a", "mm Hg a", (decimal)25.4));
                Program.UnitsList.Add(new Units("in wc a", "mm Hg a", (decimal)1.868));
                Program.UnitsList.Add(new Units("kg/cm² a", "mm Hg a", (decimal)735.559));
                Program.UnitsList.Add(new Units("kPa a", "mm Hg a", (decimal)7.501));
                Program.UnitsList.Add(new Units("lb/ft² a", "mm Hg a", (decimal)0.359));
                Program.UnitsList.Add(new Units("mbara", "mm Hg a", (decimal)0.750));
                Program.UnitsList.Add(new Units("meter H2O a", "mm Hg a", (decimal)73.556));
                Program.UnitsList.Add(new Units("mm H2O a", "mm Hg a", (decimal)0.074));
                Program.UnitsList.Add(new Units("Mpa a", "mm Hg a", (decimal)7500.617));
                Program.UnitsList.Add(new Units("oz/in² a", "mm Hg a", (decimal)3.232));
                Program.UnitsList.Add(new Units("Pa a", "mm Hg a", (decimal)7500.617));
                Program.UnitsList.Add(new Units("psia", "mm Hg a", (decimal)51.715));
                Program.UnitsList.Add(new Units("Torr a", "mm Hg a", (decimal)1));

                //OK
                Program.UnitsList.Add(new Units("atm a", "Mpa a", (decimal)0.101));
                Program.UnitsList.Add(new Units("bara", "Mpa a", (decimal)0.1));
                Program.UnitsList.Add(new Units("ft wc a", "Mpa a", (decimal)0.003));
                Program.UnitsList.Add(new Units("in Hg a", "Mpa a", (decimal)0.003));
                Program.UnitsList.Add(new Units("in wc a", "Mpa a", (decimal)0.0002));
                Program.UnitsList.Add(new Units("kg/cm² a", "Mpa a", (decimal)0.098));
                Program.UnitsList.Add(new Units("kPa a", "Mpa a", (decimal)0.001));
                Program.UnitsList.Add(new Units("lb/ft² a", "Mpa a", (decimal)0.00005));
                Program.UnitsList.Add(new Units("mbara", "Mpa a", (decimal)0.0001));
                Program.UnitsList.Add(new Units("meter H2O a", "Mpa a", (decimal)0.01));
                Program.UnitsList.Add(new Units("mm H2O a", "Mpa a", (decimal)0.00001));
                Program.UnitsList.Add(new Units("mm Hg a", "Mpa a", (decimal)0.0001));
                Program.UnitsList.Add(new Units("oz/in² a", "Mpa a", (decimal)0.0004));
                Program.UnitsList.Add(new Units("Pa a", "Mpa a", (decimal)0.000001));
                Program.UnitsList.Add(new Units("psia", "Mpa a", (decimal)0.007));
                Program.UnitsList.Add(new Units("Torr a", "Mpa a", (decimal)0.0001));

                //OK
                Program.UnitsList.Add(new Units("atm a", "oz/in² a", (decimal)235.135));
                Program.UnitsList.Add(new Units("bara", "oz/in² a", (decimal)232.06));
                Program.UnitsList.Add(new Units("ft wc a", "oz/in² a", (decimal)6.936));
                Program.UnitsList.Add(new Units("in Hg a", "oz/in² a", (decimal)7.858));
                Program.UnitsList.Add(new Units("in wc a", "oz/in² a", (decimal)0.578));
                Program.UnitsList.Add(new Units("kg/cm² a", "oz/in² a", (decimal)227.573));
                Program.UnitsList.Add(new Units("kPa a", "oz/in² a", (decimal)2.321));
                Program.UnitsList.Add(new Units("lb/ft² a", "oz/in² a", (decimal)0.111));
                Program.UnitsList.Add(new Units("mbara", "oz/in² a", (decimal)0.232));
                Program.UnitsList.Add(new Units("meter H2O a", "oz/in² a", (decimal)22.757));
                Program.UnitsList.Add(new Units("mm H2O a", "oz/in² a", (decimal)0.023));
                Program.UnitsList.Add(new Units("mm Hg a", "oz/in² a", (decimal)0.309));
                Program.UnitsList.Add(new Units("Mpa a", "oz/in² a", (decimal)2320.604));
                Program.UnitsList.Add(new Units("Pa a", "oz/in² a", (decimal)0.002));
                Program.UnitsList.Add(new Units("psia", "oz/in² a", (decimal)16));
                Program.UnitsList.Add(new Units("Torr a", "oz/in² a", (decimal)0.309));

                //OK
                Program.UnitsList.Add(new Units("atm a", "Pa a", (decimal)101325));
                Program.UnitsList.Add(new Units("bara", "Pa a", (decimal)100000));
                Program.UnitsList.Add(new Units("ft wc a", "Pa a", (decimal)2989.067));
                Program.UnitsList.Add(new Units("in Hg a", "Pa a", (decimal)3386.388));
                Program.UnitsList.Add(new Units("in wc a", "Pa a", (decimal)249.089));
                Program.UnitsList.Add(new Units("kg/cm² a", "Pa a", (decimal)98066.5));
                Program.UnitsList.Add(new Units("kPa a", "Pa a", (decimal)1000));
                Program.UnitsList.Add(new Units("lb/ft² a", "Pa a", (decimal)47.88));
                Program.UnitsList.Add(new Units("mbara", "Pa a", (decimal)100));
                Program.UnitsList.Add(new Units("meter H2O a", "Pa a", (decimal)9806.65));
                Program.UnitsList.Add(new Units("mm H2O a", "Pa a", (decimal)9.807));
                Program.UnitsList.Add(new Units("mm Hg a", "Pa a", (decimal)133.322));
                Program.UnitsList.Add(new Units("Mpa a", "Pa a", (decimal)1000000));
                Program.UnitsList.Add(new Units("oz/in² a", "Pa a", (decimal)430.922));
                Program.UnitsList.Add(new Units("psia", "Pa a", (decimal)6894.757));
                Program.UnitsList.Add(new Units("Torr a", "Pa a", (decimal)133.322));

                //OK
                Program.UnitsList.Add(new Units("atm a", "Torr a", (decimal)760));
                Program.UnitsList.Add(new Units("bara", "Torr a", (decimal)750.062));
                Program.UnitsList.Add(new Units("ft wc a", "Torr a", (decimal)22.42));
                Program.UnitsList.Add(new Units("in Hg a", "Torr a", (decimal)25.4));
                Program.UnitsList.Add(new Units("in wc a", "Torr a", (decimal)1.868));
                Program.UnitsList.Add(new Units("kg/cm² a", "Torr a", (decimal)735.559));
                Program.UnitsList.Add(new Units("kPa a", "Torr a", (decimal)7.501));
                Program.UnitsList.Add(new Units("lb/ft² a", "Torr a", (decimal)0.359));
                Program.UnitsList.Add(new Units("mbara", "Torr a", (decimal)0.75));
                Program.UnitsList.Add(new Units("meter H2O a", "Torr a", (decimal)73.556));
                Program.UnitsList.Add(new Units("mm H2O a", "Torr a", (decimal)0.074));
                Program.UnitsList.Add(new Units("mm Hg a", "Torr a", (decimal)1));
                Program.UnitsList.Add(new Units("Mpa a", "Torr a", (decimal)7500.617));
                Program.UnitsList.Add(new Units("oz/in² a", "Torr a", (decimal)3.232));
                Program.UnitsList.Add(new Units("psia", "Torr a", (decimal)51.715));
                Program.UnitsList.Add(new Units("Pa a", "Torr a", (decimal)0.008));

                //OK
                Program.UnitsList.Add(new Units("atm g", "psig", (decimal)14.696));
                Program.UnitsList.Add(new Units("barg", "psig", (decimal)14.505));
                Program.UnitsList.Add(new Units("ft wc g", "psig", (decimal)0.434));
                Program.UnitsList.Add(new Units("in Hg g", "psig", (decimal)0.491));
                Program.UnitsList.Add(new Units("in wc g", "psig", (decimal)0.036));
                Program.UnitsList.Add(new Units("kg/cm² g", "psig", (decimal)14.223));
                Program.UnitsList.Add(new Units("kPa g", "psig", (decimal)0.145));
                Program.UnitsList.Add(new Units("lb/ft² g", "psig", (decimal)0.007));
                Program.UnitsList.Add(new Units("mbarg", "psig", (decimal)0.015));
                Program.UnitsList.Add(new Units("meter H2O g", "psig", (decimal)1.422));
                Program.UnitsList.Add(new Units("mm H2O g", "psig", (decimal)0.001));
                Program.UnitsList.Add(new Units("mm Hg g", "psig", (decimal)0.019));
                Program.UnitsList.Add(new Units("Mpa g", "psig", (decimal)145.038));
                Program.UnitsList.Add(new Units("oz/in² g", "psig", (decimal)0.062));
                Program.UnitsList.Add(new Units("Pa g", "psig", (decimal)0.000145037738));
                Program.UnitsList.Add(new Units("Torr g", "psig", (decimal)0.019));

                //OK
                Program.UnitsList.Add(new Units("barg", "atm g", (decimal)0.987));
                Program.UnitsList.Add(new Units("ft wc g", "atm g", (decimal)0.029));
                Program.UnitsList.Add(new Units("in Hg g", "atm g", (decimal)0.033));
                Program.UnitsList.Add(new Units("in wc g", "atm g", (decimal)0.002));
                Program.UnitsList.Add(new Units("kg/cm² g", "atm g", (decimal)0.968));
                Program.UnitsList.Add(new Units("kPa g", "atm g", (decimal)0.010));
                Program.UnitsList.Add(new Units("lb/ft² g", "atm g", (decimal)0.0005));
                Program.UnitsList.Add(new Units("mbarg", "atm g", (decimal)0.001));
                Program.UnitsList.Add(new Units("meter H2O g", "atm g", (decimal)0.097));
                Program.UnitsList.Add(new Units("mm H2O g", "atm g", (decimal)0.0001));
                Program.UnitsList.Add(new Units("mm Hg g", "atm g", (decimal)0.001));
                Program.UnitsList.Add(new Units("Mpa g", "atm g", (decimal)9.869));
                Program.UnitsList.Add(new Units("oz/in² g", "atm g", (decimal)0.004));
                Program.UnitsList.Add(new Units("Pa g", "atm g", (decimal)0.00001));
                Program.UnitsList.Add(new Units("psig", "atm g", (decimal)0.068));
                Program.UnitsList.Add(new Units("Torr g", "atm g", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("atm g", "barg", (decimal)1.013));
                Program.UnitsList.Add(new Units("ft wc g", "barg", (decimal)0.030));
                Program.UnitsList.Add(new Units("in Hg g", "barg", (decimal)0.034));
                Program.UnitsList.Add(new Units("in wc g", "barg", (decimal)0.002));
                Program.UnitsList.Add(new Units("kg/cm² g", "barg", (decimal)0.981));
                Program.UnitsList.Add(new Units("kPa g", "barg", (decimal)0.010));
                Program.UnitsList.Add(new Units("lb/ft² g", "barg", (decimal)0.0005));
                Program.UnitsList.Add(new Units("mbarg", "barg", (decimal)0.001));
                Program.UnitsList.Add(new Units("meter H2O g", "barg", (decimal)0.098));
                Program.UnitsList.Add(new Units("mm H2O g", "barg", (decimal)0.0001));
                Program.UnitsList.Add(new Units("mm Hg g", "barg", (decimal)0.001));
                Program.UnitsList.Add(new Units("Mpa g", "barg", (decimal)10));
                Program.UnitsList.Add(new Units("oz/in² g", "barg", (decimal)0.004));
                Program.UnitsList.Add(new Units("Pa g", "barg", (decimal)0.00001));
                Program.UnitsList.Add(new Units("psig", "barg", (decimal)0.069));
                Program.UnitsList.Add(new Units("Torr g", "barg", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("atm g", "ft wc g", (decimal)33.899));
                Program.UnitsList.Add(new Units("barg", "ft wc g", (decimal)33.455));
                Program.UnitsList.Add(new Units("in Hg g", "ft wc g", (decimal)1.133));
                Program.UnitsList.Add(new Units("in wc g", "ft wc g", (decimal)0.083));
                Program.UnitsList.Add(new Units("kg/cm² g", "ft wc g", (decimal)32.808));
                Program.UnitsList.Add(new Units("kPa g", "ft wc g", (decimal)0.335));
                Program.UnitsList.Add(new Units("lb/ft² g", "ft wc g", (decimal)0.016));
                Program.UnitsList.Add(new Units("mbarg", "ft wc g", (decimal)0.033));
                Program.UnitsList.Add(new Units("meter H2O g", "ft wc g", (decimal)3.281));
                Program.UnitsList.Add(new Units("mm H2O g", "ft wc g", (decimal)0.003));
                Program.UnitsList.Add(new Units("mm Hg g", "ft wc g", (decimal)0.045));
                Program.UnitsList.Add(new Units("Mpa g", "ft wc g", (decimal)334.553));
                Program.UnitsList.Add(new Units("oz/in² g", "ft wc g", (decimal)0.144));
                Program.UnitsList.Add(new Units("Pa g", "ft wc g", (decimal)0.0003));
                Program.UnitsList.Add(new Units("psig", "ft wc g", (decimal)2.307));
                Program.UnitsList.Add(new Units("Torr g", "ft wc g", (decimal)0.045));

                //OK
                Program.UnitsList.Add(new Units("atm g", "in Hg g", (decimal)29.921));
                Program.UnitsList.Add(new Units("barg", "in Hg g", (decimal)29.530));
                Program.UnitsList.Add(new Units("ft wc g", "in Hg g", (decimal)0.883));
                Program.UnitsList.Add(new Units("in wc g", "in Hg g", (decimal)0.074));
                Program.UnitsList.Add(new Units("kg/cm² g", "in Hg g", (decimal)28.959));
                Program.UnitsList.Add(new Units("kPa g", "in Hg g", (decimal)0.295));
                Program.UnitsList.Add(new Units("lb/ft² g", "in Hg g", (decimal)0.014));
                Program.UnitsList.Add(new Units("mbarg", "in Hg g", (decimal)0.03));
                Program.UnitsList.Add(new Units("meter H2O g", "in Hg g", (decimal)2.896));
                Program.UnitsList.Add(new Units("mm H2O g", "in Hg g", (decimal)0.003));
                Program.UnitsList.Add(new Units("mm Hg g", "in Hg g", (decimal)0.039));
                Program.UnitsList.Add(new Units("Mpa g", "in Hg g", (decimal)295.3));
                Program.UnitsList.Add(new Units("oz/in² g", "in Hg g", (decimal)0.127));
                Program.UnitsList.Add(new Units("Pa g", "in Hg g", (decimal)0.0003));
                Program.UnitsList.Add(new Units("psig", "in Hg g", (decimal)2.036));
                Program.UnitsList.Add(new Units("Torr g", "in Hg g", (decimal)0.039));

                //OK
                Program.UnitsList.Add(new Units("atm g", "in wc g", (decimal)406.782));
                Program.UnitsList.Add(new Units("barg", "in wc g", (decimal)401.463));
                Program.UnitsList.Add(new Units("ft wc g", "in wc g", (decimal)12));
                Program.UnitsList.Add(new Units("in Hg g", "in wc g", (decimal)13.595));
                Program.UnitsList.Add(new Units("kg/cm² g", "in wc g", (decimal)393.701));
                Program.UnitsList.Add(new Units("kPa g", "in wc g", (decimal)4.015));
                Program.UnitsList.Add(new Units("lb/ft² g", "in wc g", (decimal)0.192));
                Program.UnitsList.Add(new Units("mbarg", "in wc g", (decimal)0.401));
                Program.UnitsList.Add(new Units("meter H2O g", "in wc g", (decimal)39.370));
                Program.UnitsList.Add(new Units("mm H2O g", "in wc g", (decimal)0.039));
                Program.UnitsList.Add(new Units("mm Hg g", "in wc g", (decimal)0.535));
                Program.UnitsList.Add(new Units("Mpa g", "in wc g", (decimal)4014.631));
                Program.UnitsList.Add(new Units("oz/in² g", "in wc g", (decimal)1.730));
                Program.UnitsList.Add(new Units("Pa g", "in wc g", (decimal)0.004));
                Program.UnitsList.Add(new Units("psig", "in wc g", (decimal)27.680));
                Program.UnitsList.Add(new Units("Torr g", "in wc g", (decimal)0.535));

                //OK
                Program.UnitsList.Add(new Units("atm g", "kg/cm² g", (decimal)1.0332));
                Program.UnitsList.Add(new Units("barg", "kg/cm² g", (decimal)1.02));
                Program.UnitsList.Add(new Units("ft wc g", "kg/cm² g", (decimal)0.03));
                Program.UnitsList.Add(new Units("in Hg g", "kg/cm² g", (decimal)0.035));
                Program.UnitsList.Add(new Units("in wc g", "kg/cm² g", (decimal)0.003));
                Program.UnitsList.Add(new Units("kPa g", "kg/cm² g", (decimal)0.01));
                Program.UnitsList.Add(new Units("lb/ft² g", "kg/cm² g", (decimal)0.0005));
                Program.UnitsList.Add(new Units("mbarg", "kg/cm² g", (decimal)0.001));
                Program.UnitsList.Add(new Units("meter H2O g", "kg/cm² g", (decimal)0.1));
                Program.UnitsList.Add(new Units("mm H2O g", "kg/cm² g", (decimal)0.0001));
                Program.UnitsList.Add(new Units("mm Hg g", "kg/cm² g", (decimal)0.001));
                Program.UnitsList.Add(new Units("Mpa g", "kg/cm² g", (decimal)10.197));
                Program.UnitsList.Add(new Units("oz/in² g", "kg/cm² g", (decimal)0.004));
                Program.UnitsList.Add(new Units("Pa g", "kg/cm² g", (decimal)0.00001));
                Program.UnitsList.Add(new Units("psig", "kg/cm² g", (decimal)0.07));
                Program.UnitsList.Add(new Units("Torr g", "kg/cm² g", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("atm g", "kPa g", (decimal)101.325));
                Program.UnitsList.Add(new Units("barg", "kPa g", (decimal)100));
                Program.UnitsList.Add(new Units("ft wc g", "kPa g", (decimal)2.989));
                Program.UnitsList.Add(new Units("in Hg g", "kPa g", (decimal)3.386));
                Program.UnitsList.Add(new Units("in wc g", "kPa g", (decimal)0.249));
                Program.UnitsList.Add(new Units("kg/cm² g", "kPa g", (decimal)98.066));
                Program.UnitsList.Add(new Units("lb/ft² g", "kPa g", (decimal)0.048));
                Program.UnitsList.Add(new Units("mbarg", "kPa g", (decimal)0.1));
                Program.UnitsList.Add(new Units("meter H2O g", "kPa g", (decimal)9.807));
                Program.UnitsList.Add(new Units("mm H2O g", "kPa g", (decimal)0.01));
                Program.UnitsList.Add(new Units("mm Hg g", "kPa g", (decimal)0.133));
                Program.UnitsList.Add(new Units("Mpa g", "kPa g", (decimal)1000));
                Program.UnitsList.Add(new Units("oz/in² g", "kPa g", (decimal)0.431));
                Program.UnitsList.Add(new Units("Pa g", "kPa g", (decimal)0.001));
                Program.UnitsList.Add(new Units("psig", "kPa g", (decimal)6.895));
                Program.UnitsList.Add(new Units("Torr g", "kPa g", (decimal)0.133));

                //OK
                Program.UnitsList.Add(new Units("atm g", "lb/ft² g", (decimal)2116.217));
                Program.UnitsList.Add(new Units("barg", "lb/ft² g", (decimal)2088.543));
                Program.UnitsList.Add(new Units("ft wc g", "lb/ft² g", (decimal)62.428));
                Program.UnitsList.Add(new Units("in Hg g", "lb/ft² g", (decimal)70.726));
                Program.UnitsList.Add(new Units("in wc g", "lb/ft² g", (decimal)5.202));
                Program.UnitsList.Add(new Units("kg/cm² g", "lb/ft² g", (decimal)2048.161));
                Program.UnitsList.Add(new Units("kPa g", "lb/ft² g", (decimal)20.885));
                Program.UnitsList.Add(new Units("mbarg", "lb/ft² g", (decimal)2.089));
                Program.UnitsList.Add(new Units("meter H2O g", "lb/ft² g", (decimal)204.816));
                Program.UnitsList.Add(new Units("mm H2O g", "lb/ft² g", (decimal)0.205));
                Program.UnitsList.Add(new Units("mm Hg g", "lb/ft² g", (decimal)2.784));
                Program.UnitsList.Add(new Units("Mpa g", "lb/ft² g", (decimal)20885.434));
                Program.UnitsList.Add(new Units("oz/in² g", "lb/ft² g", (decimal)9));
                Program.UnitsList.Add(new Units("Pa g", "lb/ft² g", (decimal)0.021));
                Program.UnitsList.Add(new Units("psig", "lb/ft² g", (decimal)144));
                Program.UnitsList.Add(new Units("Torr g", "lb/ft² g", (decimal)2.784));

                //OK
                Program.UnitsList.Add(new Units("atm g", "mbarg", (decimal)1013.250));
                Program.UnitsList.Add(new Units("barg", "mbarg", (decimal)1000));
                Program.UnitsList.Add(new Units("ft wc g", "mbarg", (decimal)29.891));
                Program.UnitsList.Add(new Units("in Hg g", "mbarg", (decimal)33.864));
                Program.UnitsList.Add(new Units("in wc g", "mbarg", (decimal)2.491));
                Program.UnitsList.Add(new Units("kg/cm² g", "mbarg", (decimal)980.665));
                Program.UnitsList.Add(new Units("kPa g", "mbarg", (decimal)10));
                Program.UnitsList.Add(new Units("lb/ft² g", "mbarg", (decimal)0.479));
                Program.UnitsList.Add(new Units("meter H2O g", "mbarg", (decimal)98.066));
                Program.UnitsList.Add(new Units("mm H2O g", "mbarg", (decimal)0.098));
                Program.UnitsList.Add(new Units("mm Hg g", "mbarg", (decimal)1.333));
                Program.UnitsList.Add(new Units("Mpa g", "mbarg", (decimal)10000));
                Program.UnitsList.Add(new Units("oz/in² g", "mbarg", (decimal)4.309));
                Program.UnitsList.Add(new Units("Pa g", "mbarg", (decimal)0.01));
                Program.UnitsList.Add(new Units("psig", "mbarg", (decimal)68.948));
                Program.UnitsList.Add(new Units("Torr g", "mbarg", (decimal)1.333));

                //OK
                Program.UnitsList.Add(new Units("atm g", "meter H2O g", (decimal)10.332));
                Program.UnitsList.Add(new Units("barg", "meter H2O g", (decimal)10.197));
                Program.UnitsList.Add(new Units("ft wc g", "meter H2O g", (decimal)0.305));
                Program.UnitsList.Add(new Units("in Hg g", "meter H2O g", (decimal)0.345));
                Program.UnitsList.Add(new Units("in wc g", "meter H2O g", (decimal)0.025));
                Program.UnitsList.Add(new Units("kg/cm² g", "meter H2O g", (decimal)10));
                Program.UnitsList.Add(new Units("kPa g", "meter H2O g", (decimal)0.102));
                Program.UnitsList.Add(new Units("lb/ft² g", "meter H2O g", (decimal)0.005));
                Program.UnitsList.Add(new Units("mbarg", "meter H2O g", (decimal)0.01));
                Program.UnitsList.Add(new Units("mm H2O g", "meter H2O g", (decimal)0.001));
                Program.UnitsList.Add(new Units("mm Hg g", "meter H2O g", (decimal)0.014));
                Program.UnitsList.Add(new Units("Mpa g", "meter H2O g", (decimal)101.972));
                Program.UnitsList.Add(new Units("oz/in² g", "meter H2O g", (decimal)0.044));
                Program.UnitsList.Add(new Units("Pa g", "meter H2O g", (decimal)0.0001));
                Program.UnitsList.Add(new Units("psig", "meter H2O g", (decimal)0.703));
                Program.UnitsList.Add(new Units("Torr g", "meter H2O g", (decimal)0.014));

                //OK
                Program.UnitsList.Add(new Units("atm g", "mm H2O g", (decimal)10332.275));
                Program.UnitsList.Add(new Units("barg", "mm H2O g", (decimal)10197.162));
                Program.UnitsList.Add(new Units("ft wc g", "mm H2O g", (decimal)304.8));
                Program.UnitsList.Add(new Units("in Hg g", "mm H2O g", (decimal)345.315));
                Program.UnitsList.Add(new Units("in wc g", "mm H2O g", (decimal)25.400));
                Program.UnitsList.Add(new Units("kg/cm² g", "mm H2O g", (decimal)10000));
                Program.UnitsList.Add(new Units("kPa g", "mm H2O g", (decimal)101.972));
                Program.UnitsList.Add(new Units("lb/ft² g", "mm H2O g", (decimal)4.882));
                Program.UnitsList.Add(new Units("mbarg", "mm H2O g", (decimal)10.197));
                Program.UnitsList.Add(new Units("meter H2O g", "mm H2O g", (decimal)1000));
                Program.UnitsList.Add(new Units("mm Hg g", "mm H2O g", (decimal)13.595));
                Program.UnitsList.Add(new Units("Mpa g", "mm H2O g", (decimal)101971.621));
                Program.UnitsList.Add(new Units("oz/in² g", "mm H2O g", (decimal)43.942));
                Program.UnitsList.Add(new Units("Pa g", "mm H2O g", (decimal)0.102));
                Program.UnitsList.Add(new Units("psig", "mm H2O g", (decimal)703.070));
                Program.UnitsList.Add(new Units("Torr g", "mm H2O g", (decimal)13.595));

                //OK
                Program.UnitsList.Add(new Units("atm g", "mm Hg g", (decimal)760));
                Program.UnitsList.Add(new Units("barg", "mm Hg g", (decimal)750.062));
                Program.UnitsList.Add(new Units("ft wc g", "mm Hg g", (decimal)22.420));
                Program.UnitsList.Add(new Units("in Hg g", "mm Hg g", (decimal)25.4));
                Program.UnitsList.Add(new Units("in wc g", "mm Hg g", (decimal)1.868));
                Program.UnitsList.Add(new Units("kg/cm² g", "mm Hg g", (decimal)735.559));
                Program.UnitsList.Add(new Units("kPa g", "mm Hg g", (decimal)7.501));
                Program.UnitsList.Add(new Units("lb/ft² g", "mm Hg g", (decimal)0.359));
                Program.UnitsList.Add(new Units("mbarg", "mm Hg g", (decimal)0.750));
                Program.UnitsList.Add(new Units("meter H2O g", "mm Hg g", (decimal)73.556));
                Program.UnitsList.Add(new Units("mm H2O g", "mm Hg g", (decimal)0.074));
                Program.UnitsList.Add(new Units("Mpa g", "mm Hg g", (decimal)7500.617));
                Program.UnitsList.Add(new Units("oz/in² g", "mm Hg g", (decimal)3.232));
                Program.UnitsList.Add(new Units("Pa g", "mm Hg g", (decimal)7500.617));
                Program.UnitsList.Add(new Units("psig", "mm Hg g", (decimal)51.715));
                Program.UnitsList.Add(new Units("Torr g", "mm Hg g", (decimal)1));

                //OK
                Program.UnitsList.Add(new Units("atm g", "Mpa g", (decimal)0.101));
                Program.UnitsList.Add(new Units("barg", "Mpa g", (decimal)0.1));
                Program.UnitsList.Add(new Units("ft wc g", "Mpa g", (decimal)0.003));
                Program.UnitsList.Add(new Units("in Hg g", "Mpa g", (decimal)0.003));
                Program.UnitsList.Add(new Units("in wc g", "Mpa g", (decimal)0.0002));
                Program.UnitsList.Add(new Units("kg/cm² g", "Mpa g", (decimal)0.098));
                Program.UnitsList.Add(new Units("kPa g", "Mpa g", (decimal)0.001));
                Program.UnitsList.Add(new Units("lb/ft² g", "Mpa g", (decimal)0.00005));
                Program.UnitsList.Add(new Units("mbarg", "Mpa g", (decimal)0.0001));
                Program.UnitsList.Add(new Units("meter H2O g", "Mpa g", (decimal)0.01));
                Program.UnitsList.Add(new Units("mm H2O g", "Mpa g", (decimal)0.00001));
                Program.UnitsList.Add(new Units("mm Hg g", "Mpa g", (decimal)0.0001));
                Program.UnitsList.Add(new Units("oz/in² g", "Mpa g", (decimal)0.0004));
                Program.UnitsList.Add(new Units("Pa g", "Mpa g", (decimal)0.000001));
                Program.UnitsList.Add(new Units("psig", "Mpa g", (decimal)0.007));
                Program.UnitsList.Add(new Units("Torr g", "Mpa g", (decimal)0.0001));

                //OK
                Program.UnitsList.Add(new Units("atm g", "oz/in² g", (decimal)235.135));
                Program.UnitsList.Add(new Units("barg", "oz/in² g", (decimal)232.06));
                Program.UnitsList.Add(new Units("ft wc g", "oz/in² g", (decimal)6.936));
                Program.UnitsList.Add(new Units("in Hg g", "oz/in² g", (decimal)7.858));
                Program.UnitsList.Add(new Units("in wc g", "oz/in² g", (decimal)0.578));
                Program.UnitsList.Add(new Units("kg/cm² g", "oz/in² g", (decimal)227.573));
                Program.UnitsList.Add(new Units("kPa g", "oz/in² g", (decimal)2.321));
                Program.UnitsList.Add(new Units("lb/ft² g", "oz/in² g", (decimal)0.111));
                Program.UnitsList.Add(new Units("mbarg", "oz/in² g", (decimal)0.232));
                Program.UnitsList.Add(new Units("meter H2O g", "oz/in² g", (decimal)22.757));
                Program.UnitsList.Add(new Units("mm H2O g", "oz/in² g", (decimal)0.023));
                Program.UnitsList.Add(new Units("mm Hg g", "oz/in² g", (decimal)0.309));
                Program.UnitsList.Add(new Units("Mpa g", "oz/in² g", (decimal)2320.604));
                Program.UnitsList.Add(new Units("Pa g", "oz/in² g", (decimal)0.002));
                Program.UnitsList.Add(new Units("psig", "oz/in² g", (decimal)16));
                Program.UnitsList.Add(new Units("Torr g", "oz/in² g", (decimal)0.309));

                //OK
                Program.UnitsList.Add(new Units("atm g", "Pa g", (decimal)101325));
                Program.UnitsList.Add(new Units("barg", "Pa g", (decimal)100000));
                Program.UnitsList.Add(new Units("ft wc g", "Pa g", (decimal)2989.067));
                Program.UnitsList.Add(new Units("in Hg g", "Pa g", (decimal)3386.388));
                Program.UnitsList.Add(new Units("in wc g", "Pa g", (decimal)249.089));
                Program.UnitsList.Add(new Units("kg/cm² g", "Pa g", (decimal)98066.5));
                Program.UnitsList.Add(new Units("kPa g", "Pa g", (decimal)1000));
                Program.UnitsList.Add(new Units("lb/ft² g", "Pa g", (decimal)47.88));
                Program.UnitsList.Add(new Units("mbarg", "Pa g", (decimal)100));
                Program.UnitsList.Add(new Units("meter H2O g", "Pa g", (decimal)9806.65));
                Program.UnitsList.Add(new Units("mm H2O g", "Pa g", (decimal)9.807));
                Program.UnitsList.Add(new Units("mm Hg g", "Pa g", (decimal)133.322));
                Program.UnitsList.Add(new Units("Mpa g", "Pa g", (decimal)1000000));
                Program.UnitsList.Add(new Units("oz/in² g", "Pa g", (decimal)430.922));
                Program.UnitsList.Add(new Units("psig", "Pa g", (decimal)6894.757));
                Program.UnitsList.Add(new Units("Torr g", "Pa g", (decimal)133.322));

                //OK
                Program.UnitsList.Add(new Units("atm g", "Torr g", (decimal)760));
                Program.UnitsList.Add(new Units("barg", "Torr g", (decimal)750.062));
                Program.UnitsList.Add(new Units("ft wc g", "Torr g", (decimal)22.42));
                Program.UnitsList.Add(new Units("in Hg g", "Torr g", (decimal)25.4));
                Program.UnitsList.Add(new Units("in wc g", "Torr g", (decimal)1.868));
                Program.UnitsList.Add(new Units("kg/cm² g", "Torr g", (decimal)735.559));
                Program.UnitsList.Add(new Units("kPa g", "Torr g", (decimal)7.501));
                Program.UnitsList.Add(new Units("lb/ft² g", "Torr g", (decimal)0.359));
                Program.UnitsList.Add(new Units("mbarg", "Torr g", (decimal)0.75));
                Program.UnitsList.Add(new Units("meter H2O g", "Torr g", (decimal)73.556));
                Program.UnitsList.Add(new Units("mm H2O g", "Torr g", (decimal)0.074));
                Program.UnitsList.Add(new Units("mm Hg g", "Torr g", (decimal)1));
                Program.UnitsList.Add(new Units("Mpa g", "Torr g", (decimal)7500.617));
                Program.UnitsList.Add(new Units("oz/in² g", "Torr g", (decimal)3.232));
                Program.UnitsList.Add(new Units("psig", "Torr g", (decimal)51.715));
                Program.UnitsList.Add(new Units("Pa g", "Torr g", (decimal)0.008));

                //OK
                Program.UnitsList.Add(new Units("ft³/day", "ft³/hr", (decimal)0.041666666667));
                Program.UnitsList.Add(new Units("ft³/day", "ft³/min", (decimal)0.00069444444444));
                Program.UnitsList.Add(new Units("ft³/day", "ft³/s", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("ft³/day", "m³/day", (decimal)0.028316847));
                Program.UnitsList.Add(new Units("ft³/day", "m³/hr", (decimal)0.001179868625));
                Program.UnitsList.Add(new Units("ft³/day", "m³/min", (decimal)0.000019664477083));
                Program.UnitsList.Add(new Units("ft³/day", "m³/s", (decimal)0.00000032774128472));
                Program.UnitsList.Add(new Units("ft³/day", "GPD (Imp)", (decimal)6.2288355488));
                Program.UnitsList.Add(new Units("ft³/day", "GPH (Imp)", (decimal)0.25953481453));
                Program.UnitsList.Add(new Units("ft³/day", "GPM (Imp)", (decimal)0.0043255802422));
                Program.UnitsList.Add(new Units("ft³/day", "GPS (Imp)", (decimal)0.000072093004036));
                Program.UnitsList.Add(new Units("ft³/day", "GPD (US)", (decimal)7.4805195882));
                Program.UnitsList.Add(new Units("ft³/day", "GPH (US)", (decimal)0.31168831619));
                Program.UnitsList.Add(new Units("ft³/day", "GPM (US)", (decimal)0.0051948052696));
                Program.UnitsList.Add(new Units("ft³/day", "GPS (US)", (decimal)0.000086580087827));
                Program.UnitsList.Add(new Units("ft³/day", "L/day", (decimal)28.316847));
                Program.UnitsList.Add(new Units("ft³/day", "L/hr", (decimal)1.179868625));
                Program.UnitsList.Add(new Units("ft³/day", "L/min", (decimal)0.019664477083));
                Program.UnitsList.Add(new Units("ft³/day", "L/s", (decimal)0.00032774128472));
                Program.UnitsList.Add(new Units("ft³/day", "BBL/d", (decimal)0.178));
                Program.UnitsList.Add(new Units("ft³/day", "BBL/h", (decimal)0.007));



                //OK
                Program.UnitsList.Add(new Units("ft³/hr", "ft³/day", (decimal)24));
                Program.UnitsList.Add(new Units("ft³/hr", "ft³/min", (decimal)0.017));
                Program.UnitsList.Add(new Units("ft³/hr", "ft³/s", (decimal)0.00027777777778));
                Program.UnitsList.Add(new Units("ft³/hr", "m³/day", (decimal)0.68));
                Program.UnitsList.Add(new Units("ft³/hr", "m³/hr", (decimal)0.028));
                Program.UnitsList.Add(new Units("ft³/hr", "m³/min", (decimal)0.00047194744999));
                Program.UnitsList.Add(new Units("ft³/hr", "m³/s", (decimal)0.0000078657908333));
                Program.UnitsList.Add(new Units("ft³/hr", "GPD (Imp)", (decimal)149.49205317));
                Program.UnitsList.Add(new Units("ft³/hr", "GPH (Imp)", (decimal)6.2288355487));
                Program.UnitsList.Add(new Units("ft³/hr", "GPM (Imp)", (decimal)0.10381392581));
                Program.UnitsList.Add(new Units("ft³/hr", "GPS (Imp)", (decimal)0.0017302320969));
                Program.UnitsList.Add(new Units("ft³/hr", "GPD (US)", (decimal)179.53247012));
                Program.UnitsList.Add(new Units("ft³/hr", "GPH (US)", (decimal)7.4805195885));
                Program.UnitsList.Add(new Units("ft³/hr", "GPM (US)", (decimal)0.12467532647));
                Program.UnitsList.Add(new Units("ft³/hr", "GPS (US)", (decimal)0.0020779221079));
                Program.UnitsList.Add(new Units("ft³/hr", "L/day", (decimal)679.604328));
                Program.UnitsList.Add(new Units("ft³/hr", "L/hr", (decimal)28.316847));
                Program.UnitsList.Add(new Units("ft³/hr", "L/min", (decimal)0.47194744999));
                Program.UnitsList.Add(new Units("ft³/hr", "L/s", (decimal)0.0078657908333));
                Program.UnitsList.Add(new Units("ft³/hr", "BBL/d", (decimal)4.275));
                Program.UnitsList.Add(new Units("ft³/hr", "BBL/h", (decimal)0.178));

                //OK
                Program.UnitsList.Add(new Units("ft³/min", "ft³/day", (decimal)1440));
                Program.UnitsList.Add(new Units("ft³/min", "ft³/hr", (decimal)60));
                Program.UnitsList.Add(new Units("ft³/min", "ft³/s", (decimal)0.017));
                Program.UnitsList.Add(new Units("ft³/min", "m³/day", (decimal)40.776));
                Program.UnitsList.Add(new Units("ft³/min", "m³/hr", (decimal)1.699));
                Program.UnitsList.Add(new Units("ft³/min", "m³/min", (decimal)0.028));
                Program.UnitsList.Add(new Units("ft³/min", "m³/s", (decimal)0.00047194745));
                Program.UnitsList.Add(new Units("ft³/min", "GPD (Imp)", (decimal)8969.5231903));
                Program.UnitsList.Add(new Units("ft³/min", "GPH (Imp)", (decimal)373.73013292));
                Program.UnitsList.Add(new Units("ft³/min", "GPM (Imp)", (decimal)6.2288355488));
                Program.UnitsList.Add(new Units("ft³/min", "GPS (Imp)", (decimal)0.10381392581));
                Program.UnitsList.Add(new Units("ft³/min", "GPD (US)", (decimal)10771.948207));
                Program.UnitsList.Add(new Units("ft³/min", "GPH (US)", (decimal)448.83117531));
                Program.UnitsList.Add(new Units("ft³/min", "GPM (US)", (decimal)7.4805195883));
                Program.UnitsList.Add(new Units("ft³/min", "GPS (US)", (decimal)0.12467532647));
                Program.UnitsList.Add(new Units("ft³/min", "L/day", (decimal)40776.25968));
                Program.UnitsList.Add(new Units("ft³/min", "L/hr", (decimal)1699.01082));
                Program.UnitsList.Add(new Units("ft³/min", "L/min", (decimal)28.316846999));
                Program.UnitsList.Add(new Units("ft³/min", "L/s", (decimal)0.47194745));
                Program.UnitsList.Add(new Units("ft³/min", "BBL/d", (decimal)256.475));
                Program.UnitsList.Add(new Units("ft³/min", "BBL/h", (decimal)10.686));

                //OK
                Program.UnitsList.Add(new Units("ft³/s", "ft³/day", (decimal)86400.000001));
                Program.UnitsList.Add(new Units("ft³/s", "ft³/hr", (decimal)3600));
                Program.UnitsList.Add(new Units("ft³/s", "ft³/min", (decimal)60));
                Program.UnitsList.Add(new Units("ft³/s", "m³/day", (decimal)2446.576));
                Program.UnitsList.Add(new Units("ft³/s", "m³/hr", (decimal)101.941));
                Program.UnitsList.Add(new Units("ft³/s", "m³/min", (decimal)1.699));
                Program.UnitsList.Add(new Units("ft³/s", "m³/s", (decimal)0.028));
                Program.UnitsList.Add(new Units("ft³/s", "GPD (Imp)", (decimal)538171.39142));
                Program.UnitsList.Add(new Units("ft³/s", "GPH (Imp)", (decimal)22423.807975));
                Program.UnitsList.Add(new Units("ft³/s", "GPM (Imp)", (decimal)373.73013293));
                Program.UnitsList.Add(new Units("ft³/s", "GPS (Imp)", (decimal)6.2288355488));
                Program.UnitsList.Add(new Units("ft³/s", "GPD (US)", (decimal)646316.89243));
                Program.UnitsList.Add(new Units("ft³/s", "GPH (US)", (decimal)26929.870519));
                Program.UnitsList.Add(new Units("ft³/s", "GPM (US)", (decimal)448.8311753));
                Program.UnitsList.Add(new Units("ft³/s", "GPS (US)", (decimal)7.4805195883));
                Program.UnitsList.Add(new Units("ft³/s", "L/day", (decimal)2446575.5808));
                Program.UnitsList.Add(new Units("ft³/s", "L/hr", (decimal)101940.6492));
                Program.UnitsList.Add(new Units("ft³/s", "L/min", (decimal)1699.01082));
                Program.UnitsList.Add(new Units("ft³/s", "L/s", (decimal)28.316847));
                Program.UnitsList.Add(new Units("ft³/s", "BBL/d", (decimal)15388.497));
                Program.UnitsList.Add(new Units("ft³/s", "BBL/h", (decimal)641.187));

                //OK
                Program.UnitsList.Add(new Units("m³/day", "ft³/day", (decimal)35.315));
                Program.UnitsList.Add(new Units("m³/day", "ft³/hr", (decimal)1.471));
                Program.UnitsList.Add(new Units("m³/day", "ft³/min", (decimal)0.025));
                Program.UnitsList.Add(new Units("m³/day", "ft³/s", (decimal)0.00040873456264));
                Program.UnitsList.Add(new Units("m³/day", "m³/hr", (decimal)0.042));
                Program.UnitsList.Add(new Units("m³/day", "m³/min", (decimal)0.001));
                Program.UnitsList.Add(new Units("m³/day", "m³/s", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("m³/day", "GPD (Imp)", (decimal)219.9692483));
                Program.UnitsList.Add(new Units("m³/day", "GPH (Imp)", (decimal)9.1653853456));
                Program.UnitsList.Add(new Units("m³/day", "GPM (Imp)", (decimal)0.15275642243));
                Program.UnitsList.Add(new Units("m³/day", "GPS (Imp)", (decimal)0.0025459403738));
                Program.UnitsList.Add(new Units("m³/day", "GPD (US)", (decimal)264.17205236));
                Program.UnitsList.Add(new Units("m³/day", "GPH (US)", (decimal)11.007168849));
                Program.UnitsList.Add(new Units("m³/day", "GPM (US)", (decimal)0.18345281414));
                Program.UnitsList.Add(new Units("m³/day", "GPS (US)", (decimal)0.0030575469023));
                Program.UnitsList.Add(new Units("m³/day", "L/day", (decimal)1000));
                Program.UnitsList.Add(new Units("m³/day", "L/hr", (decimal)41.666666666));
                Program.UnitsList.Add(new Units("m³/day", "L/min", (decimal)0.69444444443));
                Program.UnitsList.Add(new Units("m³/day", "L/s", (decimal)0.011574074074));
                Program.UnitsList.Add(new Units("m³/day", "BBL/d", (decimal)6.290));
                Program.UnitsList.Add(new Units("m³/day", "BBL/h", (decimal)0.262));

                //OK
                Program.UnitsList.Add(new Units("m³/hr", "ft³/day", (decimal)847.552));
                Program.UnitsList.Add(new Units("m³/hr", "ft³/hr", (decimal)35.315));
                Program.UnitsList.Add(new Units("m³/hr", "ft³/min", (decimal)0.589));
                Program.UnitsList.Add(new Units("m³/hr", "ft³/s", (decimal)0.01));
                Program.UnitsList.Add(new Units("m³/hr", "m³/day", (decimal)24));
                Program.UnitsList.Add(new Units("m³/hr", "m³/min", (decimal)0.017));
                Program.UnitsList.Add(new Units("m³/hr", "m³/s", (decimal)0.00027777777778));
                Program.UnitsList.Add(new Units("m³/hr", "GPD (Imp)", (decimal)5279.2619593));
                Program.UnitsList.Add(new Units("m³/hr", "GPH (Imp)", (decimal)219.9692483));
                Program.UnitsList.Add(new Units("m³/hr", "GPM (Imp)", (decimal)3.6661541383));
                Program.UnitsList.Add(new Units("m³/hr", "GPS (Imp)", (decimal)0.061102568972));
                Program.UnitsList.Add(new Units("m³/hr", "GPD (US)", (decimal)6340.1292566));
                Program.UnitsList.Add(new Units("m³/hr", "GPH (US)", (decimal)264.17205237));
                Program.UnitsList.Add(new Units("m³/hr", "GPM (US)", (decimal)4.4028675393));
                Program.UnitsList.Add(new Units("m³/hr", "GPS (US)", (decimal)0.073381125656));
                Program.UnitsList.Add(new Units("m³/hr", "L/day", (decimal)24000));
                Program.UnitsList.Add(new Units("m³/hr", "L/hr", (decimal)1000));
                Program.UnitsList.Add(new Units("m³/hr", "L/min", (decimal)16.666666666));
                Program.UnitsList.Add(new Units("m³/hr", "L/s", (decimal)0.27777777778));
                Program.UnitsList.Add(new Units("m³/hr", "BBL/d", (decimal)150.955));
                Program.UnitsList.Add(new Units("m³/hr", "BBL/h", (decimal)6.290));

                //OK
                Program.UnitsList.Add(new Units("m³/min", "ft³/day", (decimal)50853.12));
                Program.UnitsList.Add(new Units("m³/min", "ft³/hr", (decimal)2118.88));
                Program.UnitsList.Add(new Units("m³/min", "ft³/min", (decimal)35.315));
                Program.UnitsList.Add(new Units("m³/min", "ft³/s", (decimal)0.589));
                Program.UnitsList.Add(new Units("m³/min", "m³/day", (decimal)1440));
                Program.UnitsList.Add(new Units("m³/min", "m³/hr", (decimal)60));
                Program.UnitsList.Add(new Units("m³/min", "m³/s", (decimal)0.017));
                Program.UnitsList.Add(new Units("m³/min", "GPD (Imp)", (decimal)316755.71756));
                Program.UnitsList.Add(new Units("m³/min", "GPH (Imp)", (decimal)13198.154898));
                Program.UnitsList.Add(new Units("m³/min", "GPM (Imp)", (decimal)219.9692483));
                Program.UnitsList.Add(new Units("m³/min", "GPS (Imp)", (decimal)3.6661541384));
                Program.UnitsList.Add(new Units("m³/min", "GPD (US)", (decimal)380407.7554));
                Program.UnitsList.Add(new Units("m³/min", "GPH (US)", (decimal)15850.323142));
                Program.UnitsList.Add(new Units("m³/min", "GPM (US)", (decimal)264.17205236));
                Program.UnitsList.Add(new Units("m³/min", "GPS (US)", (decimal)4.4028675394));
                Program.UnitsList.Add(new Units("m³/min", "L/day", (decimal)1440000));
                Program.UnitsList.Add(new Units("m³/min", "L/hr", (decimal)60000.000001));
                Program.UnitsList.Add(new Units("m³/min", "L/min", (decimal)1000));
                Program.UnitsList.Add(new Units("m³/min", "L/s", (decimal)16.666666667));
                Program.UnitsList.Add(new Units("m³/min", "BBL/d", (decimal)9057.328));
                Program.UnitsList.Add(new Units("m³/min", "BBL/h", (decimal)377.389));

                //OK
                Program.UnitsList.Add(new Units("m³/s", "ft³/day", (decimal)3051187.205));
                Program.UnitsList.Add(new Units("m³/s", "ft³/hr", (decimal)127132.8));
                Program.UnitsList.Add(new Units("m³/s", "ft³/min", (decimal)2118.88));
                Program.UnitsList.Add(new Units("m³/s", "ft³/s", (decimal)35.315));
                Program.UnitsList.Add(new Units("m³/s", "m³/day", (decimal)86400));
                Program.UnitsList.Add(new Units("m³/s", "m³/hr", (decimal)3600));
                Program.UnitsList.Add(new Units("m³/s", "m³/min", (decimal)60));
                Program.UnitsList.Add(new Units("m³/s", "GPD (Imp)", (decimal)19005343.053));
                Program.UnitsList.Add(new Units("m³/s", "GPH (Imp)", (decimal)791889.29386));
                Program.UnitsList.Add(new Units("m³/s", "GPM (Imp)", (decimal)13198.154898));
                Program.UnitsList.Add(new Units("m³/s", "GPS (Imp)", (decimal)219.9692483));
                Program.UnitsList.Add(new Units("m³/s", "GPD (US)", (decimal)22824465.324));
                Program.UnitsList.Add(new Units("m³/s", "GPH (US)", (decimal)951019.38852));
                Program.UnitsList.Add(new Units("m³/s", "GPM (US)", (decimal)15850.323141));
                Program.UnitsList.Add(new Units("m³/s", "GPS (US)", (decimal)264.17205236));
                Program.UnitsList.Add(new Units("m³/s", "L/day", (decimal)86400000.001));
                Program.UnitsList.Add(new Units("m³/s", "L/hr", (decimal)3600000));
                Program.UnitsList.Add(new Units("m³/s", "L/min", (decimal)59999.999999));
                Program.UnitsList.Add(new Units("m³/s", "L/s", (decimal)1000));
                Program.UnitsList.Add(new Units("m³/s", "BBL/d", (decimal)543439.651));
                Program.UnitsList.Add(new Units("m³/s", "BBL/h", (decimal)22643.319));

                //OK
                Program.UnitsList.Add(new Units("GPD (Imp)", "ft³/day", (decimal)0.16054365092));
                Program.UnitsList.Add(new Units("GPD (Imp)", "ft³/hr", (decimal)0.0066893187884));
                Program.UnitsList.Add(new Units("GPD (Imp)", "ft³/min", (decimal)0.00011148864647));
                Program.UnitsList.Add(new Units("GPD (Imp)", "ft³/s", (decimal)0.0000018581441079));
                Program.UnitsList.Add(new Units("GPD (Imp)", "m³/day", (decimal)0.00454609));
                Program.UnitsList.Add(new Units("GPD (Imp)", "m³/hr", (decimal)0.00018942041666));
                Program.UnitsList.Add(new Units("GPD (Imp)", "m³/min", (decimal)0.0000031570069444));
                Program.UnitsList.Add(new Units("GPD (Imp)", "m³/s", (decimal)0.000000052616782407));
                Program.UnitsList.Add(new Units("GPD (Imp)", "GPH (Imp)", (decimal)0.041666666666));
                Program.UnitsList.Add(new Units("GPD (Imp)", "GPM (Imp)", (decimal)0.00069444444444));
                Program.UnitsList.Add(new Units("GPD (Imp)", "GPS (Imp)", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("GPD (Imp)", "GPD (US)", (decimal)1.2009499255));
                Program.UnitsList.Add(new Units("GPD (Imp)", "GPH (US)", (decimal)0.050039580231));
                Program.UnitsList.Add(new Units("GPD (Imp)", "GPM (US)", (decimal)0.00083399300382));
                Program.UnitsList.Add(new Units("GPD (Imp)", "GPS (US)", (decimal)0.000013899883397));
                Program.UnitsList.Add(new Units("GPD (Imp)", "L/day", (decimal)4.54609));
                Program.UnitsList.Add(new Units("GPD (Imp)", "L/hr", (decimal)0.18942041666));
                Program.UnitsList.Add(new Units("GPD (Imp)", "L/min", (decimal)0.0031570069444));
                Program.UnitsList.Add(new Units("GPD (Imp)", "L/s", (decimal)0.000052616782407));
                Program.UnitsList.Add(new Units("GPD (Imp)", "BBL/d", (decimal)0.029));
                Program.UnitsList.Add(new Units("GPD (Imp)", "BBL/h", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("GPH (Imp)", "ft³/day", (decimal)3.853));
                Program.UnitsList.Add(new Units("GPH (Imp)", "ft³/hr", (decimal)0.16054365093));
                Program.UnitsList.Add(new Units("GPH (Imp)", "ft³/min", (decimal)0.0026757275154));
                Program.UnitsList.Add(new Units("GPH (Imp)", "ft³/s", (decimal)0.00004459545859));
                Program.UnitsList.Add(new Units("GPH (Imp)", "m³/day", (decimal)0.10910616));
                Program.UnitsList.Add(new Units("GPH (Imp)", "m³/hr", (decimal)0.00454609));
                Program.UnitsList.Add(new Units("GPH (Imp)", "m³/min", (decimal)0.000075768166666));
                Program.UnitsList.Add(new Units("GPH (Imp)", "m³/s", (decimal)0.0000012628027778));
                Program.UnitsList.Add(new Units("GPH (Imp)", "GPD (Imp)", (decimal)24));
                Program.UnitsList.Add(new Units("GPH (Imp)", "GPM (Imp)", (decimal)0.016666666667));
                Program.UnitsList.Add(new Units("GPH (Imp)", "GPS (Imp)", (decimal)0.00027777777778));
                Program.UnitsList.Add(new Units("GPH (Imp)", "GPD (US)", (decimal)28.822798213));
                Program.UnitsList.Add(new Units("GPH (Imp)", "GPH (US)", (decimal)1.2009499256));
                Program.UnitsList.Add(new Units("GPH (Imp)", "GPM (US)", (decimal)0.020015832092));
                Program.UnitsList.Add(new Units("GPH (Imp)", "GPS (US)", (decimal)0.00033359720153));
                Program.UnitsList.Add(new Units("GPH (Imp)", "L/day", (decimal)109.10616));
                Program.UnitsList.Add(new Units("GPH (Imp)", "L/hr", (decimal)4.54609));
                Program.UnitsList.Add(new Units("GPH (Imp)", "L/min", (decimal)0.075768166666));
                Program.UnitsList.Add(new Units("GPH (Imp)", "L/s", (decimal)0.0012628027778));
                Program.UnitsList.Add(new Units("GPH (Imp)", "BBL/d", (decimal)0.686));
                Program.UnitsList.Add(new Units("GPH (Imp)", "BBL/h", (decimal)0.029));

                //OK
                Program.UnitsList.Add(new Units("GPM (Imp)", "ft³/day", (decimal)231.183));
                Program.UnitsList.Add(new Units("GPM (Imp)", "ft³/hr", (decimal)9.6326190554));
                Program.UnitsList.Add(new Units("GPM (Imp)", "ft³/min", (decimal)0.16054365092));
                Program.UnitsList.Add(new Units("GPM (Imp)", "ft³/s", (decimal)0.0026757275154));
                Program.UnitsList.Add(new Units("GPM (Imp)", "m³/day", (decimal)6.5463696001));
                Program.UnitsList.Add(new Units("GPM (Imp)", "m³/hr", (decimal)0.2727654));
                Program.UnitsList.Add(new Units("GPM (Imp)", "m³/min", (decimal)0.0045460899999));
                Program.UnitsList.Add(new Units("GPM (Imp)", "m³/s", (decimal)0.000075768166667));
                Program.UnitsList.Add(new Units("GPM (Imp)", "GPD (Imp)", (decimal)1440));
                Program.UnitsList.Add(new Units("GPM (Imp)", "GPH (Imp)", (decimal)60));
                Program.UnitsList.Add(new Units("GPM (Imp)", "GPS (Imp)", (decimal)0.016666666667));
                Program.UnitsList.Add(new Units("GPM (Imp)", "GPD (US)", (decimal)1729.3678927));
                Program.UnitsList.Add(new Units("GPM (Imp)", "GPH (US)", (decimal)72.056995533));
                Program.UnitsList.Add(new Units("GPM (Imp)", "GPM (US)", (decimal)1.2009499255));
                Program.UnitsList.Add(new Units("GPM (Imp)", "GPS (US)", (decimal)0.020015832092));
                Program.UnitsList.Add(new Units("GPM (Imp)", "L/day", (decimal)6546.3696001));
                Program.UnitsList.Add(new Units("GPM (Imp)", "L/hr", (decimal)272.7654));
                Program.UnitsList.Add(new Units("GPM (Imp)", "L/min", (decimal)4.5460899999));
                Program.UnitsList.Add(new Units("GPM (Imp)", "L/s", (decimal)0.075768166667));
                Program.UnitsList.Add(new Units("GPM (Imp)", "BBL/d", (decimal)41.175));
                Program.UnitsList.Add(new Units("GPM (Imp)", "BBL/h", (decimal)1.716));

                //OK
                Program.UnitsList.Add(new Units("GPS (Imp)", "ft³/day", (decimal)13870.972));
                Program.UnitsList.Add(new Units("GPS (Imp)", "ft³/hr", (decimal)577.95714332));
                Program.UnitsList.Add(new Units("GPS (Imp)", "ft³/min", (decimal)9.6326190554));
                Program.UnitsList.Add(new Units("GPS (Imp)", "ft³/s", (decimal)0.16054365092));
                Program.UnitsList.Add(new Units("GPS (Imp)", "m³/day", (decimal)392.782176));
                Program.UnitsList.Add(new Units("GPS (Imp)", "m³/hr", (decimal)16.365924));
                Program.UnitsList.Add(new Units("GPS (Imp)", "m³/min", (decimal)0.27276539999));
                Program.UnitsList.Add(new Units("GPS (Imp)", "m³/s", (decimal)0.00454609));
                Program.UnitsList.Add(new Units("GPS (Imp)", "GPD (Imp)", (decimal)86400.000001));
                Program.UnitsList.Add(new Units("GPS (Imp)", "GPH (Imp)", (decimal)3599.9999999));
                Program.UnitsList.Add(new Units("GPS (Imp)", "GPM (Imp)", (decimal)60));
                Program.UnitsList.Add(new Units("GPS (Imp)", "GPD (US)", (decimal)103762.07356));
                Program.UnitsList.Add(new Units("GPS (Imp)", "GPH (US)", (decimal)4323.419732));
                Program.UnitsList.Add(new Units("GPS (Imp)", "GPM (US)", (decimal)72.05699553));
                Program.UnitsList.Add(new Units("GPS (Imp)", "GPS (US)", (decimal)1.2009499255));
                Program.UnitsList.Add(new Units("GPS (Imp)", "L/day", (decimal)392782.176));
                Program.UnitsList.Add(new Units("GPS (Imp)", "L/hr", (decimal)16365.924));
                Program.UnitsList.Add(new Units("GPS (Imp)", "L/min", (decimal)272.76539999));
                Program.UnitsList.Add(new Units("GPS (Imp)", "L/s", (decimal)4.54609));
                Program.UnitsList.Add(new Units("GPS (Imp)", "BBL/d", (decimal)2470.526));
                Program.UnitsList.Add(new Units("GPS (Imp)", "BBL/h", (decimal)102.939));

                //OK
                Program.UnitsList.Add(new Units("GPD (US)", "ft³/day", (decimal)0.13368055363));
                Program.UnitsList.Add(new Units("GPD (US)", "ft³/hr", (decimal)0.005570023067));
                Program.UnitsList.Add(new Units("GPD (US)", "ft³/min", (decimal)0.000092833717798));
                Program.UnitsList.Add(new Units("GPD (US)", "ft³/s", (decimal)0.00000154722863));
                Program.UnitsList.Add(new Units("GPD (US)", "m³/day", (decimal)0.003785411784));
                Program.UnitsList.Add(new Units("GPD (US)", "m³/hr", (decimal)0.000157725491));
                Program.UnitsList.Add(new Units("GPD (US)", "m³/min", (decimal)0.0000026287581833));
                Program.UnitsList.Add(new Units("GPD (US)", "m³/s", (decimal)0.000000043812636389));
                Program.UnitsList.Add(new Units("GPD (US)", "GPD (Imp)", (decimal)0.83267418464));
                Program.UnitsList.Add(new Units("GPD (US)", "GPH (Imp)", (decimal)0.034694757692));
                Program.UnitsList.Add(new Units("GPD (US)", "GPM (Imp)", (decimal)0.00057824596155));
                Program.UnitsList.Add(new Units("GPD (US)", "GPS (Imp)", (decimal)0.0000096374326925));
                Program.UnitsList.Add(new Units("GPD (US)", "GPH (US)", (decimal)0.041666666668));
                Program.UnitsList.Add(new Units("GPD (US)", "GPM (US)", (decimal)0.00069444444445));
                Program.UnitsList.Add(new Units("GPD (US)", "GPS (US)", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("GPD (US)", "L/day", (decimal)3.785411784));
                Program.UnitsList.Add(new Units("GPD (US)", "L/hr", (decimal)0.157725491));
                Program.UnitsList.Add(new Units("GPD (US)", "L/min", (decimal)0.0026287581833));
                Program.UnitsList.Add(new Units("GPD (US)", "L/s", (decimal)0.000043812636389));
                Program.UnitsList.Add(new Units("GPD (US)", "BBL/d", (decimal)0.024));
                Program.UnitsList.Add(new Units("GPD (US)", "BBL/h", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("GPH (US)", "ft³/day", (decimal)3.208333287));
                Program.UnitsList.Add(new Units("GPH (US)", "ft³/hr", (decimal)0.13368055363));
                Program.UnitsList.Add(new Units("GPH (US)", "ft³/min", (decimal)0.0022280092271));
                Program.UnitsList.Add(new Units("GPH (US)", "ft³/s", (decimal)0.000037133487118));
                Program.UnitsList.Add(new Units("GPH (US)", "m³/day", (decimal)0.090849882814));
                Program.UnitsList.Add(new Units("GPH (US)", "m³/hr", (decimal)0.0037854117838));
                Program.UnitsList.Add(new Units("GPH (US)", "m³/min", (decimal)0.000063090196397));
                Program.UnitsList.Add(new Units("GPH (US)", "m³/s", (decimal)0.0000010515032733));
                Program.UnitsList.Add(new Units("GPH (US)", "GPD (Imp)", (decimal)19.984180431));
                Program.UnitsList.Add(new Units("GPH (US)", "GPH (Imp)", (decimal)0.83267418459));
                Program.UnitsList.Add(new Units("GPH (US)", "GPM (Imp)", (decimal)0.013877903077));
                Program.UnitsList.Add(new Units("GPH (US)", "GPS (Imp)", (decimal)0.00023129838461));
                Program.UnitsList.Add(new Units("GPH (US)", "GPD (US)", (decimal)23.999999999));
                Program.UnitsList.Add(new Units("GPH (US)", "GPM (US)", (decimal)0.016666666666));
                Program.UnitsList.Add(new Units("GPH (US)", "GPS (US)", (decimal)0.00027777777777));
                Program.UnitsList.Add(new Units("GPH (US)", "L/day", (decimal)90.849882814));
                Program.UnitsList.Add(new Units("GPH (US)", "L/hr", (decimal)3.7854117838));
                Program.UnitsList.Add(new Units("GPH (US)", "L/min", (decimal)0.063090196397));
                Program.UnitsList.Add(new Units("GPH (US)", "L/s", (decimal)0.0010515032733));
                Program.UnitsList.Add(new Units("GPH (US)", "BBL/d", (decimal)0.571));
                Program.UnitsList.Add(new Units("GPH (US)", "BBL/h", (decimal)0.024));

                //OK
                Program.UnitsList.Add(new Units("GPM (US)", "ft³/day", (decimal)192.49999723));
                Program.UnitsList.Add(new Units("GPM (US)", "ft³/hr", (decimal)8.0208332178));
                Program.UnitsList.Add(new Units("GPM (US)", "ft³/min", (decimal)0.13368055363));
                Program.UnitsList.Add(new Units("GPM (US)", "ft³/s", (decimal)0.0022280092272));
                Program.UnitsList.Add(new Units("GPM (US)", "m³/day", (decimal)5.450992969));
                Program.UnitsList.Add(new Units("GPM (US)", "m³/hr", (decimal)0.22712470704));
                Program.UnitsList.Add(new Units("GPM (US)", "m³/min", (decimal)0.0037854117839));
                Program.UnitsList.Add(new Units("GPM (US)", "m³/s", (decimal)0.0000630901964));
                Program.UnitsList.Add(new Units("GPM (US)", "GPD (Imp)", (decimal)1199.0508259));
                Program.UnitsList.Add(new Units("GPM (US)", "GPH (Imp)", (decimal)49.960451077));
                Program.UnitsList.Add(new Units("GPM (US)", "GPM (Imp)", (decimal)0.83267418463));
                Program.UnitsList.Add(new Units("GPM (US)", "GPS (Imp)", (decimal)0.013877903077));
                Program.UnitsList.Add(new Units("GPM (US)", "GPD (US)", (decimal)1440));
                Program.UnitsList.Add(new Units("GPM (US)", "GPH (US)", (decimal)60));
                Program.UnitsList.Add(new Units("GPM (US)", "GPS (US)", (decimal)0.016666666667));
                Program.UnitsList.Add(new Units("GPM (US)", "L/day", (decimal)5450.992969));
                Program.UnitsList.Add(new Units("GPM (US)", "L/hr", (decimal)227.12470704));
                Program.UnitsList.Add(new Units("GPM (US)", "L/min", (decimal)3.7854117839));
                Program.UnitsList.Add(new Units("GPM (US)", "L/s", (decimal)0.0630901964));
                Program.UnitsList.Add(new Units("GPM (US)", "BBL/d", (decimal)34.286));
                Program.UnitsList.Add(new Units("GPM (US)", "BBL/h", (decimal)1.429));

                //OK
                Program.UnitsList.Add(new Units("GPS (US)", "ft³/day", (decimal)11549.999834));
                Program.UnitsList.Add(new Units("GPS (US)", "ft³/hr", (decimal)481.24999307));
                Program.UnitsList.Add(new Units("GPS (US)", "ft³/min", (decimal)8.0208332178));
                Program.UnitsList.Add(new Units("GPS (US)", "ft³/s", (decimal)0.13368055363));
                Program.UnitsList.Add(new Units("GPS (US)", "m³/day", (decimal)327.05957814));
                Program.UnitsList.Add(new Units("GPS (US)", "m³/hr", (decimal)13.627482422));
                Program.UnitsList.Add(new Units("GPS (US)", "m³/min", (decimal)0.22712470704));
                Program.UnitsList.Add(new Units("GPS (US)", "m³/s", (decimal)0.003785411784));
                Program.UnitsList.Add(new Units("GPS (US)", "GPD (Imp)", (decimal)71943.049553));
                Program.UnitsList.Add(new Units("GPS (US)", "GPH (Imp)", (decimal)2997.6270646));
                Program.UnitsList.Add(new Units("GPS (US)", "GPM (Imp)", (decimal)49.960451078));
                Program.UnitsList.Add(new Units("GPS (US)", "GPS (Imp)", (decimal)0.83267418463));
                Program.UnitsList.Add(new Units("GPS (US)", "GPD (US)", (decimal)86400));
                Program.UnitsList.Add(new Units("GPS (US)", "GPH (US)", (decimal)3600.0000001));
                Program.UnitsList.Add(new Units("GPS (US)", "GPM (US)", (decimal)60));
                Program.UnitsList.Add(new Units("GPS (US)", "L/day", (decimal)327059.57814));
                Program.UnitsList.Add(new Units("GPS (US)", "L/hr", (decimal)13627.482422));
                Program.UnitsList.Add(new Units("GPS (US)", "L/min", (decimal)227.12470704));
                Program.UnitsList.Add(new Units("GPS (US)", "L/s", (decimal)3.785411784));
                Program.UnitsList.Add(new Units("GPS (US)", "BBL/d", (decimal)2057.143));
                Program.UnitsList.Add(new Units("GPS (US)", "BBL/h", (decimal)85.714));


                //OK
                Program.UnitsList.Add(new Units("L/day", "ft³/day", (decimal)0.035314666213));
                Program.UnitsList.Add(new Units("L/day", "ft³/hr", (decimal)0.0014714444255));
                Program.UnitsList.Add(new Units("L/day", "ft³/min", (decimal)0.000024524073759));
                Program.UnitsList.Add(new Units("L/day", "ft³/s", (decimal)0.00000040873456264));
                Program.UnitsList.Add(new Units("L/day", "m³/day", (decimal)0.001));
                Program.UnitsList.Add(new Units("L/day", "m³/hr", (decimal)0.000041666666666));
                Program.UnitsList.Add(new Units("L/day", "m³/min", (decimal)0.00000069444444443));
                Program.UnitsList.Add(new Units("L/day", "m³/s", (decimal)0.000000011574074074));
                Program.UnitsList.Add(new Units("L/day", "GPD (Imp)", (decimal)0.2199692483));
                Program.UnitsList.Add(new Units("L/day", "GPH (Imp)", (decimal)0.0091653853456));
                Program.UnitsList.Add(new Units("L/day", "GPM (Imp)", (decimal)0.00015275642243));
                Program.UnitsList.Add(new Units("L/day", "GPS (Imp)", (decimal)0.0000025459403738));
                Program.UnitsList.Add(new Units("L/day", "GPD (US)", (decimal)0.26417205236));
                Program.UnitsList.Add(new Units("L/day", "GPH (US)", (decimal)0.011007168849));
                Program.UnitsList.Add(new Units("L/day", "GPM (US)", (decimal)0.00018345281414));
                Program.UnitsList.Add(new Units("L/day", "GPS (US)", (decimal)0.0000030575469023));
                Program.UnitsList.Add(new Units("L/day", "L/hr", (decimal)0.041666666666));
                Program.UnitsList.Add(new Units("L/day", "L/min", (decimal)0.00069444444443));
                Program.UnitsList.Add(new Units("L/day", "L/s", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("L/day", "BBL/d", (decimal)0.006));
                Program.UnitsList.Add(new Units("L/day", "BBL/h", (decimal)0.0003));

                //OK
                Program.UnitsList.Add(new Units("L/hr", "ft³/day", (decimal)0.84755198912));
                Program.UnitsList.Add(new Units("L/hr", "ft³/hr", (decimal)0.035314666213));
                Program.UnitsList.Add(new Units("L/hr", "ft³/min", (decimal)0.00058857777022));
                Program.UnitsList.Add(new Units("L/hr", "ft³/s", (decimal)0.0000098096295036));
                Program.UnitsList.Add(new Units("L/hr", "m³/day", (decimal)0.024));
                Program.UnitsList.Add(new Units("L/hr", "m³/hr", (decimal)0.001));
                Program.UnitsList.Add(new Units("L/hr", "m³/min", (decimal)0.000016666666666));
                Program.UnitsList.Add(new Units("L/hr", "m³/s", (decimal)0.00000027777777778));
                Program.UnitsList.Add(new Units("L/hr", "GPD (Imp)", (decimal)5.2792619593));
                Program.UnitsList.Add(new Units("L/hr", "GPH (Imp)", (decimal)0.2199692483));
                Program.UnitsList.Add(new Units("L/hr", "GPM (Imp)", (decimal)0.0036661541383));
                Program.UnitsList.Add(new Units("L/hr", "GPS (Imp)", (decimal)0.000061102568972));
                Program.UnitsList.Add(new Units("L/hr", "GPD (US)", (decimal)6.3401292566));
                Program.UnitsList.Add(new Units("L/hr", "GPH (US)", (decimal)0.26417205237));
                Program.UnitsList.Add(new Units("L/hr", "GPM (US)", (decimal)0.0044028675393));
                Program.UnitsList.Add(new Units("L/hr", "GPS (US)", (decimal)0.000073381125656));
                Program.UnitsList.Add(new Units("L/hr", "L/day", (decimal)24));
                Program.UnitsList.Add(new Units("L/hr", "L/min", (decimal)0.016666666666));
                Program.UnitsList.Add(new Units("L/hr", "L/s", (decimal)0.00027777777778));
                Program.UnitsList.Add(new Units("L/hr", "BBL/d", (decimal)0.151));
                Program.UnitsList.Add(new Units("L/hr", "BBL/h", (decimal)0.006));

                //OK
                Program.UnitsList.Add(new Units("L/min", "ft³/day", (decimal)50.853119348));
                Program.UnitsList.Add(new Units("L/min", "ft³/hr", (decimal)2.1188799728));
                Program.UnitsList.Add(new Units("L/min", "ft³/min", (decimal)0.035314666213));
                Program.UnitsList.Add(new Units("L/min", "ft³/s", (decimal)0.00058857777022));
                Program.UnitsList.Add(new Units("L/min", "m³/day", (decimal)1.44));
                Program.UnitsList.Add(new Units("L/min", "m³/hr", (decimal)0.060000000001));
                Program.UnitsList.Add(new Units("L/min", "m³/min", (decimal)0.001));
                Program.UnitsList.Add(new Units("L/min", "m³/s", (decimal)0.000016666666667));
                Program.UnitsList.Add(new Units("L/min", "GPD (Imp)", (decimal)316.75571756));
                Program.UnitsList.Add(new Units("L/min", "GPH (Imp)", (decimal)13.198154898));
                Program.UnitsList.Add(new Units("L/min", "GPM (Imp)", (decimal)0.2199692483));
                Program.UnitsList.Add(new Units("L/min", "GPS (Imp)", (decimal)0.0036661541384));
                Program.UnitsList.Add(new Units("L/min", "GPD (US)", (decimal)380.4077554));
                Program.UnitsList.Add(new Units("L/min", "GPH (US)", (decimal)15.850323142));
                Program.UnitsList.Add(new Units("L/min", "GPM (US)", (decimal)0.26417205236));
                Program.UnitsList.Add(new Units("L/min", "GPS (US)", (decimal)0.0044028675394));
                Program.UnitsList.Add(new Units("L/min", "L/day", (decimal)1440));
                Program.UnitsList.Add(new Units("L/min", "L/hr", (decimal)60.000000001));
                Program.UnitsList.Add(new Units("L/min", "L/s", (decimal)0.016666666667));
                Program.UnitsList.Add(new Units("L/min", "BBL/d", (decimal)9.057));
                Program.UnitsList.Add(new Units("L/min", "BBL/h", (decimal)0.377));

                //OK
                Program.UnitsList.Add(new Units("L/s", "ft³/day", (decimal)3051.1871608));
                Program.UnitsList.Add(new Units("L/s", "ft³/hr", (decimal)127.13279837));
                Program.UnitsList.Add(new Units("L/s", "ft³/min", (decimal)2.1188799728));
                Program.UnitsList.Add(new Units("L/s", "ft³/s", (decimal)0.035314666213));
                Program.UnitsList.Add(new Units("L/s", "m³/day", (decimal)86.400000001));
                Program.UnitsList.Add(new Units("L/s", "m³/hr", (decimal)3.6));
                Program.UnitsList.Add(new Units("L/s", "m³/min", (decimal)0.059999999999));
                Program.UnitsList.Add(new Units("L/s", "m³/s", (decimal)0.001));
                Program.UnitsList.Add(new Units("L/s", "GPD (Imp)", (decimal)19005.343053));
                Program.UnitsList.Add(new Units("L/s", "GPH (Imp)", (decimal)791.88929386));
                Program.UnitsList.Add(new Units("L/s", "GPM (Imp)", (decimal)13.198154898));
                Program.UnitsList.Add(new Units("L/s", "GPS (Imp)", (decimal)0.2199692483));
                Program.UnitsList.Add(new Units("L/s", "GPD (US)", (decimal)22824.465324));
                Program.UnitsList.Add(new Units("L/s", "GPH (US)", (decimal)951.01938852));
                Program.UnitsList.Add(new Units("L/s", "GPM (US)", (decimal)15.850323141));
                Program.UnitsList.Add(new Units("L/s", "GPS (US)", (decimal)0.26417205236));
                Program.UnitsList.Add(new Units("L/s", "L/day", (decimal)86400.000001));
                Program.UnitsList.Add(new Units("L/s", "L/hr", (decimal)3600));
                Program.UnitsList.Add(new Units("L/s", "L/min", (decimal)60));
                Program.UnitsList.Add(new Units("L/s", "BBL/d", (decimal)543.440));
                Program.UnitsList.Add(new Units("L/s", "BBL/h", (decimal)22.643));

                //OK
                Program.UnitsList.Add(new Units("BBL/d", "ft³/day", (decimal)5.615));
                Program.UnitsList.Add(new Units("BBL/d", "ft³/hr", (decimal)0.234));
                Program.UnitsList.Add(new Units("BBL/d", "ft³/min", (decimal)0.004));
                Program.UnitsList.Add(new Units("BBL/d", "ft³/s", (decimal)0.0001));
                Program.UnitsList.Add(new Units("BBL/d", "m³/day", (decimal)0.159));
                Program.UnitsList.Add(new Units("BBL/d", "m³/hr", (decimal)0.007));
                Program.UnitsList.Add(new Units("BBL/d", "m³/min", (decimal)0.0001));
                Program.UnitsList.Add(new Units("BBL/d", "m³/s", (decimal)0.000002));
                Program.UnitsList.Add(new Units("BBL/d", "GPD (Imp)", (decimal)34.972));
                Program.UnitsList.Add(new Units("BBL/d", "GPH (Imp)", (decimal)1.457));
                Program.UnitsList.Add(new Units("BBL/d", "GPM (Imp)", (decimal)0.024));
                Program.UnitsList.Add(new Units("BBL/d", "GPS (Imp)", (decimal)0.0005));
                Program.UnitsList.Add(new Units("BBL/d", "GPD (US)", (decimal)42));
                Program.UnitsList.Add(new Units("BBL/d", "GPH (US)", (decimal)1.75));
                Program.UnitsList.Add(new Units("BBL/d", "GPM (US)", (decimal)0.029));
                Program.UnitsList.Add(new Units("BBL/d", "GPS (US)", (decimal)0.0005));
                Program.UnitsList.Add(new Units("BBL/d", "L/day", (decimal)158.987));
                Program.UnitsList.Add(new Units("BBL/d", "L/hr", (decimal)6.624));
                Program.UnitsList.Add(new Units("BBL/d", "L/min", (decimal)0.11));
                Program.UnitsList.Add(new Units("BBL/d", "L/s", (decimal)0.002));
                Program.UnitsList.Add(new Units("BBL/d", "BBL/h", (decimal)0.042));

                //OK
                Program.UnitsList.Add(new Units("BBL/h", "ft³/day", (decimal)134.750));
                Program.UnitsList.Add(new Units("BBL/h", "ft³/hr", (decimal)5.615));
                Program.UnitsList.Add(new Units("BBL/h", "ft³/min", (decimal)0.094));
                Program.UnitsList.Add(new Units("BBL/h", "ft³/s", (decimal)0.002));
                Program.UnitsList.Add(new Units("BBL/h", "m³/day", (decimal)3.816));
                Program.UnitsList.Add(new Units("BBL/h", "m³/hr", (decimal)0.159));
                Program.UnitsList.Add(new Units("BBL/h", "m³/min", (decimal)0.003));
                Program.UnitsList.Add(new Units("BBL/h", "m³/s", (decimal)0.00004));
                Program.UnitsList.Add(new Units("BBL/h", "GPD (Imp)", (decimal)839.336));
                Program.UnitsList.Add(new Units("BBL/h", "GPH (Imp)", (decimal)34.972));
                Program.UnitsList.Add(new Units("BBL/h", "GPM (Imp)", (decimal)0.7));
                Program.UnitsList.Add(new Units("BBL/h", "GPS (Imp)", (decimal)0.01));
                Program.UnitsList.Add(new Units("BBL/h", "GPD (US)", (decimal)1008));
                Program.UnitsList.Add(new Units("BBL/h", "GPH (US)", (decimal)42));
                Program.UnitsList.Add(new Units("BBL/h", "GPM (US)", (decimal)0.7));
                Program.UnitsList.Add(new Units("BBL/h", "GPS (US)", (decimal)0.012));
                Program.UnitsList.Add(new Units("BBL/h", "L/day", (decimal)3815.695));
                Program.UnitsList.Add(new Units("BBL/h", "L/hr", (decimal)158.987));
                Program.UnitsList.Add(new Units("BBL/h", "L/min", (decimal)2.650));
                Program.UnitsList.Add(new Units("BBL/h", "L/s", (decimal)0.044));
                Program.UnitsList.Add(new Units("BBL/h", "BBL/d", (decimal)24));


                //OK
                Program.UnitsList.Add(new Units("Nm³/day", "MMSCFD", (decimal)0.000037326));
                Program.UnitsList.Add(new Units("Nm³/day", "MMSCFH", (decimal)0.000001555));
                Program.UnitsList.Add(new Units("Nm³/day", "MMSCFM", (decimal)0.000000026));
                Program.UnitsList.Add(new Units("Nm³/day", "Nm³/hr", (decimal)0.042));
                Program.UnitsList.Add(new Units("Nm³/day", "Nm³/min", (decimal)0.001));
                Program.UnitsList.Add(new Units("Nm³/day", "Nm³/s", (decimal)0.00001));
                Program.UnitsList.Add(new Units("Nm³/day", "SCFD", (decimal)37.326));
                Program.UnitsList.Add(new Units("Nm³/day", "SCFH", (decimal)1.555));
                Program.UnitsList.Add(new Units("Nm³/day", "SCFM", (decimal)0.026));
                Program.UnitsList.Add(new Units("Nm³/day", "SCFS", (decimal)0.0004));
                Program.UnitsList.Add(new Units("Nm³/day", "Sm³/hr", (decimal)0.044));
                Program.UnitsList.Add(new Units("Nm³/day", "Sm³/min", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("Nm³/hr", "MMSCFD", (decimal)0.000895819));
                Program.UnitsList.Add(new Units("Nm³/hr", "MMSCFH", (decimal)0.000037326));
                Program.UnitsList.Add(new Units("Nm³/hr", "MMSCFM", (decimal)0.000000622));
                Program.UnitsList.Add(new Units("Nm³/hr", "Nm³/day", (decimal)24));
                Program.UnitsList.Add(new Units("Nm³/hr", "Nm³/min", (decimal)0.017));
                Program.UnitsList.Add(new Units("Nm³/hr", "Nm³/s", (decimal)0.0003));
                Program.UnitsList.Add(new Units("Nm³/hr", "SCFD", (decimal)895.819));
                Program.UnitsList.Add(new Units("Nm³/hr", "SCFH", (decimal)37.326));
                Program.UnitsList.Add(new Units("Nm³/hr", "SCFM", (decimal)0.622));
                Program.UnitsList.Add(new Units("Nm³/hr", "SCFS", (decimal)0.01));
                Program.UnitsList.Add(new Units("Nm³/hr", "Sm³/hr", (decimal)1.057));
                Program.UnitsList.Add(new Units("Nm³/hr", "Sm³/min", (decimal)0.018));

                //OK
                Program.UnitsList.Add(new Units("Nm³/min", "MMSCFD", (decimal)0.053749143));
                Program.UnitsList.Add(new Units("Nm³/min", "MMSCFH", (decimal)0.00223954));
                Program.UnitsList.Add(new Units("Nm³/min", "MMSCFM", (decimal)0.000037326));
                Program.UnitsList.Add(new Units("Nm³/min", "Nm³/day", (decimal)1440));
                Program.UnitsList.Add(new Units("Nm³/min", "Nm³/hr", (decimal)60));
                Program.UnitsList.Add(new Units("Nm³/min", "Nm³/s", (decimal)0.017));
                Program.UnitsList.Add(new Units("Nm³/min", "SCFD", (decimal)53749.143));
                Program.UnitsList.Add(new Units("Nm³/min", "SCFH", (decimal)2239.548));
                Program.UnitsList.Add(new Units("Nm³/min", "SCFM", (decimal)37.326));
                Program.UnitsList.Add(new Units("Nm³/min", "SCFS", (decimal)0.622));
                Program.UnitsList.Add(new Units("Nm³/min", "Sm³/hr", (decimal)63.417));
                Program.UnitsList.Add(new Units("Nm³/min", "Sm³/min", (decimal)1.057));

                //OK
                Program.UnitsList.Add(new Units("Nm³/s", "MMSCFD", (decimal)3.225));
                Program.UnitsList.Add(new Units("Nm³/s", "MMSCFH", (decimal)0.134));
                Program.UnitsList.Add(new Units("Nm³/s", "MMSCFM", (decimal)0.002));
                Program.UnitsList.Add(new Units("Nm³/s", "Nm³/day", (decimal)86400));
                Program.UnitsList.Add(new Units("Nm³/s", "Nm³/hr", (decimal)3600));
                Program.UnitsList.Add(new Units("Nm³/s", "Nm³/min", (decimal)60));
                Program.UnitsList.Add(new Units("Nm³/s", "SCFD", (decimal)3224948.552));
                Program.UnitsList.Add(new Units("Nm³/s", "SCFH", (decimal)134372.856));
                Program.UnitsList.Add(new Units("Nm³/s", "SCFM", (decimal)2239.548));
                Program.UnitsList.Add(new Units("Nm³/s", "SCFS", (decimal)37.326));
                Program.UnitsList.Add(new Units("Nm³/s", "Sm³/hr", (decimal)3805.016));
                Program.UnitsList.Add(new Units("Nm³/s", "Sm³/min", (decimal)63.417));

                //OK
                Program.UnitsList.Add(new Units("SCFD", "MMSCFD", (decimal)0.000001));
                Program.UnitsList.Add(new Units("SCFD", "MMSCFH", (decimal)0.000000042));
                Program.UnitsList.Add(new Units("SCFD", "MMSCFM", (decimal)0.000000001));
                Program.UnitsList.Add(new Units("SCFD", "Nm³/day", (decimal)0.026791125));
                Program.UnitsList.Add(new Units("SCFD", "Nm³/hr", (decimal)0.001116297));
                Program.UnitsList.Add(new Units("SCFD", "Nm³/min", (decimal)0.000018605));
                Program.UnitsList.Add(new Units("SCFD", "Nm³/s", (decimal)0.00000031));
                Program.UnitsList.Add(new Units("SCFD", "SCFH", (decimal)0.042));
                Program.UnitsList.Add(new Units("SCFD", "SCFM", (decimal)0.001));
                Program.UnitsList.Add(new Units("SCFD", "SCFS", (decimal)0.000011574));
                Program.UnitsList.Add(new Units("SCFD", "Sm³/hr", (decimal)0.001179869));
                Program.UnitsList.Add(new Units("SCFD", "Sm³/min", (decimal)0.000019664));

                //OK
                Program.UnitsList.Add(new Units("SCFH", "MMSCFD", (decimal)0.00002));
                Program.UnitsList.Add(new Units("SCFH", "MMSCFH", (decimal)0.000001));
                Program.UnitsList.Add(new Units("SCFH", "MMSCFM", (decimal)0.00000002));
                Program.UnitsList.Add(new Units("SCFH", "Nm³/day", (decimal)0.642987002));
                Program.UnitsList.Add(new Units("SCFH", "Nm³/hr", (decimal)0.026791125));
                Program.UnitsList.Add(new Units("SCFH", "Nm³/min", (decimal)0.000446519));
                Program.UnitsList.Add(new Units("SCFH", "Nm³/s", (decimal)0.000007442));
                Program.UnitsList.Add(new Units("SCFH", "SCFD", (decimal)24));
                Program.UnitsList.Add(new Units("SCFH", "SCFM", (decimal)0.017));
                Program.UnitsList.Add(new Units("SCFH", "SCFS", (decimal)0.000277778));
                Program.UnitsList.Add(new Units("SCFH", "Sm³/hr", (decimal)0.028));
                Program.UnitsList.Add(new Units("SCFH", "Sm³/min", (decimal)0.000471947));

                //OK
                Program.UnitsList.Add(new Units("SCFM", "MMSCFD", (decimal)0.001));
                Program.UnitsList.Add(new Units("SCFM", "MMSCFH", (decimal)0.0001));
                Program.UnitsList.Add(new Units("SCFM", "MMSCFM", (decimal)0.000001));
                Program.UnitsList.Add(new Units("SCFM", "Nm³/day", (decimal)38.579));
                Program.UnitsList.Add(new Units("SCFM", "Nm³/hr", (decimal)1.607));
                Program.UnitsList.Add(new Units("SCFM", "Nm³/min", (decimal)0.027));
                Program.UnitsList.Add(new Units("SCFM", "Nm³/s", (decimal)0.000446519));
                Program.UnitsList.Add(new Units("SCFM", "SCFD", (decimal)1440));
                Program.UnitsList.Add(new Units("SCFM", "SCFH", (decimal)60));
                Program.UnitsList.Add(new Units("SCFM", "SCFS", (decimal)0.017));
                Program.UnitsList.Add(new Units("SCFM", "Sm³/hr", (decimal)1.699));
                Program.UnitsList.Add(new Units("SCFM", "Sm³/min", (decimal)0.028));

                //OK
                Program.UnitsList.Add(new Units("SCFS", "MMSCFD", (decimal)0.086));
                Program.UnitsList.Add(new Units("SCFS", "MMSCFH", (decimal)0.004));
                Program.UnitsList.Add(new Units("SCFS", "MMSCFM", (decimal)0.0001));
                Program.UnitsList.Add(new Units("SCFS", "Nm³/day", (decimal)2314.753));
                Program.UnitsList.Add(new Units("SCFS", "Nm³/hr", (decimal)96.448));
                Program.UnitsList.Add(new Units("SCFS", "Nm³/min", (decimal)1.607));
                Program.UnitsList.Add(new Units("SCFS", "Nm³/s", (decimal)0.027));
                Program.UnitsList.Add(new Units("SCFS", "SCFD", (decimal)86400));
                Program.UnitsList.Add(new Units("SCFS", "SCFM", (decimal)60));
                Program.UnitsList.Add(new Units("SCFS", "SCFH", (decimal)3600));
                Program.UnitsList.Add(new Units("SCFS", "Sm³/hr", (decimal)101.941));
                Program.UnitsList.Add(new Units("SCFS", "Sm³/min", (decimal)1.699));

                //OK
                Program.UnitsList.Add(new Units("Sm³/hr", "MMSCFD", (decimal)0.000847552));
                Program.UnitsList.Add(new Units("Sm³/hr", "MMSCFH", (decimal)0.002));
                Program.UnitsList.Add(new Units("Sm³/hr", "MMSCFM", (decimal)0.000000589));
                Program.UnitsList.Add(new Units("Sm³/hr", "Nm³/day", (decimal)22.707));
                Program.UnitsList.Add(new Units("Sm³/hr", "Nm³/hr", (decimal)0.946));
                Program.UnitsList.Add(new Units("Sm³/hr", "Nm³/min", (decimal)0.016));
                Program.UnitsList.Add(new Units("Sm³/hr", "Nm³/s", (decimal)0.015768661));
                Program.UnitsList.Add(new Units("Sm³/hr", "SCFD", (decimal)847.552));
                Program.UnitsList.Add(new Units("Sm³/hr", "SCFM", (decimal)0.589));
                Program.UnitsList.Add(new Units("Sm³/hr", "SCFH", (decimal)35.315));
                Program.UnitsList.Add(new Units("Sm³/hr", "SCFS", (decimal)0.01));
                Program.UnitsList.Add(new Units("Sm³/hr", "Sm³/min", (decimal)0.017));

                //OK
                Program.UnitsList.Add(new Units("Sm³/min", "MMSCFD", (decimal)0.05085312));
                Program.UnitsList.Add(new Units("Sm³/min", "MMSCFH", (decimal)0.002));
                Program.UnitsList.Add(new Units("Sm³/min", "MMSCFM", (decimal)0.000035315));
                Program.UnitsList.Add(new Units("Sm³/min", "Nm³/day", (decimal)1362.412));
                Program.UnitsList.Add(new Units("Sm³/min", "Nm³/hr", (decimal)56.767));
                Program.UnitsList.Add(new Units("Sm³/min", "Nm³/min", (decimal)0.946));
                Program.UnitsList.Add(new Units("Sm³/min", "Nm³/s", (decimal)0.016));
                Program.UnitsList.Add(new Units("Sm³/min", "SCFD", (decimal)50853.12));
                Program.UnitsList.Add(new Units("Sm³/min", "SCFM", (decimal)35.315));
                Program.UnitsList.Add(new Units("Sm³/min", "SCFH", (decimal)2118.88));
                Program.UnitsList.Add(new Units("Sm³/min", "SCFS", (decimal)0.589));
                Program.UnitsList.Add(new Units("Sm³/min", "Sm³/hr", (decimal)60));


                //OK
                Program.UnitsList.Add(new Units("MMSCFD", "MMSCFH", (decimal)0.042));
                Program.UnitsList.Add(new Units("MMSCFD", "MMSCFM", (decimal)0.001));
                Program.UnitsList.Add(new Units("MMSCFD", "Nm³/day", (decimal)26791.125));
                Program.UnitsList.Add(new Units("MMSCFD", "Nm³/hr", (decimal)1116.297));
                Program.UnitsList.Add(new Units("MMSCFD", "Nm³/min", (decimal)18.605));
                Program.UnitsList.Add(new Units("MMSCFD", "Nm³/s", (decimal)0.31));
                Program.UnitsList.Add(new Units("MMSCFD", "SCFD", (decimal)1000000));
                Program.UnitsList.Add(new Units("MMSCFD", "SCFH", (decimal)41666.67));
                Program.UnitsList.Add(new Units("MMSCFD", "SCFM", (decimal)694.44));
                Program.UnitsList.Add(new Units("MMSCFD", "SCFS", (decimal)11.574));
                Program.UnitsList.Add(new Units("MMSCFD", "Sm³/hr", (decimal)1179.869));
                Program.UnitsList.Add(new Units("MMSCFD", "Sm³/min", (decimal)19.664));


                //OK
                Program.UnitsList.Add(new Units("MMSCFH", "MMSCFD", (decimal)24));
                Program.UnitsList.Add(new Units("MMSCFH", "MMSCFM", (decimal)0.017));
                Program.UnitsList.Add(new Units("MMSCFH", "Nm³/day", (decimal)642987.003));
                Program.UnitsList.Add(new Units("MMSCFH", "Nm³/hr", (decimal)26791.125));
                Program.UnitsList.Add(new Units("MMSCFH", "Nm³/min", (decimal)446.519));
                Program.UnitsList.Add(new Units("MMSCFH", "Nm³/s", (decimal)7.442));
                Program.UnitsList.Add(new Units("MMSCFH", "SCFD", (decimal)24000000.061));
                Program.UnitsList.Add(new Units("MMSCFH", "SCFH", (decimal)1000000.003));
                Program.UnitsList.Add(new Units("MMSCFH", "SCFM", (decimal)16666.667));
                Program.UnitsList.Add(new Units("MMSCFH", "SCFS", (decimal)277.778));
                Program.UnitsList.Add(new Units("MMSCFH", "Sm³/hr", (decimal)28316.847));
                Program.UnitsList.Add(new Units("MMSCFH", "Sm³/min", (decimal)471.947));

                //OK
                Program.UnitsList.Add(new Units("MMSCFM", "MMSCFD", 1440));
                Program.UnitsList.Add(new Units("MMSCFM", "MMSCFH", 60));
                Program.UnitsList.Add(new Units("MMSCFM", "Nm³/day", (decimal)38579213.306));
                Program.UnitsList.Add(new Units("MMSCFM", "Nm³/hr", (decimal)1607467.221));
                Program.UnitsList.Add(new Units("MMSCFM", "Nm³/min", (decimal)26791.12));
                Program.UnitsList.Add(new Units("MMSCFM", "Nm³/s", (decimal)446.519));
                Program.UnitsList.Add(new Units("MMSCFM", "SCFD", (decimal)1439999746.49));
                Program.UnitsList.Add(new Units("MMSCFM", "SCFH", (decimal)59999989.437));
                Program.UnitsList.Add(new Units("MMSCFM", "SCFM", (decimal)999999.824));
                Program.UnitsList.Add(new Units("MMSCFM", "SCFS", (decimal)16666.664));
                Program.UnitsList.Add(new Units("MMSCFM", "Sm³/hr", (decimal)1699010.496));
                Program.UnitsList.Add(new Units("MMSCFM", "Sm³/min", (decimal)28316.842));

                //OK
                Program.UnitsList.Add(new Units("kg/day", "kg/hr", (decimal)0.041666666));
                Program.UnitsList.Add(new Units("kg/day", "kg/min", (decimal)0.00069444444443));
                Program.UnitsList.Add(new Units("kg/day", "kg/s", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("kg/day", "lb/day", (decimal)2.2046244202));
                Program.UnitsList.Add(new Units("kg/day", "lb/hr", (decimal)0.091859350839));
                Program.UnitsList.Add(new Units("kg/day", "lb/min", (decimal)0.0015309891807));
                Program.UnitsList.Add(new Units("kg/day", "lb/s", (decimal)0.000025516486345));
                Program.UnitsList.Add(new Units("kg/day", "Ton,long/day", (decimal)0.0009842073304));
                Program.UnitsList.Add(new Units("kg/day", "Ton,long/hr", (decimal)0.000041008638768));
                Program.UnitsList.Add(new Units("kg/day", "Ton,long/s", (decimal)0.000000011391288547));
                Program.UnitsList.Add(new Units("kg/day", "Ton(US)/day", (decimal)0.0011023122101));
                Program.UnitsList.Add(new Units("kg/day", "Ton(US)/hr", (decimal)0.000045929675419));
                Program.UnitsList.Add(new Units("kg/day", "Ton(US)/s", (decimal)0.000000012758243172));
                Program.UnitsList.Add(new Units("kg/day", "Ton(mt)/day", (decimal)0.001));
                Program.UnitsList.Add(new Units("kg/day", "Ton(mt)/hr", (decimal)0.000041666666666));
                Program.UnitsList.Add(new Units("kg/day", "Ton(mt)/s", (decimal)0.000000011574074074));


                //OK
                Program.UnitsList.Add(new Units("kg/hr", "kg/day", 24));
                Program.UnitsList.Add(new Units("kg/hr", "kg/min", (decimal)0.016666666666));
                Program.UnitsList.Add(new Units("kg/hr", "kg/s", (decimal)0.00027777777778));
                Program.UnitsList.Add(new Units("kg/hr", "lb/day", (decimal)52.910986085));
                Program.UnitsList.Add(new Units("kg/hr", "lb/hr", (decimal)2.2046244202));
                Program.UnitsList.Add(new Units("kg/hr", "lb/min", (decimal)0.036743740337));
                Program.UnitsList.Add(new Units("kg/hr", "lb/s", (decimal)0.00061239567228));
                Program.UnitsList.Add(new Units("kg/hr", "Ton,long/day", (decimal)0.02362097593));
                Program.UnitsList.Add(new Units("kg/hr", "Ton,long/hr", (decimal)0.00098420733045));
                Program.UnitsList.Add(new Units("kg/hr", "Ton,long/s", (decimal)0.00000027339092512));
                Program.UnitsList.Add(new Units("kg/hr", "Ton(US)/day", (decimal)0.026455493042));
                Program.UnitsList.Add(new Units("kg/hr", "Ton(US)/hr", (decimal)0.0011023122101));
                Program.UnitsList.Add(new Units("kg/hr", "Ton(US)/s", (decimal)0.00000030619783614));
                Program.UnitsList.Add(new Units("kg/hr", "Ton(mt)/day", (decimal)0.024));
                Program.UnitsList.Add(new Units("kg/hr", "Ton(mt)/hr", (decimal)0.001));
                Program.UnitsList.Add(new Units("kg/hr", "Ton(mt)/s", (decimal)0.00000027777777778));

                //OK
                Program.UnitsList.Add(new Units("kg/min", "kg/day", 1440));
                Program.UnitsList.Add(new Units("kg/min", "kg/hr", (decimal)60.000000001));
                Program.UnitsList.Add(new Units("kg/min", "kg/s", (decimal)0.01666666667));
                Program.UnitsList.Add(new Units("kg/min", "lb/day", (decimal)3174.6591651));
                Program.UnitsList.Add(new Units("kg/min", "lb/hr", (decimal)132.27746521));
                Program.UnitsList.Add(new Units("kg/min", "lb/min", (decimal)2.2046244202));
                Program.UnitsList.Add(new Units("kg/min", "lb/s", (decimal)0.036743740337));
                Program.UnitsList.Add(new Units("kg/min", "Ton,long/day", (decimal)1.4172585558));
                Program.UnitsList.Add(new Units("kg/min", "Ton,long/hr", (decimal)0.059052439828));
                Program.UnitsList.Add(new Units("kg/min", "Ton,long/s", (decimal)0.000016403455508));
                Program.UnitsList.Add(new Units("kg/min", "Ton(US)/day", (decimal)1.5873295825));
                Program.UnitsList.Add(new Units("kg/min", "Ton(US)/hr", (decimal)0.066138732606));
                Program.UnitsList.Add(new Units("kg/min", "Ton(US)/s", (decimal)0.000018371870169));
                Program.UnitsList.Add(new Units("kg/min", "Ton(mt)/day", (decimal)1.44));
                Program.UnitsList.Add(new Units("kg/min", "Ton(mt)/hr", (decimal)0.060000000001));
                Program.UnitsList.Add(new Units("kg/min", "Ton(mt)/s", (decimal)0.000016666666667));

                //OK
                Program.UnitsList.Add(new Units("kg/s", "kg/day", 86400));
                Program.UnitsList.Add(new Units("kg/s", "kg/hr", 3600));
                Program.UnitsList.Add(new Units("kg/s", "kg/min", 60));
                Program.UnitsList.Add(new Units("kg/s", "lb/day", (decimal)190479.5499));
                Program.UnitsList.Add(new Units("kg/s", "lb/hr", (decimal)7936.6479125));
                Program.UnitsList.Add(new Units("kg/s", "lb/min", (decimal)132.27746521));
                Program.UnitsList.Add(new Units("kg/s", "lb/s", (decimal)2.2046244202));
                Program.UnitsList.Add(new Units("kg/s", "Ton,long/day", (decimal)85.035513347));
                Program.UnitsList.Add(new Units("kg/s", "Ton,long/hr", (decimal)3.5431463896));
                Program.UnitsList.Add(new Units("kg/s", "Ton,long/s", (decimal)0.00098420733044));
                Program.UnitsList.Add(new Units("kg/s", "Ton(US)/day", (decimal)95.23977495));
                Program.UnitsList.Add(new Units("kg/s", "Ton(US)/hr", (decimal)3.9683239563));
                Program.UnitsList.Add(new Units("kg/s", "Ton(US)/s", (decimal)0.0011023122101));
                Program.UnitsList.Add(new Units("kg/s", "Ton(mt)/day", (decimal)86.400000001));
                Program.UnitsList.Add(new Units("kg/s", "Ton(mt)/hr", (decimal)3.6));
                Program.UnitsList.Add(new Units("kg/s", "Ton(mt)/s", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("lb/day", "kg/day", (decimal)0.453592));
                Program.UnitsList.Add(new Units("lb/day", "kg/hr", (decimal)0.018899666666));
                Program.UnitsList.Add(new Units("lb/day", "kg/min", (decimal)0.00031499444444));
                Program.UnitsList.Add(new Units("lb/day", "kg/s", (decimal)0.0000052499074074));
                Program.UnitsList.Add(new Units("lb/day", "lb/hr", (decimal)0.041666666666));
                Program.UnitsList.Add(new Units("lb/day", "lb/min", (decimal)0.00069444444444));
                Program.UnitsList.Add(new Units("lb/day", "lb/s", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("lb/day", "Ton,long/day", (decimal)0.00044642857141));
                Program.UnitsList.Add(new Units("lb/day", "Ton,long/hr", (decimal)0.000018601190476));
                Program.UnitsList.Add(new Units("lb/day", "Ton,long/s", (decimal)0.0000000051669973545));
                Program.UnitsList.Add(new Units("lb/day", "Ton(US)/day", (decimal)0.00049999999999));
                Program.UnitsList.Add(new Units("lb/day", "Ton(US)/hr", (decimal)0.000020833333333));
                Program.UnitsList.Add(new Units("lb/day", "Ton(US)/s", (decimal)0.000000005787037037));
                Program.UnitsList.Add(new Units("lb/day", "Ton(mt)/day", (decimal)0.000453592));
                Program.UnitsList.Add(new Units("lb/day", "Ton(mt)/hr", (decimal)0.000018899666666));
                Program.UnitsList.Add(new Units("lb/day", "Ton(mt)/s", (decimal)0.0000000052499074074));

                //OK
                Program.UnitsList.Add(new Units("lb/hr", "kg/day", (decimal)10.886208));
                Program.UnitsList.Add(new Units("lb/hr", "kg/hr", (decimal)0.453592));
                Program.UnitsList.Add(new Units("lb/hr", "kg/min", (decimal)0.0075598666666));
                Program.UnitsList.Add(new Units("lb/hr", "Kg/s", (decimal)0.00012599777778));
                Program.UnitsList.Add(new Units("lb/hr", "lb/day", 24));
                Program.UnitsList.Add(new Units("lb/hr", "lb/min", (decimal)0.016666666667));
                Program.UnitsList.Add(new Units("lb/hr", "lb/s", (decimal)0.00027777777778));
                Program.UnitsList.Add(new Units("lb/hr", "Ton,long/day", (decimal)0.010714285714));
                Program.UnitsList.Add(new Units("lb/hr", "Ton,long/hr", (decimal)0.00044642857144));
                Program.UnitsList.Add(new Units("lb/hr", "Ton,long/s", (decimal)0.00000012400793651));
                Program.UnitsList.Add(new Units("lb/hr", "Ton(US)/day", (decimal)0.012));
                Program.UnitsList.Add(new Units("lb/hr", "Ton(US)/hr", (decimal)0.0005));
                Program.UnitsList.Add(new Units("lb/hr", "Ton(US)/s", (decimal)0.00000013888888889));
                Program.UnitsList.Add(new Units("lb/hr", "Ton(mt)/day", (decimal)0.010886208));
                Program.UnitsList.Add(new Units("lb/hr", "Ton(mt)/hr", (decimal)0.000453592));
                Program.UnitsList.Add(new Units("lb/hr", "Ton(mt)/s", (decimal)0.00000012599777778));

                //OK
                Program.UnitsList.Add(new Units("lb/min", "kg/day", (decimal)653.17248001));
                Program.UnitsList.Add(new Units("lb/min", "kg/hr", (decimal)27.21552));
                Program.UnitsList.Add(new Units("lb/min", "kg/min", (decimal)0.45359199999));
                Program.UnitsList.Add(new Units("lb/min", "Kg/s", (decimal)0.0075598666667));
                Program.UnitsList.Add(new Units("lb/min", "lb/day", 1440));
                Program.UnitsList.Add(new Units("lb/min", "lb/hr", 60));
                Program.UnitsList.Add(new Units("lb/min", "lb/s", (decimal)0.016666666667));
                Program.UnitsList.Add(new Units("lb/min", "Ton,long/day", (decimal)0.64285714284));
                Program.UnitsList.Add(new Units("lb/min", "Ton,long/hr", (decimal)0.026785714286));
                Program.UnitsList.Add(new Units("lb/min", "Ton,long/s", (decimal)0.0000074404761905));
                Program.UnitsList.Add(new Units("lb/min", "Ton(US)/day", (decimal)0.71999999999));
                Program.UnitsList.Add(new Units("lb/min", "Ton(US)/hr", (decimal)0.03));
                Program.UnitsList.Add(new Units("lb/min", "Ton(US)/s", (decimal)0.0000083333333334));
                Program.UnitsList.Add(new Units("lb/min", "Ton(mt)/day", (decimal)0.65317248001));
                Program.UnitsList.Add(new Units("lb/min", "Ton(mt)/hr", (decimal)0.02721552));
                Program.UnitsList.Add(new Units("lb/min", "Ton(mt)/s", (decimal)0.0000075598666667));

                //OK
                Program.UnitsList.Add(new Units("lb/s", "kg/day", (decimal)39190.3488));
                Program.UnitsList.Add(new Units("lb/s", "kg/hr", (decimal)1632.9312));
                Program.UnitsList.Add(new Units("lb/s", "kg/min", (decimal)27.215519999));
                Program.UnitsList.Add(new Units("lb/s", "Kg/s", (decimal)0.453592));
                Program.UnitsList.Add(new Units("lb/s", "lb/day", 86400));
                Program.UnitsList.Add(new Units("lb/s", "lb/hr", (decimal)3599.9999999));
                Program.UnitsList.Add(new Units("lb/s", "lb/min", 60));
                Program.UnitsList.Add(new Units("lb/s", "Ton,long/day", (decimal)38.57142857));
                Program.UnitsList.Add(new Units("lb/s", "Ton,long/hr", (decimal)1.6071428572));
                Program.UnitsList.Add(new Units("lb/s", "Ton,long/s", (decimal)0.00044642857143));
                Program.UnitsList.Add(new Units("lb/s", "Ton(US)/day", (decimal)43.199999999));
                Program.UnitsList.Add(new Units("lb/s", "Ton(US)/hr", (decimal)1.8));
                Program.UnitsList.Add(new Units("lb/s", "Ton(US)/s", (decimal)0.0005));
                Program.UnitsList.Add(new Units("lb/s", "Ton(mt)/day", (decimal)39.1903488));
                Program.UnitsList.Add(new Units("lb/s", "Ton(mt)/hr", (decimal)1.6329312));
                Program.UnitsList.Add(new Units("lb/s", "Ton(mt)/s", (decimal)0.000453592));

                //OK
                Program.UnitsList.Add(new Units("Ton,long/day", "kg/day", (decimal)(1 / 0.0009842073304)));
                Program.UnitsList.Add(new Units("Ton,long/day", "kg/hr", (decimal)(1 / 0.02362097593)));
                Program.UnitsList.Add(new Units("Ton,long/day", "kg/min", (decimal)(1 / 1.4172585558)));
                Program.UnitsList.Add(new Units("Ton,long/day", "Kg/s", (decimal)(1 / 85.035513347)));
                Program.UnitsList.Add(new Units("Ton,long/day", "lb/day", (decimal)(1 / 0.00044642857141)));
                Program.UnitsList.Add(new Units("Ton,long/day", "lb/hr", (decimal)(1 / 0.010714285714)));
                Program.UnitsList.Add(new Units("Ton,long/day", "lb/min", (decimal)(1 / 0.64285714284)));
                Program.UnitsList.Add(new Units("Ton,long/day", "lb/s", (decimal)(1 / 38.57142857)));
                Program.UnitsList.Add(new Units("Ton,long/day", "Ton,long/hr", (decimal)0.041666666668));
                Program.UnitsList.Add(new Units("Ton,long/day", "Ton,long/s", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("Ton,long/day", "Ton(US)/day", (decimal)1.12));
                Program.UnitsList.Add(new Units("Ton,long/day", "Ton(US)/hr", (decimal)0.046666666667));
                Program.UnitsList.Add(new Units("Ton,long/day", "Ton(US)/s", (decimal)0.000012962962963));
                Program.UnitsList.Add(new Units("Ton,long/day", "Ton(mt)/day", (decimal)1.01604608));
                Program.UnitsList.Add(new Units("Ton,long/day", "Ton(mt)/hr", (decimal)0.042335253334));
                Program.UnitsList.Add(new Units("Ton,long/day", "Ton(mt)/s", (decimal)0.000011759792593));

                //OK
                Program.UnitsList.Add(new Units("Ton,long/hr", "kg/day", (decimal)(1 / 0.000041008638768)));
                Program.UnitsList.Add(new Units("Ton,long/hr", "kg/hr", (decimal)(1 / 0.00098420733045)));
                Program.UnitsList.Add(new Units("Ton,long/hr", "kg/min", (decimal)(1 / 0.059052439828)));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Kg/s", (decimal)(1 / 3.5431463896)));
                Program.UnitsList.Add(new Units("Ton,long/hr", "lb/day", (decimal)(1 / 0.000018601190476)));
                Program.UnitsList.Add(new Units("Ton,long/hr", "lb/hr", (decimal)(1 / 0.00044642857144)));
                Program.UnitsList.Add(new Units("Ton,long/hr", "lb/min", (decimal)(1 / 0.026785714286)));
                Program.UnitsList.Add(new Units("Ton,long/hr", "lb/s", (decimal)(1 / 1.6071428572)));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Ton,long/day", (decimal)23.999999999));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Ton,long/s", (decimal)0.00027777777778));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Ton(US)/day", (decimal)26.879999999));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Ton(US)/hr", (decimal)1.12));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Ton(US)/s", (decimal)0.00031111111111));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Ton(mt)/day", (decimal)24.38510592));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Ton(mt)/hr", (decimal)1.01604608));
                Program.UnitsList.Add(new Units("Ton,long/hr", "Ton(mt)/s", (decimal)0.00028223502222));

                //OK
                Program.UnitsList.Add(new Units("Ton,long/s", "kg/day", (decimal)(1 / 0.000000011391288547)));
                Program.UnitsList.Add(new Units("Ton,long/s", "kg/hr", (decimal)(1 / 0.00000027339092512)));
                Program.UnitsList.Add(new Units("Ton,long/s", "kg/min", (decimal)(1 / 0.000016403455508)));
                Program.UnitsList.Add(new Units("Ton,long/s", "Kg/s", (decimal)(1 / 0.00098420733044)));
                Program.UnitsList.Add(new Units("Ton,long/s", "lb/day", (decimal)(1 / 0.0000000051669973545)));
                Program.UnitsList.Add(new Units("Ton,long/s", "lb/hr", (decimal)(1 / 0.00000012400793651)));
                Program.UnitsList.Add(new Units("Ton,long/s", "lb/min", (decimal)(1 / 0.0000074404761905)));
                Program.UnitsList.Add(new Units("Ton,long/s", "lb/s", (decimal)(1 / 0.00044642857143)));
                Program.UnitsList.Add(new Units("Ton,long/s", "Ton,long/day", (decimal)86399.999997));
                Program.UnitsList.Add(new Units("Ton,long/s", "Ton,long/hr", (decimal)3600));
                Program.UnitsList.Add(new Units("Ton,long/s", "Ton(US)/day", (decimal)96767.999998));
                Program.UnitsList.Add(new Units("Ton,long/s", "Ton(US)/hr", (decimal)4031.9999999));
                Program.UnitsList.Add(new Units("Ton,long/s", "Ton(US)/s", (decimal)1.12));
                Program.UnitsList.Add(new Units("Ton,long/s", "Ton(mt)/day", (decimal)87786.381313));
                Program.UnitsList.Add(new Units("Ton,long/s", "Ton(mt)/hr", (decimal)3657.765888));
                Program.UnitsList.Add(new Units("Ton,long/s", "Ton(mt)/s", (decimal)1.01604608));

                //OK
                Program.UnitsList.Add(new Units("Ton(US)/day", "kg/day", (decimal)(1 / 0.0011023122101)));
                Program.UnitsList.Add(new Units("Ton(US)/day", "kg/hr", (decimal)(1 / 0.026455493042)));
                Program.UnitsList.Add(new Units("Ton(US)/day", "kg/min", (decimal)(1 / 1.5873295825)));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Kg/s", (decimal)(1 / 95.23977495)));
                Program.UnitsList.Add(new Units("Ton(US)/day", "lb/day", (decimal)(1 / 0.00049999999999)));
                Program.UnitsList.Add(new Units("Ton(US)/day", "lb/hr", (decimal)(1 / 0.012)));
                Program.UnitsList.Add(new Units("Ton(US)/day", "lb/min", (decimal)(1 / 0.71999999999)));
                Program.UnitsList.Add(new Units("Ton(US)/day", "lb/s", (decimal)(1 / 43.199999999)));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Ton,long/day", (decimal)0.89285714284));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Ton,long/hr", (decimal)0.037202380953));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Ton,long/s", (decimal)0.000010333994709));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Ton(US)/hr", (decimal)0.041666666667));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Ton(US)/s", (decimal)0.000011574074074));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Ton(mt)/day", (decimal)0.90718400002));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Ton(mt)/hr", (decimal)0.037799333334));
                Program.UnitsList.Add(new Units("Ton(US)/day", "Ton(mt)/s", (decimal)0.000010499814815));

                //OK
                Program.UnitsList.Add(new Units("Ton(US)/hr", "kg/day", (decimal)(1 / 0.000041666666666)));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "kg/hr", (decimal)(1 / 0.0011023122101)));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "kg/min", (decimal)(1 / 0.066138732606)));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Kg/s", (decimal)(1 / 3.9683239563)));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "lb/day", (decimal)(1 / 0.000020833333333)));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "lb/hr", (decimal)(1 / 0.0005)));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "lb/min", (decimal)(1 / 0.03)));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "lb/s", (decimal)(1 / 1.8)));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Ton,long/day", (decimal)21.428571428));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Ton,long/hr", (decimal)0.89285714288));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Ton,long/s", (decimal)0.00024801587302));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Ton(US)/day", 24));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Ton(US)/s", (decimal)0.00027777777778));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Ton(mt)/day", (decimal)21.772416001));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Ton(mt)/hr", (decimal)0.90718400001));
                Program.UnitsList.Add(new Units("Ton(US)/hr", "Ton(mt)/s", (decimal)0.00025199555556));

                //OK
                Program.UnitsList.Add(new Units("Ton(US)/s", "kg/day", (decimal)(1 / 0.000000012758243172)));
                Program.UnitsList.Add(new Units("Ton(US)/s", "kg/hr", (decimal)(1 / 0.00000030619783614)));
                Program.UnitsList.Add(new Units("Ton(US)/s", "kg/min", (decimal)(1 / 0.000018371870169)));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Kg/s", (decimal)(1 / 0.0011023122101)));
                Program.UnitsList.Add(new Units("Ton(US)/s", "lb/day", (decimal)(1 / 0.000000005787037037)));
                Program.UnitsList.Add(new Units("Ton(US)/s", "lb/hr", (decimal)(1 / 0.00000013888888889)));
                Program.UnitsList.Add(new Units("Ton(US)/s", "lb/min", (decimal)(1 / 0.0000083333333334)));
                Program.UnitsList.Add(new Units("Ton(US)/s", "lb/s", (decimal)(1 / 0.0005)));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Ton,long/day", (decimal)77142.85714));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Ton,long/hr", (decimal)3214.2857143));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Ton,long/s", (decimal)0.89285714286));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Ton(US)/day", (decimal)86399.999998));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Ton(US)/hr", (decimal)3599.9999999));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Ton(mt)/day", (decimal)78380.697601));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Ton(mt)/hr", (decimal)3265.8624));
                Program.UnitsList.Add(new Units("Ton(US)/s", "Ton(mt)/s", (decimal)0.907184));

                //OK
                Program.UnitsList.Add(new Units("Ton(mt)/day", "kg/day", (decimal)(1 / 0.001)));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "kg/hr", (decimal)(1 / 0.024)));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "kg/min", (decimal)(1 / 1.44)));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Kg/s", (decimal)(1 / 86.400000001)));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "lb/day", (decimal)(1 / 0.000453592)));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "lb/hr", (decimal)(1 / 0.010886208)));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "lb/min", (decimal)(1 / 0.65317248001)));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "lb/s", (decimal)(1 / 39.1903488)));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Ton,long/day", (decimal)0.9842073304));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Ton,long/hr", (decimal)0.041008638768));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Ton,long/s", (decimal)0.000011391288547));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Ton(US)/day", (decimal)1.1023122101));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Ton(US)/hr", (decimal)0.045929675419));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Ton(US)/s", (decimal)0.000012758243172));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Ton(mt)/hr", (decimal)0.041666666666));
                Program.UnitsList.Add(new Units("Ton(mt)/day", "Ton(mt)/s", (decimal)0.000011574074074));

                //OK
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "kg/day", (decimal)(1 / 0.000041666666666)));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "kg/hr", (decimal)(1 / 0.001)));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "kg/min", (decimal)(1 / 0.060000000001)));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Kg/s", (decimal)(1 / 3.6)));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "lb/day", (decimal)(1 / 0.000018899666666)));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "lb/hr", (decimal)(1 / 0.000453592)));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "lb/min", (decimal)(1 / 0.02721552)));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "lb/s", (decimal)(1 / 1.6329312)));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Ton,long/day", (decimal)23.62097593));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Ton,long/hr", (decimal)0.98420733045));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Ton,long/s", (decimal)0.00027339092512));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Ton(US)/day", (decimal)26.455493042));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Ton(US)/hr", (decimal)1.1023122101));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Ton(US)/s", (decimal)0.00030619783614));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Ton(mt)/day", (decimal)24));
                Program.UnitsList.Add(new Units("Ton(mt)/hr", "Ton(mt)/s", (decimal)0.00027777777778));

                //OK
                Program.UnitsList.Add(new Units("Ton(mt)/s", "kg/day", (decimal)(1 / 0.000000011574074074)));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "kg/hr", (decimal)(1 / 0.00000027777777778)));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "kg/min", (decimal)(1 / 0.000016666666667)));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Kg/s", (decimal)(1 / 0.001)));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "lb/day", (decimal)(1 / 0.0000000052499074074)));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "lb/hr", (decimal)(1 / 0.00000012599777778)));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "lb/min", (decimal)(1 / 0.0000075598666667)));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "lb/s", (decimal)(1 / 0.000453592)));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Ton,long/day", (decimal)85035.513347));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Ton,long/hr", (decimal)3543.1463896));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Ton,long/s", (decimal)0.98420733044));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Ton(US)/day", (decimal)26.455493042));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Ton(US)/hr", (decimal)95239.77495));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Ton(US)/s", (decimal)1.1023122101));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Ton(mt)/day", (decimal)86400.000001));
                Program.UnitsList.Add(new Units("Ton(mt)/s", "Ton(mt)/hr", 3600));

                //OK
                Program.UnitsList.Add(new Units("kg/L", "kg/m³", (decimal)1000));
                Program.UnitsList.Add(new Units("kg/L", "lb/ft³", (decimal)62.428));
                Program.UnitsList.Add(new Units("kg/L", "lb/Gal(US)", (decimal)8.3454));

                //OK
                Program.UnitsList.Add(new Units("kg/m³", "kg/L", (decimal)0.001));
                Program.UnitsList.Add(new Units("kg/m³", "lb/ft³", (decimal)0.062428));
                Program.UnitsList.Add(new Units("kg/m³", "lb/Gal(US)", (decimal)0.0083454));

                //OK
                Program.UnitsList.Add(new Units("lb/ft³", "kg/L", (decimal)0.0160185));
                Program.UnitsList.Add(new Units("lb/ft³", "kg/m³", (decimal)16.0185));
                Program.UnitsList.Add(new Units("lb/ft³", "lb/Gal(US)", (decimal)0.133681));

                //OK
                Program.UnitsList.Add(new Units("lb/Gal(US)", "kg/L", (decimal)0.119826));
                Program.UnitsList.Add(new Units("lb/Gal(US)", "kg/m³", (decimal)119.826));
                Program.UnitsList.Add(new Units("lb/Gal(US)", "lb/ft³", (decimal)7.48052));


                //OK
                Program.UnitsList.Add(new Units("ft³/lb", "Gal(US)/lb", (decimal)7.48052));
                Program.UnitsList.Add(new Units("ft³/lb", "L/kg", (decimal)62.428));
                Program.UnitsList.Add(new Units("ft³/lb", "m³/kg", (decimal)0.062428));

                //OK
                Program.UnitsList.Add(new Units("Gal(US)/lb", "ft³/lb", (decimal)0.133681));
                Program.UnitsList.Add(new Units("Gal(US)/lb", "L/Kg", (decimal)8.3454));
                Program.UnitsList.Add(new Units("Gal(US)/lb", "m³/kg", (decimal)0.0083454));

                //OK
                Program.UnitsList.Add(new Units("L/kg", "ft³/lb", (decimal)0.0160185));
                Program.UnitsList.Add(new Units("L/Kg", "Gal(US)/lb", (decimal)0.119826));
                Program.UnitsList.Add(new Units("L/kg", "m³/kg", (decimal)0.001));

                //OK
                Program.UnitsList.Add(new Units("m³/kg", "ft³/lb", (decimal)16.0185));
                Program.UnitsList.Add(new Units("m³/kg", "Gal(US)/lb", (decimal)119.826));
                Program.UnitsList.Add(new Units("m³/kg", "L/kg", (decimal)1000));

                //OK
                Program.UnitsList.Add(new Units("cm²/s", "cP", (decimal)100));
                Program.UnitsList.Add(new Units("cm²/s", "cSt", (decimal)100));
                Program.UnitsList.Add(new Units("cm²/s", "ft²/s", (decimal)0.00108));
                Program.UnitsList.Add(new Units("cm²/s", "in²/s", (decimal)0.155));
                Program.UnitsList.Add(new Units("cm²/s", "kg/m.hr", (decimal)359.99928));
                Program.UnitsList.Add(new Units("cm²/s", "lb/ft.hr", (decimal)241.90835));
                Program.UnitsList.Add(new Units("cm²/s", "lb/ft.s", (decimal)0.06720));
                Program.UnitsList.Add(new Units("cm²/s", "lbf.s/ft²", (decimal)0.00209));
                Program.UnitsList.Add(new Units("cm²/s", "m²/s", (decimal)0.0001));
                Program.UnitsList.Add(new Units("cm²/s", "mm²/s", (decimal)100));
                Program.UnitsList.Add(new Units("cm²/s", "mPa.s", (decimal)100));
                Program.UnitsList.Add(new Units("cm²/s", "N.s/m²", (decimal)0.1));
                Program.UnitsList.Add(new Units("cm²/s", "Pa.s", (decimal)0.1));
                Program.UnitsList.Add(new Units("cm²/s", "Poise", (decimal)1));
                Program.UnitsList.Add(new Units("cm²/s", "SSU", (decimal)453.57143));

                //OK
                Program.UnitsList.Add(new Units("cP", "cm²/s", (decimal)0.01));
                Program.UnitsList.Add(new Units("cP", "cSt", (decimal)1));
                Program.UnitsList.Add(new Units("cP", "ft²/s", (decimal)0.00001));
                Program.UnitsList.Add(new Units("cP", "in²/s", (decimal)0.00155));
                Program.UnitsList.Add(new Units("cP", "kg/m.hr", (decimal)3.59999));
                Program.UnitsList.Add(new Units("cP", "lb/ft.hr", (decimal)2.41909));
                Program.UnitsList.Add(new Units("cP", "lb/ft.s", (decimal)0.00067));
                Program.UnitsList.Add(new Units("cP", "lbf.s/ft²", (decimal)0.00002));
                Program.UnitsList.Add(new Units("cP", "m²/s", (decimal)0.000001));
                Program.UnitsList.Add(new Units("cP", "mm²/s", (decimal)1));
                Program.UnitsList.Add(new Units("cP", "mPa.s", (decimal)1));
                Program.UnitsList.Add(new Units("cP", "N.s/m²", (decimal)0.001));
                Program.UnitsList.Add(new Units("cP", "Pa.s", (decimal)0.001));
                Program.UnitsList.Add(new Units("cP", "Poise", (decimal)0.01));
                Program.UnitsList.Add(new Units("cP", "SSU", (decimal)4.53571));

                //OK
                Program.UnitsList.Add(new Units("cSt", "cm²/s", (decimal)0.01));
                Program.UnitsList.Add(new Units("cSt", "cP", (decimal)1));
                Program.UnitsList.Add(new Units("cSt", "ft²/s", (decimal)0.00001));
                Program.UnitsList.Add(new Units("cSt", "in²/s", (decimal)0.00155));
                Program.UnitsList.Add(new Units("cSt", "kg/m.hr", (decimal)3.59999));
                Program.UnitsList.Add(new Units("cSt", "lb/ft.hr", (decimal)2.41908));
                Program.UnitsList.Add(new Units("cSt", "lb/ft.s", (decimal)0.00067));
                Program.UnitsList.Add(new Units("cSt", "lbf.s/ft²", (decimal)0.00002));
                Program.UnitsList.Add(new Units("cSt", "m²/s", (decimal)0.000001));
                Program.UnitsList.Add(new Units("cSt", "mm²/s", (decimal)1));
                Program.UnitsList.Add(new Units("cSt", "mPa.s", (decimal)1));
                Program.UnitsList.Add(new Units("cSt", "N.s/m²", (decimal)0.001));
                Program.UnitsList.Add(new Units("cSt", "Pa.s", (decimal)0.001));
                Program.UnitsList.Add(new Units("cSt", "Poise", (decimal)0.01));
                Program.UnitsList.Add(new Units("cSt", "SSU", (decimal)4.53571));

                //OK
                Program.UnitsList.Add(new Units("ft²/s", "cm²/s", (decimal)929.0304));
                Program.UnitsList.Add(new Units("ft²/s", "cP", (decimal)92903.04));
                Program.UnitsList.Add(new Units("ft²/s", "cSt", (decimal)92903.04));
                Program.UnitsList.Add(new Units("ft²/s", "in²/s", (decimal)144));
                Program.UnitsList.Add(new Units("ft²/s", "kg/m.hr", (decimal)334450.944));
                Program.UnitsList.Add(new Units("ft²/s", "lb/ft.hr", (decimal)224740.65807));
                Program.UnitsList.Add(new Units("ft²/s", "lb/ft.s", (decimal)62.42796));
                Program.UnitsList.Add(new Units("ft²/s", "lbf.s/ft²", (decimal)1.94032));
                Program.UnitsList.Add(new Units("ft²/s", "m²/s", (decimal)0.09290));
                Program.UnitsList.Add(new Units("ft²/s", "mm²/s", (decimal)92903.04));
                Program.UnitsList.Add(new Units("ft²/s", "mPa.s", (decimal)92903.04));
                Program.UnitsList.Add(new Units("ft²/s", "N.s/m²", (decimal)92.90304));
                Program.UnitsList.Add(new Units("ft²/s", "Pa.s", (decimal)92.90304));
                Program.UnitsList.Add(new Units("ft²/s", "Poise", (decimal)929.03040));
                Program.UnitsList.Add(new Units("ft²/s", "SSU", (decimal)421381.64571));

                //OK
                Program.UnitsList.Add(new Units("in²/s", "cm²/s", (decimal)6.45160));
                Program.UnitsList.Add(new Units("in²/s", "cP", (decimal)645.16000));
                Program.UnitsList.Add(new Units("in²/s", "cSt", (decimal)645.16000));
                Program.UnitsList.Add(new Units("in²/s", "ft²/s", (decimal)0.00694));
                Program.UnitsList.Add(new Units("in²/s", "kg/m.hr", (decimal)2322.57600));
                Program.UnitsList.Add(new Units("in²/s", "lb/ft.hr", (decimal)1560.69901));
                Program.UnitsList.Add(new Units("in²/s", "lb/ft.s", (decimal)0.43353));
                Program.UnitsList.Add(new Units("in²/s", "lbf.s/ft²", (decimal)0.01347));
                Program.UnitsList.Add(new Units("in²/s", "m²/s", (decimal)0.00065));
                Program.UnitsList.Add(new Units("in²/s", "mm²/s", (decimal)645.16000));
                Program.UnitsList.Add(new Units("in²/s", "mPa.s", (decimal)645.16000));
                Program.UnitsList.Add(new Units("in²/s", "N.s/m²", (decimal)0.64516));
                Program.UnitsList.Add(new Units("in²/s", "Pa.s", (decimal)0.64516));
                Program.UnitsList.Add(new Units("in²/s", "Poise", (decimal)6.45160));
                Program.UnitsList.Add(new Units("in²/s", "SSU", (decimal)2926.26143));

                //OK
                Program.UnitsList.Add(new Units("kg/m.hr", "cm²/s", (decimal)0.00278));
                Program.UnitsList.Add(new Units("kg/m.hr", "cP", (decimal)0.27778));
                Program.UnitsList.Add(new Units("kg/m.hr", "cSt", (decimal)0.27778));
                Program.UnitsList.Add(new Units("kg/m.hr", "ft²/s", (decimal)0.000003));
                Program.UnitsList.Add(new Units("kg/m.hr", "in²/s", (decimal)0.00043));
                Program.UnitsList.Add(new Units("kg/m.hr", "lb/ft.hr", (decimal)0.67197));
                Program.UnitsList.Add(new Units("kg/m.hr", "lb/ft.s", (decimal)0.00019));
                Program.UnitsList.Add(new Units("kg/m.hr", "lbf.s/ft²", (decimal)0.00001));
                Program.UnitsList.Add(new Units("kg/m.hr", "m²/s", (decimal)0.0000003));
                Program.UnitsList.Add(new Units("kg/m.hr", "mm²/s", (decimal)0.27778));
                Program.UnitsList.Add(new Units("kg/m.hr", "mPa.s", (decimal)0.27778));
                Program.UnitsList.Add(new Units("kg/m.hr", "N.s/m²", (decimal)0.00028));
                Program.UnitsList.Add(new Units("kg/m.hr", "Pa.s", (decimal)0.00028));
                Program.UnitsList.Add(new Units("kg/m.hr", "Poise", (decimal)0.00278));
                Program.UnitsList.Add(new Units("kg/m.hr", "SSU", (decimal)1.25992));

                //OK
                Program.UnitsList.Add(new Units("lb/ft.hr", "cm²/s", (decimal)0.00413));
                Program.UnitsList.Add(new Units("lb/ft.hr", "cP", (decimal)0.41338));
                Program.UnitsList.Add(new Units("lb/ft.hr", "cSt", (decimal)0.41338));
                Program.UnitsList.Add(new Units("lb/ft.hr", "ft²/s", (decimal)0.000004));
                Program.UnitsList.Add(new Units("lb/ft.hr", "in²/s", (decimal)0.00064));
                Program.UnitsList.Add(new Units("lb/ft.hr", "kg/m.hr", (decimal)1.48816));
                Program.UnitsList.Add(new Units("lb/ft.hr", "lb/ft.s", (decimal)0.00028));
                Program.UnitsList.Add(new Units("lb/ft.hr", "lbf.s/ft²", (decimal)0.00001));
                Program.UnitsList.Add(new Units("lb/ft.hr", "m²/s", (decimal)0.0000004));
                Program.UnitsList.Add(new Units("lb/ft.hr", "mm²/s", (decimal)0.41338));
                Program.UnitsList.Add(new Units("lb/ft.hr", "mPa.s", (decimal)0.41338));
                Program.UnitsList.Add(new Units("lb/ft.hr", "N.s/m²", (decimal)0.00041));
                Program.UnitsList.Add(new Units("lb/ft.hr", "Pa.s", (decimal)0.00041));
                Program.UnitsList.Add(new Units("lb/ft.hr", "Poise", (decimal)0.00413));
                Program.UnitsList.Add(new Units("lb/ft.hr", "SSU", (decimal)1.87497));

                //OK
                Program.UnitsList.Add(new Units("lb/ft.s", "cm²/s", (decimal)14.88164));
                Program.UnitsList.Add(new Units("lb/ft.s", "cP", (decimal)1488.16400));
                Program.UnitsList.Add(new Units("lb/ft.s", "cSt", (decimal)1488.16400));
                Program.UnitsList.Add(new Units("lb/ft.s", "ft²/s", (decimal)0.01602));
                Program.UnitsList.Add(new Units("lb/ft.s", "in²/s", (decimal)2.30666));
                Program.UnitsList.Add(new Units("lb/ft.s", "kg/m.hr", (decimal)5357.39316));
                Program.UnitsList.Add(new Units("lb/ft.s", "lb/ft.hr", (decimal)3600.00199));
                Program.UnitsList.Add(new Units("lb/ft.s", "lbf.s/ft²", (decimal)0.03108));
                Program.UnitsList.Add(new Units("lb/ft.s", "m²/s", (decimal)0.00149));
                Program.UnitsList.Add(new Units("lb/ft.s", "mm²/s", (decimal)1488.16394));
                Program.UnitsList.Add(new Units("lb/ft.s", "mPa.s", (decimal)1488.16394));
                Program.UnitsList.Add(new Units("lb/ft.s", "N.s/m²", (decimal)1.48816));
                Program.UnitsList.Add(new Units("lb/ft.s", "Pa.s", (decimal)1.48816));
                Program.UnitsList.Add(new Units("lb/ft.s", "Poise", (decimal)14.88160));
                Program.UnitsList.Add(new Units("lb/ft.s", "SSU", (decimal)6749.86857));

                //OK
                Program.UnitsList.Add(new Units("lbf.s/ft²", "cm²/s", (decimal)478.80259));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "cP", (decimal)47880.25900));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "cSt", (decimal)47880.25900));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "ft²/s", (decimal)0.51538));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "in²/s", (decimal)74.21472));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "kg/m.hr", (decimal)172369.32752));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "lb/ft.hr", (decimal)115826.84036));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "lb/ft.s", (decimal)32.17412));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "m²/s", (decimal)0.04788));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "mm²/s", (decimal)47880.25919));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "mPa.s", (decimal)47880.25919));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "N.s/m²", (decimal)47.88026));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "Pa.s", (decimal)47.88026));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "Poise", (decimal)478.80260));
                Program.UnitsList.Add(new Units("lbf.s/ft²", "SSU", (decimal)217171.17929));

                //OK
                Program.UnitsList.Add(new Units("m²/s", "cm²/s", (decimal)10000));
                Program.UnitsList.Add(new Units("m²/s", "cP", (decimal)1000000));
                Program.UnitsList.Add(new Units("m²/s", "cSt", (decimal)1000000));
                Program.UnitsList.Add(new Units("m²/s", "ft²/s", (decimal)10.76391));
                Program.UnitsList.Add(new Units("m²/s", "in²/s", (decimal)10.76391));
                Program.UnitsList.Add(new Units("m²/s", "kg/m.hr", (decimal)3599999.86063));
                Program.UnitsList.Add(new Units("m²/s", "lb/ft.hr", (decimal)2419088.21685));
                Program.UnitsList.Add(new Units("m²/s", "lb/ft.s", (decimal)671.96895));
                Program.UnitsList.Add(new Units("m²/s", "lbf.s/ft²", (decimal)20.88543));
                Program.UnitsList.Add(new Units("m²/s", "mm²/s", (decimal)999999.80162));
                Program.UnitsList.Add(new Units("m²/s", "mPa.s", (decimal)999999.80162));
                Program.UnitsList.Add(new Units("m²/s", "N.s/m²", (decimal)999.99980));
                Program.UnitsList.Add(new Units("m²/s", "Pa.s", (decimal)999.99980));
                Program.UnitsList.Add(new Units("m²/s", "Poise", (decimal)9999.99800));
                Program.UnitsList.Add(new Units("m²/s", "SSU", (decimal)4535713.37857));

                //OK
                Program.UnitsList.Add(new Units("mm²/s", "cm²/s", (decimal)0.01000));
                Program.UnitsList.Add(new Units("mm²/s", "cP", (decimal)1.00000));
                Program.UnitsList.Add(new Units("mm²/s", "cSt", (decimal)1.00000));
                Program.UnitsList.Add(new Units("mm²/s", "ft²/s", (decimal)0.00001));
                Program.UnitsList.Add(new Units("mm²/s", "in²/s", (decimal)0.00155));
                Program.UnitsList.Add(new Units("mm²/s", "kg/m.hr", (decimal)3.59999));
                Program.UnitsList.Add(new Units("mm²/s", "lb/ft.hr", (decimal)2.41908));
                Program.UnitsList.Add(new Units("mm²/s", "lb/ft.s", (decimal)0.00067));
                Program.UnitsList.Add(new Units("mm²/s", "lbf.s/ft²", (decimal)0.00002));
                Program.UnitsList.Add(new Units("mm²/s", "m²/s", (decimal)0.000001));
                Program.UnitsList.Add(new Units("mm²/s", "mPa.s", (decimal)1.00000));
                Program.UnitsList.Add(new Units("mm²/s", "N.s/m²", (decimal)0.00100));
                Program.UnitsList.Add(new Units("mm²/s", "Pa.s", (decimal)0.00100));
                Program.UnitsList.Add(new Units("mm²/s", "Poise", (decimal)0.01000));
                Program.UnitsList.Add(new Units("mm²/s", "SSU", (decimal)4.53571));

                //OK
                Program.UnitsList.Add(new Units("mPa.s", "cm²/s", (decimal)0.01000));
                Program.UnitsList.Add(new Units("mPa.s", "cP", (decimal)1.00000));
                Program.UnitsList.Add(new Units("mPa.s", "cSt", (decimal)1.00000));
                Program.UnitsList.Add(new Units("mPa.s", "ft²/s", (decimal)0.00001));
                Program.UnitsList.Add(new Units("mPa.s", "in²/s", (decimal)0.00155));
                Program.UnitsList.Add(new Units("mPa.s", "kg/m.hr", (decimal)3.59999));
                Program.UnitsList.Add(new Units("mPa.s", "lb/ft.hr", (decimal)2.41908));
                Program.UnitsList.Add(new Units("mPa.s", "lb/ft.s", (decimal)0.00067));
                Program.UnitsList.Add(new Units("mPa.s", "lbf.s/ft²", (decimal)0.00002));
                Program.UnitsList.Add(new Units("mPa.s", "m²/s", (decimal)0.000001));
                Program.UnitsList.Add(new Units("mPa.s", "mm²/s", (decimal)1.00000));
                Program.UnitsList.Add(new Units("mPa.s", "N.s/m²", (decimal)0.00100));
                Program.UnitsList.Add(new Units("mPa.s", "Pa.s", (decimal)0.00100));
                Program.UnitsList.Add(new Units("mPa.s", "Poise", (decimal)0.01000));
                Program.UnitsList.Add(new Units("mPa.s", "SSU", (decimal)4.53571));

                //OK
                Program.UnitsList.Add(new Units("N.s/m²", "cm²/s", (decimal)10.00000));
                Program.UnitsList.Add(new Units("N.s/m²", "cP", (decimal)1000.00000));
                Program.UnitsList.Add(new Units("N.s/m²", "cSt", (decimal)1000.00000));
                Program.UnitsList.Add(new Units("N.s/m²", "ft²/s", (decimal)0.01076));
                Program.UnitsList.Add(new Units("N.s/m²", "in²/s", (decimal)1.55000));
                Program.UnitsList.Add(new Units("N.s/m²", "kg/m.hr", (decimal)3599.99280));
                Program.UnitsList.Add(new Units("N.s/m²", "lb/ft.hr", (decimal)2419.08347));
                Program.UnitsList.Add(new Units("N.s/m²", "lb/ft.s", (decimal)0.67197));
                Program.UnitsList.Add(new Units("N.s/m²", "lbf.s/ft²", (decimal)0.02089));
                Program.UnitsList.Add(new Units("N.s/m²", "m²/s", (decimal)0.00100));
                Program.UnitsList.Add(new Units("N.s/m²", "mm²/s", (decimal)1000.00000));
                Program.UnitsList.Add(new Units("N.s/m²", "mPa.s", (decimal)1000.00000));
                Program.UnitsList.Add(new Units("N.s/m²", "Pa.s", (decimal)1.00000));
                Program.UnitsList.Add(new Units("N.s/m²", "Poise", (decimal)10.00000));
                Program.UnitsList.Add(new Units("N.s/m²", "SSU", (decimal)4535.71429));

                //OK
                Program.UnitsList.Add(new Units("Pa.s", "cm²/s", (decimal)10.00000));
                Program.UnitsList.Add(new Units("Pa.s", "cP", (decimal)1000.00000));
                Program.UnitsList.Add(new Units("Pa.s", "cSt", (decimal)1000.00000));
                Program.UnitsList.Add(new Units("Pa.s", "ft²/s", (decimal)0.01076));
                Program.UnitsList.Add(new Units("Pa.s", "in²/s", (decimal)1.55000));
                Program.UnitsList.Add(new Units("Pa.s", "kg/m.hr", (decimal)3599.99280));
                Program.UnitsList.Add(new Units("Pa.s", "lb/ft.hr", (decimal)2419.08347));
                Program.UnitsList.Add(new Units("Pa.s", "lb/ft.s", (decimal)0.67197));
                Program.UnitsList.Add(new Units("Pa.s", "lbf.s/ft²", (decimal)0.02089));
                Program.UnitsList.Add(new Units("Pa.s", "m²/s", (decimal)0.00100));
                Program.UnitsList.Add(new Units("Pa.s", "mm²/s", (decimal)1000.00000));
                Program.UnitsList.Add(new Units("Pa.s", "mPa.s", (decimal)1000.00000));
                Program.UnitsList.Add(new Units("Pa.s", "N.s/m²", (decimal)1.00000));
                Program.UnitsList.Add(new Units("Pa.s", "Poise", (decimal)10.00000));
                Program.UnitsList.Add(new Units("Pa.s", "SSU", (decimal)4535.71429));

                //OK
                Program.UnitsList.Add(new Units("Poise", "cm²/s", (decimal)1.00000));
                Program.UnitsList.Add(new Units("Poise", "cP", (decimal)100.00000));
                Program.UnitsList.Add(new Units("Poise", "cSt", (decimal)100.00000));
                Program.UnitsList.Add(new Units("Poise", "ft²/s", (decimal)0.00108));
                Program.UnitsList.Add(new Units("Poise", "in²/s", (decimal)0.15500));
                Program.UnitsList.Add(new Units("Poise", "kg/m.hr", (decimal)359.99928));
                Program.UnitsList.Add(new Units("Poise", "lb/ft.hr", (decimal)241.90835));
                Program.UnitsList.Add(new Units("Poise", "lb/ft.s", (decimal)0.06720));
                Program.UnitsList.Add(new Units("Poise", "lbf.s/ft²", (decimal)0.00209));
                Program.UnitsList.Add(new Units("Poise", "m²/s", (decimal)0.00010));
                Program.UnitsList.Add(new Units("Poise", "mm²/s", (decimal)100.00000));
                Program.UnitsList.Add(new Units("Poise", "mPa.s", (decimal)100.00000));
                Program.UnitsList.Add(new Units("Poise", "N.s/m²", (decimal)0.10000));
                Program.UnitsList.Add(new Units("Poise", "Pa.s", (decimal)0.10000));
                Program.UnitsList.Add(new Units("Poise", "SSU", (decimal)453.57143));

                //OK
                Program.UnitsList.Add(new Units("SSU", "cm²/s", (decimal)0.00220));
                Program.UnitsList.Add(new Units("SSU", "cP", (decimal)0.22047));
                Program.UnitsList.Add(new Units("SSU", "cSt", (decimal)0.22047));
                Program.UnitsList.Add(new Units("SSU", "ft²/s", (decimal)0.000002));
                Program.UnitsList.Add(new Units("SSU", "in²/s", (decimal)0.00034));
                Program.UnitsList.Add(new Units("SSU", "kg/m.hr", (decimal)0.79370));
                Program.UnitsList.Add(new Units("SSU", "lb/ft.hr", (decimal)0.53334));
                Program.UnitsList.Add(new Units("SSU", "lb/ft.s", (decimal)0.00015));
                Program.UnitsList.Add(new Units("SSU", "lbf.s/ft²", (decimal)0.000005));
                Program.UnitsList.Add(new Units("SSU", "m²/s", (decimal)0.0000002));
                Program.UnitsList.Add(new Units("SSU", "mm²/s", (decimal)0.22047));
                Program.UnitsList.Add(new Units("SSU", "mPa.s", (decimal)0.22047));
                Program.UnitsList.Add(new Units("SSU", "N.s/m²", (decimal)0.00022));
                Program.UnitsList.Add(new Units("SSU", "Pa.s", (decimal)0.00022));
                Program.UnitsList.Add(new Units("SSU", "Poise", (decimal)0.00220));
            }
            catch
            {
                
            }

        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FromUnit"></param>
        /// <param name="ToUnit"></param>
        /// <param name="Type">1 = MassToVolume , 2 = VolumeToMass</param>
        /// <returns></returns>
        public static string ConvertLiquidUnit(string ValueFrom,string SG,string FromUnit,string ToUnit,int Type)
        {
            try
            {
                decimal result = 0;
                if (SG == "")
                    return "";
                string[] to = ToUnit.Split('/');
                string to1 = "";
                if (to.Length == 1)
                {
                    switch (ToUnit)
                    {
                        case "GPD (Imp)":
                        case "GPD (US)":
                            {
                                to1 = "day";
                                break;
                            }
                        case "GPH (Imp)":
                        case "GPH (US)":
                            {
                                to1 = "hr";
                                break;
                            }
                        case "GPM(Imp)":
                        case "GPM (US)":
                            {
                                to1 = "min";
                                break;
                            }
                        case "GPS (Imp)":
                        case "GPS (US)":
                            {
                                to1 = "s";
                                break;
                            }
                    }
                }
                else
                    to1 = to[1];
                decimal convert_from;
                decimal ro_ref = (decimal)999.972; //kg/m3
                decimal ro = Convert.ToDecimal(SG) * ro_ref;
                switch (Type)
                {
                    case 1:
                        {
                            convert_from = ConvertUnit(Convert.ToDecimal(ValueFrom), FromUnit, "kg/" + to1);
                            decimal Q = convert_from / ro;
                            if (ToUnit == ("m³/" + to1))
                                result = Q;
                            else
                            {
                                result = ConvertUnit(Q, ("m³/" + to1), ToUnit);
                            }
                            break;
                        }
                    case 2:
                        {
                            convert_from = ConvertUnit(Convert.ToDecimal(ValueFrom), FromUnit, "m³/" + to1);
                            decimal m_dot = convert_from * ro;
                            if (ToUnit == ("kg/" + to1))
                                result = m_dot;
                            else
                            {
                                result = ConvertUnit(m_dot, ("kg/" + to1), ToUnit);
                            }
                            break;
                        }
                }
                return Convert.ToString(Math.Round(result, 2));
            }
            catch
            {
                return null;
            }
        }
        public static decimal ConvertUnit(decimal Input,string From,string To)
        {
            try
            {
                string result = "";
                if (From == To)
                {
                    return Input;
                }
                int index_unit = Program.UnitsList.FindIndex(item => item.Base == To && item.Name == From);
                if (index_unit != -1)
                {
                    decimal k = Program.UnitsList[index_unit].K;
                    decimal res = Input * k;
                    return Math.Round(res, 2);
                }
                else
                {
                    string FluidType = Program.ProjectList[Program.CurrentProjectSelectedIndex].Fluid_Type;
                    string Relieving = Program.ProjectList[Program.CurrentProjectSelectedIndex].Relieving;
                    string RelievingUnit = Program.ProjectList[Program.CurrentProjectSelectedIndex].Relieving_Unit;
                    string MolecularWeight = Program.ProjectList[Program.CurrentProjectSelectedIndex].Molecular_Weight;
                    string AtmPressure = Program.ProjectList[Program.CurrentProjectSelectedIndex].Atmospheric;
                    string AtmPressureUnit = Program.ProjectList[Program.CurrentProjectSelectedIndex].Atmospheric_Unit;
                    string SetPressure = Program.ProjectList[Program.CurrentProjectSelectedIndex].SET_PRESSURE;
                    string SetPressureUnit = Program.ProjectList[Program.CurrentProjectSelectedIndex].SET_PRESSURE_Unit;
                    string SG = Program.ProjectList[Program.CurrentProjectSelectedIndex].Specific_Gravity;
                    if (FluidType == "Gas/Vapor")
                    {
                        switch (From)
                        {
                            case "kg/day":
                            case "kg/hr":
                            case "kg/min":
                            case "kg/s":
                            case "Ton,long/day":
                            case "Ton,long/hr":
                            case "Ton,long/s":
                            case "Ton(US)/day":
                            case "Ton(US)/hr":
                            case "Ton(US)/s":
                            case "Ton(mt)/day":
                            case "Ton(mt)/hr":
                            case "Ton(mt)/s":
                                {
                                    result = ConvertMassToVolume_Gas_SI(From, To, Input, Relieving, RelievingUnit, MolecularWeight, AtmPressure, AtmPressureUnit, SetPressure, SetPressureUnit);
                                    ;
                                    break;
                                }
                            case "lb/day":
                            case "lb/hr":
                            case "lb/min":
                            case "lb/s":
                                {
                                    result = ConvertMassToVolume_Gas_BRITISH(From, To, Input, Relieving, RelievingUnit, MolecularWeight, AtmPressure, AtmPressureUnit, SetPressure, SetPressureUnit);
                                    break;
                                }
                            case "SCFS":
                            case "SCFM":
                            case "SCFH":
                            case "SCFD":
                            case "MMSCFM":
                            case "MMSCFH":
                            case "MMSCFD":
                            case "ft³/s":
                            case "ft³/min":
                            case "ft³/hr":
                            case "ft³/day":
                                {
                                    result = ConvertVolumeToMass_Gas_BRITISH(From, To, Input, Relieving, RelievingUnit, MolecularWeight, AtmPressure, AtmPressureUnit, SetPressure, SetPressureUnit);
                                    break;
                                }
                            case "Sm³/min":
                            case "Sm³/hr":
                            case "Nm³/ s":
                            case "Nm³/min":
                            case "Nm³/hr":
                            case "Nm³/day":
                            case "m³/hr":
                            case "m³/s":
                            case "m³/min":
                            case "m³/day":
                                {
                                    result = ConvertVolumeToMass_Gas_SI(From, To, Input, Relieving, RelievingUnit, MolecularWeight, AtmPressure, AtmPressureUnit, SetPressure, SetPressureUnit);
                                    break;
                                }
                        }
                    }
                    if (FluidType == "Liquid")
                    {
                        switch (From)
                        {
                            case "kg/day":
                            case "kg/hr":
                            case "kg/min":
                            case "kg/s":
                            case "lb/day":
                            case "lb/hr":
                            case "lb/min":
                            case "lb/s":
                            case "Ton,long/day":
                            case "Ton,long/hr":
                            case "Ton,long/s":
                            case "Ton(US)/day":
                            case "Ton(US)/hr":
                            case "Ton(US)/s":
                            case "Ton(mt)/day":
                            case "Ton(mt)/hr":
                            case "Ton(mt)/s":
                                {
                                    result = ConvertLiquidUnit(Input.ToString(), SG, From, To, 1);
                                    break;
                                }
                            default:
                                {
                                    result = ConvertLiquidUnit(Input.ToString(), SG, From, To, 2);
                                    break;
                                }

                        }
                    }
                }
                if (result == "")
                    return 0;
                else
                    return Convert.ToDecimal(result);
            }
            catch
            {
                return 0;
            }
        }



        /// <summary>
        /// Calculate W (Required Pressure Flow) base lb/h from API 520 - Page 59
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Unit"></param>
        /// <returns></returns>
        private static decimal Calculate_W_For_Gas(string Value,string Unit)
        {
            try
            {
                decimal w = 0;
                if (Unit == "lb/hr")
                {
                    w = Convert.ToDecimal(Value);
                }

                if (Unit != "lb/hr")
                {
                    decimal v = Convert.ToDecimal(Value);
                    w = ConvertUnit(v, Unit, "lb/hr");
                    if (w == 0)
                        w = ConvertUnit(v, Unit, "ft³/hr");
                }
                return w;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Calculate C Factor
        /// </summary>
        /// <param name="K">K. (CP/CV)</param>
        /// <returns>K</returns>
        private static decimal Calculate_C_For_Gas(string K)
        {
            try
            {
                decimal k = Convert.ToDecimal(K);
                decimal c1 = 2 / (k + 1);
                decimal p = (k + 1) / (k - 1);
                double c2 = Math.Pow((double)c1, (double)p);
                decimal c3 = k * (decimal)c2;
                double c4 = Math.Sqrt((double)c3);
                decimal c = 520 * (decimal)c4;
                return c;
            }
            catch
            {
                return 0;
            }
        }

        private static double Calculate_Kd(string FluidType)
        {
            try
            {
                double Kd = 0;
                switch (FluidType)
                {
                    case "Gas":
                    case "Steam":
                        Kd = 0.856;
                        break;
                    case "Liquid":
                        Kd = 0.729;
                        break;
                }
                return Kd;
            }
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// Calculate P1 base psig or psia for Gas
        /// </summary>
        /// <param name="SetPressure">Set Pressure</param>
        /// <param name="OverPressure">Over Pressure</param>
        /// <param name="OverPressurePercent">Over Pressure Percent</param>
        /// <param name="AtmPerssure">Atm. Perssure</param>
        /// <returns>P1</returns>
        private static decimal Calculate_P1(string SetPressure,string SetPressureUnit,string OverPressure,string OverPressureUnit,string OverPressurePercent,string AtmPerssure,string AtmPerssureUnit,string InletLoss,string InLetPercent,string InletLossUnit,string FluidType)
        {
            try
            {
                decimal p1 = 0;
                decimal op = 0;
                decimal atmp = 0;
                decimal loss = 0;
                decimal sp = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                if (OverPressure != "")
                {
                    op = ConvertUnit(Convert.ToDecimal(OverPressure), OverPressureUnit, "psig");
                }
                else
                {
                    op = (sp * Convert.ToDecimal(OverPressurePercent)) / 100;
                }
                if (InLetPercent != "")
                {
                    loss = (sp * Convert.ToDecimal(InLetPercent)) / 100;
                }
                else if (InletLoss != "")
                {
                    loss = ConvertUnit(Convert.ToDecimal(InletLoss), InletLossUnit, "psig");
                }
                if (AtmPerssure != "")
                    atmp = ConvertUnit(Convert.ToDecimal(AtmPerssure), AtmPerssureUnit, "psia");
                if (FluidType == "Gas")
                    p1 = sp + op - loss + atmp;
                else if (FluidType == "Liquid")
                    p1 = sp + op - loss;
                return p1;
            }
            catch
            {
                return 0;
            }
        }

        private static decimal Calculate_P2(string TotalBackPressure, string TotalBackPressureUnit, string AtmPerssure, string AtmPerssureUnit,string FluidType)
        {
            try
            {
                decimal p2 = 0;
                decimal atmp = 0;
                decimal pback = 0;
                if (AtmPerssure != "")
                    atmp = ConvertUnit(Convert.ToDecimal(AtmPerssure), AtmPerssureUnit, "psia");
                if (TotalBackPressure != "")
                {
                    ConvertUnit(Convert.ToDecimal(TotalBackPressure), TotalBackPressureUnit, "psig");
                }
                if (FluidType == "Gas")
                    p2 = pback + atmp;
                else if (FluidType == "Liquid")
                    p2 = pback;
                return p2;
            }
            catch
            {
                return 0;
            }
        }
        private static decimal Calculate_Kb_For_Gas(string SetPressure,string SetPressureUnit,string TotalBackPressure,string TotalBackPressureUnit,string OverPressurePercent,string OverPressure,string OverPressureUnit)
        {
            try
            {
                decimal Kb = 1;
                if (TotalBackPressure == "0")
                    return Kb;

                decimal Pb = ConvertUnit(Convert.ToDecimal(TotalBackPressure), TotalBackPressureUnit, "psig");
                decimal Ps = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                decimal fac = (Pb / Ps) * 100;
                if (Convert.ToDouble(OverPressurePercent) == 10)
                {
                    if (fac < (decimal)30.1073 || fac > (decimal)50.0226)
                        return Kb;
                    else
                        return (decimal)FindKbIn10Percent((double)fac);
                }
                if (Convert.ToDouble(OverPressurePercent) == 16)
                {
                    if (fac < (decimal)37.7539 || fac > (decimal)49.9403)
                        return Kb;
                    else
                        return FindKbIn16Percent(fac);
                }
                if (Convert.ToDouble(OverPressurePercent) == 21)
                {
                    return Kb;
                }
                return Kb;
            }
            catch
            {
                return 0;
            }
        }

        private static double Calculate_Kb_For_Gas_From_Curve(string Fact_UP,string Fact_Down,double fac,string Kb_UP,string Kb_Down)
        {
            try
            {
                double Kb = 0;
                double fup = Convert.ToDouble(Fact_UP);
                double fdown = Convert.ToDouble(Fact_Down);
                double kbup = Convert.ToDouble(Kb_UP);
                double kbdown = Convert.ToDouble(Kb_Down);
                Kb = (((kbup - kbdown) / (fup - fdown)) * (fac - fdown)) + kbdown;
                return Kb;
            }
            catch
            {
                return 0;
            }
        }

        private static double FindKbIn10Percent(double fac)
        {
            try
            {
                double Kb = 0;
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@fac";
                param[0, 1] = fac.ToString();

                DAL dal = new DAL();

                dal.StoredProcedureName = "prcGetKd10PercentForGas";
                dt = dal.ExcecuteQueryToDataTable(param);
                if (dt.Rows.Count > 0)
                {
                    string _kb = dt.Rows[0]["Kb"].ToString();
                    Kb = Convert.ToDouble(_kb);
                    return Kb;
                }
                else
                {
                    DAL dal2 = new DAL();
                    dal2.StoredProcedureName = "prcGetUpKd10PercentForGas";
                    dt = null;
                    dt = dal2.ExcecuteQueryToDataTable(param);
                    string facUP = dt.Rows[0]["Fact"].ToString();
                    string KbUP = dt.Rows[0]["Kb"].ToString();

                    DAL dal3 = new DAL();
                    dal3.StoredProcedureName = "prcGetDownKd10PercentForGas";
                    dt = null;
                    dt = dal3.ExcecuteQueryToDataTable(param);
                    string facDown = dt.Rows[0]["Fact"].ToString();
                    string KbDown = dt.Rows[0]["Kb"].ToString();
                    return Calculate_Kb_For_Gas_From_Curve(facUP, facDown, fac, KbUP, KbDown);
                }
            }
            catch
            {
                return 0;
            }
        }
        private static decimal FindKbIn16Percent(decimal fac)
        {
            decimal Kb = 0;

            return Kb;
        }

        public static decimal Calculate_A_For_Gas(int ProjectIndex,string MolecularWeight,string K,string Compressibility,
                                                  string Relieving,string RelievingUnit,
                                                  string RequiredPressureFlow,string RequiredPressureFlowUnit,
                                                  string AtmPressure,string AtmPressureUnit,string SetPressure,
                                                  string SetPressureUnit,string OverPressurePercent,
                                                  string OverPressure,string OverPressureUnit,
                                                  string TotalBackPressure,string TotalBackPressureUnit,string Kc,string InletLoss,string InletLossPercent,string InletLossUnit,string _Kd)

           
        {
            try
            {
                decimal A = 0;
                decimal W = Calculate_W_For_Gas(RequiredPressureFlow, RequiredPressureFlowUnit);
                decimal C = Calculate_C_For_Gas(K);
                double Kd = 0;
                if (_Kd != "")
                    Kd = Convert.ToDouble(_Kd);
                else
                    Kd = Calculate_Kd("Gas");
                decimal P1 = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Gas");
                decimal Kb = Calculate_Kb_For_Gas(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit, OverPressurePercent, OverPressure, OverPressureUnit);
                decimal T = Calculate_T_For_Gas(Relieving, RelievingUnit);
                decimal Z = Convert.ToDecimal(Compressibility);
                decimal M = Convert.ToDecimal(MolecularWeight);
                decimal KC = Convert.ToDecimal(Kc);
                A = (W / (C * (decimal)Kd * P1 * Kb * KC)) * Convert.ToDecimal(Math.Sqrt(((double)T * (double)Z) / (double)M));
                Program.ProjectList[ProjectIndex].C = Math.Round(C, 1).ToString();
                Program.ProjectList[ProjectIndex].Relieving_Flowing = Math.Round(P1, 2).ToString();
                Program.ProjectList[ProjectIndex].Relieving_Flowing_Unit = "psia";
                Program.ProjectList[ProjectIndex].Kd = Kd.ToString();
                Program.ProjectList[ProjectIndex].A = Math.Round(A, 2).ToString();
                Program.ProjectList[ProjectIndex].Area_Calculated = Math.Round(A, 2).ToString();
                Program.ProjectList[ProjectIndex].Flow_Required_Converted = Math.Round(W, 2).ToString();
                Program.ProjectList[ProjectIndex].Rupture_Disc_CCF = Kc;
                Program.ProjectList[ProjectIndex].Discharge_Coefficient = Kd.ToString();
                Program.ProjectList[ProjectIndex].Discharge_Coefficien_derated = "HOLD";
                Program.ProjectList[ProjectIndex].Back_Pressure_Correction_Factor = Math.Round(Kb, 2).ToString();
                Program.ProjectList[ProjectIndex].P1 = Math.Round(P1, 2).ToString();
                Program.ProjectList[ProjectIndex].P1_unit = "Psia";
                Program.ProjectList[ProjectIndex].Relieving_Temperature = Relieving + " " + RelievingUnit;
                Program.ProjectList[ProjectIndex].Relieving_Temperature1 = T.ToString() + " " + "°R";
                return A;
            }
            catch
            {
                return 0;
            }
        }

        public static string Calculate_W_For_Gas(string A,string MolecularWeight, string K, string Compressibility,
                                                 string Relieving, string RelievingUnit,
                                                 string RequiredPressureFlow, string RequiredPressureFlowUnit,
                                                 string AtmPressure, string AtmPressureUnit, string SetPressure,
                                                 string SetPressureUnit, string OverPressurePercent,
                                                 string OverPressure, string OverPressureUnit,
                                                 string TotalBackPressure, string TotalBackPressureUnit, string Kc, string InletLoss, string InletLossPercent, string InletLossUnit,string _kd)


        {
            try
            {
                decimal W = 0;
                decimal C = Calculate_C_For_Gas(K);
                double Kd = 0;
                if (_kd != "")
                    Kd = Convert.ToDouble(_kd);
                else
                    Kd = Calculate_Kd("Gas");

                decimal P1 = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Gas");
                decimal Kb = Calculate_Kb_For_Gas(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit, OverPressurePercent, OverPressure, OverPressureUnit);
                decimal T = Calculate_T_For_Gas(Relieving, RelievingUnit);
                decimal Z = Convert.ToDecimal(Compressibility);
                decimal M = Convert.ToDecimal(MolecularWeight);
                decimal KC = Convert.ToDecimal(Kc);
                W = (Convert.ToDecimal(A) * C * (decimal)Kd * P1 * Kb * KC * ((decimal)Math.Sqrt((double)M / ((double)T * (double)Z))));
                return Convert.ToString(Math.Round(W, 2));
            }
            catch
            {
                return null;
            }
        }

        public static string Calculate_Q_For_Liquid(string A, string SetPressure, string SetPressureUnit, string TotalBackPressure,
                                                   string TotalBackPressureUnit, string Kc, string AtmPerssure, string AtmPerssureUnit,
                                                   string OverPressure, string OverPressureUnit, string OverPressurePercent, string InletLoss, string InLetPercent,
                                                   string InletLossUnit, string SpecificGravity,string _kd)
        {
            try
            {
                decimal Q = 0;
                double kd = 0;
                if (_kd != "")
                    kd = Convert.ToDouble(_kd);
                else
                    kd = Calculate_Kd("Liquid");
                decimal kw = Calculate_Kw_From_Curve(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit);
                decimal kc = Convert.ToDecimal(Kc);
                decimal kv = 1;
                decimal p2 = Calculate_P2(TotalBackPressure, TotalBackPressureUnit, AtmPerssure, AtmPerssureUnit, "Liquid");
                decimal p1 = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPerssure, AtmPerssureUnit, InletLoss, InLetPercent, InletLossUnit, "Liquid");
                decimal g = Convert.ToDecimal(SpecificGravity);
                decimal Density = g * (decimal)62.4;
                Q = Convert.ToDecimal(A) * (decimal)38 * (decimal)kd * kw * kc * kv * Convert.ToDecimal((Math.Sqrt(((double)p1 - (double)p2) / (double)g)));
                decimal Q_ft3_hr = Q * (decimal)8.021;
                decimal Q_lb_hr = Q_ft3_hr * Density;
                return Convert.ToString(Math.Round(Q_lb_hr, 2));
            }
            catch
            {
                return null; 
            }
        }
        private static decimal Calculate_T_For_Gas(string Value,string Unit)
        {
            try
            {
                decimal t = 0;
                if (Unit == "°C")
                    t = (Math.Round((Convert.ToDecimal(Value) + (decimal)273.15) * (decimal)1.8, 3));
                if (Unit == "°K")
                    t = (Math.Round(Convert.ToDecimal(Value) * (decimal)1.8, 3));
                if (Unit == "°F")
                    t = (Convert.ToDecimal(Value) + (decimal)459.67);
                if (Unit == "°R")
                    t = Convert.ToDecimal(Value);
                return t;
            }
            catch
            {
                return 0;
            }
        }

        public static List<string> GetOrifices(decimal A)
        {
            try
            {
                List<string> OrificeList = new List<string>();
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetOrifice";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@A";
                param[0, 1] = A.ToString();
                dt = dal.ExcecuteQueryToDataTable(param);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string orif = dt.Rows[i]["OrificeName"].ToString();

                        OrificeList.Add(orif);
                    }
                }
                return OrificeList;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetOrificesValue(decimal A)
        {
            try
            {
                List<string> OrificeList = new List<string>();
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetOrifice";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@A";
                param[0, 1] = A.ToString();
                dt = dal.ExcecuteQueryToDataTable(param);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string orif = dt.Rows[i]["MinValue"].ToString();
                        OrificeList.Add(orif);
                    }
                }
                return OrificeList;
            }
            catch
            {
                return null;
            }
        }


        public static List<string> GetFirstOrifices(decimal A)
        {
            try
            {
                List<string> OrificeList = new List<string>();
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetOrifice";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@A";
                param[0, 1] = A.ToString();
                dt = dal.ExcecuteQueryToDataTable(param);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string orif = dt.Rows[i]["MinValue"].ToString();

                        OrificeList.Add(orif);
                    }
                }
                return OrificeList;
            }
            catch
            {
                return null;
            }
        }
        public static List<string> GetSeries(decimal A)
        {
            try
            {
                List<string> SeriesList = new List<string>();
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetOrifice";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@A";
                param[0, 1] = A.ToString();
                dt = dal.ExcecuteQueryToDataTable(param);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string series = dt.Rows[i]["Series"].ToString();
                        SeriesList.Add(series);
                    }
                }
                return SeriesList;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetSize(string Series)
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetSize";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@Series";
                param[0, 1] = Series;
                dt = dal.ExcecuteQueryToDataTable(param);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetBodyMaterial(string Series)
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetBodyMaterial";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@Series";
                param[0, 1] = Series;
                dt = dal.ExcecuteQueryToDataTable(param);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static void GetBodyMaterialAll()
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetBodyMaterialAll";
                DataTable dt = new DataTable();
                dt = dal.ExcecuteStoredProcedureToDataTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BodyMaterials bm = new BodyMaterials();
                        string id = dt.Rows[i]["Id"].ToString();
                        string max_temp = dt.Rows[i]["MaxTemp"].ToString();
                        string BodyMaterial = dt.Rows[i]["BodyMaterial"].ToString();
                        string ReturnCode = dt.Rows[i]["ReturnCode"].ToString();
                        string Alias = dt.Rows[i]["Alias"].ToString();
                        string StandardName = dt.Rows[i]["StandardName"].ToString();
                        string Series = dt.Rows[i]["Series"].ToString();
                        bm.Id = id;
                        bm.MaxTemp = max_temp;
                        bm.BodyMaterial = BodyMaterial;
                        bm.ReturnCode = ReturnCode;
                        bm.Alias = Alias;
                        bm.StandardName = StandardName;
                        bm.Series = Series;
                        Program.BodyMaterialsList.Add(bm);
                    }
                }
            }
            catch
            {
                
            }
        }


        public static DataTable GetSpringMaterial(string Series)
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetSpringMaterial";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@Series";
                param[0, 1] = Series;
                dt = dal.ExcecuteQueryToDataTable(param);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetBodyType()
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetBodyType";
                DataTable dt = new DataTable();
                dt = dal.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetBodySize()
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetBodySize";
                DataTable dt = new DataTable();
                dt = dal.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetTrimType()
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetTrimType";
                DataTable dt = new DataTable();
                dt = dal.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetPortSize()
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetPortSize";
                DataTable dt = new DataTable();
                dt = dal.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }


        public static DataTable GetRatedCV()
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetRatedCV";
                DataTable dt = new DataTable();
                dt = dal.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetStroke()
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetStroke";
                DataTable dt = new DataTable();
                dt = dal.ExcecuteStoredProcedureToDataTable();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable GetDiskMaterial(string Series)
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetDiskMaterial";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@Series";
                param[0, 1] = Series;
                dt = dal.ExcecuteQueryToDataTable(param);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetSeat(string Series)
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetSeat";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@Series";
                param[0, 1] = Series;
                dt = dal.ExcecuteQueryToDataTable(param);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetAnsiFlangeRating(string Series)
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetAnsiFlangeRating";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@Series";
                param[0, 1] = Series;
                dt = dal.ExcecuteQueryToDataTable(param);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetFlangeFace(string Series)
        {
            try
            {
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetFlangeFace";
                DataTable dt = new DataTable();
                string[,] param = new string[1, 2];
                param[0, 0] = "@Series";
                param[0, 1] = Series;
                dt = dal.ExcecuteQueryToDataTable(param);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public static DataTable GetProducts(List<string> OrificeList, List<string> SeriesList)
        {
            try
            {
                DataTable dtOri = new DataTable();
                DataTable dt = new DataTable();
                dt.Columns.Add("Orifice", typeof(string));
                dt.Columns.Add("Series", typeof(string));

                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetOrifice";
                for (int i = 0; i < OrificeList.Count; i++)
                {
                    dtOri.Rows.Clear();
                    string[,] param = new string[1, 2];
                    param[0, 0] = "@A";
                    param[0, 1] = OrificeList[i];
                    dtOri = dal.ExcecuteQueryToDataTable(param);
                    if (dtOri.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtOri.Rows.Count; x++)
                        {
                            string orifice = dtOri.Rows[x]["OrificeName"].ToString();
                            string series = dtOri.Rows[x]["Series"].ToString();
                            dt.Rows.Add(orifice, series);
                        }
                    }
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> Calculate_A_For_Liquid_With_Kw_1(int ProjectIndex,string SpecificGravity, string Viscosity,
                                                string Relieving, string RelievingUnit,
                                                string RequiredFlowCapacity, string RequiredFlowCapacityUnit,
                                                string AtmPressure, string AtmPressureUnit, string SetPressure,
                                                string SetPressureUnit, string OverPressurePercent,
                                                string OverPressure, string OverPressureUnit,
                                                string TotalBackPressure, string TotalBackPressureUnit, string Kc,
                                                string InletLoss,string InletLossPercent,string InletLossUnit,string _kd)

        {
            try
            {
                double A1 = 0;
                decimal Q = Calculate_Q_For_Liquid(Convert.ToDecimal(RequiredFlowCapacity), Convert.ToDecimal(SpecificGravity), RequiredFlowCapacityUnit);

                // decimal Q = Convert.ToDecimal(RequiredFlowCapacity) / (Convert.ToDecimal(SpecificGravity) * (decimal)62.4);
                double G = Convert.ToDouble(SpecificGravity);
                double KC = Convert.ToDouble(Kc);
                decimal Kv = 1;
                decimal P1 = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Liquid");
                decimal P2 = Calculate_P2(TotalBackPressure, TotalBackPressureUnit, AtmPressure, AtmPressureUnit, "Liquid");
                decimal Kw = 1;


                A1 = Math.Round(((double)Q / ((double)38 * (double)0.62 * (double)Kw * KC * (double)Kv) * (Math.Sqrt(G / ((double)P1 - (double)P2)))), 2);
                List<string> ResourceOrifice = new List<string>();
                List<string> SeriesList = new List<string>();
                List<string> FinalOrificeList = new List<string>();
                ResourceOrifice = GetFirstOrifices((decimal)A1);
                SeriesList = GetSeries((decimal)A1);
                FinalOrificeList = Calculate_A_EslahShode(ProjectIndex, ResourceOrifice, Q, G, Viscosity, Kw, KC, P1, P2);

                return FinalOrificeList;
            }
            catch
            {
                return null;
            }
        }

        private static decimal Calculate_Q_For_Liquid(decimal FlowCapacity,decimal SG,string Unit)
        {
            try
            {
                decimal Q = 0;
                switch (Unit)
                {
                    case "ft³/hr":
                        decimal flow_lbhr = FlowCapacity * SG * 62;
                        decimal densiry = SG * (decimal)62.428;
                        decimal q_ft3hr = flow_lbhr / densiry;
                        Q = q_ft3hr / (decimal)8.021;
                        break;
                    case "lb/hr":
                        Q = FlowCapacity * (decimal)0.002;
                        break;
                    case "Kg/day":
                        Q = FlowCapacity * (decimal)0.00018;
                        break;
                    case "Kg/hr":
                        Q = FlowCapacity * (decimal)0.0044;
                        break;
                    case "Kg/min":
                        Q = FlowCapacity * (decimal)0.26;
                        break;
                    case "Kg/s":
                        Q = FlowCapacity * (decimal)15.85;
                        break;
                    case "lb/day":
                        Q = FlowCapacity * (decimal)0.000083;
                        break;
                    case "lb/min":
                        Q = FlowCapacity * (decimal)0.12;
                        break;
                    case "lb/s":
                        Q = FlowCapacity * (decimal)7.19;
                        break;
                    case "Ton,long/day":
                        Q = FlowCapacity * (decimal)0.18;
                        break;
                    case "Ton,long/hr":
                        Q = FlowCapacity * (decimal)4.40;
                        break;
                    case "Ton,long/s":
                        Q = FlowCapacity * (decimal)15840;
                        break;
                    case "GPM(US)":
                        Q = FlowCapacity;
                        break;
                    default:
                        Q = FlowCapacity;
                        break;
                }
                return Math.Round(Q, 2);
            }
            catch
            {
                return 0;
            }
        }

        private static List<string> Calculate_A_EslahShode(int ProjectIndex,List<string> ResOrifice,decimal Q,double G,string Viscosity,decimal Kw,double KC,decimal P1,decimal P2)
        {
            try
            {
                List<string> FinalOrifice = new List<string>();
                for (int i = 0; i < ResOrifice.Count; i++)
                {
                    bool FindOrifice = false;
                    if (ResOrifice[i] != "")
                    {
                        double A = Convert.ToDouble(ResOrifice[i]);
                        while (!FindOrifice)
                        {
                            double R = (double)Q * (2800 * G) / (Convert.ToDouble(Viscosity) * Math.Sqrt(A));
                            double Kv = Math.Pow((0.9935 + (2.878 / Math.Pow(R, 0.5)) + (342.75 / Math.Pow(R, 1.5))), -1);
                            double A2 = Math.Round(((double)Q / ((double)38 * (double)0.62 * (double)Kw * KC * (double)Kv) * (Math.Sqrt(G / ((double)P1 - (double)P2)))), 2);
                            List<string> NewOrifice = new List<string>();
                            NewOrifice = GetFirstOrifices((decimal)A2);
                            if (NewOrifice[i] == ResOrifice[i])
                            {
                                Program.ProjectList[ProjectIndex].Area_Calculated = A2.ToString();
                                FinalOrifice.Add(NewOrifice[i]);
                                FindOrifice = true;
                            }
                            else
                            {
                                A = A2;
                                FindOrifice = false;
                            }
                        }
                    }
                }

                return FinalOrifice;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> Calculate_A_For_Liquid_With_Kw_No_1(int ProjectIndex,string SpecificGravity, string Viscosity,
                                               string Relieving, string RelievingUnit,
                                               string RequiredFlowCapacity, string RequiredFlowCapacityUnit,
                                               string AtmPressure, string AtmPressureUnit, string SetPressure,
                                               string SetPressureUnit, string OverPressurePercent,
                                               string OverPressure, string OverPressureUnit,
                                               string TotalBackPressure, string TotalBackPressureUnit, string Kc,
                                               string InletLoss, string InletLossPercent, string InletLossUnit,string _kd)

        {
            try
            {
                double A1 = 0;
                decimal Q = Calculate_Q_For_Liquid(Convert.ToDecimal(RequiredFlowCapacity), Convert.ToDecimal(SpecificGravity), RequiredFlowCapacityUnit);
                double G = Convert.ToDouble(SpecificGravity);
                double KC = Convert.ToDouble(Kc);
                decimal Kv = 1;
                decimal P1 = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Liquid");
                decimal P2 = Calculate_P2(TotalBackPressure, TotalBackPressureUnit, AtmPressure, AtmPressureUnit, "Liquid");

                decimal Kw = Calculate_Kw_From_Curve(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit);
                if (Kw == 1)
                    return null;

                A1 = Math.Round(((double)Q / ((double)38 * (double)0.62 * (double)Kw * KC * (double)Kv) * (Math.Sqrt(G / ((double)P1 - (double)P2)))), 2);
                List<string> ResourceOrifice = new List<string>();
                List<string> SeriesList = new List<string>();
                List<string> FinalOrificeList = new List<string>();
                ResourceOrifice = GetFirstOrifices((decimal)A1);
                SeriesList = GetSeries((decimal)A1);
                FinalOrificeList = Calculate_A_EslahShode(ProjectIndex, ResourceOrifice, Q, G, Viscosity, Kw, KC, P1, P2);

                return FinalOrificeList;
            }
            catch
            {
                return null;
            }
        }

        private static decimal Calculate_Kw_From_Curve(string SetPressure,string SetPressureUnit,string TotalBackPressure,string TotalBackPressureUnit)
        {
            try
            {
                decimal kw = 0;
                decimal PB = ConvertUnit(Convert.ToDecimal(TotalBackPressure), TotalBackPressureUnit, "psig");
                decimal PS = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                decimal fact = (PB / PS) * 100;
                if (fact < (decimal)15.1273 || fact > (decimal)49.947)
                    return 1;
                else
                {
                    DataTable dt = new DataTable();
                    string[,] param = new string[1, 2];
                    param[0, 0] = "@fac";
                    param[0, 1] = fact.ToString();
                    DAL dal = new DAL();
                    dal.StoredProcedureName = "prcGetUpKwForLiquid";
                    dt = null;
                    dt = dal.ExcecuteQueryToDataTable(param);
                    string facUP = dt.Rows[0]["Fact"].ToString();
                    string KwUP = dt.Rows[0]["Kw"].ToString();
                    DAL dal3 = new DAL();
                    dal3.StoredProcedureName = "prcGetDownKWForLiquid";
                    dt = null;
                    dt = dal3.ExcecuteQueryToDataTable(param);
                    string facDown = dt.Rows[0]["Fact"].ToString();
                    string KwDown = dt.Rows[0]["Kw"].ToString();
                    double fup = Convert.ToDouble(facUP);
                    double fdown = Convert.ToDouble(facDown);
                    double kbup = Convert.ToDouble(KwUP);
                    double kbdown = Convert.ToDouble(KwDown);
                    kw = ((((decimal)kbup - (decimal)kbdown) / ((decimal)fup - (decimal)fdown)) * (fact - (decimal)fdown)) + (decimal)kbdown;
                }
                return kw;
            }
            catch
            {
                return 0;
            }
        }

        public static decimal Calculate_A_For_Steam(int ProjectIndex,string MolecularWeight, string K, string Compressibility,
                                                string Relieving, string RelievingUnit,
                                                string RequiredPressureFlow, string RequiredPressureFlowUnit,
                                                string AtmPressure, string AtmPressureUnit, string SetPressure,
                                                string SetPressureUnit, string OverPressurePercent,
                                                string OverPressure, string OverPressureUnit,
                                                string TotalBackPressure, string TotalBackPressureUnit, string Kc, string InletLoss, string InletLossPercent, string InletLossUnit,string _kd)


        {
            try
            {
                decimal A = 0;
                decimal W = Calculate_W_For_Gas(RequiredPressureFlow, RequiredPressureFlowUnit);
                double Kd = 0;
                if (_kd != "")
                    Kd = Convert.ToDouble(_kd);
                else
                    Kd = Calculate_Kd("Steam");
                decimal P1 = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Gas");
                decimal Kb = Calculate_Kb_For_Gas(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit, OverPressurePercent, OverPressure, OverPressureUnit);

                decimal KC = Convert.ToDecimal(Kc);
                decimal Kn = Calculate_Kn(P1);
                decimal Ksh = Calculate_Ksh(ProjectIndex, SetPressure, SetPressureUnit, Relieving, RelievingUnit);
                if (Ksh == 0)
                    return A;
                A = (W / ((decimal)51.5 * P1 * (decimal)Kd * Kb * KC * Kn * Ksh));

                Program.ProjectList[ProjectIndex].Kd = Kd.ToString();
                Program.ProjectList[ProjectIndex].W = W.ToString();
                Program.ProjectList[ProjectIndex].P1 = P1.ToString();
                Program.ProjectList[ProjectIndex].P1_unit = "psia";
                Program.ProjectList[ProjectIndex].Rupture_Disc_CCF = Kc;
                Program.ProjectList[ProjectIndex].Superheat_Correction_Factor = Ksh.ToString();
                Program.ProjectList[ProjectIndex].Molecular_Weight = MolecularWeight;
                Program.ProjectList[ProjectIndex].Ratio_of_Specific_Heats = K;
                Program.ProjectList[ProjectIndex].Inlet_Stagnation_Enthalpy = Compressibility;
                Program.ProjectList[ProjectIndex].Area_Calculated = A.ToString();
                return A;
            }
            catch
            {
                return 0;
            }
        }

        public static string Calculate_W_For_Steam(int ProjectIndex,string A,string MolecularWeight, string K, string Compressibility,
                                                string Relieving, string RelievingUnit,
                                                string RequiredPressureFlow, string RequiredPressureFlowUnit,
                                                string AtmPressure, string AtmPressureUnit, string SetPressure,
                                                string SetPressureUnit, string OverPressurePercent,
                                                string OverPressure, string OverPressureUnit,
                                                string TotalBackPressure, string TotalBackPressureUnit, string Kc, string InletLoss, string InletLossPercent, string InletLossUnit,string _kd)


        {
            try
            {
                decimal W = 0;
                double Kd = 0;
                if (_kd != "")
                    Kd = Convert.ToDouble(_kd);
                else
                    Kd = Calculate_Kd("Steam");

                decimal P1 = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Gas");
                decimal Kb = Calculate_Kb_For_Gas(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit, OverPressurePercent, OverPressure, OverPressureUnit);

                decimal KC = Convert.ToDecimal(Kc);
                decimal Kn = Calculate_Kn(P1);
                decimal Ksh = Calculate_Ksh(ProjectIndex, SetPressure, SetPressureUnit, Relieving, RelievingUnit);

                W = (Convert.ToDecimal(A) * (decimal)51.5 * P1 * (decimal)Kd * Kb * KC * Kn * Ksh);
                return Math.Round(W, 2).ToString();
            }
            catch
            {
                return null;
            }
        }
        private static decimal Calculate_Kn(decimal P1)
        {
            try
            {
                decimal Kn = 1;
                if (P1 <= 1500)
                    return Kn;
                else
                {
                    Kn = ((((decimal)0.1906 * P1) - 1000) / (((decimal)0.2292 * P1) - 1061));
                    return Kn;
                }
            }
            catch
            {
                return 0;
            }
        }

        private static decimal Calculate_Ksh(int ProjectIndex,string SetPressure,string SetPressureUnit,string Relieving,string RelievingUnit)
        {
            try
            {
                decimal ksh = 0;
                decimal sp = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                decimal temp = ConvertTempToFahrenheit(Relieving, RelievingUnit);
                Program.ProjectList[ProjectIndex].Relieving_Temperature = temp.ToString() + " Fahrenheit";
                DataTable dt = new DataTable();
                string[,] param = new string[2, 2];
                param[0, 0] = "@SetPressure";
                param[0, 1] = sp.ToString();
                param[1, 0] = "@Tempreture";
                param[1, 1] = temp.ToString();
                DAL dal = new DAL();
                dal.StoredProcedureName = "prcGetKshDown";
                dt = null;
                dt = dal.ExcecuteQueryToDataTable(param);
                if (dt.Rows.Count == 0)
                    return ksh;
                string spDown = dt.Rows[0]["SetPerssure"].ToString();
                string tempDown = dt.Rows[0]["Tempreture"].ToString();
                string kshDown1 = dt.Rows[0]["ReturnKsh"].ToString();


                dal.StoredProcedureName = "prcGetKshUp";
                dt = null;
                dt = dal.ExcecuteQueryToDataTable(param);
                if (dt.Rows.Count == 0)
                    return ksh;
                string spUp = dt.Rows[0]["SetPerssure"].ToString();
                string tempUp = dt.Rows[0]["Tempreture"].ToString();
                string kshUp2 = dt.Rows[0]["ReturnKsh"].ToString();

                param[0, 0] = "@SetPressure";
                param[0, 1] = spDown;
                param[1, 0] = "@Tempreture";
                param[1, 1] = tempUp;

                dal.StoredProcedureName = "prcGetKshEqual";
                dt = null;
                dt = dal.ExcecuteQueryToDataTable(param);
                string kshDown2 = dt.Rows[0]["ReturnKsh"].ToString();

                param[0, 0] = "@SetPressure";
                param[0, 1] = spUp;
                param[1, 0] = "@Tempreture";
                param[1, 1] = tempDown;

                dal.StoredProcedureName = "prcGetKshEqual";
                dt = null;
                dt = dal.ExcecuteQueryToDataTable(param);
                string kshUp1 = "";
                if (dt.Rows.Count == 0)
                    kshUp1 = "0";
                else
                    kshUp1 = dt.Rows[0]["ReturnKsh"].ToString();

                double sp_up = Convert.ToDouble(spUp);
                double temp_up = Convert.ToDouble(tempUp);
                double ksh_down1 = Convert.ToDouble(kshDown1);

                double sp_down = Convert.ToDouble(spDown);
                double temp_down = Convert.ToDouble(tempDown);
                double ksh_up2 = Convert.ToDouble(kshUp2);

                double ksh_down2 = Convert.ToDouble(kshDown2);
                double ksh_up1 = Convert.ToDouble(kshUp1);

                decimal ksh_down3 = ((((decimal)ksh_up1 - (decimal)ksh_down1) / ((decimal)sp_up - (decimal)sp_down)) * (sp - (decimal)sp_up)) + (decimal)ksh_up1;
                decimal ksh_up3 = ((((decimal)ksh_up2 - (decimal)ksh_down2) / ((decimal)sp_up - (decimal)sp_down)) * (sp - (decimal)sp_up)) + (decimal)ksh_up2;
                ksh = ((((decimal)ksh_up3 - (decimal)ksh_down3) / ((decimal)temp_up - (decimal)temp_down)) * (temp - (decimal)temp_up)) + (decimal)ksh_up3;
                return ksh;
            }
            catch
            {
                return 0;
            }
        }

        private static decimal ConvertTempToFahrenheit(string Value,string Unit)
        {
            try
            {
                decimal t = 0;
                if (Unit == "°C")
                    t = (Math.Round((Convert.ToDecimal(Value) * (decimal)1.8) + (decimal)32, 3));
                if (Unit == "°K")
                    t = Math.Round((decimal)1.8 * (Convert.ToDecimal(Value) - 273) + 32, 3);
                if (Unit == "°F")
                    t = Convert.ToDecimal(Value);
                if (Unit == "°R")
                    t = Math.Round(Convert.ToDecimal(Value) - (decimal)459.67, 3);
                return t;
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ConvertTempToKelvin(string Value, string Unit)
        {
            try
            {
                decimal t = 0;
                if (Unit == "°C")
                    t = (Math.Round(Convert.ToDecimal(Value) + (decimal)273, 3));
                if (Unit == "°K")
                    t = Convert.ToDecimal(Value);
                if (Unit == "°F")
                    t = Math.Round((Convert.ToDecimal(Value) + (decimal)459.67) * (5 / 9), 3);
                if (Unit == "°R")
                    t = Math.Round(Convert.ToDecimal(Value) * ((decimal)0.555), 3);
                return t;
            }
            catch
            {
                return 0;
            }
        }

        private static decimal ConvertTempToRankine(string Value, string Unit)
        {
            try
            {
                decimal t = 0;
                if (Unit == "°C")
                    t = (Math.Round((Convert.ToDecimal(Value) + (decimal)273.15) * ((decimal)1.8), 3));
                if (Unit == "°K")
                    t = (Math.Round(Convert.ToDecimal(Value) * ((decimal)1.8), 3));
                if (Unit == "°F")
                    t = Math.Round((Convert.ToDecimal(Value) + (decimal)459.67), 3);
                if (Unit == "°R")
                    t = Convert.ToDecimal(Value);
                return t;
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ConvertTempToCelsius(string Value, string Unit)
        {
            try
            {
                decimal t = 0;
                if (Unit == "°C")
                    t = Convert.ToDecimal(Value);
                if (Unit == "°K")
                    t = (Math.Round(Convert.ToDecimal(Value) - (decimal)273.15, 3));
                if (Unit == "°F")
                    t = Math.Round((Convert.ToDecimal(Value) - 32) * ((decimal)0.555), 3);
                if (Unit == "°R")
                    t = Math.Round((Convert.ToDecimal(Value) - (decimal)491.67) * ((decimal)0.555), 3);
                return t;
            }
            catch
            {
                return 0;
            }
        }

        public static decimal Calculate_L30_For_Gas(string SetPressure, string SetPressureUnit, string OverPressure, string OverPressureUnit,
                                                    string OverPressurePercent, string  AtmPressure, string AtmPressureUnit,string TotalBackPressure,
                                                    string TotalBackPressureUnit,string Q, string MolecularWeight, string K,
                                                    string Relieving, string RelievingUnit,string S)
        {
            try
            {
                decimal l30 = 0;
                decimal p1 = Calculate_P1_For_Noise(SetPressure, SetPressureUnit, OverPressurePercent);
                decimal pb = Calculate_Pb_For_Noise(TotalBackPressure, TotalBackPressureUnit, AtmPressure, AtmPressureUnit);
                decimal pr = Calculate_Pr_For_Npise(SetPressure, SetPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit);
                decimal l = 0;
                if (pr <= (decimal)2.923)
                    l = ((decimal)18.477 * pr) - (decimal)0.4172;
                else
                    l = ((decimal)0.6053 * pr) + (decimal)51.817;

                decimal q = Convert.ToDecimal(Q) / 60;
                decimal M = Convert.ToDecimal(MolecularWeight);
                decimal p2 = pb + (decimal)1.03;
                decimal k = Convert.ToDecimal(K);
                decimal t1 = ConvertTempToKelvin(Relieving, RelievingUnit);
                decimal t2 = t1 * Convert.ToDecimal(Math.Pow(((double)p2 / (double)p1), (((double)k - 1) / (double)k)));
                decimal s = Convert.ToDecimal(S);
                decimal c = (decimal)91.2 * Convert.ToDecimal(Math.Pow((double)k * (double)t1 / (double)M, 0.5));
                l30 = l + (10 * Convert.ToDecimal(Math.Log10(0.5 * (double)q * Math.Pow((double)c, 2))));
                return l30;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal Calculate_L1_For_Gas(decimal L30)
        {
            try
            {
                decimal l1 = 0;
                l1 = L30 + (decimal)29.542;
                return l1;
            }
            catch
            {
                return 0;
            }
        }

        public static decimal Calculate_L1P_For_Gas(decimal L1,string SetPressure, string SetPressureUnit, string OverPressure, string OverPressureUnit,
                                                   string OverPressurePercent, string AtmPressure, string AtmPressureUnit, string TotalBackPressure,
                                                   string TotalBackPressureUnit, string Q, string MolecularWeight, string K,
                                                   string Relieving, string RelievingUnit, string Di, string S)
        {
            try
            {
                decimal l1p = 0;
                decimal p1 = Calculate_P1_For_Noise(SetPressure, SetPressureUnit, OverPressurePercent);
                decimal pb = Calculate_Pb_For_Noise(TotalBackPressure, TotalBackPressureUnit, AtmPressure, AtmPressureUnit);

                decimal q = Convert.ToDecimal(Q) / 60;
                decimal M = Convert.ToDecimal(MolecularWeight);
                decimal p2 = pb + (decimal)1.03;
                decimal k = Convert.ToDecimal(K);
                decimal t1 = ConvertTempToKelvin(Relieving, RelievingUnit);
                decimal t2 = t1 * Convert.ToDecimal(Math.Pow(((double)p2 / (double)p1), (((double)k - 1) / (double)k)));
                decimal di = Convert.ToDecimal(Di);
                decimal s = Convert.ToDecimal(S);


                decimal c2 = ((q / M) * (decimal)22.414 * (273 / t2) / 3600) / Convert.ToDecimal((Math.Pow(((Double)di / 1000), 2))) * ((decimal)3.14 * 10000);
                decimal ro2 = M * p2 / t2 * ((decimal)273 / (decimal)22.4);
                l1p = L1 + ((decimal)10 * (decimal)Math.Log10(3 * Math.Pow(10, -13) * Math.Pow((double)c2 * (double)di / (double)s, 2) / (((double)ro2 * (double)c2) / 415) + 1));
                return l1p;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static decimal Calculate_P1_For_Noise(string SetPressure, string SetPressureUnit, string OverPressurePercent)
        {
            try {
                decimal p1 = 0;
                decimal sp = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                p1 = sp * (1 + Convert.ToDecimal(OverPressurePercent) / 100) + (decimal)1.03;
                return p1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static decimal Calculate_Pb_For_Noise(string TotalBackPressure,string TotalBackPressureUnit,string AtmPressure,string AtmPressureUnit)
        {
            try
            {
                decimal pb = 0;
                decimal tbp = ConvertUnit(Convert.ToDecimal(TotalBackPressure), TotalBackPressureUnit, "psig");
                decimal atm = ConvertUnit(Convert.ToDecimal(AtmPressure), AtmPressureUnit, "psia");
                pb = tbp + atm;
                return pb;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static decimal Calculate_Pr_For_Npise(string SetPressure, string SetPressureUnit, string OverPressurePercent, string AtmPressure, string AtmPressureUnit)
        {
            try
            {
                decimal pr = 0;
                decimal sp = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                decimal atm = ConvertUnit(Convert.ToDecimal(AtmPressure), AtmPressureUnit, "psia");
                pr = ((sp * ((decimal)1 + (Convert.ToDecimal(OverPressurePercent) / (decimal)100))) + (decimal)14.69595) / atm;
                return pr;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal Calculate_A_For_2Phase_C22(int ProjectIndex,string RequiredPressureFlow2Phase, string RequiredFlow2PhaseUnit, string V90, string V90Unit,
                                                         string Relieving, string RelievingTemp, string AtmPressure, string AtmPressureUnit, string V0, string V0Unit,
                                                         string SetPressure, string SetPressureUnit, string OverPressurePercent, string Kv, string Kd,
                                                         string OverPressure, string OverPressureUnit, string TotalBackPressure,
                                                         string TotalBackPressureUnit, string Kc, string InletLoss, string InletLossPercent, string InletLossUnit)

        {
            try {
                decimal A = 0;
                decimal w = Calculate_W_For_Gas(RequiredPressureFlow2Phase, RequiredFlow2PhaseUnit);
                decimal t = ConvertTempToFahrenheit(Relieving, RelievingTemp);
                decimal p2 = Calculate_P2(TotalBackPressure, TotalBackPressureUnit, AtmPressure, AtmPressureUnit, "Gas");
                decimal p_set = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                decimal p_bp = ConvertUnit(Convert.ToDecimal(TotalBackPressure), TotalBackPressureUnit, "psig");
                decimal p_reliv = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Gas");
                decimal pr = p2 / p_reliv;
                decimal v_0 = (decimal)16.01846 * ConvertUnit(Convert.ToDecimal(V0), V0Unit, "ft³/lb");
                decimal v_9 = (decimal)16.01846 * ConvertUnit(Convert.ToDecimal(V90), V90Unit, "ft³/lb");
                decimal kd = Convert.ToDecimal(Kd);
                decimal kc = Convert.ToDecimal(Kc);
                decimal kv = Convert.ToDecimal(Kv);
                decimal kb = Calculate_Kb_For_Gas(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit, OverPressurePercent, OverPressure, OverPressureUnit);
                decimal W = 9 * ((v_9 / v_0) - 1);
                double eta_c = Math.Pow((1 + (1.0446 - 0.0093431 * Math.Pow((double)W, 0.5)) * Math.Pow((double)W, -0.56261)), (-0.70356 + 0.014685 * Math.Log10((double)W)));
                double pc = eta_c * (double)p_reliv;               
                double G = 68.09 * eta_c * Math.Sqrt(((double)p_reliv / ((double)v_0 * (double)W)));
                A = ((decimal)0.04 * W) / (kd * kb * kc * kv * (decimal)G);

                Program.ProjectList[ProjectIndex].P1 = p_reliv.ToString();
                Program.ProjectList[ProjectIndex].P1_unit = "psia";
                Program.ProjectList[ProjectIndex].P2 = p2.ToString();
                Program.ProjectList[ProjectIndex].P2_unit = "psia";
                Program.ProjectList[ProjectIndex].PR = pr.ToString();
                Program.ProjectList[ProjectIndex].PR_unit = "";

                Program.ProjectList[ProjectIndex].V0 = v_0.ToString();
                Program.ProjectList[ProjectIndex].V90 = v_9.ToString();
                Program.ProjectList[ProjectIndex].Kv = kv.ToString();
                Program.ProjectList[ProjectIndex].Omega = W.ToString();
                Program.ProjectList[ProjectIndex].Eta_c = eta_c.ToString();
                Program.ProjectList[ProjectIndex].Pc = pc.ToString() ;
                Program.ProjectList[ProjectIndex].Pc_Unit = "psia";
                
                Program.ProjectList[ProjectIndex].G = G.ToString();
                Program.ProjectList[ProjectIndex].G_Unit = "lb/s·ft²";
                Program.ProjectList[ProjectIndex].Areq = A.ToString();
                Program.ProjectList[ProjectIndex].Areq_Unit = "in²";
                if (pc > ((double)p_bp + 14.7))
                    Program.ProjectList[ProjectIndex].G_Critical = G.ToString();
                else if (pc < ((double)p_bp + 14.7))
                    Program.ProjectList[ProjectIndex].G_SubCritical = G.ToString();

                return A;
            }
            catch
            {
                return 0;
            }
        }

        public static string Calculate_W_For_2Phase_C22(string A, string RequiredPressureFlow2Phase, string RequiredFlow2PhaseUnit, string V90, string V90Unit,
                                                        string Relieving, string RelievingTemp, string AtmPressure, string AtmPressureUnit, string V0, string V0Unit,
                                                        string SetPressure, string SetPressureUnit, string OverPressurePercent, string Kv, string Kd,
                                                        string OverPressure, string OverPressureUnit, string TotalBackPressure,
                                                        string TotalBackPressureUnit, string Kc, string InletLoss, string InletLossPercent, string InletLossUnit)

        {
            try
            {
                decimal W1 = 0;
                decimal w2 = Calculate_W_For_Gas(RequiredPressureFlow2Phase, RequiredFlow2PhaseUnit);
                decimal t = ConvertTempToFahrenheit(Relieving, RelievingTemp);
                decimal p_set = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                decimal p_bp = ConvertUnit(Convert.ToDecimal(TotalBackPressure), TotalBackPressureUnit, "psig");
                decimal p_reliv = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Gas");
                decimal v_0 = (decimal)16.01846 * ConvertUnit(Convert.ToDecimal(V0), V0Unit, "ft³/lb");
                decimal v_9 = (decimal)16.01846 * ConvertUnit(Convert.ToDecimal(V90), V90Unit, "ft³/lb");
                decimal kd = Convert.ToDecimal(Kd);
                decimal kc = Convert.ToDecimal(Kc);
                decimal kv = Convert.ToDecimal(Kv);
                decimal kb = Calculate_Kb_For_Gas(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit, OverPressurePercent, OverPressure, OverPressureUnit);
                decimal W = 9 * ((v_9 / v_0) - 1);
                double eta_c = Math.Pow((1 + (1.0446 - 0.0093431 * Math.Pow((double)W, 0.5)) * Math.Pow((double)W, -0.56261)), (-0.70356 + 0.014685 * Math.Log10((double)W)));
                double G = 68.09 * eta_c * Math.Sqrt(((double)p_reliv / ((double)v_0 * (double)W)));
                W1 = (Convert.ToDecimal(A) * kd * kb * kc * kv * (decimal)G) / (decimal)0.04;
                return W1.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static decimal Calculate_A_For_2Phase_C23(int ProjectIndex, string LiquidDensity, string LiquidDensityUnit, string MixDensity90, string MixDensity90Unit,
                                                        string Relieving, string RelievingTemp, string AtmPressure, string AtmPressureUnit, string VaporPressure, string RequiredPressureFlow,
                                                        string SetPressure, string SetPressureUnit, string OverPressurePercent, string Kv, string Kd, string RequiredPressureFlowUnit,
                                                        string OverPressure, string OverPressureUnit, string TotalBackPressure,
                                                        string TotalBackPressureUnit, string Kc, string InletLoss, string InletLossPercent, string InletLossUnit)

        {
            try
            {
                decimal A = 0;
                decimal Q = ConvertUnit(Convert.ToDecimal(RequiredPressureFlow), RequiredPressureFlowUnit, "GPM(US)");
                decimal kd = Convert.ToDecimal(Kd);
                decimal kc = Convert.ToDecimal(Kc);
                decimal kv = Convert.ToDecimal(Kv);
                decimal kb = Calculate_Kb_For_Gas(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit, OverPressurePercent, OverPressure, OverPressureUnit);
                decimal ro_10 = ConvertUnit(Convert.ToDecimal(LiquidDensity), LiquidDensityUnit, "lb/ft3");
                decimal ro_9 = ConvertUnit(Convert.ToDecimal(MixDensity90), MixDensity90Unit, "lb/ft3");
                decimal ws = 9 * ((ro_10 / ro_9) - 1); //omega
                decimal eta_st = (2 * ws) / (1 + 2 * ws);
                decimal ps = Convert.ToDecimal(VaporPressure);
                decimal p_set = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                decimal p_bp = ConvertUnit(Convert.ToDecimal(TotalBackPressure), TotalBackPressureUnit, "psig");
                decimal p_atm = ConvertUnit(Convert.ToDecimal(AtmPressure), AtmPressureUnit, "psia");
                decimal eta_s = ps / p_set;
                decimal eta_a = ps / p_bp;
                decimal eta_c = 0;
                if (eta_s <= eta_st)
                    eta_c = eta_s;
                else if (eta_s > eta_st)
                    eta_c = eta_s * (2 * ws / 2 * ws - 1) * (1 - Convert.ToDecimal(Math.Sqrt(1 - 1 / (double)eta_s * (2 * (double)ws - 1 / 2 * (double)ws))));
                decimal p_reliv = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Liquid");
                decimal pc = eta_c * p_reliv;
                double G = 0;
                if (ps >= eta_st * p_reliv)
                {
                    decimal eta = 0;
                    if (pc > p_bp + p_atm)
                        eta = eta_c; // flow critical
                    else if (pc < p_bp + p_atm)
                        eta = eta_a; // subcritical flow
                    G = (68.09 * Math.Pow((2 * (1 - (double)eta_s) + 2 * ((double)ws * (double)eta_s * Math.Log10((double)eta_s / (double)eta) - ((double)ws - 1) * ((double)eta_s - (double)eta))), 0.5) / (double)ws * ((double)eta_s / (double)eta - 1) + 1) * Math.Sqrt((double)p_reliv * (double)ro_10);
                }
                if (ps < eta_st * p_reliv)
                {
                    decimal p = 0;
                    if (ps > p_bp + p_atm)
                        p = ps; //critical flow
                    else if (ps > p_bp + p_atm)
                        p = p_bp; // subcritical flow (all-liquid flow)
                    G = 96.3 * Math.Pow((double)ro_10 * ((double)p_reliv - (double)p), 0.5);
                }
                A = (decimal)0.3208 * (Q * ro_10) / (kd * kb * kc * kv * (decimal)G);
                return A;
            }
            catch (Exception)
            {
                return 0;
            }

                
        }

        public static string Calculate_W_For_2Phase_C23(string A, string LiquidDensity, string LiquidDensityUnit, string MixDensity90, string MixDensity90Unit,
                                                        string Relieving, string RelievingTemp, string AtmPressure, string AtmPressureUnit, string VaporPressure, string RequiredPressureFlow,
                                                        string SetPressure, string SetPressureUnit, string OverPressurePercent, string Kv, string Kd, string RequiredPressureFlowUnit,
                                                        string OverPressure, string OverPressureUnit, string TotalBackPressure,
                                                        string TotalBackPressureUnit, string Kc, string InletLoss, string InletLossPercent, string InletLossUnit)

        {
            try
            {
                decimal W = 0;
                decimal Q = ConvertUnit(Convert.ToDecimal(RequiredPressureFlow), RequiredPressureFlowUnit, "GPM(US)");
                decimal kd = Convert.ToDecimal(Kd);
                decimal kc = Convert.ToDecimal(Kc);
                decimal kv = Convert.ToDecimal(Kv);
                decimal kb = Calculate_Kb_For_Gas(SetPressure, SetPressureUnit, TotalBackPressure, TotalBackPressureUnit, OverPressurePercent, OverPressure, OverPressureUnit);
                decimal ro_10 = ConvertUnit(Convert.ToDecimal(LiquidDensity), LiquidDensityUnit, "lb/ft3");
                decimal ro_9 = ConvertUnit(Convert.ToDecimal(MixDensity90), MixDensity90Unit, "lb/ft3");
                decimal ws = 9 * ((ro_10 / ro_9) - 1); //omega
                decimal eta_st = (2 * ws) / (1 + 2 * ws);
                decimal ps = Convert.ToDecimal(VaporPressure);
                decimal p_set = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                decimal p_bp = ConvertUnit(Convert.ToDecimal(TotalBackPressure), TotalBackPressureUnit, "psig");
                decimal p_atm = ConvertUnit(Convert.ToDecimal(AtmPressure), AtmPressureUnit, "psia");
                decimal eta_s = ps / p_set;
                decimal eta_a = ps / p_bp;
                decimal eta_c = 0;
                if (eta_s <= eta_st)
                    eta_c = eta_s;
                else if (eta_s > eta_st)
                    eta_c = eta_s * (2 * ws / 2 * ws - 1) * (1 - Convert.ToDecimal(Math.Sqrt(1 - 1 / (double)eta_s * (2 * (double)ws - 1 / 2 * (double)ws))));
                decimal p_reliv = Calculate_P1(SetPressure, SetPressureUnit, OverPressure, OverPressureUnit, OverPressurePercent, AtmPressure, AtmPressureUnit, InletLoss, InletLossPercent, InletLossUnit, "Liquid");
                decimal pc = eta_c * p_reliv;
                double G = 0;
                if (ps >= eta_st * p_reliv)
                {
                    decimal eta = 0;
                    if (pc > p_bp + p_atm)
                        eta = eta_c; // flow critical
                    else if (pc < p_bp + p_atm)
                        eta = eta_a; // subcritical flow
                    G = (68.09 * Math.Pow((2 * (1 - (double)eta_s) + 2 * ((double)ws * (double)eta_s * Math.Log10((double)eta_s / (double)eta) - ((double)ws - 1) * ((double)eta_s - (double)eta))), 0.5) / (double)ws * ((double)eta_s / (double)eta - 1) + 1) * Math.Sqrt((double)p_reliv * (double)ro_10);
                }
                if (ps < eta_st * p_reliv)
                {
                    decimal p = 0;
                    if (ps > p_bp + p_atm)
                        p = ps; //critical flow
                    else if (ps > p_bp + p_atm)
                        p = p_bp; // subcritical flow (all-liquid flow)
                    G = 96.3 * Math.Pow((double)ro_10 * ((double)p_reliv - (double)p), 0.5);
                }
                W = (Convert.ToDecimal(A) * kd * kb * kc * kv * (decimal)G) / (decimal)0.3208 * ro_10;
                return W.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void Calculate_ReactionForce(int CurrentProjectIndex,string FluidType,string SelectedFlowCapacity,string ReactionForceUnit,string K,string Relieving, string RelievingUnit,string MolecularWeight,string Size,string SetPressure,string SetPressureUnit,string OverPressurePercent)
        {
            try
            {
                if (FluidType == "Gas" || FluidType == "Steam")
                {
                    decimal w = ConvertUnit(Convert.ToDecimal(SelectedFlowCapacity), ReactionForceUnit, "lb/hr");
                    decimal k = Convert.ToDecimal(K);
                    decimal t = ConvertTempToRankine(Relieving, RelievingUnit);
                    decimal m = Convert.ToDecimal(MolecularWeight);
                    decimal a = Convert.ToDecimal(Size);
                    decimal sp = ConvertUnit(Convert.ToDecimal(SetPressure), SetPressureUnit, "psig");
                    decimal p = sp * (1 + Convert.ToDecimal(OverPressurePercent) / 100) + (decimal)1.03;
                    decimal f = (w / 366) * Convert.ToDecimal(Math.Sqrt(((double)k * (double)t) / ((double)k + 1) * (double)m)) + (a * p);
                    Program.ProjectList[CurrentProjectIndex].Estimated_Reaction_Force = Math.Round(f, 2).ToString();
                }
            }
            catch
            {

            }
        }

        public static DataTable GetClassLimits(string Temp, string Perssure,string Material)
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetClassLimits";
                string[,] newparams = new string[3, 2];

                newparams[0, 0] = "@Temp";
                newparams[0, 1] = Temp;

                newparams[1, 0] = "@Perssure";
                newparams[1, 1] = Perssure;

                newparams[2, 0] = "@Material";
                newparams[2, 1] = Material;

                dt = dl.ExcecuteQueryToDataTable(newparams);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetBodyMaterialsLimits(string Temp, string Perssure, string Class)
        {
            try
            {
                DataTable dt = new DataTable();
                DAL dl = new DAL();
                dl.StoredProcedureName = "prcGetBodyMaterilaLimits";
                string[,] newparams = new string[3, 2];

                newparams[0, 0] = "@Temp";
                newparams[0, 1] = Temp;

                newparams[1, 0] = "@Perssure";
                newparams[1, 1] = Perssure;

                newparams[2, 0] = "@Class";
                newparams[2, 1] = Class;

                dt = dl.ExcecuteQueryToDataTable(newparams);
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }

}
