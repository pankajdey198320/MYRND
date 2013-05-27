using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.IO;
namespace GetClassInfoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            string sAssemblyFileName = @"D:\PROJECTS\Tests\R_N_D\GetClassInfoReflection\GetClassInfoReflection\Asambly\MedappzService.dll";

            if (sAssemblyFileName.Length != 0)
            {
                Assembly assem = Assembly.LoadFrom(sAssemblyFileName);
                Type[] types = assem.GetTypes();
                ArrayList arrl = new ArrayList();
                foreach (Type cls in types)
                {
                    try
                    {
                        //Add Class Name                       
                        arrl.Add("["+cls.FullName+"]");
                        if (cls.IsAbstract)
                            arrl.Add("{Abstract Class:" + cls.Name.ToString()+"}");
                        else if (cls.IsPublic)
                            arrl.Add("{Public Class:" + cls.Name.ToString() + "}");
                        else if (cls.IsSealed)
                            arrl.Add("{Sealed Class:" + cls.Name.ToString() + "}");
                        
                        MethodInfo[] methodName = cls.GetMethods();
                        foreach (MethodInfo method in methodName)
                        {
                           // string s = method.MemberType.ToString();
                           object[] attributes= method.GetCustomAttributes(typeof(System.ServiceModel.OperationContractAttribute) ,true);
                        
                            //arrl.Add("\t" + method.Name.ToString());
                           if (method.ReflectedType.IsPublic && attributes.Length >0)
                                arrl.Add( method.Name.ToString() );
                            //else
                            //    arrl.Add("\tNon-Public - " + method.Name.ToString());
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        Console.WriteLine("Error msg");
                    }
                }

                //Dump Data to NotePad File
                FileStream fs = new FileStream(@"D:\myData.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                for (int i = 0; i < arrl.Count; i++)
                {
                    //  lstInfo.Items.Add(arrl[i].ToString());
                    sw.WriteLine(arrl[i].ToString());
                }
                sw.Flush();
                sw.Close();
            }
        }
    }
}
