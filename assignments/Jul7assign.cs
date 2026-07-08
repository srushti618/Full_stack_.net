// using System;
// class Program {
//     static void Main() {
     


  
// // ****Loops*****
// // while loop
// // do-while loop
// // for loop
// // continue
// // break
// // An automated conveyor belt processes 20 packages. Package IDs are generated from 1001 to 1020 using a loop.
// // For each package:
// // If the package ID is divisible by 4, it is marked as Quality Check Required.
// // Else if the package ID is divisible by 5, it is marked as Priority Shipment.
// // Otherwise, it is marked as Normal Processing.
// // At the end of the program, display:
// // Total packages processed
// // Number of packages requiring quality check
// // Number of priority shipments
// // Number of normal packages


// int totalpackagesprocess=0;

// int prqc=0;

// int priorityshipments=0;

// int normalpackages=0;

// for(int i=1001;i<=1020;i++){
//        totalpackagesprocess ++;

//        if(i%4==0){
//               Console.WriteLine("This Package ID "+(i)+"  it is Required Quality Check Required.");
//               prqc++;
 
//        }
//        else if(i%5==0){
//               Console.WriteLine("This Package ID "+(i)+" it is Required  as Priority Shipment.");
//               priorityshipments++;
//        }
//        else{
// Console.WriteLine("This Package ID "+(i)+" it is Required normal packages. ");
// normalpackages++;
//        }
// }
// Console.WriteLine("The number of totalpackagesprocess is :  "+(totalpackagesprocess));
// Console.WriteLine("The number of prqc is :  "+(prqc));
// Console.WriteLine("The number of priorityshipments is :  "+(priorityshipments));
// Console.WriteLine("The number of normalpackages is :  "+ (normalpackages));
   
// // Q .1 ) A smart city has 30 street lights numbered 1 to 30. The power consumption (in watts) for each light is calculated using the formula:
// // Power = 80 + (Light Number × 5)
// // For each street light:
// // If power consumption is greater than 180 W, display "Maintenance Required".
// // Else if power consumption is between 140 W and 180 W, display "Normal Operation".
// // Otherwise, display "Energy Efficient".
// // Also calculate and display:
// // Total power consumed by all street lights
// // Average power consumption
// // Number of lights in each category


// int total_power=0;
// int maintlight=0;
// int normallight=0;
// int energyelight=0;
// int power =0;
//  for(int i=1;i<=30;i++){
// power =80+(i*5); 
// total_power+=power;
// if(power>180){
//         Console.WriteLine("Maintenance Required.");
//         maintlight++;
// }
// else if (power>140 && power<=180){
//        Console.WriteLine("Normal operation");
//        normallight++;
// }
// else{
//        Console.WriteLine("Energy Efficient");
//        energyelight++;
// }
//  }
//  int avgpower=(total_power/30);

// Console.WriteLine("The total power consumed by all street lights is : "+(total_power));
// Console.WriteLine("The number of lights in each category is : "+(maintlight));
// Console.WriteLine("The number of lights in each category is : "+(normallight));
// Console.WriteLine("The number of lights in each category is : "+(energyelight));
// Console.WriteLine("Theaverage power consumed by all street lights is : "+(avgpower));


//        }
       
//     }


