using System;
using System.Collections.Generic;
using System.Text;

namespace CatShelter.Domain.CatEvidence
{
    public class CatRecord 
    {
        public virtual DateTime Date { get; protected set; }
        public virtual string Text { get; protected set; }
        public virtual Cat Cat { get; protected set; }

        protected CatRecord()
        {
            
        }

        public CatRecord(Cat cat, DateTime date, string text)
        {
            Cat = cat;
            Date = date;
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(Date)}: {Date}, {nameof(Text)}: {Text}";
        }
    }
}
