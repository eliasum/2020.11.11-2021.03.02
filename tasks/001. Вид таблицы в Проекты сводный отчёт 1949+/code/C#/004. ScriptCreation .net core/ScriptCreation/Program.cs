using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            // путь к считываемому файлу списка пользователей
            string pathFileRead = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\person.txt");

            // путь к записываемому файлу списка пользователей
            string pathFileWrite = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\MQLscript.txt");



            if (File.Exists(pathFileRead))
            {
                // Читаем файл с жесткого диска.
                string[] fileRead = File.ReadAllLines(pathFileRead);

                string[] fileWrite = new string[fileRead.Length];

                
                // последовательный вывод элементов массива words
                foreach (string s in fileRead)
                {
                    Console.WriteLine(s);
                }

                for (int i = 0; i < fileRead.Length; i++)
                {
                    /*
                    Для использования интерполяции строк необходимо перед строкой указывать символ доллара — "$".
                    При интерполяции строки указано непосредственно значение в {}, которое необходимо подставить в строку.
                    */

                    fileWrite[i] = $@"
copy table PMCProjectSpaceMyDesk Projects2~PMCProjectSpaceMyDesk derived fromuser system touser {fileRead[i]};
modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} column name Task_Actual_Start_Date label emxFramework.Attribute.Task_Actual_Start_Date businessobject $<attribute[attribute_TaskActualStartDate].value> setting 'Registered Suite' Framework setting 'Field Type' attribute setting Editable true setting format date sorttype other setting Sortable true setting 'Sort Type' date order 11 column name Task_Estimated_Start_Date label emxFramework.Attribute.Task_Estimated_Start_Date businessobject $<attribute[attribute_TaskEstimatedStartDate].value> setting 'Registered Suite' Framework setting 'Field Type' attribute setting Editable true setting format date sorttype other setting Sortable true setting 'Sort Type' date order 10 column name Task_Estimated_Duration label emxFramework.Attribute.Task_Estimated_Duration businessobject $<attribute[attribute_TaskEstimatedDuration].value> setting 'Registered Suite' Framework setting 'Field Type' attribute setting Editable true setting format numeric sorttype other setting Sortable true setting 'Sort Type' real order 12;
modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} property customSortColumns value 'Name' property customSortDirections value ascending property customFreezePane value 'Name';
modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} column modify name 'Name' order '1' column modify name 'ProjectStatus' order '2' column modify name 'currentPhase' order '3' column modify name 'Type' order '4' column modify name 'Status' order '5' column modify name 'Owner' order '6' column modify name 'Created Date' order '7' column modify name 'Est Finish' order '8' column modify name 'Act Finish' order '9' column modify name 'Task_Estimated_Start_Date' order '10' column modify name 'Task_Actual_Start_Date' order '11' column modify name 'Task_Estimated_Duration' order '12';
modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} column modify name 'Program' hidden column modify name 'Description' hidden column modify name 'Project' hidden column modify name 'Vault' hidden;
modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} property MX_CURRENT_TABLE value true;

modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} column name 'EffortPlan' businessobject empty label 'emxProgramCentral.Common.EffortPlan' setting 'Registered Suite' 'ProgramCentral' setting 'Target Location' 'content' setting 'Auto Filter' 'true' setting 'RMB Menu' 'PMCListProjectRMBMenu' user all;
modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} column name 'ActualLaborCosts' businessobject empty label 'emxProgramCentral.Common.ActualLaborCosts' setting 'Registered Suite' 'ProgramCentral' setting 'Target Location' 'content' setting 'Auto Filter' 'true' setting 'RMB Menu' 'PMCListProjectRMBMenu' user all;
modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} column name 'PlannedPhysicalVolume' businessobject empty label 'emxProgramCentral.Common.PlannedPhysicalVolume' setting 'Registered Suite' 'ProgramCentral' setting 'Target Location' 'content' setting 'Auto Filter' 'true' setting 'RMB Menu' 'PMCListProjectRMBMenu' user all;
modify table Projects2~PMCProjectSpaceMyDesk user {fileRead[i]} column name 'ActualPhysicalVolume' businessobject empty label 'emxProgramCentral.Common.ActualPhysicalVolume' setting 'Registered Suite' 'ProgramCentral' setting 'Target Location' 'content' setting 'Auto Filter' 'true' setting 'RMB Menu' 'PMCListProjectRMBMenu' user all;
                    ";
                }

                // Перезаписываем файл
                File.WriteAllLines(pathFileWrite, fileWrite);

            }
            else
            {
                Console.WriteLine("Error!");
            }

            Console.ReadKey();
        }
    }
}
