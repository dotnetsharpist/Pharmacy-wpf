using Npgsql;
using Pharmcy.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmcy.Repostories;

public abstract class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        _connection = new NpgsqlConnection(DBConstans.DB_CONNECTIONSTRING);
    }
}
