using Npgsql;
using Pharmcy.Entities.Customers;
using Pharmcy.Interfaces.Customers;
using Pharmcy.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmcy.Repostories.Customers;

public class CustomerRepository :BaseRepository, ICustomerRepository
{
    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(Customer obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.\"Customer\"(\"FirstName\", \"LastName\", \"Age\", \"ContactAdd\", \"CreatedAt\", \"UpdatedAt\") VALUES (@FirstName,@LastName,@Age,@ContactAdd,@CreatedAt,@UpdatedAt);";
            
            await using ( var command = new NpgsqlCommand(query, _connection)) 
            {
                command.Parameters.AddWithValue("FirstName", obj.FirstName);
                command.Parameters.AddWithValue("LastName", obj.LastName);
                command.Parameters.AddWithValue("Age", obj.Age);
                command.Parameters.AddWithValue("ContactAdd", obj.ContactAdd);
                command.Parameters.AddWithValue("CreatedAt", obj.CreatedAT);
                command.Parameters.AddWithValue("UpdatedAt", obj.UpdatedAT);
                var dresult = await command.ExecuteNonQueryAsync();
                return dresult;
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
    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }
    public async Task<IList<Customer>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Customer>();
            string query = $"SELECT * FROM public.\"Customer\" ORDER BY \"CustID\" offset {(@params.PageNumber - 1) * @params.PageSize} limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query , _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while ( await reader.ReadAsync()) 
                    {
                        var cust = new Customer();
                        cust.CustID = reader.GetInt64(0);
                        cust.FirstName = reader.GetString(1);
                        cust.LastName = reader.GetString(2);
                        cust.Age = reader.GetInt32(3);
                        cust.ContactAdd = reader.GetString(4);
                        cust.CreatedAT = reader.GetDateTime(5);
                        cust.UpdatedAT = reader.GetDateTime(6);
                        list.Add(cust);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Customer>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public Task<Customer> GetASync(long id)
    {                                              
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Customer obj)
    {
        throw new System.NotImplementedException();
    }
}
