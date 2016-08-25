using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_LinqIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            // зєднання для робітників і менеджерів           
            List<Human> employees = new List<Human>
            {
                new Employee { ID = 1, Age = 23, Name = "Oles", ManagerID = 1 },
                new Employee { ID = 2, Age = 18, Name = "Alex", ManagerID = 2 },
                new Employee { ID = 3, Age = 34, Name = "Ivan", ManagerID = 1 },
                new Employee { ID = 4, Age = 22, Name = "Vasil", ManagerID = 2 },
                new Employee { ID = 5, Age = 23, Name = "Nazar", ManagerID = 1 },
                new Employee { ID = 6, Age = 54, Name = "Valentin", ManagerID = 2 },
                new Employee { ID = 7, Age = 33, Name = "Boris", ManagerID = 1 },
                new Employee { ID = 7, Age = 33, Name = "Boris", ManagerID = 1 }
            };
            List<Human> managers = new List<Human>
            {
                new Manager { ID = 1, Age = 23, Name = "Bogdan", Employees = new List<int> { 1,3,5,7 } },
                new Manager { ID = 2, Age = 32, Name = "Roman", Employees = new List<int> { 2, 4, 6} },
                new Manager { ID = 3, Age = 40, Name = "Valera" }
            };
            List<Job> jobs = new List<Job>
            {
                new Job { ID = 1, EmployeeId = 1, Year = "2008", Month ="03", Day = "01" },
                new Job { ID = 2, EmployeeId = 1, Year = "2008", Month ="03", Day = "01" },
                new Job { ID = 3, EmployeeId = 1, Year = "2008", Month ="03", Day = "02" },
                new Job { ID = 4, EmployeeId = 1, Year = "2008", Month ="04", Day = "01" },
                new Job { ID = 5, EmployeeId = 1, Year = "2008", Month ="04", Day = "02" },
                new Job { ID = 6, EmployeeId = 2, Year = "2008", Month ="03", Day = "01" },
                new Job { ID = 7, EmployeeId = 2, Year = "2008", Month ="03", Day = "01" },
                new Job { ID = 8, EmployeeId = 2, Year = "2008", Month ="03", Day = "02" },
                new Job { ID = 9, EmployeeId = 2, Year = "2008", Month ="04", Day = "01" },
                new Job { ID = 10, EmployeeId = 3, Year = "2008", Month ="03", Day = "01" },
                new Job { ID = 11, EmployeeId = 3, Year = "2008", Month ="03", Day = "01" },
                new Job { ID = 12, EmployeeId = 3, Year = "2008", Month ="02", Day = "01" },
                new Job { ID = 13, EmployeeId = 3, Year = "2008", Month ="02", Day = "02" }
            };
            List<JobDescription> job_description = new List<JobDescription>
            {
                new JobDescription { ID = 1, Description = "To do job1" },
                new JobDescription { ID = 2, Description = "To do job2" },
                new JobDescription { ID = 3, Description = "To do job3" },
                new JobDescription { ID = 4, Description = "To do job4" },
                new JobDescription { ID = 5, Description = "To do job5" },
                new JobDescription { ID = 6, Description = "To do job6" },
                new JobDescription { ID = 7, Description = "To do job7" },
                new JobDescription { ID = 8, Description = "To do job8" },
                new JobDescription { ID = 9, Description = "To do job9" },
                new JobDescription { ID = 10, Description = "To do job10" },
                new JobDescription { ID = 11, Description = "To do job11" },
                new JobDescription { ID = 12, Description = "To do job12" },
                new JobDescription { ID = 13, Description = "To do job13" }
            };

            List<Contact> contacts = new List<Contact>
            {
                new Contact { FirstName = "Oleh", LastName = "Masnuy", Number = "0834432302" },
                new Contact { FirstName = "Ivan", LastName = "Lisnuy", Number = "0939843124" },
                new Contact { FirstName = "Andriy", LastName = "Koval", Number = "0934341233" },
                new Contact { FirstName = "Oleksandr", LastName = "Kril", Number = "0509452303" },
                new Contact { FirstName = "Orest", LastName = "Pidlisnuy", Number = "0978342233" },
                new Contact { FirstName = "Vasil", LastName = "Glushko", Number = "0987730302" },
                new Contact { FirstName = "Valera", LastName = "Osmaleniy", Number = "0987734212" },
                new Contact { FirstName = "Volodumyr", LastName = "Shepitchak", Number = "0987743341" },
                new Contact { FirstName = "Volodumyr", LastName = "Shepitchak", Number = "0987743341" }
            };
            List<CallLog> callLog = new List<CallLog>
            {
                new CallLog { Incoming = true, Number = "0939843124" },
                new CallLog { Incoming = true, Number = "0978342233" },
                new CallLog { Incoming = true, Number = "0987743341" },
                new CallLog { Incoming = true, Number = "0987742344" },
                new CallLog { Incoming = false, Number = "0983432344" },
                new CallLog { Incoming = true, Number = "0987743498" },
                new CallLog { Incoming = false, Number = "0987743432" },
                new CallLog { Incoming = true, Number = "0969850034" },
                new CallLog { Incoming = true, Number = "0969850034" }
            };

            int[] sequence = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            // простий вступ - let variable
            Console.WriteLine("1" + new string('-', 79));
            var q1 = from s in sequence
                     let average = sequence.Average()
                     select Math.Pow((s - average), 2);

            var qe1 = sequence.Select(s => new { s = s, average = sequence.Average() })
                              .Select(z => Math.Pow((z.s - z.average), 2));

            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }

            // простий вступ - into operator
            Console.WriteLine("2" + new string('-', 79));
            var q2 = from e in employees.Cast<Employee>()
                     group e by e.ManagerID into m_group
                     select new { ManagerId = m_group.Key, Elements = m_group, Count = m_group.Count() };

            var qe2 = employees.Cast<Employee>()
                               .GroupBy(e => e.ManagerID)
                               .Select(e => new { ManagerId = e.Key, Elements = e, Count = e.Count() });

            foreach (var item in qe2)
            {
                Console.WriteLine("Manager id = {0}", item.ManagerId);
                foreach (var e in item.Elements)
                {
                    Console.WriteLine(" emp id = {0}, emp name = {1}, manager id = {2}", e.ID, e.Name, e.ManagerID);
                }
            }

            // простий вступ - join
            Console.WriteLine("3" + new string('-', 79));
            var q3 = employees.Cast<Employee>()
                              .Join(managers.Cast<Manager>(),
                                    e => e.ManagerID,
                                    m => m.ID,
                                    (e, m) => new { EmployeeId = e.ID, EmployeeName = e.Name, ManagerId = m.ID })
                              .OrderByDescending(z => z.EmployeeId)
                              .Take(5);

            var qe3 = (from e in employees.Cast<Employee>()
                       join m in managers.Cast<Manager>()
                        on e.ManagerID equals m.ID
                       orderby e.ID descending
                       select new { EmployeeId = e.ID, EmployeeName = e.Name, ManagerId = m.ID }).Take(5);

            foreach (var item in qe3)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}, managerid = {2}", item.EmployeeId, item.EmployeeName, item.ManagerId);
            }

            // простий вступ - використання лічильника циклів
            Console.WriteLine("4" + new string('-', 79));
            var qe4 = employees.Cast<Employee>().Select((e, index) => e.FooMethod(index));

            foreach (var item in qe4.GetNotNull())
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}, managerid = {2}", item.ID, item.Name, item.ManagerID);
            }

            // Select vs SelectMany
            string[] sequece = new string[] { "The quick brown", "fox jumps over", "the lazy dog." };

            Console.WriteLine("5" + new string('-', 79));
            IEnumerable<string[]> qe5 = sequece.Select(s => s.Split(' '));

            foreach (var item in qe5)
            {
                foreach (var w in item)
                {
                    Console.WriteLine(w);
                }
            }

            Console.WriteLine("6" + new string('-', 79));
            IEnumerable<string> qe6 = sequece.SelectMany(s => s.Split(' '));

            foreach (var item in qe6)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("7" + new string('-', 79));
            var q7 = from s in sequece
                     from w in s.Split(' ')
                     select s;

            foreach (var item in q7)
            {
                Console.WriteLine(item);
            }

            // Select vs SelectMany for employee/managers
            Console.WriteLine("8" + new string('-', 79));
            IEnumerable<Employee> qe8 = managers.Cast<Manager>()
                                                .SelectMany(m => m.Employees.ConvertAll(x => new Employee { ID = x }));

            foreach (var item in qe8)
            {
                Console.WriteLine(item.ID);
            }

            Console.WriteLine("9" + new string('-', 79));
            var qe9 = managers.Cast<Manager>()
                              .SelectMany(m => m.Employees.ConvertAll(x => new Employee { ID = x, ManagerID = m.ID }))
                              .GroupBy(e => e.ManagerID);

            Console.WriteLine("Total groups count = {0}", qe9.Count());
            foreach (var item in qe9)
            {
                Console.WriteLine("Manager id = {0}", item.Key);
                foreach (var e in item)
                {
                    Console.WriteLine(" Employee id = {0}", e.ID);
                }
            }

            Console.WriteLine("10" + new string('-', 78));
            foreach (var item in employees.Cast<Employee>().Distinct(new EmployeeComparer()))
            {
                Console.WriteLine(item.ID);
            }

            Console.WriteLine("11" + new string('-', 78));
            var joinIntoGroups = managers.Cast<Manager>()
                                         .GroupJoin(employees.Cast<Employee>(),
                                                    m => m.ID,
                                                    e => e.ManagerID,
                                                    (m, emps) => new { ManagerId = m.ID, Employees = emps });
            Console.WriteLine("Total groups count = {0}", joinIntoGroups.Count());
            foreach (var group in joinIntoGroups)
            {
                Console.WriteLine("Key = {0}", group.ManagerId);
                foreach (var emp in group.Employees)
                {
                    Console.WriteLine(" Employee id = {0}, employee name = {1}", emp.ID, emp.Name);
                }
            }

            /* WORKING WITH GROUPS */
            Console.WriteLine("12" + new string('-', 78));
            string[] wordsSequence = { "SCW10", "SCW1", "SCW2", "SCW11", "NUT10", "NUT1", "NUT2", "NUT11" };
            var qe10 = wordsSequence.GroupBy(w => w == null ? "(null)" : w.Substring(0, 3));
            Console.WriteLine("Group count = {0}", qe10.Count());
            foreach (var group in qe10)
            {
                Console.WriteLine("Key = {0}", group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(" " + item);
                }
            }

            // групування за декількома параметрами
            Console.WriteLine("13" + new string('-', 78));
            var qe11 = employees.Cast<Employee>()
                                .GroupBy(e => new { e.ManagerID, e.Age });
            Console.WriteLine("Groups count = {0}", qe11.Count());
            foreach (var group in qe11)
            {
                Console.WriteLine("Key = {0}", group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(" " + item.ID + " " + item.Name);
                }
            }

            // групування за допомогою кастомного компаратора
            Console.WriteLine("14" + new string('-', 78));
            string[] names = { "Janet", "Janette", "Joanne", "Jo-anne", "Katy", "Katie", "Ralph", "Ralphe", "Ralphe" };
            var qe12 = names.GroupBy(n => n, new SoundexEqualityComparer());

            foreach (var group in qe12)
            {
                Console.WriteLine("Key = {0}", group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(" " + item);
                }
            }

            // використання нуль-оператора в групуванні (n ?? (null) або string.IsNullOrEmpty(n) ? "name" : n)
            Console.WriteLine("15" + new string('-', 78));
            string[] names1 = { "Janet", "Janette", "Joanne", null, "Jo-anne", "Katy", "Katie", "Ralph", "Ralphe", "Ralphe", "" };
            var qe13 = names1.GroupBy(n => string.IsNullOrEmpty(n) ? "(null)" : n,
                                      n => new { Name = string.IsNullOrEmpty(n) ? "name missing" : n });
            foreach (var group in qe13)
            {
                Console.WriteLine("Key = {0}", group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(" " + item.Name);
                }
            }

            // проекція згрупованих даних в локальну змінну через into
            Console.WriteLine("16" + new string('-', 78));
            var qe14 = from e in employees.Cast<Employee>()
                       group e by e.ManagerID into g
                       select new
                       {
                           ManagerId = g.Key,
                           TotalEmployees = g.Count(),
                           TotalYoung = g.Count(e => e.Age < 20),
                           TotalIdsSum = g.Sum(e => e.ID)
                       };

            // в розширюючих методах не потрібно into тут можна писати select доразу після GroupBy            
            var qe15 = employees.Cast<Employee>()
                                .Distinct(new EmployeeComparer())       // вибірка робітників в яких не співпадає ID
                                .GroupBy(e => e.ManagerID)
                                .Select(z => new
                                {
                                    ManagerId = z.Key,
                                    TotalEmployees = z.Count(),
                                    TotalYoung = z.Count(e => e.Age < 20),
                                    TotalIdsSum = z.Sum(e => e.ID),
                                    Employees = z
                                });

            foreach (var emp in qe15)
            {
                Console.WriteLine("Manager id = {0}, TotalEmpoyees = {1}, Total young = {2}, Sum of IDs = {3}",
                    emp.ManagerId, emp.TotalEmployees, emp.TotalYoung, emp.TotalIdsSum);

                foreach (var item in emp.Employees)
                {
                    Console.WriteLine(" " + item.ID);
                }
            }

            // приклад із вкладеними group by
            Console.WriteLine("17" + new string('-', 78));
            var qe16 = from e in employees.Cast<Employee>()
                       select new
                       {
                           EmployeeID = e.ID,
                           EmployeeName = e.Name,
                           YearGroup = from j in jobs
                                       where j.EmployeeId == e.ID
                                       group j by j.Year into groupYear
                                       select new
                                       {
                                           Year = groupYear.Key,
                                           MonthGroup = from m in groupYear
                                                        group m by m.Month
                                       }
                       };

            var qe17 = employees.Cast<Employee>()
                                .Select(e => new
                                {
                                    EmployeeID = e.ID,
                                    EmployeeName = e.Name,
                                    YearGroup = jobs.Where(j => j.EmployeeId == e.ID)
                                                    .GroupBy(j => j.Year)
                                                    .Select(j_yearly => new
                                                    {
                                                        Year = j_yearly.Key,
                                                        YearJobsCount = j_yearly.Count(),
                                                        MonthGroup = j_yearly.GroupBy(j_monthly => j_monthly.Month)
                                                    })
                                });            

            foreach (var emp in qe17)
            {
                Console.WriteLine("Employee : " + emp.EmployeeID + "." + emp.EmployeeName);
                foreach (var yeargroup in emp.YearGroup)
                {
                    Console.WriteLine(" Year : {0}, count = {1}", yeargroup.Year, yeargroup.YearJobsCount);
                    foreach (var month in yeargroup.MonthGroup)
                    {
                        Console.WriteLine("  Month : " + month.Key);
                        foreach (var job in month)
                        {
                            Console.WriteLine("   Job : id = {0}", job.ID);
                        }
                    }
                }
            }

            // вибірка згрупованих job тільки по року
            Console.WriteLine("17_1" + new string('-', 76));
            var qe17_1 = employees.Cast<Employee>()
                                  .Select(e => new
                                  {
                                      EmpId = e.ID,
                                      EmpName = e.Name,
                                      YearGroup = jobs.Where(j => j.EmployeeId == e.ID)
                                                      .GroupBy(j => j.Year)
                                      //.Select(j_yr => new
                                      //{
                                      //    Year = j_yr.Key,
                                      //    Jobs = j_yr
                                      //})
                                  });

            foreach (var emp in qe17_1)
            {
                Console.WriteLine("Eployee id = {0}", emp.EmpId);
                foreach (var year in emp.YearGroup)
                {
                    Console.WriteLine(" Year = {0}", year.Key);
                    foreach (var j in year)
                    {
                        Console.WriteLine("  Job no = {0}", j.ID);
                    }
                }
            }

            // а тепер додамо у вибірку ще й групування робіт по днях
            Console.WriteLine("17_2" + new string('-', 76));
            var qe17_2 = employees.Cast<Employee>()
                                  .Select(e => new
                                  {
                                      EmpId = e.ID,
                                      EmpName = e.Name,
                                      YearGroup = jobs.Where(j => j.EmployeeId == e.ID)
                                                      .GroupBy(j => j.Year)
                                                      .Select(j_yr => new
                                                      {
                                                          Year = j_yr.Key,
                                                          JobsPerYear = j_yr.Count(),
                                                          MonthGroup = j_yr.GroupBy(m => m.Month)
                                                                           .Select(j_mn => new
                                                                           {
                                                                               Month = j_mn.Key,
                                                                               JobsPerMonth = j_mn.Count(),
                                                                               DaysGroup = j_mn.GroupBy(d => d.Day)
                                                                                               .Select(j_d => new
                                                                                               {
                                                                                                   Day = j_d.Key,
                                                                                                   JobsPerDay = j_d.Count(),
                                                                                                   Jobs = j_d
                                                                                               })
                                                                           })
                                                      })
                                  });

            foreach (var emp in qe17_2)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}", emp.EmpId, emp.EmpName);
                foreach (var year in emp.YearGroup)
                {
                    Console.WriteLine(" Year = {0}, jobs per year = {1}", year.Year, year.JobsPerYear);
                    foreach (var month in year.MonthGroup)
                    {
                        Console.WriteLine("  Month = {0}, jobs per month = {1}", month.Month, month.JobsPerMonth);
                        foreach (var day in month.DaysGroup)
                        {
                            Console.WriteLine("   Day = {0}, jobs per day = {1}", day.Day, day.JobsPerDay);
                            foreach (var job in day.Jobs)
                            {
                                Console.WriteLine("    Job no = {0}", job.ID);
                            }
                        }
                    }
                }
            }

            // перепишемо останній запит через join
            Console.WriteLine("18" + new string('-', 78));
            var qe18 = employees.Cast<Employee>()
                                .Join(jobs,
                                      e => e.ID,
                                      j => j.EmployeeId,
                                      (e, j) => new
                                      {
                                          EmployeeId = e.ID,
                                          EmployeeName = e.Name,
                                          Job = j
                                      })
                                 .GroupBy(je => je.EmployeeId)
                                 .Select(je => new
                                 {
                                     EmpId = je.Key,
                                     YearJobs = je.GroupBy(j => j.Job.Year)
                                                  .Select(j => new
                                                  {
                                                      Year = j.Key,
                                                      MonthJobs = j.GroupBy(j1 => j1.Job.Month)
                                                  })
                                 });

            foreach (var emp in qe18)
            {
                Console.WriteLine("Employee id = {0}", emp.EmpId);
                foreach (var year in emp.YearJobs)
                {
                    Console.WriteLine(" Year = {0}", year.Year);
                    foreach (var month in year.MonthJobs)
                    {
                        Console.WriteLine("  Month = {0}", month.Key);
                        foreach (var job in month)
                        {
                            Console.WriteLine("    Job no = {0}", job.Job.ID);
                        }
                    }
                }
            }

            // витягнемо всі роботи для робітника з id=1 сортовані по року,місяцю і дню
            Console.WriteLine("19" + new string('-', 78));
            var qe19 = employees.Cast<Employee>()
                              .Where(e => e.ID == 1)
                              .Select(e => new
                              {
                                  EmployeeId = e.ID,
                                  EmployeeName = e.Name,
                                  YearJobs = jobs.Where(j => j.EmployeeId == e.ID)
                                                 .GroupBy(j => j.Year)
                                                 .Select(j_yr => new
                                                 {
                                                     Year = j_yr.Key,
                                                     MonthJobs = j_yr.GroupBy(j => j.Month)
                                                                     .Select(j_mn => new
                                                                     {
                                                                         Month = j_mn.Key,
                                                                         DayJobs = j_mn.GroupBy(j => j.Day)
                                                                                       .Select(j_d => new
                                                                                       {
                                                                                           Day = j_d.Key,
                                                                                           Jobs = j_d
                                                                                       })
                                                                     })
                                                 })
                              });

            foreach (var emp in qe19)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}", emp.EmployeeId, emp.EmployeeName);
                foreach (var year in emp.YearJobs)
                {
                    Console.WriteLine(" Year = {0}", year.Year);
                    foreach (var month in year.MonthJobs)
                    {
                        Console.WriteLine("  Month = {0}", month.Month);
                        foreach (var day in month.DayJobs)
                        {
                            Console.WriteLine("   Day = {0}", day.Day);
                            foreach (var job in day.Jobs)
                            {
                                Console.WriteLine("    Job no = {0}", job.ID);
                            }
                        }
                    }
                }
            }

            /* WORKING WITH JOINS */
            // cross join в термінах linq операторів
            Console.WriteLine("50" + new string('-', 78));
            var qe50 = from e in employees.Cast<Employee>()
                       from m in managers.Cast<Manager>()
                       select new { e, m };

            foreach (var element in qe50)
            {
                Console.WriteLine("Employee id = {0}, manager id = {1}", element.e.ID, element.m.ID);
            }

            // cross join в термінах розширюючих методів
            Console.WriteLine("51" + new string('-', 78));
            var qe51 = managers.Cast<Manager>()
                               .SelectMany(m => employees.Cast<Employee>(),
                                           (m, e) => new { m, e });
            foreach (var element in qe51)
            {
                Console.WriteLine("Employee id = {0}, manager id = {1}", element.e.ID, element.m.ID);
            }

            // генерування таблиці бінарних чисел за допомогою cross join
            var binary = new int[] { 0, 1 };

            Console.WriteLine("52" + new string('-', 78));
            var qe52 = from b1 in binary
                       from b2 in binary
                       from b3 in binary
                       from b4 in binary
                       select string.Format("{0}{1}{2}{3}",
                                                b1, b2, b3, b4);

            foreach (var item in qe52)
            {
                Console.WriteLine(item);
            }

            // ONE-TO-ONE JOIN
            // -- using 'join' operator
            // -- subquery in 'select' projection
            // -- using 'SingleOrDefault' operator in select projection
            // -- using cross join with 'where' filter

            // можна засвоїти просте правило - коли outer(колекція ліва) містить багато елементів >> inner(права колекція) - JOIN 
            //                               - коли outer(колекція ліва) містить мало елементів < inner(права колекція) - SUBQUERY

            // простий початок join one-to-one
            string[] outer = { "a", "b", "c", "d" };
            string[] inner = { "b", "c", "d", "e", "c" };

            Console.WriteLine("60" + new string('-', 78));
            var qe60 = from s1 in outer
                       join s2 in inner on s1 equals s2
                       select string.Format("Outer :{0}, Inner :{1}", s1, s2);
            foreach (var element in qe60)
            {
                Console.WriteLine(element);
            }

            // inner join для employee + job
            Console.WriteLine("61" + new string('-', 78));
            var qe61 = from e in employees.Cast<Employee>()
                       join j in jobs on e.ID equals j.EmployeeId
                       select new { EmployeeId = e.ID, JobId = j.ID };

            foreach (var raw in qe61)
            {
                Console.WriteLine("Employee id = {0}, job id = {1}", raw.EmployeeId, raw.JobId);
            }

            // теж саме тільки в термінах розширюючих методів
            Console.WriteLine("62" + new string('-', 78));
            var qe62 = employees.Cast<Employee>()
                                .Join(jobs,
                                      e => e.ID,
                                      j => j.EmployeeId,
                                      (e, j) => new { EmployeeId = e.ID, JobId = j.ID })
                                .OrderByDescending(r => r.EmployeeId);
            foreach (var raw in qe62)
            {
                Console.WriteLine("Employee id = {0}, job id = {1}", raw.EmployeeId, raw.JobId);
            }

            // outer join для manager + employee
            Console.WriteLine("63" + new string('-', 78));
            var qe63 = from m in managers.Cast<Manager>()
                       join e in employees.Cast<Employee>()
                         on m.ID equals e.ManagerID into em
                       from element in em.DefaultIfEmpty()
                       select new
                       {
                           ManagerId = m.ID,
                           Employee = element
                       };
            foreach (var raw in qe63)
            {
                Console.WriteLine("Manager ID : {0}, EmployeeId : {1}, EmployeeName : {2}", raw.ManagerId,
                                                                                           raw.Employee == null ? "(no emp)" : raw.Employee.ID.ToString(),
                                                                                           raw.Employee == null ? "(no emp)" : raw.Employee.Name);
            }

            // знаю як зробити проекцію елементів з GroupJoin в послідовність строк
            Console.WriteLine("64" + new string('-', 78));
            var qe64 = managers.Cast<Manager>()
                               .GroupJoin(employees.Cast<Employee>(),
                                          m => m.ID,
                                          e => e.ManagerID,
                                          (m, emps) => new { ManagerId = m.ID, Employees = emps })
                               .SelectMany(r => r.Employees.DefaultIfEmpty(), // завдяки оператору DefaultIfEmpty отримуємо outer join, без нього - inner join
                                          (r, e) => new { ManagerId = r.ManagerId, Employee = e });

            foreach (var raw in qe64)
            {
                Console.WriteLine("Manager ID : {0}, EmployeeId : {1}, EmployeeName : {2}", raw.ManagerId,
                                                                                            raw.Employee == null ? "(no emp)" : raw.Employee.ID.ToString(),
                                                                                            raw.Employee == null ? "(no emp)" : raw.Employee.Name);
            }

            // outer join для manager + employee (робітники пакуються в групи і так же передаються на вихід в select)
            Console.WriteLine("65" + new string('-', 78));
            var qe65 = from m in managers.Cast<Manager>()
                       join e in employees.Cast<Employee>()
                         on m.ID equals e.ManagerID into allEmpls
                       select new
                       {
                           ManagerId = m.ID,
                           Employees = allEmpls
                       };
            foreach (var raw in qe65)
            {
                Console.WriteLine("Manager id : {0}", raw.ManagerId);
                foreach (var emp in raw.Employees)
                {
                    Console.WriteLine(" Employee id : {0}, employee name : {1}", emp.ID, emp.Name);
                }
            }

            // join з складеним ключем
            Console.WriteLine("66" + new string('-', 78));
            var qe66 = from e in employees.Cast<Employee>()
                       join m in managers.Cast<Manager>()
                         on new { ID = e.ManagerID, Age = e.Age } equals
                            new { ID = m.ID, Age = m.Age }
                       select new { ManagerId = m.ID, ManagerName = m.Name, EmployeeId = e.ID, EmployeeName = e.Name, Age = m.Age };
            foreach (var raw in qe66)
            {
                Console.WriteLine("Manager id={0},ManagerName={1},employee id={2},employee name={3} | Age={4}",
                                                            raw.ManagerId, raw.ManagerName, raw.EmployeeId, raw.EmployeeName, raw.Age);
            }

            // join з IEqualityComparer

            // one-to-one join через subquery для employee + job
            Console.WriteLine("68" + new string('-', 78));
            var qe68 = from e in employees.Cast<Employee>()
                       select new
                       {
                           EmployeeId = e.ID,
                           EmployeeName = e.Name,
                           JobInfo = (from j in jobs
                                      where j.EmployeeId == e.ID
                                      select j).ToList()
                       };
            foreach (var raw in qe68)
            {
                Console.WriteLine("Employee ID = {0}, Employee name = {1}", raw.EmployeeId, raw.EmployeeName);
                foreach (var job in raw.JobInfo)
                {
                    Console.WriteLine(" Job no = {0}", job.ID);
                }
            }

            // перепишемо останній запит з subquery через розширені методи
            Console.WriteLine("69" + new string('-', 78));
            var qe69 = employees.Cast<Employee>()
                                .Select(e => new
                                {
                                    EmployeeId = e.ID,
                                    EmployeeName = e.Name,
                                    JobsInfo = jobs.Where(j => j.EmployeeId == e.ID)
                                                   .ToList()
                                });
            foreach (var emp in qe69)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}", emp.EmployeeId, emp.EmployeeName);
                foreach (var job in emp.JobsInfo)
                {
                    Console.WriteLine(" Job no = {0}", job.ID);
                }
            }

            // one-to-one cross join
            Console.WriteLine("70" + new string('-', 78));
            var qe70 = from e in employees.Cast<Employee>()
                       from m in managers.Cast<Manager>()
                       where e.ManagerID == m.ID
                       select new
                       {
                           EmployeeId = e.ID,
                           ManagerId = m.ID
                       };
            foreach (var raw in qe70)
            {
                Console.WriteLine("Manager id = {0}, Employee id = {1}", raw.ManagerId, raw.EmployeeId);
            }

            // Measure performance
            //Console.WriteLine("71" + new string('-', 78));
            //long time = MeasureTime(() => employees.ToList(), 1000000);

            //Console.WriteLine((time / 1000.0).ToString() + " sec");

            // ONE-TO-MANY JOIN
            // -- 'join/into' combination or GroupJoin
            // -- subquery in 'select' projection
            // -- 'ToLookup' operator

            // performance overview :
            // 1. ToLookup is the best in all cases
            // 2. Subquery in select projection
            // 3. join/into (GroupJoin)

            // join/into або GroupInto operator для employee + job
            // елементи з outer колекції будуть у тій послідовності в якій вони були на вході,
            // а елементи з inner будуть в такій як були вони теж на вході і якщо потрібно для них
            // змінити порядок то слід застосувати subquery in select projection замість GroupJoin
            Console.WriteLine("71" + new string('-', 78));
            var qe71 = from e in employees.Cast<Employee>()
                       join j in jobs on e.ID equals j.EmployeeId
                        into j_coll
                       select new
                       {
                           EmployeeId = e.ID,
                           EmployeeName = e.Name,
                           Jobs = j_coll
                       };

            foreach (var raw in qe71)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}", raw.EmployeeId, raw.EmployeeName);
                foreach (var job in raw.Jobs)
                {
                    Console.WriteLine(" Job no = {0}", job.ID);
                }
            }

            // теж саме через розширюючий метод
            Console.WriteLine("71_1" + new string('-', 76));
            var qe71_1 = managers.Cast<Manager>()
                                 .GroupJoin(employees.Cast<Employee>(),
                                            m => m.ID,
                                            e => e.ManagerID,
                                            (m, emps) => new { ManagerId = m.ID, ManagerName = m.Name, Employees = emps })
                                 .SelectMany(r => r.Employees.DefaultIfEmpty(),
                                            (r, e) => new { ManagerId = r.ManagerId, ManagerName = r.ManagerName, Employee = e })
                                 .Where(r => r.Employee == null);

            foreach (var raw in qe71_1)
            {
                Console.WriteLine("Manager id = {0}, manager name = {1}, employee id = {2}",
                                                raw.ManagerId, raw.ManagerName, raw.Employee != null ? raw.Employee.ID : -1);
            }

            // теж саме але для employee + job
            Console.WriteLine("71_2" + new string('-', 76));
            var qe71_2 = employees.Cast<Employee>()
                                  .GroupJoin(jobs,
                                             e => e.ID,
                                             j => j.EmployeeId,
                                             (e, jbs) => new { EmployeeId = e.ID, EmployeeName = e.Name, Jobs = jbs })
                                  .SelectMany(r => r.Jobs.DefaultIfEmpty(),
                                             (r, j) => new { EmployeeId = r.EmployeeId, EmployeeName = r.EmployeeName, Job = j })
                                  .Where(r => r.Job == null);

            foreach (var raw in qe71_2)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}, job no = {2}",
                                    raw.EmployeeId, raw.EmployeeName, raw.Job != null ? raw.Job.ID : -1);
            }

            // теж саме але з subquery
            Console.WriteLine("71_3" + new string('-', 76));
            var qe71_3 = employees.Cast<Employee>()
                                  .Select(e => new
                                  {
                                      EmployeeId = e.ID,
                                      EmployeeName = e.Name,
                                      Job = jobs.Where(j => j.EmployeeId == e.ID).FirstOrDefault()
                                  })
                                  .Where(r => r.Job == null);
            foreach (var raw in qe71_3)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}, job id = {2}",
                                        raw.EmployeeId, raw.EmployeeName, raw.Job != null ? raw.Job.ID : -1);
            }

            Console.WriteLine("71_4" + new string('-', 76));
            var qe71_4 = jobs.ToLookup(j => j.EmployeeId);

            foreach (var job_group in qe71_4)
            {
                Console.WriteLine("Employee id = {0}", job_group.Key);
                foreach (var job in job_group)
                {
                    Console.WriteLine(" Job no = {0}", job.ID);
                }
            }

            // one tom many через subquery
            Console.WriteLine("72" + new string('-', 78));
            var qe72 = from e in employees.Cast<Employee>()
                       select new
                       {
                           EmployeeId = e.ID,
                           EmployeeName = e.Name,
                           Jobs = from j in jobs
                                  where j.EmployeeId == e.ID
                                  select j
                       };
            foreach (var raw in qe72)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}", raw.EmployeeId, raw.EmployeeName);
                foreach (var job in raw.Jobs)
                {
                    Console.WriteLine(" Job no = {0}", job.ID);
                }
            }

            // теж саме тільки через розширюючі методи
            Console.WriteLine("73" + new string('-', 78));
            var qe73 = employees.Cast<Employee>()
                                .Select(e => new
                                {
                                    EmployeeId = e.ID,
                                    EmployeeName = e.Name,
                                    Jobs = jobs.Where(j => j.EmployeeId == e.ID)
                                });
            foreach (var raw in qe73)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}", raw.EmployeeId, raw.EmployeeName);
                foreach (var job in raw.Jobs)
                {
                    Console.WriteLine(" Job no = {0}", job.ID);
                }
            }

            // builds a lookup list for the inner sequence
            Console.WriteLine("74" + new string('-', 78));
            var jobs_lookup_list = jobs.ToLookup(j => j.EmployeeId);
            var qe74 = employees.Cast<Employee>()
                                .Select(e => new
                                {
                                    EmployeeId = e.ID,
                                    EmployeeName = e.Name,
                                    Jobs = jobs_lookup_list[e.ID]
                                });
            foreach (var raw in qe74)
            {
                Console.WriteLine("Employee id = {0}, employee name = {1}", raw.EmployeeId, raw.EmployeeName);
                foreach (var job in raw.Jobs)
                {
                    Console.WriteLine(" Job no = {0}", job.ID);
                }
            }
            // через ToLookup
            long time;
            time = MeasureTime(() =>
            {
                Console.WriteLine("75" + new string('-', 78));
                var jobs_lookup = jobs.ToLookup(j => j.EmployeeId);
                var qe75 = employees.Cast<Employee>()
                                    .Select(e => new
                                    {
                                        EmployeeId = e.ID,
                                        EmployeeName = e.Name,
                                        Jobs = jobs_lookup[e.ID]
                                    });

                foreach (var emp in qe75)
                {
                    Console.WriteLine("Employee id = {0}, employee name = {1}", emp.EmployeeId, emp.EmployeeName);
                    foreach (var job in emp.Jobs)
                    {
                        Console.WriteLine(" Job id = {0}", job.ID);
                    }
                }
            }, 1);
            Console.WriteLine("Time elaplsed : {0}", time);

            time = MeasureTime(() =>
            {
                Console.WriteLine("76" + new string('-', 78));
                var qe76 = employees.Cast<Employee>()
                                    .GroupJoin(jobs,
                                               e => e.ID,
                                               j => j.EmployeeId,
                                               (e, js) => new { EmployeeId = e.ID, EmployeeName = e.Name, Jobs = js });
                foreach (var emp in qe76)
                {
                    Console.WriteLine("Employee id = {0}, employee name = {1}", emp.EmployeeId, emp.EmployeeName);
                    foreach (var job in emp.Jobs)
                    {
                        Console.WriteLine(" Job id = {0}", job.ID);
                    }
                }
            }, 1);
            Console.WriteLine("Time elaplsed : {0}", time);

            /* AGGREGATION OPERATION */
            Console.WriteLine();
            Console.WriteLine(new string('*', 80));
            Console.WriteLine(new string('*', 80));
            Console.WriteLine(new string('*', 80));

            // Aggregate
            int[] n_arr1 = { 1, 2, 3 };

            // summ and add 100 to result
            Console.WriteLine("1" + new string('-', 79));
            var sum = n_arr1.Aggregate(0, (acc, i) => acc + i, acc => acc + 100);
            Console.WriteLine("Summ = {0}", sum);

            // calculate average
            Console.WriteLine("2" + new string('-', 79));
            int count = 0;
            var avg = n_arr1.Aggregate(0, (acc, i) =>
             {
                 count += 1;
                 acc += i;
                 return acc;
             }, acc => count > 0 ? acc / count : 0);
            Console.WriteLine("Avg value = {0}", avg);

            // calculate persentage employees / jobs            
            Console.WriteLine("3" + new string('-', 79));
            var emp_jobs_perc = employees.Cast<Employee>()
                                         .Aggregate(0, (acc, e) =>
                                          {
                                              acc += jobs.Where(j => j.EmployeeId == e.ID).Count() > 0 ? 1 : 0;
                                              return acc;
                                          }, acc => (double)acc / employees.Count() * 100);
            Console.WriteLine("Total employees jobs = {0}", emp_jobs_perc);

            // теж саме тільки через Any
            Console.WriteLine("3_1" + new string('-', 77));
            var emp_jobs_perc1 = employees.Cast<Employee>()
                                          .Aggregate(0, (acc, e) =>
                                           {
                                               acc += jobs.Any(j => j.EmployeeId == e.ID) ? 1 : 0;
                                               return acc;
                                           }, acc => (double)acc / employees.Count * 100);
            Console.WriteLine("Total employees jobs = {0}", emp_jobs_perc1);

            // кількість менеджерів які мають підлеглих
            Console.WriteLine("4" + new string('-', 79));
            var real_mngs_count = managers.Cast<Manager>()
                                          .Aggregate(0, (acc, m) =>
                                           {
                                               acc += employees.Cast<Employee>().Count(e => e.ManagerID == m.ID) > 0 ? 1 : 0;
                                               return acc;
                                           }, acc => acc);
            Console.WriteLine("Real managers count = {0}", real_mngs_count);

            // теж саме тільки через Any
            Console.WriteLine("4_1" + new string('-', 77));
            var real_mngs_count1 = managers.Cast<Manager>()
                                           .Aggregate(0, (acc, m) =>
                                           {
                                               acc += employees.Cast<Employee>().Any(e => e.ManagerID == m.ID) ? 1 : 0;
                                               return acc;
                                           }, acc => acc);
            Console.WriteLine("Real managers count = {0}", real_mngs_count1);

            // max/min функції
            var letters = new char[] { 'v', 'e', 'x', 'a' };
            var min1 = letters.Min();
            var max1 = letters.Max();

            // ToDictionary
            Console.WriteLine("5" + new string('-', 79));
            var emp_dict = employees.Cast<Employee>()
                                    .ToDictionary(e => e.Name, e => e, new EmployeeDictionaryComparer());

            foreach (var emp in emp_dict)
            {
                Console.WriteLine(emp.Key + " : " + emp.Value.ID);
            }

            // ToList
            Console.WriteLine("6" + new string('-', 79));
            var qe_range = Enumerable.Range(10, 5);
            List<int> qe_to_list = (from e in qe_range
                                    where e < 13
                                    select e).ToList();
            foreach (var elem in qe_to_list)
            {
                Console.WriteLine(elem);
            }

            // ToLookup
            Console.WriteLine("7" + new string('-', 79));
            var emp_lookup = employees.Cast<Employee>()
                                      .ToLookup(e => e.Name, e => e)
                                      .SelectMany(e => e,
                                                 (e, emp) => new { Key = e.Key, Employee = emp });

            foreach (var emp in emp_lookup)
            {
                Console.WriteLine(emp.Key + " : " + emp.Employee.ID);
            }

            // Build lookup list of employees by manager id
            Console.WriteLine("8" + new string('-', 79));
            var emp_lookup_by_mng = employees.Cast<Employee>().ToLookup(e => e.ManagerID);
            var managers_with_emps_lookup = managers.Cast<Manager>()
                                                    .Select(m => new
                                                    {
                                                        ManagerId = m.ID,
                                                        ManagerName = m.Name,
                                                        Employees = emp_lookup_by_mng[m.ID]
                                                    });
            foreach (var manager in managers_with_emps_lookup)
            {
                Console.WriteLine("Manager id = {0}, manager name = {1}, total employees = {2}",
                                    manager.ManagerId, manager.ManagerName, manager.Employees.Count());
                foreach (var employee in manager.Employees)
                {
                    Console.WriteLine(" Employee id = {0}, employee name = {1}", employee.ID, employee.Name);
                }
            }

            // to lookup jobs + employees
            //var jobs_look_list = jobs.ToLookup(j => j.EmployeeId);
            Console.WriteLine("9" + new string('-', 79));
            var some_join_emp_jobs = employees.Cast<Employee>()
                                              .GroupJoin(jobs,
                                                         e => e.ID,
                                                         j => j.EmployeeId,
                                                         (e, jbs) => new
                                                         {
                                                             EmployeeId = e.ID,
                                                             EmployeeName = e.Name,
                                                             Jobs = jbs.Select(j => new
                                                             {
                                                                 Job = j,
                                                                 JobDescr = job_description.Where(jd => jd.ID == j.ID)
                                                                                           .Select(jd => jd.Description)
                                                                                           .FirstOrDefault()
                                                             })
                                                         })
                                              .SelectMany(r => r.Jobs.DefaultIfEmpty(),
                                                         (r, jbs) => new
                                                         {
                                                             EmployeeId = r.EmployeeId,
                                                             EmployeeName = r.EmployeeName,
                                                             Job = jbs
                                                         });
            foreach (var raw in some_join_emp_jobs)
            {
                Console.WriteLine("Employee id ={0}, employee name ={1}, job no ={2}, job desc ={3}",
                                    raw.EmployeeId, raw.EmployeeName, raw.Job != null ? raw.Job.Job.ID : -1,
                                                                      raw.Job != null ? raw.Job.JobDescr : "no desc");
            }

            // manager + employee with jobs and every job has description
            Console.WriteLine("9_1" + new string('-', 77));
            var mang_with_emp_jobs = managers.Cast<Manager>()
                                             .GroupJoin(employees.Cast<Employee>(),
                                                        m => m.ID,
                                                        e => e.ManagerID,
                                                        (m, emps) => new
                                                        {
                                                            ManagerId = m.ID,
                                                            ManagerName = m.Name,
                                                            ManagersEmployeesCount = emps.Count(),
                                                            ManagersEmployees = emps.Select(e => new
                                                            {
                                                                EmployeeId = e.ID,
                                                                EmployeeName = e.Name,
                                                                EmployeeJobs = jobs.Where(j => j.EmployeeId == e.ID)
                                                                                   .Select(j => new
                                                                                   {
                                                                                       Job = j,
                                                                                       JobDesc = job_description.Where(jd => jd.ID == j.ID)
                                                                                                                .Select(jd => jd.Description)
                                                                                                                .FirstOrDefault()
                                                                                   })
                                                            })
                                                        })
                                              .SelectMany(r => r.ManagersEmployees.DefaultIfEmpty(),
                                                         (r, e) => new
                                                         {
                                                             ManagerId = r.ManagerId,
                                                             ManagerName = r.ManagerName,
                                                             ManagersEmployeesCount = r.ManagersEmployeesCount,
                                                             ManagerEmployee = e,
                                                             ManagerEmployeeJobsCount = e != null ? e.EmployeeJobs.Count() : 0
                                                         });
            //foreach (var raw in mang_with_emp_jobs)
            //{
            //    Console.WriteLine("Manager id ={0}, manager name ={1}, total emps ={2}, emp id ={3},emp name ={4}",
            //                         raw.ManagerId, raw.ManagerName, raw.ManagersEmployeesCount,
            //                         raw.ManagerEmployee != null ? raw.ManagerEmployee.EmployeeId : -1,
            //                         raw.ManagerEmployee != null ? raw.ManagerEmployee.EmployeeName : "no name");
            //    if (raw.ManagerEmployee != null)
            //        foreach (var job in raw.ManagerEmployee.EmployeeJobs)
            //        {
            //            Console.WriteLine(" Job no = {0}, descr = {1}", job.Job.ID, job.JobDesc);
            //        }
            //}

            foreach (var raw in mang_with_emp_jobs)
            {
                Console.WriteLine("Manager id ={0}, manager name ={1}, total emps ={2}, emp id ={3},emp jbscnt ={4}",
                                     raw.ManagerId, raw.ManagerName, raw.ManagersEmployeesCount,
                                     raw.ManagerEmployee != null ? raw.ManagerEmployee.EmployeeId : -1,
                                     raw.ManagerEmployeeJobsCount);
            }

            // таке як попереднє - 1 тільки через ToLookup
            Console.WriteLine("10" + new string('-', 78));
            var jobs_with_desc_lookup = jobs.ToLookup(j => j.EmployeeId,
                                                      j => new
                                                      {
                                                          Job = j,
                                                          JobDesc = job_description.Where(jd => jd.ID == j.ID)
                                                                                   .Select(jd => jd.Description)
                                                                                   .FirstOrDefault()
                                                      });
            var emps_with_jobs_lookup = employees.Cast<Employee>()
                                                 .Select(e => new
                                                 {
                                                     EmployeeId = e.ID,
                                                     EmployeeName = e.Name,
                                                     Jobs = jobs_with_desc_lookup[e.ID]
                                                 })
                                                 .SelectMany(r => r.Jobs.DefaultIfEmpty(),
                                                            (r, jbs) => new
                                                            {
                                                                EmployeeId = r.EmployeeId,
                                                                EmployeeName = r.EmployeeName,
                                                                Job = jbs
                                                            });
            foreach (var raw in emps_with_jobs_lookup)
            {
                Console.WriteLine("Employee id ={0}, employee name ={1}, job no ={2}, job desc ={3}",
                                    raw.EmployeeId, raw.EmployeeName, raw.Job != null ? raw.Job.Job.ID : -1,
                                                                      raw.Job != null ? raw.Job.JobDesc : "no desc");
            }

            // Merge operator - Zip
            Console.WriteLine("11" + new string('-', 78));
            var letters_1 = new string[] { "A", "B", "C", "D", "E", "S" };
            var numbers_1 = new int[] { 1, 2, 3 };

            var letters_merged_nums = letters_1.Zip(numbers_1, (s, i) => s + i.ToString());
            foreach (var raw in letters_merged_nums)
            {
                Console.WriteLine(raw);
            }

            // Skip while and Take while
            Console.WriteLine("12" + new string('-', 78));
            string sampleString = @"# comment line 1
                                    # comment line 2
                                    Data line 1
                                    Data line 2

                                    This line is ignored.";
            var skip_take_qe = sampleString.Split('\n')
                                           .SkipWhile(s => s.StartsWith("#"))
                                           .TakeWhile(s => !string.IsNullOrEmpty(s.Trim()))
                                           .Select(s => s.Trim()); ;
            foreach (var s in skip_take_qe)
            {
                Console.WriteLine(s);
            }

            // Quintifier operators
            // All operator            
            Console.WriteLine("13" + new string('-', 78));
            var evens = new int[] { 2, 4, 6, 8, 10 };
            var odds = new int[] { 1, 3, 5, 7, 9 };
            var nums = Enumerable.Range(1, 10);
            Console.WriteLine("All are : even - {0}, odd - {1}, nums - {2}", evens.All(i => i % 2 == 0),
                                                                            odds.All(i => i % 2 == 0),
                                                                            nums.All(i => i % 2 == 0));
            // Any operator
            Console.WriteLine("14" + new string('-', 78));
            var empty_any = Enumerable.Empty<int>();
            var one_any = new int[] { 1 };
            var many_any = Enumerable.Range(1, 5);

            Console.WriteLine("Empty : {0}, One : {1}, Many : {2}",
                                    empty_any.Any(), one_any.Any(), many_any.Any());

            Console.WriteLine("15" + new string('-', 78));
            string[] animals_for_any = { "Koala", "Kangaroo", "Spider", "Wombat", "Snake", "Emu", "Shark", "Jellyfish" };

            bool anyFish = animals_for_any.Any(s => s.Contains("fish"));
            bool anyCats = animals_for_any.Any(s => s.Contains("cat"));

            Console.WriteLine("Any fish ? {0}, Any cats ? {1}", anyFish, anyCats);

            // Contains operator
            Console.WriteLine("15" + new string('-', 78));
            string[] names_contains = { "peter", "paul", "mary" };
            bool b1_1 = names_contains.Contains("PETER");
            bool b2_1 = names_contains.Contains("peter");
            bool b3_1 = names_contains.Contains("PETER", StringComparer.InvariantCultureIgnoreCase);

            Console.WriteLine("PETER : {0}, peter : {1}, PETER : {2}", b1_1, b2_1, b3_1);

            /* WORKINH WITH SET OF DATA */
            // Concat operator
            Console.WriteLine();
            Console.WriteLine(new string('*', 80));
            Console.WriteLine(new string('*', 80));
            Console.WriteLine(new string('*', 80));

            // Concat collections
            // Combine the contents of two collections.
            // Returns all elements from first collection
            // then all elements from second collection
            Console.WriteLine("1" + new string('-', 79));
            int[] simple_ints1 = { 1, 2, 3, 4, 4 };
            int[] simple_ints2 = { 4, 5, 6, 7, 8 };
            int[] simple_ints3 = { 1, 2, 3, 4, 4, 6 };
            int[] simple_ints4 = { 1, 2, 3, 4, 4 };
            var sod_qe1 = simple_ints1.Concat(simple_ints2);
            foreach (var item in sod_qe1)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            // Union operator
            Console.WriteLine("2" + new string('-', 79));
            var sod_qe2 = simple_ints1.Union(simple_ints2);
            foreach (var item in sod_qe2)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            // Union для strings
            Console.WriteLine("3" + new string('-', 79));
            string[] simple_strings1 = { "hello", "world", "and", "good", "bye", "bye", "BYE", "some", "some" };
            string[] simple_strings2 = { "HELLO", "WORLD", "AND", "GOOD", "BYE" };
            var sod_qe3 = simple_strings1.Union(simple_strings2, new MyStringComparer());
            foreach (var item in sod_qe3)
            {
                Console.WriteLine(item);
            }

            // Distinct operator
            // Returns unique elements from source collection
            Console.WriteLine("4" + new string('-', 79));
            var sod_qe4 = simple_strings1.Distinct(new MyStringComparer());
            foreach (var item in sod_qe4)
            {
                Console.WriteLine(item);
            }

            // теж саме але через стандартний компаратор
            Console.WriteLine("5" + new string('-', 79));
            var sod_qe5 = simple_strings1.Distinct(StringComparer.CurrentCultureIgnoreCase);
            foreach (var item in sod_qe5)
            {
                Console.WriteLine(item);
            }

            // Except operator - бере ті елементи першої колекції які не зустрічаються в другій колекції
            // Returns elements from the source collection
            // that are NOT in the second collection using the EqualityComparer<TSource>.Default comparer to compare elements
            Console.WriteLine("6" + new string('-', 79));
            var sod_qe6 = simple_strings1.Except(simple_strings2, StringComparer.InvariantCultureIgnoreCase);
            foreach (var item in sod_qe6)
            {
                Console.WriteLine(item);
            }

            // Intersect - генерує колекцію елементів які зутрічаються в обидвох колекціях
            // Returns the elements from source collection
            // that ARE ALSO in the second collection using the EqualityComparer<TSource>.Default comparer to compare elements
            Console.WriteLine("7" + new string('-', 79));
            var sod_qe7 = simple_strings1.Intersect(simple_strings2);
            foreach (var item in sod_qe7)
            {
                Console.WriteLine(item);
            }

            // теж саме але з компаратором
            Console.WriteLine("8" + new string('-', 79));
            var sod_qe8 = simple_strings1.Intersect(simple_strings2, StringComparer.CurrentCultureIgnoreCase);
            foreach (var item in sod_qe8)
            {
                Console.WriteLine(item);
            }

            // Union operator - повертає унікальні елементи з обидвох колекцій
            // Combines elements of two collections.
            // Returns all elements from first collection, then all elements from second collection
            // Duplicate elements are removed (only the first occurance is returned)

            // lookup recent phone number OR contact first and last names
            // to incrementally build a convenient picklist on partial user 
            // entry (narrow the list as data is typed).
            Console.WriteLine("9" + new string('-', 79));
            string userEntry = "096";
            var sod_qe9 = (contacts.Where(cn => cn.FirstName.Contains(userEntry) ||
                                               cn.LastName.Contains(userEntry))
                                  .Select(cn => new { Display = cn.FirstName + " " + cn.LastName })
                          //.Distinct() 
                          )
                          .Union    // коли використовується Union - distinct не обовязковий бо Union все одно видаляє дублікати елементів
                          (
                           callLog.Where(clog => clog.Incoming == true &&
                                                 clog.Number.Contains(userEntry))
                                  .Select(clog => new { Display = clog.Number })
                          //.Distinct()
                          );
            foreach (var item in sod_qe9)
            {
                Console.WriteLine(item.Display);
            }

            // HashSet<T> - unordered collection containing unique elements and provides a set of standart set 
            // operators such as intersecton and union plus many more.
            // It has the standart operations Add,Remove,Contains but because it uses a hash-based implementation
            // for object identity, these operations are immediatelly accessible without looping the entire
            // list as occurs in List<T>
            Console.WriteLine("10" + new string('-', 78));
            HashSet<int> hash_qe10 = new HashSet<int>(simple_ints1);
            Console.WriteLine("before UnionWith");
            foreach (var item in hash_qe10)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            // UNION = 1 | 1 + distinct
            // SYMMETRIC EXCEPTION WITH = 1 ^ 1

            // SymmetricExceptWith - a.Except(b).Concat(b.Except(a)) - return elements that appear in either
            // collections, but not both. This is XOR on two collections.
            hash_qe10.SymmetricExceptWith(simple_ints2);  // різниця в тому що якщо в обидвох колекціях є однакові дані то ці елементи не будуть включені
            //hash_qe10.UnionWith(simple_ints2);
            //var hash_qe10_1 = simple_ints1.Except(simple_ints2).Concat(simple_ints2.Except(simple_ints1));
            //var hash_qe10_1 = simple_ints1.Union(simple_ints2);            

            Console.WriteLine("after UnionWith (SymmetricExceptWith)");
            foreach (var item in hash_qe10)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            // returns only even numbers from set
            Console.WriteLine("11" + new string('-', 78));
            var hash_qe11 = hash_qe10.Where(i => i % 2 == 0)
                                     .Select(i => i);
            foreach (var item in hash_qe11)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            // Overlap = b.Intersect(a).Distinct().Any() - returns true if
            // any element in the given collection are present in the second collection
            Console.WriteLine("12" + new string('-', 78));
            var hash_qe12 = hash_qe10.Overlaps(simple_ints2);
            var hash_qe13 = simple_ints1.Intersect(simple_ints2).Distinct().Any();
            Console.WriteLine(hash_qe12 + " : " + hash_qe13);

            // IsSubsetOf - return the boolean value of true if all of the elements
            // in the given collection are present in the second collection. Will return true
            // if collections share the same elements
            Console.WriteLine("13" + new string('-', 78));
            HashSet<int> hash_qe15 = new HashSet<int>(simple_ints1);
            var hash_qe14 = hash_qe15.IsSubsetOf(simple_ints1);
            var hash_qe16 = simple_ints1.Distinct().Count();
            var hash_qe17 = simple_ints1.Intersect(simple_ints2).Distinct().Count();
            Console.WriteLine(hash_qe14 + " : " + (hash_qe16 == hash_qe17));

            // IsProperSubsetOf - returns the boolean value of true if all of the elements
            // in the given collection are present in the second collection. Will retutn the false if
            // the collection are share exactly the same elements; the collection must be an actual subset
            // with at least one element less than in the second collection 
            Console.WriteLine("14" + new string('-', 78));
            var hash_qe18 = hash_qe15.IsProperSubsetOf(simple_ints3);
            var hash_qe19 = simple_ints1.Distinct().Count();
            var hash_qe20 = simple_ints3.Distinct().Count();
            var hash_qe21 = simple_ints1.Intersect(simple_ints3).Distinct().Count();
            var hash_qe22 = (hash_qe21 < hash_qe20) && (hash_qe21 == hash_qe19);
            Console.WriteLine(hash_qe18 + " : " + hash_qe22);

            // IsSupersetOf - returns the boolean value of true if all of the elements
            // in the second collection are present in the given collection. Will returns true if 
            // collections share the same elements
            Console.WriteLine("15" + new string('-', 78));
            var hash_qe23 = hash_qe15.IsSupersetOf(simple_ints2);
            var hash_qe24 = hash_qe15.Intersect(simple_ints2).Distinct().Count() == hash_qe15.Distinct().Count();
            Console.WriteLine(hash_qe23);

            // IsProperSupersetOf - returns true if all elements in the second collection are present
            // in the given collection. Will return false if collections share the same elements.
            Console.WriteLine("16" + new string('-', 78));
            var hash_qe25 = hash_qe15.IsProperSupersetOf(simple_ints4);
            var hash_qe26 = (simple_ints1.Distinct().Count() > simple_ints4.Intersect(simple_ints1).Distinct().Count()) &&
                            (simple_ints4.Intersect(simple_ints1).Distinct().Count() == simple_ints4.Distinct().Count());
            Console.WriteLine(hash_qe25 + " : " + hash_qe26);

            // SetEquals - returns true if both collection share the same distinct element value
            Console.WriteLine("17" + new string('-', 78));
            var hash_qe27 = hash_qe15.SetEquals(simple_ints4);
            var hash_qe28 = simple_ints1.Distinct().OrderBy(x => x)
                                        .SequenceEqual(
                            simple_ints4.Distinct().OrderBy(y => y));
            Console.WriteLine(hash_qe27 + " : " + hash_qe28);

            /* WRITING GROUP OPERATOR */
            var elements_to_group = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            Console.WriteLine("======================");
            Console.WriteLine(Math.Ceiling((double)10 / 3));

            Console.ReadLine();
        }

        static long MeasureTime(Action action, int iterations)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }

    // Some usefull methods that doesn't exists in LINQ
    public static class LinqExtensions
    {
        public static IEnumerable<T> SymmetricExcept<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source collection is null");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target collection is null");
            }
            return source.Except(target)
                         .Concat(
                   target.Except(source));
        }

        public static bool Overlaps<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source collection is null");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target collection is null");
            }
            return target.Intersect(source).Distinct().Any();
        }

        public static bool IsSupersetOf<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source collection is null");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target collection is null");
            }
            return target.Intersect(source).Distinct().Count() == target.Distinct().Count();
        }

        public static bool IsProperSupersetOf<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source collection is null");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target collection is null");
            }

            var sourceLen = source.Distinct().Count();
            var targetLen = target.Distinct().Count();
            var intersectLen = target.Intersect(source).Distinct().Count();
            return (intersectLen < sourceLen) && intersectLen == targetLen;
        }

        public static bool IsSubsetOf<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source collection is null");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target collection is null");
            }
            return IsSupersetOf(target, source);
        }

        public static bool IsProperSubsetOf<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source collection is null");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target collection is null");
            }
            return IsProperSupersetOf(target, source);
        }

        public static bool SetEquals<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source collection is null");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target collection is null");
            }
            return source.Distinct().OrderBy(x => x)
                         .SequenceEqual(
                   target.Distinct().OrderBy(y => y));
        }

        public static T Last<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source collection is null");
            }

            IList<T> source_as_list = source as IList<T>;
            if (source_as_list != null)
            {
                if (source_as_list.Count > 0)
                {
                    return source_as_list[source_as_list.Count - 1];
                }
            }
            else
            {
                using (IEnumerator<T> enumerator = source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        T current;
                        do
                        {
                            current = enumerator.Current;
                        } while (enumerator.MoveNext());
                        return current;
                    }
                }
            }
            throw new InvalidOperationException("No element in collections.");
        }

        public static T LastOrDefault<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source collection is null");
            }

            IList<T> source_as_list = source as IList<T>;
            if (source_as_list != null)
            {
                if (source_as_list.Count > 0)
                {
                    return source_as_list[source_as_list.Count - 1];
                }
            }
            else
            {
                using (IEnumerator<T> enumerator = source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        T current;
                        do
                        {
                            current = enumerator.Current;
                        } while (enumerator.MoveNext());
                        return current;
                    }
                }
            }
            return default(T);
        }

        public static T RandomElement<T>(this IEnumerable<T> source, int seed = 0)
        {
            int count = 0;

            // Throw exception in case of null source collection
            if (source == null)
            {
                throw new ArgumentNullException("Source collection is null");
            }

            // Try to cast source collection to ICollection for best performance
            // when count elements
            ICollection<T> source_as_icollection = source as ICollection<T>;
            if (source_as_icollection != null)
            {
                count = source_as_icollection.Count;
            }
            else
            {
                count = source.Count();
            }

            // Throw exception in case of empty collection
            if (count == 0)
            {
                throw new InvalidOperationException("No elements in collection.");
            }

            // Check for start value
            Random random = seed == 0 ? new Random() : new Random(seed);

            // IList implements access by index
            IList<T> source_as_ilist = source as IList<T>;
            if (source_as_ilist != null)
            {
                return source_as_ilist[random.Next(0, count)];
            }
            else
            {
                int rand = random.Next(0, count);
                using (IEnumerator<T> enumerator = source.GetEnumerator())
                {
                    enumerator.MoveNext();
                    while (rand > 0)
                    {
                        enumerator.MoveNext();
                        rand--;
                    }
                    return enumerator.Current;
                }
            }
        }

        public static T RandomElementOrDefault<T>(this IEnumerable<T> source, int seed = 0)
        {
            int count = 0;

            // Throw exception in case of null source collection
            if (source == null)
            {
                throw new ArgumentNullException("Source collection is null");
            }

            // Try to cast source collection to ICollection for best performance
            // when count elements
            ICollection<T> source_as_icollection = source as ICollection<T>;
            if (source_as_icollection != null)
            {
                count = source_as_icollection.Count;
            }
            else
            {
                count = source.Count();
            }

            // Throw exception in case of empty collection
            if (count == 0)
            {
                return default(T);
            }

            // Check for start value
            Random random = seed == 0 ? new Random() : new Random(seed);

            // IList implements access by index
            IList<T> source_as_ilist = source as IList<T>;
            if (source_as_ilist != null)
            {
                return source_as_ilist[random.Next(0, count)];
            }
            else
            {
                int rand = random.Next(0, count);
                using (IEnumerator<T> enumerator = source.GetEnumerator())
                {
                    enumerator.MoveNext();
                    while (rand > 0)
                    {
                        enumerator.MoveNext();
                        rand--;
                    }
                    return enumerator.Current;
                }
            }
        }

        public static IEnumerable<T> WhereClause<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> TakeRange<T>(this IEnumerable<T> source, Func<T, bool> startPredicate, Func<T, bool> endPredicate)
        {
            return source.TakeRangeIterator(startPredicate, endPredicate);
        }

        public static IEnumerable<T> TakeRange<T>(this IEnumerable<T> source, Func<T, bool> endPredicate)
        {
            return source.TakeRangeIterator(t => true, endPredicate);
        }

        private static IEnumerable<T> TakeRangeIterator<T>(this IEnumerable<T> source, Func<T, bool> startPredicate, Func<T, bool> endPredicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source collection is null");
            }
            if (startPredicate == null)
            {
                throw new ArgumentNullException("Start predicate is null");
            }
            if (endPredicate == null)
            {
                throw new ArgumentNullException("End predicate is null");
            }

            bool foundStart = false;

            foreach (var item in source)
            {
                if (startPredicate(item))
                {
                    foundStart = true;
                }
                if (foundStart)
                {
                    if (endPredicate(item))
                    {
                        yield break;
                    }
                    else
                    {
                        yield return item;
                    }
                }
            }
        }

        public static IEnumerable<IGrouping<int,TElement>> Segment<TElement>(this IEnumerable<TElement> source,int segments)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }
            if(segments <= 0)
            {
                throw new ArgumentOutOfRangeException("segments");
            }
            return source.SegmentIterator(segments);
        }

        private static IEnumerable<IGrouping<int, TElement>> SegmentIterator<TElement>(this IEnumerable<TElement> source, int segments)
        {
            int count = source.Count();
            int perSegment = (int)Math.Ceiling((double)count / segments);
            Grouping<int, TElement>[] groups = new Grouping<int, TElement>[segments];

            // initialize groups
            for (int i = 0; i < segments; i++)
            {
                groups[i] = new Grouping<int, TElement>(perSegment) { Key = i + 1 };
            }

            // add elements into groups            
            int segment = 0;
            int index_of_element = 0;
            Grouping<int, TElement> g = groups[segment];
            using(IEnumerator<TElement> e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    g.Add(e.Current);
                    index_of_element++;

                    if(segment < segments - 1 && index_of_element == perSegment)
                    {
                        yield return g;
                        index_of_element = 0;
                        segment++;
                        g = groups[segment];                        
                    }
                }
            }
            
            // якщо останній сегмент не заповнений до кінця без цього уривка не відбудеться його повернення
            while(segment < segments)
            {
                yield return groups[segment];
                segment++;
            }
        }
    }

    class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IList<TElement>
    {
        private int count;
        private TElement[] elements;
        private TKey key;

        public Grouping(int size)
        {
            count = 0;
            elements = new TElement[size];
        }

        public TKey Key
        {
            get { return key; }
            set { key = value; }
        }
        public IEnumerator<TElement> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public TElement this[int index]
        {
            get
            {
                if (index < 0 || index > count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return elements[index];
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public int Count
        {
            get { return count; }
        }
        public bool IsReadOnly
        {
            get { return true; }
        }
        public void Add(TElement item)
        {
            if (elements.Length == count)
            {
                Array.Resize(ref elements, count * 2);
            }
            elements[count++] = item;
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(TElement item)
        {
            return Array.IndexOf(elements, item, 0, count) >= 0;
        }
        public void CopyTo(TElement[] array, int arrayIndex)
        {
            Array.Copy(elements, 0, array, arrayIndex, count);
        }
        public int IndexOf(TElement item)
        {
            return Array.IndexOf(elements, item, 0, count);
        }
        public void Insert(int index, TElement item)
        {
            throw new NotImplementedException();
        }
        public bool Remove(TElement item)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }

    class EmployeeDictionaryComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.InvariantCulture) ? false : false;
        }

        public int GetHashCode(string obj)
        {
            return obj.ToString().GetHashCode();
        }
    }

    class MyStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.CurrentCultureIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return obj.ToLowerInvariant().GetHashCode();
        }
    }

    class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.ToString().GetHashCode();
        }
    }

    class SoundexEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode(string obj)
        {
            int result = 0;

            string s = soundex(obj);
            if (string.IsNullOrEmpty(s) == false)
                result = Convert.ToInt32(s[0]) * 1000 + Convert.ToInt32(s.Substring(1, 3));

            return result;
        }
        public string soundex(string s)
        {
            // Algorithm as listed on
            // http://en.wikipedia.org/wiki/Soundex.
            // builds a string code in the format:
            // [A-Z][0-6][0-6][0-6]
            // based on the phonetic sound of the input.
            if (string.IsNullOrEmpty(s))
                return null;

            StringBuilder result = new StringBuilder();

            // As long as there is at least one character we can proceed
            string source = s.ToUpper().Replace(" ", "");
            result.Append(source[0]);
            char prev = '0';

            for (int i = 1; i < source.Length; i++)
            {
                char mappedTo = '0';
                char thisChar = source[i];

                if ("BFPV".Contains(thisChar))
                {
                    mappedTo = '1';
                }
                else if ("CGJKQSXZ".Contains(thisChar))
                {
                    mappedTo = '2';
                }
                else if ("DT".Contains(thisChar))
                {
                    mappedTo = '3';
                }
                else if ('L' == thisChar)
                {
                    mappedTo = '4';
                }
                else if ("MN".Contains(thisChar))
                {
                    mappedTo = '5';
                }
                else if ('R' == thisChar)
                {
                    mappedTo = '6';
                }

                // ignore duplicates and non-mached
                if (mappedTo != prev && mappedTo != '0')
                {
                    result.Append(mappedTo);
                    prev = mappedTo;
                }
            }
            while (result.Length < 4) result.Append("0");

            return result.ToString(0, 4);
        }
    }
    static class Extensions
    {
        public static Employee FooMethod(this Employee employee, int i)
        {
            if (i % 2 == 0)
                return employee;
            else
                return null;
        }

        public static IEnumerable<T> GetNotNull<T>(this IEnumerable<T> elements)
        {
            foreach (var item in elements)
            {
                if (item != null)
                    yield return item;
                else
                    continue;
            }
        }
    }

    interface Human { }
    class Person : Human
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class Employee : Person
    {
        public int ManagerID { get; set; }
    }
    class Manager : Person
    {
        public List<int> Employees { get; set; }
        public Manager()
        {
            Employees = new List<int>();
        }
    }

    class Job
    {
        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
    }

    class JobDescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }

    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
    }

    class CallLog
    {
        public string Number { get; set; }
        public bool Incoming { get; set; }
    }
}
