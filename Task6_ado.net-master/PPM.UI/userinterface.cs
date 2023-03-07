using Program.Model.modl;
using PROGRAM.DOMINE.domine;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace PROGRAM.UI.ui;

 public class UI
{
   public void Viewing()
   {

        ProjectData obj = new ProjectData();
        EmployeeManagement obj1 = new EmployeeManagement();
        RoleManagement obj2 = new RoleManagement();
        Employee employee = new Employee();
        Project project = new Project();
       /* Role role = new Role();*/
        obj2.RoleList.Add(new Role(1,"Manager"));
        obj2.RoleList.Add(new Role(2,"Asst.Manger"));
        obj2.RoleList.Add(new Role(3,"Software Engineer" ));
        obj2.RoleList.Add(new Role(4,"Associate Software Engineer" ));
        obj2.RoleList.Add(new Role(5,"Trainee Software Engineer" ));


        Console.WriteLine("");
        Boolean error = false;


        Regex phonenumber = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");
        Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex date = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");
        View:
            Console.WriteLine("");
            Console.WriteLine("                                      *** | PROLIFICS PROJECT MANAGEMENT    | ***                                    ");
            Console.WriteLine("\n \n  HELLO PROLIFIAN ");
            Console.WriteLine("");
            Console.Write("\n \n  Select  Operation ");
            Console.WriteLine("");
            Console.Write("                                           Enter \"1\" : Project Module");
            Console.WriteLine("");
            Console.Write("                                           Enter \"2\" : Employee Module");
            Console.WriteLine("");
            Console.Write("                                           Enter \"3\" : Role Module");
            Console.WriteLine(""); 
            Console.Write("                                           Enter \"4\" : save ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                       Enter \"x\" : exit application");
            Console.WriteLine("");
            Console.Write("\n \n Please  Enter Selected Operation ");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            var read = Console.ReadLine();
            while (true)
            {
            repeat:
                switch (read)
                {
                    case "1":
                        while (true)
                        {
                        projectModule:
                            Console.WriteLine("");
                            Console.WriteLine("                                     ****| Welcome to Project Module   |***                                    ");
                            Console.WriteLine("");
                            Console.Write("\n \n  Select  Operation ");
                            Console.WriteLine("");
                            Console.Write("                               Enter \"1\" : Add Project");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("                               Enter \"2\" : View  all Projects");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("                               Enter \"3\" : View  Project by ID");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("                               Enter \"4\" : View Project by Name");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("                           Enter \"5\" : Add Employee to Project");
                            Console.WriteLine("");
                            Console.WriteLine("                           Enter \"6\"  : Remove Employee from Project");
                            Console.WriteLine("");
                            Console.WriteLine("                           Enter \"7\"  : View Projects with Employees");
                            Console.WriteLine("");
                            Console.WriteLine("                           Enter \"8\"  : Delete  Project");
                            Console.WriteLine("");
                            Console.WriteLine("                           Enter \"9\"  : View all Projects with Employees");
                            Console.WriteLine("");
                            Console.WriteLine("                           Enter \"x\"  : Main Menu");
                            Console.WriteLine("");
                            Console.Write("\n \n Please  Enter Selected Operation ");
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                            var projectselect = Console.ReadLine();
         while (true)
        {
            switch (projectselect)
            {
                case "1":
                    Console.WriteLine("");
                    do
                    {
                    try
                     { 
                        ProjectId:
                        error = false;
                        Console.WriteLine("Enter Project Id");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        for(int i = 0; i< obj.Prolifics.Count;i++)
                        {
                        if(obj.Prolifics[i].id == Id)
                        {
                            Console.WriteLine("The Id already Exists \t");
                            Console.WriteLine("\n Enter any key to try again");
                            Console.WriteLine("\n Press x to get  Main Menu");

                            var tryId = Console.ReadLine();
                            if(tryId == "x")
                            {
                               goto projectModule;
                            }
                            else
                            {
                                goto ProjectId;
                            }
                            }
                        }
                        
                        Console.WriteLine("Enter Project Name");
                        string? name = Console.ReadLine();

                        startDate:
                        Console.WriteLine("Enter Project Start Date of Project DD/MM/YYYY formate");
                        string?  start = Console.ReadLine();
                        if(!date.IsMatch(start))
                                {
                                    Console.WriteLine("Invalid Date Format");
                                    Console.WriteLine("Enter any key to Try Again");
                                    Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                    var startDateread=Console.ReadLine();

                                    if(startDateread == "x")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        goto startDate;
                                    }
                                }
                                
                        EndDate:
                                Console.WriteLine("Enter End Date of Project in DD/MM/YYYY format");
                                string? end = Console.ReadLine();
                                if (!date.IsMatch(end))
                                {
                                    Console.WriteLine("Invalid Date Format");
                                    Console.WriteLine("Enter any key to Try Again");
                                    Console.WriteLine("Enter \"x\" to Exit to  Main Menu");
                                    
                                    var endDateread = Console.ReadLine();
                                    if (endDateread == "x")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        goto EndDate;
                                    }

                                }
                        Project project1 = new Project(name, start, end, Id);
                        project = project1;
                        obj.Addproject(project);
                        Console.WriteLine(" \n Project Added Successfully! \t ");
                        Console.ReadLine();
                        Console.WriteLine("Would You Like To Add Employees to this Project?");
                        Console.WriteLine("Enter \"Yes\" to Add or Enter Anything to Deny");
                                                
                        var addEmployeeOrNot = Console.ReadLine();

                                                    if (addEmployeeOrNot == "Yes")
                                                    {
                                                        obj1.ViewAllEmployees();
                                                        Console.WriteLine("Above are the Available Employees");
                                                        Console.WriteLine("Enter the ID of Employee to Add into Project");
                                                        int EmpId = Convert.ToInt32(Console.ReadLine());
                                                    
                                                        if(obj.exist(EmpId))
                                                        {
                                                            employee = obj1.EmployeeDetails(EmpId);
                                                            obj.AddingEmployeeToProject(Id,employee);
                                                            Console.WriteLine("Added Successfully");
                                                        }
                                                        
                                                        else 
                                                        {
                                                            Console.WriteLine("Employee Does Not Exist");
                                                        }
                                                    }

                                                    Console.WriteLine("Enter any key to get Main Menu");
                                                    Console.ReadLine();
                                            

                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nError : only use Numbers for ID");
                        Console.WriteLine("Enter any key to Try Again");
                        Console.WriteLine("Enter  \"x\" to get Main Menu");
                            
                                read= Console.ReadLine();
                                if(read == "x")
                                {
                                    break;
                                }
                                error = true;
                    }
                        
                        catch (Exception)
                            {
                                Console.WriteLine("\nError : Only use Numbers for ID");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to get Main Menu");
                            
                                
                                read = Console.ReadLine();
                                if(read == "x")
                                {
                                    
                                    break;
                                }
                                error = true;
                            }
                    
                }
            
                while(error);
                    break;
                case "2":
                    obj.ViewAllProjects();
                     Console.WriteLine("Enter any key to get back  to main menu");
                    Console.ReadLine();
                    break;
                case "3":
                    try
                    {
                        Console.WriteLine("Search via project id");
                        Console.WriteLine("Enter  id of project");
                        int eid = Convert.ToInt32(Console.ReadLine());
                        obj.ShowProject(eid);
                        Console.WriteLine();
                        Console.WriteLine("Enter any key to get back to main menu");
                        Console.ReadLine();
                    }
                    catch (Exception ) 
                    {
                         Console.WriteLine("Id should be in numbers formate"); 
                    }
                    break;
                case "4":
                        Console.WriteLine("Type to search for project");
                        read = Console.ReadLine();
                        obj.SearchProjectByName(read);
                        Console.WriteLine("Enter any key to get to main menu");
                        Console.ReadLine();
                        break;
                case "5":
                try{

                
                        Console.WriteLine("");
                        Console.WriteLine("Available projects");
                        obj.ViewAllProjects();
                        Console.WriteLine();
                        Console.WriteLine(" Available employees");
                        obj1.ViewAllEmployees();
                        Console.WriteLine("Enter  Project ID ");
                        int PROJId = Convert.ToInt32(Console.ReadLine());
                    if(obj.exist(PROJId))
                        {
                         Console.WriteLine("Enter the  employee ID ");
                        int EmpId = Convert.ToInt32(Console.ReadLine());
                        if( obj1.exist(EmpId))
                        {
                            Employee  employee1 = obj1.EmployeeDetails(EmpId);
                            if(!obj.IfExistsInEmployee(EmpId, PROJId))
                            {
                            obj.AddingEmployeeToProject(PROJId,employee);
                            
                            Console.WriteLine(" Project Added Successfully");
                            }
                        else
                        {
                             Console.WriteLine("Employee Already exist");
                        }
                        
                        }
                        
                    else
                    {
                        Console.WriteLine("project does not exist");
                    }
                 } 
                }
                   catch(Exception)
                   {
                    Console.WriteLine("Invalid Entry");
                   }
                   Console.WriteLine("Enter any key to get back to main menu");
                   Console.ReadLine();
                   
                 
                break;

                
                case "6":  try{
                        obj.ViewAllProjects();
                        Console.WriteLine("Enter Project ID");
                        int PROJId1 = Convert.ToInt32(Console.ReadLine());
                        if(obj.exist(PROJId1)){
                        Console.WriteLine("Enter Employee ID ");
                        int EmpId1 = Convert.ToInt32(Console.ReadLine());
                        if (obj.exist(EmpId1))
                        {
                        employee = obj1.EmployeeDetails(EmpId1);
                        obj.EmployeeFromProject(PROJId1,employee);
                        Console.WriteLine("\n Employee Deleted Successfully");
                        
                    }
                    else{
                        Console.WriteLine("NO employee present in project with the given id");
                    }
                }
                else
                {
                    Console.WriteLine("Project do not exist");
                }
                }
                    catch(FormatException )
                    {
                        Console.WriteLine("Id can only be integer");
                    }
                        Console.WriteLine("Enter any key to get to main menu");
                        Console.ReadLine();
                        break;
                case "7":
                    Console.WriteLine("Enter Project Id");
                    int pid = Convert.ToInt32(Console.ReadLine());
                    obj.Display();
                    Console.WriteLine("Enter any key to get to main menu");
                    Console.ReadLine();
                    break;
                case "8" :
                try  
                {
                    Console.WriteLine(" Enter Project ID to Delete ");
                    int IDforDelete = Convert.ToInt32(Console.ReadLine());
                    if(obj.exist(IDforDelete))
                
                    {
                        for(int i=0; i< obj.Prolifics.Count; i ++ )                 
                        {
                            for (int j = 0; j < obj.Prolifics[i].AddingEmployeelist.Count; j ++)
                            {
                                if (obj.Prolifics[i].id == IDforDelete)
                                {
                                    obj.EmployeeFromProject(IDforDelete, obj.Prolifics[i].AddingEmployeelist[j]);
                                }
                            }
                            if (obj.Prolifics[i].id== IDforDelete)
                            {
                                obj.DeleteProject(IDforDelete, obj.Prolifics[i]);
                                Console.WriteLine("Deleted Successfully !!..");
                            }
                        }   
                    }
                    else
                    {
                        Console.WriteLine(" No  Project Exist");
                    }
                }
                    catch (FormatException )
                {
                    Console.WriteLine("ID should be number");
                }
                    Console.WriteLine("Enter any key to get to main menu");
                    Console.ReadLine();
                    break;
                case "9":
                    obj.ViewAllProjects();
                    Console.WriteLine("Enter any key to get to main menu");
                    Console.ReadLine();
                    break;
                case "x":
                    goto View;
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    break;
            }
        }
    }
        
        case "2":
                while(true)
                {
                    Console.WriteLine("");
                    Console.WriteLine(" ***** EMPLOYEE MODULE ***** ");
                    Console.WriteLine("");
                    Console.WriteLine(" Enter 1 to Adding Employee ");
                    Console.WriteLine(" Enter 2 to List All Employees ");
                    Console.WriteLine(" Enter 3 to List Employee By Id ");
                    Console.WriteLine(" Enter 4 to Delete Employee ");
                    Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                    Console.WriteLine("");
                    var employeeSelector = Console.ReadLine();
                    switch(employeeSelector)
                    {
                    case "1":
                        tryagain:
                        try
                        {
                        ProjectempId:
                        Console.WriteLine("Enter the Id of employee");
                        int empId = Convert.ToInt32(Console.ReadLine());
                         for(int i = 0; i< obj1.ProlificsemployeeList.Count;i++)
                        {
                            if(obj1.ProlificsemployeeList[i].employeeId == empId)
                            {
                                Console.WriteLine(" \n \n The id already exists \t ");
                                Console.WriteLine("\n Enter any key to try again \t");
                                Console.WriteLine(" \n Press x to get to main menu \t ");
                                var tryId = Console.ReadLine();
                                if(tryId == "x")
                                {
                                goto tryagain;
                                }
                                else
                                {
                                goto ProjectempId;
                                }
                            }
                        }
                        
                        Console.WriteLine("Enter employee First Name");
                        var FirstName = Console.ReadLine();
                        Console.WriteLine("Enter employee Last Name");
                        var LastName = Console.ReadLine();
                        EMAIL:
                        Console.WriteLine("Enter employee Email Id");
                        string Email = Console.ReadLine();
                            if(!email.IsMatch(Email))
                            {
                                Console.WriteLine("Invalid Email Format");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to get Main Menu");
                                
                                var emailread=Console.ReadLine();

                                if(emailread=="x")
                                {
                                    break;
                                }
                                else
                                {
                                    goto EMAIL;
                                }
                            }
                        Mobile:
                        Console.WriteLine("Enter employee Mobile Number");
                        string MobileNumber = Console.ReadLine();
                            if(!phonenumber.IsMatch(MobileNumber))
                            {
                                Console.WriteLine("Invalid Mobile Number format");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to get Main Menu");
                                var mobileread=Console.ReadLine();

                                if(mobileread=="x")
                                {
                                    break;
                                }
                                else
                                {
                                    goto Mobile;
                                }
                            }
                            
                        Console.WriteLine("Enter Employee Address");
                        string Address = Console.ReadLine();


                        Option:
                        Console.WriteLine("Select 1 : Add Role Id to Employe");
                        Console.WriteLine("Select 2 : New Role to  Employee");

                        int select = Convert.ToInt32(Console.ReadLine());
                        if (select == 1)
                        {
                        try
                        {
                        SelectRole:
                            obj2.DisplayRole();
                            Console.WriteLine("Select Role Id from above list to assign role to employee");
                            int r1 = Convert.ToInt32(Console.ReadLine());
                            string? roleName1 = null;
                            if(obj2.exist(r1))
                            {
                                for (int i=0; i<obj2.RoleList.Count; i++)
                                {
                                if (obj2.RoleList[i].roleId == r1)
                                    {
                                    roleName1= obj2.RoleList[i].roleName;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Entry");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to get Main Menu");
                                string? tryemprole = Console.ReadLine();
                                if(tryemprole == "x")   
                                {
                                    break;
                                }
                                else
                                {
                                    goto SelectRole;
                                }
                            }
                            Employee employeeadd = new Employee(empId, FirstName, LastName, Email, MobileNumber, Address, r1, roleName1);
                            obj1.AddEmployee(employeeadd);
                            employee = employeeadd;
                            Console.WriteLine(" \n \n Added Successfully");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\n \n Emp ID in formate eg: 1234 ");
                        }
                        }
                        else if (select == 2)
                        {
                        try
                        {   roleID:
                            Console.WriteLine("Enter  Role Id");
                            int roleID = Convert.ToInt32(Console.ReadLine());
                            if (obj2.exist(roleID))
                            {
                                Console.WriteLine("Role with this ID already Exists");
                                Console.WriteLine("Enter any key to Try Again");
                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                var tryagain = Console.ReadLine();
                                if (tryagain == "x")
                                {
                                break;
                                }
                                else
                                {
                                goto roleID;
                                }
                            }
                           else
                           {                                 
                            Console.WriteLine("Enter  name of the  Role");
                            string roleName = Console.ReadLine();
                            Console.WriteLine(roleName);

                            Role newRole = new Role(roleID, roleName);
                            obj2.RoleAdd(newRole);

                            Employee eadd = new Employee(empId, FirstName, LastName, Email, MobileNumber,Address, roleID, roleName);
                            obj1.AddEmployee(eadd);
                            employee = eadd;
                            Console.WriteLine("\n \n ...Added Successfully...\t");
                           }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\n \n Role Id should be Numbers ");
                        }
                        }
                        else
                        {
                        Console.WriteLine("Invalid entry");
                        Console.WriteLine("Try Again");
                        goto Option;
                        }
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine("ID can only be in Numbers");
                        Console.WriteLine("Enter any key to Try Again");
                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");

                        string EmpIdTry = Console.ReadLine();
                        if(EmpIdTry == "y")
                            {
                                goto breaking;
                            }
                            else
                            {
                                goto tryagain;
                            }
                    }

                        catch(Exception e)
                        {
                        Console.WriteLine("Invalid Entry");
                        Console.WriteLine("Enter any key to Try Again");
                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                            
                        string EmpIdTry1 = Console.ReadLine();

                        if(EmpIdTry1 == "x")
                            {
                                goto breaking;
                            }
                            else
                            {
                                goto tryagain;
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Enter any key to get back to Main Menu");
                        Console.ReadLine();
                        breaking:
                        break;

                case "2":
                    obj1.ViewAllEmployees();
                    Console.WriteLine("Enter any key to get Main Menu");
                    Console.ReadLine();
                    break;
                case "3":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Employee");
                                            int searchEmployeeById = Convert.ToInt32(Console.ReadLine());
                                            obj1.ShowEmployee(searchEmployeeById);
                                            Console.WriteLine("Enter any key to get Main Menu");
                                            Console.ReadLine();
                                        }

                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("ID can only be in Numbers");
                                        }
                                    
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Invalid Input");
                                        }
                                        break;

                                    case "4":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Employee");
                                            int idforDeleting = Convert.ToInt32(Console.ReadLine());
                                            for (int i=0; i< obj1.ProlificsemployeeList.Count; i++)
                                            {
                                                if (obj1.ProlificsemployeeList[i].employeeId == idforDeleting)
                                                {
                                                    for (int j=0; j<obj.Prolifics.Count; j++)
                                                    {
                                                        if (obj.Prolifics.Count !=0 && obj.Prolifics[j].AddingEmployeelist.Count !=0)
                                                        {
                                                            for (int k=0; k<obj.Prolifics[j].AddingEmployeelist.Count; k++)
                                                            {
                                                                if (obj.Prolifics[j].AddingEmployeelist[k].employeeId == idforDeleting)
                                                                {
                                                                    obj.Prolifics[j].AddingEmployeelist.Remove(obj.Prolifics[j].AddingEmployeelist[k]);
                                                                }
                                                            }
                                                        }
                                                    }

                                                    obj1.DeleteEmployee(idforDeleting, obj1.ProlificsemployeeList[i]);
                                                    Console.WriteLine("Deleted Successfully");
                                                }
                                            }
                                            
                                            Console.WriteLine("Enter any key to get Main Menu");
                                            Console.ReadLine();
                                            break;
                                        }
                                    
                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("Enter Valid Input");
                                        }
                                        break;
                                
                                    case "x":
                                        goto View;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Input, Provide Correct Input");
                                        break;
                                }
                            }


                case "3":
                while(true)
                {
                    Console.WriteLine("");
                    Console.WriteLine(" ***** ROLE MODULE ***** ");
                    Console.WriteLine("");
                    Console.WriteLine(" Enter 1 to Adding Role ");
                    Console.WriteLine(" Enter 2 to List All Roles ");
                    Console.WriteLine(" Enter 3 to List Roles By Id ");
                    Console.WriteLine(" Enter 4 to Delete Role ");
                    Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                    Console.WriteLine("");
                    var roleSelector = Console.ReadLine();
                switch (roleSelector)
                {
                    case "1":
                        try
                        {
                            InputroleID:
                            Console.WriteLine(" \n \n Enter  Role Id \t ");
                            int RoleId = Convert.ToInt32(Console.ReadLine());
                            // for(int i = 0; i<obj2.RoleList.Count; i++)
                            // {
                            // if(RoleId == obj2.RoleList[i].roleId)
                            // {
                            // Console.WriteLine("The ID already exists try new ID");
                            // Console.WriteLine("Enter any key to Try Again");
                            // Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                            // string roleidTry = Console.ReadLine();
                            //                             if (roleidTry == "x") 
                            //                             {
                            //                                 break;
                            //                             }
                            //                             else
                            //                             {
                            //                                 goto InputroleID;
                            //                             }
                            //                         }
                            //                     }

                        Console.WriteLine("Enter name of the  Role");
                        string? roleNAme = Console.ReadLine();
                        Role newRole = new Role(RoleId, roleNAme);
                        obj2.RoleAdding(newRole);
                        Console.WriteLine("\n \n ...Added Successfully...\t");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Role Id should only be in number formate ");
                    }
                    break;

                case "2":
                    obj2.DisplayRole();
                    Console.WriteLine("Enter any key to get back  to main menu");
                    Console.ReadLine();
                    break;
                
                case "3":
                try
                {
                    Console.WriteLine("Enter Role ID ");
                        int searchRoleById = Convert.ToInt32(Console.ReadLine());
                        if (obj2.exist(searchRoleById))
                            {
                                obj2.ListRoleById(searchRoleById);
                            }
                                        
                        else
                            {
                                Console.WriteLine(" Role ID Does Not Exist");
                            }
                                        
                                Console.WriteLine("Enter any key to get Main Menu");
                                Console.ReadLine();
                }
                catch (FormatException )
                {
                    Console.WriteLine("ID should be in Numbers only");
                }
                catch (Exception )
                {
                    Console.WriteLine("Invalid Input");
                }
                break; 
                case "4":
                try
                {
                    Console.WriteLine("Enter the ID of the Role");
                    int deleteRoleById = Convert.ToInt32(Console.ReadLine());
                    if (obj2.exist(deleteRoleById))
                    {
                        if (obj1.IfExistsByRole(deleteRoleById))
                            {
                                Console.WriteLine("Looks like Employee consists this Role ID, Delete Employee with this Role Id First");
                            }
                        else
                            {
                                obj2.DeleteRole(deleteRoleById);
                                Console.WriteLine("Deleted Successfully");
                            }
                    }
                                            
                    else
                    {
                    Console.WriteLine("ID Does Not Exists");
                    }
                    Console.WriteLine("Enter any key to get Main Menu");
                    Console.ReadLine();
                }
                                    
                catch ( FormatException e)
                {
                    Console.WriteLine("ID should be in Numbers only");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                }
                break;
                                
                case "x":
                goto View;
                break;

            default:
            Console.WriteLine("Invalid Entry");
            break;
        }
                            
    }
                
    case "4":
    var serialiazerProject = new XmlSerializer(typeof(List<Project>));

    var serialiazerEmployee = new XmlSerializer(typeof(List<Employee>));

    var serializerRole = new XmlSerializer(typeof(List<Role>));

    using (var writer = new StreamWriter (@"C:\Users\SMandlole\XmlSerialization file\Text.txt"))

    {
        serialiazerProject.Serialize(writer, obj.Prolifics);

        serialiazerEmployee.Serialize(writer, obj1.ProlificsemployeeList);

        serializerRole.Serialize(writer, obj2.RoleList);
    }

    break;

    case "5":
    return;  
    }

              
        
   
        
            Console.Write("\n LIST OF OPERATIONS ");
            Console.WriteLine("");
            Console.WriteLine("                                      *** | PROLIFICS PROJECT MANAGEMENT    | ***                                    ");
            Console.WriteLine("");
            Console.WriteLine("\n \n  HELLO PROLIFIAN ");
            Console.WriteLine("");
            Console.Write("\n \n  Select  Operation ");
            Console.WriteLine("");
            Console.Write("                                           Enter \"1\" : Project Module");
            Console.WriteLine("");
            Console.Write("                                           Enter \"2\" : Employee Module");
            Console.WriteLine("");
            Console.Write("                                           Enter \"3\" : Role Module");
            Console.WriteLine("");
            Console.Write("                                           Enter \"4\" : save");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                       Enter \"x\" : exit application");
            Console.WriteLine("");
            Console.Write("\n \n Please  Enter Selected Operation ");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
        }
    }
   }