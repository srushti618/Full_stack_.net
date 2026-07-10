using System;
using System.Collections.Generic;

class Teacher{
    public int tid{get;set;}
    public string tname{get;set;}
}
class Stud{
    public int id{get;set;}
    public string name{get;set;}
}
class Collection{
    static void Main(){
        // List <string> names=new List <string>();
        // names.Add("Srushti");
        // names.Add("amruta");
        // names.Add("achal");
        // names.Add("sanskruti");
        // names.Add("Sneha");
        // names.Add("bhakti");
        // names.Add("Shraddha");

        // names.Add("astha");
        // foreach(string n in names){
        //     Console.WriteLine(n);
        // }
        List <Stud> st=new List<Stud>
{
new Stud {id=1,name="srushti"},
new Stud {id=2,name="soham"},
new Stud {id=3,name="sakshi"},
new Stud {id=4,name="saloni"},
new Stud {id=5,name="sandhya"},

};
        List <Teacher> teach=new List<Teacher>
{
new Teacher {tid=11,tname="tsrushti"},
new Teacher {tid=12,tname="tsoham"},
new Teacher {tid=13,tname="tsakshi"},
new Teacher {tid=14,tname="tsaloni"},
new Teacher {tid=15,tname="tsandhya"},

};
foreach(var stu in st){
    Console.WriteLine($"student id  and name is {stu.id}{stu.name}");
}
foreach(var tea in teach ){
    Console.WriteLine($"teacher id  and name is {tea.tid}{tea.tname}");
}





    }
} 
