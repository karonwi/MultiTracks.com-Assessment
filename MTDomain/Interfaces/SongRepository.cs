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
    public class SongRepository : IRepository<Song>
    {
        private readonly string _connectionString;

        public SongRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public Task<Song> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Song>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(Song entity)
        {
            throw new NotImplementedException();
        }

        public Task<Song> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Song>> ListPaginatedAsync(int pageSize, int pageNumber)
        {
            List<Song> songs = new List<Song>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("ListAllSongs", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@PageSize", pageSize));
                    cmd.Parameters.Add(new SqlParameter("@PageNumber", pageNumber));

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var song = new Song
                            {
                                SongID = reader.GetInt32(reader.GetOrdinal("SongID")),
                                DateCreation = reader.GetDateTime(reader.GetOrdinal("DateCreation")),
                                AlbumID = reader.GetInt32(reader.GetOrdinal("AlbumID")),
                                ArtistID = reader.GetInt32(reader.GetOrdinal("ArtistID")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Bpm = reader.GetDecimal(reader.GetOrdinal("Bpm")),
                                TimeSignature = reader.GetString(reader.GetOrdinal("TimeSignature")),
                                Multitracks = reader.GetBoolean(reader.GetOrdinal("Multitracks")),
                                CustomMix = reader.GetBoolean(reader.GetOrdinal("CustomMix")),
                                Chart = reader.GetBoolean(reader.GetOrdinal("Chart")),
                                RehearsalMix = reader.GetBoolean(reader.GetOrdinal("RehearsalMix")),
                                Patches = reader.GetBoolean(reader.GetOrdinal("Patches")),
                                SongSpecificPatches = reader.GetBoolean(reader.GetOrdinal("SongSpecificPatches")),
                                ProPresenter = reader.GetBoolean(reader.GetOrdinal("ProPresenter"))
                            };

                            songs.Add(song);
                        }
                    }
                }
            }

            return songs;
        }
    }
}
