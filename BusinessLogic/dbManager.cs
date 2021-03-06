﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    // SQLite documentation: http://www.sqlite.org .
    public class dbManager
    {
        private string dbName;
        private SQLiteConnection dbConnection;

        // Constructor, create automatically a connection to the definied db.
        public dbManager(string dbName)
        {
            this.dbName = dbName;

            bool dbExisted = true;
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                dbExisted = false;
            }

            dbConnection = new SQLiteConnection("Data Source=" + dbName + ";Version=3;foreign keys=true;");
            dbConnection.Open();

            if (!dbExisted)
            {
                // Table name: field names
                // files: id, title, author, year, doi, favorite, vdirs_id, type, note, location, added, rread
                // file_tag: id, files_id, tags_id
                // tags: id, name
                // vdirs: id, name, parentdir_id
                // settings: id, name, value
                // Use http://sqlitebrowser.org/ program to watch how it looks like the db structure.

                SQLiteCommand sqlc = new SQLiteCommand("CREATE TABLE 'files' ('id' INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE, 'title' VARCHAR NOT NULL, 'author' VARCHAR NULL DEFAULT NULL, 'year' INTEGER NULL DEFAULT NULL, 'DOI' VARCHAR NULL DEFAULT NULL, 'vdirs_id' INTEGER NULL DEFAULT NULL REFERENCES vdirs(id) ON UPDATE RESTRICT ON DELETE RESTRICT, 'favorite' BOOL DEFAULT 0, 'type' VARCHAR NOT NULL, 'note' VARCHAR NULL DEFAULT NULL, 'location' VARCHAR NOT NULL, 'added' VARCHAR DEFAULT CURRENT_TIMESTAMP, 'rread' VARCHAR NULL DEFAULT NULL)", dbConnection);
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("CREATE TABLE 'tags' ('id' INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE, 'name' VARCHAR NOT NULL)", dbConnection);
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("CREATE TABLE 'file_tag' ('id' INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE, 'files_id' INTEGER NOT NULL REFERENCES files(id) ON UPDATE RESTRICT ON DELETE RESTRICT, 'tags_id' INTEGER NOT NULL REFERENCES tags(id) ON UPDATE RESTRICT ON DELETE RESTRICT)", dbConnection);
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("CREATE TABLE 'vdirs' ('id' INTEGER PRIMARY KEY  AUTOINCREMENT NOT NULL  UNIQUE, 'name' VARCHAR NOT NULL, 'parentdir_id' INTEGER NULL DEFAULT NULL REFERENCES vdirs(id) ON UPDATE RESTRICT ON DELETE RESTRICT)", dbConnection);
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("CREATE TABLE 'settings' ('id' INTEGER PRIMARY KEY  AUTOINCREMENT NOT NULL  UNIQUE, 'name' VARCHAR NOT NULL, 'value' VARCHAR NOT NULL)", dbConnection);
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand(@"CREATE INDEX ft_tag_id_file_id
                        on file_tag (files_id, tags_id);
                        CREATE INDEX ft_file_id
                        on file_tag (files_id);
                        CREATE INDEX ft_tag_id
                        on file_tag (tags_id);
                        CREATE INDEX v_parentdir_id
                        on vdirs (parentdir_id);
                        CREATE INDEX v_name
                        on vdirs (name);
                        CREATE INDEX t_name
                        on tags (name);
                        CREATE INDEX f_title
                        on files (title);
                        CREATE INDEX f_author
                        on files (author);
                        CREATE INDEX f_year
                        on files ('year');
                        CREATE INDEX f_doi
                        on files (doi);
                        CREATE INDEX f_vdirs_id
                        on files (vdirs_id);
                        CREATE INDEX f_favorite
                        on files (favorite);
                        CREATE INDEX f_type
                        on files (type);
                        CREATE INDEX f_location
                        on files (location);
                        CREATE INDEX f_added
                        on files (added);
                        CREATE INDEX f_rread
                        on files (rread);", dbConnection);
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("INSERT INTO settings ('id', 'name', 'value') VALUES (1, $name, $value)", dbConnection);
                sqlc.Parameters.AddWithValue("$name", "Document extensions");
                sqlc.Parameters.AddWithValue("$value", "doc,docx,xls,xlsx,pdf,txt,htm,html");
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("INSERT INTO settings ('id', 'name', 'value') VALUES (2, $name, $value)", dbConnection);
                sqlc.Parameters.AddWithValue("$name", "Audio extensions");
                sqlc.Parameters.AddWithValue("$value", "jpg,jpeg,bmp,png,gif");
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("INSERT INTO settings ('id', 'name', 'value') VALUES (3, $name, $value)", dbConnection);
                sqlc.Parameters.AddWithValue("$name", "Audio extensions");
                sqlc.Parameters.AddWithValue("$value", "mp3,flac,aac,ac3,wav,ogg,wma,mid");
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("INSERT INTO settings ('id', 'name', 'value') VALUES (4, $name, $value)", dbConnection);
                sqlc.Parameters.AddWithValue("$name", "Video extensions");
                sqlc.Parameters.AddWithValue("$value", "mkv,wmv,mp4,flv,3gp,avi,divx,mpg,mpeg");
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("INSERT INTO settings ('id', 'name', 'value') VALUES (5, $name, $value)", dbConnection);
                sqlc.Parameters.AddWithValue("$name", "Executeable extensions");
                sqlc.Parameters.AddWithValue("$value", "exe,msi,com");
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("INSERT INTO settings ('id', 'name', 'value') VALUES (6, $name, $value)", dbConnection);
                sqlc.Parameters.AddWithValue("$name", "Custom extensions");
                sqlc.Parameters.AddWithValue("$value", "");
                sqlc.ExecuteNonQuery();
                sqlc = new SQLiteCommand("INSERT INTO settings ('id', 'name', 'value') VALUES (7, $name, $value)", dbConnection);
                sqlc.Parameters.AddWithValue("$name", "Selected file extensions");
                sqlc.Parameters.AddWithValue("$value", "1");
                sqlc.ExecuteNonQuery();
            }

            try
            {
                SQLiteCommand sqlc = new SQLiteCommand("pragma schema_version;", dbConnection);
                SQLiteDataReader sqldr = sqlc.ExecuteReader();
                sqldr.Read();
            }
            catch (SQLiteException e)
            {
                throw e;
            }
        }

        // Close db conn. use when you exit from the app.
        public void closeDbConn()
        {
            dbConnection.Close();
        }

        // Open db conn.
        public void openDbConn()
        {
            dbConnection.Open();
        }

        // Returns a list with all Files record.
        public List<Files> getAllFiles()
        {
            List<Files> files = new List<Files>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
	                GROUP BY f.id", dbConnection);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Returns a list with all receantly added Files record (past 3 days).
        public List<Files> getAllFilesReceantlyAdded()
        {
            // Date -3 days ago.
            DateTime dt = DateTime.Now.AddDays(-3d);

            List<Files> files = new List<Files>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
                    WHERE f.added >= $added
	                GROUP BY f.id", dbConnection);
            sqlc.Parameters.AddWithValue("$added", dt.ToString("yyyy-MM-dd HH:mm:ss"));
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Returns a list with all receantly read Files record (past 3 days).
        public List<Files> getAllFilesReceantlyRead()
        {
            // Date -3 days ago.
            DateTime dt = DateTime.Now.AddDays(-3d);

            List<Files> files = new List<Files>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
                    WHERE f.rread >= $rread
	                GROUP BY f.id", dbConnection);
            sqlc.Parameters.AddWithValue("$rread", dt.ToString("yyyy-MM-dd HH:mm:ss"));
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Returns a list with all favorite Files record (past 3 days).
        public List<Files> getAllFilesFavorite()
        {
            List<Files> files = new List<Files>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
                    WHERE f.favorite = 1
	                GROUP BY f.id", dbConnection);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Returns a list those files which are not in any custom vdir.
        public List<Files> getAllFilesWhichAreNotInADir()
        {
            List<Files> files = new List<Files>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
                    WHERE f.'vdirs_id' is NULL
	                GROUP BY f.id", dbConnection);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Returns a list those Files which are in the defined vdir.
        public List<Files> getAllFilesFromDir(int dirId)
        {
            List<Files> files = new List<Files>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
                    WHERE f.'vdirs_id' = $vdirs_id
	                GROUP BY f.id", dbConnection);
            sqlc.Parameters.AddWithValue("$vdirs_id", dirId);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Returns a list those Files which has the defined tag.
        public List<Files> getAllFilesByTag(int tagId)
        {
            List<Files> files = new List<Files>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
                    WHERE ft.'tags_id' = $tags_id
	                GROUP BY f.id", dbConnection);
            sqlc.Parameters.AddWithValue("$tags_id", tagId);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Returns a list those Files which has the defined Author name.
        public List<Files> getAllFilesByAuthors(string authorName)
        {
            List<Files> files = new List<Files>();

            SQLiteCommand sqlc;
            if (authorName.Equals("(No author name)"))
            {
                sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
                    WHERE f.'author' IS NULL or f.'author' = '' or f.'author' = '(No author name)'
	                GROUP BY f.id", dbConnection);
            }
            else
            {
                sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
                    WHERE f.'author' = $author
	                GROUP BY f.id", dbConnection);
                sqlc.Parameters.AddWithValue("$author", authorName);
            }
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Get allowed file extensions by typeId.
        public string getFileExtensions(int typeId)
        {
            SQLiteCommand sqlc = new SQLiteCommand("SELECT * FROM settings WHERE id = $id", dbConnection);
            sqlc.Parameters.AddWithValue("$id", typeId);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            sqldr.Read();

            return Convert.ToString(sqldr["value"]);
        }

        // Gets the selected file type.
        public int getSelectedFileTypeExtensions()
        {
            SQLiteCommand sqlc = new SQLiteCommand("SELECT * FROM settings WHERE id = 7", dbConnection);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            sqldr.Read();

            return Convert.ToInt32(sqldr["value"]);
        }

        // Sets the selected file type.
        public void setSelectedFileTypeExtensions(int typeId)
        {
            SQLiteCommand sqlc = new SQLiteCommand("UPDATE settings SET value = $value WHERE id = 7", dbConnection);
            sqlc.Parameters.AddWithValue("$value", typeId);
            sqlc.ExecuteNonQuery();
        }

        // Sets the custom file extensions.
        public void setCustomFileExtensions(string customExtensions)
        {
            SQLiteCommand sqlc = new SQLiteCommand("UPDATE settings SET value = $value WHERE id = 6", dbConnection);
            sqlc.Parameters.AddWithValue("$value", customExtensions);
            sqlc.ExecuteNonQuery();
        }

        // Add multiple files.
        public void addFiles(string[] filePaths)
        {
            using (var transaction = dbConnection.BeginTransaction())
            {
                using (var cmd = dbConnection.CreateCommand())
                {
                    using (var cmd2 = dbConnection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO files (id, title, author, year, doi, favorite, type, note, location, rread) VALUES (NULL, $title, NULL, NULL, NULL, 0, $type, NULL, $location, NULL);";
                        cmd2.CommandText = "SELECT count(*) AS db FROM files WHERE location = $location";

                        foreach (var filePath in filePaths)
                        {
                            cmd2.Parameters.AddWithValue("$location", filePath);
                            SQLiteDataReader sqldr = cmd2.ExecuteReader();
                            sqldr.Read();

                            if (Convert.ToInt32(sqldr["db"]) == 0)
                            {
                                cmd.Parameters.AddWithValue("$title", Path.GetFileNameWithoutExtension(filePath));
                                cmd.Parameters.AddWithValue("$type", Path.GetExtension(filePath));
                                cmd.Parameters.AddWithValue("$location", filePath);
                                cmd.ExecuteNonQuery(); 
                            }
                            sqldr.Dispose();
                        } 
                    }
                }
                transaction.Commit();
            }
        }

        // Delete only one File.
        public void removeFiles(string id)
        {
            if (!id.Equals(""))
            {
                SQLiteCommand sqlc2 = new SQLiteCommand("DELETE FROM file_tag WHERE files_id = $files_id;", dbConnection);
                sqlc2.Parameters.AddWithValue("$files_id", id);
                sqlc2.ExecuteNonQuery();

                SQLiteCommand sqlc = new SQLiteCommand("DELETE FROM files WHERE id = $id;", dbConnection);
                sqlc.Parameters.AddWithValue("$id", id);
                sqlc.ExecuteNonQuery();

                // Search and delete those records which doesn't have pair in file_tag table form tags table.
                SQLiteCommand sqlcd = new SQLiteCommand(@"DELETE  
                            FROM    tags
                            WHERE   id NOT IN
                                    (
                                    SELECT  tags_id
                                    FROM    file_tag
                                    );", dbConnection);
                sqlcd.ExecuteNonQuery();
            }
        }

        // Delete multiple File.
        public void removeFiles(string[] ids)
        {
            if (ids.Length != 0)
            {
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var cmd = dbConnection.CreateCommand())
                    {
                        using (var cmd2 = dbConnection.CreateCommand())
                        {
                            cmd2.CommandText = "DELETE FROM file_tag WHERE files_id = $files_id;";
                            cmd.CommandText = "DELETE FROM files WHERE id = $id;";

                            foreach (string id in ids)
                            {
                                cmd2.Parameters.AddWithValue("$files_id", id);
                                cmd2.ExecuteNonQuery();
                                cmd.Parameters.AddWithValue("$id", id);
                                cmd.ExecuteNonQuery();
                            }


                            // Search and delete those records which doesn't have pair in file_tag table form tags table.
                            SQLiteCommand sqlcd = new SQLiteCommand(@"DELETE  
                            FROM    tags
                            WHERE   id NOT IN
                                    (
                                    SELECT  tags_id
                                    FROM    file_tag
                                    );", dbConnection);
                            sqlcd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        // Search a string everywhere except virtual dirs string.
        public List<Files> simpleSearch(string searchedString)
        {
            List<Files> files = new List<Files>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT f.*, group_concat(t.name, ', ') AS tags_name FROM files f 
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'
	                WHERE f.'title' LIKE $searchString OR 
	                f.'author' LIKE $searchString OR 
	                f.'year' LIKE $searchString OR 
	                f.'doi' LIKE $searchString OR 
	                f.'favorite' LIKE $searchString OR
	                f.'vdirs_id' LIKE $searchString OR 
	                f.'type' LIKE $searchString OR 
	                f.'note' LIKE $searchString OR 
	                f.'location' LIKE $searchString OR 
	                f.'added' LIKE $searchString OR 
	                f.'rread' LIKE $searchString OR
	                t.'name' LIKE $searchString
	                GROUP BY f.id", dbConnection);
            sqlc.Parameters.AddWithValue("$searchString", "%" + searchedString + "%");
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }

        // Set recently read parameter.
        public void setReceantlyReadNow(int id)
        {
            // Actual date.
            DateTime dt = DateTime.Now;

            SQLiteCommand sqlc = new SQLiteCommand(@"UPDATE files SET rread = $rread WHERE id = $id", dbConnection);
            sqlc.Parameters.AddWithValue("$rread", dt.ToString("yyyy-MM-dd HH:mm:ss"));
            sqlc.Parameters.AddWithValue("$id", id);
            sqlc.ExecuteNonQuery();
        }

        // Set new path/location parameter.
        public void setNewPath(int id, string path)
        {
            SQLiteCommand sqlc = new SQLiteCommand(@"UPDATE files SET location = $location WHERE id = $id", dbConnection);
            sqlc.Parameters.AddWithValue("$location", path);
            sqlc.Parameters.AddWithValue("$id", id);
            sqlc.ExecuteNonQuery();
        }

        // Returns a VDir tree from the db.
        public VDirs getVDirs()
        {
            VDirs returnVdir = new VDirs(-1, "root");

            SQLiteCommand sqlc = new SQLiteCommand("SELECT * FROM vdirs WHERE parentdir_id IS NULL", dbConnection);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                returnVdir.addNewChild(getVDirsById(Convert.ToInt32(sqldr["id"])));
            }

            return returnVdir;
        }

        // Get VDirs by main ID.
        public VDirs getVDirsById(int id)
        {
            VDirs returnVdir = null;

            if (id > 0)
            {
                List<VDirs> tmpVdirs = new List<VDirs>();
                int firstId = -2;

                SQLiteCommand sqlc = new SQLiteCommand(@"WITH vdirsCTE AS (
                        SELECT *,0 AS steps
                        FROM vdirs
                        WHERE id = $id
    
                        UNION ALL
  
                        SELECT mgr.*, usr.steps + 1 AS steps
                        FROM vdirsCTE AS usr
                        INNER JOIN vdirs AS mgr
                            ON usr.id = mgr.parentdir_id
                    )
                    SELECT * FROM vdirsCTE AS u;", dbConnection);
                sqlc.Parameters.AddWithValue("$id", id);
                SQLiteDataReader sqldr = sqlc.ExecuteReader();
                while (sqldr.Read())
                {
                    tmpVdirs.Add(new VDirs(
                                Convert.ToInt32(sqldr["id"]),
                                Convert.ToString(sqldr["name"]),
                                (sqldr["parentdir_id"] == System.DBNull.Value ? -1 : Convert.ToInt32(sqldr["parentdir_id"]))
                            ));
                    if (firstId == -2)
                    {
                        firstId = (sqldr["parentdir_id"] == System.DBNull.Value ? -1 : Convert.ToInt32(sqldr["parentdir_id"]));
                    }
                }

                List<int> idEnd = new List<int>();
                sqlc = new SQLiteCommand(@"SELECT a.* FROM vdirs a WHERE not EXISTS(SELECT 1 FROM vdirs b WHERE a.id=b.parentdir_id)", dbConnection);
                sqldr = sqlc.ExecuteReader();
                while (sqldr.Read())
                {
                    idEnd.Add(Convert.ToInt32(sqldr["id"]));
                }

                returnVdir = recursiveBuildVDirs(ref tmpVdirs, ref idEnd, firstId);
            }

            return returnVdir;
        }

        // Generate tree object in recursive mode.
        private VDirs recursiveBuildVDirs(ref List<VDirs> treeList, ref List<int> idEnd, int actualId)
        {
            int index = idEnd.FindIndex(a => a == actualId);
            if (treeList.Count == 0 || index > 0)
            {
                return null;
            }
            else
            {
                VDirs tmp = null;
                VDirs tmp2 = null;

                foreach (VDirs item in treeList)
                {
                    if (item.ParentId == actualId)
                    {
                        tmp = new VDirs(item.Id, item.Name, item.ParentId);
                        tmp2 = item;
                        break;
                    }
                }

                if (tmp2 != null)
                {
                    treeList.Remove(tmp2);
                }

                if (tmp != null)
                {
                    VDirs tmp3 = null;
                    do
                    {
                        tmp3 = recursiveBuildVDirs(ref treeList, ref idEnd, tmp.Id);
                        if (tmp3 != null)
                        {
                            tmp.addNewChild(tmp3);
                        }
                    } while (tmp3 != null);
                }

                return tmp;
            }
        }

        // Add new vdir the the selected place.
        public void addVdirs(int mainID, string newDirName)
        {
            SQLiteCommand sqlc = new SQLiteCommand(@"INSERT INTO vdirs (name, parentdir_id) VALUES ($name, $parentdir_id)", dbConnection);
            sqlc.Parameters.AddWithValue("$name", newDirName);
            sqlc.Parameters.AddWithValue("$parentdir_id", (mainID == -1 ? null : mainID.ToString()));
            sqlc.ExecuteNonQuery();
        }

        // Moves a vdir into another.
        public void moveVdirs(int whichId, int newSubId)
        {
            SQLiteCommand sqlc = new SQLiteCommand(@"UPDATE vdirs SET parentdir_id = $parentdir_id WHERE id = $id", dbConnection);
            sqlc.Parameters.AddWithValue("$id", whichId);
            sqlc.Parameters.AddWithValue("$parentdir_id", (newSubId == -1 ? null : newSubId.ToString()));
            sqlc.ExecuteNonQuery();
        }

        // Rename a vdir into another.
        public void renameVdirs(int id, string newName)
        {
            SQLiteCommand sqlc = new SQLiteCommand(@"UPDATE vdirs SET name = $name WHERE id = $id", dbConnection);
            sqlc.Parameters.AddWithValue("$id", id);
            sqlc.Parameters.AddWithValue("$name", newName);
            sqlc.ExecuteNonQuery();
        }

        // Remove selected vdir and his all child.
        public void removeVdirs(int removeableId)
        {
            using (var transaction = dbConnection.BeginTransaction())
            {
                SQLiteCommand sqlc = new SQLiteCommand(@"WITH vdirsCTE AS (
                        SELECT *,0 AS steps
                        FROM vdirs
                        WHERE id = $id
    
                        UNION ALL
  
                        SELECT mgr.*, usr.steps + 1 AS steps
                        FROM vdirsCTE AS usr
                        INNER JOIN vdirs AS mgr
                            ON usr.id = mgr.parentdir_id
                    )
                    SELECT * FROM vdirsCTE AS u ORDER BY steps DESC;", dbConnection);
                sqlc.Parameters.AddWithValue("$id", removeableId);
                SQLiteDataReader sqldr = sqlc.ExecuteReader();
                using (var cmd = dbConnection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE files SET vdirs_id = NULL WHERE vdirs_id = $vdirs_id";
                    using (var cmd2 = dbConnection.CreateCommand())
                    {
                        cmd2.CommandText = "DELETE FROM vdirs WHERE id = $id;";

                        while (sqldr.Read())
                        {
                            cmd.Parameters.AddWithValue("$vdirs_id", Convert.ToString(sqldr["id"]));
                            cmd.ExecuteNonQuery();
                            cmd2.Parameters.AddWithValue("$id", Convert.ToString(sqldr["id"]));
                            cmd2.ExecuteNonQuery();
                        }
                    }
                }
                transaction.Commit();
            }
        }

        // Removes all vdirs.
        public void removeAllVdirs()
        {
            SQLiteCommand sqlc = new SQLiteCommand(@"DELETE FROM vdirs;", dbConnection);
            sqlc.ExecuteNonQuery();
        }

        // Set file to favorite or not.
        public void toggleToFavorite(int id, bool isFavorite)
        {
            SQLiteCommand sqlc = new SQLiteCommand(@"UPDATE files SET favorite = $favorite WHERE id = $id", dbConnection);
            sqlc.Parameters.AddWithValue("$id", id);
            sqlc.Parameters.AddWithValue("$favorite", isFavorite);
            sqlc.ExecuteNonQuery();
        }

        // Move file to directory
        public void moveFileToDir(int fileId, int dirId)
        {
            SQLiteCommand sqlc = new SQLiteCommand(@"UPDATE files SET vdirs_id = $vdirs_id WHERE id = $id", dbConnection);
            sqlc.Parameters.AddWithValue("$id", fileId);
            sqlc.Parameters.AddWithValue("$vdirs_id", (dirId == -1 ? null : dirId.ToString()));
            sqlc.ExecuteNonQuery();
        }

        //Get All Tags.
        public List<Tags> getTags()
        {
            List<Tags> tags = new List<Tags>();

            SQLiteCommand sqlc = new SQLiteCommand("SELECT * FROM tags ORDER BY name", dbConnection);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                tags.Add(new Tags(Convert.ToInt32(sqldr["id"]), Convert.ToString(sqldr["name"])));
            }

            return tags;
        }

        //Get All Authors.
        public List<string> getAuthors()
        {
            List<string> tags = new List<string>();

            SQLiteCommand sqlc = new SQLiteCommand(@"SELECT CASE
    WHEN author IS NULL OR author = ''
    THEN '(No author name)'
    ELSE author
END as author FROM files GROUP BY CASE
    WHEN author IS NULL OR author = ''
    THEN '(No author name)'
    ELSE author
END ORDER BY author", dbConnection);
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                tags.Add(Convert.ToString(sqldr["author"]));
            }

            return tags;
        }

        //Save modified file record
        public void saveModifiedFileRecords(Files fi)
        {
            using (var transaction = dbConnection.BeginTransaction())
            {
                string[] tags = fi.Tags.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
                // For remove other empty lines i.e. " ".
                for (int i = 0; i < tags.Length; i++)
                {
                    tags[i] = tags[i].Trim();
                }
                tags = tags.Where(val => !string.IsNullOrEmpty(val)).ToArray();

                List<string> existLinkedTagsName = new List<string>();
                List<int> existLinkedTagsId = new List<int>();

                // Find exist and linked tags.
                SQLiteCommand sqlcf = new SQLiteCommand(@"SELECT t.* FROM tags t
                                            LEFT JOIN file_tag ft ON t.'id' = ft.'tags_id'
                                            WHERE t.name IN ({names}) AND ft.'files_id' = $files_id;", dbConnection);
                sqlcf.Parameters.AddWithValue("$files_id", fi.Id);
                sqlcf.AddArrayParameters("names", tags);
                SQLiteDataReader sqlcfr = sqlcf.ExecuteReader();
                while (sqlcfr.Read())
                {
                    existLinkedTagsId.Add(Convert.ToInt32(sqlcfr["id"]));
                    existLinkedTagsName.Add(Convert.ToString(sqlcfr["name"]));
                }

                string[] linkedTagsDiff = new string[0];
                // Gets deleted and new tags.
                linkedTagsDiff = tags.Except(existLinkedTagsName.ToArray()).ToArray(); 

                if (existLinkedTagsId.Count > 0)
                {
                    // Search and delete those records which was removed from the Files' tags.
                    SQLiteCommand sqlcdFileTag = new SQLiteCommand(@"DELETE  
                            FROM    file_tag
                            WHERE   files_id = $files_id AND
                                    tags_id NOT IN ({tags_id});", dbConnection);
                    sqlcdFileTag.Parameters.AddWithValue("$files_id", fi.Id);
                    sqlcdFileTag.AddArrayParameters("tags_id", existLinkedTagsId.ToArray());
                    sqlcdFileTag.ExecuteNonQuery();
                }
                else
                {
                    // Delete all tags, if there's no match the previous ones.
                    SQLiteCommand sqlcdFileTag = new SQLiteCommand(@"DELETE  
                            FROM    file_tag
                            WHERE   files_id = $files_id;", dbConnection);
                    sqlcdFileTag.Parameters.AddWithValue("$files_id", fi.Id);
                    sqlcdFileTag.ExecuteNonQuery(); 
                }


                List<string> existTagsName = new List<string>();
                List<int> existTagsId = new List<int>();

                // Get's not linked exist tags.
                SQLiteCommand sqlcft = new SQLiteCommand(@"SELECT * FROM tags WHERE name IN ({name})", dbConnection);
                sqlcft.AddArrayParameters("name", linkedTagsDiff);
                SQLiteDataReader sqlcftr = sqlcft.ExecuteReader();
                while (sqlcftr.Read())
                {
                    existTagsId.Add(Convert.ToInt32(sqlcftr["id"]));
                    existTagsName.Add(Convert.ToString(sqlcftr["name"]));
                }

                string[] tagsDiff = new string[0];
                // Gets new tags.
                tagsDiff = linkedTagsDiff.Except(existTagsName.ToArray()).ToArray();

                if (tagsDiff.Length > 0)
                {
                    foreach (string item in tagsDiff)
                    {
                        // Insert new tag name.
                        SQLiteCommand sqlci = new SQLiteCommand(@"INSERT INTO tags (name) VALUES ($name);", dbConnection);
                        sqlci.Parameters.AddWithValue("$name", item);
                        int a = sqlci.ExecuteNonQuery();

                        // Get last insert id.
                        SQLiteCommand Command = new SQLiteCommand(@"select last_insert_rowid()", dbConnection);
                        long lastId = (long)Command.ExecuteScalar();

                        // Add new insert id to collection.
                        existTagsId.Add(Convert.ToInt32(lastId));
                    }
                }

                if (existTagsId.Count > 0)
                {
                    foreach (int item in existTagsId)
                    {
                        // Add newly added tags to file.
                        SQLiteCommand sqlci = new SQLiteCommand(@"INSERT INTO file_tag (files_id, tags_id) VALUES ($files_id, $tags_id);", dbConnection);
                        sqlci.Parameters.AddWithValue("$files_id", fi.Id);
                        sqlci.Parameters.AddWithValue("$tags_id", item);
                        int a = sqlci.ExecuteNonQuery();
                    }
                }

                // Search and delete those records which doesn't have pair in file_tag table form tags table.
                SQLiteCommand sqlcd = new SQLiteCommand(@"DELETE  
                            FROM    tags
                            WHERE   id NOT IN
                                    (
                                    SELECT  tags_id
                                    FROM    file_tag
                                    );", dbConnection);
                sqlcd.ExecuteNonQuery();

                if (fi.Year == "") {
                    SQLiteCommand sqlc = new SQLiteCommand(@"UPDATE files SET title = $title, author = $author, year = null, doi = $doi, favorite = $favorite WHERE id = $id", dbConnection);
                    sqlc.Parameters.AddWithValue("$id", fi.Id);
                    sqlc.Parameters.AddWithValue("$title", fi.Title);
                    sqlc.Parameters.AddWithValue("$author", fi.Author);
                    sqlc.Parameters.AddWithValue("$doi", fi.Doi);
                    sqlc.Parameters.AddWithValue("$favorite", fi.Favorite);
                    sqlc.ExecuteNonQuery();
                }
                else
                {
                    SQLiteCommand sqlc = new SQLiteCommand(@"UPDATE files SET title = $title, author = $author, year = $year, doi = $doi, favorite = $favorite WHERE id = $id", dbConnection);
                    sqlc.Parameters.AddWithValue("$id", fi.Id);
                    sqlc.Parameters.AddWithValue("$title", fi.Title);
                    sqlc.Parameters.AddWithValue("$author", fi.Author);
                    sqlc.Parameters.AddWithValue("$year", fi.Year);
                    sqlc.Parameters.AddWithValue("$doi", fi.Doi);
                    sqlc.Parameters.AddWithValue("$favorite", fi.Favorite);
                    sqlc.ExecuteNonQuery();
                }

                transaction.Commit();
            }
        }

        // This finds all files, which have 'Biztosítás' and 'pdf' tags on it.
        //Select *
        //From files As f
        //Where Exists    (
        //        Select 1
        //        From file_tag As ft
        //        LEFT JOIN tags t ON t.id = ft.tags_id
        //        Where t.name In('Biztosítás','pdf') --insert tags here, it can't be empty!
        //            And ft.files_id = f.Id
        //        Group By ft.files_id
        //        Having Count(*) = 2 --tags no.
        //        ) --insert addicional condition here

        //
        public List<Files> getASFiles(ASCriteria criteria)
        {
            List<Files> files = new List<Files>();

            string where = "";

            string command = @"SELECT  f.*, group_concat(t.name, ', ') AS tags_name FROM files f
	                LEFT JOIN file_tag ft ON ft.'files_id' = f.'id'
	                LEFT JOIN tags t ON ft.'tags_id' = t.'id'";

            if (criteria.Title != "")
            {
                where += "and f.title LIKE $title ";
            }

            if (criteria.Author != "")
            {
                where += "and f.author LIKE $author ";
            }

            if (criteria.Doi != "")
            {
                where += "and f.doi LIKE $doi ";
            }

            if (criteria.Tags != "")
            {
                where += @"and Exists    (
                Select 1
                From file_tag As ft
                LEFT JOIN tags t ON t.id = ft.tags_id
                Where t.name In ({name_tags})
                    And ft.files_id = f.Id
                Group By ft.files_id
                Having Count(*) = $name_tags_count
                )"; 
            }

            if (criteria.YearFrom != 0)
            {
                where += "and f.year >= $yearFrom ";
            }

            if (criteria.YearTo != 0)
            {
                where += "and f.year <= $yearTo ";
            }

            if (criteria.AddedFrom > DateTime.MinValue)
            {
                where += "and f.added >= $addedFrom ";
            }

            if (criteria.AddedTo > DateTime.MinValue)
            {
                where += "and f.added <= $addedTo ";
            }

            if (criteria.Notes != "")
            {
                where += "and f.note LIKE $note ";
            }

            if (criteria.Favorite == 1)
            {
                where += "and f.favorite = 1 ";
            }
            else if (criteria.Favorite == 0)
            {
                where += "and f.favorite = 0 ";
            }

            if (where != "")
            {
                where = " WHERE " + where.Remove(0, 4);
                command += where;
            }

            command += @" GROUP BY f.id";

            SQLiteCommand sqlc = new SQLiteCommand(command, dbConnection);
            if (criteria.Title != "")
            {
                sqlc.Parameters.AddWithValue("$title", criteria.Title);
            }

            if (criteria.Author != "")
            {
                sqlc.Parameters.AddWithValue("$author", criteria.Author);
            }

            if (criteria.Doi != "")
            {
                sqlc.Parameters.AddWithValue("$doi", criteria.Doi);
            }

            if (criteria.Tags != "")
            {
                string[] tags = criteria.Tags.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
                sqlc.AddArrayParameters("name_tags", tags);
                sqlc.Parameters.AddWithValue("$name_tags_count", tags.Length);
            }

            if (criteria.YearFrom != 0)
            {
                sqlc.Parameters.AddWithValue("$yearFrom", criteria.YearFrom);
            }

            if (criteria.YearTo != 0)
            {
                sqlc.Parameters.AddWithValue("$yearTo", criteria.YearTo);
            }

            if (criteria.AddedFrom > DateTime.MinValue)
            {
                sqlc.Parameters.AddWithValue("$addedFrom", criteria.AddedFrom);
            }

            if (criteria.AddedTo > DateTime.MinValue)
            {
                sqlc.Parameters.AddWithValue("$addedTo", criteria.AddedTo);
            }

            if (criteria.Notes != "")
            {
                sqlc.Parameters.AddWithValue("$note", criteria.Notes);
            }
            SQLiteDataReader sqldr = sqlc.ExecuteReader();
            while (sqldr.Read())
            {
                // Do not use sqldr["id"].toString() because it won't work and kills the program!
                files.Add(new Files(
                    Convert.ToInt32(sqldr["id"]),
                    Convert.ToString(sqldr["title"]),
                    Convert.ToString(sqldr["author"]),
                    Convert.ToString(sqldr["year"]),
                    Convert.ToString(sqldr["doi"]),
                    Convert.ToString(sqldr["vdirs_id"]),
                    Convert.ToBoolean(sqldr["favorite"]),
                    Convert.ToString(sqldr["type"]),
                    Convert.ToString(sqldr["tags_name"]),
                    Convert.ToString(sqldr["note"]),
                    Convert.ToString(sqldr["location"]),
                    Convert.ToString(sqldr["added"]),
                    Convert.ToString(sqldr["rread"])
                    ));
            }

            return files;
        }
    }
}
