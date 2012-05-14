using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Controller
{
    class DBController
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private string connectionstring;
        private ModelController controller;

        public DBController(ModelController controller)
        {
            this.controller = controller;
                       
            connectionstring = Properties.Settings.Default.lovenshuleDBConnectionString;


            con = new SqlConnection(connectionstring);
            cmd = new SqlCommand();
            cmd.Connection = con; //SqlConnection-object is added to SqlCommand-object
            cmd.CommandType = CommandType.StoredProcedure; // declares that we're using a stored procedure
        }

        public void GetAllEntries()
        {
            SqlDataReader datareader = null; //is used to reference received data
                       
            int score;
            int playTime;
            int levelCount;
            int  entryID;
            DateTime entryTime;

            cmd.Parameters.Clear();

            cmd.CommandText = "GetAllEntries";

            try
            {
                con.Open();
                datareader = cmd.ExecuteReader(); //Reads and returns data

                while (datareader.Read() == true)
                {
                    score = (int)datareader["score"];
                    playTime = (int)datareader["playTime"];
                    levelCount = (int)datareader["levelCount"];
                    entryID = (int)datareader["entryID"];
                    entryTime = (DateTime)datareader["entryTime"];

                    //Not implemented yet!!!!!!!!!!
                    //controller.DB_AddEntry(score, playTime, levelCount, entryID, entryTime);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //close the reader
                if (datareader != null)
                {
                    datareader.Close();
                }

                //close the connection
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
