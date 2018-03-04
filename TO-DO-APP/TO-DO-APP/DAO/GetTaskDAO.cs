using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TO_DO_APP.Database;
using TO_DO_APP.Models;
using MySql.Data.MySqlClient;

namespace TO_DO_APP.DAO
{
    public class GetTaskDAO
    {
        public List<ToDoModel> GetAllTask(){
            List<ToDoModel> result = new List<ToDoModel>();
            var dbCon = DBConnection.Instance();

            if (dbCon.IsConnect())
            {
                string query = "SELECT TASK_ID,SUBJECT,DETAIL,STATUS FROM TASK_TO_DO";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToDoModel data = new ToDoModel();
                    data.Task_id = reader.GetString(0);
                    data.Subject = reader.GetString(1);
                    data.Detail = reader.GetString(2);
                    data.Status = reader.GetString(3);
                    result.Add(data);
                }
                dbCon.Close();
            }
            return result;
        }

        public ToDoModel GetSingleTask(string taskID)
        {
            var dbCon = DBConnection.Instance();
            ToDoModel data = new ToDoModel();
            if (dbCon.IsConnect())
            {
                string query = "SELECT TASK_ID,SUBJECT,DETAIL,STATUS FROM TASK_TO_DO WHERE TASK_ID = '" + taskID +"'" ;
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data.Task_id = reader.GetString(0);
                    data.Subject = reader.GetString(1);
                    data.Detail = reader.GetString(2);
                    data.Status = reader.GetString(3);
                }
                dbCon.Close();
            }
            return data;
        }

        public bool AddTask(ToDoModel dataInsert)
        {
            var dbCon = DBConnection.Instance();
            ToDoModel data = new ToDoModel();
            bool result = false;
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO TASK_TO_DO  (SUBJECT,DETAIL,STATUS) VALUES('"+ dataInsert.Subject +"','"+ dataInsert.Detail +"','"+ dataInsert.Status +"')";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                dbCon.Close();
            }
            return result;
        }

        public bool EditTask(ToDoModel dataEdit)
        {
            var dbCon = DBConnection.Instance();
            bool result = false;
            if (dbCon.IsConnect())
            {
                string query = "UPDATE TASK_TO_DO  SET SUBJECT = '" + dataEdit.Subject + "', DETAIL = '" + dataEdit.Detail + "', STATUS = '" + dataEdit.Status + "' WHERE TASK_ID = '" + dataEdit.Task_id + "'";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                dbCon.Close();
            }
            return result;
        }

        public bool ChangeStatusTask(ToDoModel statusChange)
        {
            var dbCon = DBConnection.Instance();
            bool result = false;
            if (dbCon.IsConnect())
            {
                string query = "UPDATE TASK_TO_DO  SET STATUS = '" + statusChange.Status + "' WHERE TASK_ID = '" + statusChange.Task_id + "'";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                dbCon.Close();
            }
            return result;
        }

        public bool DeleteTask(string taskID)
        {
            var dbCon = DBConnection.Instance();
            bool result = false;
            if (dbCon.IsConnect())
            {
                string query = "DELETE FROM TASK_TO_DO WHERE TASK_ID = '" + taskID + "'";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                dbCon.Close();
            }
            return result;
        }
    }
} 