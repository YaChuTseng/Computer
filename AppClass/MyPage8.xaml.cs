using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace AppClass
{
    public partial class MyPage8 : ContentPage
    {
        public MyPage8()
        {
            InitializeComponent();

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = System.IO.Path.Combine(path, "..", "Library", "sql.db");

            SQLiteConnection conn = new SQLiteConnection(path);
            conn.CreateTable<MyTable>();
            conn.Insert(new MyTable()
            {
                Id = Guid.NewGuid().ToString(),
                Value = "Hello"
            });

            var result = conn.Table<MyTable>().Where(c => c.Value == "Hello").ToList();
        }

        [Table("My")]

        public class MyTable
        {
            [Column("IDKey")]
            [SQLite.PrimaryKey]
            public string Id { get; set; }

            [SQLite.Ignore]

            public string Value { get; set; }
        }
    }
}
