using System;
using System.Collections.Generic;
using System.Text;
using AppMinhasCompras.Model;
using System.Threading.Tasks;
using SQLite;

namespace AppMinhasCompras.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }


        public void Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=? Preco=? WHERE id = ?";

            _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);

        }

        /*public Task<Produto> getBYId(int id)
        {
            return new Produto();
        }*/

        public Task<List<Produto>> GetALL()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
    }
}
