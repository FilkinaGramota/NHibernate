using System;
namespace Demo.Entities
{
    public class Score
    {
        public double ShortProgram { get; protected set; }
        public double FreeSkating { get; protected set; }
        public double TotalScore { get; protected set; }

        public Score()
        {
            ShortProgram = 0;
            FreeSkating = 0;
            TotalScore = 0;
        }
  
        public Score (double ShortProgram, double FreeSkating)
        {
            this.ShortProgram = ShortProgram;
            this.FreeSkating = FreeSkating;
            this.TotalScore = ShortProgram + FreeSkating;
        }

        public bool Equals(Score other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return this.TotalScore == other.TotalScore;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Score);
        }

        public override string ToString()
        {
            return string.Format("SP: {0}  FS: {1}  Total: {2}\n", ShortProgram, FreeSkating, TotalScore);
        }
    }
}
