// using System;
// class Except{

//     static void checkage(int age){
//         if(age<18){
//             throw new Exception("Age is less than 18");
//         }
//         else{
//             Console.WriteLine($"The age is : {age}");
//         }
//     }
//     static void Main(){
//         try{
//             int a=5;
//             int b=0;
//             int c=a/b;
//             Console.WriteLine($"The result is : {c}");
//         }
//         catch(DivideByZeroException e){
//             Console.WriteLine($"The exception is : {e.Message}");
//         }

//         try{
//             checkage(15);
//         }
//         catch(Exception e){
//             Console.WriteLine($"The exception is : {e.Message}");
//         }
//     }
// }