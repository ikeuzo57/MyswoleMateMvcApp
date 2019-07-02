using MyswoleMateMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyswoleMateMvcApp.MySwoleMateDAL
{
    //DAL stands for Data Access Layer. Data Access Layer is the layer which communicates to the database.
    public class TraineeDAL
    {
        //uses connection string for connecting to database
       
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ConnectionString;
        

        public int AddTraineeInfo(Trainee trainee)
        {
            {
                string sqlQuery = "INSERT into Trainee (FirstName, LastName, Email, Height, " +
                    "Weight, CellNbr, Gender, Age) VALUES (@FirstName, @LastName, @Email, @Height, " +
                    "@Weight, @CellNbr, @Gender, @Age)";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = trainee.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = trainee.LastName;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = trainee.Email;
                    cmd.Parameters.Add("@Height", SqlDbType.Int).Value = trainee.Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.Int).Value = trainee.Weight;
                    cmd.Parameters.Add("@CellNbr", SqlDbType.VarChar).Value = trainee.CellNbr;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = trainee.Gender;
                    cmd.Parameters.Add("@Age", SqlDbType.Int).Value = trainee.Age;
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        // this method returns List of Trainee
        public List<TraineeViewModel> GetAllTrainees()
        {
            //SQL command for selecting all from Trainee table
            string sqlQuery = "SELECT * FROM Trainee";

            //Empty list of TraineeViewModel to add and return
            List<TraineeViewModel> trainees = new List<TraineeViewModel>();

            //Using SqlConnection to establish connection to database
            //using SqlCommand passing in the SqlConnection and the sqlQuery
            using (SqlConnection con = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                // Open Connection
                con.Open();
                //SqlDataReader is used because we are reading data from the database
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //while there are records in the database
                    while (reader.Read())
                    {
                        //store each value into the properties of TraineeViewModel
                        TraineeViewModel temp = new TraineeViewModel()
                        {
                            TraineeID = Convert.ToInt32(reader["TraineeID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Height = Convert.ToInt32(reader["Height"]),
                            Weight = Convert.ToInt32(reader["Weight"]),
                            CellNbr = reader["CellNbr"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Age = Convert.ToInt32(reader["Age"])
                        };
                        //Add the Trainee object to the List of Trainee
                        trainees.Add(temp);
                    }
                }

            }
            return trainees;
        }
    }
}