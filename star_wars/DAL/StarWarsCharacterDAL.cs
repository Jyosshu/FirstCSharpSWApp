using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using star_wars.Models;
using System.Data.SqlClient;

namespace star_wars.DAL
{
    public class StarWarsCharacterDAL
    {
        
        public List<StarWarsCharacter> GetCharacters()
        {
            List<StarWarsCharacter> output = new List<StarWarsCharacter>();

            try
            {
                using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=StarWars;Trusted_Connection=True;"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Characters;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StarWarsCharacter character = new StarWarsCharacter();
                        character.Name = Convert.ToString(reader["name"]);
                        character.HomePlanet = Convert.ToString(reader["homeplanet"]);
                        character.IsForceSensitive = Convert.ToBoolean(reader["isForceSensative"]);
                        character.IdDarkSide = Convert.ToBoolean(reader["isDarkSide"]);

                        output.Add(character);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }

            return output;
        }

    }
}