using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RestoranWeb_ish
{
    public class Utility
    {
        SqlConnection conn = new SqlConnection();
        string wqbConfig = @"Data Source = KOMPAC\SQLEXPRESS; Initial Catalog = restoran; Integrated Security = True";
        SqlCommand comm = new SqlCommand();

        public int gostProvera(string email, string pass)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.gostEmail";

            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pass));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int gostInsert(string ime, string prezime, string telefon, string email, string pass)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.gostInsert";

            comm.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm.Parameters.Add(new SqlParameter("@telefon", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, telefon));
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pass));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int gostUpdate(string email, string pass)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.gostUpdate";

            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pass));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int gostDelete(string email)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.gostDelete";

            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int stoInsert(string kapacitet)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.stoInsert";

            comm.Parameters.Add(new SqlParameter("@kapacitet", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, kapacitet));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int stoDelete(int id)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.stoDelete";

            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int stoUpdate(int id, string kapacitet)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.stoUpdate";

            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm.Parameters.Add(new SqlParameter("@godina", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, kapacitet));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int terminInsert(string datum, string vreme)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.terminInsert";

            comm.Parameters.Add(new SqlParameter("@datum", SqlDbType.Date, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum));
            comm.Parameters.Add(new SqlParameter("@vreme", SqlDbType.Time, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vreme));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int terminUpdate(int id, string datum, string vreme)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.terminUpdate";

            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, id));
            comm.Parameters.Add(new SqlParameter("@datum", SqlDbType.Date, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum));
            comm.Parameters.Add(new SqlParameter("@vreme", SqlDbType.Time, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vreme));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int terminDelete(int id)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.terminDelete";

            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 32, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int rezervacijaInsert(int gost, int sto, int termin)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.rezervacijaInsert";

            comm.Parameters.Add(new SqlParameter("@gost", SqlDbType.Int, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, gost));
            comm.Parameters.Add(new SqlParameter("@sto", SqlDbType.Int, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sto));
            comm.Parameters.Add(new SqlParameter("@termin", SqlDbType.Int, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, termin));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int rezervacijaDelete(int id)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.rezervacijaDelete";

            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

        public int rezervacijaUpdate(int gost, int sto, int termin)
        {
            conn.ConnectionString = wqbConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.rezervacijaUpdate";

            comm.Parameters.Add(new SqlParameter("@gost", SqlDbType.Int, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, gost));
            comm.Parameters.Add(new SqlParameter("@sto", SqlDbType.Int, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sto));
            comm.Parameters.Add(new SqlParameter("@termin", SqlDbType.Int, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, termin));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }
            return rezultat;
        }

    }
}