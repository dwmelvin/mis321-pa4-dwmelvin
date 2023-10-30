namespace api.Models
{
    public class Exercise
    {
        public int ExerciseID {get; set;}
        public string ExerciseType {get; set;}
        public string ExerciseDuration {get; set;}
        public string ExerciseDate {get; set;}
        public bool Pinned {get; set;}
        public bool Delete {get; set;}
    }
}