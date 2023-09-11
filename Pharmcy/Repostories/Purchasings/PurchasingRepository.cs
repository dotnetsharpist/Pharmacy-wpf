using Microsoft.VisualBasic;
using Npgsql;
using Pharmcy.Entities.Medicines;
using Pharmcy.Entities.Purchasing;
using Pharmcy.Interfaces.Purchasings;
using Pharmcy.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Pharmcy.Repostories.Purchasings
{
    public class PurchasingRepository : BaseRepository, IPurchasingRepository
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Purchasing obj)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.\"Purchasing\"(\"Amount\",  \"PurName\", \"image_path\", \"description\")  " +
                    "VALUES (@Amount, @PurName, @image_path, @description);";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Amount", obj.Amount);
                    command.Parameters.AddWithValue("@PurName", obj.PurName);
                    command.Parameters.AddWithValue("@image_path", obj.image_path);
                    command.Parameters.AddWithValue("@description", obj.Description);
                    var dbreuslt = await command.ExecuteNonQueryAsync();
                    return dbreuslt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally { await _connection.CloseAsync(); }
        }
        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }
        public async Task<IList<Purchasing>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                var list = new List<Purchasing>();
                string query = $"SELECT * FROM public.\"Purchasing\" ORDER BY \"PurchaseId\" offset {(@params.PageNumber - 1) * @params.PageSize} limit {@params.PageSize}";
                await using (var command = new NpgsqlCommand(query,_connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            var pur = new Purchasing();
                            pur.PurchaseId = reader.GetInt64(0);
                            pur.CustId = reader.GetInt64(1);
                            pur.MedId = reader.GetInt64(2);
                            pur.Amount = reader.GetInt32(3);
                            pur.Date = reader.GetDateTime(4);
                            pur.CreatedAT = reader.GetDateTime(5);
                            pur.UpdatedAT = reader.GetDateTime(6);
                            pur.PurName = reader.GetString(7);
                            pur.image_path = reader.GetString(8);
                            pur.Description = reader.GetString(9);
                            list.Add(pur);
                        }
                    }
                }
                return list;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Purchasing>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
        public async Task<Purchasing> GetASync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"Select * from public.\"Purchasing\" order by \"PurchaseId\" where Name ilike '\"name\"'";
                var pur = new Purchasing();
                await using (var command = new NpgsqlCommand(query,_connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            pur.PurchaseId = reader.GetInt64(0);
                            pur.CustId = reader.GetInt64(1);
                            pur.MedId = reader.GetInt64(2);
                            pur.Amount = reader.GetInt32(3);
                            pur.Date = reader.GetDateTime(4);
                            pur.CreatedAT = reader.GetDateTime(5);
                            pur.UpdatedAT = reader.GetDateTime(6);
                            pur.PurName = reader.GetString(7);
                            pur.image_path = reader.GetString(8);
                            pur.Description = reader.GetString(9);

                        }
                    }
                }
                return pur;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Purchasing();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
        public Task<int> UpdateAsync(long id, Purchasing obj)
        {
            throw new NotImplementedException();
        }
    }
}
