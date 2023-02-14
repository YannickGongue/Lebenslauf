using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Style;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EngineeringToolsCV_1.Repositories
{
    public class UserInfosRepositories : IUserInfoRepository
    {
        private SqlCommand sqlcmdManager;         // Sql-Befehle ausführen.
        private SqlConnection sqlconManager;      //Die Verbindung einer Datenbank herstellen.
        private Constante Constant;
        private Setting setting;
        private MessageDialog dialogMessage;

        public void AddStudentInfos(MStudentInformations mStudentInformations)
        {
            throw new NotImplementedException();
        }

        public void FindStudentInfos(MStudentInformations mStudentInformations)
        {
            throw new NotImplementedException();
        }

        public void Foto()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudentInfos(MStudentInformations mStudentInformations)
        {
            throw new NotImplementedException();
        }

        public void SaveStudentInfos(MStudentInformations mStudentInformations)
        {
            int iCount;                   //Anzahl der Einträge.
            string strQueryRegister;      //SqlAbfrage festlegen.
            this.dialogMessage = new MessageDialog();

            //Connectionstring-Objekt instanzieren.
            sqlconManager = new SqlConnection();
            //Die Verbindung einer Datenbank festlegen.
            sqlconManager.ConnectionString = setting.ConnectionString;
            //Sql-command Objekt instanzieren.
            sqlcmdManager = new SqlCommand();
            Constant = new Constante();
            //Sql-Command zuweisen.
            sqlcmdManager.Connection = sqlconManager;

                try
                {
                    //Verbindung öffnen.
                    sqlconManager.Open();
                    //sql-Befehle zusammensetzen.
                    strQueryRegister = string.Format("INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7})" +
                                                     "VALUES(@1,@2,@3,@4,@5,@6,@7)",
                                                     Constant.strTBL_StudentsInfo,
                                                     Constant.strName,
                                                     Constant.strVorname,
                                                     Constant.strAlter,
                                                     Constant.StrEmail,
                                                     Constant.strStraße,
                                                     Constant.strNummer,
                                                     Constant.strPostleitzahl,
                                                     Constant.strStadt);
                    //Parameters-collection leeren.
                    sqlcmdManager.Parameters.Clear();
                    // Parameters collection einfügen.
                    sqlcmdManager.Parameters.AddWithValue("@1", mStudentInformations.Name);
                    sqlcmdManager.Parameters.AddWithValue("@2", mStudentInformations.Vorname);
                    sqlcmdManager.Parameters.AddWithValue("@3", mStudentInformations.Alter);
                    sqlcmdManager.Parameters.AddWithValue("@4", mStudentInformations.Email);
                    sqlcmdManager.Parameters.AddWithValue("@6", mStudentInformations.Straße);
                    sqlcmdManager.Parameters.AddWithValue("@7", mStudentInformations.Postleitzahl);
                    sqlcmdManager.Parameters.AddWithValue("@8", mStudentInformations.Stadt);
                    sqlcmdManager.Parameters.AddWithValue("@9", mStudentInformations.Straßenummer);
                    

                    //Sql-Abfrage festlegen.
                    sqlcmdManager.CommandType = CommandType.Text;
                    sqlcmdManager.CommandText = strQueryRegister;
                    
                    //sql-Befehle ausführen.
                    iCount = sqlcmdManager.ExecuteNonQuery();
                //sind die Datensätze eingefügt?
                if (iCount == 1)
                {
                    this.dialogMessage.ErrorMessage.Text = "die Einträgen wurden erfolgreich in die Datenbank hinzugefügt";
                    this.dialogMessage.Show();                
                }  
                   
                    //Die Verbindung schließen.
                    sqlconManager.Close();
                }
                catch (Exception ex)
                {
                    //Fehlermeldung
                   this.dialogMessage.ErrorMessage.Text = ex.Message.ToString();
                   this.dialogMessage.Show();
                }
            }

        public void UpdateStudentInfos(MStudentInformations mStudentInformations)
        {
            throw new NotImplementedException();
        }
    }
}
