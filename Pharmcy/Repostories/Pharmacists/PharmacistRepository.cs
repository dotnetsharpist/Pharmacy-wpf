using Npgsql;
using Pharmcy.Interfaces.Pharmacists;
using Pharmcy.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmcy.Entities.Pharmacists;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;


namespace Pharmcy.Repostories.Pharmacists;
public class PharmacistRepository : BaseRepository, IPharmacistRepository
{
    public PharmacistRepository()
    {
        
    }
    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
    public async Task<int> CreateAsync(Pharmacist obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.\"Pharmacist\"(\"FirstName\", \"LastName\", \"PharEmail\", \"gender\", \"birth_date\", \"image_path\") " +
                                                    "VALUES (@FirstName,@LastName,@PharEmail,@gender,@birth_date,@image_path);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@FirstName", obj.FirstName);
                command.Parameters.AddWithValue("@LastName", obj.LastName);
                command.Parameters.AddWithValue("@PharEmail", obj.PharEmail);
                command.Parameters.AddWithValue("@gender", obj.gender);
                command.Parameters.AddWithValue("@birth_date", obj.birth_date);
                command.Parameters.AddWithValue("@image_path", obj.image_path);
                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch(Exception ex)
        {
            //MessageBox.Show(ex.Message.ToString());
            MessageBox.Show(ex.Message);
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
            string query = $"delete from public.\"Pharmacist\" where \"PharId\"={id};";
            await using (var command = new NpgsqlCommand(query,_connection))
            {
                int natija = await command.ExecuteNonQueryAsync();
                return natija;
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Pharmacist>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Pharmacist>();
            string query = $"SELECT * FROM public.\"Pharmacist\" ORDER BY \"PharId\" offset {(@params.PageNumber - 1) * @params.PageSize} limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query,_connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while ( await reader.ReadAsync())
                    {
                        var ph = new Pharmacist();
                        ph.PharId = reader.GetInt64(0);
                        ph.FirstName = reader.GetString(1);
                        ph.LastName = reader.GetString(2);
                        ph.PharEmail = reader.GetString(3);
                        ph.CreatedAT = reader.GetDateTime(4);
                        ph.UpdatedAT = reader.GetDateTime(5);
                        //ph.salt = reader.GetString(6);
                        ph.gender = reader.GetString(7);
                        ph.birth_date = reader.GetDateTime(8);
                        ph.image_path = reader.GetString(9);
                        list.Add(ph);
                    }

                }
            }
            return list;
        }
        catch
        {
            return new List<Pharmacist>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public Task<Pharmacist> GetASync(long id)
    {
        throw new NotImplementedException();
    }
    public async Task<int> UpdateAsync(long id,Pharmacist obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.\"Pharmacist\" SET " +
                "\"FirstName\" = @FirstName, \"LastName\" = @LastName, \"PharEmail\" = @PharEmail, \"gender\" = @gender, \"birth_date\" = @birth_date, \"image_path\" = @image_path " +
                "WHERE \"PharId\" = @PharId";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@PharId", id);
                command.Parameters.AddWithValue("@FirstName", obj.FirstName);
                command.Parameters.AddWithValue("@LastName", obj.LastName);
                command.Parameters.AddWithValue("@PharEmail", obj.PharEmail);
                command.Parameters.AddWithValue("@gender", obj.gender);
                command.Parameters.AddWithValue("@birth_date", obj.birth_date);
                command.Parameters.AddWithValue("@image_path", obj.image_path);
                var dbresult = await command.ExecuteNonQueryAsync();
                return dbresult;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }
}
