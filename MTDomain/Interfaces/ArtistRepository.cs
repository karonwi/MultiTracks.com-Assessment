using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using MTDomain.Entities;

namespace MTDomain.Interfaces
{
    public class ArtistRepository : IRepository<Artist>
    {
        private readonly string _connectionString;

        public ArtistRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public Task<Artist> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artist>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(Artist artist)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("AddArtist", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@DateCreation", artist.DateCreation));
                    cmd.Parameters.Add(new SqlParameter("@Title", artist.Title));
                    cmd.Parameters.Add(new SqlParameter("@Biography", artist.Biography));
                    cmd.Parameters.Add(new SqlParameter("@ImageURL", artist.ImageURL));
                    cmd.Parameters.Add(new SqlParameter("@HeroURL", artist.HeroURL));

                    int artistId = Convert.ToInt32((decimal)await cmd.ExecuteScalarAsync());

                    return artistId;
                }
            }
        }

        public async Task<Artist> GetByNameAsync(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("GetArtistByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", name.Trim());

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Artist
                            {
                                ArtistID = reader.GetInt32(reader.GetOrdinal("ArtistID")),
                                DateCreation = reader.GetDateTime(reader.GetOrdinal("DateCreation")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Biography = reader.IsDBNull(reader.GetOrdinal("Biography")) ? null : reader.GetString(reader.GetOrdinal("Biography")),
                                ImageURL = reader.IsDBNull(reader.GetOrdinal("ImageURL")) ? null : reader.GetString(reader.GetOrdinal("ImageURL")),
                                HeroURL = reader.IsDBNull(reader.GetOrdinal("HeroURL")) ? null : reader.GetString(reader.GetOrdinal("HeroURL"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Task<IEnumerable<Artist>> ListPaginatedAsync(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
