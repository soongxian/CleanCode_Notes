namespace _1._NestedLoop
{
    public class Program
    {
        /* ------------------------------- Messy Code ------------------------------- */
        public static void CheckModifyPermissionMessy(EmployeePermission employee)
        {
            if (employee.ActiveUser == true)
            {
                Console.WriteLine("User is active.");
                if (employee.AccessProductionDb == true)
                {
                    Console.WriteLine("User is allowed to access the production database.");
                    if (employee.ModifyProductionDb == true)
                    {
                        Console.WriteLine("User is allowed to modify the production database.");
                    }
                    else
                    {
                        throw new Exception("User is not allowed to modify the production database.");
                    }
                }
                else
                {
                    throw new Exception("User is not allowed to access the production database.");
                }
            }
            else
            {
                throw new Exception("User is not active.");
            }
        }
        /* --------------------------- End Of Messy Code ---------------------------- */


        /* ------------------------------- Clean Code ------------------------------- */
        public static void CheckModifyPermissionClean(EmployeePermission employee)
        {
            if (!employee.ActiveUser)
            {
                throw new Exception("User is not active");
            }
            Console.WriteLine("User is active.");

            if (!employee.AccessProductionDb)
            {
                throw new Exception("User is not allowed to access the production database.");
            }
            Console.WriteLine("User is allowed to access the production database.");
            if (!employee.ModifyProductionDb)
            {
                throw new Exception("User is not allowed to modify the production database.");
            }
            Console.WriteLine("User is allowed to modify the production database.");
        }
        /* --------------------------- End Of Clean Code ---------------------------- */


        public static void Main(string[] args)
        {
            EmployeePermission emp = new EmployeePermission("Ryan", true, true, true);
            // This is the messy code.
            CheckModifyPermissionMessy(emp);

            // This is the refactored version of clean code.
            CheckModifyPermissionClean(emp);
        }

        public class EmployeePermission
        {
            public string Name { get; set; }
            public bool AccessProductionDb { get; set; }
            public bool ModifyProductionDb { get; set; }
            public bool ActiveUser { get; set; }

            public EmployeePermission(string name, bool AccessProductionDb, bool ModifyProductionDb, bool activeUser)
            {
                this.Name = name;
                this.AccessProductionDb = AccessProductionDb;
                this.ModifyProductionDb = ModifyProductionDb;
                this.ActiveUser = activeUser;
            }
        }
    }
}
