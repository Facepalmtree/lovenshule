using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

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
            //"Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\lovenshuleDB.mdf;Integrated Security=True;User Instance=True;";


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
                    controller.DB_AddEntry(score, playTime, levelCount, entryID, entryTime);
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

        public int AddEntry(int score, int playTime, int levelCount, DateTime entryTime)
        {
            int entryID = -1;

            cmd.CommandText = "AddEntry"; //angiv  stored procedure

            cmd.Parameters.Clear(); //tøm parameterlisten

            //sæt værdier ind i parametrene
            SqlParameter par = new SqlParameter("@score", SqlDbType.Int);
            par.Value = score;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@playTime", SqlDbType.Int);
            par.Value = playTime;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@levelCount", SqlDbType.Int);
            par.Value = levelCount;
            cmd.Parameters.Add(par);
            
            par = new SqlParameter("@entryID", SqlDbType.Int);
            par.Direction = ParameterDirection.Output;            
            cmd.Parameters.Add(par);

            par = new SqlParameter("@entryTime", SqlDbType.DateTime);
            par.Value = entryTime;
            cmd.Parameters.Add(par);

            try
            {
                con.Open(); // opens connections
                cmd.ExecuteNonQuery(); //executes command
                entryID = (int)cmd.Parameters["@entryID"].Value; //returns entryID

                return entryID;
            }
            catch //(SqlException e)
            {
                return entryID;
            }
            finally //if connections is open, close it
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void DeleteEntry(int entryID)
        {

            cmd.CommandText = "DeleteEntry"; 

            cmd.Parameters.Clear();
            
            SqlParameter par = new SqlParameter("@entryID", SqlDbType.Int);
            par.Value = entryID;
            cmd.Parameters.Add(par);

            try
            {
                con.Open(); // opens connections
                cmd.ExecuteNonQuery(); //executes command//returns entryID
                
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally //if connections is open, close it
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void ResetHighscore()
        {
            cmd.CommandText = "ResetHighscore";

            cmd.Parameters.Clear();

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
