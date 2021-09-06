using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace VpnKillSwitch
{
    class DataBase
    {
        private static string DB_NAME = "ks.sqlite";
        public static DataBase db = new DataBase();

        private SQLiteConnection connection;

        public DataBase() {
            this.connection = new SQLiteConnection(DB_NAME);
            this.connection.CreateTables<Config, Path>();
        }

        // path store
        public void insertPath(string path) {
            connection.Insert(new Path
            {
                path = path
            }) ;
        }
        public bool removePath(string path) {
            bool ret = true;
            Path[] paths = connection.Table<Path>().Where(p => p.path == path).ToArray();

            foreach (Path p in paths) {
                ret = ret && connection.Delete(p) == 1;
            }
            return ret;
        }
        public string[] getPaths() {
            Path[] paths = connection.Table<Path>().ToArray();
            string[] ret = new string[paths.Length];

            for (int i = 0; i < paths.Length; i++) {
                ret[i] = paths[i].path;
            }

            return ret;
        }
        public bool isPathExists(string path) {
            return  connection.Table<Path>().Where(p => p.path == path).Count() != 0;
        }


        // config store
        public bool set(string key, string value) {
            return connection.InsertOrReplace(new Config { 
                key = key,
                value = value
            }) == 1;
        }
        public string get(string key, string def = null) {
            Config ret = connection.Table<Config>().Where(c => c.key == key).FirstOrDefault();
            return ret == null ? def : ret.value;
        }


        // data classes
        public class Config {
            [PrimaryKey]
            public string key { get; set; }
            public string value { get; set; }
        }
        public class Path {
            [PrimaryKey , AutoIncrement]
            public int id { get; set; }
            public string path { get; set; }
        }
    }
}
