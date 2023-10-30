using MySql.Data.MySqlClient;
using System.Collections.Generic;
using api;
using api.Models;

namespace api.Models
{
    public class ExerciseUtility
    {
        public List<Exercise> GetAllExercises()
        {
            ConnectionString db = new ConnectionString();
            using var con = new MySqlConnection(db.cs);
            con.Open();
            var workoutList = new List<Exercise>();
            string stm = "SELECT * FROM exercise";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                var exercise = new Exercise  
                {
                    ExerciseID = rdr.GetInt32("exerciseid"),
                    ExerciseType = rdr.GetString("exercisetype"),
                    ExerciseDuration = rdr.GetString("exerciseduration"),
                    ExerciseDate = rdr.GetString("exercisedate"),
                    Pinned = rdr.GetBoolean("pinned"),
                    Delete = rdr.GetBoolean("deleted")
                };
                workoutList.Add(exercise);
            }
            con.Close();
            return workoutList;
        }
        public void AddExercise(Exercise exercise)
        {
            ConnectionString db = new ConnectionString();
            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = @"INSERT INTO exercise (exercisetype, exerciseduration, exercisedate, pinned, deleted) VALUES (@exercisetype, @exerciseduration, @exercisedate, @pinned, @deleted)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@exercisetype", exercise.ExerciseType);
            cmd.Parameters.AddWithValue("@exerciseduration", exercise.ExerciseDuration);
            cmd.Parameters.AddWithValue("@exercisedate", exercise.ExerciseDate);
            cmd.Parameters.AddWithValue("@pinned", exercise.Pinned);
            cmd.Parameters.AddWithValue("@deleted", exercise.Delete);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void DeleteExercise(Exercise exercise)
        {
            ConnectionString db = new ConnectionString();
            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = @"UPDATE exercise SET deleted = @deleted WHERE exerciseid = @ExerciseID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ExerciseID", exercise.ExerciseID);
            cmd.Parameters.AddWithValue("@deleted", exercise.Delete);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void PinExercise(Exercise exercise)
        {
            ConnectionString db = new ConnectionString();
            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = @"UPDATE exercise SET pinned = @pinned WHERE exerciseid = @ExerciseID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ExerciseID", exercise.ExerciseID);
            cmd.Parameters.AddWithValue("@pinned", !exercise.Pinned);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
