using Npgsql;
using Pharmcy.Entities.Medicines;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmcy.Repostories.Medicines;

public class MedicineRepository : BaseRepository, IMedicineRepository
{
    public MedicineRepository()
    {
           
    }
    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(Medicine obj)
    {
        try
        {
            //await _connection.OpenAsync();
            await _connection.OpenAsync();

            string query = "INSERT INTO public.\"Medicines\"(\"MedCategory\", \"Name\", \"Description\", \"Price\", \"CreatedTime\", \"EndTime\", \"CreatedAt\", \"UpdatedAt\", \"image_path\")" +
                "VALUES (@MedCategory, @Name, @Description, @Price, @CreatedTime, @EndTime, @CreatedAt, @UpdatedAt,@image_path);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@MedCategory", obj.MedCategory);
                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Description", obj.Description);
                command.Parameters.AddWithValue("@Price", obj.Price);
                command.Parameters.AddWithValue("@CreatedTime", obj.CreatTime);
                command.Parameters.AddWithValue("@EndTime", obj.EndTime);
                command.Parameters.AddWithValue("@CreatedAt", obj.CreatedAT);
                command.Parameters.AddWithValue("@UpdatedAt", obj.UpdatedAT);
                command.Parameters.AddWithValue("@image_path", obj.image_path);
                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM public.\"Medicines\" WHERE \"MedId\"={id};";
            await using (var command = new NpgsqlCommand( query, _connection))
            {
               int natija = await command.ExecuteNonQueryAsync();
               return natija;
            } 
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }   
    }
    public async Task<IList<Medicine>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Medicine>();
            string query = $"SELECT * FROM public.\"Medicines\" ORDER BY \"MedId\" offset {(@params.PageNumber - 1) * @params.PageSize} limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using ( var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync()) 
                    {
                        var med = new Medicine();
                        med.MedId = reader.GetInt64(0);
                        med.MedCategory = reader.GetString(1);
                        med.Name = reader.GetString(2);
                        med.Description = reader.GetString(3);
                        med.Price = reader.GetString(4);
                        med.CreatTime = reader.GetDateTime(5);
                        med.EndTime = reader.GetDateTime(6);
                        med.CreatedAT = reader.GetDateTime(7);
                        med.UpdatedAT = reader.GetDateTime(8);
                        med.image_path = reader.GetString(9);
                        list.Add(med);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Medicine>();
        }
        finally
        {
            await _connection.CloseAsync();
        }

    }
    public async Task<Medicine> GetASync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from public.\"Medicines\" order by \"MedId\" where Name ilike '\"name\"'";
            var med = new Medicine();
            await using (var command = new NpgsqlCommand(query,_connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        med.MedId = reader.GetInt64(0);
                        med.MedCategory = reader.GetString(1);
                        med.Name = reader.GetString(2);
                        med.Description = reader.GetString(3);
                        med.Price = reader.GetString(4);
                        med.CreatTime = reader.GetDateTime(5);
                        med.EndTime = reader.GetDateTime(6);
                        med.CreatedAT = reader.GetDateTime(7);
                        med.UpdatedAT = reader.GetDateTime(8);
                        med.image_path = reader.GetString(9);
                    }

                }
            }
            return med;
        }
        catch 
        {
            return new Medicine();
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> UpdateAsync(long id, Medicine obj)
    {    
        try
        {
            await _connection.OpenAsync();

            string query = "update public.\"Medicines\" set " +
                          "\"MedCategory\" = @MedCategory,\"Name\" = @Name, \"Description\" = @Description, " +
                          "\"Price\" = @price, \"CreatedTime\" = @CreatedTime, \"EndTime\" = @EndTime, " +
                          "\"image_path\" = @image_path where \"MedId\" = @MedId";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@MedId", id);
                command.Parameters.AddWithValue("@MedCategory", obj.MedCategory);
                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Description", obj.Description);
                command.Parameters.AddWithValue("@Price", obj.Price);
                command.Parameters.AddWithValue("@CreatedTime", obj.CreatTime);
                command.Parameters.AddWithValue("@EndTime", obj.EndTime);
                command.Parameters.AddWithValue("@image_path", obj.image_path);
                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
