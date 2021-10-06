using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text;
using System.Linq;
using Client.Models;

namespace Client.Controls
{    
    public class Record
    {
        public int UserId { get; set; }

        public string Type { get; set; }

        public int X  { get; set; }

        public int Y { get; set; }

        public DateTime Time { get; set; }

        public Record(string Type, int X, int Y, DateTime Time)
        {
            this.Type = Type;
            this.X = X;
            this.Y = Y;
            this.Time = Time;
            this.UserId = AuthentificatedUser.Id;
        }
    }

    public class RecordList
    {
        public RecordList()
        {
            Records = new ObservableCollection<Record>();
        }

        public void ClearRecords()
        {
            Records.Clear();
        }

        public ObservableCollection<Record> TypeSort()
        {
            Records  = new ObservableCollection<Record>(Records.OrderBy(e => e.Type));
            return Records;
        }

        public ObservableCollection<Record> TimeSort()
        {
            Records = new ObservableCollection<Record>(Records.OrderByDescending(e => e.Time));
            return Records;
        }

        public ObservableCollection<Record>  Records{ get; private set; }        
    }
}
