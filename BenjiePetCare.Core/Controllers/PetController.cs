using BenjiePetCare.Core.Abstracts;
using BenjiePetCare.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenjiePetCare.Core.Controllers
{
    public class PetController:IPetController
    {

        string connectionString = string.Empty;

        public PetController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }

        public Pet Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> Get()
        {
            List<Pet> pets = new List<Pet>();

            //get pets from db
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string sql = @"SELECT * FROM PETS";

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Pet pet = new Pet();

                        pet.Id = Int32.Parse(data["Id"].ToString());
                        pet.Name = data["Name"].ToString();
                        pet.Notes = data["Notes"].ToString();
                        pet.IsOnCare = Boolean.Parse(data["IsOnCare"].ToString());

                        pets.Add(pet);
                    }
                }

                data.Dispose();
                cmd.Dispose();
            }

            return pets;
        }

        public bool Add(Pet pet)
        {
            bool isSuccess = false;

            //insert on db
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string sql = @"INSERT INTO Pets (Name, IsOnCare) 
                                VALUES (@name,@isOnCare);";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@name", pet.Name);
                cmd.Parameters.AddWithValue("@isOnCare", pet.IsOnCare);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    isSuccess = true;
                }
            }


            return isSuccess;
        }

        public bool Update(Pet entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
