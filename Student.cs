using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Student_database_management
{
    class Student
    {
        public static int idcount; // this is to set the id's in order
        public Dictionary<string, object> db; // for changing the json to Dictionary
        public List<int> students_id = new List<int>(); // for saving the students

        public Student()
        {
            string db_text = File.ReadAllText("db.json");
            db = JsonConvert.DeserializeObject<Dictionary<string, object>>(db_text);
            foreach (string id in db.Keys.ToArray())
            {
                students_id.Add(Convert.ToInt32(id));
            }
            idcount = students_id.Max() + 1;
        }
        public void save_db()
        {
            string db_json = JsonConvert.SerializeObject(db, Formatting.Indented);
            //string db_json = System.Text.Json.JsonSerializer.Serialize(db);
            File.WriteAllText("db.json", db_json);
        }


        public string add_stu(string name, int age, int grade) // For adding student
        {
            IDictionary<string, object> stu_dict = new Dictionary<string, object>();
            stu_dict.Add("name", name);
            stu_dict.Add("age", age);
            stu_dict.Add("grade", grade);
            db.Add(Convert.ToString(idcount), stu_dict);
            students_id.Add(idcount);
            save_db();
            string message = "Student is Added Successfully!\n";
            message += "\nStudent ID: " + idcount;
            message += "\nStudent Name: " + name;
            message += "\nStudent Age: " + age;
            message += "\nStudent Grade: " + grade + "\n";
            
            idcount++;
            return message;
        }

        public string remove_stu(int id) // For removing student
        {
            bool isfound = false;
            foreach (var stu_id in students_id)
            {
                if (stu_id == id)
                {
                    isfound = true;
                    break;
                }
            }
            if (isfound == false)
            {
                return "Student with this ID is not found in the DataBase!!\n";
            }
            db.Remove(Convert.ToString(id));
            students_id.Remove(id);
            save_db();
            return "Successfully Removed the Student from DataBase!!\n";
        }

        public string ListStudents()
        {
            string message = "";
            foreach (var id in students_id)
            {
                dynamic stu_dic = db[Convert.ToString(id)];
                string name = (string)stu_dic["name"];
                int age = (int)stu_dic["age"];
                int grade = (int)stu_dic["grade"];
                message += "Student Name: " + name + "\n";
                message += "\tID: " + id + "\n";
                message += "\tAge: " + age + "\n";
                message += "\tGrade: " + grade + "\n\n";
            }
            return message;
        }
    }
}
